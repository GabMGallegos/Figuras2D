using Figuras2D.Models;
using Figuras2D.Presenters;
using Figuras2D.Helpers;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Windows.Forms;

namespace Figuras2D.Views
{
    public partial class FrmClover : Form
    {
        private Clover _figuraActual;
        private Transformacion2D _transformacion = new Transformacion2D();

        private const float margin = 20f;
        private const double MinRenderableSide = 20;

        private float GetMaxRenderableDiameter()
        {
            return Math.Min(panel1.ClientSize.Width, panel1.ClientSize.Height) - (2 * margin);
        }

        private double GetMaxRenderableSide()
        {
            float maxDiameter = GetMaxRenderableDiameter();
            return maxDiameter / 2.0;
        }

        public FrmClover()
        {
            InitializeComponent();

            btnCalcular.Click += btnCalcular_Click;
            btnLimpiar.Click += btnLimpiar_Click;
            panel1.Paint += panelTrebol_Paint;

            txtRadio.TextChanged += (s, e) => LimpiarResultados();

            this.KeyPreview = true;
            this.KeyDown += FrmClover_KeyDown;

            this.BackColor = AppTheme.BgMain;
            this.ForeColor = AppTheme.TextPri;
            this.Font = AppTheme.FontMenu;
            this.btnCalcular.BackColor = AppTheme.Accent;
            this.btnCalcular.ForeColor = AppTheme.TextPri;
            this.btnLimpiar.BackColor = AppTheme.Accent;
            this.btnLimpiar.ForeColor = AppTheme.TextPri;
            this.lblMensaje.ForeColor = AppTheme.alert;
        }

        private bool TryGetDouble(TextBox textBox, out double value)
        {
            return double.TryParse(
                       textBox.Text,
                       NumberStyles.Float,
                       CultureInfo.CurrentCulture,
                       out value)
                || double.TryParse(
                       textBox.Text,
                       NumberStyles.Float,
                       CultureInfo.InvariantCulture,
                       out value);
        }

        private void LimpiarResultados()
        {
            lblAreaResult.Text = "0.00";
            lblPerimetroResult.Text = "0.00";
            lblMensaje.Text = "";

            _figuraActual = null;
            _transformacion.Reiniciar();

            panel1.Invalidate();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (!TryGetDouble(txtRadio, out double radio))
            {
                LimpiarResultados();
                lblMensaje.Text = "Ingrese un valor numérico válido para el radio.";
                return;
            }

            var clover = new Clover(radio);
            var presenter = new CloverPresenter(clover);

            if (!presenter.IsValid)
            {
                LimpiarResultados();
                lblMensaje.Text = "El radio debe ser mayor a 0.";
                return;
            }

            double maxRenderableSide = GetMaxRenderableSide();

            if (radio < MinRenderableSide)
            {
                lblMensaje.Text = $"El trebol es muy pequeño. Use un radio ≥ {MinRenderableSide:0.00}.";
                _figuraActual = null;
                panel1.Invalidate();
                return;
            }

            if (radio > maxRenderableSide)
            {
                lblMensaje.Text = $"El trebol es muy grande. El radio máximo es {maxRenderableSide:0.00}.";
                _figuraActual = null;
                panel1.Invalidate();
                return;
            }

            _figuraActual = clover;

            lblAreaResult.Text = presenter.Area.ToString("0.00");
            lblPerimetroResult.Text = presenter.Perimeter.ToString("0.00");
            lblMensaje.Text = "";

            panel1.Invalidate();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarResultados();
            txtRadio.Text = "";
        }

        private void panelTrebol_Paint(object sender, PaintEventArgs e)
        {
            if (_figuraActual == null)
                return;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(panel1.BackColor);

            float cx = panel1.ClientSize.Width / 2f;
            float cy = panel1.ClientSize.Height / 2f;

            float r = (float)_figuraActual.Radius;
            float rTransformado = r * _transformacion.FactorEscala;

            PointF centroOriginal = new PointF(cx, cy);
            PointF centroTransformado = _transformacion.Aplicar(centroOriginal, centroOriginal);

            GraphicsState estadoOriginal = g.Save();

            g.TranslateTransform(centroTransformado.X, centroTransformado.Y);
            g.RotateTransform(_transformacion.AnguloRotacion);

            using (var path = new GraphicsPath())
            using (var brush = new SolidBrush(Color.FromArgb(180, 32, 178, 170)))
            using (var pen = new Pen(Color.SeaGreen, 2))
            {
                for (int i = 0; i < 3; i++)
                {
                    double angulo = (i * 120 - 90) * Math.PI / 180.0;

                    float lx = (float)(rTransformado * Math.Cos(angulo));
                    float ly = (float)(rTransformado * Math.Sin(angulo));

                    path.AddEllipse(
                        lx - rTransformado,
                        ly - rTransformado,
                        2 * rTransformado,
                        2 * rTransformado
                    );
                }

                g.FillPath(brush, path);
                g.DrawPath(pen, path);
            }

            g.Restore(estadoOriginal);
        }

        private void FrmClover_KeyDown(object sender, KeyEventArgs e)
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
                panel1.Invalidate();
            }
        }
    }
}