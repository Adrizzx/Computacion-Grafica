namespace WinAppTodosAlgoritmos
{
    partial class Inicio
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.algoritmosDeLineaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.circuloYRellenoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dibujadorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.algoritmosDeRecorteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.algoritmosDeLineaToolStripMenuItem,
            this.circuloYRellenoToolStripMenuItem,
            this.dibujadorToolStripMenuItem,
            this.algoritmosDeRecorteToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // algoritmosDeLineaToolStripMenuItem
            // 
            this.algoritmosDeLineaToolStripMenuItem.Name = "algoritmosDeLineaToolStripMenuItem";
            this.algoritmosDeLineaToolStripMenuItem.Size = new System.Drawing.Size(125, 20);
            this.algoritmosDeLineaToolStripMenuItem.Text = "Algoritmos de Línea";
            this.algoritmosDeLineaToolStripMenuItem.Click += new System.EventHandler(this.algoritmosDeLineaToolStripMenuItem_Click);
            // 
            // circuloYRellenoToolStripMenuItem
            // 
            this.circuloYRellenoToolStripMenuItem.Name = "circuloYRellenoToolStripMenuItem";
            this.circuloYRellenoToolStripMenuItem.Size = new System.Drawing.Size(108, 20);
            this.circuloYRellenoToolStripMenuItem.Text = "Círculo y Relleno";
            this.circuloYRellenoToolStripMenuItem.Click += new System.EventHandler(this.circuloYRellenoToolStripMenuItem_Click);
            // 
            // dibujadorToolStripMenuItem
            // 
            this.dibujadorToolStripMenuItem.Name = "dibujadorToolStripMenuItem";
            this.dibujadorToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.dibujadorToolStripMenuItem.Text = "Dibujador";
            this.dibujadorToolStripMenuItem.Click += new System.EventHandler(this.dibujadorToolStripMenuItem_Click);
            // 
            // algoritmosDeRecorteToolStripMenuItem
            // 
            this.algoritmosDeRecorteToolStripMenuItem.Name = "algoritmosDeRecorteToolStripMenuItem";
            this.algoritmosDeRecorteToolStripMenuItem.Size = new System.Drawing.Size(137, 20);
            this.algoritmosDeRecorteToolStripMenuItem.Text = "Algoritmos de Recorte";
            this.algoritmosDeRecorteToolStripMenuItem.Click += new System.EventHandler(this.algoritmosDeRecorteToolStripMenuItem_Click);
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Inicio";
            this.Text = "Compendio Gráficos - Integración Completa";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Inicio_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem algoritmosDeLineaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem circuloYRellenoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dibujadorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem algoritmosDeRecorteToolStripMenuItem;
    }
}