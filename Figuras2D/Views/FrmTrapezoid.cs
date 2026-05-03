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
    public partial class FrmTrapezoid : Form
    {
        private Trapezoid _figuraActual;
        private const float margin = 20f;

        public FrmTrapezoid()
        {
            InitializeComponent();

            btnCalcular.Click += btnCalcular_Click;
            btnLimpiar.Click += btnLimpiar_Click;
            panel1.Paint += panelTrapecio_Paint;

            txtBaseMayor.TextChanged += (s, e) => LimpiarResultados();
            txtBaseMenor.TextChanged += (s, e) => LimpiarResultados();
            txtAltura.TextChanged += (s, e) => LimpiarResultados();
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

        // ---------------------------------------------------------------
        // BOTÓN CALCULAR
        // ---------------------------------------------------------------
        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (!TryGetDouble(txtBaseMayor, out double bMayor) ||
                !TryGetDouble(txtBaseMenor, out double bMenor) ||
                !TryGetDouble(txtAltura, out double h))
            {
                lblMensaje.Text = "Ingrese valores numéricos válidos en los tres campos.";
                LimpiarResultados();
                return;
            }

            var trapezoid = new Trapezoid(bMayor, bMenor, h);
            var presenter = new TrapezoidPresenter(trapezoid);

            if (!presenter.IsValid)
            {
                lblMensaje.Text =
                    "Trapecio inválido. Verifique que:\n" +
                    "  • Todos los valores sean mayores a 0.\n" +
                    "  • La base mayor sea estrictamente mayor que la base menor.";
                LimpiarResultados();
                return;
            }

            _figuraActual = trapezoid;
            lblAreaResult.Text = presenter.Area.ToString("0.00");
            lblPerimetroResult.Text = presenter.Perimeter.ToString("0.00");
            lblMensaje.Text = "";

            panel1.Invalidate();
        }


        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarResultados();
        }



        private void panelTrapecio_Paint(object sender, PaintEventArgs e)
        {
            if (_figuraActual == null)
                return;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(panel1.BackColor);

            double bMayor = _figuraActual.MajorBase;
            double bMenor = _figuraActual.MinorBase;
            double h = _figuraActual.Height;

            double offset = (bMayor - bMenor) / 2.0;

            PointF[] puntos = new PointF[]
            {
                new PointF(0f,                     (float)h),  
                new PointF((float)bMayor,          (float)h),  
                new PointF((float)(offset + bMenor), 0f),      
                new PointF((float)offset,            0f)       
            };

            EscalarYCentrar(puntos, panel1.ClientSize);

            using (var brush = new SolidBrush(Color.FromArgb(180, 144, 238, 144)))
            using (var pen = new Pen(Color.DarkGreen, 2))
            {
                g.FillPolygon(brush, puntos);
                g.DrawPolygon(pen, puntos);
            }


            DibujarEtiquetaLado(g, puntos[0], puntos[1], bMayor, "Base mayor");
            DibujarEtiquetaLado(g, puntos[3], puntos[2], bMenor, "Base menor");
            DibujarEtiquetaLado(g, puntos[0], puntos[3], _figuraActual.LateralSide, "Lado");
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

            float escalaX = (panelSize.Width - 2 * margin) / (maxX - minX);
            float escalaY = (panelSize.Height - 2 * margin) / (maxY - minY);
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
