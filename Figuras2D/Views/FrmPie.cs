using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Windows.Forms;
using Figuras2D.Models;
using Figuras2D.Presenters;
using Figuras2D.Helpers;

namespace Figuras2D
{
    public partial class FrmPie : Form
    {
        private Pie _pieActual;
        private Transformacion2D _transformacion = new Transformacion2D();

        private const float Margin = 20f;
        private const double MinRenderableRadius = 10;

        public FrmPie()
        {
            InitializeComponent();

            panel2.Size = new Size(390, 390);

            btnCalcular.Click += btnCalcular_Click;
            btnLimpiarCampos.Click += btnLimpiarCampos_Click;
            panel2.Paint += panel2_Paint;

            this.KeyPreview = true;
            this.KeyDown += FrmPie_KeyDown;

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

        private float GetMaxRenderableRadius()
        {
            float maxDiameter = Math.Min(panel2.ClientSize.Width, panel2.ClientSize.Height) - (2 * Margin);

            return maxDiameter / 2f;
        }

        private double GetVisibleAngle(double startAngle, double endAngle)
        {
            double visibleAngle = endAngle - startAngle;

            if (visibleAngle < 0)
            {
                visibleAngle += 360;
            }

            return visibleAngle;
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (!TryGetDouble(txtRadio, out double radio) ||
                !TryGetDouble(txtAnguloInicial, out double anguloInicial) ||
                !TryGetDouble(txtAnguloFinal, out double anguloFinal))
            {
                lblMensaje.Text = "Ingrese valores numéricos válidos.";
                lblAreaResultado.Text = "0.00";
                lblPerimetroResultado.Text = "0.00";

                _pieActual = null;
                panel2.Invalidate();
                return;
            }

            Pie pie = new Pie(radio, anguloInicial, anguloFinal);
            PiePresenter presenter = new PiePresenter(pie);

            if (!presenter.IsValid)
            {
                lblMensaje.Text = "El radio debe ser mayor que cero. Los ángulos deben estar entre 0 y 360 y no pueden ser iguales.";
                lblAreaResultado.Text = "0.00";
                lblPerimetroResultado.Text = "0.00";

                _pieActual = null;
                panel2.Invalidate();
                return;
            }

            double visibleAngle = GetVisibleAngle(anguloInicial, anguloFinal);

            if (visibleAngle <= 0 || visibleAngle >= 360)
            {
                lblMensaje.Text = "El ángulo visible debe ser mayor que 0 y menor que 360 grados.";
                lblAreaResultado.Text = presenter.Area.ToString("0.00");
                lblPerimetroResultado.Text = presenter.Perimeter.ToString("0.00");

                _pieActual = null;
                panel2.Invalidate();
                return;
            }

            float maxRenderableRadius = GetMaxRenderableRadius();

            if (radio < MinRenderableRadius)
            {
                lblMensaje.Text = $"El sector circular es demasiado pequeño para visualizarse claramente. Use un radio mayor o igual a {MinRenderableRadius:0.00}.";
                lblAreaResultado.Text = presenter.Area.ToString("0.00");
                lblPerimetroResultado.Text = presenter.Perimeter.ToString("0.00");

                _pieActual = null;
                panel2.Invalidate();
                return;
            }

            if (radio > maxRenderableRadius)
            {
                lblMensaje.Text = $"El sector circular no se puede renderizar. El radio máximo para este panel es {maxRenderableRadius:0.00}.";
                lblAreaResultado.Text = presenter.Area.ToString("0.00");
                lblPerimetroResultado.Text = presenter.Perimeter.ToString("0.00");

                _pieActual = null;
                panel2.Invalidate();
                return;
            }

            _pieActual = pie;

            lblAreaResultado.Text = presenter.Area.ToString("0.00");
            lblPerimetroResultado.Text = presenter.Perimeter.ToString("0.00");
            lblMensaje.Text = "";

            panel2.Invalidate();
        }

        private void btnLimpiarCampos_Click(object sender, EventArgs e)
        {
            txtRadio.Clear();
            txtAnguloInicial.Clear();
            txtAnguloFinal.Clear();

            lblAreaResultado.Text = "0.00";
            lblPerimetroResultado.Text = "0.00";
            lblMensaje.Text = "";

            _pieActual = null;
            _transformacion.Reiniciar();

            panel2.Invalidate();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            if (_pieActual == null)
            {
                return;
            }

            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.Clear(panel2.BackColor);

            float radio = (float)_pieActual.Radius;
            float radioTransformado = radio * _transformacion.FactorEscala;
            float diametroTransformado = radioTransformado * 2f;

            float centerX = panel2.ClientSize.Width / 2f;
            float centerY = panel2.ClientSize.Height / 2f;

            PointF centroOriginal = new PointF(centerX, centerY);
            PointF centroTransformado = _transformacion.Aplicar(centroOriginal, centroOriginal);

            float anguloInicial = -(float)_pieActual.StartAngle;
            float anguloVisible = -(float)(_pieActual.EndAngle - _pieActual.StartAngle);

            if (anguloVisible > 0)
            {
                anguloVisible -= 360f;
            }

            GraphicsState estadoOriginal = graphics.Save();

            graphics.TranslateTransform(centroTransformado.X, centroTransformado.Y);
            graphics.RotateTransform(_transformacion.AnguloRotacion);

            using (SolidBrush brush = new SolidBrush(Color.MediumSlateBlue))
            using (Pen pen = new Pen(Color.Black, 2))
            {
                graphics.FillPie(
                    brush,
                    -radioTransformado,
                    -radioTransformado,
                    diametroTransformado,
                    diametroTransformado,
                    anguloInicial,
                    anguloVisible
                );

                graphics.DrawPie(
                    pen,
                    -radioTransformado,
                    -radioTransformado,
                    diametroTransformado,
                    diametroTransformado,
                    anguloInicial,
                    anguloVisible
                );
            }

            graphics.Restore(estadoOriginal);
        }

        private void FrmPie_KeyDown(object sender, KeyEventArgs e)
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
                panel2.Invalidate();
            }
        }
    }
}