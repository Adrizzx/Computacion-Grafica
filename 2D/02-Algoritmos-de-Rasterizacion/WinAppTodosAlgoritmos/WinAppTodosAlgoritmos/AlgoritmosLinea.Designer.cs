namespace WinAppTodosAlgoritmos
{
    partial class AlgoritmosLinea
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
            this.grbEntradas = new System.Windows.Forms.GroupBox();
            this.lblFinalY = new System.Windows.Forms.Label();
            this.txtFinalY = new System.Windows.Forms.TextBox();
            this.lblFinalX = new System.Windows.Forms.Label();
            this.txtFinalX = new System.Windows.Forms.TextBox();
            this.lblInicioY = new System.Windows.Forms.Label();
            this.txtInicioY = new System.Windows.Forms.TextBox();
            this.lblInicioX = new System.Windows.Forms.Label();
            this.txtInicioX = new System.Windows.Forms.TextBox();
            this.grbAlgoritmos = new System.Windows.Forms.GroupBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.btnAnterior = new System.Windows.Forms.Button();
            this.btnDDA = new System.Windows.Forms.Button();
            this.btnBresenham = new System.Windows.Forms.Button();
            this.btnPuntoMedio = new System.Windows.Forms.Button();
            this.grbParametros = new System.Windows.Forms.GroupBox();
            this.lblP = new System.Windows.Forms.Label();
            this.txtP = new System.Windows.Forms.TextBox();
            this.lblDeltaY = new System.Windows.Forms.Label();
            this.txtDeltaY = new System.Windows.Forms.TextBox();
            this.lblDeltaX = new System.Windows.Forms.Label();
            this.txtDeltaX = new System.Windows.Forms.TextBox();
            this.lblK = new System.Windows.Forms.Label();
            this.txtK = new System.Windows.Forms.TextBox();
            this.lblPendiente = new System.Windows.Forms.Label();
            this.txtPendiente = new System.Windows.Forms.TextBox();
            this.grbCanvas = new System.Windows.Forms.GroupBox();
            this.ptbGrafica = new System.Windows.Forms.PictureBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.pnlControles = new System.Windows.Forms.Panel();
            this.grbEntradas.SuspendLayout();
            this.grbAlgoritmos.SuspendLayout();
            this.grbParametros.SuspendLayout();
            this.grbCanvas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbGrafica)).BeginInit();
            this.pnlControles.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbEntradas
            // 
            this.grbEntradas.Controls.Add(this.lblFinalY);
            this.grbEntradas.Controls.Add(this.txtFinalY);
            this.grbEntradas.Controls.Add(this.lblFinalX);
            this.grbEntradas.Controls.Add(this.txtFinalX);
            this.grbEntradas.Controls.Add(this.lblInicioY);
            this.grbEntradas.Controls.Add(this.txtInicioY);
            this.grbEntradas.Controls.Add(this.lblInicioX);
            this.grbEntradas.Controls.Add(this.txtInicioX);
            this.grbEntradas.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbEntradas.Location = new System.Drawing.Point(0, 0);
            this.grbEntradas.Name = "grbEntradas";
            this.grbEntradas.Size = new System.Drawing.Size(250, 130);
            this.grbEntradas.TabIndex = 0;
            this.grbEntradas.TabStop = false;
            this.grbEntradas.Text = "Puntos (X, Y)";
            // 
            // lblFinalY
            // 
            this.lblFinalY.AutoSize = true;
            this.lblFinalY.Location = new System.Drawing.Point(15, 103);
            this.lblFinalY.Name = "lblFinalY";
            this.lblFinalY.Size = new System.Drawing.Size(42, 13);
            this.lblFinalY.TabIndex = 6;
            this.lblFinalY.Text = "Final Y:";
            // 
            // txtFinalY
            // 
            this.txtFinalY.Location = new System.Drawing.Point(100, 100);
            this.txtFinalY.Name = "txtFinalY";
            this.txtFinalY.Size = new System.Drawing.Size(130, 20);
            this.txtFinalY.TabIndex = 7;
            // 
            // lblFinalX
            // 
            this.lblFinalX.AutoSize = true;
            this.lblFinalX.Location = new System.Drawing.Point(15, 77);
            this.lblFinalX.Name = "lblFinalX";
            this.lblFinalX.Size = new System.Drawing.Size(42, 13);
            this.lblFinalX.TabIndex = 4;
            this.lblFinalX.Text = "Final X:";
            // 
            // txtFinalX
            // 
            this.txtFinalX.Location = new System.Drawing.Point(100, 74);
            this.txtFinalX.Name = "txtFinalX";
            this.txtFinalX.Size = new System.Drawing.Size(130, 20);
            this.txtFinalX.TabIndex = 5;
            // 
            // lblInicioY
            // 
            this.lblInicioY.AutoSize = true;
            this.lblInicioY.Location = new System.Drawing.Point(15, 51);
            this.lblInicioY.Name = "lblInicioY";
            this.lblInicioY.Size = new System.Drawing.Size(45, 13);
            this.lblInicioY.TabIndex = 2;
            this.lblInicioY.Text = "Inicio Y:";
            // 
            // txtInicioY
            // 
            this.txtInicioY.Location = new System.Drawing.Point(100, 48);
            this.txtInicioY.Name = "txtInicioY";
            this.txtInicioY.Size = new System.Drawing.Size(130, 20);
            this.txtInicioY.TabIndex = 3;
            // 
            // lblInicioX
            // 
            this.lblInicioX.AutoSize = true;
            this.lblInicioX.Location = new System.Drawing.Point(15, 25);
            this.lblInicioX.Name = "lblInicioX";
            this.lblInicioX.Size = new System.Drawing.Size(45, 13);
            this.lblInicioX.TabIndex = 0;
            this.lblInicioX.Text = "Inicio X:";
            // 
            // txtInicioX
            // 
            this.txtInicioX.Location = new System.Drawing.Point(100, 22);
            this.txtInicioX.Name = "txtInicioX";
            this.txtInicioX.Size = new System.Drawing.Size(130, 20);
            this.txtInicioX.TabIndex = 1;
            // 
            // grbAlgoritmos
            // 
            this.grbAlgoritmos.Controls.Add(this.btnLimpiar);
            this.grbAlgoritmos.Controls.Add(this.btnSiguiente);
            this.grbAlgoritmos.Controls.Add(this.btnAnterior);
            this.grbAlgoritmos.Controls.Add(this.btnDDA);
            this.grbAlgoritmos.Controls.Add(this.btnBresenham);
            this.grbAlgoritmos.Controls.Add(this.btnPuntoMedio);
            this.grbAlgoritmos.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbAlgoritmos.Location = new System.Drawing.Point(0, 130);
            this.grbAlgoritmos.Name = "grbAlgoritmos";
            this.grbAlgoritmos.Size = new System.Drawing.Size(250, 158);
            this.grbAlgoritmos.TabIndex = 1;
            this.grbAlgoritmos.TabStop = false;
            this.grbAlgoritmos.Text = "Algoritmos de Línea";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(15, 122);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(215, 25);
            this.btnLimpiar.TabIndex = 5;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.Enabled = false;
            this.btnSiguiente.Location = new System.Drawing.Point(130, 91);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(100, 25);
            this.btnSiguiente.TabIndex = 4;
            this.btnSiguiente.Text = "Siguiente ►";
            this.btnSiguiente.UseVisualStyleBackColor = true;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // btnAnterior
            // 
            this.btnAnterior.Enabled = false;
            this.btnAnterior.Location = new System.Drawing.Point(15, 91);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(100, 25);
            this.btnAnterior.TabIndex = 3;
            this.btnAnterior.Text = "◄ Anterior";
            this.btnAnterior.UseVisualStyleBackColor = true;
            this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click);
            // 
            // btnDDA
            // 
            this.btnDDA.BackColor = System.Drawing.Color.LightCyan;
            this.btnDDA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDDA.Location = new System.Drawing.Point(15, 25);
            this.btnDDA.Name = "btnDDA";
            this.btnDDA.Size = new System.Drawing.Size(65, 55);
            this.btnDDA.TabIndex = 0;
            this.btnDDA.Text = "DDA";
            this.btnDDA.UseVisualStyleBackColor = false;
            this.btnDDA.Click += new System.EventHandler(this.btnDDA_Click);
            // 
            // btnBresenham
            // 
            this.btnBresenham.BackColor = System.Drawing.Color.LightCoral;
            this.btnBresenham.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBresenham.Location = new System.Drawing.Point(85, 25);
            this.btnBresenham.Name = "btnBresenham";
            this.btnBresenham.Size = new System.Drawing.Size(80, 55);
            this.btnBresenham.TabIndex = 1;
            this.btnBresenham.Text = "Bresenham";
            this.btnBresenham.UseVisualStyleBackColor = false;
            this.btnBresenham.Click += new System.EventHandler(this.btnBresenham_Click);
            // 
            // btnPuntoMedio
            // 
            this.btnPuntoMedio.BackColor = System.Drawing.Color.LightGreen;
            this.btnPuntoMedio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPuntoMedio.Location = new System.Drawing.Point(170, 25);
            this.btnPuntoMedio.Name = "btnPuntoMedio";
            this.btnPuntoMedio.Size = new System.Drawing.Size(60, 55);
            this.btnPuntoMedio.TabIndex = 2;
            this.btnPuntoMedio.Text = "Midpoint";
            this.btnPuntoMedio.UseVisualStyleBackColor = false;
            this.btnPuntoMedio.Click += new System.EventHandler(this.btnPuntoMedio_Click);
            // 
            // grbParametros
            // 
            this.grbParametros.Controls.Add(this.lblP);
            this.grbParametros.Controls.Add(this.txtP);
            this.grbParametros.Controls.Add(this.lblDeltaY);
            this.grbParametros.Controls.Add(this.txtDeltaY);
            this.grbParametros.Controls.Add(this.lblDeltaX);
            this.grbParametros.Controls.Add(this.txtDeltaX);
            this.grbParametros.Controls.Add(this.lblK);
            this.grbParametros.Controls.Add(this.txtK);
            this.grbParametros.Controls.Add(this.lblPendiente);
            this.grbParametros.Controls.Add(this.txtPendiente);
            this.grbParametros.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbParametros.Location = new System.Drawing.Point(0, 288);
            this.grbParametros.Name = "grbParametros";
            this.grbParametros.Size = new System.Drawing.Size(250, 160);
            this.grbParametros.TabIndex = 2;
            this.grbParametros.TabStop = false;
            this.grbParametros.Text = "Parámetros de Cálculo";
            // 
            // lblP
            // 
            this.lblP.AutoSize = true;
            this.lblP.Location = new System.Drawing.Point(15, 129);
            this.lblP.Name = "lblP";
            this.lblP.Size = new System.Drawing.Size(49, 13);
            this.lblP.TabIndex = 8;
            this.lblP.Text = "P / D ini:";
            // 
            // txtP
            // 
            this.txtP.Location = new System.Drawing.Point(100, 126);
            this.txtP.Name = "txtP";
            this.txtP.ReadOnly = true;
            this.txtP.Size = new System.Drawing.Size(130, 20);
            this.txtP.TabIndex = 9;
            // 
            // lblDeltaY
            // 
            this.lblDeltaY.AutoSize = true;
            this.lblDeltaY.Location = new System.Drawing.Point(15, 103);
            this.lblDeltaY.Name = "lblDeltaY";
            this.lblDeltaY.Size = new System.Drawing.Size(45, 13);
            this.lblDeltaY.TabIndex = 6;
            this.lblDeltaY.Text = "Delta Y:";
            // 
            // txtDeltaY
            // 
            this.txtDeltaY.Location = new System.Drawing.Point(100, 100);
            this.txtDeltaY.Name = "txtDeltaY";
            this.txtDeltaY.ReadOnly = true;
            this.txtDeltaY.Size = new System.Drawing.Size(130, 20);
            this.txtDeltaY.TabIndex = 7;
            // 
            // lblDeltaX
            // 
            this.lblDeltaX.AutoSize = true;
            this.lblDeltaX.Location = new System.Drawing.Point(15, 77);
            this.lblDeltaX.Name = "lblDeltaX";
            this.lblDeltaX.Size = new System.Drawing.Size(45, 13);
            this.lblDeltaX.TabIndex = 4;
            this.lblDeltaX.Text = "Delta X:";
            // 
            // txtDeltaX
            // 
            this.txtDeltaX.Location = new System.Drawing.Point(100, 74);
            this.txtDeltaX.Name = "txtDeltaX";
            this.txtDeltaX.ReadOnly = true;
            this.txtDeltaX.Size = new System.Drawing.Size(130, 20);
            this.txtDeltaX.TabIndex = 5;
            // 
            // lblK
            // 
            this.lblK.AutoSize = true;
            this.lblK.Location = new System.Drawing.Point(15, 51);
            this.lblK.Name = "lblK";
            this.lblK.Size = new System.Drawing.Size(17, 13);
            this.lblK.TabIndex = 2;
            this.lblK.Text = "K:";
            // 
            // txtK
            // 
            this.txtK.Location = new System.Drawing.Point(100, 48);
            this.txtK.Name = "txtK";
            this.txtK.ReadOnly = true;
            this.txtK.Size = new System.Drawing.Size(130, 20);
            this.txtK.TabIndex = 3;
            // 
            // lblPendiente
            // 
            this.lblPendiente.AutoSize = true;
            this.lblPendiente.Location = new System.Drawing.Point(15, 25);
            this.lblPendiente.Name = "lblPendiente";
            this.lblPendiente.Size = new System.Drawing.Size(75, 13);
            this.lblPendiente.TabIndex = 0;
            this.lblPendiente.Text = "Pendiente (m):";
            // 
            // txtPendiente
            // 
            this.txtPendiente.Location = new System.Drawing.Point(100, 22);
            this.txtPendiente.Name = "txtPendiente";
            this.txtPendiente.ReadOnly = true;
            this.txtPendiente.Size = new System.Drawing.Size(130, 20);
            this.txtPendiente.TabIndex = 1;
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
            this.grbCanvas.Text = "Gráfico de Línea";
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
            this.ptbGrafica.Click += new System.EventHandler(this.ptbGrafica_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(12, 540);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(126, 13);
            this.lblInfo.TabIndex = 5;
            this.lblInfo.Text = "Ingrese coordenadas";
            // 
            // pnlControles
            // 
            this.pnlControles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlControles.Controls.Add(this.grbEntradas);
            this.pnlControles.Controls.Add(this.grbParametros);
            this.pnlControles.Controls.Add(this.grbAlgoritmos);
            this.pnlControles.Location = new System.Drawing.Point(12, 12);
            this.pnlControles.Name = "pnlControles";
            this.pnlControles.Size = new System.Drawing.Size(250, 520);
            this.pnlControles.TabIndex = 6;
            // 
            // AlgoritmosLinea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 565);
            this.Controls.Add(this.pnlControles);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.grbCanvas);
            this.Name = "AlgoritmosLinea";
            this.Text = "Algoritmos de Trazado de Línea";
            this.Load += new System.EventHandler(this.AlgoritmosLinea_Load);
            this.grbEntradas.ResumeLayout(false);
            this.grbEntradas.PerformLayout();
            this.grbAlgoritmos.ResumeLayout(false);
            this.grbParametros.ResumeLayout(false);
            this.grbParametros.PerformLayout();
            this.grbCanvas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptbGrafica)).EndInit();
            this.pnlControles.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.GroupBox grbEntradas;
        private System.Windows.Forms.Label lblInicioX;
        private System.Windows.Forms.TextBox txtInicioX;
        private System.Windows.Forms.Label lblInicioY;
        private System.Windows.Forms.TextBox txtInicioY;
        private System.Windows.Forms.Label lblFinalX;
        private System.Windows.Forms.TextBox txtFinalX;
        private System.Windows.Forms.Label lblFinalY;
        private System.Windows.Forms.TextBox txtFinalY;
        private System.Windows.Forms.GroupBox grbAlgoritmos;
        private System.Windows.Forms.Button btnDDA;
        private System.Windows.Forms.Button btnBresenham;
        private System.Windows.Forms.Button btnPuntoMedio;
        private System.Windows.Forms.GroupBox grbParametros;
        private System.Windows.Forms.Label lblPendiente;
        private System.Windows.Forms.TextBox txtPendiente;
        private System.Windows.Forms.Label lblK;
        private System.Windows.Forms.TextBox txtK;
        private System.Windows.Forms.Label lblDeltaX;
        private System.Windows.Forms.TextBox txtDeltaX;
        private System.Windows.Forms.Label lblDeltaY;
        private System.Windows.Forms.TextBox txtDeltaY;
        private System.Windows.Forms.Label lblP;
        private System.Windows.Forms.TextBox txtP;
        private System.Windows.Forms.GroupBox grbCanvas;
        private System.Windows.Forms.PictureBox ptbGrafica;
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Panel pnlControles;
        }
    }
