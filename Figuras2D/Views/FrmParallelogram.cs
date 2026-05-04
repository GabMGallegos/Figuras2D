using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Windows.Forms;
using Figuras2D.Models;
using Figuras2D.Presenters;

namespace Figuras2D
{
    public partial class FrmParallelogram : Form
    {
        private Parallelogram _parallelogramActual;

        private const float Margin = 20f;
        private const double MinRenderableSize = 20;

        public FrmParallelogram()
        {
            InitializeComponent();

            panel2.Size = new Size(390, 390);

            btnCalcular.Click += btnCalcular_Click;
            btnLimpiarCampos.Click += btnLimpiarCampos_Click;
            panel2.Paint += panel2_Paint;

                        this.BackColor = AppTheme.BgMain;
            this.ForeColor = AppTheme.TextPri;
            this.Font = AppTheme.FontMenu;
            this.btnCalcular.BackColor = AppTheme.Accent;
            this.btnCalcular.ForeColor = AppTheme.TextPri;
            this.btnLimpiarCampos.BackColor = AppTheme.Accent;
            this.btnLimpiarCampos.ForeColor = AppTheme.TextPri;
            this.lblMensaje.ForeColor = AppTheme.alert;
        }

        private bool TryGetDouble(TextBox textBox, out double value)
        {
            return double.TryParse(textBox.Text, NumberStyles.Float, CultureInfo.CurrentCulture, out value) ||
                   double.TryParse(textBox.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out value);
        }

        private float GetMaxRenderableWidth()
        {
            return panel2.ClientSize.Width - (2 * Margin);
        }

        private float GetMaxRenderableHeight()
        {
            return panel2.ClientSize.Height - (2 * Margin);
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (!TryGetDouble(txtBase, out double base_) ||
                !TryGetDouble(txtLado, out double lado) ||
                !TryGetDouble(txtAngulo, out double angulo))
            {
                lblMensaje.Text = "Ingrese valores numéricos válidos.";
                lblAreaResultado.Text = "0.00";
                lblPerimetroResultado.Text = "0.00";
                _parallelogramActual = null;
                panel2.Invalidate();
                return;
            }

            Parallelogram parallelogram = new Parallelogram(base_, lado, angulo);
            ParallelogramPresenter presenter = new ParallelogramPresenter(parallelogram);

            if (!presenter.IsValid)
            {
                lblMensaje.Text = "Valores inválidos. Base y lado > 0, ángulo entre 1° y 179°.";
                lblAreaResultado.Text = "0.00";
                lblPerimetroResultado.Text = "0.00";
                _parallelogramActual = null;
                panel2.Invalidate();
                return;
            }

            float maxWidth = GetMaxRenderableWidth();
            float maxHeight = GetMaxRenderableHeight();

            // Alto real = lado * sin(angulo)
            double altoReal = lado * Math.Sin(angulo * Math.PI / 180);
            // Ancho real = base + lado * cos(angulo)
            double anchoReal = base_ + lado * Math.Abs(Math.Cos(angulo * Math.PI / 180));

            if (base_ < MinRenderableSize || lado < MinRenderableSize)
            {
                lblMensaje.Text = $"El paralelogramo es demasiado pequeño. Use valores mayores o iguales a {MinRenderableSize:0.00}.";
                lblAreaResultado.Text = presenter.Area.ToString("0.00");
                lblPerimetroResultado.Text = presenter.Perimeter.ToString("0.00");
                _parallelogramActual = null;
                panel2.Invalidate();
                return;
            }

            if (anchoReal > maxWidth)
            {
                lblMensaje.Text = $"El paralelogramo no se puede renderizar. Ancho máximo: {maxWidth:0.00}.";
                lblAreaResultado.Text = presenter.Area.ToString("0.00");
                lblPerimetroResultado.Text = presenter.Perimeter.ToString("0.00");
                _parallelogramActual = null;
                panel2.Invalidate();
                return;
            }

            if (altoReal > maxHeight)
            {
                lblMensaje.Text = $"El paralelogramo no se puede renderizar. Alto máximo: {maxHeight:0.00}.";
                lblAreaResultado.Text = presenter.Area.ToString("0.00");
                lblPerimetroResultado.Text = presenter.Perimeter.ToString("0.00");
                _parallelogramActual = null;
                panel2.Invalidate();
                return;
            }

            _parallelogramActual = parallelogram;
            lblAreaResultado.Text = presenter.Area.ToString("0.00");
            lblPerimetroResultado.Text = presenter.Perimeter.ToString("0.00");
            lblMensaje.Text = "";
            panel2.Invalidate();
        }

        private void btnLimpiarCampos_Click(object sender, EventArgs e)
        {
            txtBase.Clear();
            txtLado.Clear();
            txtAngulo.Clear();
            lblAreaResultado.Text = "0.00";
            lblPerimetroResultado.Text = "0.00";
            lblMensaje.Text = "";
            _parallelogramActual = null;
            panel2.Invalidate();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            if (_parallelogramActual == null) return;

            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            float base_ = (float)_parallelogramActual.Base;
            float lado = (float)_parallelogramActual.Lado;
            double anguloRad = _parallelogramActual.Angulo * Math.PI / 180;

            float alto = lado * (float)Math.Sin(anguloRad);
            float desplazamiento = lado * (float)Math.Cos(anguloRad);
            float anchoTotal = base_ + Math.Abs(desplazamiento);

            float x = (panel2.ClientSize.Width - anchoTotal) / 2f;
            float y = (panel2.ClientSize.Height - alto) / 2f;

            PointF[] puntos = new PointF[]
            {
                new PointF(x + Math.Abs(desplazamiento), y),           
                new PointF(x + anchoTotal, y),                          
                new PointF(x + base_, y + alto),                        
                new PointF(x, y + alto)                                
            };

            using (SolidBrush brush = new SolidBrush(Color.LightSalmon))
            using (Pen pen = new Pen(Color.Black, 2))
            {
                graphics.FillPolygon(brush, puntos);
                graphics.DrawPolygon(pen, puntos);
            }
        }
    }
}