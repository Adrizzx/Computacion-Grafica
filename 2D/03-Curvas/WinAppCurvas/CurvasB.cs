using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WinAppCurvas
{
    public partial class CurvasB : Form
    {
        // Almacenamiento de puntos
        private List<PointF> puntosControl = new List<PointF>();

        // Variables para interacción con el mouse
        private int indicePuntoArrastrado = -1;
        private bool estaArrastrando = false;
        private const float RADIO_PUNTO = 6f;

        // Variables de animación
        private float t_animacion = 0.0f;
        private bool animando = false;
        private bool animacionFinalizada = false;

        public CurvasB()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbTipoCurva.SelectedIndex = 2; // Por defecto Bézier Cúbica
            ConfigurarEscenarioInicial();
            this.DoubleBuffered = true; // Evitar parpadeo
        }

        // Configura puntos predeterminados para que el usuario no vea la pantalla vacía
        private void ConfigurarEscenarioInicial()
        {
            puntosControl.Clear();
            int cy = pbLienzo.Height / 2;
            int cx = pbLienzo.Width / 2;

            // Agregamos puntos iniciales según el modo para demostración inmediata
            switch (cmbTipoCurva.SelectedIndex)
            {
                case 0: // Lineal (2 puntos)
                    puntosControl.Add(new PointF(100, cy));
                    puntosControl.Add(new PointF(pbLienzo.Width - 100, cy));
                    break;
                case 1: // Cuadrática (3 puntos)
                    puntosControl.Add(new PointF(100, cy));
                    puntosControl.Add(new PointF(cx, 50));
                    puntosControl.Add(new PointF(pbLienzo.Width - 100, cy));
                    break;
                case 2: // Cúbica (4 puntos)
                case 4: // B-Spline
                    puntosControl.Add(new PointF(100, cy));
                    puntosControl.Add(new PointF(cx - 100, 50));
                    puntosControl.Add(new PointF(cx + 100, pbLienzo.Height - 50));
                    puntosControl.Add(new PointF(pbLienzo.Width - 100, cy));
                    break;
                case 3: // N-Grados (ejemplo con 5)
                    puntosControl.Add(new PointF(50, cy));
                    puntosControl.Add(new PointF(200, 50));
                    puntosControl.Add(new PointF(400, cy + 100));
                    puntosControl.Add(new PointF(600, 50));
                    puntosControl.Add(new PointF(800, cy));
                    break;
            }
            pbLienzo.Invalidate();
        }

        #region Lógica de Dibujado (Paint)

        private void pbLienzo_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;

            // 1. Dibujar líneas poligonales (esqueleto) que conectan los puntos de control
            if (puntosControl.Count > 1)
            {
                using (Pen penGuias = new Pen(Color.LightGray, 1) { DashStyle = DashStyle.Dash })
                {
                    g.DrawLines(penGuias, puntosControl.ToArray());
                }
            }

            // 2. Dibujar la curva completa (Estática)
            // Si estamos animando, la curva se dibuja progresivamente hasta t_animacion
            // Si no estamos animando, se dibuja completa (t=1.0)
            float t_limite = animando ? t_animacion : 1.0f;

            if (cmbTipoCurva.SelectedIndex == 4) // B-Spline
            {
                DibujarBSpline(g, t_limite);
            }
            else // Bézier (Todos los grados)
            {
                DibujarBezier(g, t_limite);
            }

            // 3. Dibujar Puntos de Control
            for (int i = 0; i < puntosControl.Count; i++)
            {
                Brush b = (i == 0 || i == puntosControl.Count - 1) ? Brushes.Red : Brushes.Blue; // Extremos rojos
                if (cmbTipoCurva.SelectedIndex == 4) b = Brushes.Blue; // En B-Spline todos son controles externos

                float r = RADIO_PUNTO;
                g.FillEllipse(b, puntosControl[i].X - r, puntosControl[i].Y - r, r * 2, r * 2);
                g.DrawString($"P{i}", this.Font, Brushes.Black, puntosControl[i].X + 5, puntosControl[i].Y - 15);
            }

            // 4. Dibujar Líneas Constructivas (Algoritmo De Casteljau visual)
            // Solo si es Bézier, estamos animando y el checkbox está activado
            if (animando && chkVerLineas.Checked && cmbTipoCurva.SelectedIndex != 4 && puntosControl.Count > 1)
            {
                DibujarDeCasteljauRecursivo(g, puntosControl, t_animacion);
            }
        }

        // Algoritmo de Bézier dibujado punto a punto
        private void DibujarBezier(Graphics g, float tMax)
        {
            if (puntosControl.Count < 2) return;

            List<PointF> curva = new List<PointF>();

            // Resolución: cuantos más pasos, más suave.
            // Para dibujar la curva completa usamos muchos pasos.
            float paso = 0.005f;

            for (float t = 0; t <= tMax; t += paso)
            {
                curva.Add(CalcularPuntoBezier(puntosControl, t));
            }
            // Asegurar el último punto si tMax es 1
            if (tMax >= 1.0f) curva.Add(CalcularPuntoBezier(puntosControl, 1.0f));

            if (curva.Count > 1)
            {
                using (Pen penCurva = new Pen(Color.Black, 2))
                {
                    g.DrawLines(penCurva, curva.ToArray());
                }
            }

            // Dibujar el punto actual de la animación
            if (animando && curva.Count > 0)
            {
                PointF ultimo = curva[curva.Count - 1];
                g.FillEllipse(Brushes.Red, ultimo.X - 4, ultimo.Y - 4, 8, 8);
            }
        }

        // Cálculo matemático de un punto en la curva Bézier usando De Casteljau
        // Este método devuelve solo el punto final, no dibuja las líneas intermedias
        private PointF CalcularPuntoBezier(List<PointF> puntos, float t)
        {
            // Hacemos una copia para no modificar la lista original
            List<PointF> temp = new List<PointF>(puntos);
            int n = temp.Count - 1;

            for (int r = 1; r <= n; r++)
            {
                for (int i = 0; i <= n - r; i++)
                {
                    float x = (1 - t) * temp[i].X + t * temp[i + 1].X;
                    float y = (1 - t) * temp[i].Y + t * temp[i + 1].Y;
                    temp[i] = new PointF(x, y);
                }
            }
            return temp[0];
        }

        // DIBUJO RECURSIVO para visualización (Líneas Verdes)
        // Esto replica lo que se ve en las páginas web de ejemplo
        private void DibujarDeCasteljauRecursivo(Graphics g, List<PointF> puntos, float t)
        {
            if (puntos.Count <= 1) return;

            List<PointF> nuevosPuntos = new List<PointF>();

            // Color varía según la profundidad de recursión para mejor estética
            Color colorLinea = Color.FromArgb(100, 0, 255, 0); // Verde translúcido
            if (puntos.Count == 2) colorLinea = Color.Red; // La última línea es tangente

            using (Pen p = new Pen(colorLinea, 1))
            {
                for (int i = 0; i < puntos.Count - 1; i++)
                {
                    // Interpolación lineal
                    float x = (1 - t) * puntos[i].X + t * puntos[i + 1].X;
                    float y = (1 - t) * puntos[i].Y + t * puntos[i + 1].Y;
                    PointF pIntermedio = new PointF(x, y);
                    nuevosPuntos.Add(pIntermedio);

                    // Dibujar línea conectora entre interpolaciones actuales
                    if (puntos.Count > 2) // No dibujamos la línea sobre la curva final
                        g.DrawLine(p, puntos[i], puntos[i + 1]);

                    // Dibujar el punto interpolado
                    g.FillEllipse(Brushes.Green, x - 3, y - 3, 6, 6);
                }

                // Si tenemos puntos interpolados, dibujar la línea que los une
                if (nuevosPuntos.Count > 1)
                    g.DrawLines(p, nuevosPuntos.ToArray());
            }

            // Recursión: repetir el proceso con los nuevos puntos
            DibujarDeCasteljauRecursivo(g, nuevosPuntos, t);
        }

        // Implementación básica de B-Spline Uniforme Cúbica
        private void DibujarBSpline(Graphics g, float tMax)
        {
            // B-Spline Cúbica necesita al menos 4 puntos
            if (puntosControl.Count < 4) return;

            List<PointF> curva = new List<PointF>();
            float paso = 0.01f;

            // En B-Spline uniforme, la curva se define por segmentos entre puntos P1..Pn-2
            // Usamos base Functions.
            // Iteramos sobre los segmentos
            int numSegmentos = puntosControl.Count - 3;

            // Ajustamos tMax al total de segmentos para la animación
            float tTotal = numSegmentos * tMax;

            for (int i = 0; i < numSegmentos; i++)
            {
                for (float t = 0; t <= 1; t += paso)
                {
                    // Si estamos animando, cortamos si superamos el tiempo global
                    if (i + t > tTotal) break;

                    curva.Add(CalcularPuntoBSpline(i, t));
                }
            }

            if (curva.Count > 1)
            {
                using (Pen penSpline = new Pen(Color.Purple, 2))
                {
                    g.DrawLines(penSpline, curva.ToArray());
                }
            }
        }

        private PointF CalcularPuntoBSpline(int i, float t)
        {
            // Puntos de control locales para este segmento
            PointF p0 = puntosControl[i];
            PointF p1 = puntosControl[i + 1];
            PointF p2 = puntosControl[i + 2];
            PointF p3 = puntosControl[i + 3];

            // Coeficientes de base B-Spline Cúbica Uniforme
            float t2 = t * t;
            float t3 = t * t * t;

            float b0 = (-t3 + 3 * t2 - 3 * t + 1) / 6.0f;
            float b1 = (3 * t3 - 6 * t2 + 4) / 6.0f;
            float b2 = (-3 * t3 + 3 * t2 + 3 * t + 1) / 6.0f;
            float b3 = t3 / 6.0f;

            float x = b0 * p0.X + b1 * p1.X + b2 * p2.X + b3 * p3.X;
            float y = b0 * p0.Y + b1 * p1.Y + b2 * p2.Y + b3 * p3.Y;

            return new PointF(x, y);
        }

        #endregion

        #region Interacción Mouse (Drag & Drop)

        private void pbLienzo_MouseDown(object sender, MouseEventArgs e)
        {
            // 1. Verificar si se hizo click sobre un punto existente
            for (int i = 0; i < puntosControl.Count; i++)
            {
                if (Distancia(e.Location, puntosControl[i]) < RADIO_PUNTO + 5)
                {
                    indicePuntoArrastrado = i;
                    estaArrastrando = true;
                    return; // Encontramos un punto, salimos
                }
            }

            // 2. Si no es arrastrar y es click derecho -> Eliminar último
            if (e.Button == MouseButtons.Right)
            {
                if (puntosControl.Count > 0)
                {
                    puntosControl.RemoveAt(puntosControl.Count - 1);
                    pbLienzo.Invalidate();
                }
                return;
            }

            // 3. Si no es arrastrar y es click izquierdo -> Agregar nuevo punto
            // (Solo si el modo permite N puntos, o si faltan puntos para los modos fijos)
            int limitePuntos = ObtenerLimitePuntos();
            if (limitePuntos == -1 || puntosControl.Count < limitePuntos)
            {
                puntosControl.Add(e.Location);
                pbLienzo.Invalidate();
            }
        }

        private void pbLienzo_MouseMove(object sender, MouseEventArgs e)
        {
            if (estaArrastrando && indicePuntoArrastrado != -1)
            {
                // Limitar coordenadas al lienzo
                float x = Math.Max(0, Math.Min(pbLienzo.Width, e.X));
                float y = Math.Max(0, Math.Min(pbLienzo.Height, e.Y));

                puntosControl[indicePuntoArrastrado] = new PointF(x, y);

                // Si la animación terminó, permitir arrastrar viendo el resultado final
                if (animacionFinalizada) t_animacion = 1.0f;
                else if (!animando) t_animacion = 1.0f; // Vista previa estática

                pbLienzo.Invalidate();
            }
        }

        private void pbLienzo_MouseUp(object sender, MouseEventArgs e)
        {
            estaArrastrando = false;
            indicePuntoArrastrado = -1;
        }

        private float Distancia(Point p1, PointF p2)
        {
            return (float)Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }

        private int ObtenerLimitePuntos()
        {
            switch (cmbTipoCurva.SelectedIndex)
            {
                case 0: return 2; // Lineal
                case 1: return 3; // Cuadrática
                case 2: return 4; // Cúbica
                default: return -1; // N y Spline (sin límite fijo superior)
            }
        }

        #endregion

        #region Control de UI y Animación

        private void cmbTipoCurva_SelectedIndexChanged(object sender, EventArgs e)
        {
            DetenerAnimacion();
            ConfigurarEscenarioInicial(); // Reiniciar puntos para coincidir con el modo
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            DetenerAnimacion();
            puntosControl.Clear();
            pbLienzo.Invalidate();
        }

        private void btnAnimar_Click(object sender, EventArgs e)
        {
            if (puntosControl.Count < 2) return;

            // Reiniciar animación
            t_animacion = 0.0f;
            animando = true;
            animacionFinalizada = false;
            tmrAnimacion.Start();
            btnAnimar.Enabled = false;
            cmbTipoCurva.Enabled = false;
        }

        private void tmrAnimacion_Tick(object sender, EventArgs e)
        {
            t_animacion += 0.01f; // Velocidad de la animación

            if (t_animacion >= 1.0f)
            {
                t_animacion = 1.0f;
                DetenerAnimacion();
                animacionFinalizada = true; // Flag para mantener el dibujo completo
                pbLienzo.Invalidate();
            }
            else
            {
                lblTValue.Text = $"t = {t_animacion:0.00}";
                pbLienzo.Invalidate(); // Redibujar cuadro
            }
        }

        private void DetenerAnimacion()
        {
            tmrAnimacion.Stop();
            animando = false;
            btnAnimar.Enabled = true;
            cmbTipoCurva.Enabled = true;
            lblTValue.Text = "t = 1.00";
        }

        private void chkVerLineas_CheckedChanged(object sender, EventArgs e)
        {
            pbLienzo.Invalidate();
        }

        #endregion

        private void pbLienzo_Click(object sender, EventArgs e)
        {

        }
    }
}