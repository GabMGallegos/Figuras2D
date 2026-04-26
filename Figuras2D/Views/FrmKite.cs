using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Windows.Forms;
using Figuras2D.Models;
using Figuras2D.Presenters;

namespace Figuras2D
{
    public partial class FrmKite : Form
    {
        private Kite _kiteActual;

        private const float Margin = 20f;
        private const double MinRenderableSize = 20;

        public FrmKite()
        {
            InitializeComponent();

            panel2.Size = new Size(390, 390);

            btnCalcular.Click += btnCalcular_Click;
            btnLimpiarCampos.Click += btnLimpiarCampos_Click;
            panel2.Paint += panel2_Paint;
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
            if (!TryGetDouble(txtDiagonalMayor, out double diagonalMayor) ||
                !TryGetDouble(txtDiagonalMenor, out double diagonalMenor) ||
                !TryGetDouble(textLadoA, out double ladoA) ||
                !TryGetDouble(textLadoB, out double ladoB))
            {
                lblMensaje.Text = "Ingrese valores numéricos válidos.";
                lblAreaResultado.Text = "0.00";
                lblPerimetroResultado.Text = "0.00";

                _kiteActual = null;
                panel2.Invalidate();
                return;
            }

            Kite kite = new Kite(diagonalMayor, diagonalMenor, ladoA, ladoB);
            KitePresenter presenter = new KitePresenter(kite);

            if (!presenter.IsValid)
            {
                lblMensaje.Text = "Las diagonales y los lados deben ser mayores que cero.";
                lblAreaResultado.Text = "0.00";
                lblPerimetroResultado.Text = "0.00";

                _kiteActual = null;
                panel2.Invalidate();
                return;
            }

            double mitadDiagonalMenor = diagonalMenor / 2.0;

            if (ladoA <= mitadDiagonalMenor || ladoB <= mitadDiagonalMenor)
            {
                lblMensaje.Text = "La cometa no se puede dibujar. Cada lado debe ser mayor que la mitad de la diagonal menor.";
                lblAreaResultado.Text = presenter.Area.ToString("0.00");
                lblPerimetroResultado.Text = presenter.Perimeter.ToString("0.00");

                _kiteActual = null;
                panel2.Invalidate();
                return;
            }

            float maxRenderableWidth = GetMaxRenderableWidth();
            float maxRenderableHeight = GetMaxRenderableHeight();

            if (diagonalMayor < MinRenderableSize || diagonalMenor < MinRenderableSize)
            {
                lblMensaje.Text = $"La cometa es demasiado pequeña para visualizarse claramente. Use diagonales mayores o iguales a {MinRenderableSize:0.00}.";
                lblAreaResultado.Text = presenter.Area.ToString("0.00");
                lblPerimetroResultado.Text = presenter.Perimeter.ToString("0.00");

                _kiteActual = null;
                panel2.Invalidate();
                return;
            }

            if (diagonalMenor > maxRenderableWidth)
            {
                lblMensaje.Text = $"La cometa no se puede renderizar. La diagonal menor máxima para este panel es {maxRenderableWidth:0.00}.";
                lblAreaResultado.Text = presenter.Area.ToString("0.00");
                lblPerimetroResultado.Text = presenter.Perimeter.ToString("0.00");

                _kiteActual = null;
                panel2.Invalidate();
                return;
            }

            if (diagonalMayor > maxRenderableHeight)
            {
                lblMensaje.Text = $"La cometa no se puede renderizar. La diagonal mayor máxima para este panel es {maxRenderableHeight:0.00}.";
                lblAreaResultado.Text = presenter.Area.ToString("0.00");
                lblPerimetroResultado.Text = presenter.Perimeter.ToString("0.00");

                _kiteActual = null;
                panel2.Invalidate();
                return;
            }

            _kiteActual = kite;

            lblAreaResultado.Text = presenter.Area.ToString("0.00");
            lblPerimetroResultado.Text = presenter.Perimeter.ToString("0.00");
            lblMensaje.Text = "";

            panel2.Invalidate();
        }

        private void btnLimpiarCampos_Click(object sender, EventArgs e)
        {
            txtDiagonalMayor.Clear();
            txtDiagonalMenor.Clear();
            textLadoA.Clear();
            textLadoB.Clear();

            lblAreaResultado.Text = "0.00";
            lblPerimetroResultado.Text = "0.00";
            lblMensaje.Text = "";

            _kiteActual = null;
            panel2.Invalidate();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            if (_kiteActual == null)
            {
                return;
            }

            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            float diagonalMayor = (float)_kiteActual.DiagonalMajor;
            float diagonalMenor = (float)_kiteActual.DiagonalMinor;
            float ladoA = (float)_kiteActual.SideA;
            float ladoB = (float)_kiteActual.SideB;

            float mitadDiagonalMenor = diagonalMenor / 2f;

            if (ladoA <= mitadDiagonalMenor || ladoB <= mitadDiagonalMenor)
            {
                return;
            }

            float segmentoSuperior = (float)Math.Sqrt(
                Math.Pow(ladoA, 2) - Math.Pow(mitadDiagonalMenor, 2)
            );

            float segmentoInferior = (float)Math.Sqrt(
                Math.Pow(ladoB, 2) - Math.Pow(mitadDiagonalMenor, 2)
            );

            float sumaSegmentos = segmentoSuperior + segmentoInferior;

            if (sumaSegmentos <= 0)
            {
                return;
            }

            float factorAjuste = diagonalMayor / sumaSegmentos;

            segmentoSuperior *= factorAjuste;
            segmentoInferior *= factorAjuste;

            float centerX = panel2.ClientSize.Width / 2f;
            float centerY = panel2.ClientSize.Height / 2f;

            float ySuperior = centerY - diagonalMayor / 2f;
            float yInferior = centerY + diagonalMayor / 2f;

            float yDiagonalMenor = ySuperior + segmentoSuperior;

            PointF puntoSuperior = new PointF(
                centerX,
                ySuperior
            );

            PointF puntoDerecho = new PointF(
                centerX + diagonalMenor / 2f,
                yDiagonalMenor
            );

            PointF puntoInferior = new PointF(
                centerX,
                yInferior
            );

            PointF puntoIzquierdo = new PointF(
                centerX - diagonalMenor / 2f,
                yDiagonalMenor
            );

            PointF[] puntos =
            {
                puntoSuperior,
                puntoDerecho,
                puntoInferior,
                puntoIzquierdo
            };

            using (SolidBrush brush = new SolidBrush(Color.RoyalBlue))
            using (Pen pen = new Pen(Color.Black, 2))
            {
                graphics.FillPolygon(brush, puntos);
                graphics.DrawPolygon(pen, puntos);
            }
        }
    }
}