namespace WinAppVelocimetro
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Timer timerVelocimetro; // Declaración del Timer

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timerVelocimetro = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timerVelocimetro
            // 
            this.timerVelocimetro.Enabled = false; // Desactivado para usar control por teclado
            this.timerVelocimetro.Interval = 50;
            this.timerVelocimetro.Tick += new System.EventHandler(this.timerVelocimetro_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(600, 400); // Tamaño del lienzo
            this.Name = "Form1";
            this.Text = "Velocímetro Digital-Analógico";
            this.KeyPreview = true; // Permite que el formulario capture las teclas
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown); // Evento de teclado
            this.ResumeLayout(false);

        }

        #endregion
    }
}