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
    public partial class FrmScalenTriangle : Form
    {
        private ScaleneTriangle _figuraActual;
        private Transformacion2D _transformacion = new Transformacion2D();

        private const float margin = 20f;

        private float GetMaxRenderableDiameter()
        {
            return Math.Min(panel1.ClientSize.Width, panel1.ClientSize.Height) - (2 * margin);
        }

        private double GetMaxRenderableSide()
        {
            float maxDiameter = GetMaxRenderableDiameter();
            return maxDiameter / 2.0;
        }

        public FrmScalenTriangle()
        {
            InitializeComponent();

            btnCalcular.Click += btnCalcular_Click;
            btnLimpiar.Click += btnLimpiar_Click;

            txtLado1.TextChanged += (s, e) => LimpiarResultados();
            txtLado2.TextChanged += (s, e) => LimpiarResultados();
            txtLado3.TextChanged += (s, e) => LimpiarResultados();

            panel1.Paint += panel1_Paint;

            this.KeyPreview = true;
            this.KeyDown += FrmScalenTriangle_KeyDown;

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
            return double.TryParse(textBox.Text, NumberStyles.Float, CultureInfo.CurrentCulture, out value) ||
                   double.TryParse(textBox.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out value);
        }

        private void LimpiarResultados()
        {
            lblAreaResult.Text = "0.00";
            lblPerimetroResult.Text = "0.00";
            lblMensaje.Text = string.Empty;

            _figuraActual = null;
            _transformacion.Reiniciar();

            panel1.Invalidate();
        }

        private void txtLado1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarResultados();

            txtLado1.Text = "";
            txtLado2.Text = "";
            txtLado3.Text = "";
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (!TryGetDouble(txtLado1, out double a) ||
                !TryGetDouble(txtLado2, out double b) ||
                !TryGetDouble(txtLado3, out double c))
            {
                LimpiarResultados();
                lblMensaje.Text = "Ingrese valores numéricos válidos en los tres lados.";
                return;
            }

            var triangle = new ScaleneTriangle(a, b, c);
            var presenter = new ScaleneTrianglePresenter(triangle);

            if (!presenter.IsValid)
            {
                LimpiarResultados();

                lblMensaje.Text =
                    "Triángulo inválido. Verifique que:\n" +
                    "  • Los tres lados sean mayores a 0.\n" +
                    "  • Se cumpla la desigualdad triangular.\n" +
                    "  • Los tres lados sean distintos (escaleno).";
                return;
            }

            double maxRenderableSide = GetMaxRenderableSide();

            if (maxRenderableSide < 0)
            {
                LimpiarResultados();
                lblMensaje.Text = "El área de dibujo es demasiado pequeña para mostrar el triángulo.";
                return;
            }

            _figuraActual = triangle;

            lblAreaResult.Text = presenter.Area.ToString("0.00");
            lblPerimetroResult.Text = presenter.Perimeter.ToString("0.00");
            lblMensaje.Text = "";

            panel1.Invalidate();
        }

        private void txtLado2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLado3_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (_figuraActual == null)
                return;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(panel1.BackColor);

            float escala = 5f;

            double a = _figuraActual.SideA * escala;
            double b = _figuraActual.SideB * escala;
            double c = _figuraActual.SideC * escala;

            double cosA = (b * b + c * c - a * a) / (2 * b * c);

            if (cosA < -1)
                cosA = -1;

            if (cosA > 1)
                cosA = 1;

            double angA = Math.Acos(cosA);

            PointF[] puntos = new PointF[3];

            puntos[0] = new PointF(0f, 0f);
            puntos[1] = new PointF((float)c, 0f);
            puntos[2] = new PointF(
                (float)(b * Math.Cos(angA)),
                (float)(-b * Math.Sin(angA))
            );

            float minX = Math.Min(puntos[0].X, Math.Min(puntos[1].X, puntos[2].X));
            float maxX = Math.Max(puntos[0].X, Math.Max(puntos[1].X, puntos[2].X));
            float minY = Math.Min(puntos[0].Y, Math.Min(puntos[1].Y, puntos[2].Y));
            float maxY = Math.Max(puntos[0].Y, Math.Max(puntos[1].Y, puntos[2].Y));

            float anchoTriangulo = maxX - minX;
            float altoTriangulo = maxY - minY;

            float offsetX = panel1.ClientSize.Width / 2f - anchoTriangulo / 2f - minX;
            float offsetY = panel1.ClientSize.Height / 2f - altoTriangulo / 2f - minY;

            for (int i = 0; i < puntos.Length; i++)
            {
                puntos[i].X += offsetX;
                puntos[i].Y += offsetY;
            }

            PointF centro = new PointF(
                panel1.ClientSize.Width / 2f,
                panel1.ClientSize.Height / 2f
            );

            for (int i = 0; i < puntos.Length; i++)
            {
                puntos[i] = _transformacion.Aplicar(puntos[i], centro);
            }

            using (var brush = new SolidBrush(Color.FromArgb(180, 173, 216, 230)))
            using (var pen = new Pen(Color.SteelBlue, 2))
            {
                g.FillPolygon(brush, puntos);
                g.DrawPolygon(pen, puntos);
            }
        }

        private void FrmScalenTriangle_KeyDown(object sender, KeyEventArgs e)
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