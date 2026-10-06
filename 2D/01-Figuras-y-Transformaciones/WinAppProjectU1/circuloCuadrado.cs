using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinAppProjectU1
{
    public partial class circuloCuadrado : Form
    {
        private FigureTransformer transformer;
        private float currentRadioCm = 0; 
        private bool isTranslating = false;

        public circuloCuadrado()
        {
            InitializeComponent();
            transformer = new FigureTransformer();
        }

        private void circuloCuadrado_Load(object sender, EventArgs e)
        {
            hScrollBarEscala.Minimum = 10;
            hScrollBarEscala.Maximum = 200;
            hScrollBarEscala.Value = 100;
            hScrollBarEscala.LargeChange = 10;
            hScrollBarEscala.SmallChange = 1;
        }

        /// <summary>
        /// Contiene toda la lógica de dibujo. Se llama cada vez que 
        /// la figura necesita redibujarse (al graficar, rotar, escalar, etc.)
        /// </summary>
        private void DrawFigure()
        {
            if (currentRadioCm <= 0)
            {
                if (ptbGrafica.Image != null)
                {
                    ptbGrafica.Image.Dispose();
                    ptbGrafica.Image = null;
                }
                return;
            }

            // Preparar el área de dibujo
            Bitmap bmp = new Bitmap(ptbGrafica.Width, ptbGrafica.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.DarkBlue);

                //conversion de px a cm
                float dpi = g.DpiX;
                float pixelesPorCm = dpi / 2.54f;
                float radio = currentRadioCm * pixelesPorCm;

                PointF center = new PointF(ptbGrafica.Width / 2f, ptbGrafica.Height / 2f);


                transformer.Center = center;
                transformer.ApplyTransform(g);

                float h = radio / 10.0f;

                using (Pen grayPen = new Pen(Color.Gray))
                using (Pen whitePen = new Pen(Color.White, 3.5f))
                {
                    grayPen.DashStyle = DashStyle.Dash;

                    PointF A = new PointF(center.X, center.Y - radio);
                    PointF B = new PointF(center.X + radio, center.Y);
                    PointF C = new PointF(center.X, center.Y + radio);
                    PointF D = new PointF(center.X - radio, center.Y);

                    float r_cos45 = (float)(radio * Math.Cos(Math.PI / 4));
                    float r_sin45 = (float)(radio * Math.Sin(Math.PI / 4));

                    PointF A_prime = new PointF(center.X - r_sin45, center.Y - r_cos45);
                    PointF B_prime = new PointF(center.X + r_cos45, center.Y - r_sin45);
                    PointF C_prime = new PointF(center.X + r_sin45, center.Y + r_cos45);
                    PointF D_prime = new PointF(center.X - r_cos45, center.Y + r_sin45);

                    // dibujar las lineas de gris
                    DrawCircle(g, grayPen, center, radio);
                    DrawCircle(g, grayPen, center, radio - h);
                    DrawCircle(g, grayPen, center, radio - (4 * h));
                    DrawCircle(g, grayPen, center, radio - (7 * h));

                    g.DrawLine(grayPen, A, C);
                    g.DrawLine(grayPen, D, B);
                    g.DrawLine(grayPen, A_prime, C_prime);
                    g.DrawLine(grayPen, D_prime, B_prime);

                    // dibujar las lineas de blanco
                    g.DrawLine(whitePen, A, B);
                    g.DrawLine(whitePen, B, C);
                    g.DrawLine(whitePen, C, D);
                    g.DrawLine(whitePen, D, A);

                    g.DrawLine(whitePen, A_prime, B_prime);
                    g.DrawLine(whitePen, B_prime, C_prime);
                    g.DrawLine(whitePen, C_prime, D_prime);
                    g.DrawLine(whitePen, D_prime, A_prime);

                    g.DrawLine(whitePen, A, C_prime);
                    g.DrawLine(whitePen, A, D_prime);
                    g.DrawLine(whitePen, B_prime, D);
                    g.DrawLine(whitePen, B_prime, C);
                    g.DrawLine(whitePen, B, A_prime);
                    g.DrawLine(whitePen, B, D_prime);
                    g.DrawLine(whitePen, C_prime, D);
                    g.DrawLine(whitePen, C, A_prime);

                }
            }

            // asignar el dibujo final al ptbGrafica
            if (ptbGrafica.Image != null)
            {
                ptbGrafica.Image.Dispose();
            }
            ptbGrafica.Image = bmp;
        }


        private void btnGraficar_Click(object sender, EventArgs e)
        {
            if (!float.TryParse(txtRadio.Text, out float radioCm) || radioCm <= 0)
            {
                MessageBox.Show("Por favor, ingresa un número válido y positivo para el radio en CENTÍMETROS.");
                return;
            }

            currentRadioCm = radioCm;
            transformer.Reset();
            isTranslating = false;
            btnTrasladar.Text = "Trasladar";
            hScrollBarEscala.Value = 100;

            DrawFigure();
        }

        private void btnResetear_Click(object sender, EventArgs e)
        {
            if (ptbGrafica.Image != null)
            {
                ptbGrafica.Image.Dispose();
                ptbGrafica.Image = null;
            }

            txtRadio.Text = "";
            currentRadioCm = 0;

            transformer.Reset();

            hScrollBarEscala.Value = 100;
            isTranslating = false;
            btnTrasladar.Text = "Trasladar";
        }

        private void btnRotarIzq_Click(object sender, EventArgs e)
        {
            transformer.Rotate(-15.0f);
            DrawFigure();
        }

        private void btnRotarDer_Click(object sender, EventArgs e)
        {
            transformer.Rotate(15.0f);
            DrawFigure();
        }

        private void hScrollBarEscala_Scroll(object sender, ScrollEventArgs e)
        {
            float newScale = hScrollBarEscala.Value / 100.0f;
            transformer.SetScale(newScale);
            DrawFigure();
        }

        private void btnTrasladar_Click(object sender, EventArgs e)
        {
            isTranslating = !isTranslating;

            if (isTranslating)
            {
                btnTrasladar.Text = "Fijar Posición";
                ptbGrafica.Focus();
                MessageBox.Show("Modo Traslación Activado.\nUsa las flechas del teclado para mover la figura.",
                    "Trasladar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                btnTrasladar.Text = "Trasladar";
                this.ActiveControl = null;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (isTranslating)
            {
                float moveAmount = 10.0f;
                bool handled = false;

                switch (keyData)
                {
                    case Keys.Left:
                        transformer.Translate(-moveAmount, 0);
                        handled = true;
                        break;
                    case Keys.Right:
                        transformer.Translate(moveAmount, 0);
                        handled = true;
                        break;
                    case Keys.Up:
                        transformer.Translate(0, -moveAmount);
                        handled = true;
                        break;
                    case Keys.Down:
                        transformer.Translate(0, moveAmount);
                        handled = true;
                        break;
                }

                if (handled)
                {
                    DrawFigure();
                    return true;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }


        private void DrawCircle(Graphics g, Pen p, PointF center, float radius)
        {
            if (radius > 0)
            {
                g.DrawEllipse(p,
                    center.X - radius,
                    center.Y - radius,
                    radius * 2,
                    radius * 2);
            }
        }

    }
}