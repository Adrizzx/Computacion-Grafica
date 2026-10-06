namespace WinAppProjectU1
{
    partial class Figura2
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
            this.ptbGrafica = new System.Windows.Forms.PictureBox();
            this.lblRadio = new System.Windows.Forms.Label();
            this.txtRadio = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnGraficar = new System.Windows.Forms.Button();
            this.btnResetear = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnTrasladar = new System.Windows.Forms.Button();
            this.btnRotarDer = new System.Windows.Forms.Button();
            this.hScrollBarEscala = new System.Windows.Forms.HScrollBar();
            this.btnRotarIzq = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.ptbGrafica)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ptbGrafica
            // 
            this.ptbGrafica.Location = new System.Drawing.Point(6, 19);
            this.ptbGrafica.Name = "ptbGrafica";
            this.ptbGrafica.Size = new System.Drawing.Size(594, 401);
            this.ptbGrafica.TabIndex = 4;
            this.ptbGrafica.TabStop = false;
            // 
            // lblRadio
            // 
            this.lblRadio.AutoSize = true;
            this.lblRadio.Location = new System.Drawing.Point(19, 22);
            this.lblRadio.Name = "lblRadio";
            this.lblRadio.Size = new System.Drawing.Size(137, 13);
            this.lblRadio.TabIndex = 0;
            this.lblRadio.Text = "Ingrese el radio de la figura:";
            // 
            // txtRadio
            // 
            this.txtRadio.Location = new System.Drawing.Point(29, 52);
            this.txtRadio.Name = "txtRadio";
            this.txtRadio.Size = new System.Drawing.Size(100, 20);
            this.txtRadio.TabIndex = 2;
            this.txtRadio.TextChanged += new System.EventHandler(this.txtRadio_TextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnGraficar);
            this.groupBox3.Controls.Add(this.btnResetear);
            this.groupBox3.Location = new System.Drawing.Point(10, 138);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(168, 71);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Salida";
            // 
            // btnGraficar
            // 
            this.btnGraficar.Location = new System.Drawing.Point(6, 29);
            this.btnGraficar.Name = "btnGraficar";
            this.btnGraficar.Size = new System.Drawing.Size(75, 23);
            this.btnGraficar.TabIndex = 1;
            this.btnGraficar.Text = "Graficar";
            this.btnGraficar.UseVisualStyleBackColor = true;
            this.btnGraficar.Click += new System.EventHandler(this.btnGraficar_Click);
            // 
            // btnResetear
            // 
            this.btnResetear.Location = new System.Drawing.Point(87, 29);
            this.btnResetear.Name = "btnResetear";
            this.btnResetear.Size = new System.Drawing.Size(75, 23);
            this.btnResetear.TabIndex = 3;
            this.btnResetear.Text = "Resetear";
            this.btnResetear.UseVisualStyleBackColor = true;
            this.btnResetear.Click += new System.EventHandler(this.btnResetear_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnTrasladar);
            this.groupBox4.Controls.Add(this.btnRotarDer);
            this.groupBox4.Controls.Add(this.hScrollBarEscala);
            this.groupBox4.Controls.Add(this.btnRotarIzq);
            this.groupBox4.Location = new System.Drawing.Point(10, 225);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(168, 185);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Opciones";
            // 
            // btnTrasladar
            // 
            this.btnTrasladar.Location = new System.Drawing.Point(41, 30);
            this.btnTrasladar.Name = "btnTrasladar";
            this.btnTrasladar.Size = new System.Drawing.Size(75, 23);
            this.btnTrasladar.TabIndex = 6;
            this.btnTrasladar.Text = "Trasladar";
            this.btnTrasladar.UseVisualStyleBackColor = true;
            this.btnTrasladar.Click += new System.EventHandler(this.btnTrasladar_Click);
            // 
            // btnRotarDer
            // 
            this.btnRotarDer.Location = new System.Drawing.Point(33, 112);
            this.btnRotarDer.Name = "btnRotarDer";
            this.btnRotarDer.Size = new System.Drawing.Size(96, 23);
            this.btnRotarDer.TabIndex = 11;
            this.btnRotarDer.Text = "Rotar Derecha";
            this.btnRotarDer.UseVisualStyleBackColor = true;
            this.btnRotarDer.Click += new System.EventHandler(this.btnRotarDer_Click);
            // 
            // hScrollBarEscala
            // 
            this.hScrollBarEscala.Location = new System.Drawing.Point(6, 157);
            this.hScrollBarEscala.Name = "hScrollBarEscala";
            this.hScrollBarEscala.Size = new System.Drawing.Size(150, 14);
            this.hScrollBarEscala.TabIndex = 12;
            this.hScrollBarEscala.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBarEscala_Scroll);
            // 
            // btnRotarIzq
            // 
            this.btnRotarIzq.Location = new System.Drawing.Point(33, 73);
            this.btnRotarIzq.Name = "btnRotarIzq";
            this.btnRotarIzq.Size = new System.Drawing.Size(96, 23);
            this.btnRotarIzq.TabIndex = 10;
            this.btnRotarIzq.Text = "Rotar Izquierda";
            this.btnRotarIzq.UseVisualStyleBackColor = true;
            this.btnRotarIzq.Click += new System.EventHandler(this.btnRotarIzq_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblRadio);
            this.groupBox2.Controls.Add(this.txtRadio);
            this.groupBox2.Location = new System.Drawing.Point(10, 31);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(168, 101);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Entrada";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ptbGrafica);
            this.groupBox1.Location = new System.Drawing.Point(184, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(606, 426);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Grafica";
            // 
            // Figura2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Figura2";
            this.Text = "Figura2";
            ((System.ComponentModel.ISupportInitialize)(this.ptbGrafica)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ptbGrafica;
        private System.Windows.Forms.Label lblRadio;
        private System.Windows.Forms.TextBox txtRadio;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnGraficar;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnTrasladar;
        private System.Windows.Forms.Button btnRotarDer;
        private System.Windows.Forms.HScrollBar hScrollBarEscala;
        private System.Windows.Forms.Button btnRotarIzq;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnResetear;
    }
}