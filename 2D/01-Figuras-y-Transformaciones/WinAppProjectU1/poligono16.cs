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
    public partial class poligono16 : Form
    {
        private float currentRadioCm = 0;
        private FigureTransformer transformer;
        private bool isTranslating = false;

        public poligono16()
        {
            InitializeComponent();
            transformer = new FigureTransformer();
        }

        private void poligono16_Load(object sender, EventArgs e)
        {
            hScrollBarEscalar.Minimum = 10;
            hScrollBarEscalar.Maximum = 200;
            hScrollBarEscalar.Value = 100;
            hScrollBarEscalar.LargeChange = 10;
            hScrollBarEscalar.SmallChange = 1;
        }

        private void btnDibujar_Click(object sender, EventArgs e)
        {
            if (float.TryParse(txtRadio.Text, out float radioIngresadoCm) && radioIngresadoCm > 0)
            {
                currentRadioCm = radioIngresadoCm;

                transformer.Reset();
                hScrollBarEscalar.Value = 100;
                isTranslating = false;
                if (btnTrasladar != null)
                {
                    btnTrasladar.Text = "Trasladar";
                }

                ptbGrafica.Invalidate();
            }
            else
            {
                currentRadioCm = 0;
                ptbGrafica.Invalidate();

                MessageBox.Show("Por favor, ingrese un valor numérico válido y positivo para el radio en CENTÍMETROS.",
                    "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ptbGrafica_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(Color.White);

            if (currentRadioCm <= 0)
            {
                return;
            }

            float dpi = g.DpiX;
            float pixelesPorCm = dpi / 2.54f;
            float radio = currentRadioCm * pixelesPorCm;

            PointF O = new PointF(ptbGrafica.Width / 2.0f, ptbGrafica.Height / 2.0f);

            //APLICAR TRANSFORMACIONES
            transformer.Center = O;
            transformer.ApplyTransform(g);

            int numPuntos = 16;
            PointF[] puntos16 = new PointF[numPuntos];
            double anguloStep = 360.0 / numPuntos;

            Pen pen16lados = new Pen(Color.Black, 2);
            Pen penRadios = new Pen(Color.Gray, 1);
            Pen penPatron = new Pen(Color.DimGray, 1);

            Func<PointF, float, PointF> GetPointOnRadiusRatio = (PointF P_end, float ratio) =>
            {
                float V_x = P_end.X - O.X;
                float V_y = P_end.Y - O.Y;
                return new PointF(O.X + V_x * ratio, O.Y + V_y * ratio);
            };

            for (int i = 0; i < numPuntos; i++)
            {
                double anguloActualDeg = 90 - (i * anguloStep);
                double anguloActualRad = anguloActualDeg * (Math.PI / 180.0);
                float x = O.X + (float)(radio * Math.Cos(anguloActualRad));
                float y = O.Y - (float)(radio * Math.Sin(anguloActualRad));
                puntos16[i] = new PointF(x, y);
            }

            g.DrawPolygon(pen16lados, puntos16);

            for (int i = 0; i < numPuntos; i++)
            {
                g.DrawLine(penRadios, O, puntos16[i]);
            }

            float r_a = 6.0f / 7.0f;
            float r_b = 5.0f / 7.0f;
            float r_c = 4.5f / 7.0f;
            float r_d = 2.5f / 7.0f;
            float r_e = 2.0f / 7.0f;

            for (int i = 0; i < numPuntos; i++)
            {
                PointF V_A = puntos16[i];
                PointF V_B = puntos16[(i + 1) % numPuntos];

                if (i % 2 == 0)
                {
                    PointF p_a = GetPointOnRadiusRatio(V_A, r_a);
                    PointF p_b = GetPointOnRadiusRatio(V_A, r_b);
                    PointF p_c = GetPointOnRadiusRatio(V_A, r_c);
                    PointF p_d = GetPointOnRadiusRatio(V_A, r_d);
                    PointF p_e = GetPointOnRadiusRatio(V_A, r_e);

                    PointF p_B_full = V_B;
                    PointF p_B_half = GetPointOnRadiusRatio(V_B, 0.5f);

                    g.DrawLine(penPatron, p_a, p_B_full);
                    g.DrawLine(penPatron, p_b, p_B_full);
                    g.DrawLine(penPatron, p_b, p_B_half);
                    g.DrawLine(penPatron, p_c, p_B_half);
                    g.DrawLine(penPatron, p_d, p_B_half);
                    g.DrawLine(penPatron, p_e, p_B_half);
                }
                else
                {
                    PointF p_a = GetPointOnRadiusRatio(V_B, r_a);
                    PointF p_b = GetPointOnRadiusRatio(V_B, r_b);
                    PointF p_c = GetPointOnRadiusRatio(V_B, r_c);
                    PointF p_d = GetPointOnRadiusRatio(V_B, r_d);
                    PointF p_e = GetPointOnRadiusRatio(V_B, r_e);

                    PointF p_A_full = V_A;
                    PointF p_A_half = GetPointOnRadiusRatio(V_A, 0.5f);

                    g.DrawLine(penPatron, p_a, p_A_full);
                    g.DrawLine(penPatron, p_b, p_A_full);
                    g.DrawLine(penPatron, p_b, p_A_half);
                    g.DrawLine(penPatron, p_c, p_A_half);
                    g.DrawLine(penPatron, p_d, p_A_half);
                    g.DrawLine(penPatron, p_e, p_A_half);
                }
            }

            pen16lados.Dispose();
            penRadios.Dispose();
            penPatron.Dispose();
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

        private void hScrollBarEscalar_Scroll(object sender, ScrollEventArgs e)
        {

            float newScale = hScrollBarEscalar.Value / 100.0f;
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

        private void btnResetear_Click(object sender, EventArgs e)
        {
            currentRadioCm = 0;
            txtRadio.Text = "";
            transformer.Reset();
            hScrollBarEscalar.Value = 100;
            isTranslating = false;

            if (btnTrasladar != null)
            {
                btnTrasladar.Text = "Trasladar";
            }

            ptbGrafica.Invalidate();
        }

        private void ptbGrafica_Click(object sender, EventArgs e)
        {

        }
    }
}