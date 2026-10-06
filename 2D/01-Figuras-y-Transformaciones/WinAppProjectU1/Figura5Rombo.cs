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
    public partial class Figura5Rombo : Form
    {
        private FigureTransformer transformer;
        private float currentRadioCm = 0;
        private bool isTranslating = false;

        public Figura5Rombo()
        {
            InitializeComponent();
            transformer = new FigureTransformer();
        }

        private void Figura5Rombo_Load(object sender, EventArgs e)
        {
            hScrollBarEscala.Minimum = 10;
            hScrollBarEscala.Maximum = 200;
            hScrollBarEscala.Value = 100;
            hScrollBarEscala.LargeChange = 10;
            hScrollBarEscala.SmallChange = 1;
        }

        /// <summary>
        /// Dibuja la figura: 6 hexágonos pequeños con 4 niveles concéntricos cada uno
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

            Bitmap bmp = new Bitmap(ptbGrafica.Width, ptbGrafica.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.FromArgb(20, 30, 50)); // Azul oscuro

                // Conversión de cm a píxeles con ajuste de escala
                float dpi = g.DpiX;
                float pixelesPorCm = dpi / 2.54f;
                float radio = currentRadioCm * pixelesPorCm * 0.6f; // Factor de escala para ajustar al tamaño del canvas

                PointF center = new PointF(ptbGrafica.Width / 2f, ptbGrafica.Height / 2f);

                transformer.Center = center;
                transformer.ApplyTransform(g);

                using (Pen whitePen = new Pen(Color.White, 2.5f))
                {
                    // Dibujar la flor hexagonal
                    DrawHexagonFlower(g, whitePen, center, radio);
                }
            }

            if (ptbGrafica.Image != null)
            {
                ptbGrafica.Image.Dispose();
            }
            ptbGrafica.Image = bmp;
        }

        /// <summary>
        /// Dibuja la flor hexagonal completa (6 hexágonos con 4 niveles cada uno)
        /// Basado en la lógica del código de referencia
        /// </summary>
        private void DrawHexagonFlower(Graphics g, Pen pen, PointF center, float radio)
        {
            // Puntos de los 6 hexágonos principales alrededor del centro
            PointF[] mainHexPoints = new PointF[6];

            // Calcular los 6 puntos principales (centros de los hexágonos pequeños)
            // Ángulo inicial: -0.523599 radianes (-30°)
            float tethaAdd = 0.0f; // Puede ajustarse para rotación

            for (int i = 0; i < 6; i++)
            {
                float tetha = (float)((i * 1.0472) + tethaAdd - 0.523599); // 1.0472 rad = 60°
                mainHexPoints[i] = new PointF(
                    (float)(center.X + radio * Math.Cos(tetha)),
                    (float)(center.Y + radio * Math.Sin(tetha))
                );
            }

            // Dibujar líneas desde el centro a cada punto principal
            for (int i = 0; i < 6; i++)
            {
                g.DrawLine(pen, center, mainHexPoints[i]);
            }

            // Para cada uno de los 6 hexágonos principales
            for (int j = 0; j < 6; j++)
            {
                // Dibujar 5 niveles de hexágonos concéntricos (4 niveles internos + el contorno)
                for (int k = 0; k < 5; k++)
                {
                    PointF[] hexPoints = new PointF[6];

                    // Calcular los 6 vértices del hexágono en este nivel
                    for (int i = 0; i < 6; i++)
                    {
                        // Ángulo base: -1.5708 rad (-90°) + offset del sector j
                        float tetha = (float)((i * 1.0472) + tethaAdd - 1.5708 + (1.0472 * j));

                        // Radio del nivel actual (escala de 0.2 por cada nivel)
                        float currentRadius = radio * 0.2f * (k + 1);

                        hexPoints[i] = new PointF(
                            (float)(mainHexPoints[j].X + currentRadius * Math.Cos(tetha)),
                            (float)(mainHexPoints[j].Y + currentRadius * Math.Sin(tetha))
                        );
                    }

                    // Dibujar las 4 primeras aristas del hexágono
                    // (las últimas 2 se comparten con hexágonos vecinos)
                    for (int i = 0; i < 4; i++)
                    {
                        g.DrawLine(pen, hexPoints[i], hexPoints[i + 1]);
                    }
                }
            }
        }

        private void txtRadio_TextChanged(object sender, EventArgs e)
        {
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

        private void ptbGrafica_Click(object sender, EventArgs e)
        {
        }

        private void lblRadio_Click(object sender, EventArgs e)
        {
        }
    }
}