using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinAppTodosAlgoritmos
{
    public partial class CirculoRelleno : Form
    {
        private CCirculo objCirculo;
        private CRelleno objRelleno;
        private bool hasCircle = false;
        private bool esperandoClick = false;
        private string algoritmoSeleccionado = "";
        private const int PIXEL_SIZE = 15;

        public CirculoRelleno()
        {
            InitializeComponent();
            InitializeApp();
        }

        private void InitializeApp()
        {
            objCirculo = new CCirculo();
            objRelleno = new CRelleno(objCirculo);
            ptbGrafica.BackColor = Color.White;
            txtRadio.KeyPress += TextBox_KeyPress;
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        private void CirculoRelleno_Load(object sender, EventArgs e)
        {
            objCirculo.InitializeCanvas(ptbGrafica);
            lblInfo.Text = "Ingrese radio y dibuje un círculo";
            lblParametros.Text = "";
            ToggleControlButtons(false);
        }

        private void ptbGrafica_SizeChanged(object sender, EventArgs e)
        {
            if (hasCircle && !string.IsNullOrEmpty(txtRadio.Text)) objCirculo.InitializeCanvas(ptbGrafica);
        }

        private void ToggleControlButtons(bool enabled)
        {
            btnAnterior.Enabled = enabled;
            btnSiguiente.Enabled = enabled;
        }

        private void ToggleFillButtons(bool enabled)
        {
            btnFloodFill.Enabled = enabled;
            btnBoundaryFill.Enabled = enabled;
            btnScanline.Enabled = enabled;
        }

        private void btnMidpoint_Click(object sender, EventArgs e) { Dibujar("MIDPOINT"); }
        private void btnBresenham_Click(object sender, EventArgs e) { Dibujar("BRESENHAM"); }
        private void btnPolar_Click(object sender, EventArgs e) { Dibujar("POLAR"); }

        private void Dibujar(string algo)
        {
            if (objCirculo.ReadData(txtRadio, ptbGrafica))
            {
                if (algo == "MIDPOINT") objCirculo.DibujarMidpoint(ptbGrafica);
                else if (algo == "BRESENHAM") objCirculo.DibujarBresenham(ptbGrafica);
                else objCirculo.DibujarPolar(ptbGrafica);

                lblInfo.Text = objCirculo.GetInfo() + " - Seleccione relleno";
                lblParametros.Text = (algo == "MIDPOINT") ? objCirculo.UltimoParametroP : objCirculo.UltimoParametroD;
                hasCircle = true;
                objRelleno.Reset();
                ToggleControlButtons(false);
                esperandoClick = false;
            }
        }

        private void btnFloodFill_Click(object sender, EventArgs e) { IniciarRelleno("FloodFill"); }
        private void btnBoundaryFill_Click(object sender, EventArgs e) { IniciarRelleno("BoundaryFill"); }
        private void btnScanline_Click(object sender, EventArgs e) { IniciarRelleno("Scanline"); }

        private void IniciarRelleno(string algo)
        {
            if (!hasCircle) { MessageBox.Show("Dibuje un círculo primero"); return; }
            if (objRelleno.IsAnimating) objRelleno.CancelarAnimacion();
            esperandoClick = true;
            algoritmoSeleccionado = algo;
            lblInfo.Text = $"Haga clic DENTRO para iniciar {algo}";
            ptbGrafica.Cursor = Cursors.Cross;
        }

        private async void ptbGrafica_MouseClick(object sender, MouseEventArgs e)
        {
            if (!esperandoClick || !hasCircle) return;
            int pixelX = e.X / PIXEL_SIZE;
            int pixelY = e.Y / PIXEL_SIZE;
            int dx = pixelX - objCirculo.CentroX;
            int dy = pixelY - objCirculo.CentroY;
            if (Math.Sqrt(dx * dx + dy * dy) > objCirculo.Radio) { MessageBox.Show("Clic fuera del círculo"); return; }

            esperandoClick = false;
            ptbGrafica.Cursor = Cursors.Default;
            ToggleFillButtons(false);
            ToggleControlButtons(false);

            if (algoritmoSeleccionado == "FloodFill") await objRelleno.EjecutarFloodFill(ptbGrafica, pixelX, pixelY);
            else if (algoritmoSeleccionado == "BoundaryFill") await objRelleno.EjecutarBoundaryFill(ptbGrafica, pixelX, pixelY);
            else await objRelleno.EjecutarScanlineFill(ptbGrafica, pixelX, pixelY);

            lblInfo.Text = objRelleno.GetCurrentStepInfo();
            ToggleFillButtons(true);
            ToggleControlButtons(true);
        }

        private void btnSiguiente_Click(object sender, EventArgs e) { objRelleno.NextStep(ptbGrafica); lblInfo.Text = objRelleno.GetCurrentStepInfo(); }
        private void btnAnterior_Click(object sender, EventArgs e) { objRelleno.PreviousStep(ptbGrafica); lblInfo.Text = objRelleno.GetCurrentStepInfo(); }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            objCirculo.InitializeCanvas(ptbGrafica);
            objRelleno.Reset();
            hasCircle = false;
            esperandoClick = false;
            lblInfo.Text = "Limpio";
            txtRadio.Clear();
            ToggleControlButtons(false);
        }
    }
}