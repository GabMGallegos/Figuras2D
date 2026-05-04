using System;
using System.Drawing;
using System.Windows.Forms;

namespace Figuras2D.Views
{
    public partial class FrmHome : Form
    {
        private FrmBienvenida _bienvenida;
        public FrmHome()
        {
            InitializeComponent();
            AplicarTema();
        }

        private void AplicarTema()
        {
            this.BackColor = AppTheme.BgMain;
            this.ForeColor = AppTheme.TextPri;
            this.Font = AppTheme.FontMenu;

            this.IsMdiContainer = true;
            foreach (Control c in this.Controls)
                if (c.GetType().Name == "MdiClient")
                    c.BackColor = Color.FromArgb(18, 18, 38);

            menuStrip2.BackColor = AppTheme.BgPanel;
            menuStrip2.ForeColor = AppTheme.TextPri;
            menuStrip2.Font = AppTheme.FontMenu;
            menuStrip2.Renderer = new MenuRendererOscuro();

            EstilizarMenuRecursivo(menuStrip2.Items);
        }

        private void EstilizarMenuRecursivo(ToolStripItemCollection items)
        {
            foreach (ToolStripItem item in items)
            {
                item.BackColor = AppTheme.BgPanel;
                item.ForeColor = AppTheme.TextPri;
                item.Font = AppTheme.FontMenu;

                if (item is ToolStripMenuItem mi)
                    EstilizarMenuRecursivo(mi.DropDownItems);
            }
        }

        private void FrmHome_Load(object sender, EventArgs e) {
            _bienvenida = new FrmBienvenida();
            _bienvenida.MdiParent = this; _bienvenida.Show();
            _bienvenida.Show();
        }

        private void msFigurasToolStripMenuItem_Click(object sender, EventArgs e) { }

        private void corazonToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmHeart f = new FrmHeart();
            f.MdiParent = this; f.Show();
        }

        private void cuadradoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FmrSquare f = new FmrSquare();
            f.MdiParent = this; f.Show();
        }

        private void rectanguloToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmRectangulo f = new FrmRectangulo();
            f.MdiParent = this; f.Show();
        }

        private void trianguloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTriangle f = new FrmTriangle();
            f.MdiParent = this; f.Show();
        }

        private void trianguloEscalenoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmScalenTriangle f = new FrmScalenTriangle();
            f.MdiParent = this; f.Show();
        }

        private void romboToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRhombus f = new FrmRhombus();
            f.MdiParent = this; f.Show();
        }

        private void pentagonoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmPentagon f = new FrmPentagon();
            f.MdiParent = this; f.Show();
        }

        private void octagonoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmOctagon f = new FrmOctagon();
            f.MdiParent = this; f.Show();
        }

        private void paralelogramoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmParallelogram f = new FrmParallelogram();
            f.MdiParent = this; f.Show();
        }

        private void circuloToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FmrCircle f = new FmrCircle();
            f.MdiParent = this; f.Show();
        }

        private void semicirculoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSemicircle f = new FrmSemicircle();
            f.MdiParent = this; f.Show();
        }

        private void cruzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCross f = new FrmCross();
            f.MdiParent = this; f.Show();
        }

        private void cometaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmKite f = new FrmKite();
            f.MdiParent = this; f.Show();
        }

        private void pastelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPie f = new FrmPie();
            f.MdiParent = this; f.Show();
        }

        private void estrellaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmStar f = new FrmStar();
            f.MdiParent = this; f.Show();
        }

        private void hexagonoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmHexagon f = new FrmHexagon();
            f.MdiParent = this; f.Show();
        }

        private void trapecioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTrapezoid f = new FrmTrapezoid();
            f.MdiParent = this; f.Show();
        }

        private void lunaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCrescentMoon f = new FrmCrescentMoon();
            f.MdiParent = this; f.Show();
        }

        private void trebolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmClover f = new FrmClover();
            f.MdiParent = this; f.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }

    public class MenuRendererOscuro : ToolStripProfessionalRenderer
    {
        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            var color = e.Item.Selected ? AppTheme.Accent : AppTheme.BgPanel;
            using (SolidBrush b = new SolidBrush(color))
            {
                e.Graphics.FillRectangle(b, e.Item.ContentRectangle);
            }
        }

        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(AppTheme.BgPanel))
            {
                e.Graphics.FillRectangle(b, e.AffectedBounds);
            }
        }

        protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
        {
            using (Pen p = new Pen(AppTheme.Separator))
            {
                int y = e.Item.Height / 2;
                e.Graphics.DrawLine(p, 4, y, e.Item.Width - 4, y);
            }
        }

        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            e.ArrowColor = AppTheme.AccentSub;
            base.OnRenderArrow(e);
        }
    }
}