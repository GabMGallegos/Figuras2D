using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Windows.Forms;
using Figuras2D.Models;
using Figuras2D.Presenters;

namespace Figuras2D
{
    public partial class FrmScaleneTriangle : Form
    {
        private ScaleneTriangle _triangleActual;
        private const float Margin = 20f;

        public FrmScaleneTriangle()
        {
            InitializeComponent();

            // Configuración del panel de dibujo (ajusta el nombre si es distinto a panel2)
            panel1.Paint += panel1_Paint;
            btnCalcular.Click += btnCalcular_Click;
        }

        private bool TryGetDouble(TextBox textBox, out double value)
        {
            return double.TryParse(textBox.Text, NumberStyles.Float, CultureInfo.CurrentCulture, out value) ||
                   double.TryParse(textBox.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out value);
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {

            if (!TryGetDouble(txtLado1, out double a) ||
                !TryGetDouble(txtLado2, out double b) ||
                !TryGetDouble(txtLado3, out double c))
            {
                return;
            }


            ScaleneTriangle triangle = new ScaleneTriangle(a, b, c);
            ScaleneTrianglePresenter presenter = new ScaleneTrianglePresenter(triangle);


            lblAreaR.Text = presenter.Area.ToString("0.00");
            lblPerimetroR.Text = presenter.Perimeter.ToString("0.00");
            _triangleActual = triangle;
            panel1.Invalidate();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            if (_triangleActual == null) return;

            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Determinamos una escala automática para que quepa en el panel
            // Tomamos el lado más largo para escalar
            float maxLado = (float)Math.Max(_triangleActual.SideA, Math.Max(_triangleActual.SideB, _triangleActual.SideC));
            float disponible = Math.Min(panel1.Width, panel1.Height) - (Margin * 2);
            float escala = disponible / maxLado;

            // Obtenemos los puntos desde el modelo con la escala calculada
            PointF[] puntos = _triangleActual.GetDrawingPoints(escala);

            // Centrar el dibujo en el panel
            graphics.TranslateTransform(panel1.Width / 2f, panel1.Height / 2f);

            using (SolidBrush brush = new SolidBrush(Color.LightBlue))
            using (Pen pen = new Pen(Color.Blue, 2))
            {
                graphics.FillPolygon(brush, puntos);
                graphics.DrawPolygon(pen, puntos);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtLado1.Clear();
            txtLado2.Clear();
            txtLado3.Clear();
            LimpiarResultados();
            _triangleActual = null;
            panel1.Invalidate();
        }

        private void LimpiarResultados()
        {
            lblAreaR.Text = "0.00";
            lblPerimetroR.Text = "0.00";
            _triangleActual = null;
            panel1.Invalidate();
        }
    }
}