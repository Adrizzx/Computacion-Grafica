namespace WinAppTodosAlgoritmos
{
    partial class CirculoRelleno
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
            this.grbInputs = new System.Windows.Forms.GroupBox();
            this.lblParametros = new System.Windows.Forms.Label();
            this.lblRadio = new System.Windows.Forms.Label();
            this.txtRadio = new System.Windows.Forms.TextBox();
            this.lblCentro = new System.Windows.Forms.Label();
            this.grbAlgoritmosCirculo = new System.Windows.Forms.GroupBox();
            this.btnMidpoint = new System.Windows.Forms.Button();
            this.btnBresenham = new System.Windows.Forms.Button();
            this.btnPolar = new System.Windows.Forms.Button();
            this.grbAlgoritmosRelleno = new System.Windows.Forms.GroupBox();
            this.btnFloodFill = new System.Windows.Forms.Button();
            this.btnBoundaryFill = new System.Windows.Forms.Button();
            this.btnScanline = new System.Windows.Forms.Button();
            this.grbControles = new System.Windows.Forms.GroupBox();
            this.btnAnterior = new System.Windows.Forms.Button();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.grbCanvas = new System.Windows.Forms.GroupBox();
            this.ptbGrafica = new System.Windows.Forms.PictureBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.pnlControles = new System.Windows.Forms.Panel();
            this.grbInputs.SuspendLayout();
            this.grbAlgoritmosCirculo.SuspendLayout();
            this.grbAlgoritmosRelleno.SuspendLayout();
            this.grbControles.SuspendLayout();
            this.grbCanvas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbGrafica)).BeginInit();
            this.pnlControles.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbInputs
            // 
            this.grbInputs.Controls.Add(this.lblParametros);
            this.grbInputs.Controls.Add(this.lblRadio);
            this.grbInputs.Controls.Add(this.txtRadio);
            this.grbInputs.Controls.Add(this.lblCentro);
            this.grbInputs.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbInputs.Location = new System.Drawing.Point(0, 0);
            this.grbInputs.Name = "grbInputs";
            this.grbInputs.Size = new System.Drawing.Size(250, 105);
            this.grbInputs.TabIndex = 0;
            this.grbInputs.TabStop = false;
            this.grbInputs.Text = "Entradas";
            // 
            // lblParametros
            // 
            this.lblParametros.AutoSize = true;
            this.lblParametros.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParametros.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblParametros.Location = new System.Drawing.Point(15, 75);
            this.lblParametros.Name = "lblParametros";
            this.lblParametros.Size = new System.Drawing.Size(0, 13);
            this.lblParametros.TabIndex = 3;
            // 
            // lblRadio
            // 
            this.lblRadio.AutoSize = true;
            this.lblRadio.Location = new System.Drawing.Point(15, 25);
            this.lblRadio.Name = "lblRadio";
            this.lblRadio.Size = new System.Drawing.Size(38, 13);
            this.lblRadio.TabIndex = 0;
            this.lblRadio.Text = "Radio:";
            // 
            // txtRadio
            // 
            this.txtRadio.Location = new System.Drawing.Point(100, 22);
            this.txtRadio.Name = "txtRadio";
            this.txtRadio.Size = new System.Drawing.Size(130, 20);
            this.txtRadio.TabIndex = 1;
            // 
            // lblCentro
            // 
            this.lblCentro.AutoSize = true;
            this.lblCentro.ForeColor = System.Drawing.Color.Gray;
            this.lblCentro.Location = new System.Drawing.Point(15, 50);
            this.lblCentro.Name = "lblCentro";
            this.lblCentro.Size = new System.Drawing.Size(180, 13);
            this.lblCentro.TabIndex = 2;
            this.lblCentro.Text = "Centro: (Automático - en el centro)";
            // 
            // grbAlgoritmosCirculo
            // 
            this.grbAlgoritmosCirculo.Controls.Add(this.btnMidpoint);
            this.grbAlgoritmosCirculo.Controls.Add(this.btnBresenham);
            this.grbAlgoritmosCirculo.Controls.Add(this.btnPolar);
            this.grbAlgoritmosCirculo.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbAlgoritmosCirculo.Location = new System.Drawing.Point(0, 105);
            this.grbAlgoritmosCirculo.Name = "grbAlgoritmosCirculo";
            this.grbAlgoritmosCirculo.Size = new System.Drawing.Size(250, 120);
            this.grbAlgoritmosCirculo.TabIndex = 1;
            this.grbAlgoritmosCirculo.TabStop = false;
            this.grbAlgoritmosCirculo.Text = "1. Trazado de Círculo";
            // 
            // btnMidpoint
            // 
            this.btnMidpoint.BackColor = System.Drawing.Color.LightCyan;
            this.btnMidpoint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMidpoint.Location = new System.Drawing.Point(15, 25);
            this.btnMidpoint.Name = "btnMidpoint";
            this.btnMidpoint.Size = new System.Drawing.Size(215, 25);
            this.btnMidpoint.TabIndex = 0;
            this.btnMidpoint.Text = "Midpoint Circle (Parámetro P)";
            this.btnMidpoint.UseVisualStyleBackColor = false;
            this.btnMidpoint.Click += new System.EventHandler(this.btnMidpoint_Click);
            // 
            // btnBresenham
            // 
            this.btnBresenham.BackColor = System.Drawing.Color.LightCoral;
            this.btnBresenham.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBresenham.Location = new System.Drawing.Point(15, 56);
            this.btnBresenham.Name = "btnBresenham";
            this.btnBresenham.Size = new System.Drawing.Size(215, 25);
            this.btnBresenham.TabIndex = 1;
            this.btnBresenham.Text = "Bresenham Circle (Parámetro D)";
            this.btnBresenham.UseVisualStyleBackColor = false;
            this.btnBresenham.Click += new System.EventHandler(this.btnBresenham_Click);
            // 
            // btnPolar
            // 
            this.btnPolar.BackColor = System.Drawing.Color.LightGreen;
            this.btnPolar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPolar.Location = new System.Drawing.Point(15, 87);
            this.btnPolar.Name = "btnPolar";
            this.btnPolar.Size = new System.Drawing.Size(215, 25);
            this.btnPolar.TabIndex = 2;
            this.btnPolar.Text = "Polar (Trigonométrico)";
            this.btnPolar.UseVisualStyleBackColor = false;
            this.btnPolar.Click += new System.EventHandler(this.btnPolar_Click);
            // 
            // grbAlgoritmosRelleno
            // 
            this.grbAlgoritmosRelleno.Controls.Add(this.btnFloodFill);
            this.grbAlgoritmosRelleno.Controls.Add(this.btnBoundaryFill);
            this.grbAlgoritmosRelleno.Controls.Add(this.btnScanline);
            this.grbAlgoritmosRelleno.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbAlgoritmosRelleno.Location = new System.Drawing.Point(0, 225);
            this.grbAlgoritmosRelleno.Name = "grbAlgoritmosRelleno";
            this.grbAlgoritmosRelleno.Size = new System.Drawing.Size(250, 120);
            this.grbAlgoritmosRelleno.TabIndex = 2;
            this.grbAlgoritmosRelleno.TabStop = false;
            this.grbAlgoritmosRelleno.Text = "2. Algoritmos de Relleno (Click adentro)";
            // 
            // btnFloodFill
            // 
            this.btnFloodFill.BackColor = System.Drawing.Color.Khaki;
            this.btnFloodFill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFloodFill.Location = new System.Drawing.Point(15, 25);
            this.btnFloodFill.Name = "btnFloodFill";
            this.btnFloodFill.Size = new System.Drawing.Size(215, 25);
            this.btnFloodFill.TabIndex = 0;
            this.btnFloodFill.Text = "Flood Fill (Recursivo)";
            this.btnFloodFill.UseVisualStyleBackColor = false;
            this.btnFloodFill.Click += new System.EventHandler(this.btnFloodFill_Click);
            // 
            // btnBoundaryFill
            // 
            this.btnBoundaryFill.BackColor = System.Drawing.Color.LightBlue;
            this.btnBoundaryFill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBoundaryFill.Location = new System.Drawing.Point(15, 56);
            this.btnBoundaryFill.Name = "btnBoundaryFill";
            this.btnBoundaryFill.Size = new System.Drawing.Size(215, 25);
            this.btnBoundaryFill.TabIndex = 1;
            this.btnBoundaryFill.Text = "BFS Fill (Iterativo / Boundary)";
            this.btnBoundaryFill.UseVisualStyleBackColor = false;
            this.btnBoundaryFill.Click += new System.EventHandler(this.btnBoundaryFill_Click);
            // 
            // btnScanline
            // 
            this.btnScanline.BackColor = System.Drawing.Color.Plum;
            this.btnScanline.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScanline.Location = new System.Drawing.Point(15, 87);
            this.btnScanline.Name = "btnScanline";
            this.btnScanline.Size = new System.Drawing.Size(215, 25);
            this.btnScanline.TabIndex = 2;
            this.btnScanline.Text = "Scanline Seed Fill";
            this.btnScanline.UseVisualStyleBackColor = false;
            this.btnScanline.Click += new System.EventHandler(this.btnScanline_Click);
            // 
            // grbControles
            // 
            this.grbControles.Controls.Add(this.btnAnterior);
            this.grbControles.Controls.Add(this.btnSiguiente);
            this.grbControles.Controls.Add(this.btnLimpiar);
            this.grbControles.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grbControles.Location = new System.Drawing.Point(0, 427);
            this.grbControles.Name = "grbControles";
            this.grbControles.Size = new System.Drawing.Size(250, 90);
            this.grbControles.TabIndex = 4;
            this.grbControles.TabStop = false;
            this.grbControles.Text = "3. Controles Paso a Paso";
            // 
            // btnAnterior
            // 
            this.btnAnterior.Enabled = false;
            this.btnAnterior.Location = new System.Drawing.Point(15, 25);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(100, 25);
            this.btnAnterior.TabIndex = 0;
            this.btnAnterior.Text = "◄ Anterior";
            this.btnAnterior.UseVisualStyleBackColor = true;
            this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click);
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.Enabled = false;
            this.btnSiguiente.Location = new System.Drawing.Point(130, 25);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(100, 25);
            this.btnSiguiente.TabIndex = 1;
            this.btnSiguiente.Text = "Siguiente ►";
            this.btnSiguiente.UseVisualStyleBackColor = true;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(15, 56);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(215, 25);
            this.btnLimpiar.TabIndex = 2;
            this.btnLimpiar.Text = "Limpiar Todo";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // grbCanvas
            // 
            this.grbCanvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbCanvas.Controls.Add(this.ptbGrafica);
            this.grbCanvas.Location = new System.Drawing.Point(268, 12);
            this.grbCanvas.Name = "grbCanvas";
            this.grbCanvas.Size = new System.Drawing.Size(520, 520);
            this.grbCanvas.TabIndex = 3;
            this.grbCanvas.TabStop = false;
            this.grbCanvas.Text = "Gráfico - El centro es (0,0)";
            // 
            // ptbGrafica
            // 
            this.ptbGrafica.BackColor = System.Drawing.Color.White;
            this.ptbGrafica.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ptbGrafica.Location = new System.Drawing.Point(3, 16);
            this.ptbGrafica.Name = "ptbGrafica";
            this.ptbGrafica.Size = new System.Drawing.Size(514, 501);
            this.ptbGrafica.TabIndex = 0;
            this.ptbGrafica.TabStop = false;
            this.ptbGrafica.SizeChanged += new System.EventHandler(this.ptbGrafica_SizeChanged);
            this.ptbGrafica.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ptbGrafica_MouseClick);
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(12, 540);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(124, 13);
            this.lblInfo.TabIndex = 5;
            this.lblInfo.Text = "Ingrese radio y dibuje";
            // 
            // pnlControles
            // 
            this.pnlControles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlControles.Controls.Add(this.grbInputs);
            this.pnlControles.Controls.Add(this.grbAlgoritmosRelleno);
            this.pnlControles.Controls.Add(this.grbAlgoritmosCirculo);
            this.pnlControles.Controls.Add(this.grbControles);
            this.pnlControles.Location = new System.Drawing.Point(12, 12);
            this.pnlControles.Name = "pnlControles";
            this.pnlControles.Size = new System.Drawing.Size(250, 517);
            this.pnlControles.TabIndex = 6;
            // 
            // CirculoRelleno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 565);
            this.Controls.Add(this.pnlControles);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.grbCanvas);
            this.Name = "CirculoRelleno";
            this.Text = "Círculos y Algoritmos de Relleno";
            this.Load += new System.EventHandler(this.CirculoRelleno_Load);
            this.grbInputs.ResumeLayout(false);
            this.grbInputs.PerformLayout();
            this.grbAlgoritmosCirculo.ResumeLayout(false);
            this.grbAlgoritmosRelleno.ResumeLayout(false);
            this.grbControles.ResumeLayout(false);
            this.grbCanvas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptbGrafica)).EndInit();
            this.pnlControles.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.GroupBox grbInputs;
        private System.Windows.Forms.Label lblParametros;
        private System.Windows.Forms.Label lblRadio;
        private System.Windows.Forms.TextBox txtRadio;
        private System.Windows.Forms.Label lblCentro;
        private System.Windows.Forms.GroupBox grbAlgoritmosCirculo;
        private System.Windows.Forms.Button btnMidpoint;
        private System.Windows.Forms.Button btnBresenham;
        private System.Windows.Forms.Button btnPolar;
        private System.Windows.Forms.GroupBox grbAlgoritmosRelleno;
        private System.Windows.Forms.Button btnFloodFill;
        private System.Windows.Forms.Button btnBoundaryFill;
        private System.Windows.Forms.Button btnScanline;
        private System.Windows.Forms.GroupBox grbCanvas;
        private System.Windows.Forms.PictureBox ptbGrafica;
        private System.Windows.Forms.GroupBox grbControles;
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Panel pnlControles;
    }
}