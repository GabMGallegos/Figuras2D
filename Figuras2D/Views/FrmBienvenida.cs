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
    public partial class FrmBienvenida : Form
    {
        public FrmBienvenida()
        {
            InitializeComponent();
            AplicarTema();
            this.Resize += (s, e) => this.Invalidate();
        }

        private void AplicarTema()
        {
            this.BackColor = AppTheme.BgMain;
            this.ForeColor = AppTheme.TextPri;
            this.Font = AppTheme.FontMenu;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized; 
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            
            using (Font fTitulo = new Font("Segoe UI", 26f, FontStyle.Bold))
            using (SolidBrush bTitulo = new SolidBrush(AppTheme.AccentSub))
            {
                string titulo = "Figuras 2D";
                SizeF sz = g.MeasureString(titulo, fTitulo);
                g.DrawString(titulo, fTitulo, bTitulo,
                    (this.Width - sz.Width) / 2,
                    this.Height / 2 - 80);
            }

            
            using (Font fSub = new Font("Segoe UI Light", 13f))
            using (SolidBrush bSub = new SolidBrush(AppTheme.TextSec))
            {
                string sub = "Selecciona una figura desde el menú Figuras";
                SizeF sz = g.MeasureString(sub, fSub);
                g.DrawString(sub, fSub, bSub,
                    (this.Width - sz.Width) / 2,
                    this.Height / 2 - 20);
            }

           
            string[] iconos = { "○", "□", "△", "⬠", "✦" };
            using (Font fIcono = new Font("Segoe UI", 22f))
            using (SolidBrush bIcono = new SolidBrush(Color.FromArgb(50, 83, 74, 183)))
            {
                int totalAncho = iconos.Length * 60;
                int startX = (this.Width - totalAncho) / 2;
                for (int i = 0; i < iconos.Length; i++)
                    g.DrawString(iconos[i], fIcono, bIcono, startX + i * 60, this.Height / 2 + 40);
            }
        }

        private void FrmBienvenida_Load(object sender, EventArgs e)
        {

        }
    }
}