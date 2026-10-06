using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WinAppTodosAlgoritmos
{
    internal class CCirculo
    {
        private Bitmap mBitmap;
        private const int PIXEL_SIZE = 15;
        private int canvasPixelRows = 0;
        private int canvasPixelCols = 0;
        private int mRadio;
        private int mCentroX, mCentroY;
        private Color mBorderColor;
        private HashSet<Point> borderPixels;
        private Color[,] pixelColors;

        public int Radio => mRadio;
        public int CentroX => mCentroX;
        public int CentroY => mCentroY;
        public string AlgoritmoUsado { get; private set; }
        public string UltimoParametroP { get; private set; }
        public string UltimoParametroD { get; private set; }
        public int TotalPuntos { get; private set; }

        public CCirculo()
        {
            mBorderColor = Color.Blue;
            AlgoritmoUsado = "";
            UltimoParametroP = "";
            UltimoParametroD = "";
            borderPixels = new HashSet<Point>();
        }

        public void UpdateCanvasSize(PictureBox picCanvas)
        {
            canvasPixelRows = picCanvas.Height / PIXEL_SIZE;
            canvasPixelCols = picCanvas.Width / PIXEL_SIZE;
            mCentroX = canvasPixelCols / 2;
            mCentroY = canvasPixelRows / 2;
            pixelColors = new Color[canvasPixelCols, canvasPixelRows];
            for (int x = 0; x < canvasPixelCols; x++)
                for (int y = 0; y < canvasPixelRows; y++)
                    pixelColors[x, y] = Color.White;
        }

        public bool ReadData(TextBox txtRadio, PictureBox picCanvas)
        {
            try
            {
                mRadio = int.Parse(txtRadio.Text);
                if (mRadio <= 0) return false;
                UpdateCanvasSize(picCanvas);
                int maxRadius = Math.Min(mCentroX, mCentroY) - 2;
                if (mRadio > maxRadius) return false;
                return true;
            }
            catch { return false; }
        }

        public void DibujarMidpoint(PictureBox picCanvas)
        {
            InitializeCanvas(picCanvas);
            borderPixels.Clear();
            TotalPuntos = MidpointCircle(mCentroX, mCentroY, mRadio);
            picCanvas.Image = mBitmap;
            AlgoritmoUsado = "Midpoint Circle";
        }

        public void DibujarBresenham(PictureBox picCanvas)
        {
            InitializeCanvas(picCanvas);
            borderPixels.Clear();
            TotalPuntos = BresenhamCircle(mCentroX, mCentroY, mRadio);
            picCanvas.Image = mBitmap;
            AlgoritmoUsado = "Bresenham Circle";
        }

        public void DibujarPolar(PictureBox picCanvas)
        {
            InitializeCanvas(picCanvas);
            borderPixels.Clear();
            TotalPuntos = PolarCircle(mCentroX, mCentroY, mRadio);
            picCanvas.Image = mBitmap;
            AlgoritmoUsado = "Polar (Trigonométrico)";
        }

        private int MidpointCircle(int xc, int yc, int r)
        {
            int x = 0, y = r;
            int p = 1 - r;
            int puntos = 0;
            PlotCirclePoints(xc, yc, x, y);
            puntos += 8;
            while (x <= y)
            {
                x++;
                if (p < 0) p = p + 2 * x + 1;
                else { y--; p = p + 2 * (x - y) + 1; }
                PlotCirclePoints(xc, yc, x, y);
                puntos += 8;
            }
            UltimoParametroP = $"P final = {p}";
            return puntos;
        }

        private int BresenhamCircle(int xc, int yc, int r)
        {
            int x = 0, y = r;
            int d = 3 - 2 * r;
            int puntos = 0;
            PlotCirclePoints(xc, yc, x, y);
            puntos += 8;
            while (x <= y)
            {
                x++;
                if (d < 0) d = d + 4 * x + 6;
                else { y--; d = d + 4 * (x - y) + 10; }
                PlotCirclePoints(xc, yc, x, y);
                puntos += 8;
            }
            UltimoParametroD = $"D final = {d}";
            return puntos;
        }

        private int PolarCircle(int xc, int yc, int r)
        {
            int puntos = 0;
            double angleStep = 1.0 / r;
            for (double angle = 0; angle <= 2 * Math.PI; angle += angleStep)
            {
                int x = (int)Math.Round(r * Math.Cos(angle));
                int y = (int)Math.Round(r * Math.Sin(angle));
                DrawPoint(xc + x, yc + y);
                puntos++;
            }
            return puntos;
        }

        private void PlotCirclePoints(int xc, int yc, int x, int y)
        {
            DrawPoint(xc + x, yc + y); DrawPoint(xc - x, yc + y);
            DrawPoint(xc + x, yc - y); DrawPoint(xc - x, yc - y);
            DrawPoint(xc + y, yc + x); DrawPoint(xc - y, yc + x);
            DrawPoint(xc + y, yc - x); DrawPoint(xc - y, yc - x);
        }

        private void DrawPoint(int x, int y)
        {
            borderPixels.Add(new Point(x, y));
            DrawPixel(x, y, mBorderColor);
        }

        public void DrawPixel(int x, int y, Color color)
        {
            if (mBitmap == null || x < 0 || x >= canvasPixelCols || y < 0 || y >= canvasPixelRows) return;
            if (pixelColors != null) pixelColors[x, y] = color;
            using (Graphics g = Graphics.FromImage(mBitmap))
            using (SolidBrush brush = new SolidBrush(color))
            {
                g.FillRectangle(brush, x * PIXEL_SIZE, y * PIXEL_SIZE, PIXEL_SIZE, PIXEL_SIZE);
                g.DrawRectangle(Pens.Black, x * PIXEL_SIZE, y * PIXEL_SIZE, PIXEL_SIZE, PIXEL_SIZE);
            }
        }

        public void InitializeCanvas(PictureBox picCanvas)
        {
            UpdateCanvasSize(picCanvas);
            if (picCanvas.Width <= 0 || picCanvas.Height <= 0) return;
            mBitmap = new Bitmap(picCanvas.Width, picCanvas.Height);
            using (Graphics g = Graphics.FromImage(mBitmap))
            {
                g.Clear(Color.White);
                using (Pen gridPen = new Pen(Color.LightGray, 1))
                {
                    for (int x = 0; x < picCanvas.Width; x += PIXEL_SIZE) g.DrawLine(gridPen, x, 0, x, picCanvas.Height);
                    for (int y = 0; y < picCanvas.Height; y += PIXEL_SIZE) g.DrawLine(gridPen, 0, y, picCanvas.Width, y);
                }
            }
            picCanvas.Image = mBitmap;
        }

        public void RedibujarCirculo(PictureBox picCanvas)
        {
            if (mBitmap == null) InitializeCanvas(picCanvas);
            else
            {
                using (Graphics g = Graphics.FromImage(mBitmap))
                {
                    g.Clear(Color.White);
                    using (Pen gridPen = new Pen(Color.LightGray, 1))
                    {
                        for (int x = 0; x < picCanvas.Width; x += PIXEL_SIZE) g.DrawLine(gridPen, x, 0, x, picCanvas.Height);
                        for (int y = 0; y < picCanvas.Height; y += PIXEL_SIZE) g.DrawLine(gridPen, 0, y, picCanvas.Width, y);
                    }
                }
            }
            if (pixelColors != null)
                for (int x = 0; x < canvasPixelCols; x++)
                    for (int y = 0; y < canvasPixelRows; y++)
                        pixelColors[x, y] = Color.White;
            foreach (Point p in borderPixels) DrawPixel(p.X, p.Y, mBorderColor);
        }

        public Color GetPixelColor(int x, int y)
        {
            if (pixelColors == null || x < 0 || x >= canvasPixelCols || y < 0 || y >= canvasPixelRows) return Color.Empty;
            return pixelColors[x, y];
        }

        public bool IsBorderPixel(int x, int y) => borderPixels.Contains(new Point(x, y));
        public Bitmap GetBitmap() => mBitmap;
        public string GetInfo() => $"Algoritmo: {AlgoritmoUsado} | Radio: {mRadio} | Puntos: {TotalPuntos}";
    }
}