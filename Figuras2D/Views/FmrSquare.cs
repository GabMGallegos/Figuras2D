using System;
using System.Drawing;
using System.Windows.Forms;
using Figuras2D.Models;
using Figuras2D.Presenters;

namespace Figuras2D.Views
{
    public partial class FmrSquare : Form
    {
        private SquarePresenter _presenter;
        private double _maxLado = 100;

        public FmrSquare()
        {
            InitializeComponent();
            this.Resize += FmrSquare_Resize;

            this.BackColor = AppTheme.BgMain;
            this.ForeColor = AppTheme.TextPri;
            this.Font = AppTheme.FontMenu;
            this.btnCalcular.BackColor = AppTheme.Accent;
            this.btnCalcular.ForeColor = AppTheme.TextPri;
            this.btnLimpiarCampos.BackColor = AppTheme.Accent;
            this.btnLimpiarCampos.ForeColor = AppTheme.TextPri;
            this.lblMensaje.ForeColor = AppTheme.alert;
        }

        private void FmrSquare_Load(object sender, EventArgs e)
        {
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (double.TryParse(txtLado.Text, out double lado))
            {
                if (lado > 0)
                {
                    var square = new Square(lado);
                    _presenter = new SquarePresenter(square);

                    lblPerimetroResultado.Text = _presenter.Perimeter.ToString("F2");
                    lblAreaResultado.Text = _presenter.Area.ToString("F2");

                    panel2.Invalidate();
                }
                else
                {
                    MessageBox.Show("El lado debe ser mayor a 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Ingrese un valor numérico válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiarCampos_Click(object sender, EventArgs e)
        {
            txtLado.Text = "";
            lblPerimetroResultado.Text = "";
            lblAreaResultado.Text = "";
            _presenter = null;
            panel2.Invalidate();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            if (_presenter == null || !_presenter.IsValid)
                return;

            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.Clear(panel2.BackColor);

            double lado = _presenter.Side;
            float scale = CalcularEscala(lado);
            PointF[] points = _presenter.GetDrawingPoints(scale);
            Point centro = new Point(panel2.Width / 2, panel2.Height / 2);

            for (int i = 0; i < points.Length; i++)
            {
                points[i] = new PointF(centro.X + points[i].X, centro.Y + points[i].Y);
            }

            using (Brush relleno = new SolidBrush(Color.LightGreen))
            using (Pen borde = new Pen(Color.DarkGreen, 2))
            {
                g.FillPolygon(relleno, points);
                g.DrawPolygon(borde, points);
            }
        }

        private float CalcularEscala(double lado)
        {
            float areaDisponible = Math.Min(panel2.Width, panel2.Height) * 0.8f;
            float escala = (float)(areaDisponible / _maxLado) * (float)lado;

            if (escala > areaDisponible)
                escala = areaDisponible;
            if (escala < 5)
                escala = 5;

            return escala;
        }

        private void FmrSquare_Resize(object sender, EventArgs e)
        {
            if (_presenter != null)
                panel2.Invalidate();
        }

        private void txtLado_TextChanged(object sender, EventArgs e)
        {
        }

        private void lblPerimetro_Click(object sender, EventArgs e)
        {
        }
    }
}