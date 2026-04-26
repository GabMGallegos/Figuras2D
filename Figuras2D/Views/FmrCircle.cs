using System;
using System.Drawing;
using System.Windows.Forms;
using Figuras2D.Models;
using Figuras2D.Presenters;

namespace Figuras2D.Views
{
    public partial class FmrCircle : Form
    {
        private CirclePresenter _presenter;
        private double _maxRadius = 100;

        public FmrCircle()
        {
            InitializeComponent();
            this.Resize += FmrCircle_Resize;
        }

        private void FmrCircle_Load(object sender, EventArgs e)
        {
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (double.TryParse(txtRadio.Text, out double radio))
            {
                if (radio > 0)
                {
                    var circle = new Circle(radio);
                    _presenter = new CirclePresenter(circle);

                    lblPerimetroResultado.Text = _presenter.Perimeter.ToString("F2");
                    lblAreaResultado.Text = _presenter.Area.ToString("F2");

                    panelCirculo.Invalidate();
                }
                else
                {
                    MessageBox.Show("El radio debe ser mayor a 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Ingrese un valor numérico válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiarCampos_Click(object sender, EventArgs e)
        {
            txtRadio.Text = "";
            lblPerimetroResultado.Text = "";
            lblAreaResultado.Text = "";
            _presenter = null;
            panelCirculo.Invalidate();
        }

        private void panelCirculo_Paint(object sender, PaintEventArgs e)
        {
            if (_presenter == null || !_presenter.IsValid)
                return;

            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.Clear(panelCirculo.BackColor);

            double radio = _presenter.Radius;
            float scale = CalcularEscala(radio);
            PointF[] points = _presenter.GetDrawingPoints(scale);
            Point centro = new Point(panelCirculo.Width / 2, panelCirculo.Height / 2);

            for (int i = 0; i < points.Length; i++)
            {
                points[i] = new PointF(centro.X + points[i].X, centro.Y + points[i].Y);
            }

            using (Brush relleno = new SolidBrush(Color.LightCoral))
            using (Pen borde = new Pen(Color.DarkRed, 2))
            {
                g.FillPolygon(relleno, points);
                g.DrawPolygon(borde, points);
            }
        }

        private float CalcularEscala(double radio)
        {
            float areaDisponible = Math.Min(panelCirculo.Width, panelCirculo.Height) * 0.8f;
            float escala = (float)(areaDisponible / _maxRadius) * (float)radio;

            if (escala > areaDisponible)
                escala = areaDisponible;
            if (escala < 5)
                escala = 5;

            return escala;
        }

        private void FmrCircle_Resize(object sender, EventArgs e)
        {
            if (_presenter != null)
                panelCirculo.Invalidate();
        }
    }
}