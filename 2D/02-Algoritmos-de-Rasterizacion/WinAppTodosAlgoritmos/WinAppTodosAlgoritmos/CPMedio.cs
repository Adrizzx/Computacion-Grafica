using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WinAppTodosAlgoritmos
{
    internal class CPMedio
    {
        private int mX1, mY1, mX2, mY2;
        private List<Point> mLinePoints;
        private int mCurrentStep;
        private Bitmap mBitmap;
        private const int PIXEL_SIZE = 5;
        private int canvasPixelRows = 0;

        public int DeltaX { get; private set; }
        public int DeltaY { get; private set; }
        public int D_Inicial { get; private set; }

        public CPMedio()
        {
            mLinePoints = new List<Point>();
            mCurrentStep = 0;
        }

        public bool ReadData(TextBox txtX1, TextBox txtY1, TextBox txtX2, TextBox txtY2, PictureBox picCanvas)
        {
            try
            {
                mX1 = int.Parse(txtX1.Text); mY1 = int.Parse(txtY1.Text);
                mX2 = int.Parse(txtX2.Text); mY2 = int.Parse(txtY2.Text);
                if (mX1 < 0 || mY1 < 0 || mX2 < 0 || mY2 < 0) return false;
                return true;
            }
            catch { return false; }
        }

        public void CalculateMidpoint(PictureBox picCanvas)
        {
            mLinePoints.Clear();
            int dx = Math.Abs(mX2 - mX1);
            int dy = Math.Abs(mY2 - mY1);
            DeltaX = dx; DeltaY = dy;

            int sx = (mX1 < mX2) ? 1 : -1;
            int sy = (mY1 < mY2) ? 1 : -1;
            canvasPixelRows = picCanvas.Height / PIXEL_SIZE;
            int x = mX1, y = mY1;

            if (dx > dy)
            {
                int d = 2 * dy - dx;
                D_Inicial = d;
                while (x != mX2)
                {
                    mLinePoints.Add(new Point(x, y));
                    x += sx;
                    if (d < 0) d = d + 2 * dy;
                    else { y += sy; d = d + 2 * dy - 2 * dx; }
                }
            }
            else
            {
                int d = 2 * dx - dy;
                D_Inicial = d;
                while (y != mY2)
                {
                    mLinePoints.Add(new Point(x, y));
                    y += sy;
                    if (d < 0) d = d + 2 * dx;
                    else { x += sx; d = d + 2 * dx - 2 * dy; }
                }
            }
            mLinePoints.Add(new Point(mX2, mY2));
            mCurrentStep = 0;
        }

        public void DrawComplete(PictureBox picCanvas)
        {
            InitializeCanvas(picCanvas);
            DrawUpToStep(picCanvas, mLinePoints.Count - 1);
        }

        public void DrawUpToStep(PictureBox picCanvas, int step)
        {
            InitializeCanvas(picCanvas);
            for (int i = 0; i <= Math.Min(step, mLinePoints.Count - 1); i++)
            {
                Point p = mLinePoints[i];
                int yOriginInvertido = canvasPixelRows - p.Y - 1;
                Color pointColor = (i == step) ? Color.Red : Color.Blue;
                DrawPixel(p.X, yOriginInvertido, pointColor);
            }
            picCanvas.Image = mBitmap;
        }

        public void NextStep(PictureBox picCanvas)
        {
            if (mCurrentStep < mLinePoints.Count - 1)
            {
                mCurrentStep++;
                DrawUpToStep(picCanvas, mCurrentStep);
            }
        }

        public void PreviousStep(PictureBox picCanvas)
        {
            if (mCurrentStep > 0)
            {
                mCurrentStep--;
                DrawUpToStep(picCanvas, mCurrentStep);
            }
        }

        private void InitializeCanvas(PictureBox picCanvas)
        {
            if (mBitmap == null || mBitmap.Width != picCanvas.Width || mBitmap.Height != picCanvas.Height)
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
        }

        private void DrawPixel(int x, int y, Color color)
        {
            using (Graphics g = Graphics.FromImage(mBitmap))
            using (SolidBrush brush = new SolidBrush(color))
            {
                g.FillRectangle(brush, x * PIXEL_SIZE, y * PIXEL_SIZE, PIXEL_SIZE, PIXEL_SIZE);
                g.DrawRectangle(Pens.Black, x * PIXEL_SIZE, y * PIXEL_SIZE, PIXEL_SIZE, PIXEL_SIZE);
            }
        }

        public string GetCurrentPointInfo()
        {
            if (mLinePoints.Count == 0) return "Sin datos";
            Point current = mLinePoints[mCurrentStep];
            return $"({current.X}, {current.Y})";
        }
    }
}