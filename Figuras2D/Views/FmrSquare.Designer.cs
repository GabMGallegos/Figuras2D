namespace Figuras2D.Views
{
    partial class FmrSquare
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtLado = new System.Windows.Forms.TextBox();
            this.lblLongitudTotal = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnLimpiarCampos = new System.Windows.Forms.Button();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblAreaResultado = new System.Windows.Forms.Label();
            this.lblPerimetroResultado = new System.Windows.Forms.Label();
            this.lblArea = new System.Windows.Forms.Label();
            this.lblPerimetro = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.trackBarSquare = new System.Windows.Forms.TrackBar();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSquare)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtLado);
            this.panel1.Controls.Add(this.lblLongitudTotal);
            this.panel1.Location = new System.Drawing.Point(36, 74);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(261, 66);
            this.panel1.TabIndex = 7;
            // 
            // txtLado
            // 
            this.txtLado.Location = new System.Drawing.Point(101, 17);
            this.txtLado.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtLado.Name = "txtLado";
            this.txtLado.Size = new System.Drawing.Size(132, 22);
            this.txtLado.TabIndex = 1;
            // 
            // lblLongitudTotal
            // 
            this.lblLongitudTotal.AutoSize = true;
            this.lblLongitudTotal.Location = new System.Drawing.Point(4, 21);
            this.lblLongitudTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLongitudTotal.Name = "lblLongitudTotal";
            this.lblLongitudTotal.Size = new System.Drawing.Size(52, 16);
            this.lblLongitudTotal.TabIndex = 0;
            this.lblLongitudTotal.Text = "Lado(l):";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnLimpiarCampos);
            this.panel4.Controls.Add(this.btnCalcular);
            this.panel4.Location = new System.Drawing.Point(36, 207);
            this.panel4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(175, 65);
            this.panel4.TabIndex = 8;
            // 
            // btnLimpiarCampos
            // 
            this.btnLimpiarCampos.Location = new System.Drawing.Point(16, 32);
            this.btnLimpiarCampos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLimpiarCampos.Name = "btnLimpiarCampos";
            this.btnLimpiarCampos.Size = new System.Drawing.Size(139, 23);
            this.btnLimpiarCampos.TabIndex = 1;
            this.btnLimpiarCampos.Text = "Limpiar Campos";
            this.btnLimpiarCampos.UseVisualStyleBackColor = true;
            this.btnLimpiarCampos.Click += new System.EventHandler(this.btnLimpiarCampos_Click);
            // 
            // btnCalcular
            // 
            this.btnCalcular.Location = new System.Drawing.Point(16, 2);
            this.btnCalcular.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(139, 23);
            this.btnCalcular.TabIndex = 0;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblAreaResultado);
            this.panel3.Controls.Add(this.lblPerimetroResultado);
            this.panel3.Controls.Add(this.lblArea);
            this.panel3.Controls.Add(this.lblPerimetro);
            this.panel3.Location = new System.Drawing.Point(36, 327);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 89);
            this.panel3.TabIndex = 9;
            // 
            // lblAreaResultado
            // 
            this.lblAreaResultado.AutoSize = true;
            this.lblAreaResultado.Location = new System.Drawing.Point(97, 49);
            this.lblAreaResultado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAreaResultado.Name = "lblAreaResultado";
            this.lblAreaResultado.Size = new System.Drawing.Size(0, 16);
            this.lblAreaResultado.TabIndex = 4;
            // 
            // lblPerimetroResultado
            // 
            this.lblPerimetroResultado.AutoSize = true;
            this.lblPerimetroResultado.Location = new System.Drawing.Point(97, 20);
            this.lblPerimetroResultado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPerimetroResultado.Name = "lblPerimetroResultado";
            this.lblPerimetroResultado.Size = new System.Drawing.Size(0, 16);
            this.lblPerimetroResultado.TabIndex = 3;
            // 
            // lblArea
            // 
            this.lblArea.AutoSize = true;
            this.lblArea.Location = new System.Drawing.Point(4, 49);
            this.lblArea.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(39, 16);
            this.lblArea.TabIndex = 2;
            this.lblArea.Text = "Área:";
            // 
            // lblPerimetro
            // 
            this.lblPerimetro.AutoSize = true;
            this.lblPerimetro.Location = new System.Drawing.Point(4, 21);
            this.lblPerimetro.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPerimetro.Name = "lblPerimetro";
            this.lblPerimetro.Size = new System.Drawing.Size(68, 16);
            this.lblPerimetro.TabIndex = 0;
            this.lblPerimetro.Text = "Perímetro:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblMensaje);
            this.panel2.Location = new System.Drawing.Point(424, 74);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(385, 342);
            this.panel2.TabIndex = 10;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold);
            this.lblMensaje.Location = new System.Drawing.Point(16, 22);
            this.lblMensaje.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(0, 29);
            this.lblMensaje.TabIndex = 0;
            // 
            // trackBarSquare
            // 
            this.trackBarSquare.Location = new System.Drawing.Point(36, 146);
            this.trackBarSquare.Name = "trackBarSquare";
            this.trackBarSquare.Size = new System.Drawing.Size(104, 56);
            this.trackBarSquare.TabIndex = 11;
            this.trackBarSquare.Scroll += new System.EventHandler(this.trackBarSquare_Scroll);
            // 
            // FmrSquare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 453);
            this.Controls.Add(this.trackBarSquare);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FmrSquare";
            this.Text = "Cuadrado";
            this.Load += new System.EventHandler(this.FmrSquare_Load);
            this.Resize += new System.EventHandler(this.FmrSquare_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSquare)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblLongitudTotal;
        private System.Windows.Forms.TextBox txtLado;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnLimpiarCampos;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblAreaResultado;
        private System.Windows.Forms.Label lblPerimetroResultado;
        private System.Windows.Forms.Label lblArea;
        private System.Windows.Forms.Label lblPerimetro;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.TrackBar trackBarSquare;
    }
}