using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Windows.Forms;
using Figuras2D.Models;
using Figuras2D.Presenters;

namespace Figuras2D.Views
{
    public partial class FrmElipse : Form
    {
        private Elipse _elipseActual;

        private const float Margin = 20f;

        public FrmElipse()
        {
            InitializeComponent();

            // Eventos
            btnCalcular.Click += btnCalcular_Click;
            btnLimpiarCampos.Click += btnLimpiarCampos_Click;
            panelElipse.Paint += panelElipse_Paint;

            // 🎨 AppTheme (igual que Semicircle)
            this.BackColor = AppTheme.BgMain;
            this.ForeColor = AppTheme.TextPri;
            this.Font = AppTheme.FontMenu;

            this.btnCalcular.BackColor = AppTheme.Accent;
            this.btnCalcular.ForeColor = AppTheme.TextPri;

            this.btnLimpiarCampos.BackColor = AppTheme.Accent;
            this.btnLimpiarCampos.ForeColor = AppTheme.TextPri;

            this.lblMensaje.ForeColor = AppTheme.alert;
        }

        private bool TryGetDouble(TextBox txt, out double value)
        {
            return double.TryParse(txt.Text, NumberStyles.Float, CultureInfo.CurrentCulture, out value) ||
                   double.TryParse(txt.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out value);
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (!TryGetDouble(txtSemiejeMayor, out double a) ||
                !TryGetDouble(txtSemiejeMenor, out double b))
            {
                lblMensaje.Text = "Ingrese valores válidos.";
                lblAreaResultado.Text = "0.00";
                lblPerimetroResultado.Text = "0.00";
                _elipseActual = null;
                panelElipse.Invalidate();
                return;
            }

            Elipse elipse = new Elipse(a, b);
            ElipsePresenter presenter = new ElipsePresenter(elipse);

            if (!presenter.IsValid)
            {
                lblMensaje.Text = "Los valores deben ser mayores que 0.";
                lblAreaResultado.Text = "0.00";
                lblPerimetroResultado.Text = "0.00";
                _elipseActual = null;
                panelElipse.Invalidate();
                return;
            }

            _elipseActual = elipse;

            lblAreaResultado.Text = presenter.Area.ToString("0.00");
            lblPerimetroResultado.Text = presenter.Perimeter.ToString("0.00");
            lblMensaje.Text = "";

            panelElipse.Invalidate();
        }

        private void btnLimpiarCampos_Click(object sender, EventArgs e)
        {
            txtSemiejeMayor.Clear();
            txtSemiejeMenor.Clear();

            lblAreaResultado.Text = "0.00";
            lblPerimetroResultado.Text = "0.00";
            lblMensaje.Text = "";

            _elipseActual = null;
            panelElipse.Invalidate();
        }

        private void panelElipse_Paint(object sender, PaintEventArgs e)
        {
            if (_elipseActual == null)
                return;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            float a = (float)_elipseActual.SemiejeMayor;
            float b = (float)_elipseActual.SemiejeMenor;

            float width = a * 2;
            float height = b * 2;

            float maxWidth = panelElipse.ClientSize.Width - (2 * Margin);
            float maxHeight = panelElipse.ClientSize.Height - (2 * Margin);

            float scale = Math.Min(maxWidth / width, maxHeight / height);

            width *= scale;
            height *= scale;

            float x = (panelElipse.Width - width) / 2;
            float y = (panelElipse.Height - height) / 2;

            using (SolidBrush brush = new SolidBrush(Color.Tomato))
            using (Pen pen = new Pen(Color.Black, 2))
            {
                g.FillEllipse(brush, x, y, width, height);
                g.DrawEllipse(pen, x, y, width, height);
            }
        }
    }
}