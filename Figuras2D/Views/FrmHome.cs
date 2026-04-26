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

        private void miCruzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCross frmCross = new FrmCross();
            frmCross.MdiParent = this;
            frmCross.Show();
        }

        private void miCorazonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmHeart frmHeart = new FrmHeart(); 
            frmHeart.MdiParent = this;
            frmHeart.Show();
        }

        private void miCometaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmKite frmKite = new FrmKite();
            frmKite.MdiParent = this;
            frmKite.Show();
        }

        private void miOctagonoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmOctagon frmOctagon = new FrmOctagon();
            frmOctagon.MdiParent = this;
            frmOctagon.Show();
        }

        private void miPastelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPie frmPie = new FrmPie();
            frmPie.MdiParent = this;
            frmPie.Show();
        }

        private void miRomboToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRhombus frmRhombus = new FrmRhombus();
            frmRhombus.MdiParent = this;
            frmRhombus.Show();
        }

        private void miSemicirculoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSemicircle frmSemicircle = new FrmSemicircle();
            frmSemicircle.MdiParent = this;
            frmSemicircle.Show();
        }

        private void FrmHome_Load(object sender, EventArgs e)
        {

        }

        private void cuadradoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FmrSquare frmSquare = new FmrSquare();
            frmSquare.MdiParent = this;
            frmSquare.Show();
        }

        private void circuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FmrCircle frmCircle = new FmrCircle ();
            frmCircle.MdiParent = this;
            frmCircle.Show();
        }

        private void trianguloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTriangle frmTriangle = new FrmTriangle();
            frmTriangle.MdiParent = this;
            frmTriangle.Show();
        }

        private void rectanguloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRectangulo frmRectangle = new FrmRectangulo();
            frmRectangle.MdiParent = this; 
            frmRectangle.Show();
        }

        private void estrellaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmStar frmStar = new FrmStar();
            frmStar.MdiParent = this; 
            frmStar.Show();
        }

        private void pentagonoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPentagon frmPentagon = new FrmPentagon();
            frmPentagon.MdiParent = this;
            frmPentagon.Show();
        }

        private void paralelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmParallelogram frmParallelogram = new FrmParallelogram();
            frmParallelogram.MdiParent = this;
            frmParallelogram.Show();
        }
    }
}
