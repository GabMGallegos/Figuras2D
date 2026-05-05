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

        private const double MinRenderableSide = 20;

        private float GetMaxRenderableDiameter()
        {
            return Math.Min(panel1.ClientSize.Width, panel1.ClientSize.Height) - (2 * margin);
        }
        private double GetMaxRenderableSide() 
        {
            return GetMaxRenderableDiameter();
           
        }


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

        private Trapezoid Get_figuraActual1()
        {
            return _figuraActual;
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

            double maxRenderableSide = GetMaxRenderableSide();

            if(bMayor==bMenor)
            {
                lblMensaje.Text = $"El trapecio es en realidad un rectángulo.";
                _figuraActual = null;
                panel1.Invalidate();
                return;
            }

            if (bMayor< MinRenderableSide)
            {
                lblMensaje.Text = $"El trapecio es muy pequeño. Use un lado ≥ {MinRenderableSide:0.00}.";
                _figuraActual = null;
                panel1.Invalidate();
                return;
            }

            if (bMayor > maxRenderableSide)
            {
                lblMensaje.Text = $"El trapecio es muy grande. El lado máximo es {maxRenderableSide:0.00}.";
                _figuraActual = null;
                panel1.Invalidate();
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

            float escala =5f;
            float bMayor = (float)_figuraActual.MajorBase * escala;
            float bMenor = (float)_figuraActual.MinorBase * escala;
            float h = (float)_figuraActual.Height * escala;
            float offset = (bMayor - bMenor) / 2f;

            float cx = panel1.ClientSize.Width / 2f;
            float cy = panel1.ClientSize.Height / 2f;

            PointF[] puntos = new PointF[]
            {
                new PointF(cx-bMayor,cy+h/2f),  //inferior izquierdo
                new PointF(cx+bMayor,cy+h/2f),  //inferior derecho
                new PointF(cx+bMenor, cy-h/2f),      //superior derecho
                new PointF(cx-bMenor, cy-h/2f)       //superior izquierdo
            };

            using (var brush = new SolidBrush(Color.FromArgb(180, 144, 238, 144)))
            using (var pen = new Pen(Color.DarkGreen, 2))
            {
                g.FillPolygon(brush, puntos);
                g.DrawPolygon(pen, puntos);
            }
        }
        }
    }

