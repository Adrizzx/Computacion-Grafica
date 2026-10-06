using System;
using System.Collections.Generic; // Necesario para List<>
using System.Drawing;
using System.Drawing.Drawing2D; // Necesario para SmoothingMode
using System.Linq; // Necesario para OrderBy
using System.Windows.Forms;

namespace WinAppProjectU1
{
    public partial class Figura2 : Form
    {
        // --- Campos de la Clase ---
        private float currentApotema = 0;
        private FigureTransformer transformer;
        private bool isTranslating = false;

        // --- Constructor ---
        public Figura2()
        {
            InitializeComponent();
            transformer = new FigureTransformer();

            // Configuración del ScrollBar
            hScrollBarEscala.Minimum = 10;
            hScrollBarEscala.Maximum = 200;
            hScrollBarEscala.Value = 100;
            hScrollBarEscala.LargeChange = 10;
            hScrollBarEscala.SmallChange = 1;

            ptbGrafica.Paint += ptbGrafica_Paint;
        }

        // --- Manejadores de Eventos de UI ---

        private void btnGraficar_Click(object sender, EventArgs e)
        {
            if (float.TryParse(txtRadio.Text, out float apotema) && apotema > 0)
            {
                currentApotema = apotema;
                transformer.Reset();
                hScrollBarEscala.Value = 100;
                isTranslating = false;

                if (btnTrasladar != null)
                {
                    btnTrasladar.Text = "Trasladar";
                }

                ptbGrafica.Invalidate();
            }
            else
            {
                currentApotema = 0;
                ptbGrafica.Invalidate();
                MessageBox.Show("Ingrese una apotema válida y positiva.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnResetear_Click(object sender, EventArgs e)
        {
            currentApotema = 0;
            txtRadio.Text = "";
            hScrollBarEscala.Value = 100;
            transformer.Reset();
            isTranslating = false;

            if (btnTrasladar != null)
            {
                btnTrasladar.Text = "Trasladar";
            }

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
            // Usar e.NewValue es más preciso y consistente
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
                    ptbGrafica.Invalidate();
                    return true;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        // --- Lógica de Dibujo ---

        private void ptbGrafica_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(Color.White);

            if (currentApotema <= 0)
                return;

            float dpi = g.DpiX;
            float pixelesPorCm = dpi / 5.00f;
            // Creamos la nueva variable con el valor en píxeles
            float apotemaEnPixeles = currentApotema * pixelesPorCm;

            float cx = ptbGrafica.Width / 2f;
            float cy = ptbGrafica.Height / 2f;

            // APLICAR TRANSFORMACIONES
            transformer.Center = new PointF(cx, cy);
            transformer.ApplyTransform(g);

            DibujarPentagonoYEstrella(g, cx, cy, apotemaEnPixeles);
        }

        private void DibujarPentagonoYEstrella(Graphics g, float cx, float cy, float apotema)
        {
            double PI = Math.PI;

            // --- 1. CÁLCULO DE PUNTOS Y LÍNEAS ---

            // Pentágono principal
            float R = apotema / (float)Math.Cos(PI / 5);
            PointF[] pentPrincipal = CrearPoligono(cx, cy, R, 5, -90);

            // Pentágonos grandes rotados
            float scaleLarge = 1.529f;
            float apotemaLarge = apotema * scaleLarge;
            float RLarge = apotemaLarge / (float)Math.Cos(PI / 5);
            PointF[] pentLargeRight = CrearPoligono(cx, cy, RLarge, 5, 12 - 90);
            PointF[] pentLargeLeft = CrearPoligono(cx, cy, RLarge, 5, -12 - 90);

            // Pentágono central pequeño e INVERTIDO
            float apotemaPequeno = apotema / 6.375f;
            float RPequeno = apotemaPequeno / (float)Math.Cos(PI / 5);
            PointF[] pentPequeno = CrearPoligono(cx, cy, RPequeno, 5, -90 + 36);

            // CALCULAR LAS 5 PUNTAS DE LA ESTRELLA PEQUEÑA (los "triángulos")
            float extensionPequena = apotemaPequeno * 2f;
            PointF[] puntasEstrellaPequena = GetPequenoStarTips(pentPequeno, cx, cy, extensionPequena);

            // CALCULAR LÍNEAS Y CRUCES DE LA ESTRELLA PRINCIPAL
            List<LineF> starLines = GetStarLines(pentPrincipal);
            List<PointF> crossings = new List<PointF>();
            PointF? c0 = FindIntersection(starLines[0], starLines[3]);
            PointF? c1 = FindIntersection(starLines[2], starLines[5]);
            PointF? c2 = FindIntersection(starLines[4], starLines[7]);
            PointF? c3 = FindIntersection(starLines[6], starLines[9]);
            PointF? c4 = FindIntersection(starLines[8], starLines[1]);

            if (c0.HasValue) crossings.Add(c0.Value);
            if (c1.HasValue) crossings.Add(c1.Value);
            if (c2.HasValue) crossings.Add(c2.Value);
            if (c3.HasValue) crossings.Add(c3.Value);
            if (c4.HasValue) crossings.Add(c4.Value);


            // --- 2. FASE DE DIBUJO ---

            // --- FASE DE RELLENO ---
            // ¡Dibuja los rellenos PRIMERO, para que las líneas queden por encima!

            // Ejemplo 1: Rellenar el pentágono central pequeño
            //FillSection(g, Color.LightBlue, pentPequeno);

            // Ejemplo 2: Rellenar el pentágono principal (el grande del centro)
            // FillSection(g, Color.LightYellow, pentPrincipal);

            // Ejemplo 3: Rellenar el pentágono formado por los cruces de la estrella
            // (Asegúrate de que 'crossings' tenga 5 puntos antes de descomentar)
            // if (crossings.Count == 5)
            // {
            //     FillSection(g, Color.LightCoral, crossings.ToArray());
            // }

            // *** EJEMPLO 4 ***
            // Rellenar uno de los "brazos" exteriores derechos (un cuadrilátero)
            // Los puntos son: pentLargeRight[0], pentPrincipal[1], pentPrincipal[2], pentLargeRight[1]
            /*if (pentLargeRight.Length >= 2 && pentPrincipal.Length >= 3)
            {
                PointF[] brazoDerecho = new PointF[]
                {
                    pentLargeRight[0], // Vértice 0 del pentágono grande derecho
                    pentPrincipal[1],  // Vértice 1 del pentágono principal
                    pentPrincipal[2],  // Vértice 2 del pentágono principal
                    pentLargeRight[1]  // Vértice 1 del pentágono grande derecho
                };
                FillSection(g, Color.LightGreen, brazoDerecho);
            }*/


            // --- FASE DE LÍNEAS ---
            // Se crea un solo lápiz para todas las líneas negras
            using (var pen = new Pen(Color.Black, 2))
            {
                // Dibujar los 3 pentágonos base
                g.DrawPolygon(pen, pentPrincipal);
                g.DrawPolygon(pen, pentLargeRight);
                g.DrawPolygon(pen, pentLargeLeft);
                g.DrawPolygon(pen, pentPequeno);

                // DIBUJAR LÍNEAS DESDE LOS VÉRTICES DEL PENTÁGONO PEQUEÑO
                DibujarLineasDesdeVertices(g, pentPequeno, apotemaPequeno, pen);

                // DIBUJAR LÍNEAS DESDE LOS VÉRTICES DEL PENTÁGONO PRINCIPAL
                DibujarLineasPentagonPrincipal(g, pentPrincipal, pen);

                // Lógica de "Líneas rojas internas" (ahora negras)
                foreach (PointF crossing in crossings)
                {
                    var nearestTwo = FindNearestVertices(crossing, puntasEstrellaPequena);
                    if (nearestTwo != null)
                    {
                        g.DrawLine(pen, crossing, nearestTwo.Item1);
                        g.DrawLine(pen, crossing, nearestTwo.Item2);
                    }
                }

                // Lógica de "Líneas azules internas" (ahora negras)
                int nPrincipal = pentPrincipal.Length;
                for (int i = 0; i < nPrincipal; i++)
                {
                    PointF p1 = pentPrincipal[i];
                    PointF p2 = pentPrincipal[(i + 1) % nPrincipal];
                    PointF midpointPrincipal = Midpoint(p1, p2);

                    var nearestTwoPequenoTips = FindNearestVertices(midpointPrincipal, puntasEstrellaPequena);
                    if (nearestTwoPequenoTips != null)
                    {
                        g.DrawLine(pen, midpointPrincipal, nearestTwoPequenoTips.Item1);
                        g.DrawLine(pen, midpointPrincipal, nearestTwoPequenoTips.Item2);
                    }
                }

                // Lógica de "Líneas Grandes" (conexiones)
                int n = pentPrincipal.Length; // n es 5
                for (int i = 0; i < n; i++)
                {
                    // pentLargeRight[i] -> pentPrincipal[(i + 1) % n] (derecha)
                    g.DrawLine(pen, pentLargeRight[i], pentPrincipal[(i + 1) % n]);

                    // pentLargeLeft[i] -> pentPrincipal[(i + 4) % n] (izquierda)
                    g.DrawLine(pen, pentLargeLeft[i], pentPrincipal[(i + 4) % n]);
                }
            }
        } // Fin de DibujarPentagonoYEstrella

        // --- Funciones de Ayuda (Cálculos y Dibujo) ---

        private void DibujarLineasDesdeVertices(Graphics g, PointF[] vertices, float apotema, Pen pen)
        {
            int n = vertices.Length;

            // Optimización: Calcular el centro (cx, cy) una sola vez
            float cx = 0, cy = 0;
            foreach (var v in vertices)
            {
                cx += v.X;
                cy += v.Y;
            }
            cx /= n;
            cy /= n;

            float extension = apotema * 2f;

            for (int i = 0; i < n; i++)
            {
                PointF v1 = vertices[i];
                PointF vPrev = vertices[(i - 1 + n) % n];
                PointF vNext = vertices[(i + 1) % n];

                PointF centroLadoIzq = Midpoint(vPrev, v1);
                PointF centroLadoDer = Midpoint(v1, vNext);

                float dx1 = centroLadoIzq.X - cx;
                float dy1 = centroLadoIzq.Y - cy;
                float len1 = (float)Math.Sqrt(dx1 * dx1 + dy1 * dy1);
                PointF puntoExtIzq = new PointF(
                    centroLadoIzq.X + (dx1 / len1) * extension,
                    centroLadoIzq.Y + (dy1 / len1) * extension
                );

                float dx2 = centroLadoDer.X - cx;
                float dy2 = centroLadoDer.Y - cy;
                float len2 = (float)Math.Sqrt(dx2 * dx2 + dy2 * dy2);
                PointF puntoExtDer = new PointF(
                    centroLadoDer.X + (dx2 / len2) * extension,
                    centroLadoDer.Y + (dy2 / len2) * extension
                );

                g.DrawLine(pen, v1, puntoExtIzq);
                g.DrawLine(pen, v1, puntoExtDer);
            }
        }

        private void DibujarLineasPentagonPrincipal(Graphics g, PointF[] vertices, Pen pen)
        {
            int n = vertices.Length;
            for (int i = 0; i < n; i++)
            {
                PointF verticeActual = vertices[i];

                int idx1 = (i + 1) % n;
                int idx2 = (i + 2) % n;
                int idx3 = (i + 3) % n;
                int idx4 = (i + 4) % n;

                PointF puntoMedio1 = Midpoint(vertices[idx1], vertices[idx2]);
                PointF puntoMedio2 = Midpoint(vertices[idx3], vertices[idx4]);

                g.DrawLine(pen, verticeActual, puntoMedio1);
                g.DrawLine(pen, verticeActual, puntoMedio2);
            }
        }

        private PointF[] CrearPoligono(float cx, float cy, float radio, int lados, float anguloInicialGrados)
        {
            PointF[] puntos = new PointF[lados];
            double anguloInicial = anguloInicialGrados * Math.PI / 180.0;
            for (int i = 0; i < lados; i++)
            {
                double angle = anguloInicial + 2 * Math.PI * i / lados;
                puntos[i] = new PointF(
                    cx + radio * (float)Math.Cos(angle),
                    cy + radio * (float)Math.Sin(angle)
                );
            }
            return puntos;
        }

        private struct LineF
        {
            public PointF P1, P2;
            public LineF(PointF p1, PointF p2) { P1 = p1; P2 = p2; }
        }

        private PointF Midpoint(PointF p1, PointF p2)
        {
            return new PointF((p1.X + p2.X) / 2f, (p1.Y + p2.Y) / 2f);
        }

        private List<LineF> GetStarLines(PointF[] vertices)
        {
            List<LineF> lines = new List<LineF>();
            int n = vertices.Length;
            for (int i = 0; i < n; i++)
            {
                PointF verticeActual = vertices[i];
                PointF puntoMedio1 = Midpoint(vertices[(i + 1) % n], vertices[(i + 2) % n]);
                PointF puntoMedio2 = Midpoint(vertices[(i + 3) % n], vertices[(i + 4) % n]);
                lines.Add(new LineF(verticeActual, puntoMedio1));
                lines.Add(new LineF(verticeActual, puntoMedio2));
            }
            return lines;
        }

        private Tuple<PointF, PointF> FindNearestVertices(PointF point, PointF[] vertices)
        {
            if (vertices == null || vertices.Length < 2)
                return null;

            // Usar 'var' para mantener la consistencia
            var distances = vertices.Select(v => new
            {
                Vertex = v,
                DistanceSq = (point.X - v.X) * (point.X - v.X) + (point.Y - v.Y) * (point.Y - v.Y)
            })
            .OrderBy(d => d.DistanceSq)
            .ToList();

            return Tuple.Create(distances[0].Vertex, distances[1].Vertex);
        }

        private PointF? FindIntersection(LineF line1, LineF line2)
        {
            PointF p1 = line1.P1, p2 = line1.P2, p3 = line2.P1, p4 = line2.P2;

            float den = (p1.X - p2.X) * (p3.Y - p4.Y) - (p1.Y - p2.Y) * (p3.X - p4.X);
            if (den == 0)
                return null;

            float t = ((p1.X - p3.X) * (p3.Y - p4.Y) - (p1.Y - p3.Y) * (p3.X - p4.X)) / den;
            float u = -((p1.X - p2.X) * (p1.Y - p3.Y) - (p1.Y - p2.Y) * (p1.X - p3.X)) / den;

            if (t >= 0 && t <= 1 && u >= 0 && u <= 1)
            {
                return new PointF(
                    p1.X + t * (p2.X - p1.X),
                    p1.Y + t * (p2.Y - p1.Y)
                );
            }

            return null;
        }

        private PointF[] GetPequenoStarTips(PointF[] vertices, float cx, float cy, float extension)
        {
            int n = vertices.Length;
            PointF[] tips = new PointF[n];

            for (int i = 0; i < n; i++)
            {
                PointF v1 = vertices[i];
                PointF vNext = vertices[(i + 1) % n];

                PointF centroLadoDer = Midpoint(v1, vNext);

                float dx = centroLadoDer.X - cx;
                float dy = centroLadoDer.Y - cy;
                float len = (float)Math.Sqrt(dx * dx + dy * dy);

                if (len == 0)
                {
                    tips[i] = centroLadoDer;
                }
                else
                {
                    tips[i] = new PointF(
                        centroLadoDer.X + (dx / len) * extension,
                        centroLadoDer.Y + (dy / len) * extension
                    );
                }
            }
            return tips;
        }

        /// <summary>
        /// Rellena un polígono (una sección) con un color específico.
        /// </summary>
        /// <param name="g">El objeto Graphics sobre el que se va a dibujar.</param>
        /// <param name="color">El color de relleno.</param>
        /// <param name="vertices">La lista de puntos (vértices) que definen la sección.
        /// Se pueden pasar como argumentos separados (p1, p2, p3...)
        /// o como un array new PointF[] {p1, p2, p3}.</áparam>
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

        private void txtRadio_TextChanged(object sender, EventArgs e)
        {
        }
    }

}