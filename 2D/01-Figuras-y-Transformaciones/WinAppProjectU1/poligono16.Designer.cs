namespace WinAppProjectU1
{
    partial class poligono16
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
            this.btnDibujar = new System.Windows.Forms.Button();
            this.ptbGrafica = new System.Windows.Forms.PictureBox();
            this.txtRadio = new System.Windows.Forms.TextBox();
            this.lblRadio = new System.Windows.Forms.Label();
            this.btnTrasladar = new System.Windows.Forms.Button();
            this.btnRotarIzq = new System.Windows.Forms.Button();
            this.btnRotarDer = new System.Windows.Forms.Button();
            this.hScrollBarEscalar = new System.Windows.Forms.HScrollBar();
            this.btnResetear = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.ptbGrafica)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDibujar
            // 
            this.btnDibujar.Location = new System.Drawing.Point(6, 19);
            this.btnDibujar.Name = "btnDibujar";
            this.btnDibujar.Size = new System.Drawing.Size(75, 23);
            this.btnDibujar.TabIndex = 0;
            this.btnDibujar.Text = "Graficar";
            this.btnDibujar.UseVisualStyleBackColor = true;
            this.btnDibujar.Click += new System.EventHandler(this.btnDibujar_Click);
            // 
            // ptbGrafica
            // 
            this.ptbGrafica.Location = new System.Drawing.Point(6, 19);
            this.ptbGrafica.Name = "ptbGrafica";
            this.ptbGrafica.Size = new System.Drawing.Size(579, 401);
            this.ptbGrafica.TabIndex = 1;
            this.ptbGrafica.TabStop = false;
            this.ptbGrafica.Click += new System.EventHandler(this.ptbGrafica_Click);
            this.ptbGrafica.Paint += new System.Windows.Forms.PaintEventHandler(this.ptbGrafica_Paint);
            // 
            // txtRadio
            // 
            this.txtRadio.Location = new System.Drawing.Point(37, 45);
            this.txtRadio.Name = "txtRadio";
            this.txtRadio.Size = new System.Drawing.Size(100, 20);
            this.txtRadio.TabIndex = 2;
            // 
            // lblRadio
            // 
            this.lblRadio.AutoSize = true;
            this.lblRadio.Location = new System.Drawing.Point(19, 25);
            this.lblRadio.Name = "lblRadio";
            this.lblRadio.Size = new System.Drawing.Size(146, 13);
            this.lblRadio.TabIndex = 3;
            this.lblRadio.Text = "Ingrese el radio para la figura:";
            // 
            // btnTrasladar
            // 
            this.btnTrasladar.Location = new System.Drawing.Point(38, 26);
            this.btnTrasladar.Name = "btnTrasladar";
            this.btnTrasladar.Size = new System.Drawing.Size(90, 23);
            this.btnTrasladar.TabIndex = 4;
            this.btnTrasladar.Text = "Trasladar";
            this.btnTrasladar.UseVisualStyleBackColor = true;
            this.btnTrasladar.Click += new System.EventHandler(this.btnTrasladar_Click);
            // 
            // btnRotarIzq
            // 
            this.btnRotarIzq.Location = new System.Drawing.Point(38, 66);
            this.btnRotarIzq.Name = "btnRotarIzq";
            this.btnRotarIzq.Size = new System.Drawing.Size(91, 23);
            this.btnRotarIzq.TabIndex = 5;
            this.btnRotarIzq.Text = "Rotar izquierda";
            this.btnRotarIzq.UseVisualStyleBackColor = true;
            this.btnRotarIzq.Click += new System.EventHandler(this.btnRotarIzq_Click);
            // 
            // btnRotarDer
            // 
            this.btnRotarDer.Location = new System.Drawing.Point(38, 95);
            this.btnRotarDer.Name = "btnRotarDer";
            this.btnRotarDer.Size = new System.Drawing.Size(90, 23);
            this.btnRotarDer.TabIndex = 6;
            this.btnRotarDer.Text = "Rotar Derecha";
            this.btnRotarDer.UseVisualStyleBackColor = true;
            this.btnRotarDer.Click += new System.EventHandler(this.btnRotarDer_Click);
            // 
            // hScrollBarEscalar
            // 
            this.hScrollBarEscalar.Location = new System.Drawing.Point(8, 148);
            this.hScrollBarEscalar.Name = "hScrollBarEscalar";
            this.hScrollBarEscalar.Size = new System.Drawing.Size(158, 19);
            this.hScrollBarEscalar.TabIndex = 7;
            this.hScrollBarEscalar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBarEscalar_Scroll);
            // 
            // btnResetear
            // 
            this.btnResetear.Location = new System.Drawing.Point(90, 19);
            this.btnResetear.Name = "btnResetear";
            this.btnResetear.Size = new System.Drawing.Size(75, 23);
            this.btnResetear.TabIndex = 8;
            this.btnResetear.Text = "Resetear";
            this.btnResetear.UseVisualStyleBackColor = true;
            this.btnResetear.Click += new System.EventHandler(this.btnResetear_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ptbGrafica);
            this.groupBox1.Location = new System.Drawing.Point(197, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(591, 426);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Grafica";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblRadio);
            this.groupBox2.Controls.Add(this.txtRadio);
            this.groupBox2.Location = new System.Drawing.Point(14, 58);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(177, 89);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Entrada";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnResetear);
            this.groupBox3.Controls.Add(this.btnDibujar);
            this.groupBox3.Location = new System.Drawing.Point(14, 165);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(177, 51);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Salida";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnTrasladar);
            this.groupBox4.Controls.Add(this.hScrollBarEscalar);
            this.groupBox4.Controls.Add(this.btnRotarDer);
            this.groupBox4.Controls.Add(this.btnRotarIzq);
            this.groupBox4.Location = new System.Drawing.Point(12, 232);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(177, 189);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Opciones";
            // 
            // poligono16
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "poligono16";
            this.Text = "poligono16";
            this.Load += new System.EventHandler(this.poligono16_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ptbGrafica)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDibujar;
        private System.Windows.Forms.PictureBox ptbGrafica;
        private System.Windows.Forms.TextBox txtRadio;
        private System.Windows.Forms.Label lblRadio;
        private System.Windows.Forms.Button btnTrasladar;
        private System.Windows.Forms.Button btnRotarIzq;
        private System.Windows.Forms.Button btnRotarDer;
        private System.Windows.Forms.HScrollBar hScrollBarEscalar;
        private System.Windows.Forms.Button btnResetear;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
    }
}