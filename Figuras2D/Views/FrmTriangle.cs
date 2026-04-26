using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Windows.Forms;
using Figuras2D.Models;
using Figuras2D.Presenters;

namespace Figuras2D.Views
{
    public partial class FrmTriangle : Form
    {
        private Triangle _triangleActual;
        private const float Margin = 20f;
        private const double MinRenderableSize = 10;

        public FrmTriangle()
        {
            InitializeComponent();
            btnCalcular.Click += btnCalcular_Click;
            btnLimpiarCampos.Click += btnLimpiarCampos_Click;
            panelTriangulo.Paint += panelTriangulo_Paint;
        }

        private bool TryGetDouble(TextBox textBox, out double value)
        {
            return double.TryParse(textBox.Text, NumberStyles.Float, CultureInfo.CurrentCulture, out value) ||
                   double.TryParse(textBox.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out value);
        }

        private float GetMaxRenderableWidth()
        {
            return panelTriangulo.ClientSize.Width - (2 * Margin);
        }

        private float GetMaxRenderableHeight()
        {
            return panelTriangulo.ClientSize.Height - (2 * Margin);
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (!TryGetDouble(txtLadoA, out double ladoA) ||
                !TryGetDouble(txtLadoB, out double ladoB) ||
                !TryGetDouble(txtLadoC, out double ladoC))
            {
                lblMensaje.Text = "Ingrese valores numéricos válidos.";
                lblAreaResultado.Text = "0.00";
                lblPerimetroResultado.Text = "0.00";

                _triangleActual = null;
                panelTriangulo.Invalidate();
                return;
            }

            Triangle triangle = new Triangle(ladoA, ladoB, ladoC);
            TrianglePresenter presenter = new TrianglePresenter(triangle);

            if (!presenter.IsValid)
            {
                lblMensaje.Text = "Triángulo inválido. Verifique que los lados sean mayores a 0 y cumplan la desigualdad triangular.";
                lblAreaResultado.Text = "0.00";
                lblPerimetroResultado.Text = "0.00";

                _triangleActual = null;
                panelTriangulo.Invalidate();
                return;
            }

            float maxRenderableWidth = GetMaxRenderableWidth();
            float maxRenderableHeight = GetMaxRenderableHeight();

            double[] lados = { ladoA, ladoB, ladoC };
            double ladoMaximo = Math.Max(ladoA, Math.Max(ladoB, ladoC));

            if (ladoMaximo < MinRenderableSize)
            {
                lblMensaje.Text = $"El triángulo es demasiado pequeño. Use lados mayores o iguales a {MinRenderableSize:0.00}.";
                lblAreaResultado.Text = presenter.Area.ToString("0.00");
                lblPerimetroResultado.Text = presenter.Perimeter.ToString("0.00");

                _triangleActual = null;
                panelTriangulo.Invalidate();
                return;
            }

            if (ladoMaximo > maxRenderableWidth)
            {
                lblMensaje.Text = $"El triángulo no se puede renderizar. El lado máximo para este panel es {maxRenderableWidth:0.00}.";
                lblAreaResultado.Text = presenter.Area.ToString("0.00");
                lblPerimetroResultado.Text = presenter.Perimeter.ToString("0.00");

                _triangleActual = null;
                panelTriangulo.Invalidate();
                return;
            }

            _triangleActual = triangle;

            lblAreaResultado.Text = presenter.Area.ToString("0.00");
            lblPerimetroResultado.Text = presenter.Perimeter.ToString("0.00");
            lblMensaje.Text = "";

            panelTriangulo.Invalidate();
        }

        private void btnLimpiarCampos_Click(object sender, EventArgs e)
        {
            txtLadoA.Clear();
            txtLadoB.Clear();
            txtLadoC.Clear();

            lblAreaResultado.Text = "0.00";
            lblPerimetroResultado.Text = "0.00";
            lblMensaje.Text = "";

            _triangleActual = null;
            panelTriangulo.Invalidate();
        }

        private void panelTriangulo_Paint(object sender, PaintEventArgs e)
        {
            if (_triangleActual == null)
                return;

            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.Clear(panelTriangulo.BackColor);

            double a = _triangleActual.SideA;
            double b = _triangleActual.SideB;
            double c = _triangleActual.SideC;

            PointF[] puntos = CalcularPuntosTriangulo(a, b, c);

            float minX = Math.Min(puntos[0].X, Math.Min(puntos[1].X, puntos[2].X));
            float maxX = Math.Max(puntos[0].X, Math.Max(puntos[1].X, puntos[2].X));
            float minY = Math.Min(puntos[0].Y, Math.Min(puntos[1].Y, puntos[2].Y));
            float maxY = Math.Max(puntos[0].Y, Math.Max(puntos[1].Y, puntos[2].Y));

            float anchoTriangulo = maxX - minX;
            float altoTriangulo = maxY - minY;

            float escalaX = (panelTriangulo.ClientSize.Width - 2 * Margin) / anchoTriangulo;
            float escalaY = (panelTriangulo.ClientSize.Height - 2 * Margin) / altoTriangulo;
            float escala = Math.Min(escalaX, escalaY);

            for (int i = 0; i < puntos.Length; i++)
            {
                puntos[i].X = (puntos[i].X - minX) * escala + Margin;
                puntos[i].Y = (puntos[i].Y - minY) * escala + Margin;
            }

            using (SolidBrush brush = new SolidBrush(Color.LightBlue))
            using (Pen pen = new Pen(Color.Blue, 2))
            {
                graphics.FillPolygon(brush, puntos);
                graphics.DrawPolygon(pen, puntos);
            }
        }

        private PointF[] CalcularPuntosTriangulo(double a, double b, double c)
        {
            PointF[] puntos = new PointF[3];

            double anguloA = Math.Acos((b * b + c * c - a * a) / (2 * b * c));
            double anguloB = Math.Acos((a * a + c * c - b * b) / (2 * a * c));

            puntos[0] = new PointF(0, 0);
            puntos[1] = new PointF((float)c, 0);
            puntos[2] = new PointF((float)(b * Math.Cos(anguloA)), (float)(-b * Math.Sin(anguloA)));

            return puntos;
        }
    }
}