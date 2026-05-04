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
    public partial class FrmScalenTriangle : Form
    {
        private ScaleneTriangle _figuraActual;
        private const float margin = 20f;
        public FrmScalenTriangle()
        {
            InitializeComponent();

            btnCalcular.Click += btnCalcular_Click;
            btnLimpiar.Click += btnLimpiar_Click;
            txtLado1.TextChanged += (s,e) => LimpiarResultados();
            txtLado2.TextChanged += (s,e) => LimpiarResultados();
            txtLado3.TextChanged += (s,e) => LimpiarResultados();
            panel1.Paint += panel1_Paint;

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
            return double.TryParse(textBox.Text, NumberStyles.Float, CultureInfo.CurrentCulture, out value) ||
                   double.TryParse(textBox.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out value);
        }
        private void LimpiarResultados()
        {
            lblAreaResult.Text = "0.00";
            lblPerimetroResult.Text = "0.00";
            lblMensaje.Text = string.Empty;
            _figuraActual = null;
            panel1.Invalidate();
        }
        private void txtLado1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarResultados();
            txtLado1.Text = "";
            txtLado2.Text = "";
            txtLado3.Text = "";

        }


        private void btnCalcular_Click(object sender, EventArgs e)
        {
            
            if (!TryGetDouble(txtLado1, out double a) ||
                !TryGetDouble(txtLado2, out double b) ||
                !TryGetDouble(txtLado3, out double c))
            {
                lblMensaje.Text = "Ingrese valores numéricos válidos en los tres lados.";
                LimpiarResultados();
                return;
            }

            
            var triangle = new ScaleneTriangle(a, b, c);
            var presenter = new ScaleneTrianglePresenter(triangle);

            
            if (!presenter.IsValid)
            {
                lblMensaje.Text =
                    "Triángulo inválido. Verifique que:\n" +
                    "  • Los tres lados sean mayores a 0.\n" +
                    "  • Se cumpla la desigualdad triangular.\n" +
                    "  • Los tres lados sean distintos (escaleno).";
                LimpiarResultados();
                return;
            }

            
            _figuraActual = triangle;
            lblAreaResult.Text = presenter.Area.ToString("0.00");
            lblPerimetroResult.Text = presenter.Perimeter.ToString("0.00");
            lblMensaje.Text = "";

            panel1.Invalidate();   
        }
        

        private void txtLado2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLado3_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (_figuraActual == null)
                return;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(panel1.BackColor);

            // Calcular los 3 vértices a partir de los lados (ley de cosenos)
            PointF[] puntos = CalcularVertices(
                _figuraActual.SideA,
                _figuraActual.SideB,
                _figuraActual.SideC);

            // Escalar y centrar para que ocupe el panel
            EscalarYCentrar(puntos, panel1.ClientSize);

            // Dibujar
            using (var brush = new SolidBrush(Color.FromArgb(180, 173, 216, 230)))
            using (var pen = new Pen(Color.SteelBlue, 2))
            {
                g.FillPolygon(brush, puntos);
                g.DrawPolygon(pen, puntos);
            }

            // Etiquetas de cada lado
            DibujarEtiquetaLado(g, puntos[0], puntos[1], _figuraActual.SideC, "c");
            DibujarEtiquetaLado(g, puntos[0], puntos[2], _figuraActual.SideB, "b");
            DibujarEtiquetaLado(g, puntos[1], puntos[2], _figuraActual.SideA, "a");
        }

        private PointF[] CalcularVertices(double a, double b, double c)
        {
            // Ángulo en el vértice P0 (opuesto a lado a)
            double cosA = (b * b + c * c - a * a) / (2 * b * c);
            double angA = Math.Acos(cosA);

            PointF[] p = new PointF[3];
            p[0] = new PointF(0f, 0f);
            p[1] = new PointF((float)c, 0f);
            p[2] = new PointF(
                (float)(b * Math.Cos(angA)),
                (float)(-b * Math.Sin(angA)));   // Y negativo → arriba en pantalla

            return p;
        }

        private void EscalarYCentrar(PointF[] puntos, Size panelSize)
        {
            float minX = float.MaxValue, maxX = float.MinValue;
            float minY = float.MaxValue, maxY = float.MinValue;

            foreach (var p in puntos)
            {
                if (p.X < minX) minX = p.X;
                if (p.X > maxX) maxX = p.X;
                if (p.Y < minY) minY = p.Y;
                if (p.Y > maxY) maxY = p.Y;
            }

            float anchoFig = maxX - minX;
            float altoFig = maxY - minY;

            float escalaX = (panelSize.Width - 2 * margin) / anchoFig;
            float escalaY = (panelSize.Height - 2 * margin) / altoFig;
            float escala = Math.Min(escalaX, escalaY);

            for (int i = 0; i < puntos.Length; i++)
            {
                puntos[i].X = (puntos[i].X - minX) * escala + margin;
                puntos[i].Y = (puntos[i].Y - minY) * escala + margin;
            }
        }

        private void DibujarEtiquetaLado(
            Graphics g, PointF p1, PointF p2, double valor, string nombre)
        {
            float mx = (p1.X + p2.X) / 2f;
            float my = (p1.Y + p2.Y) / 2f;

            // Desplazar 14px en dirección perpendicular al lado
            float dx = p2.X - p1.X;
            float dy = p2.Y - p1.Y;
            float len = (float)Math.Sqrt(dx * dx + dy * dy);
            if (len < 0.001f) return;

            float nx = -dy / len * 14f;   // normal unitaria × 14px
            float ny = dx / len * 14f;

            string texto = $"{nombre} = {valor:0.00}";

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
