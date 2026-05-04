using Figuras2D.Models;
using Figuras2D.Presenters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Figuras2D.Views
{
    public partial class FrmClover : Form
    {
        private Clover _figuraActual;
        private const float margin = 20f;

        public FrmClover()
        {
            InitializeComponent();

            btnCalcular.Click += btnCalcular_Click;
            btnLimpiar.Click += btnLimpiar_Click;
            panel1.Paint += panelTrebol_Paint;

            txtRadio.TextChanged += (s, e) => LimpiarResultados();

            this.BackColor = AppTheme.BgMain;
            this.ForeColor = AppTheme.TextPri;
            this.Font = AppTheme.FontMenu;
            this.btnCalcular.BackColor = AppTheme.Accent;
            this.btnCalcular.ForeColor = AppTheme.TextPri;
            this.btnLimpiar.BackColor = AppTheme.Accent;
            this.btnLimpiar.ForeColor = AppTheme.TextPri;
            this.lblMensaje.ForeColor = AppTheme.alert;
        }

        private bool TryGetDouble(TextBox textBox, out double value)
        {
            return double.TryParse(textBox.Text,
                       NumberStyles.Float, CultureInfo.CurrentCulture, out value)
                || double.TryParse(textBox.Text,
                       NumberStyles.Float, CultureInfo.InvariantCulture, out value);
        }

        private void LimpiarResultados()
        {
            lblAreaResult.Text = "0.00";
            lblPerimetroResult.Text = "0.00";
            lblMensaje.Text = "";

            _figuraActual = null;
            panel1.Invalidate();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (!TryGetDouble(txtRadio, out double radio))
            {
                lblMensaje.Text = "Ingrese un valor numérico válido para el radio.";
                LimpiarResultados();
                return;
            }

            var clover = new Clover(radio);
            var presenter = new CloverPresenter(clover);

            if (!presenter.IsValid)
            {
                lblMensaje.Text = "El radio debe ser mayor a 0.";
                LimpiarResultados();
                return;
            }

            _figuraActual = clover;
            lblAreaResult.Text = presenter.Area.ToString("0.00");
            lblPerimetroResult.Text = presenter.Perimeter.ToString("0.00");
            lblMensaje.Text = "";

            panel1.Invalidate();
        }


        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarResultados();
            txtRadio.Text = "";
        }

        private void panelTrebol_Paint(object sender, PaintEventArgs e)
        {
            if (_figuraActual == null)
                return;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(panel1.BackColor);

            float cx = panel1.ClientSize.Width / 2f;
            float cy = panel1.ClientSize.Height / 2f;

            // El radio máximo para que quepa en el panel considerando el margen

            float maxR = Math.Min(cx, cy) - margin;
            float r = maxR / 2f;

            using (var path = new GraphicsPath())
            using (var brush = new SolidBrush(Color.FromArgb(180, 32, 178, 170)))
            using (var pen = new Pen(Color.SeaGreen, 2))
            {
                //tres hojas separadas 120 grados, cada una es un círculo con radio r
                for (int i = 0; i < 3; i++)
                {
                    double angulo = (i * 120 - 90) * Math.PI / 180.0;
                    float lx = cx + (float)(r * Math.Cos(angulo));
                    float ly = cy + (float)(r * Math.Sin(angulo));

                    path.AddEllipse(lx - r, ly - r, 2 * r, 2 * r);
                }

                g.FillPath(brush, path);
                g.DrawPath(pen, path);
            }
        }
    }
}
