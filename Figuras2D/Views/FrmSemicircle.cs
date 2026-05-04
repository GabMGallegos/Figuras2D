using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Windows.Forms;
using Figuras2D.Models;
using Figuras2D.Presenters;

namespace Figuras2D
{
    public partial class FrmSemicircle : Form
    {
        private Semicircle _semicircleActual;

        private const float Margin = 20f;
        private const double MinRenderableRadius = 10;

        public FrmSemicircle()
        {
            InitializeComponent();

            panel2.Size = new Size(390, 390);

            btnCalcular.Click += btnCalcular_Click;
            btnLimpiarCampos.Click += btnLimpiarCampos_Click;
            panel2.Paint += panel2_Paint;
            this.BackColor = AppTheme.BgMain;
            this.ForeColor = AppTheme.TextPri;
            this.Font = AppTheme.FontMenu;
            this.btnCalcular.BackColor = AppTheme.Accent;
            this.btnCalcular.ForeColor = AppTheme.TextPri;
            this.btnLimpiarCampos.BackColor = AppTheme.Accent;
            this.btnLimpiarCampos.ForeColor = AppTheme.TextPri;
            this.lblMensaje.ForeColor = AppTheme.alert;
        }

        private bool TryGetDouble(TextBox textBox, out double value)
        {
            return double.TryParse(textBox.Text, NumberStyles.Float, CultureInfo.CurrentCulture, out value) ||
                   double.TryParse(textBox.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out value);
        }

        private float GetMaxRenderableRadius()
        {
            float maxWidth = panel2.ClientSize.Width - (2 * Margin);
            float maxHeight = panel2.ClientSize.Height - (2 * Margin);

            return Math.Min(maxWidth / 2f, maxHeight);
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (!TryGetDouble(txtRadio, out double radio))
            {
                lblMensaje.Text = "Ingrese un valor numérico válido.";
                lblAreaResultado.Text = "0.00";
                lblPerimetroResultado.Text = "0.00";

                _semicircleActual = null;
                panel2.Invalidate();
                return;
            }

            Semicircle semicircle = new Semicircle(radio);
            SemicirclePresenter presenter = new SemicirclePresenter(semicircle);

            if (!presenter.IsValid)
            {
                lblMensaje.Text = "El radio debe ser mayor que cero.";
                lblAreaResultado.Text = "0.00";
                lblPerimetroResultado.Text = "0.00";

                _semicircleActual = null;
                panel2.Invalidate();
                return;
            }

            float maxRenderableRadius = GetMaxRenderableRadius();

            if (radio < MinRenderableRadius)
            {
                lblMensaje.Text = $"El semicírculo es demasiado pequeño para visualizarse claramente. Use un radio mayor o igual a {MinRenderableRadius:0.00}.";
                lblAreaResultado.Text = presenter.Area.ToString("0.00");
                lblPerimetroResultado.Text = presenter.Perimeter.ToString("0.00");

                _semicircleActual = null;
                panel2.Invalidate();
                return;
            }

            if (radio > maxRenderableRadius)
            {
                lblMensaje.Text = $"El semicírculo no se puede renderizar. El radio máximo para este panel es {maxRenderableRadius:0.00}.";
                lblAreaResultado.Text = presenter.Area.ToString("0.00");
                lblPerimetroResultado.Text = presenter.Perimeter.ToString("0.00");

                _semicircleActual = null;
                panel2.Invalidate();
                return;
            }

            _semicircleActual = semicircle;

            lblAreaResultado.Text = presenter.Area.ToString("0.00");
            lblPerimetroResultado.Text = presenter.Perimeter.ToString("0.00");
            lblMensaje.Text = "";

            panel2.Invalidate();
        }

        private void btnLimpiarCampos_Click(object sender, EventArgs e)
        {
            txtRadio.Clear();

            lblAreaResultado.Text = "0.00";
            lblPerimetroResultado.Text = "0.00";
            lblMensaje.Text = "";

            _semicircleActual = null;
            panel2.Invalidate();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            if (_semicircleActual == null)
            {
                return;
            }

            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            float radio = (float)_semicircleActual.Radius;
            float diametro = radio * 2f;

            float x = (panel2.ClientSize.Width - diametro) / 2f;
            float y = (panel2.ClientSize.Height - radio) / 2f;

            Rectangle rectangulo = new Rectangle(
                (int)x,
                (int)y,
                (int)diametro,
                (int)diametro
            );

            using (GraphicsPath path = new GraphicsPath())
            using (SolidBrush brush = new SolidBrush(Color.Tomato))
            using (Pen pen = new Pen(Color.Black, 2))
            {
                path.AddArc(rectangulo, 180, 180);
                path.AddLine(x + diametro, y + radio, x, y + radio);
                path.CloseFigure();

                graphics.FillPath(brush, path);
                graphics.DrawPath(pen, path);
            }
        }
    }
}