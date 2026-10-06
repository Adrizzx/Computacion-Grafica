using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq; // Necesario para OrderBy
using System.Windows.Forms;

namespace WinAppTodosAlgoritmos
{
    public class CRecorte
    {
        private Bitmap mBitmap;

        // Ventana de recorte (Xmin, Ymin, Xmax, Ymax)
        private Rectangle ventana;

        // Códigos de región para Cohen-Sutherland
        private const int INSIDE = 0; // 0000
        private const int LEFT = 1;   // 0001
        private const int RIGHT = 2;  // 0010
        private const int BOTTOM = 4; // 0100
        private const int TOP = 8;    // 1000

        public CRecorte()
        {
            ventana = new Rectangle(50, 50, 200, 200);
        }

        public void Inicializar(PictureBox canvas)
        {
            if (canvas.Width > 0 && canvas.Height > 0)
            {
                mBitmap = new Bitmap(canvas.Width, canvas.Height);

                // Calcular ventana centrada (60% del tamaño del canvas)
                int w = (int)(canvas.Width * 0.6);
                int h = (int)(canvas.Height * 0.6);
                int x = (canvas.Width - w) / 2;
                int y = (canvas.Height - h) / 2;

                ventana = new Rectangle(x, y, w, h);

                DibujarVentana();
                canvas.Image = mBitmap;
            }
        }

        private void DibujarVentana()
        {
            using (Graphics g = Graphics.FromImage(mBitmap))
            {
                g.Clear(Color.White);

                // Grid
                using (Pen pGrid = new Pen(Color.FromArgb(240, 240, 240)))
                {
                    for (int x = 0; x < mBitmap.Width; x += 20) g.DrawLine(pGrid, x, 0, x, mBitmap.Height);
                    for (int y = 0; y < mBitmap.Height; y += 20) g.DrawLine(pGrid, 0, y, mBitmap.Width, y);
                }

                // Ventana
                using (Pen pVentana = new Pen(Color.Blue, 3))
                {
                    g.DrawRectangle(pVentana, ventana);
                }

                using (SolidBrush bBlue = new SolidBrush(Color.Blue))
                {
                    g.DrawString("Ventana de Recorte", new Font("Arial", 10, FontStyle.Bold), bBlue, ventana.X, ventana.Y - 20);
                }
            }
        }

        public void DibujarEntrada(List<Point> puntos, bool esPoligono, PictureBox canvas)
        {
            if (puntos.Count < 1) return;

            DibujarVentana();

            using (Graphics g = Graphics.FromImage(mBitmap))
            {
                using (Pen p = new Pen(Color.Gray, 2) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash })
                {
                    if (puntos.Count == 1)
                    {
                        g.FillEllipse(Brushes.Black, puntos[0].X - 3, puntos[0].Y - 3, 6, 6);
                    }
                    else
                    {
                        if (esPoligono && puntos.Count > 1)
                        {
                            g.DrawLines(p, puntos.ToArray());
                            if (puntos.Count > 2) g.DrawLine(p, puntos[puntos.Count - 1], puntos[0]);
                        }
                        else if (!esPoligono && puntos.Count == 2)
                        {
                            g.DrawLine(p, puntos[0], puntos[1]);
                        }

                        foreach (var pt in puntos) g.FillEllipse(Brushes.Black, pt.X - 3, pt.Y - 3, 6, 6);
                    }
                }
            }
            canvas.Refresh();
        }

        // ========================================================
        // 1. COHEN-SUTHERLAND
        // ========================================================
        private int ComputeCode(double x, double y)
        {
            int code = INSIDE;
            if (x < ventana.Left) code |= LEFT;
            else if (x > ventana.Right) code |= RIGHT;
            if (y < ventana.Top) code |= TOP;
            else if (y > ventana.Bottom) code |= BOTTOM;
            return code;
        }

