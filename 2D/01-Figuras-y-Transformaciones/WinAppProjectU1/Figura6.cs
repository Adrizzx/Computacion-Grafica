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
    public partial class Figura6 : Form
    {
        private FigureTransformer transformer;
        private float currentRadioCm = 0;
        private bool isTranslating = false;

        public Figura6()
        {
            InitializeComponent();
            transformer = new FigureTransformer();
        }

        private void Figura6_Load(object sender, EventArgs e)
        {
            hScrollBarEscala.Minimum = 10;
            hScrollBarEscala.Maximum = 200;
            hScrollBarEscala.Value = 100;
            hScrollBarEscala.LargeChange = 10;
            hScrollBarEscala.SmallChange = 1;
        }

        /// <summary>
        /// Dibuja la figura del primer código adaptada
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
                g.Clear(Color.White);

                // Conversión de cm a píxeles con ajuste de escala
                float dpi = g.DpiX;
                float pixelesPorCm = dpi / 2.54f;
                float radioBase = currentRadioCm * pixelesPorCm * 0.6f; // Factor de escala para ajustar al tamaño del canvas

                PointF center = new PointF(ptbGrafica.Width / 2f, ptbGrafica.Height / 2f);

                // Primero trasladar al centro
                g.TranslateTransform(center.X, center.Y);

                transformer.Center = new PointF(0, 0); // Ahora el centro es (0,0)
                transformer.ApplyTransform(g);

                // Dibujar la figura del primer código
                DibujarFiguraOriginal(g, radioBase);
            }

            // Asignar el dibujo final al PictureBox
            if (ptbGrafica.Image != null)
            {
                ptbGrafica.Image.Dispose();
            }
            ptbGrafica.Image = bmp;
        }

        /// <summary>
        /// Dibuja la figura completa del primer código
        /// </summary>
        private void DibujarFiguraOriginal(Graphics g, float radioBase)
        {
            // El primer código usa un radio fijo de 50, escalamos proporcionalmente
            float escala = radioBase / 50f;
            int radio = 50;

            using (Pen lapiz = new Pen(Color.Black, 2))
            using (Pen lapizEntrecortado = new Pen(Color.Black))
            {
                lapizEntrecortado.DashStyle = DashStyle.Dash;

                // Crear la ruta principal (7 círculos base)
                using (GraphicsPath ruta = new GraphicsPath())
                {
                    // Círculo central
                    AgregarCirculoEscalado(ruta, 0, 0, radio, escala);

                    // 6 círculos alrededor
                    AgregarCirculoEscalado(ruta, 0, 50, radio, escala);
                    AgregarCirculoEscalado(ruta, 0, -50, radio, escala);
                    AgregarCirculoEscalado(ruta, -45, -25, radio, escala);
                    AgregarCirculoEscalado(ruta, 45, 25, radio, escala);
                    AgregarCirculoEscalado(ruta, 45, -25, radio, escala);
                    AgregarCirculoEscalado(ruta, -45, 25, radio, escala);

                    g.DrawPath(lapiz, ruta);

                    // Dibujar pétalos con clip (4 diagonales externas)
                    DibujarPetalConClip(g, lapiz, ruta, 45, -75, radio, escala);
                    DibujarPetalConClip(g, lapiz, ruta, 45, 75, radio, escala);
                    DibujarPetalConClip(g, lapiz, ruta, -45, 75, radio, escala);
                    DibujarPetalConClip(g, lapiz, ruta, -45, -75, radio, escala);

                    // Pétalos arriba y abajo con clip específico
                    DibujarPetalConClipCirculo(g, lapiz, 0, -50, 0, -100, radio, escala);
                    DibujarPetalConClipCirculo(g, lapiz, 0, 50, 0, 100, radio, escala);

                    // Pétalos horizontales
                    DibujarPetalConClip(g, lapiz, ruta, 85, 0, radio, escala);
                    DibujarPetalConClip(g, lapiz, ruta, -85, 0, radio, escala);

                    // Pétalos diagonales intermedios
                    DibujarPetalConClipCirculo(g, lapiz, 45, -25, 85, -50, radio, escala);
                    DibujarPetalConClipCirculo(g, lapiz, 45, 25, 85, 50, radio, escala);
                    DibujarPetalConClipCirculo(g, lapiz, -45, -25, -85, -50, radio, escala);
                    DibujarPetalConClipCirculo(g, lapiz, -45, 25, -85, 50, radio, escala);

                    // 12 círculos de los extremos
                    DibujarPetalConClip(g, lapiz, ruta, 42, -125, radio, escala);
                    DibujarPetalConClip(g, lapiz, ruta, 42, 125, radio, escala);
                    DibujarPetalConClip(g, lapiz, ruta, -42, 125, radio, escala);
                    DibujarPetalConClip(g, lapiz, ruta, -42, -125, radio, escala);

                    DibujarPetalConClip(g, lapiz, ruta, 85, -100, radio, escala);
                    DibujarPetalConClip(g, lapiz, ruta, 85, 100, radio, escala);
                    DibujarPetalConClip(g, lapiz, ruta, -85, 100, radio, escala);
                    DibujarPetalConClip(g, lapiz, ruta, -85, -100, radio, escala);

                    DibujarPetalConClip(g, lapiz, ruta, 131, -25, radio, escala);
                    DibujarPetalConClip(g, lapiz, ruta, 131, 25, radio, escala);
                    DibujarPetalConClip(g, lapiz, ruta, -131, 25, radio, escala);
                    DibujarPetalConClip(g, lapiz, ruta, -131, -25, radio, escala);
                }

                // Círculo exterior punteado
                int radioF = 105;
                float radioFEscalado = radioF * escala;
                g.DrawEllipse(lapizEntrecortado,
                    -radioFEscalado, -radioFEscalado,
                    radioFEscalado * 2, radioFEscalado * 2);
            }
        }

        private void AgregarCirculoEscalado(GraphicsPath path, int centroX, int centroY, int radio, float escala)
        {
            float x = centroX * escala;
            float y = centroY * escala;
            float r = radio * escala;
            path.AddEllipse(x - r, y - r, r * 2, r * 2);
        }

        private void DibujarPetalConClip(Graphics g, Pen lapiz, GraphicsPath clipPath,
            int centroX, int centroY, int radio, float escala)
        {
            using (GraphicsPath petal = new GraphicsPath())
            {
                AgregarCirculoEscalado(petal, centroX, centroY, radio, escala);
                g.SetClip(clipPath);
                g.DrawPath(lapiz, petal);
                g.ResetClip();
            }
        }

        private void DibujarPetalConClipCirculo(Graphics g, Pen lapiz,
            int clipX, int clipY, int petalX, int petalY, int radio, float escala)
        {
            using (GraphicsPath clipPath = new GraphicsPath())
            using (GraphicsPath petal = new GraphicsPath())
            {
                AgregarCirculoEscalado(clipPath, clipX, clipY, radio, escala);
                AgregarCirculoEscalado(petal, petalX, petalY, radio, escala);
                g.SetClip(clipPath);
                g.DrawPath(lapiz, petal);
                g.ResetClip();
            }
        }

        private void txtRadio_TextChanged(object sender, EventArgs e)
        {
            // Opcional: validación en tiempo real si lo deseas
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

        private void ptbGrafica_Click(object sender, EventArgs e)
        {
            // Opcional: puedes agregar funcionalidad aquí si lo necesitas
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
    }
}