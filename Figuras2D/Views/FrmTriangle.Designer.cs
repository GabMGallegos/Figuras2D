namespace Figuras2D.Views
{
    partial class FrmTriangle
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
            this.panelDatos = new System.Windows.Forms.Panel();
            this.txtLadoC = new System.Windows.Forms.TextBox();
            this.lblLadoC = new System.Windows.Forms.Label();
            this.txtLadoB = new System.Windows.Forms.TextBox();
            this.lblLadoB = new System.Windows.Forms.Label();
            this.txtLadoA = new System.Windows.Forms.TextBox();
            this.lblLadoA = new System.Windows.Forms.Label();
            this.panelBotones = new System.Windows.Forms.Panel();
            this.btnLimpiarCampos = new System.Windows.Forms.Button();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.panelResultados = new System.Windows.Forms.Panel();
            this.lblAreaResultado = new System.Windows.Forms.Label();
            this.lblPerimetroResultado = new System.Windows.Forms.Label();
            this.lblArea = new System.Windows.Forms.Label();
            this.lblPerimetro = new System.Windows.Forms.Label();
            this.panelTriangulo = new System.Windows.Forms.Panel();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.panelDatos.SuspendLayout();
            this.panelBotones.SuspendLayout();
            this.panelResultados.SuspendLayout();
            this.SuspendLayout();

            // panelDatos
            this.panelDatos.Controls.Add(this.txtLadoC);
            this.panelDatos.Controls.Add(this.lblLadoC);
            this.panelDatos.Controls.Add(this.txtLadoB);
            this.panelDatos.Controls.Add(this.lblLadoB);
            this.panelDatos.Controls.Add(this.txtLadoA);
            this.panelDatos.Controls.Add(this.lblLadoA);
            this.panelDatos.Location = new System.Drawing.Point(27, 30);
            this.panelDatos.Name = "panelDatos";
            this.panelDatos.Size = new System.Drawing.Size(200, 120);
            this.panelDatos.TabIndex = 0;

            // lblLadoA
            this.lblLadoA.AutoSize = true;
            this.lblLadoA.Location = new System.Drawing.Point(3, 15);
            this.lblLadoA.Name = "lblLadoA";
            this.lblLadoA.Size = new System.Drawing.Size(47, 13);
            this.lblLadoA.Text = "Lado A:";

            // txtLadoA
            this.txtLadoA.Location = new System.Drawing.Point(80, 12);
            this.txtLadoA.Name = "txtLadoA";
            this.txtLadoA.Size = new System.Drawing.Size(100, 20);
            this.txtLadoA.TabIndex = 1;

            // lblLadoB
            this.lblLadoB.AutoSize = true;
            this.lblLadoB.Location = new System.Drawing.Point(3, 45);
            this.lblLadoB.Name = "lblLadoB";
            this.lblLadoB.Size = new System.Drawing.Size(47, 13);
            this.lblLadoB.Text = "Lado B:";

            // txtLadoB
            this.txtLadoB.Location = new System.Drawing.Point(80, 42);
            this.txtLadoB.Name = "txtLadoB";
            this.txtLadoB.Size = new System.Drawing.Size(100, 20);
            this.txtLadoB.TabIndex = 2;

            // lblLadoC
            this.lblLadoC.AutoSize = true;
            this.lblLadoC.Location = new System.Drawing.Point(3, 75);
            this.lblLadoC.Name = "lblLadoC";
            this.lblLadoC.Size = new System.Drawing.Size(47, 13);
            this.lblLadoC.Text = "Lado C:";

            // txtLadoC
            this.txtLadoC.Location = new System.Drawing.Point(80, 72);
            this.txtLadoC.Name = "txtLadoC";
            this.txtLadoC.Size = new System.Drawing.Size(100, 20);
            this.txtLadoC.TabIndex = 3;

            // panelBotones
            this.panelBotones.Controls.Add(this.btnLimpiarCampos);
            this.panelBotones.Controls.Add(this.btnCalcular);
            this.panelBotones.Location = new System.Drawing.Point(27, 170);
            this.panelBotones.Name = "panelBotones";
            this.panelBotones.Size = new System.Drawing.Size(131, 53);
            this.panelBotones.TabIndex = 1;

            // btnCalcular
            this.btnCalcular.Location = new System.Drawing.Point(12, 3);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(104, 23);
            this.btnCalcular.TabIndex = 0;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = true;

            // btnLimpiarCampos
            this.btnLimpiarCampos.Location = new System.Drawing.Point(12, 30);
            this.btnLimpiarCampos.Name = "btnLimpiarCampos";
            this.btnLimpiarCampos.Size = new System.Drawing.Size(104, 23);
            this.btnLimpiarCampos.TabIndex = 1;
            this.btnLimpiarCampos.Text = "Limpiar Campos";
            this.btnLimpiarCampos.UseVisualStyleBackColor = true;

            // panelResultados
            this.panelResultados.Controls.Add(this.lblAreaResultado);
            this.panelResultados.Controls.Add(this.lblPerimetroResultado);
            this.panelResultados.Controls.Add(this.lblArea);
            this.panelResultados.Controls.Add(this.lblPerimetro);
            this.panelResultados.Location = new System.Drawing.Point(27, 240);
            this.panelResultados.Name = "panelResultados";
            this.panelResultados.Size = new System.Drawing.Size(150, 72);
            this.panelResultados.TabIndex = 2;

            // lblPerimetro
            this.lblPerimetro.AutoSize = true;
            this.lblPerimetro.Location = new System.Drawing.Point(3, 15);
            this.lblPerimetro.Name = "lblPerimetro";
            this.lblPerimetro.Size = new System.Drawing.Size(56, 13);
            this.lblPerimetro.Text = "Perímetro:";

            // lblArea
            this.lblArea.AutoSize = true;
            this.lblArea.Location = new System.Drawing.Point(3, 40);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(32, 13);
            this.lblArea.Text = "Área:";

            // lblPerimetroResultado
            this.lblPerimetroResultado.AutoSize = true;
            this.lblPerimetroResultado.Location = new System.Drawing.Point(73, 15);
            this.lblPerimetroResultado.Name = "lblPerimetroResultado";
            this.lblPerimetroResultado.Size = new System.Drawing.Size(0, 13);

            // lblAreaResultado
            this.lblAreaResultado.AutoSize = true;
            this.lblAreaResultado.Location = new System.Drawing.Point(73, 40);
            this.lblAreaResultado.Name = "lblAreaResultado";
            this.lblAreaResultado.Size = new System.Drawing.Size(0, 13);

            // panelTriangulo
            this.panelTriangulo.BackColor = System.Drawing.Color.White;
            this.panelTriangulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTriangulo.Location = new System.Drawing.Point(280, 30);
            this.panelTriangulo.Name = "panelTriangulo";
            this.panelTriangulo.Size = new System.Drawing.Size(350, 350);
            this.panelTriangulo.TabIndex = 3;

            // lblMensaje
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblMensaje.ForeColor = System.Drawing.Color.Red;
            this.lblMensaje.Location = new System.Drawing.Point(27, 330);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(0, 15);

            // FrmTriangle
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 411);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.panelTriangulo);
            this.Controls.Add(this.panelResultados);
            this.Controls.Add(this.panelBotones);
            this.Controls.Add(this.panelDatos);
            this.Name = "FrmTriangle";
            this.Text = "Triángulo";
            this.panelDatos.ResumeLayout(false);
            this.panelDatos.PerformLayout();
            this.panelBotones.ResumeLayout(false);
            this.panelResultados.ResumeLayout(false);
            this.panelResultados.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Panel panelDatos;
        private System.Windows.Forms.Label lblLadoA;
        private System.Windows.Forms.TextBox txtLadoA;
        private System.Windows.Forms.Label lblLadoC;
        private System.Windows.Forms.TextBox txtLadoC;
        private System.Windows.Forms.Label lblLadoB;
        private System.Windows.Forms.TextBox txtLadoB;
        private System.Windows.Forms.Panel panelBotones;
        private System.Windows.Forms.Button btnLimpiarCampos;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.Panel panelResultados;
        private System.Windows.Forms.Label lblAreaResultado;
        private System.Windows.Forms.Label lblPerimetroResultado;
        private System.Windows.Forms.Label lblArea;
        private System.Windows.Forms.Label lblPerimetro;
        private System.Windows.Forms.Panel panelTriangulo;
        private System.Windows.Forms.Label lblMensaje;
    }
}