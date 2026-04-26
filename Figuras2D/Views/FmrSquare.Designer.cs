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
            this.lblLongitudTotal = new System.Windows.Forms.Label();
            this.txtLado = new System.Windows.Forms.TextBox();
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
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();

            // panel1
            this.panel1.Controls.Add(this.txtLado);
            this.panel1.Controls.Add(this.lblLongitudTotal);
            this.panel1.Location = new System.Drawing.Point(27, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(196, 54);
            this.panel1.TabIndex = 7;

            // lblLongitudTotal
            this.lblLongitudTotal.AutoSize = true;
            this.lblLongitudTotal.Location = new System.Drawing.Point(3, 17);
            this.lblLongitudTotal.Name = "lblLongitudTotal";
            this.lblLongitudTotal.Size = new System.Drawing.Size(42, 13);
            this.lblLongitudTotal.TabIndex = 0;
            this.lblLongitudTotal.Text = "Lado(l):";

            // txtLado
            this.txtLado.Location = new System.Drawing.Point(76, 14);
            this.txtLado.Name = "txtLado";
            this.txtLado.Size = new System.Drawing.Size(100, 20);
            this.txtLado.TabIndex = 1;

            // panel4
            this.panel4.Controls.Add(this.btnLimpiarCampos);
            this.panel4.Controls.Add(this.btnCalcular);
            this.panel4.Location = new System.Drawing.Point(27, 168);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(131, 53);
            this.panel4.TabIndex = 8;

            // btnLimpiarCampos
            this.btnLimpiarCampos.Location = new System.Drawing.Point(12, 26);
            this.btnLimpiarCampos.Name = "btnLimpiarCampos";
            this.btnLimpiarCampos.Size = new System.Drawing.Size(104, 19);
            this.btnLimpiarCampos.TabIndex = 1;
            this.btnLimpiarCampos.Text = "Limpiar Campos";
            this.btnLimpiarCampos.UseVisualStyleBackColor = true;
            this.btnLimpiarCampos.Click += new System.EventHandler(this.btnLimpiarCampos_Click);

            // btnCalcular
            this.btnCalcular.Location = new System.Drawing.Point(12, 2);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(104, 19);
            this.btnCalcular.TabIndex = 0;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);

            // panel3
            this.panel3.Controls.Add(this.lblAreaResultado);
            this.panel3.Controls.Add(this.lblPerimetroResultado);
            this.panel3.Controls.Add(this.lblArea);
            this.panel3.Controls.Add(this.lblPerimetro);
            this.panel3.Location = new System.Drawing.Point(27, 266);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(150, 72);
            this.panel3.TabIndex = 9;

            // lblAreaResultado
            this.lblAreaResultado.AutoSize = true;
            this.lblAreaResultado.Location = new System.Drawing.Point(73, 40);
            this.lblAreaResultado.Name = "lblAreaResultado";
            this.lblAreaResultado.Size = new System.Drawing.Size(0, 13);
            this.lblAreaResultado.TabIndex = 4;

            // lblPerimetroResultado
            this.lblPerimetroResultado.AutoSize = true;
            this.lblPerimetroResultado.Location = new System.Drawing.Point(73, 16);
            this.lblPerimetroResultado.Name = "lblPerimetroResultado";
            this.lblPerimetroResultado.Size = new System.Drawing.Size(0, 13);
            this.lblPerimetroResultado.TabIndex = 3;

            // lblArea
            this.lblArea.AutoSize = true;
            this.lblArea.Location = new System.Drawing.Point(3, 40);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(32, 13);
            this.lblArea.TabIndex = 2;
            this.lblArea.Text = "Área:";

            // lblPerimetro
            this.lblPerimetro.AutoSize = true;
            this.lblPerimetro.Location = new System.Drawing.Point(3, 17);
            this.lblPerimetro.Name = "lblPerimetro";
            this.lblPerimetro.Size = new System.Drawing.Size(56, 13);
            this.lblPerimetro.TabIndex = 0;
            this.lblPerimetro.Text = "Perímetro:";

            // panel2
            this.panel2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblMensaje);
            this.panel2.Location = new System.Drawing.Point(318, 60);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(289, 278);
            this.panel2.TabIndex = 10;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);

            // lblMensaje
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold);
            this.lblMensaje.Location = new System.Drawing.Point(12, 18);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(0, 24);
            this.lblMensaje.TabIndex = 0;

            // FmrSquare
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 368);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
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
            this.ResumeLayout(false);
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
    }
}