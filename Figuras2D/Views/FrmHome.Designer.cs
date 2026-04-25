namespace Figuras2D.Views
{
    partial class FrmHome
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.msFigurasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miCruzToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miCorazonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miCometaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miOctagonoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miPastelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miRomboToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miSemicirculoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip2
            // 
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msFigurasToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(800, 28);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // msFigurasToolStripMenuItem
            // 
            this.msFigurasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miCruzToolStripMenuItem,
            this.miCorazonToolStripMenuItem,
            this.miCometaToolStripMenuItem,
            this.miOctagonoToolStripMenuItem,
            this.miPastelToolStripMenuItem,
            this.miRomboToolStripMenuItem,
            this.miSemicirculoToolStripMenuItem});
            this.msFigurasToolStripMenuItem.Name = "msFigurasToolStripMenuItem";
            this.msFigurasToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
            this.msFigurasToolStripMenuItem.Text = "Figuras";
            // 
            // miCruzToolStripMenuItem
            // 
            this.miCruzToolStripMenuItem.Name = "miCruzToolStripMenuItem";
            this.miCruzToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.miCruzToolStripMenuItem.Text = "Cruz";
            this.miCruzToolStripMenuItem.Click += new System.EventHandler(this.miCruzToolStripMenuItem_Click);
            // 
            // miCorazonToolStripMenuItem
            // 
            this.miCorazonToolStripMenuItem.Name = "miCorazonToolStripMenuItem";
            this.miCorazonToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.miCorazonToolStripMenuItem.Text = "Corazón";
            this.miCorazonToolStripMenuItem.Click += new System.EventHandler(this.miCorazonToolStripMenuItem_Click);
            // 
            // miCometaToolStripMenuItem
            // 
            this.miCometaToolStripMenuItem.Name = "miCometaToolStripMenuItem";
            this.miCometaToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.miCometaToolStripMenuItem.Text = "Cometa";
            this.miCometaToolStripMenuItem.Click += new System.EventHandler(this.miCometaToolStripMenuItem_Click);
            // 
            // miOctagonoToolStripMenuItem
            // 
            this.miOctagonoToolStripMenuItem.Name = "miOctagonoToolStripMenuItem";
            this.miOctagonoToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.miOctagonoToolStripMenuItem.Text = "Octágono";
            this.miOctagonoToolStripMenuItem.Click += new System.EventHandler(this.miOctagonoToolStripMenuItem_Click);
            // 
            // miPastelToolStripMenuItem
            // 
            this.miPastelToolStripMenuItem.Name = "miPastelToolStripMenuItem";
            this.miPastelToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.miPastelToolStripMenuItem.Text = "Pastel ";
            this.miPastelToolStripMenuItem.Click += new System.EventHandler(this.miPastelToolStripMenuItem_Click);
            // 
            // miRomboToolStripMenuItem
            // 
            this.miRomboToolStripMenuItem.Name = "miRomboToolStripMenuItem";
            this.miRomboToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.miRomboToolStripMenuItem.Text = "Rombo";
            this.miRomboToolStripMenuItem.Click += new System.EventHandler(this.miRomboToolStripMenuItem_Click);
            // 
            // miSemicirculoToolStripMenuItem
            // 
            this.miSemicirculoToolStripMenuItem.Name = "miSemicirculoToolStripMenuItem";
            this.miSemicirculoToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.miSemicirculoToolStripMenuItem.Text = "Semicírculo";
            this.miSemicirculoToolStripMenuItem.Click += new System.EventHandler(this.miSemicirculoToolStripMenuItem_Click);
            // 
            // FrmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip2);
            this.IsMdiContainer = true;
            this.Name = "FrmHome";
            this.Text = "FrmHome";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem msFigurasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miCruzToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miCorazonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miCometaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miOctagonoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miPastelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miRomboToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miSemicirculoToolStripMenuItem;
    }
}