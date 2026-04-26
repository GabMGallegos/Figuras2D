using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Windows.Forms;
using Figuras2D.Models;
using Figuras2D.Presenters;

namespace Figuras2D
{
    public partial class FrmCross : Form
    {
        private Cross _crossActual;

        private const float Margin = 20f;
        private const double MinRenderableSize = 20;

        public FrmCross()
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

        private float GetMaxRenderableSize()
        {
            return Math.Min(panel2.Width, panel2.Height) - (2 * Margin);
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (!TryGetDouble(txtLongitudTotal, out double longitudTotal) ||
                !TryGetDouble(txtGrosor, out double grosor))
            {
                lblMensaje.Text = "Ingrese valores numéricos válidos.";
                lblAreaResultado.Text = "0.00";
                lblPerimetroResultado.Text = "0.00";

                _crossActual = null;
                panel2.Invalidate();
                return;
            }

            Cross cross = new Cross(longitudTotal, grosor);
            CrossPresenter presenter = new CrossPresenter(cross);

            if (!presenter.IsValid)
            {
                lblMensaje.Text = "La longitud total y el grosor deben ser mayores que cero. El grosor debe ser menor que la longitud total.";
                lblAreaResultado.Text = "0.00";
                lblPerimetroResultado.Text = "0.00";

                _crossActual = null;
                panel2.Invalidate();
                return;
            }

            float maxRenderableSize = GetMaxRenderableSize();

            if (longitudTotal < MinRenderableSize)
            {
                lblMensaje.Text = $"La cruz es demasiado pequeña para visualizarse claramente. Use una longitud total mayor o igual a {MinRenderableSize:0.00}.";
                lblAreaResultado.Text = presenter.Area.ToString("0.00");
                lblPerimetroResultado.Text = presenter.Perimeter.ToString("0.00");

                _crossActual = null;
                panel2.Invalidate();
                return;
            }

            if (longitudTotal > maxRenderableSize)
            {
                lblMensaje.Text = $"La cruz no se puede renderizar. La longitud total máxima para este panel es {maxRenderableSize:0.00}.";
                lblAreaResultado.Text = presenter.Area.ToString("0.00");
                lblPerimetroResultado.Text = presenter.Perimeter.ToString("0.00");

                _crossActual = null;
                panel2.Invalidate();
                return;
            }

            _crossActual = cross;

            lblAreaResultado.Text = presenter.Area.ToString("0.00");
            lblPerimetroResultado.Text = presenter.Perimeter.ToString("0.00");
            lblMensaje.Text = "";

            panel2.Invalidate();
        }

        private void btnLimpiarCampos_Click(object sender, EventArgs e)
        {
            txtLongitudTotal.Clear();
            txtGrosor.Clear();

            lblAreaResultado.Text = "0.00";
            lblPerimetroResultado.Text = "0.00";
            lblMensaje.Text = "";

            _crossActual = null;
            panel2.Invalidate();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            if (_crossActual == null)
            {
                return;
            }

            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            float longitudTotal = (float)_crossActual.ArmLength;
            float grosor = (float)_crossActual.Thickness;

            float x = (panel2.Width - longitudTotal) / 2f;
            float y = (panel2.Height - longitudTotal) / 2f;

            float espacio = (longitudTotal - grosor) / 2f;

            PointF[] puntos =
            {
                new PointF(x + espacio, y),
                new PointF(x + espacio + grosor, y),
                new PointF(x + espacio + grosor, y + espacio),
                new PointF(x + longitudTotal, y + espacio),
                new PointF(x + longitudTotal, y + espacio + grosor),
                new PointF(x + espacio + grosor, y + espacio + grosor),
                new PointF(x + espacio + grosor, y + longitudTotal),
                new PointF(x + espacio, y + longitudTotal),
                new PointF(x + espacio, y + espacio + grosor),
                new PointF(x, y + espacio + grosor),
                new PointF(x, y + espacio),
                new PointF(x + espacio, y + espacio)
            };

            using (SolidBrush brush = new SolidBrush(Color.MediumPurple))
            using (Pen pen = new Pen(Color.Black, 2))
            {
                graphics.FillPolygon(brush, puntos);
                graphics.DrawPolygon(pen, puntos);
            }
        }
    }
}