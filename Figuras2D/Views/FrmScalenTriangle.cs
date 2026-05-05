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

        private float GetMaxRenderableDiameter()
        {
            return Math.Min(panel1.ClientSize.Width, panel1.ClientSize.Height) - (2 * margin);
        }

        private double GetMaxRenderableSide()
        {
            float maxDiameter = GetMaxRenderableDiameter();
            return maxDiameter / 2.0;
        }
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

            float escala = 5f;
            // Calcular los 3 vértices a partir de los lados (ley de cosenos)

            double a = _figuraActual.SideA * escala;
            double b = _figuraActual.SideB * escala;
            double c = _figuraActual.SideC * escala;

            double cosA = (b * b + c * c - a * a) / (2 * b * c);
            double angA = Math.Acos(cosA);

            PointF[] p = new PointF[3];
            p[0] = new PointF(0f, 0f);
            p[1] = new PointF((float)c, 0f);
            p[2] = new PointF(
                (float)(b * Math.Cos(angA)),
                (float)(-b * Math.Sin(angA)));   // Y negativo → arriba en pantalla

            float offsetX = panel1.ClientSize.Width / 2f - (float)_figuraActual.SideC / 2f;
            float offsetY = panel1.ClientSize.Height / 2f + (float)(_figuraActual.SideB * Math.Sin(angA)) / 2f;

            for (int i = 0; i < p.Length; i++)
            {
                p[i].X += offsetX;
                p[i].Y += offsetY;
            }

            using (var brush = new SolidBrush(Color.FromArgb(180, 173, 216, 230)))
            using (var pen = new Pen(Color.SteelBlue, 2))
            {
                g.FillPolygon(brush, p);
                g.DrawPolygon(pen, p);
            }

            // Dibujar
            using (var brush = new SolidBrush(Color.FromArgb(180, 173, 216, 230)))
            using (var pen = new Pen(Color.SteelBlue, 2))
            {
                g.FillPolygon(brush, p);
                g.DrawPolygon(pen, p);
            }
        }

    }
}
