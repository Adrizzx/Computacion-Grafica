namespace WinAppTodosAlgoritmos
{
    partial class Drawer
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.canvas = new System.Windows.Forms.PictureBox();
            this.panelControles = new System.Windows.Forms.Panel();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lstPixeles = new System.Windows.Forms.ListBox();
            this.lblLista = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.lblColor = new System.Windows.Forms.Label();
            this.pnlColorMuestra = new System.Windows.Forms.Panel();
            this.btnColor = new System.Windows.Forms.Button();
            this.groupBoxModos = new System.Windows.Forms.GroupBox();
            this.rbRellenar = new System.Windows.Forms.RadioButton();
            this.rbDibujar = new System.Windows.Forms.RadioButton();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.panelControles.SuspendLayout();
            this.groupBoxModos.SuspendLayout();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.canvas.BackColor = System.Drawing.Color.White;
            this.canvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.canvas.Location = new System.Drawing.Point(12, 12);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(560, 426);
            this.canvas.TabIndex = 0;
            this.canvas.TabStop = false;
            this.canvas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseClick);
            // 
            // panelControles
            // 
            this.panelControles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControles.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelControles.Controls.Add(this.lblEstado);
            this.panelControles.Controls.Add(this.lstPixeles);
            this.panelControles.Controls.Add(this.lblLista);
            this.panelControles.Controls.Add(this.btnLimpiar);
            this.panelControles.Controls.Add(this.lblColor);
            this.panelControles.Controls.Add(this.pnlColorMuestra);
            this.panelControles.Controls.Add(this.btnColor);
            this.panelControles.Controls.Add(this.groupBoxModos);
            this.panelControles.Location = new System.Drawing.Point(578, 12);
            this.panelControles.Name = "panelControles";
            this.panelControles.Size = new System.Drawing.Size(210, 426);
            this.panelControles.TabIndex = 1;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.ForeColor = System.Drawing.Color.Blue;
            this.lblEstado.Location = new System.Drawing.Point(14, 396);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(35, 13);
            this.lblEstado.TabIndex = 7;
            this.lblEstado.Text = "Listo.";
            // 
            // lstPixeles
            // 
            this.lstPixeles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstPixeles.FormattingEnabled = true;
            this.lstPixeles.Location = new System.Drawing.Point(14, 230);
            this.lstPixeles.Name = "lstPixeles";
            this.lstPixeles.Size = new System.Drawing.Size(182, 173);
            this.lstPixeles.TabIndex = 6;
            // 
            // lblLista
            // 
            this.lblLista.AutoSize = true;
            this.lblLista.Location = new System.Drawing.Point(11, 214);
            this.lblLista.Name = "lblLista";
            this.lblLista.Size = new System.Drawing.Size(91, 13);
            this.lblLista.TabIndex = 5;
            this.lblLista.Text = "Píxeles Pintados:";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(14, 170);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(182, 30);
            this.btnLimpiar.TabIndex = 4;
            this.btnLimpiar.Text = "Limpiar Todo";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Location = new System.Drawing.Point(11, 110);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(75, 13);
            this.lblColor.TabIndex = 3;
            this.lblColor.Text = "Color Relleno:";
            // 
            // pnlColorMuestra
            // 
            this.pnlColorMuestra.BackColor = System.Drawing.Color.DodgerBlue;
            this.pnlColorMuestra.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlColorMuestra.Location = new System.Drawing.Point(14, 126);
            this.pnlColorMuestra.Name = "pnlColorMuestra";
            this.pnlColorMuestra.Size = new System.Drawing.Size(30, 30);
            this.pnlColorMuestra.TabIndex = 2;
            // 
            // btnColor
            // 
            this.btnColor.Location = new System.Drawing.Point(50, 126);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(146, 30);
            this.btnColor.TabIndex = 1;
            this.btnColor.Text = "Seleccionar Color";
            this.btnColor.UseVisualStyleBackColor = true;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // groupBoxModos
            // 
            this.groupBoxModos.Controls.Add(this.rbRellenar);
            this.groupBoxModos.Controls.Add(this.rbDibujar);
            this.groupBoxModos.Location = new System.Drawing.Point(14, 14);
            this.groupBoxModos.Name = "groupBoxModos";
            this.groupBoxModos.Size = new System.Drawing.Size(182, 85);
            this.groupBoxModos.TabIndex = 0;
            this.groupBoxModos.TabStop = false;
            this.groupBoxModos.Text = "Modo";
            // 
            // rbRellenar
            // 
            this.rbRellenar.AutoSize = true;
            this.rbRellenar.Location = new System.Drawing.Point(16, 51);
            this.rbRellenar.Name = "rbRellenar";
            this.rbRellenar.Size = new System.Drawing.Size(107, 17);
            this.rbRellenar.TabIndex = 1;
            this.rbRellenar.Text = "Rellenar Figuras";
            this.rbRellenar.UseVisualStyleBackColor = true;
            this.rbRellenar.CheckedChanged += new System.EventHandler(this.rbRellenar_CheckedChanged);
            // 
            // rbDibujar
            // 
            this.rbDibujar.AutoSize = true;
            this.rbDibujar.Checked = true;
            this.rbDibujar.Location = new System.Drawing.Point(16, 28);
            this.rbDibujar.Name = "rbDibujar";
            this.rbDibujar.Size = new System.Drawing.Size(130, 17);
            this.rbDibujar.TabIndex = 0;
            this.rbDibujar.TabStop = true;
            this.rbDibujar.Text = "Dibujar Líneas (Click)";
            this.rbDibujar.UseVisualStyleBackColor = true;
            this.rbDibujar.CheckedChanged += new System.EventHandler(this.rbDibujar_CheckedChanged);
            // 
            // Drawer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelControles);
            this.Controls.Add(this.canvas);
            this.Name = "Drawer";
            this.Text = "Dibujar y Rellenar Figuras";
            this.Load += new System.EventHandler(this.Drawer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.panelControles.ResumeLayout(false);
            this.panelControles.PerformLayout();
            this.groupBoxModos.ResumeLayout(false);
            this.groupBoxModos.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.Panel panelControles;
        private System.Windows.Forms.GroupBox groupBoxModos;
        private System.Windows.Forms.RadioButton rbRellenar;
        private System.Windows.Forms.RadioButton rbDibujar;
        private System.Windows.Forms.Panel pnlColorMuestra;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.ListBox lstPixeles;
        private System.Windows.Forms.Label lblLista;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label lblEstado;
    }
}