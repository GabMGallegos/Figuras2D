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

        private const double MinRenderableSide = 20; 

        private float GetMaxRenderableDiameter()
        {
            return Math.Min(panel1.ClientSize.Width, panel1.ClientSize.Height) - (2 * margin);
        }

        private double GetMaxRenderableSide()
        {
            float maxDiameter = GetMaxRenderableDiameter();
            return maxDiameter / 2.0;
        }

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
                lblMensaje.Text = "Ingrese un valor numérico válido.";
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

            double maxRenderableSide = GetMaxRenderableSide();



            if (lado < MinRenderableSide)
            {
                lblMensaje.Text = $"El hexágono es muy pequeño. Use un lado ≥ {MinRenderableSide:0.00}.";
                _figuraActual = null;
                panel1.Invalidate();
                return;
            }
    
            if (lado > maxRenderableSide)
            {
                lblMensaje.Text = $"El hexágono es muy grande. El lado máximo es {maxRenderableSide:0.00}.";
                _figuraActual = null;
                panel1.Invalidate();
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
            txtLado.Text = "";
        }

        private void panelHexagono_Paint(object sender, PaintEventArgs e)
        {
            if (_figuraActual == null) return;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Uso lado real para el dibujo, para que se vea proporcional al valor ingresado
            float lado = (float)_figuraActual.Side;

            float radio = lado;

            float cx = panel1.ClientSize.Width / 2f;
            float cy = panel1.ClientSize.Height / 2f;

            PointF[] puntos = new PointF[6];
            for (int i = 0; i < 6; i++)
            {
                // Ajustamos el ángulo para que se vea igual que el de tus compañeros
                double ang = (i * 60 - 30) * Math.PI / 180.0;
                puntos[i] = new PointF(
                    cx + radio * (float)Math.Cos(ang),
                    cy + radio * (float)Math.Sin(ang));
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