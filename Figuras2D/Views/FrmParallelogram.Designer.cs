namespace Figuras2D
{
    partial class FrmParallelogram
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnLimpiarCampos = new System.Windows.Forms.Button();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblAreaResultado = new System.Windows.Forms.Label();
            this.lblPerimetroResultado = new System.Windows.Forms.Label();
            this.lblArea = new System.Windows.Forms.Label();
            this.lblPerimetro = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtAngulo = new System.Windows.Forms.TextBox();
            this.lblAngulo = new System.Windows.Forms.Label();
            this.txtLado = new System.Windows.Forms.TextBox();
            this.lblLado = new System.Windows.Forms.Label();
            this.txtBase = new System.Windows.Forms.TextBox();
            this.lblBase = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnLimpiarCampos);
            this.panel4.Controls.Add(this.btnCalcular);
            this.panel4.Location = new System.Drawing.Point(23, 220);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(175, 65);
            this.panel4.TabIndex = 11;
            // 
            // btnLimpiarCampos
            // 
            this.btnLimpiarCampos.Location = new System.Drawing.Point(16, 32);
            this.btnLimpiarCampos.Name = "btnLimpiarCampos";
            this.btnLimpiarCampos.Size = new System.Drawing.Size(138, 23);
            this.btnLimpiarCampos.TabIndex = 1;
            this.btnLimpiarCampos.Text = "Limpiar Campos";
            this.btnLimpiarCampos.UseVisualStyleBackColor = true;
            // 
            // btnCalcular
            // 
            this.btnCalcular.Location = new System.Drawing.Point(16, 3);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(138, 23);
            this.btnCalcular.TabIndex = 0;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblAreaResultado);
            this.panel3.Controls.Add(this.lblPerimetroResultado);
            this.panel3.Controls.Add(this.lblArea);
            this.panel3.Controls.Add(this.lblPerimetro);
            this.panel3.Location = new System.Drawing.Point(23, 330);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 89);
            this.panel3.TabIndex = 12;
            // 
            // lblAreaResultado
            // 
            this.lblAreaResultado.AutoSize = true;
            this.lblAreaResultado.Location = new System.Drawing.Point(97, 49);
            this.lblAreaResultado.Name = "lblAreaResultado";
            this.lblAreaResultado.Size = new System.Drawing.Size(0, 16);
            this.lblAreaResultado.TabIndex = 4;
            // 
            // lblPerimetroResultado
            // 
            this.lblPerimetroResultado.AutoSize = true;
            this.lblPerimetroResultado.Location = new System.Drawing.Point(97, 20);
            this.lblPerimetroResultado.Name = "lblPerimetroResultado";
            this.lblPerimetroResultado.Size = new System.Drawing.Size(0, 16);
            this.lblPerimetroResultado.TabIndex = 3;
            // 
            // lblArea
            // 
            this.lblArea.AutoSize = true;
            this.lblArea.Location = new System.Drawing.Point(4, 49);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(39, 16);
            this.lblArea.TabIndex = 2;
            this.lblArea.Text = "Área:";
            // 
            // lblPerimetro
            // 
            this.lblPerimetro.AutoSize = true;
            this.lblPerimetro.Location = new System.Drawing.Point(4, 21);
            this.lblPerimetro.Name = "lblPerimetro";
            this.lblPerimetro.Size = new System.Drawing.Size(68, 16);
            this.lblPerimetro.TabIndex = 0;
            this.lblPerimetro.Text = "Perímetro:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtAngulo);
            this.panel1.Controls.Add(this.lblAngulo);
            this.panel1.Controls.Add(this.txtLado);
            this.panel1.Controls.Add(this.lblLado);
            this.panel1.Controls.Add(this.txtBase);
            this.panel1.Controls.Add(this.lblBase);
            this.panel1.Location = new System.Drawing.Point(23, 54);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(227, 120);
            this.panel1.TabIndex = 10;
            // 
            // txtAngulo
            // 
            this.txtAngulo.Location = new System.Drawing.Point(80, 80);
            this.txtAngulo.Name = "txtAngulo";
            this.txtAngulo.Size = new System.Drawing.Size(100, 22);
            this.txtAngulo.TabIndex = 5;
            // 
            // lblAngulo
            // 
            this.lblAngulo.AutoSize = true;
            this.lblAngulo.Location = new System.Drawing.Point(4, 83);
            this.lblAngulo.Name = "lblAngulo";
            this.lblAngulo.Size = new System.Drawing.Size(70, 16);
            this.lblAngulo.TabIndex = 4;
            this.lblAngulo.Text = "Ángulo (°):";
            // 
            // txtLado
            // 
            this.txtLado.Location = new System.Drawing.Point(80, 49);
            this.txtLado.Name = "txtLado";
            this.txtLado.Size = new System.Drawing.Size(100, 22);
            this.txtLado.TabIndex = 3;
            // 
            // lblLado
            // 
            this.lblLado.AutoSize = true;
            this.lblLado.Location = new System.Drawing.Point(4, 52);
            this.lblLado.Name = "lblLado";
            this.lblLado.Size = new System.Drawing.Size(38, 16);
            this.lblLado.TabIndex = 2;
            this.lblLado.Text = "Lado:";
            // 
            // txtBase
            // 
            this.txtBase.Location = new System.Drawing.Point(80, 18);
            this.txtBase.Name = "txtBase";
            this.txtBase.Size = new System.Drawing.Size(100, 22);
            this.txtBase.TabIndex = 1;
            // 
            // lblBase
            // 
            this.lblBase.AutoSize = true;
            this.lblBase.Location = new System.Drawing.Point(4, 21);
            this.lblBase.Name = "lblBase";
            this.lblBase.Size = new System.Drawing.Size(40, 16);
            this.lblBase.TabIndex = 0;
            this.lblBase.Text = "Base:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblMensaje);
            this.panel2.Location = new System.Drawing.Point(338, 54);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(390, 390);
            this.panel2.TabIndex = 9;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensaje.Location = new System.Drawing.Point(16, 22);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(0, 29);
            this.lblMensaje.TabIndex = 0;
            // 
            // FrmParallelogram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 554);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "FrmParallelogram";
            this.Text = "Paralelogramo";
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnLimpiarCampos;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblAreaResultado;
        private System.Windows.Forms.Label lblPerimetroResultado;
        private System.Windows.Forms.Label lblArea;
        private System.Windows.Forms.Label lblPerimetro;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtAngulo;
        private System.Windows.Forms.Label lblAngulo;
        private System.Windows.Forms.TextBox txtLado;
        private System.Windows.Forms.Label lblLado;
        private System.Windows.Forms.TextBox txtBase;
        private System.Windows.Forms.Label lblBase;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblMensaje;
    }
}