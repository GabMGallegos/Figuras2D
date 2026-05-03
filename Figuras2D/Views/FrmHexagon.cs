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
        private const float Margin = 20f;

        public FrmHexagon()
        {
            InitializeComponent();

            btnCalcular.Click += btnCalcular_Click;
            btnLimpiar.Click += btnLimpiar_Click;
            panel1.Paint += panelHexagono_Paint;

            txtLado.TextChanged += (s, e) => LimpiarResultados();
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

            float r = Math.Min(cx, cy) - Margin;

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

            DibujarEtiquetaLado(g, puntos[0], puntos[1],
                _figuraActual.Side, "Lado");
        }


        private void DibujarEtiquetaLado(
            Graphics g, PointF p1, PointF p2, double valor, string nombre)
        {
            float mx = (p1.X + p2.X) / 2f;
            float my = (p1.Y + p2.Y) / 2f;

            float dx = p2.X - p1.X;
            float dy = p2.Y - p1.Y;
            float len = (float)Math.Sqrt(dx * dx + dy * dy);
            if (len < 0.001f) return;

            float nx = -dy / len * 14f;
            float ny = dx / len * 14f;

            string texto = $"{nombre}: {valor:0.00}";

            using (var font = new Font("Segoe UI", 8f, FontStyle.Regular))
            using (var brush = new SolidBrush(Color.FromArgb(60, 60, 60)))
            {
                SizeF sz = g.MeasureString(texto, font);
                g.DrawString(texto, font, brush,
                    mx + nx - sz.Width / 2f,
                    my + ny - sz.Height / 2f);
            }
        }


    }
}