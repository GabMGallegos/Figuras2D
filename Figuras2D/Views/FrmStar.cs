using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Windows.Forms;
using Figuras2D.Models;
using Figuras2D.Presenters;

namespace Figuras2D
{
    public partial class FrmStar : Form
    {
        private Star _starActual;

        private const float Margin = 20f;
        private const double MinRenderableSize = 20;

        public FrmStar()
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

        private bool TryGetInt(TextBox textBox, out int value)
        {
            return int.TryParse(textBox.Text, out value);
        }

        private float GetMaxRenderableRadius()
        {
            return (Math.Min(panel2.ClientSize.Width, panel2.ClientSize.Height) / 2f) - Margin;
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (!TryGetDouble(txtRadioExterno, out double radioExterno) ||
                !TryGetDouble(txtRadioInterno, out double radioInterno) ||
                !TryGetInt(txtPuntas, out int puntas))
            {
                lblMensaje.Text = "Ingrese valores numéricos válidos.";
                lblAreaResultado.Text = "0.00";
                lblPerimetroResultado.Text = "0.00";
                _starActual = null;
                panel2.Invalidate();
                return;
            }

            Star star = new Star(radioExterno, radioInterno, puntas);
            StarPresenter presenter = new StarPresenter(star);

            if (!presenter.IsValid)
            {
                lblMensaje.Text = "Valores inválidos. El radio externo debe ser mayor al interno y las puntas >= 3.";
                lblAreaResultado.Text = "0.00";
                lblPerimetroResultado.Text = "0.00";
                _starActual = null;
                panel2.Invalidate();
                return;
            }

            float maxRadius = GetMaxRenderableRadius();

            if (radioExterno < MinRenderableSize)
            {
                lblMensaje.Text = $"La estrella es demasiado pequeña. Use radio externo mayor o igual a {MinRenderableSize:0.00}.";
                lblAreaResultado.Text = presenter.Area.ToString("0.00");
                lblPerimetroResultado.Text = presenter.Perimeter.ToString("0.00");
                _starActual = null;
                panel2.Invalidate();
                return;
            }

            if (radioExterno > maxRadius)
            {
                lblMensaje.Text = $"La estrella no se puede renderizar. El radio externo máximo es {maxRadius:0.00}.";
                lblAreaResultado.Text = presenter.Area.ToString("0.00");
                lblPerimetroResultado.Text = presenter.Perimeter.ToString("0.00");
                _starActual = null;
                panel2.Invalidate();
                return;
            }

            _starActual = star;
            lblAreaResultado.Text = presenter.Area.ToString("0.00");
            lblPerimetroResultado.Text = presenter.Perimeter.ToString("0.00");
            lblMensaje.Text = "";
            panel2.Invalidate();
        }

        private void btnLimpiarCampos_Click(object sender, EventArgs e)
        {
            txtRadioExterno.Clear();
            txtRadioInterno.Clear();
            txtPuntas.Clear();
            lblAreaResultado.Text = "0.00";
            lblPerimetroResultado.Text = "0.00";
            lblMensaje.Text = "";
            _starActual = null;
            panel2.Invalidate();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            if (_starActual == null) return;

            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            float cx = panel2.ClientSize.Width / 2f;
            float cy = panel2.ClientSize.Height / 2f;
            float radioExterno = (float)_starActual.RadioExterno;
            float radioInterno = (float)_starActual.RadioInterno;
            int puntas = _starActual.Puntas;

            PointF[] puntos = new PointF[puntas * 2];
            double anguloInicial = -Math.PI / 2; // Punta hacia arriba

            for (int i = 0; i < puntas * 2; i++)
            {
                double angulo = anguloInicial + i * Math.PI / puntas;
                float radio = (i % 2 == 0) ? radioExterno : radioInterno;
                puntos[i] = new PointF(
                    cx + radio * (float)Math.Cos(angulo),
                    cy + radio * (float)Math.Sin(angulo)
                );
            }

            using (SolidBrush brush = new SolidBrush(Color.MediumVioletRed))
            using (Pen pen = new Pen(Color.Black, 2))
            {
                graphics.FillPolygon(brush, puntos);
                graphics.DrawPolygon(pen, puntos);
            }
        }
    }
}