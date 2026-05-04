using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Windows.Forms;
using Figuras2D.Models;
using Figuras2D.Presenters;

namespace Figuras2D
{
    public partial class FrmRectangulo : Form
    {
        private Rectangulo _rectanguloActual;

        private const float Margin = 20f;
        private const double MinRenderableSize = 20;

        public FrmRectangulo()
        {
            InitializeComponent();

            panel2.Size = new Size(390, 390);

            btnCalcular.Click += btnCalcular_Click;
            btnLimpiarCampos.Click += btnLimpiarCampos_Click;
            panel2.Paint += panel2_Paint;

            this.BackColor = AppTheme.BgMain;
            this.ForeColor = AppTheme.TextPri;
            this.Font = AppTheme.FontMenu;
            this.btnCalcular.BackColor = AppTheme.Accent;
            this.btnCalcular.ForeColor = AppTheme.TextPri;
            this.btnLimpiarCampos.BackColor = AppTheme.Accent;
            this.btnLimpiarCampos.ForeColor = AppTheme.TextPri;
            this.lblMensaje.ForeColor = AppTheme.alert;
        }

        private bool TryGetDouble(TextBox textBox, out double value)
        {
            return double.TryParse(textBox.Text, NumberStyles.Float, CultureInfo.CurrentCulture, out value) ||
                   double.TryParse(textBox.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out value);
        }

        private float GetMaxRenderableWidth()
        {
            return panel2.ClientSize.Width - (2 * Margin);
        }

        private float GetMaxRenderableHeight()
        {
            return panel2.ClientSize.Height - (2 * Margin);
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (!TryGetDouble(txtAncho, out double ancho) ||
                !TryGetDouble(txtAlto, out double alto))
            {
                lblMensaje.Text = "Ingrese valores numéricos válidos.";
                lblAreaResultado.Text = "0.00";
                lblPerimetroResultado.Text = "0.00";
                _rectanguloActual = null;
                panel2.Invalidate();
                return;
            }

            Rectangulo rectangulo = new Rectangulo(ancho, alto);
            RectanguloPresenter presenter = new RectanguloPresenter(rectangulo);

            if (!presenter.IsValid)
            {
                lblMensaje.Text = "El ancho y el alto deben ser mayores que cero.";
                lblAreaResultado.Text = "0.00";
                lblPerimetroResultado.Text = "0.00";
                _rectanguloActual = null;
                panel2.Invalidate();
                return;
            }

            float maxRenderableWidth = GetMaxRenderableWidth();
            float maxRenderableHeight = GetMaxRenderableHeight();

            if (ancho < MinRenderableSize || alto < MinRenderableSize)
            {
                lblMensaje.Text = $"El rectángulo es demasiado pequeño. Use valores mayores o iguales a {MinRenderableSize:0.00}.";
                lblAreaResultado.Text = presenter.Area.ToString("0.00");
                lblPerimetroResultado.Text = presenter.Perimeter.ToString("0.00");
                _rectanguloActual = null;
                panel2.Invalidate();
                return;
            }

            if (ancho > maxRenderableWidth)
            {
                lblMensaje.Text = $"El rectángulo no se puede renderizar. El ancho máximo para este panel es {maxRenderableWidth:0.00}.";
                lblAreaResultado.Text = presenter.Area.ToString("0.00");
                lblPerimetroResultado.Text = presenter.Perimeter.ToString("0.00");
                _rectanguloActual = null;
                panel2.Invalidate();
                return;
            }

            if (alto > maxRenderableHeight)
            {
                lblMensaje.Text = $"El rectángulo no se puede renderizar. El alto máximo para este panel es {maxRenderableHeight:0.00}.";
                lblAreaResultado.Text = presenter.Area.ToString("0.00");
                lblPerimetroResultado.Text = presenter.Perimeter.ToString("0.00");
                _rectanguloActual = null;
                panel2.Invalidate();
                return;
            }

            _rectanguloActual = rectangulo;
            lblAreaResultado.Text = presenter.Area.ToString("0.00");
            lblPerimetroResultado.Text = presenter.Perimeter.ToString("0.00");
            lblMensaje.Text = "";
            panel2.Invalidate();
        }

        private void btnLimpiarCampos_Click(object sender, EventArgs e)
        {
            txtAncho.Clear();
            txtAlto.Clear();
            lblAreaResultado.Text = "0.00";
            lblPerimetroResultado.Text = "0.00";
            lblMensaje.Text = "";
            _rectanguloActual = null;
            panel2.Invalidate();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            if (_rectanguloActual == null) return;

            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            float ancho = (float)_rectanguloActual.Ancho;
            float alto = (float)_rectanguloActual.Alto;

            float x = (panel2.ClientSize.Width - ancho) / 2f;
            float y = (panel2.ClientSize.Height - alto) / 2f;

            using (SolidBrush brush = new SolidBrush(Color.CornflowerBlue))
            using (Pen pen = new Pen(Color.Black, 2))
            {
                graphics.FillRectangle(brush, x, y, ancho, alto);
                graphics.DrawRectangle(pen, x, y, ancho, alto);
            }
        }
    }
}