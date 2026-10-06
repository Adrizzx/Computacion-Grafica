using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinAppTodosAlgoritmos
{
    internal class CRelleno
    {
        private List<Point> fillSteps;
        private int currentFillStep;
        private Color fillColor;
        private Color borderColor;
        private CCirculo circulo;
        public string AlgoritmoUsado { get; private set; }
        private bool isAnimating = false;
        private CancellationTokenSource cancellationTokenSource;
        private HashSet<Point> visited;
        private const int MAX_PIXELS = 50000;
        private Color targetColorGlobal;
        private int canvasPixelCols;
        private int canvasPixelRows;
        private const int PIXEL_SIZE = 15;

        public CRelleno(CCirculo circuloRef)
        {
            fillSteps = new List<Point>();
            currentFillStep = 0;
            fillColor = Color.Yellow;
            borderColor = Color.Blue;
            circulo = circuloRef;
            AlgoritmoUsado = "";
            visited = new HashSet<Point>();
        }

        public bool IsAnimating => isAnimating;

        public async Task EjecutarFloodFill(PictureBox picCanvas, int seedX, int seedY)
        {
            PrepararEjecucion(picCanvas, seedX, seedY);
            if (!ValidarInicio(seedX, seedY)) return;

            FloodFillRecursivo(seedX, seedY);
            AlgoritmoUsado = "Flood Fill (Inundación)";
            await FinalizarEjecucion(picCanvas);
        }

        public async Task EjecutarBoundaryFill(PictureBox picCanvas, int seedX, int seedY)
        {
            PrepararEjecucion(picCanvas, seedX, seedY);
            if (!ValidarInicio(seedX, seedY)) return;

            BFSFill(seedX, seedY);
            AlgoritmoUsado = "BFS Fill (Amplitud)";
            await FinalizarEjecucion(picCanvas);
        }

        public async Task EjecutarScanlineFill(PictureBox picCanvas, int seedX, int seedY)
        {
            PrepararEjecucion(picCanvas, seedX, seedY);
            if (!ValidarInicio(seedX, seedY)) return;

            ScanlineSeedFill(seedX, seedY);
            AlgoritmoUsado = "Scanline Seed Fill";
            await FinalizarEjecucion(picCanvas);
        }

        private void PrepararEjecucion(PictureBox picCanvas, int seedX, int seedY)
        {
            CancelarAnimacion();
            cancellationTokenSource = new CancellationTokenSource();
            fillSteps.Clear();
            visited.Clear();
            currentFillStep = 0;
            canvasPixelCols = picCanvas.Width / PIXEL_SIZE;
            canvasPixelRows = picCanvas.Height / PIXEL_SIZE;
            targetColorGlobal = circulo.GetPixelColor(seedX, seedY);
        }

        private bool ValidarInicio(int seedX, int seedY)
        {
            if (seedX < 0 || seedX >= canvasPixelCols || seedY < 0 || seedY >= canvasPixelRows) return false;
            if (circulo.IsBorderPixel(seedX, seedY)) return false;
            if (ColorsEqual(targetColorGlobal, borderColor)) return false;
            return true;
        }

        private async Task FinalizarEjecucion(PictureBox picCanvas)
        {
            if (fillSteps.Count == 0) return;
            await AnimarRellenoConPivote(picCanvas, cancellationTokenSource.Token);
        }

        private void FloodFillRecursivo(int x, int y)
        {
            if (x < 0 || x >= canvasPixelCols || y < 0 || y >= canvasPixelRows) return;
            Point p = new Point(x, y);
            if (!visited.Add(p)) return;
            if (fillSteps.Count >= MAX_PIXELS) return;
            if (circulo.IsBorderPixel(x, y)) return;
            if (!ColorsEqual(circulo.GetPixelColor(x, y), targetColorGlobal)) return;

            fillSteps.Add(p);
            FloodFillRecursivo(x, y - 1);
            FloodFillRecursivo(x + 1, y);
            FloodFillRecursivo(x, y + 1);
            FloodFillRecursivo(x - 1, y);
        }

        private void BFSFill(int seedX, int seedY)
        {
            Queue<Point> queue = new Queue<Point>();
            queue.Enqueue(new Point(seedX, seedY));
            while (queue.Count > 0 && fillSteps.Count < MAX_PIXELS)
            {
                Point current = queue.Dequeue();
                int cx = current.X, cy = current.Y;
                if (cx < 0 || cx >= canvasPixelCols || cy < 0 || cy >= canvasPixelRows) continue;
                if (!visited.Add(current)) continue;
                if (circulo.IsBorderPixel(cx, cy)) continue;
                if (!ColorsEqual(circulo.GetPixelColor(cx, cy), targetColorGlobal)) continue;

                fillSteps.Add(current);
                queue.Enqueue(new Point(cx, cy - 1));
                queue.Enqueue(new Point(cx + 1, cy));
                queue.Enqueue(new Point(cx, cy + 1));
                queue.Enqueue(new Point(cx - 1, cy));
            }
        }

        private void ScanlineSeedFill(int seedX, int seedY)
        {
            Stack<Point> stack = new Stack<Point>();
            stack.Push(new Point(seedX, seedY));
            while (stack.Count > 0 && fillSteps.Count < MAX_PIXELS)
            {
                Point seed = stack.Pop();
                int x = seed.X, y = seed.Y;
                if (y < 0 || y >= canvasPixelRows) continue;

                int leftX = x;
                while (leftX > 0 && !circulo.IsBorderPixel(leftX - 1, y) && !visited.Contains(new Point(leftX - 1, y)))
                {
                    if (ColorsEqual(circulo.GetPixelColor(leftX - 1, y), borderColor)) break;
                    leftX--;
                }

                int rightX = x;
                while (rightX < canvasPixelCols - 1 && !circulo.IsBorderPixel(rightX + 1, y) && !visited.Contains(new Point(rightX + 1, y)))
                {
                    if (ColorsEqual(circulo.GetPixelColor(rightX + 1, y), borderColor)) break;
                    rightX++;
                }

                bool spanAbove = false, spanBelow = false;
                for (int i = leftX; i <= rightX; i++)
                {
                    Point current = new Point(i, y);
                    if (visited.Contains(current) || circulo.IsBorderPixel(i, y)) continue;
                    if (ColorsEqual(circulo.GetPixelColor(i, y), borderColor)) continue;

                    visited.Add(current);
                    fillSteps.Add(current);

                    if (y > 0) CheckSpan(i, y - 1, ref spanAbove, stack);
                    if (y < canvasPixelRows - 1) CheckSpan(i, y + 1, ref spanBelow, stack);
                }
            }
        }

        private void CheckSpan(int x, int y, ref bool span, Stack<Point> stack)
        {
            if (!visited.Contains(new Point(x, y)) && !circulo.IsBorderPixel(x, y))
            {
                if (!ColorsEqual(circulo.GetPixelColor(x, y), borderColor))
                {
                    if (!span) { stack.Push(new Point(x, y)); span = true; }
                }
                else span = false;
            }
            else span = false;
        }

        public void CancelarAnimacion()
        {
            if (cancellationTokenSource != null && !cancellationTokenSource.IsCancellationRequested)
                cancellationTokenSource.Cancel();
            isAnimating = false;
        }

        private async Task AnimarRellenoConPivote(PictureBox picCanvas, CancellationToken token)
        {
            isAnimating = true;
            try
            {
                for (int i = 0; i < fillSteps.Count; i++)
                {
                    if (token.IsCancellationRequested) { isAnimating = false; return; }
                    currentFillStep = i;
                    RedrawWithFillAndPivot(picCanvas, i);
                    await Task.Delay(5, token);
                }
            }
            catch (TaskCanceledException) { }
            isAnimating = false;
        }

        private void RedrawWithFillAndPivot(PictureBox picCanvas, int step)
        {
            circulo.RedibujarCirculo(picCanvas);
            for (int i = 0; i <= Math.Min(step, fillSteps.Count - 1); i++)
            {
                Point p = fillSteps[i];
                circulo.DrawPixel(p.X, p.Y, (i == step) ? Color.Red : fillColor);
            }
            picCanvas.Image = circulo.GetBitmap();
            Application.DoEvents();
        }

        public void NextStep(PictureBox picCanvas, int inc = 1)
        {
            if (currentFillStep < fillSteps.Count - 1)
            {
                currentFillStep = Math.Min(currentFillStep + inc, fillSteps.Count - 1);
                RedrawWithFillAndPivot(picCanvas, currentFillStep);
            }
        }

        public void PreviousStep(PictureBox picCanvas, int dec = 1)
        {
            if (currentFillStep > 0)
            {
                currentFillStep = Math.Max(currentFillStep - dec, 0);
                RedrawWithFillAndPivot(picCanvas, currentFillStep);
            }
        }

        public string GetCurrentStepInfo()
        {
            if (fillSteps.Count == 0) return "Sin datos";
            return $"{AlgoritmoUsado} - Paso: {currentFillStep + 1}/{fillSteps.Count}";
        }

        public int GetTotalSteps() => fillSteps.Count;
        public void Reset() { CancelarAnimacion(); fillSteps.Clear(); visited.Clear(); currentFillStep = 0; AlgoritmoUsado = ""; }
        private bool ColorsEqual(Color c1, Color c2) => c1.R == c2.R && c1.G == c2.G && c1.B == c2.B;
    }
}