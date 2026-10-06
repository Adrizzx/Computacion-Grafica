using System;
using System.Windows.Forms;

namespace WinAppTodosAlgoritmos
{
    public partial class AlgoritmosLinea : Form
    {
        private CDDA objDDA;
        private CBresenham objBresenham;
        private CPMedio objPMedio;
        private string algoritmoActual = "";

        public AlgoritmosLinea()
        {
            InitializeComponent();
            objDDA = new CDDA();
            objBresenham = new CBresenham();
            objPMedio = new CPMedio();
            if (ptbGrafica != null) ptbGrafica.BackColor = System.Drawing.Color.White;
            ConfigurarValidaciones();
        }

        private void ConfigurarValidaciones()
        {
            txtInicioX.KeyPress += TextBox_KeyPress;
            txtInicioY.KeyPress += TextBox_KeyPress;
            txtFinalX.KeyPress += TextBox_KeyPress;
            txtFinalY.KeyPress += TextBox_KeyPress;
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        private void AlgoritmosLinea_Load(object sender, EventArgs e)
        {
            LimpiarTodo();
        }

        private void btnDDA_Click(object sender, EventArgs e)
        {
            algoritmoActual = "DDA";
            if (objDDA.ReadData(txtInicioX, txtInicioY, txtFinalX, txtFinalY, ptbGrafica))
            {
                objDDA.CalculateDDA(ptbGrafica);
                objDDA.DrawComplete(ptbGrafica);
                if (float.IsPositiveInfinity(objDDA.Pendiente)) txtPendiente.Text = "∞";
                else txtPendiente.Text = objDDA.Pendiente.ToString("0.###");
                txtK.Text = objDDA.K.ToString();
                lblInfo.Text = "DDA - " + objDDA.GetCurrentPointInfo();
                ToggleButtons(true);
            }
        }

        private void btnBresenham_Click(object sender, EventArgs e)
        {
            algoritmoActual = "Bresenham";
            if (objBresenham.ReadData(txtInicioX, txtInicioY, txtFinalX, txtFinalY, ptbGrafica))
            {
                objBresenham.CalculateBresenham(ptbGrafica);
                objBresenham.DrawComplete(ptbGrafica);
                txtDeltaX.Text = objBresenham.DeltaX.ToString();
                txtDeltaY.Text = objBresenham.DeltaY.ToString();
                txtP.Text = objBresenham.P_Inicial.ToString();
                lblInfo.Text = "Bresenham - " + objBresenham.GetCurrentPointInfo();
                ToggleButtons(true);
            }
        }

        private void btnPuntoMedio_Click(object sender, EventArgs e)
        {
            algoritmoActual = "PuntoMedio";
            if (objPMedio.ReadData(txtInicioX, txtInicioY, txtFinalX, txtFinalY, ptbGrafica))
            {
                objPMedio.CalculateMidpoint(ptbGrafica);
                objPMedio.DrawComplete(ptbGrafica);
                txtDeltaX.Text = objPMedio.DeltaX.ToString();
                txtDeltaY.Text = objPMedio.DeltaY.ToString();
                txtP.Text = objPMedio.D_Inicial.ToString();
                lblInfo.Text = "Punto Medio - " + objPMedio.GetCurrentPointInfo();
                ToggleButtons(true);
            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (algoritmoActual == "DDA") { objDDA.PreviousStep(ptbGrafica); lblInfo.Text = "DDA - " + objDDA.GetCurrentPointInfo(); }
            else if (algoritmoActual == "Bresenham") { objBresenham.PreviousStep(ptbGrafica); lblInfo.Text = "Bresenham - " + objBresenham.GetCurrentPointInfo(); }
            else if (algoritmoActual == "PuntoMedio") { objPMedio.PreviousStep(ptbGrafica); lblInfo.Text = "Punto Medio - " + objPMedio.GetCurrentPointInfo(); }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (algoritmoActual == "DDA") { objDDA.NextStep(ptbGrafica); lblInfo.Text = "DDA - " + objDDA.GetCurrentPointInfo(); }
            else if (algoritmoActual == "Bresenham") { objBresenham.NextStep(ptbGrafica); lblInfo.Text = "Bresenham - " + objBresenham.GetCurrentPointInfo(); }
            else if (algoritmoActual == "PuntoMedio") { objPMedio.NextStep(ptbGrafica); lblInfo.Text = "Punto Medio - " + objPMedio.GetCurrentPointInfo(); }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarTodo();
        }

        private void LimpiarTodo()
        {
            txtInicioX.Clear(); txtInicioY.Clear(); txtFinalX.Clear(); txtFinalY.Clear();
            txtPendiente.Clear(); txtK.Clear(); txtDeltaX.Clear(); txtDeltaY.Clear(); txtP.Clear();
            ptbGrafica.Image = null;
            algoritmoActual = "";
            ToggleButtons(false);
            txtInicioX.Focus();
        }

        private void ToggleButtons(bool enabled)
        {
            btnAnterior.Enabled = enabled;
            btnSiguiente.Enabled = enabled;
        }

        private void ptbGrafica_Click(object sender, EventArgs e)
        {

        }
    }
}