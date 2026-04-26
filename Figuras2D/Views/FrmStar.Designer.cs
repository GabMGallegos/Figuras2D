namespace Figuras2D
{
    partial class FrmStar
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
            this.txtPuntas = new System.Windows.Forms.TextBox();
            this.lblPuntas = new System.Windows.Forms.Label();
            this.txtRadioInterno = new System.Windows.Forms.TextBox();
            this.lblRadioInterno = new System.Windows.Forms.Label();
            this.txtRadioExterno = new System.Windows.Forms.TextBox();
            this.lblRadioExterno = new System.Windows.Forms.Label();
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
            this.panel4.Location = new System.Drawing.Point(23, 234);
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
            this.panel3.Location = new System.Drawing.Point(23, 347);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 89);
            this.panel3.TabIndex = 12;
            // 
            // lblAreaResultado
            // 
            this.lblAreaResultado.AutoSize = true;
            this.lblAreaResultado.Location = new System.Drawing.Point(120, 49);
            this.lblAreaResultado.Name = "lblAreaResultado";
            this.lblAreaResultado.Size = new System.Drawing.Size(0, 16);
            this.lblAreaResultado.TabIndex = 4;
            // 
            // lblPerimetroResultado
            // 
            this.lblPerimetroResultado.AutoSize = true;
            this.lblPerimetroResultado.Location = new System.Drawing.Point(120, 20);
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
            this.panel1.Controls.Add(this.txtPuntas);
            this.panel1.Controls.Add(this.lblPuntas);
            this.panel1.Controls.Add(this.txtRadioInterno);
            this.panel1.Controls.Add(this.lblRadioInterno);
            this.panel1.Controls.Add(this.txtRadioExterno);
            this.panel1.Controls.Add(this.lblRadioExterno);
            this.panel1.Location = new System.Drawing.Point(23, 54);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(227, 120);
            this.panel1.TabIndex = 10;
            // 
            // txtPuntas
            // 
            this.txtPuntas.Location = new System.Drawing.Point(110, 80);
            this.txtPuntas.Name = "txtPuntas";
            this.txtPuntas.Size = new System.Drawing.Size(100, 22);
            this.txtPuntas.TabIndex = 5;
            // 
            // lblPuntas
            // 
            this.lblPuntas.AutoSize = true;
            this.lblPuntas.Location = new System.Drawing.Point(4, 83);
            this.lblPuntas.Name = "lblPuntas";
            this.lblPuntas.Size = new System.Drawing.Size(50, 16);
            this.lblPuntas.TabIndex = 4;
            this.lblPuntas.Text = "Puntas:";
            // 
            // txtRadioInterno
            // 
            this.txtRadioInterno.Location = new System.Drawing.Point(110, 49);
            this.txtRadioInterno.Name = "txtRadioInterno";
            this.txtRadioInterno.Size = new System.Drawing.Size(100, 22);
            this.txtRadioInterno.TabIndex = 3;
            // 
            // lblRadioInterno
            // 
            this.lblRadioInterno.AutoSize = true;
            this.lblRadioInterno.Location = new System.Drawing.Point(4, 52);
            this.lblRadioInterno.Name = "lblRadioInterno";
            this.lblRadioInterno.Size = new System.Drawing.Size(88, 16);
            this.lblRadioInterno.TabIndex = 2;
            this.lblRadioInterno.Text = "Radio Interno:";
            // 
            // txtRadioExterno
            // 
            this.txtRadioExterno.Location = new System.Drawing.Point(110, 18);
            this.txtRadioExterno.Name = "txtRadioExterno";
            this.txtRadioExterno.Size = new System.Drawing.Size(100, 22);
            this.txtRadioExterno.TabIndex = 1;
            // 
            // lblRadioExterno
            // 
            this.lblRadioExterno.AutoSize = true;
            this.lblRadioExterno.Location = new System.Drawing.Point(4, 21);
            this.lblRadioExterno.Name = "lblRadioExterno";
            this.lblRadioExterno.Size = new System.Drawing.Size(95, 16);
            this.lblRadioExterno.TabIndex = 0;
            this.lblRadioExterno.Text = "Radio Externo:";
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
            // FrmStar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 554);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "FrmStar";
            this.Text = "Estrella";
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
        private System.Windows.Forms.TextBox txtPuntas;
        private System.Windows.Forms.Label lblPuntas;
        private System.Windows.Forms.TextBox txtRadioInterno;
        private System.Windows.Forms.Label lblRadioInterno;
        private System.Windows.Forms.TextBox txtRadioExterno;
        private System.Windows.Forms.Label lblRadioExterno;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblMensaje;
    }
}