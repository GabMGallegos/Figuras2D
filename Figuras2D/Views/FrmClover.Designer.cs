namespace Figuras2D.Views
{
    partial class FrmClover
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
            this.lblMensaje = new System.Windows.Forms.Label();
            this.panelResultados = new System.Windows.Forms.Panel();
            this.lblAreaResult = new System.Windows.Forms.Label();
            this.lblPerimetroResult = new System.Windows.Forms.Label();
            this.lblArea = new System.Windows.Forms.Label();
            this.lblPerimetro = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtRadio = new System.Windows.Forms.TextBox();
            this.lblRadio = new System.Windows.Forms.Label();
            this.panelResultados.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Location = new System.Drawing.Point(97, 350);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(0, 16);
            this.lblMensaje.TabIndex = 18;
            // 
            // panelResultados
            // 
            this.panelResultados.Controls.Add(this.lblAreaResult);
            this.panelResultados.Controls.Add(this.lblPerimetroResult);
            this.panelResultados.Controls.Add(this.lblArea);
            this.panelResultados.Controls.Add(this.lblPerimetro);
            this.panelResultados.Location = new System.Drawing.Point(81, 234);
            this.panelResultados.Margin = new System.Windows.Forms.Padding(4);
            this.panelResultados.Name = "panelResultados";
            this.panelResultados.Size = new System.Drawing.Size(200, 89);
            this.panelResultados.TabIndex = 17;
            // 
            // lblAreaResult
            // 
            this.lblAreaResult.AutoSize = true;
            this.lblAreaResult.Location = new System.Drawing.Point(97, 49);
            this.lblAreaResult.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAreaResult.Name = "lblAreaResult";
            this.lblAreaResult.Size = new System.Drawing.Size(0, 16);
            this.lblAreaResult.TabIndex = 4;
            // 
            // lblPerimetroResult
            // 
            this.lblPerimetroResult.AutoSize = true;
            this.lblPerimetroResult.Location = new System.Drawing.Point(97, 20);
            this.lblPerimetroResult.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPerimetroResult.Name = "lblPerimetroResult";
            this.lblPerimetroResult.Size = new System.Drawing.Size(0, 16);
            this.lblPerimetroResult.TabIndex = 3;
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
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(177, 190);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(65, 23);
            this.btnLimpiar.TabIndex = 16;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnCalcular
            // 
            this.btnCalcular.Location = new System.Drawing.Point(81, 190);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(75, 23);
            this.btnCalcular.TabIndex = 15;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(333, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(386, 354);
            this.panel1.TabIndex = 14;
            // 
            // txtRadio
            // 
            this.txtRadio.Location = new System.Drawing.Point(150, 117);
            this.txtRadio.Name = "txtRadio";
            this.txtRadio.Size = new System.Drawing.Size(61, 22);
            this.txtRadio.TabIndex = 13;
            // 
            // lblRadio
            // 
            this.lblRadio.AutoSize = true;
            this.lblRadio.Location = new System.Drawing.Point(85, 120);
            this.lblRadio.Name = "lblRadio";
            this.lblRadio.Size = new System.Drawing.Size(59, 20);
            this.lblRadio.TabIndex = 12;
            this.lblRadio.Text = "Radio:";
            // 
            // FrmClover
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.panelResultados);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnCalcular);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtRadio);
            this.Controls.Add(this.lblRadio);
            this.Name = "FrmClover";
            this.Text = "FrmClover";
            this.panelResultados.ResumeLayout(false);
            this.panelResultados.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.Panel panelResultados;
        private System.Windows.Forms.Label lblAreaResult;
        private System.Windows.Forms.Label lblPerimetroResult;
        private System.Windows.Forms.Label lblArea;
        private System.Windows.Forms.Label lblPerimetro;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtRadio;
        private System.Windows.Forms.Label lblRadio;
    }
}