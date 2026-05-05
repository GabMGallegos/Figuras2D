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
    public partial class FrmCrescentMoon : Form
    {
        private CrescentMoon _figuraActual;
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


        public FrmCrescentMoon()
        {
            InitializeComponent();

            btnCalcular.Click += btnCalcular_Click;
            btnLimpiar.Click += btnLimpiar_Click;
            panel1.Paint += panelLuna_Paint;

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

            var moon = new CrescentMoon(radio);
            var presenter = new CrescentMoonPresenter(moon);

            if (!presenter.IsValid)
            {
                lblMensaje.Text = "El radio debe ser mayor a 0.";
                LimpiarResultados();
                return;
            }

            double maxRenderableSide = GetMaxRenderableSide();

            if (radio < MinRenderableSide)
            {
                lblMensaje.Text = $"La media luna es muy pequeña. Use un radio ≥ {MinRenderableSide:0.00}.";
                _figuraActual = null;
                panel1.Invalidate();
                return;
            }

            if (radio > maxRenderableSide)
            {
                lblMensaje.Text = $"La media luna es muy grande. El radio máximo es {maxRenderableSide:0.00}.";
                _figuraActual = null;
                panel1.Invalidate();
                return;
            }

            _figuraActual = moon;
            lblAreaResult.Text = presenter.Area.ToString("0.00");
            lblPerimetroResult.Text = presenter.Perimeter.ToString("0.00");
            lblMensaje.Text = "";

            panel1.Invalidate();
        }


        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarResultados();
        }


        private void panelLuna_Paint(object sender, PaintEventArgs e)
        {
            if (_figuraActual == null)
                return;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(panel1.BackColor);

            float cx = panel1.ClientSize.Width / 2f;
            float cy = panel1.ClientSize.Height / 2f;

            
            float R =(float)_figuraActual.Radius;

            
            float r = R * 0.75f;   // radio del círculo interior
            float d = R * 0.35f;   // desplazamiento hacia la derecha

            
            var outerRect = new RectangleF(cx - R, cy - R, 2 * R, 2 * R);
            
            var innerRect = new RectangleF(cx - r + d, cy - r, 2 * r, 2 * r);

            using (var outerPath = new GraphicsPath())
            using (var innerPath = new GraphicsPath())
            {
                outerPath.AddEllipse(outerRect);
                innerPath.AddEllipse(innerRect);

                
                var region = new Region(outerPath);
                region.Exclude(innerPath);

                using (var brush = new SolidBrush(Color.FromArgb(210, 255, 248, 180)))
                {
                    
                    g.FillRegion(brush, region);
                }

                region.Dispose();
            }

        }
    }
}
