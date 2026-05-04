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
    public partial class FrmHexagon : Form
    {
        private Hexagon _figuraActual;
        private const float margin = 20f;

        public FrmHexagon()
        {
            InitializeComponent();

            btnCalcular.Click += btnCalcular_Click;
            btnLimpiar.Click += btnLimpiar_Click;
            panel1.Paint += panelHexagono_Paint;

            txtLado.TextChanged += (s, e) => LimpiarResultados();
            this.Resize += (s,e) => Invalidate();

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
            if (!TryGetDouble(txtLado, out double lado))
            {
                lblMensaje.Text = "Ingrese un valor numérico válido para el lado.";
                LimpiarResultados();
                return;
            }

            var hexagon = new Hexagon(lado);
            var presenter = new HexagonPresenter(hexagon);

            if (!presenter.IsValid)
            {
                lblMensaje.Text = "El lado debe ser mayor a 0.";
                LimpiarResultados();
                return;
            }

            _figuraActual = hexagon;
            lblAreaResult.Text = presenter.Area.ToString("0.00");
            lblPerimetroResult.Text = presenter.Perimeter.ToString("0.00");
            lblMensaje.Text = "";

            panel1.Invalidate();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarResultados();
        }

        private void panelHexagono_Paint(object sender, PaintEventArgs e)
        {
            if (_figuraActual == null)
                return;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(panel1.BackColor);

            float cx = panel1.ClientSize.Width / 2f;
            float cy = panel1.ClientSize.Height / 2f;

            float r = Math.Min(cx, cy) - margin;

            // Calcular los 6 vértices del hexágono
            // El ángulo de cada vértice es 60 grados, empezando desde -30 para que el primer vértice quede "arriba"
            PointF[] puntos = new PointF[6];
            for (int i = 0; i < 6; i++)
            {
                double ang = (i * 60 - 30) * Math.PI / 180.0;
                puntos[i] = new PointF(
                    cx + r * (float)Math.Cos(ang),
                    cy + r * (float)Math.Sin(ang));
            }

            using (var brush = new SolidBrush(Color.FromArgb(180, 255, 215, 0)))
            using (var pen = new Pen(Color.Goldenrod, 2))
            {
                g.FillPolygon(brush, puntos);
                g.DrawPolygon(pen, puntos);
            }
        }




    }
}