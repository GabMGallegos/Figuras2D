using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Figuras2D.Views
{
    public partial class FrmHome : Form
    {
        public FrmHome()
        {
            InitializeComponent();
        }

        private void FrmHome_Load(object sender, EventArgs e)
        {

        }

        private void msFigurasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void corazonToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmHeart frmHeart = new FrmHeart();
            frmHeart.MdiParent = this;
            frmHeart.Show();
        }

        private void cuadradoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FmrSquare frmSquare = new FmrSquare();
            frmSquare.MdiParent = this;
            frmSquare.Show();
        }

        private void rectanguloToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmRectangulo frmRectangulo = new FrmRectangulo();
            frmRectangulo.MdiParent = this;
            frmRectangulo.Show();
        }

        private void trianguloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTriangle frmTriangle = new FrmTriangle();
            frmTriangle.MdiParent = this;
            frmTriangle.Show();
        }

        private void trianguloEscalenoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmScalenTriangle frmScalenTriangle = new FrmScalenTriangle();
            frmScalenTriangle.MdiParent = this;
            frmScalenTriangle.Show();
        }

        private void romboToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRhombus frmRhombus = new FrmRhombus();
            frmRhombus.MdiParent = this;
            frmRhombus.Show();
        }

        private void pentagonoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmPentagon frmPentagon = new FrmPentagon();
            frmPentagon.MdiParent = this;
            frmPentagon.Show();
        }

        private void octagonoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmOctagon frmOctagon = new FrmOctagon();
            frmOctagon.MdiParent = this;
            frmOctagon.Show();
        }

        private void paralelogramoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmParallelogram frmParallelogram = new FrmParallelogram();
            frmParallelogram.MdiParent = this;
            frmParallelogram.Show();
        }

        private void circuloToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FmrCircle frmCirculo = new FmrCircle();
            frmCirculo.MdiParent = this;
            frmCirculo.Show();
        }

        private void semicirculoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSemicircle frmSemicircle = new FrmSemicircle();
            frmSemicircle.MdiParent = this;
            frmSemicircle.Show();
        }

        private void cruzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCross frmCross = new FrmCross();
            frmCross.MdiParent = this;
            frmCross.Show();
        }

        private void cometaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmKite frmKite = new FrmKite();
            frmKite.MdiParent = this;
            frmKite.Show();
        }

        private void pastelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPie frmPie = new FrmPie();
            frmPie.MdiParent = this;
            frmPie.Show();
        }

        private void estrellaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmStar frmStar = new FrmStar();
            frmStar.MdiParent = this;
            frmStar.Show();
        }

        private void hexagonoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmHexagon frmHexagon = new FrmHexagon();
            frmHexagon.MdiParent = this;
            frmHexagon.Show();
        }

        private void trapecioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTrapezoid frmTrape = new FrmTrapezoid();
            frmTrape.MdiParent = this;
            frmTrape.Show();
        }

        private void lunaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCrescentMoon frmCrescentMoon = new FrmCrescentMoon();
            frmCrescentMoon.MdiParent = this; frmCrescentMoon.Show();
        }

        private void trebolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmClover frmClover = new FrmClover(); frmClover.MdiParent = this; frmClover.Show();
        }
    }
}
