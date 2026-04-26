using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Windows.Forms;
using Figuras2D.Models;
using Figuras2D.Presenters;

namespace Figuras2D
{
    public partial class FrmPentagon : Form
    {
        private Pentagon _pentagonActual;

        private const float Margin = 20f;
        private const double MinRenderableSize = 20;

        public FrmPentagon()
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

        private float GetMaxRenderableRadius()
        {
            return (Math.Min(panel2.ClientSize.Width, panel2.ClientSize.Height) / 2f) - Margin;
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (!TryGetDouble(txtLado, out double lado))
            {
                lblMensaje.Text = "Ingrese un valor numérico válido.";
                lblAreaResultado.Text = "0.00";
                lblPerimetroResultado.Text = "0.00";
                _pentagonActual = null;
                panel2.Invalidate();
                return;
            }

            Pentagon pentagon = new Pentagon(lado);
            PentagonPresenter presenter = new PentagonPresenter(pentagon);

            if (!presenter.IsValid)
            {
                lblMensaje.Text = "El lado debe ser mayor que cero.";
                lblAreaResultado.Text = "0.00";
                lblPerimetroResultado.Text = "0.00";
                _pentagonActual = null;
                panel2.Invalidate();
                return;
            }

            // El radio circunscrito del pentágono regular
            double radioCircunscrito = lado / (2 * Math.Sin(Math.PI / 5));
            float maxRadius = GetMaxRenderableRadius();

            if (lado < MinRenderableSize)
            {
                lblMensaje.Text = $"El pentágono es demasiado pequeño. Use un lado mayor o igual a {MinRenderableSize:0.00}.";
                lblAreaResultado.Text = presenter.Area.ToString("0.00");
                lblPerimetroResultado.Text = presenter.Perimeter.ToString("0.00");
                _pentagonActual = null;
                panel2.Invalidate();
                return;
            }

            if (radioCircunscrito > maxRadius)
            {
                lblMensaje.Text = $"El pentágono no se puede renderizar. El lado máximo para este panel es {(maxRadius * 2 * Math.Sin(Math.PI / 5)):0.00}.";
                lblAreaResultado.Text = presenter.Area.ToString("0.00");
                lblPerimetroResultado.Text = presenter.Perimeter.ToString("0.00");
                _pentagonActual = null;
                panel2.Invalidate();
                return;
            }

            _pentagonActual = pentagon;
            lblAreaResultado.Text = presenter.Area.ToString("0.00");
            lblPerimetroResultado.Text = presenter.Perimeter.ToString("0.00");
            lblMensaje.Text = "";
            panel2.Invalidate();
        }

        private void btnLimpiarCampos_Click(object sender, EventArgs e)
        {
            txtLado.Clear();
            lblAreaResultado.Text = "0.00";
            lblPerimetroResultado.Text = "0.00";
            lblMensaje.Text = "";
            _pentagonActual = null;
            panel2.Invalidate();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            if (_pentagonActual == null) return;

            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            float cx = panel2.ClientSize.Width / 2f;
            float cy = panel2.ClientSize.Height / 2f;

            double radio = _pentagonActual.Lado / (2 * Math.Sin(Math.PI / 5));
            double anguloInicial = -Math.PI / 2; // Punta hacia arriba

            PointF[] puntos = new PointF[5];
            for (int i = 0; i < 5; i++)
            {
                double angulo = anguloInicial + i * 2 * Math.PI / 5;
                puntos[i] = new PointF(
                    cx + (float)radio * (float)Math.Cos(angulo),
                    cy + (float)radio * (float)Math.Sin(angulo)
                );
            }

            using (SolidBrush brush = new SolidBrush(Color.SteelBlue))
            using (Pen pen = new Pen(Color.Black, 2))
            {
                graphics.FillPolygon(brush, puntos);
                graphics.DrawPolygon(pen, puntos);
            }
        }
    }
}