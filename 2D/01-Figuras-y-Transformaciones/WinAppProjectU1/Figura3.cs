using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WinAppProjectU1
{
    public partial class Figura3 : Form
    {
        // --- Campos de la Clase ---
        private float currentRadioCm = 0;
        private FigureTransformer transformer;
        private bool isTranslating = false;

        // --- Constructor ---
        public Figura3()
        {
            InitializeComponent();
            transformer = new FigureTransformer();

            // Configuración del ScrollBar
            if (this.Controls.Find("hScrollBarEscala", true).Length > 0)
            {
                HScrollBar hScrollBarEscala = (HScrollBar)this.Controls.Find("hScrollBarEscala", true)[0];
                hScrollBarEscala.Minimum = 10;
                hScrollBarEscala.Maximum = 200;
                hScrollBarEscala.Value = 100;
                hScrollBarEscala.LargeChange = 10;
                hScrollBarEscala.SmallChange = 1;
                hScrollBarEscala.Scroll += hScrollBarEscala_Scroll;
            }

            ptbGrafica.Paint += ptbGrafica_Paint;
        }

        // --- Manejadores de Eventos de UI (Botones, Scroll, Teclado) ---

        private void btnGraficar_Click(object sender, EventArgs e)
        {
            if (float.TryParse(txtRadio.Text, out float radioIngresadoCm) && radioIngresadoCm > 0)
            {
                currentRadioCm = radioIngresadoCm;
                transformer.Reset();
                if (this.Controls.Find("hScrollBarEscala", true).Length > 0)
                {
                    ((HScrollBar)this.Controls.Find("hScrollBarEscala", true)[0]).Value = 100;
                }
                isTranslating = false;
                if (btnTrasladar != null)
                    btnTrasladar.Text = "Trasladar";
                ptbGrafica.Invalidate();
            }
            else
            {
                currentRadioCm = 0;
                ptbGrafica.Invalidate();
                MessageBox.Show("Ingrese un radio válido y positivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnResetear_Click(object sender, EventArgs e)
        {
            currentRadioCm = 0;
            txtRadio.Text = "";
            if (this.Controls.Find("hScrollBarEscala", true).Length > 0)
            {
                ((HScrollBar)this.Controls.Find("hScrollBarEscala", true)[0]).Value = 100;
            }
            transformer.Reset();
            isTranslating = false;
            if (btnTrasladar != null)
                btnTrasladar.Text = "Trasladar";
            ptbGrafica.Invalidate();
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
            ptbGrafica.Invalidate();
        }

        private void btnRotarDer_Click(object sender, EventArgs e)
        {
            transformer.Rotate(15.0f);
            ptbGrafica.Invalidate();
        }

        private void hScrollBarEscala_Scroll(object sender, ScrollEventArgs e)
        {
            float newScale = e.NewValue / 100.0f;
            transformer.SetScale(newScale);
            ptbGrafica.Invalidate();
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
                        transformer.Translate(-moveAmount, 0); handled = true; break;
                    case Keys.Right:
                        transformer.Translate(moveAmount, 0); handled = true; break;
                    case Keys.Up:
                        transformer.Translate(0, -moveAmount); handled = true; break;
                    case Keys.Down:
                        transformer.Translate(0, moveAmount); handled = true; break;
                }
                if (handled)
                {
                    ptbGrafica.Invalidate();
                    return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        // --- Lógica de Dibujo (Paint) ---

        private void ptbGrafica_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(Color.White);

            if (currentRadioCm <= 0) return;

            float dpi = g.DpiX;
            float pixelesPorCm = dpi / 2.54f;
            // Usamos un nombre de variable claro, ej: 'radioEnPixeles'
            float radioEnPixeles = currentRadioCm * pixelesPorCm;

            float cx = ptbGrafica.Width / 2f;
            float cy = ptbGrafica.Height / 2f;

            transformer.Center = new PointF(cx, cy);
            transformer.ApplyTransform(g);

            PointF centro = new PointF(cx, cy);

            for (int i = 0; i < 5; i++)
            {
                float rotationOffset = i * 72.0f;
                DrawSingleFigureInstance(g, centro, radioEnPixeles, rotationOffset);
            }
        }

        private void DrawSingleFigureInstance(Graphics g, PointF centroBase, float totalRadius, float offsetAngleDegrees)
        {
            // --- 0. Configuración Inicial ---
            float h = totalRadius / 12.0f;
            var points = new Dictionary<string, PointF>();

            // Ángulos base
            float ang_up_base = 90.0f;
            float ang_right_base = 90.0f - 36.0f; // 54.0f
            float ang_left_base = 90.0f + 36.0f; // 126.0f

            // Ángulos con el offset de rotación
            float ang_up = ang_up_base + offsetAngleDegrees;
            float ang_right = ang_right_base + offsetAngleDegrees;
            float ang_left = ang_left_base + offsetAngleDegrees;

            // --- 1. CÁLCULO DE TODOS LOS PUNTOS ---

            points["A"] = CalculatePoint(centroBase, h * 1, ang_up);
            points["B"] = CalculatePoint(centroBase, h * 7, ang_up);
            points["C"] = CalculatePoint(centroBase, h * 9, ang_up);
            points["D"] = CalculatePoint(centroBase, h * 11, ang_up);
            points["E"] = CalculatePoint(centroBase, h * 12, ang_up);

            points["J"] = CalculatePoint(centroBase, h * 1, ang_right);
            points["K"] = CalculatePoint(centroBase, h * 4, ang_right);
            points["L"] = CalculatePoint(centroBase, h * 11, ang_right);
            points["M"] = CalculatePoint(centroBase, h * 12, ang_right);

            points["N"] = CalculatePoint(centroBase, h * 1, ang_left);
            points["O"] = CalculatePoint(centroBase, h * 4, ang_left);
            points["P"] = CalculatePoint(centroBase, h * 11, ang_left);
            points["Q"] = CalculatePoint(centroBase, h * 12, ang_left);

            PointF C = points["C"];
            points["F"] = CalculatePoint(C, 1.5f * h, ang_up - 90);
            points["G"] = CalculatePoint(C, 3f * h, ang_up - 90);
            points["H"] = CalculatePoint(C, 1.5f * h, ang_up + 90);
            points["I"] = CalculatePoint(C, 3f * h, ang_up + 90);

            points["R"] = Lerp(points["I"], centroBase, 1 / 3.0f);
            points["S"] = Lerp(points["G"], centroBase, 1 / 3.0f);
            points["T"] = Lerp(points["I"], points["B"], 0.5f);
            points["U"] = Lerp(points["G"], points["B"], 0.5f);

            float dist_IR = GetDistance(points["I"], points["R"]);
            float t_V = (dist_IR == 0) ? 0 : h / dist_IR;
            points["V"] = Lerp(points["I"], points["R"], t_V);

            float dist_GS = GetDistance(points["G"], points["S"]);
            float t_W = (dist_GS == 0) ? 0 : h / dist_GS;
            points["W"] = Lerp(points["G"], points["S"], t_W);

            // --- 2. FASE DE DIBUJO (POR LÓGICA DE FORMA) ---

            // --- FASE DE RELLENO (NUEVO) ---
            // ¡Dibuja los rellenos PRIMERO, para que las líneas queden por encima!

            // Ejemplo 1: Rellenar el triángulo (B, H, I)
            //FillSection(g, Color.LightSkyBlue, points["B"], points["H"], points["I"]);

            // Ejemplo 2: Rellenar el triángulo (S, K, L)
            //FillSection(g, Color.LightCoral, points["S"], points["K"], points["L"]);


            // --- FASE DE LÍNEAS (Outlines) ---
            Pen penPrincipal = new Pen(Color.Black, 2);

            // Dibujo del "marco" exterior
            g.DrawLine(penPrincipal, points["Q"], points["E"]);
            g.DrawLine(penPrincipal, points["E"], points["M"]);
            g.DrawLine(penPrincipal, points["L"], points["M"]);
            g.DrawLine(penPrincipal, points["Q"], points["P"]);

            // Dibujo de la estructura interna (forma de "diamante" conectada a D)
            g.DrawLine(penPrincipal, points["P"], points["D"]);
            g.DrawLine(penPrincipal, points["D"], points["L"]);
            g.DrawLine(penPrincipal, points["D"], points["E"]);
            g.DrawLine(penPrincipal, points["I"], points["D"]);
            g.DrawLine(penPrincipal, points["G"], points["D"]);
            g.DrawLine(penPrincipal, points["H"], points["D"]);
            g.DrawLine(penPrincipal, points["F"], points["D"]);

            // Dibujo de las formas de "cometa" (Kite shapes) conectadas a B
            g.DrawLine(penPrincipal, points["I"], points["B"]);
            g.DrawLine(penPrincipal, points["G"], points["B"]);
            g.DrawLine(penPrincipal, points["H"], points["B"]);
            g.DrawLine(penPrincipal, points["F"], points["B"]);
            g.DrawLine(penPrincipal, points["I"], points["H"]);
            g.DrawLine(penPrincipal, points["F"], points["G"]);

            // Dibujo de la estrella interior (conexiones a R, S, V, W)
            g.DrawLine(penPrincipal, points["R"], points["P"]);
            g.DrawLine(penPrincipal, points["R"], points["O"]);
            g.DrawLine(penPrincipal, points["S"], points["K"]);
            g.DrawLine(penPrincipal, points["S"], points["L"]);
            g.DrawLine(penPrincipal, points["I"], points["R"]);
            g.DrawLine(penPrincipal, points["G"], points["S"]);
            g.DrawLine(penPrincipal, points["P"], points["I"]);
            g.DrawLine(penPrincipal, points["G"], points["L"]);
            g.DrawLine(penPrincipal, points["P"], points["V"]);
            g.DrawLine(penPrincipal, points["L"], points["W"]);

            // ARCO CENTRAL
            float gdi_startAngle = 360.0f - ang_left;
            float gdi_sweepAngle = ang_left - ang_right;
            RectangleF arcRect = new RectangleF(centroBase.X - h, centroBase.Y - h, h * 2, h * 2);
            g.DrawArc(penPrincipal, arcRect, gdi_startAngle, gdi_sweepAngle);

            // CONEXIONES AL ARCO
            List<string> connectPoints = new List<string> { "O", "R", "T", "B", "U", "S", "K" };
            foreach (string key in connectPoints)
            {
                if (points.ContainsKey(key))
                {
                    PointF p_outer = points[key];
                    float angleDeg = GetAngle(p_outer, centroBase);
                    PointF p_inner = CalculatePoint(centroBase, h, angleDeg);
                    g.DrawLine(penPrincipal, p_outer, p_inner);
                }
            }

            // Liberar recursos
            penPrincipal.Dispose();
        }

        // --- Funciones de Ayuda (Cálculos Matemáticos) ---

        /// <summary>
        /// Calcula un punto en un círculo dado un centro, radio y ángulo.
        /// El ángulo 0 es a la derecha, 90 es arriba.
        /// </summary>
        private PointF CalculatePoint(PointF center, float radius, float angleDegrees)
        {
            float angleRadians = (float)(angleDegrees * Math.PI / 180.0);
            return new PointF(
                center.X + radius * (float)Math.Cos(angleRadians),
                center.Y - radius * (float)Math.Sin(angleRadians)
            );
        }

        /// <summary>
        /// Interpolación Lineal (Lerp) entre dos puntos.
        /// </summary>
        private PointF Lerp(PointF p1, PointF p2, float t)
        {
            return new PointF(
                p1.X + (p2.X - p1.X) * t,
                p1.Y + (p2.Y - p1.Y) * t
            );
        }

        /// <summary>
        /// Calcula la distancia euclidiana entre dos puntos.
        /// </summary>
        private float GetDistance(PointF p1, PointF p2)
        {
            float dx = p2.X - p1.X;
            float dy = p2.Y - p1.Y;
            return (float)Math.Sqrt(dx * dx + dy * dy);
        }

        /// <summary>
        /// Obtiene el ángulo matemático (0=derecha, 90=arriba) de un punto
        /// relativo a un centro.
        /// </summary>
        private float GetAngle(PointF p, PointF center)
        {
            float dx = p.X - center.X;
            float dy = -(p.Y - center.Y); // Eje Y invertido en GDI+
            float angleRad = (float)Math.Atan2(dy, dx);
            float angleDeg = (float)(angleRad * 180.0 / Math.PI);

            if (angleDeg < 0) angleDeg += 360; // Asegurar rango 0-360

            return angleDeg;
        }

        /// <summary>
        /// Rellena un polígono (una sección) con un color específico.
        /// </summary>
        /// <param name="g">El objeto Graphics sobre el que se va a dibujar.</param>
        /// <param name="color">El color de relleno.</param>
        /// <param name="vertices">La lista de puntos (vértices) que definen la sección.
        /// Se pueden pasar como argumentos separados (p1, p2, p3...)
        /// o como un array new PointF[] {p1, p2, p3}.</param>
        private void FillSection(Graphics g, Color color, params PointF[] vertices)
        {
            // Asegurarse de que hay al menos 3 vértices para formar un polígono
            if (vertices != null && vertices.Length >= 3)
            {
                using (SolidBrush brush = new SolidBrush(color))
                {
                    g.FillPolygon(brush, vertices);
                }
            }
        }
    }

}