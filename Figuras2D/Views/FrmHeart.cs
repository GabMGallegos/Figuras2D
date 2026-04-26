using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Windows.Forms;
using Figuras2D.Models;
using Figuras2D.Presenters;

namespace Figuras2D
{
    public partial class FrmHeart : Form
    {
        private Heart _heartActual;

        private const float Margin = 20f;
        private const double MinRenderableSize = 20;

        public FrmHeart()
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
            if (!TryGetDouble(txtAncho, out double ancho) ||
                !TryGetDouble(txtAlto, out double alto))
            {
                lblMensaje.Text = "Ingrese valores numéricos válidos.";
                lblAreaResultado.Text = "0.00";
                lblPerimetroResultado.Text = "0.00";

                _heartActual = null;
                panel2.Invalidate();
                return;
            }

            Heart heart = new Heart(ancho, alto);
            HeartPresenter presenter = new HeartPresenter(heart);

            if (!presenter.IsValid)
            {
                lblMensaje.Text = "El ancho y el alto deben ser mayores que cero.";
                lblAreaResultado.Text = "0.00";
                lblPerimetroResultado.Text = "0.00";

                _heartActual = null;
                panel2.Invalidate();
                return;
            }

            float maxRenderableWidth = GetMaxRenderableWidth();
            float maxRenderableHeight = GetMaxRenderableHeight();

            if (ancho < MinRenderableSize || alto < MinRenderableSize)
            {
                lblMensaje.Text = $"El corazón es demasiado pequeño para visualizarse claramente. Use ancho y alto mayores o iguales a {MinRenderableSize:0.00}.";
                lblAreaResultado.Text = presenter.Area.ToString("0.00");
                lblPerimetroResultado.Text = presenter.Perimeter.ToString("0.00");

                _heartActual = null;
                panel2.Invalidate();
                return;
            }

            if (ancho > maxRenderableWidth)
            {
                lblMensaje.Text = $"El corazón no se puede renderizar. El ancho máximo para este panel es {maxRenderableWidth:0.00}.";
                lblAreaResultado.Text = presenter.Area.ToString("0.00");
                lblPerimetroResultado.Text = presenter.Perimeter.ToString("0.00");

                _heartActual = null;
                panel2.Invalidate();
                return;
            }

            if (alto > maxRenderableHeight)
            {
                lblMensaje.Text = $"El corazón no se puede renderizar. El alto máximo para este panel es {maxRenderableHeight:0.00}.";
                lblAreaResultado.Text = presenter.Area.ToString("0.00");
                lblPerimetroResultado.Text = presenter.Perimeter.ToString("0.00");

                _heartActual = null;
                panel2.Invalidate();
                return;
            }

            _heartActual = heart;

            lblAreaResultado.Text = presenter.Area.ToString("0.00");
            lblPerimetroResultado.Text = presenter.Perimeter.ToString("0.00");
            lblMensaje.Text = "";

            panel2.Invalidate();
        }

        private void btnLimpiarCampos_Click(object sender, EventArgs e)
        {
            txtAncho.Clear();
            txtAlto.Clear();

            lblAreaResultado.Text = "0.00";
            lblPerimetroResultado.Text = "0.00";
            lblMensaje.Text = "";

            _heartActual = null;
            panel2.Invalidate();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            if (_heartActual == null)
            {
                return;
            }

            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            float ancho = (float)_heartActual.Width;
            float alto = (float)_heartActual.Height;

            float x = (panel2.ClientSize.Width - ancho) / 2f;
            float y = (panel2.ClientSize.Height - alto) / 2f;

            float mitadAncho = ancho / 2f;
            float mitadAlto = alto / 2f;

            float baseY = y + mitadAlto;

            PointF puntoIzquierdo = new PointF(x, baseY);
            PointF puntoInferior = new PointF(x + mitadAncho, y + alto);
            PointF puntoDerecho = new PointF(x + ancho, baseY);

            RectangleF rectIzquierdo = new RectangleF(x, y + alto / 4f, mitadAncho, alto / 2f);
            RectangleF rectDerecho = new RectangleF(x + mitadAncho, y + alto / 4f, mitadAncho, alto / 2f);

            using (GraphicsPath path = new GraphicsPath())
            using (SolidBrush brush = new SolidBrush(Color.Red))
            using (Pen pen = new Pen(Color.Black, 2))
            {
                path.StartFigure();

                // Triángulo inferior
                path.AddLine(puntoIzquierdo, puntoInferior);
                path.AddLine(puntoInferior, puntoDerecho);

                // Semicírculo / semielipse superior derecha
                path.AddArc(rectDerecho, 0, -180);

                // Semicírculo / semielipse superior izquierda
                path.AddArc(rectIzquierdo, 0, -180);

                path.CloseFigure();

                graphics.FillPath(brush, path);
                graphics.DrawPath(pen, path);
            }
        }
    }
}