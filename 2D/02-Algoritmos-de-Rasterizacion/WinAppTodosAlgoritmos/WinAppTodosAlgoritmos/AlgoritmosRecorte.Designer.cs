namespace WinAppTodosAlgoritmos
{
    partial class AlgoritmosRecorte
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlControles = new System.Windows.Forms.Panel();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnRecortar = new System.Windows.Forms.Button();
            this.cmbAlgoritmo = new System.Windows.Forms.ComboBox();
            this.lblAlgoritmo = new System.Windows.Forms.Label();
            this.grpModo = new System.Windows.Forms.GroupBox();
            this.rbPoligono = new System.Windows.Forms.RadioButton();
            this.rbLinea = new System.Windows.Forms.RadioButton();
            this.ptbCanvas = new System.Windows.Forms.PictureBox();
            this.pnlControles.SuspendLayout();
            this.grpModo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlControles
            // 
            this.pnlControles.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlControles.Controls.Add(this.lblInfo);
            this.pnlControles.Controls.Add(this.btnLimpiar);
            this.pnlControles.Controls.Add(this.btnRecortar);
            this.pnlControles.Controls.Add(this.cmbAlgoritmo);
            this.pnlControles.Controls.Add(this.lblAlgoritmo);
            this.pnlControles.Controls.Add(this.grpModo);
            this.pnlControles.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlControles.Location = new System.Drawing.Point(0, 0);
            this.pnlControles.Name = "pnlControles";
            this.pnlControles.Size = new System.Drawing.Size(240, 500);
            this.pnlControles.TabIndex = 0;
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfo.BackColor = System.Drawing.Color.White;
            this.lblInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblInfo.Location = new System.Drawing.Point(12, 260);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Padding = new System.Windows.Forms.Padding(5);
            this.lblInfo.Size = new System.Drawing.Size(216, 220);
            this.lblInfo.TabIndex = 5;
            this.lblInfo.Text = "Instrucciones:\r\n1. Seleccione Modo (Línea o Polígono).\r\n2. Haga clic en el área b" +
    "lanca para definir puntos.\r\n3. Presione \'Aplicar Recorte\' para ver el resultado.";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(12, 220);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(216, 30);
            this.btnLimpiar.TabIndex = 4;
            this.btnLimpiar.Text = "Limpiar / Reiniciar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnRecortar
            // 
            this.btnRecortar.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnRecortar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecortar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecortar.ForeColor = System.Drawing.Color.White;
            this.btnRecortar.Location = new System.Drawing.Point(12, 166);
            this.btnRecortar.Name = "btnRecortar";
            this.btnRecortar.Size = new System.Drawing.Size(216, 40);
            this.btnRecortar.TabIndex = 3;
            this.btnRecortar.Text = "Aplicar Recorte";
            this.btnRecortar.UseVisualStyleBackColor = false;
            this.btnRecortar.Click += new System.EventHandler(this.btnRecortar_Click);
            // 
            // cmbAlgoritmo
            // 
            this.cmbAlgoritmo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAlgoritmo.FormattingEnabled = true;
            this.cmbAlgoritmo.Location = new System.Drawing.Point(12, 139);
            this.cmbAlgoritmo.Name = "cmbAlgoritmo";
            this.cmbAlgoritmo.Size = new System.Drawing.Size(216, 21);
            this.cmbAlgoritmo.TabIndex = 2;
            // 
            // lblAlgoritmo
            // 
            this.lblAlgoritmo.AutoSize = true;
            this.lblAlgoritmo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlgoritmo.Location = new System.Drawing.Point(12, 119);
            this.lblAlgoritmo.Name = "lblAlgoritmo";
            this.lblAlgoritmo.Size = new System.Drawing.Size(126, 13);
            this.lblAlgoritmo.TabIndex = 1;
            this.lblAlgoritmo.Text = "2. Escoja Algoritmo:";
            // 
            // grpModo
            // 
            this.grpModo.Controls.Add(this.rbPoligono);
            this.grpModo.Controls.Add(this.rbLinea);
            this.grpModo.Location = new System.Drawing.Point(12, 12);
            this.grpModo.Name = "grpModo";
            this.grpModo.Size = new System.Drawing.Size(216, 80);
            this.grpModo.TabIndex = 0;
            this.grpModo.TabStop = false;
            this.grpModo.Text = "1. Seleccione Objeto";
            // 
            // rbPoligono
            // 
            this.rbPoligono.AutoSize = true;
            this.rbPoligono.Location = new System.Drawing.Point(15, 48);
            this.rbPoligono.Name = "rbPoligono";
            this.rbPoligono.Size = new System.Drawing.Size(125, 17);
            this.rbPoligono.TabIndex = 1;
            this.rbPoligono.Text = "Polígono (Sutherland)";
            this.rbPoligono.UseVisualStyleBackColor = true;
            this.rbPoligono.CheckedChanged += new System.EventHandler(this.rbPoligono_CheckedChanged);
            // 
            // rbLinea
            // 
            this.rbLinea.AutoSize = true;
            this.rbLinea.Checked = true;
            this.rbLinea.Location = new System.Drawing.Point(15, 25);
            this.rbLinea.Name = "rbLinea";
            this.rbLinea.Size = new System.Drawing.Size(53, 17);
            this.rbLinea.TabIndex = 0;
            this.rbLinea.TabStop = true;
            this.rbLinea.Text = "Línea";
            this.rbLinea.UseVisualStyleBackColor = true;
            this.rbLinea.CheckedChanged += new System.EventHandler(this.rbLinea_CheckedChanged);
            // 
            // ptbCanvas
            // 
            this.ptbCanvas.BackColor = System.Drawing.Color.White;
            this.ptbCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ptbCanvas.Location = new System.Drawing.Point(240, 0);
            this.ptbCanvas.Name = "ptbCanvas";
            this.ptbCanvas.Size = new System.Drawing.Size(560, 500);
            this.ptbCanvas.TabIndex = 1;
            this.ptbCanvas.TabStop = false;
            this.ptbCanvas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ptbCanvas_MouseClick);
            // 
            // AlgoritmosRecorte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.ptbCanvas);
            this.Controls.Add(this.pnlControles);
            this.Name = "AlgoritmosRecorte";
            this.Text = "Algoritmos de Recorte (Clipping)";
            this.Load += new System.EventHandler(this.AlgoritmosRecorte_Load);
            this.pnlControles.ResumeLayout(false);
            this.pnlControles.PerformLayout();
            this.grpModo.ResumeLayout(false);
            this.grpModo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbCanvas)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlControles;
        private System.Windows.Forms.GroupBox grpModo;
        private System.Windows.Forms.RadioButton rbPoligono;
        private System.Windows.Forms.RadioButton rbLinea;
        private System.Windows.Forms.Label lblAlgoritmo;
        private System.Windows.Forms.ComboBox cmbAlgoritmo;
        private System.Windows.Forms.Button btnRecortar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.PictureBox ptbCanvas;
    }
}