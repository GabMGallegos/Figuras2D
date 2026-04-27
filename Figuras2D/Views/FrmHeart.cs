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

            float centroX = x + ancho / 2f;
            float centroY = y + alto / 2f;

            // Rombo base
            PointF puntoSuperior = new PointF(centroX, y);
            PointF puntoDerecho = new PointF(x + ancho, centroY);
            PointF puntoInferior = new PointF(centroX, y + alto);
            PointF puntoIzquierdo = new PointF(x, centroY);

            PointF[] puntosRombo =
            {
                puntoSuperior,
                puntoDerecho,
                puntoInferior,
                puntoIzquierdo
            };

            // Longitud de los lados superiores del rombo
            float ladoSuperiorIzquierdo = Distance(puntoSuperior, puntoIzquierdo);
            float ladoSuperiorDerecho = Distance(puntoSuperior, puntoDerecho);

            float ejeMayor = Math.Min(ladoSuperiorIzquierdo, ladoSuperiorDerecho);

            // Relación para círculo / óvalo
            float proporcion = alto / ancho;
            float ejeMenor = ejeMayor * proporcion;

            // Límites para que no quede exagerado
            if (ejeMenor < ejeMayor * 0.45f)
            {
                ejeMenor = ejeMayor * 0.45f;
            }

            if (ejeMenor > ejeMayor)
            {
                ejeMenor = ejeMayor;
            }

            // Centros de los lóbulos
            PointF centroElipseIzquierda = MidPoint(puntoSuperior, puntoIzquierdo);
            PointF centroElipseDerecha = MidPoint(puntoSuperior, puntoDerecho);

            // Ángulos de inclinación
            float anguloIzquierdo = AngleDegrees(puntoIzquierdo, puntoSuperior);
            float anguloDerecho = AngleDegrees(puntoSuperior, puntoDerecho);

            using (SolidBrush brush = new SolidBrush(Color.Red))
            using (Pen pen = new Pen(Color.Black, 2))
            {
                // Relleno
                graphics.FillPolygon(brush, puntosRombo);
                FillRotatedEllipse(graphics, brush, centroElipseIzquierda, ejeMayor, ejeMenor, anguloIzquierdo);
                FillRotatedEllipse(graphics, brush, centroElipseDerecha, ejeMayor, ejeMenor, anguloDerecho);

                // SOLO contorno visible:
                // 1) La V inferior
                graphics.DrawLine(pen, puntoIzquierdo, puntoInferior);
                graphics.DrawLine(pen, puntoInferior, puntoDerecho);

                // 2) SOLO mitad superior de cada lóbulo
                DrawUpperHalfRotatedEllipse(graphics, pen, centroElipseIzquierda, ejeMayor, ejeMenor, anguloIzquierdo);
                DrawUpperHalfRotatedEllipse(graphics, pen, centroElipseDerecha, ejeMayor, ejeMenor, anguloDerecho);
            }
        }

        private void DrawUpperHalfRotatedEllipse(Graphics graphics, Pen pen, PointF centro, float ejeMayor, float ejeMenor, float angulo)
        {
            GraphicsState estado = graphics.Save();

            graphics.TranslateTransform(centro.X, centro.Y);
            graphics.RotateTransform(angulo);

            // Solo la mitad superior
            graphics.DrawArc(
                pen,
                -ejeMayor / 2f,
                -ejeMenor / 2f,
                ejeMayor,
                ejeMenor,
                180,
                180
            );

            graphics.Restore(estado);
        }

        private float Distance(PointF p1, PointF p2)
        {
            float dx = p2.X - p1.X;
            float dy = p2.Y - p1.Y;
            return (float)Math.Sqrt(dx * dx + dy * dy);
        }

        private PointF MidPoint(PointF p1, PointF p2)
        {
            return new PointF(
                (p1.X + p2.X) / 2f,
                (p1.Y + p2.Y) / 2f
            );
        }

        private float AngleDegrees(PointF p1, PointF p2)
        {
            float dx = p2.X - p1.X;
            float dy = p2.Y - p1.Y;
            return (float)(Math.Atan2(dy, dx) * 180.0 / Math.PI);
        }

        private void FillRotatedEllipse(Graphics graphics, Brush brush, PointF centro, float ejeMayor, float ejeMenor, float angulo)
        {
            GraphicsState estado = graphics.Save();

            graphics.TranslateTransform(centro.X, centro.Y);
            graphics.RotateTransform(angulo);
            graphics.FillEllipse(
                brush,
                -ejeMayor / 2f,
                -ejeMenor / 2f,
                ejeMayor,
                ejeMenor
            );

            graphics.Restore(estado);
        }

        private void DrawRotatedEllipse(Graphics graphics, Pen pen, PointF centro, float ejeMayor, float ejeMenor, float angulo)
        {
            GraphicsState estado = graphics.Save();

            graphics.TranslateTransform(centro.X, centro.Y);
            graphics.RotateTransform(angulo);
            graphics.DrawEllipse(
                pen,
                -ejeMayor / 2f,
                -ejeMenor / 2f,
                ejeMayor,
                ejeMenor
            );

            graphics.Restore(estado);
        }
    }
}