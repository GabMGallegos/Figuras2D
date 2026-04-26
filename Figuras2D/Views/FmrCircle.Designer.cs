namespace Figuras2D.Views
{
    partial class FmrCircle
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
            this.lblRadio = new System.Windows.Forms.Label();
            this.txtRadio = new System.Windows.Forms.TextBox();
            this.panelBotones = new System.Windows.Forms.Panel();
            this.btnLimpiarCampos = new System.Windows.Forms.Button();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.panelResultados = new System.Windows.Forms.Panel();
            this.lblAreaResultado = new System.Windows.Forms.Label();
            this.lblPerimetroResultado = new System.Windows.Forms.Label();
            this.lblArea = new System.Windows.Forms.Label();
            this.lblPerimetro = new System.Windows.Forms.Label();
            this.panelCirculo = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panelBotones.SuspendLayout();
            this.panelResultados.SuspendLayout();
            this.SuspendLayout();

            // panel1
            this.panel1.Controls.Add(this.txtRadio);
            this.panel1.Controls.Add(this.lblRadio);
            this.panel1.Location = new System.Drawing.Point(27, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(196, 54);
            this.panel1.TabIndex = 7;

            // lblRadio
            this.lblRadio.AutoSize = true;
            this.lblRadio.Location = new System.Drawing.Point(3, 17);
            this.lblRadio.Name = "lblRadio";
            this.lblRadio.Size = new System.Drawing.Size(43, 13);
            this.lblRadio.TabIndex = 0;
            this.lblRadio.Text = "Radio(r):";

            // txtRadio
            this.txtRadio.Location = new System.Drawing.Point(76, 14);
            this.txtRadio.Name = "txtRadio";
            this.txtRadio.Size = new System.Drawing.Size(100, 20);
            this.txtRadio.TabIndex = 1;

            // panelBotones
            this.panelBotones.Controls.Add(this.btnLimpiarCampos);
            this.panelBotones.Controls.Add(this.btnCalcular);
            this.panelBotones.Location = new System.Drawing.Point(27, 168);
            this.panelBotones.Name = "panelBotones";
            this.panelBotones.Size = new System.Drawing.Size(131, 53);
            this.panelBotones.TabIndex = 8;

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

            // panelResultados
            this.panelResultados.Controls.Add(this.lblAreaResultado);
            this.panelResultados.Controls.Add(this.lblPerimetroResultado);
            this.panelResultados.Controls.Add(this.lblArea);
            this.panelResultados.Controls.Add(this.lblPerimetro);
            this.panelResultados.Location = new System.Drawing.Point(27, 266);
            this.panelResultados.Name = "panelResultados";
            this.panelResultados.Size = new System.Drawing.Size(150, 72);
            this.panelResultados.TabIndex = 9;

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

            // panelCirculo
            this.panelCirculo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.panelCirculo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCirculo.Location = new System.Drawing.Point(318, 60);
            this.panelCirculo.Name = "panelCirculo";
            this.panelCirculo.Size = new System.Drawing.Size(289, 278);
            this.panelCirculo.TabIndex = 10;
            this.panelCirculo.Paint += new System.Windows.Forms.PaintEventHandler(this.panelCirculo_Paint);

            // FmrCircle
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 368);
            this.Controls.Add(this.panelCirculo);
            this.Controls.Add(this.panelResultados);
            this.Controls.Add(this.panelBotones);
            this.Controls.Add(this.panel1);
            this.Name = "FmrCircle";
            this.Text = "Círculo";
            this.Load += new System.EventHandler(this.FmrCircle_Load);
            this.Resize += new System.EventHandler(this.FmrCircle_Resize);

            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelBotones.ResumeLayout(false);
            this.panelResultados.ResumeLayout(false);
            this.panelResultados.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblRadio;
        private System.Windows.Forms.TextBox txtRadio;
        private System.Windows.Forms.Panel panelBotones;
        private System.Windows.Forms.Button btnLimpiarCampos;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.Panel panelResultados;
        private System.Windows.Forms.Label lblAreaResultado;
        private System.Windows.Forms.Label lblPerimetroResultado;
        private System.Windows.Forms.Label lblArea;
        private System.Windows.Forms.Label lblPerimetro;
        private System.Windows.Forms.Panel panelCirculo;
    }
}