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
            txtBaseMayor.Text = "";
            txtBaseMenor.Text = "";
            txtAltura.Text = "";
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
                new PointF(0f,                     (float)h),  //inferior izquierdo
                new PointF((float)bMayor,          (float)h),  //inferior derecho
                new PointF((float)(offset + bMenor), 0f),      //superior derecho
                new PointF((float)offset,            0f)       //superior izquierdo
            };

            EscalarYCentrar(puntos, panel1.ClientSize);

            using (var brush = new SolidBrush(Color.FromArgb(180, 144, 238, 144)))
            using (var pen = new Pen(Color.DarkGreen, 2))
            {
                g.FillPolygon(brush, puntos);
                g.DrawPolygon(pen, puntos);
            }

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
        }
    }