        public void RecortarLineaCohenSutherland(Point p1, Point p2, PictureBox canvas, bool esPartePoligono = false)
        {
            double x1 = p1.X, y1 = p1.Y;
            double x2 = p2.X, y2 = p2.Y;

            int code1 = ComputeCode(x1, y1);
            int code2 = ComputeCode(x2, y2);
            bool accept = false;

            while (true)
            {
                if ((code1 | code2) == 0) { accept = true; break; }
                else if ((code1 & code2) != 0) { break; }
                else
                {
                    int codeOut = (code1 != 0) ? code1 : code2;
                    double x = 0, y = 0;

                    if ((codeOut & TOP) != 0) { x = x1 + (x2 - x1) * (ventana.Top - y1) / (y2 - y1); y = ventana.Top; }
                    else if ((codeOut & BOTTOM) != 0) { x = x1 + (x2 - x1) * (ventana.Bottom - y1) / (y2 - y1); y = ventana.Bottom; }
                    else if ((codeOut & RIGHT) != 0) { y = y1 + (y2 - y1) * (ventana.Right - x1) / (x2 - x1); x = ventana.Right; }
                    else if ((codeOut & LEFT) != 0) { y = y1 + (y2 - y1) * (ventana.Left - x1) / (x2 - x1); x = ventana.Left; }

                    if (codeOut == code1) { x1 = x; y1 = y; code1 = ComputeCode(x1, y1); }
                    else { x2 = x; y2 = y; code2 = ComputeCode(x2, y2); }
                }
            }

            if (accept)
            {
                Color c = esPartePoligono ? Color.Purple : Color.Red;
                string nombre = esPartePoligono ? "" : "Cohen-Sutherland";
                DibujarLineaResultado((int)x1, (int)y1, (int)x2, (int)y2, c, nombre, canvas);
            }
        }

        // ========================================================
        // 2. LIANG-BARSKY
        // ========================================================
        private bool ClipTest(float p, float q, ref float u1, ref float u2)
        {
            if (p < 0.0) { float r = q / p; if (r > u2) return false; if (r > u1) u1 = r; }
            else if (p > 0.0) { float r = q / p; if (r < u1) return false; if (r < u2) u2 = r; }
            else if (q < 0.0) return false;
            return true;
        }

        public void RecortarLineaLiangBarsky(Point p1, Point p2, PictureBox canvas, bool esPartePoligono = false)
        {
            float u1 = 0.0f, u2 = 1.0f;
            float dx = p2.X - p1.X, dy = p2.Y - p1.Y;

            if (ClipTest(-dx, p1.X - ventana.Left, ref u1, ref u2) &&
                ClipTest(dx, ventana.Right - p1.X, ref u1, ref u2) &&
                ClipTest(-dy, p1.Y - ventana.Top, ref u1, ref u2) &&
                ClipTest(dy, ventana.Bottom - p1.Y, ref u1, ref u2))
            {
                int x1_new = (int)(p1.X + u1 * dx);
                int y1_new = (int)(p1.Y + u1 * dy);
                int x2_new = (int)(p1.X + u2 * dx);
                int y2_new = (int)(p1.Y + u2 * dy);

                Color c = esPartePoligono ? Color.DarkOrange : Color.Green;
                string nombre = esPartePoligono ? "" : "Liang-Barsky";
                DibujarLineaResultado(x1_new, y1_new, x2_new, y2_new, c, nombre, canvas);
            }
        }

