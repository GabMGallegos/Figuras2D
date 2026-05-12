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
    public partial class FrmTrapezoid : Form
    {
        private Trapezoid _figuraActual;
        private Transformacion2D _transformacion = new Transformacion2D();

        private const float margin = 20f;
        private const double MinRenderableSide = 20;

        private float GetMaxRenderableDiameter()
        {
            return Math.Min(panel1.ClientSize.Width, panel1.ClientSize.Height) - (2 * margin);
        }

        private double GetMaxRenderableSide()
        {
            return GetMaxRenderableDiameter();
        }

        public FrmTrapezoid()
        {
            InitializeComponent();

            btnCalcular.Click += btnCalcular_Click;
            btnLimpiar.Click += btnLimpiar_Click;
            panel1.Paint += panelTrapecio_Paint;

            txtBaseMayor.TextChanged += (s, e) => LimpiarResultados();
            txtBaseMenor.TextChanged += (s, e) => LimpiarResultados();
            txtAltura.TextChanged += (s, e) => LimpiarResultados();

            this.KeyPreview = true;
            this.KeyDown += FrmTrapezoid_KeyDown;

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
            if (!TryGetDouble(txtBaseMayor, out double bMayor) ||
                !TryGetDouble(txtBaseMenor, out double bMenor) ||
                !TryGetDouble(txtAltura, out double h))
            {
                LimpiarResultados();
                lblMensaje.Text = "Ingrese valores numéricos válidos en los tres campos.";
                return;
            }

            var trapezoid = new Trapezoid(bMayor, bMenor, h);
            var presenter = new TrapezoidPresenter(trapezoid);

            if (!presenter.IsValid)
            {
                LimpiarResultados();

                lblMensaje.Text =
                    "Trapecio inválido. Verifique que:\n" +
                    "  • Todos los valores sean mayores a 0.\n" +
                    "  • La base mayor sea estrictamente mayor que la base menor.";
                return;
            }

            double maxRenderableSide = GetMaxRenderableSide();

            if (bMayor == bMenor)
            {
                lblMensaje.Text = "El trapecio es en realidad un rectángulo.";
                _figuraActual = null;
                panel1.Invalidate();
                return;
            }

            if (bMayor < MinRenderableSide)
            {
                lblMensaje.Text = $"El trapecio es muy pequeño. Use un lado ≥ {MinRenderableSide:0.00}.";
                _figuraActual = null;
                panel1.Invalidate();
                return;
            }

            if (bMayor > maxRenderableSide)
            {
                lblMensaje.Text = $"El trapecio es muy grande. El lado máximo es {maxRenderableSide:0.00}.";
                _figuraActual = null;
                panel1.Invalidate();
                return;
            }

            _figuraActual = trapezoid;

            lblAreaResult.Text = presenter.Area.ToString("0.00");
            lblPerimetroResult.Text = presenter.Perimeter.ToString("0.00");
            lblMensaje.Text = "";

            panel1.Invalidate();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarResultados();

            txtBaseMayor.Text = "";
            txtBaseMenor.Text = "";
            txtAltura.Text = "";
        }

        private void panelTrapecio_Paint(object sender, PaintEventArgs e)
        {
            if (_figuraActual == null)
                return;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(panel1.BackColor);

            float escala = 5f;

            float bMayor = (float)_figuraActual.MajorBase * escala;
            float bMenor = (float)_figuraActual.MinorBase * escala;
            float h = (float)_figuraActual.Height * escala;

            float cx = panel1.ClientSize.Width / 2f;
            float cy = panel1.ClientSize.Height / 2f;

            PointF centro = new PointF(cx, cy);

            PointF[] puntos = new PointF[]
            {
                new PointF(cx - bMayor / 2f, cy + h / 2f),
                new PointF(cx + bMayor / 2f, cy + h / 2f),
                new PointF(cx + bMenor / 2f, cy - h / 2f),
                new PointF(cx - bMenor / 2f, cy - h / 2f)
            };

            for (int i = 0; i < puntos.Length; i++)
            {
                puntos[i] = _transformacion.Aplicar(puntos[i], centro);
            }

            using (var brush = new SolidBrush(Color.FromArgb(180, 144, 238, 144)))
            using (var pen = new Pen(Color.DarkGreen, 2))
            {
                g.FillPolygon(brush, puntos);
                g.DrawPolygon(pen, puntos);
            }
        }

        private void FrmTrapezoid_KeyDown(object sender, KeyEventArgs e)
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