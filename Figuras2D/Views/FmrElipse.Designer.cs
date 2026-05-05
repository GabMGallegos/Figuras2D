namespace Figuras2D.Views
{
    partial class FrmElipse
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
            this.panelBotones = new System.Windows.Forms.Panel();
            this.btnLimpiarCampos = new System.Windows.Forms.Button();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.panelResultados = new System.Windows.Forms.Panel();
            this.lblAreaResultado = new System.Windows.Forms.Label();
            this.lblPerimetroResultado = new System.Windows.Forms.Label();
            this.lblArea = new System.Windows.Forms.Label();
            this.lblPerimetro = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtSemiejeMenor = new System.Windows.Forms.TextBox();
            this.lblSemiejeMenor = new System.Windows.Forms.Label();
            this.txtSemiejeMayor = new System.Windows.Forms.TextBox();
            this.lblSemiejeMayor = new System.Windows.Forms.Label();
            this.panelElipse = new System.Windows.Forms.Panel();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.panelBotones.SuspendLayout();
            this.panelResultados.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBotones
            // 
            this.panelBotones.Controls.Add(this.btnLimpiarCampos);
            this.panelBotones.Controls.Add(this.btnCalcular);
            this.panelBotones.Location = new System.Drawing.Point(50, 194);
            this.panelBotones.Name = "panelBotones";
            this.panelBotones.Size = new System.Drawing.Size(175, 65);
            this.panelBotones.TabIndex = 19;
            // 
            // btnLimpiarCampos
            // 
            this.btnLimpiarCampos.Location = new System.Drawing.Point(16, 32);
            this.btnLimpiarCampos.Name = "btnLimpiarCampos";
            this.btnLimpiarCampos.Size = new System.Drawing.Size(138, 23);
            this.btnLimpiarCampos.TabIndex = 1;
            this.btnLimpiarCampos.Text = "Limpiar Campos";
            this.btnLimpiarCampos.UseVisualStyleBackColor = true;
            this.btnLimpiarCampos.Click += new System.EventHandler(this.btnLimpiarCampos_Click);
            // 
            // btnCalcular
            // 
            this.btnCalcular.Location = new System.Drawing.Point(16, 3);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(138, 23);
            this.btnCalcular.TabIndex = 0;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // panelResultados
            // 
            this.panelResultados.Controls.Add(this.lblAreaResultado);
            this.panelResultados.Controls.Add(this.lblPerimetroResultado);
            this.panelResultados.Controls.Add(this.lblArea);
            this.panelResultados.Controls.Add(this.lblPerimetro);
            this.panelResultados.Location = new System.Drawing.Point(50, 307);
            this.panelResultados.Name = "panelResultados";
            this.panelResultados.Size = new System.Drawing.Size(200, 89);
            this.panelResultados.TabIndex = 20;
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
            this.panel1.Controls.Add(this.txtSemiejeMenor);
            this.panel1.Controls.Add(this.lblSemiejeMenor);
            this.panel1.Controls.Add(this.txtSemiejeMayor);
            this.panel1.Controls.Add(this.lblSemiejeMayor);
            this.panel1.Location = new System.Drawing.Point(50, 54);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(227, 108);
            this.panel1.TabIndex = 18;
            // 
            // txtSemiejeMenor
            // 
            this.txtSemiejeMenor.Location = new System.Drawing.Point(120, 56);
            this.txtSemiejeMenor.Name = "txtSemiejeMenor";
            this.txtSemiejeMenor.Size = new System.Drawing.Size(100, 22);
            this.txtSemiejeMenor.TabIndex = 3;
            // 
            // lblSemiejeMenor
            // 
            this.lblSemiejeMenor.AutoSize = true;
            this.lblSemiejeMenor.Location = new System.Drawing.Point(4, 59);
            this.lblSemiejeMenor.Name = "lblSemiejeMenor";
            this.lblSemiejeMenor.Size = new System.Drawing.Size(101, 16);
            this.lblSemiejeMenor.TabIndex = 2;
            this.lblSemiejeMenor.Text = "Semieje menor:";
            // 
            // txtSemiejeMayor
            // 
            this.txtSemiejeMayor.Location = new System.Drawing.Point(120, 18);
            this.txtSemiejeMayor.Name = "txtSemiejeMayor";
            this.txtSemiejeMayor.Size = new System.Drawing.Size(100, 22);
            this.txtSemiejeMayor.TabIndex = 1;
            // 
            // lblSemiejeMayor
            // 
            this.lblSemiejeMayor.AutoSize = true;
            this.lblSemiejeMayor.Location = new System.Drawing.Point(4, 21);
            this.lblSemiejeMayor.Name = "lblSemiejeMayor";
            this.lblSemiejeMayor.Size = new System.Drawing.Size(101, 16);
            this.lblSemiejeMayor.TabIndex = 0;
            this.lblSemiejeMayor.Text = "Semieje mayor:";
            // 
            // panelElipse
            // 
            this.panelElipse.BackColor = System.Drawing.SystemColors.HighlightText;
            this.panelElipse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelElipse.Location = new System.Drawing.Point(365, 54);
            this.panelElipse.Name = "panelElipse";
            this.panelElipse.Size = new System.Drawing.Size(390, 390);
            this.panelElipse.TabIndex = 17;
            this.panelElipse.Paint += new System.Windows.Forms.PaintEventHandler(this.panelElipse_Paint);
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensaje.Location = new System.Drawing.Point(61, 478);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(0, 29);
            this.lblMensaje.TabIndex = 0;
            // 
            // FrmElipse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 554);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.panelBotones);
            this.Controls.Add(this.panelResultados);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelElipse);
            this.Name = "FrmElipse";
            this.Text = "Elipse";
            this.panelBotones.ResumeLayout(false);
            this.panelResultados.ResumeLayout(false);
            this.panelResultados.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Panel panelBotones;
        private System.Windows.Forms.Button btnLimpiarCampos;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.Panel panelResultados;
        private System.Windows.Forms.Label lblAreaResultado;
        private System.Windows.Forms.Label lblPerimetroResultado;
        private System.Windows.Forms.Label lblArea;
        private System.Windows.Forms.Label lblPerimetro;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtSemiejeMenor;
        private System.Windows.Forms.Label lblSemiejeMenor;
        private System.Windows.Forms.TextBox txtSemiejeMayor;
        private System.Windows.Forms.Label lblSemiejeMayor;
        private System.Windows.Forms.Panel panelElipse;
        private System.Windows.Forms.Label lblMensaje;
    }
}