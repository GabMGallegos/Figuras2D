using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Windows.Forms;
using Figuras2D.Models;
using Figuras2D.Presenters;

namespace Figuras2D
{
    public partial class FrmOctagon : Form
    {
        private Octagon _octagonActual;

        private const float Margin = 20f;
        private const double MinRenderableSide = 20;

        public FrmOctagon()
        {
            InitializeComponent();

            PanelDibujo.Size = new Size(390, 390);

            btnCalcular.Click += btnCalcular_Click;
            btnLimpiarCampos.Click += btnLimpiarCampos_Click;
            PanelDibujo.Paint += panel2_Paint;
        }

        private bool TryGetDouble(TextBox textBox, out double value)
        {
            return double.TryParse(textBox.Text, NumberStyles.Float, CultureInfo.CurrentCulture, out value) ||
                   double.TryParse(textBox.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out value);
        }

        private float GetMaxRenderableDiameter()
        {
            return Math.Min(PanelDibujo.ClientSize.Width, PanelDibujo.ClientSize.Height) - (2 * Margin);
        }

        private double GetMaxRenderableSide()
        {
            double maxDiameter = GetMaxRenderableDiameter();

            return maxDiameter * Math.Sin(Math.PI / 8);
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (!TryGetDouble(txtLado, out double lado))
            {
                lblMensaje.Text = "Ingrese un valor numérico válido.";
                lblAreaResultado.Text = "0.00";
                lblPerimetroResultado.Text = "0.00";

                _octagonActual = null;
                PanelDibujo.Invalidate();
                return;
            }

            Octagon octagon = new Octagon(lado);
            OctagonPresenter presenter = new OctagonPresenter(octagon);

            if (!presenter.IsValid)
            {
                lblMensaje.Text = "El lado del octágono debe ser mayor que cero.";
                lblAreaResultado.Text = "0.00";
                lblPerimetroResultado.Text = "0.00";

                _octagonActual = null;
                PanelDibujo.Invalidate();
                return;
            }

            double maxRenderableSide = GetMaxRenderableSide();

            if (lado < MinRenderableSide)
            {
                lblMensaje.Text = $"El octágono es demasiado pequeño para visualizarse claramente. Use un lado mayor o igual a {MinRenderableSide:0.00}.";
                lblAreaResultado.Text = presenter.Area.ToString("0.00");
                lblPerimetroResultado.Text = presenter.Perimeter.ToString("0.00");

                _octagonActual = null;
                PanelDibujo.Invalidate();
                return;
            }

            if (lado > maxRenderableSide)
            {
                lblMensaje.Text = $"El octágono no se puede renderizar. El lado máximo para este panel es {maxRenderableSide:0.00}.";
                lblAreaResultado.Text = presenter.Area.ToString("0.00");
                lblPerimetroResultado.Text = presenter.Perimeter.ToString("0.00");

                _octagonActual = null;
                PanelDibujo.Invalidate();
                return;
            }

            _octagonActual = octagon;

            lblAreaResultado.Text = presenter.Area.ToString("0.00");
            lblPerimetroResultado.Text = presenter.Perimeter.ToString("0.00");
            lblMensaje.Text = "";

            PanelDibujo.Invalidate();
        }

        private void btnLimpiarCampos_Click(object sender, EventArgs e)
        {
            txtLado.Clear();

            lblAreaResultado.Text = "0.00";
            lblPerimetroResultado.Text = "0.00";
            lblMensaje.Text = "";

            _octagonActual = null;
            PanelDibujo.Invalidate();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            if (_octagonActual == null)
            {
                return;
            }

            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            float lado = (float)_octagonActual.Side;

            float radio = lado / (2f * (float)Math.Sin(Math.PI / 8));

            float centerX = PanelDibujo.ClientSize.Width / 2f;
            float centerY = PanelDibujo.ClientSize.Height / 2f;

            PointF[] puntos = new PointF[8];

            for (int i = 0; i < 8; i++)
            {
                double angle = -Math.PI / 2 + Math.PI / 8 + i * Math.PI / 4;

                puntos[i] = new PointF(
                    centerX + radio * (float)Math.Cos(angle),
                    centerY + radio * (float)Math.Sin(angle)
                );
            }

            using (SolidBrush brush = new SolidBrush(Color.LightSalmon))
            using (Pen pen = new Pen(Color.Black, 2))
            {
                graphics.FillPolygon(brush, puntos);
                graphics.DrawPolygon(pen, puntos);
            }
        }

        private void txtLado_TextChanged(object sender, EventArgs e)
        {

        }
    }
}