        // ========================================================
        // 3. EXPLÍCITO (NAIVE / INTERSECCIÓN DIRECTA)
        // ========================================================
        public void RecortarLineaExplicita(Point p1, Point p2, PictureBox canvas)
        {
            // 1. Verificar si está completamente dentro (Aceptación Trivial)
            if (ventana.Contains(p1) && ventana.Contains(p2))
            {
                DibujarLineaResultado(p1.X, p1.Y, p2.X, p2.Y, Color.Orange, "Explícito (Naive)", canvas);
                return;
            }

            // 2. Lista de puntos candidatos (P1, P2 y posibles intersecciones)
            List<PointF> candidatos = new List<PointF>();
            if (ventana.Contains(p1)) candidatos.Add(p1);
            if (ventana.Contains(p2)) candidatos.Add(p2);

            float dx = p2.X - p1.X;
            float dy = p2.Y - p1.Y;

            // Calcular intersecciones con los 4 bordes usando y = mx + b
            if (Math.Abs(dx) >= 0.1f) // No vertical
            {
                float m = dy / dx;
                float b = p1.Y - m * p1.X;

                // Intersección Izquierda (x = Left) -> y = m*Left + b
                float yLeft = m * ventana.Left + b;
                if (yLeft >= ventana.Top && yLeft <= ventana.Bottom) candidatos.Add(new PointF(ventana.Left, yLeft));

                // Intersección Derecha (x = Right)
                float yRight = m * ventana.Right + b;
                if (yRight >= ventana.Top && yRight <= ventana.Bottom) candidatos.Add(new PointF(ventana.Right, yRight));

                // Chequear Top/Bottom si no es horizontal
                if (Math.Abs(dy) >= 0.1f)
                {
                    // y = Top -> x = (Top - b)/m
                    float xTop = (ventana.Top - b) / m;
                    if (xTop >= ventana.Left && xTop <= ventana.Right) candidatos.Add(new PointF(xTop, ventana.Top));

                    // y = Bottom
                    float xBottom = (ventana.Bottom - b) / m;
                    if (xBottom >= ventana.Left && xBottom <= ventana.Right) candidatos.Add(new PointF(xBottom, ventana.Bottom));
                }
            }
            else // Línea Vertical (dx ~ 0)
            {
                if (p1.X >= ventana.Left && p1.X <= ventana.Right)
                {
                    // Solo puede intersecar con Top y Bottom
                    candidatos.Add(new PointF(p1.X, ventana.Top));
                    candidatos.Add(new PointF(p1.X, ventana.Bottom));
                }
            }

            // 3. Filtrar puntos que realmente están en el segmento original
            List<PointF> validos = new List<PointF>();
            float minX = Math.Min(p1.X, p2.X) - 0.1f;
            float maxX = Math.Max(p1.X, p2.X) + 0.1f;
            float minY = Math.Min(p1.Y, p2.Y) - 0.1f;
            float maxY = Math.Max(p1.Y, p2.Y) + 0.1f;
            float vMinX = ventana.Left - 0.1f;
            float vMaxX = ventana.Right + 0.1f;
            float vMinY = ventana.Top - 0.1f;
            float vMaxY = ventana.Bottom + 0.1f;

            foreach (PointF pt in candidatos)
            {
                // Debe estar dentro del rango de la línea original Y dentro de la ventana (con tolerancia)
                if (pt.X >= minX && pt.X <= maxX && pt.Y >= minY && pt.Y <= maxY &&
                    pt.X >= vMinX && pt.X <= vMaxX && pt.Y >= vMinY && pt.Y <= vMaxY)
                {
                    // Evitar duplicados muy cercanos
                    if (!validos.Any(v => Math.Abs(v.X - pt.X) < 1 && Math.Abs(v.Y - pt.Y) < 1))
                    {
                        validos.Add(pt);
                    }
                }
            }

            // 4. Si tenemos al menos 2 puntos válidos, dibujamos de extremo a extremo
            if (validos.Count >= 2)
            {
                // Ordenar por eje X (o Y si es vertical) para encontrar extremos
                if (Math.Abs(dx) > Math.Abs(dy))
                    validos = validos.OrderBy(p => p.X).ToList();
                else
                    validos = validos.OrderBy(p => p.Y).ToList();

                PointF ini = validos.First();
                PointF fin = validos.Last();

                DibujarLineaResultado((int)ini.X, (int)ini.Y, (int)fin.X, (int)fin.Y, Color.Orange, "Explícito (Naive)", canvas);
            }
        }

        // ========================================================
        // 4. POLÍGONOS
        // ========================================================
        public void RecortarPoligonoSutherland(List<Point> entrada, PictureBox canvas)
        {
            List<Point> salida = new List<Point>(entrada);
            salida = RecortarLadoPoligono(salida, ventana.Left, "IZQ");
            salida = RecortarLadoPoligono(salida, ventana.Right, "DER");
            salida = RecortarLadoPoligono(salida, ventana.Top, "ARR");
            salida = RecortarLadoPoligono(salida, ventana.Bottom, "ABA");
            DibujarPoligonoResultado(salida, Color.Magenta, "Sutherland-Hodgman", canvas);
        }

