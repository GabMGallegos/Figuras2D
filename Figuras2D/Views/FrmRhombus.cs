using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Windows.Forms;
using Figuras2D.Models;
using Figuras2D.Presenters;

namespace Figuras2D
{
    public partial class FrmRhombus : Form
    {
        private Rhombus _rhombusActual;

        private const float Margin = 20f;
        private const double MinRenderableSize = 20;

        public FrmRhombus()
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
                !TryGetDouble(textLado, out double lado))
            {
                lblMensaje.Text = "Ingrese valores numéricos válidos.";
                lblAreaResultado.Text = "0.00";
                lblPerimetroResultado.Text = "0.00";

                _rhombusActual = null;
                panel2.Invalidate();
                return;
            }

            Rhombus rhombus = new Rhombus(diagonalMayor, diagonalMenor, lado);
            RhombusPresenter presenter = new RhombusPresenter(rhombus);

            if (!presenter.IsValid)
            {
                lblMensaje.Text = "Las diagonales y el lado deben ser mayores que cero.";
                lblAreaResultado.Text = "0.00";
                lblPerimetroResultado.Text = "0.00";

                _rhombusActual = null;
                panel2.Invalidate();
                return;
            }

            float maxRenderableWidth = GetMaxRenderableWidth();
            float maxRenderableHeight = GetMaxRenderableHeight();

            if (diagonalMayor < MinRenderableSize || diagonalMenor < MinRenderableSize)
            {
                lblMensaje.Text = $"El rombo es demasiado pequeño para visualizarse claramente. Use diagonales mayores o iguales a {MinRenderableSize:0.00}.";
                lblAreaResultado.Text = presenter.Area.ToString("0.00");
                lblPerimetroResultado.Text = presenter.Perimeter.ToString("0.00");

                _rhombusActual = null;
                panel2.Invalidate();
                return;
            }

            if (diagonalMenor > maxRenderableWidth)
            {
                lblMensaje.Text = $"El rombo no se puede renderizar. La diagonal menor máxima para este panel es {maxRenderableWidth:0.00}.";
                lblAreaResultado.Text = presenter.Area.ToString("0.00");
                lblPerimetroResultado.Text = presenter.Perimeter.ToString("0.00");

                _rhombusActual = null;
                panel2.Invalidate();
                return;
            }

            if (diagonalMayor > maxRenderableHeight)
            {
                lblMensaje.Text = $"El rombo no se puede renderizar. La diagonal mayor máxima para este panel es {maxRenderableHeight:0.00}.";
                lblAreaResultado.Text = presenter.Area.ToString("0.00");
                lblPerimetroResultado.Text = presenter.Perimeter.ToString("0.00");

                _rhombusActual = null;
                panel2.Invalidate();
                return;
            }

            _rhombusActual = rhombus;

            lblAreaResultado.Text = presenter.Area.ToString("0.00");
            lblPerimetroResultado.Text = presenter.Perimeter.ToString("0.00");
            lblMensaje.Text = "";

            panel2.Invalidate();
        }

        private void btnLimpiarCampos_Click(object sender, EventArgs e)
        {
            txtDiagonalMayor.Clear();
            txtDiagonalMenor.Clear();
            textLado.Clear();

            lblAreaResultado.Text = "0.00";
            lblPerimetroResultado.Text = "0.00";
            lblMensaje.Text = "";

            _rhombusActual = null;
            panel2.Invalidate();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            if (_rhombusActual == null)
            {
                return;
            }

            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            float diagonalMayor = (float)_rhombusActual.DiagonalMajor;
            float diagonalMenor = (float)_rhombusActual.DiagonalMinor;

            float centerX = panel2.ClientSize.Width / 2f;
            float centerY = panel2.ClientSize.Height / 2f;

            PointF puntoSuperior = new PointF(
                centerX,
                centerY - diagonalMayor / 2f
            );

            PointF puntoDerecho = new PointF(
                centerX + diagonalMenor / 2f,
                centerY
            );

            PointF puntoInferior = new PointF(
                centerX,
                centerY + diagonalMayor / 2f
            );

            PointF puntoIzquierdo = new PointF(
                centerX - diagonalMenor / 2f,
                centerY
            );

            PointF[] puntos =
            {
                puntoSuperior,
                puntoDerecho,
                puntoInferior,
                puntoIzquierdo
            };

            using (SolidBrush brush = new SolidBrush(Color.MediumTurquoise))
            using (Pen pen = new Pen(Color.Black, 2))
            {
                graphics.FillPolygon(brush, puntos);
                graphics.DrawPolygon(pen, puntos);
            }
        }
    }
}