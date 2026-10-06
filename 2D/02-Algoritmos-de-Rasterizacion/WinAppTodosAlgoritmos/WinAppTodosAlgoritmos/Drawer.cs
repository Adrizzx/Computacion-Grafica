using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinAppTodosAlgoritmos
{
    public partial class Drawer : Form
    {
        private const int PIXEL_SIZE = 10;
        private Bitmap bmp;
        private Graphics g;
        private Point? primerPunto = null;
        private Color colorRelleno = Color.Yellow;
        private Color colorLinea = Color.Black;
        private bool isWorking = false;
        private bool stopRequested = false;
        private Color[,] tablero;
        private int cols;
        private int rows;

        public Drawer()
        {
            InitializeComponent();
            lstPixeles.SelectionMode = SelectionMode.None;
            lblEstado.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        }

        private void Drawer_Load(object sender, EventArgs e)
        {
            InicializarCanvas();
            pnlColorMuestra.BackColor = colorRelleno;
            lblEstado.Text = $"Modo: DFS Seguro | Píxel: {PIXEL_SIZE}px";
        }

        private void InicializarCanvas()
        {
            if (canvas.Width == 0 || canvas.Height == 0) return;
            cols = canvas.Width / PIXEL_SIZE;
            rows = canvas.Height / PIXEL_SIZE;
            tablero = new Color[cols, rows];
            for (int x = 0; x < cols; x++) for (int y = 0; y < rows; y++) tablero[x, y] = Color.White;
            bmp = new Bitmap(canvas.Width, canvas.Height);
            g = Graphics.FromImage(bmp);
            g.Clear(Color.White);
            DibujarGrid();
            canvas.Image = bmp;
        }

        private void DibujarGrid()
        {
            using (Pen pen = new Pen(Color.LightGray))
            {
                for (int x = 0; x <= canvas.Width; x += PIXEL_SIZE) g.DrawLine(pen, x, 0, x, canvas.Height);
                for (int y = 0; y <= canvas.Height; y += PIXEL_SIZE) g.DrawLine(pen, 0, y, canvas.Width, y);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            stopRequested = true;
            InicializarCanvas();
            primerPunto = null;
            lstPixeles.Items.Clear();
            lblEstado.Text = "Lienzo limpio.";
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                colorRelleno = colorDialog1.Color;
                pnlColorMuestra.BackColor = colorRelleno;
            }
        }

        private void rbDibujar_CheckedChanged(object sender, EventArgs e) => primerPunto = null;
        private void rbRellenar_CheckedChanged(object sender, EventArgs e) => primerPunto = null;

        private async void canvas_MouseClick(object sender, MouseEventArgs e)
        {
            if (isWorking) return;
            int gx = e.X / PIXEL_SIZE;
            int gy = e.Y / PIXEL_SIZE;
            if (gx >= cols || gy >= rows) return;

            if (rbDibujar.Checked) ManejarDibujo(gx, gy);
            else if (rbRellenar.Checked) await ManejarRellenoSeguro(gx, gy);
            canvas.Refresh();
        }

        private void ManejarDibujo(int x, int y)
        {
            PintarCeldaLogicaYVisual(x, y, colorLinea);
            if (primerPunto == null)
            {
                primerPunto = new Point(x, y);
                lblEstado.Text = $"Inicio: ({x},{y})";
            }
            else
            {
                Point p1 = primerPunto.Value;
                Point p2 = new Point(x, y);
                DibujarLineaBresenham(p1.X, p1.Y, p2.X, p2.Y, colorLinea);
                lblEstado.Text = $"Línea: ({p1.X},{p1.Y}) -> ({p2.X},{p2.Y})";
                primerPunto = p2;
            }
        }

        private void DibujarLineaBresenham(int x0, int y0, int x1, int y1, Color color)
        {
            int dx = Math.Abs(x1 - x0);
            int dy = Math.Abs(y1 - y0);
            int sx = x0 < x1 ? 1 : -1;
            int sy = y0 < y1 ? 1 : -1;
            int err = dx - dy;
            while (true)
            {
                PintarCeldaLogicaYVisual(x0, y0, color);
                if (x0 == x1 && y0 == y1) break;
                int e2 = 2 * err;
                if (e2 > -dy) { err -= dy; x0 += sx; }
                if (e2 < dx) { err += dx; y0 += sy; }
            }
        }

        private async Task ManejarRellenoSeguro(int x, int y)
        {
            Color colorObjetivo = tablero[x, y];
            if (ColoresIguales(colorObjetivo, colorRelleno) || ColoresIguales(colorObjetivo, colorLinea))
            {
                lblEstado.Text = "No se puede rellenar aquí.";
                return;
            }
            stopRequested = false;
            isWorking = true;
            lstPixeles.Items.Clear();
            lblEstado.Text = "Calculando ruta (DFS Seguro)...";
            List<Point> pasos = new List<Point>();
            FloodFillDFS_Seguro(x, y, colorObjetivo, colorRelleno, pasos);
            lblEstado.Text = $"Animando {pasos.Count} píxeles...";
            int contador = 0;
            foreach (Point p in pasos)
            {
                if (stopRequested) { isWorking = false; return; }
                PintarSoloVisual(p.X, p.Y, colorRelleno);
                lstPixeles.Items.Add($"({p.X},{p.Y})");
                contador++;
                if (contador % 5 == 0) { lstPixeles.TopIndex = lstPixeles.Items.Count - 1; canvas.Refresh(); await Task.Delay(1); }
            }
            if (lstPixeles.Items.Count > 0) lstPixeles.TopIndex = lstPixeles.Items.Count - 1;
            canvas.Refresh();
            lblEstado.Text = "Relleno completado.";
            isWorking = false;
        }

        private void FloodFillDFS_Seguro(int x, int y, Color target, Color replacement, List<Point> pasos)
        {
            Stack<Point> pila = new Stack<Point>();
            pila.Push(new Point(x, y));
            while (pila.Count > 0)
            {
                Point p = pila.Pop();
                if (p.X < 0 || p.X >= cols || p.Y < 0 || p.Y >= rows) continue;
                if (!ColoresIguales(tablero[p.X, p.Y], target)) continue;
                if (ColoresIguales(tablero[p.X, p.Y], replacement)) continue;
                tablero[p.X, p.Y] = replacement;
                pasos.Add(p);
                pila.Push(new Point(p.X - 1, p.Y));
                pila.Push(new Point(p.X, p.Y + 1));
                pila.Push(new Point(p.X + 1, p.Y));
                pila.Push(new Point(p.X, p.Y - 1));
            }
        }

        private void PintarCeldaLogicaYVisual(int x, int y, Color color)
        {
            if (x < 0 || x >= cols || y < 0 || y >= rows) return;
            tablero[x, y] = color;
            PintarSoloVisual(x, y, color);
        }

        private void PintarSoloVisual(int x, int y, Color color)
        {
            using (SolidBrush brush = new SolidBrush(color))
            {
                g.FillRectangle(brush, x * PIXEL_SIZE + 1, y * PIXEL_SIZE + 1, PIXEL_SIZE - 1, PIXEL_SIZE - 1);
            }
        }

        private bool ColoresIguales(Color c1, Color c2) => c1.ToArgb() == c2.ToArgb();
    }
}