        private List<Point> RecortarLadoPoligono(List<Point> poly, int borde, string tipo)
        {
            List<Point> nuevaLista = new List<Point>();
            if (poly.Count == 0) return nuevaLista;
            Point S = poly[poly.Count - 1];
            foreach (Point E in poly)
            {
                bool E_Adentro = EstaAdentro(E, borde, tipo);
                bool S_Adentro = EstaAdentro(S, borde, tipo);
                if (E_Adentro)
                {
                    if (!S_Adentro) nuevaLista.Add(Interseccion(S, E, borde, tipo));
                    nuevaLista.Add(E);
                }
                else if (S_Adentro)
                {
                    nuevaLista.Add(Interseccion(S, E, borde, tipo));
                }
                S = E;
            }
            return nuevaLista;
        }

        public void RecortarPoligonoPorAristas_Cohen(List<Point> entrada, PictureBox canvas)
        {
            if (entrada.Count < 2) return;
            Point p1 = entrada[entrada.Count - 1];
            foreach (Point p2 in entrada)
            {
                RecortarLineaCohenSutherland(p1, p2, canvas, true);
                p1 = p2;
            }
        }

        public void RecortarPoligonoPorAristas_Liang(List<Point> entrada, PictureBox canvas)
        {
            if (entrada.Count < 2) return;
            Point p1 = entrada[entrada.Count - 1];
            foreach (Point p2 in entrada)
            {
                RecortarLineaLiangBarsky(p1, p2, canvas, true);
                p1 = p2;
            }
        }

        private bool EstaAdentro(Point p, int borde, string tipo)
        {
            switch (tipo)
            {
                case "IZQ": return p.X >= borde;
                case "DER": return p.X <= borde;
                case "ARR": return p.Y >= borde;
                case "ABA": return p.Y <= borde;
                default: return false;
            }
        }

        private Point Interseccion(Point S, Point E, int borde, string tipo)
        {
            double x = 0, y = 0;
            double m = (E.X != S.X) ? (double)(E.Y - S.Y) / (E.X - S.X) : 0;
            if (tipo == "IZQ" || tipo == "DER")
            {
                x = borde;
                if (E.X != S.X) y = m * (x - S.X) + S.Y; else y = S.Y;
            }
            else
            {
                y = borde;
                if (m != 0) x = (y - S.Y) / m + S.X; else x = S.X;
            }
            return new Point((int)x, (int)y);
        }

        // ========================================================
        // DIBUJO
        // ========================================================
        private void DibujarLineaResultado(int x1, int y1, int x2, int y2, Color c, string nombre, PictureBox canvas)
        {
            using (Graphics g = Graphics.FromImage(mBitmap))
            {
                using (Pen p = new Pen(c, 4))
                {
                    g.DrawLine(p, x1, y1, x2, y2);
                }
                if (!string.IsNullOrEmpty(nombre))
                {
                    using (SolidBrush b = new SolidBrush(c))
                    {
                        g.DrawString(nombre, new Font("Arial", 9, FontStyle.Bold), b, (x1 + x2) / 2, (y1 + y2) / 2 - 15);
                    }
                }
            }
            canvas.Refresh();
        }

        private void DibujarPoligonoResultado(List<Point> puntos, Color c, string nombre, PictureBox canvas)
        {
            if (puntos.Count < 3) return;
            using (Graphics g = Graphics.FromImage(mBitmap))
            {
                using (Pen p = new Pen(c, 4))
                {
                    g.DrawPolygon(p, puntos.ToArray());
                }
                using (SolidBrush b = new SolidBrush(Color.FromArgb(50, c)))
                {
                    g.FillPolygon(b, puntos.ToArray());
                }
                using (SolidBrush bText = new SolidBrush(c))
                {
                    int cx = 0, cy = 0;
                    foreach (var p in puntos) { cx += p.X; cy += p.Y; }
                    cx /= puntos.Count; cy /= puntos.Count;
                    g.DrawString(nombre, new Font("Arial", 9, FontStyle.Bold), bText, cx, cy);
                }
            }
            canvas.Refresh();
        }
    }
}