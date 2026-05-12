using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Windows.Forms;
using Figuras2D.Models;
using Figuras2D.Presenters;
using Figuras2D.Helpers;

namespace Figuras2D.Views
{
    public partial class FrmElipse : Form
    {
        private Elipse _elipseActual;
        private Transformacion2D _transformacion = new Transformacion2D();

        private const float Margin = 20f;

        public FrmElipse()
        {
            InitializeComponent();

            // Eventos
            btnCalcular.Click += btnCalcular_Click;
            btnLimpiarCampos.Click += btnLimpiarCampos_Click;
            panelElipse.Paint += panelElipse_Paint;

            this.KeyPreview = true;
            this.KeyDown += FrmElipse_KeyDown;

            // AppTheme
            this.BackColor = AppTheme.BgMain;
            this.ForeColor = AppTheme.TextPri;
            this.Font = AppTheme.FontMenu;

            this.btnCalcular.BackColor = AppTheme.Accent;
            this.btnCalcular.ForeColor = AppTheme.TextPri;

            this.btnLimpiarCampos.BackColor = AppTheme.Accent;
            this.btnLimpiarCampos.ForeColor = AppTheme.TextPri;

            this.lblMensaje.ForeColor = AppTheme.alert;
        }

        private bool TryGetDouble(TextBox txt, out double value)
        {
            return double.TryParse(txt.Text, NumberStyles.Float, CultureInfo.CurrentCulture, out value) ||
                   double.TryParse(txt.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out value);
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (!TryGetDouble(txtSemiejeMayor, out double a) ||
                !TryGetDouble(txtSemiejeMenor, out double b))
            {
                lblMensaje.Text = "Ingrese valores válidos.";
                lblAreaResultado.Text = "0.00";
                lblPerimetroResultado.Text = "0.00";
                _elipseActual = null;
                panelElipse.Invalidate();
                return;
            }

            Elipse elipse = new Elipse(a, b);
            ElipsePresenter presenter = new ElipsePresenter(elipse);

            if (!presenter.IsValid)
            {
                lblMensaje.Text = "Los valores deben ser mayores que 0.";
                lblAreaResultado.Text = "0.00";
                lblPerimetroResultado.Text = "0.00";
                _elipseActual = null;
                panelElipse.Invalidate();
                return;
            }

            float escalaFija = 5f;
            double anchoReal = a * 2 * escalaFija;
            double altoReal = b * 2 * escalaFija;

            if (anchoReal > panelElipse.ClientSize.Width - (2 * Margin) ||
                altoReal > panelElipse.ClientSize.Height - (2 * Margin))
            {
                lblMensaje.Text = "La elipse es demasiado grande para el panel.";
                lblAreaResultado.Text = presenter.Area.ToString("0.00");
                lblPerimetroResultado.Text = presenter.Perimeter.ToString("0.00");
                _elipseActual = null;
                panelElipse.Invalidate();
                return;
            }

            _elipseActual = elipse;

            lblAreaResultado.Text = presenter.Area.ToString("0.00");
            lblPerimetroResultado.Text = presenter.Perimeter.ToString("0.00");
            lblMensaje.Text = "";

            panelElipse.Invalidate();
        }

        private void btnLimpiarCampos_Click(object sender, EventArgs e)
        {
            txtSemiejeMayor.Clear();
            txtSemiejeMenor.Clear();

            lblAreaResultado.Text = "0.00";
            lblPerimetroResultado.Text = "0.00";
            lblMensaje.Text = "";

            _elipseActual = null;
            _transformacion.Reiniciar();

            panelElipse.Invalidate();
        }

        private void panelElipse_Paint(object sender, PaintEventArgs e)
        {
            if (_elipseActual == null)
                return;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(panelElipse.BackColor);

            float escalaFija = 5f;

            float width = (float)_elipseActual.SemiejeMayor * 2 * escalaFija;
            float height = (float)_elipseActual.SemiejeMenor * 2 * escalaFija;

            PointF centroOriginal = new PointF(
                panelElipse.ClientSize.Width / 2f,
                panelElipse.ClientSize.Height / 2f
            );

            PointF centroTransformado = _transformacion.Aplicar(centroOriginal, centroOriginal);

            float widthTransformado = width * _transformacion.FactorEscala;
            float heightTransformado = height * _transformacion.FactorEscala;

            GraphicsState estadoOriginal = g.Save();

            g.TranslateTransform(centroTransformado.X, centroTransformado.Y);
            g.RotateTransform(_transformacion.AnguloRotacion);

            RectangleF rectanguloElipse = new RectangleF(
                -widthTransformado / 2f,
                -heightTransformado / 2f,
                widthTransformado,
                heightTransformado
            );

            using (SolidBrush brush = new SolidBrush(Color.Tomato))
            using (Pen pen = new Pen(Color.Black, 2))
            {
                g.FillEllipse(brush, rectanguloElipse);
                g.DrawEllipse(pen, rectanguloElipse);
            }

            g.Restore(estadoOriginal);
        }

        private void FrmElipse_KeyDown(object sender, KeyEventArgs e)
        {
            float pasoTraslacion = 10f;
            float pasoEscala = 1.1f;
            float pasoRotacion = 10f;

            bool huboTransformacion = _transformacion.ProcesarTecla(
                e.KeyCode,
                pasoTraslacion,
                pasoEscala,
                pasoRotacion
            );

            if (huboTransformacion)
            {
                panelElipse.Invalidate();
            }
        }
    }
}