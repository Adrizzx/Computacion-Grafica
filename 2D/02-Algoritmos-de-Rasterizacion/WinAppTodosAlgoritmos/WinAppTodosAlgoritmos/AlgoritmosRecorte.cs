using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WinAppTodosAlgoritmos
{
    public partial class AlgoritmosRecorte : Form
    {
        private CRecorte motor;
        private List<Point> puntosActuales;

        public AlgoritmosRecorte()
        {
            InitializeComponent();
            motor = new CRecorte();
            puntosActuales = new List<Point>();

            rbLinea.Checked = true;
            ActualizarControles();
        }

        private void AlgoritmosRecorte_Load(object sender, EventArgs e)
        {
            motor.Inicializar(ptbCanvas);
        }

        private void ptbCanvas_MouseClick(object sender, MouseEventArgs e)
        {
            if (rbLinea.Checked)
            {
                if (puntosActuales.Count >= 2) puntosActuales.Clear();
                puntosActuales.Add(e.Location);

                motor.DibujarEntrada(puntosActuales, false, ptbCanvas);

                if (puntosActuales.Count == 1) lblInfo.Text = "Punto 1 capturado. Haga clic para el Punto 2.";
                else lblInfo.Text = "Línea definida. Seleccione algoritmo y presione Recortar.";
            }
            else // Polígono
            {
                puntosActuales.Add(e.Location);
                motor.DibujarEntrada(puntosActuales, true, ptbCanvas);
                lblInfo.Text = $"Vértice {puntosActuales.Count} añadido. Siga agregando o Recorte.";
            }
        }

        private void btnRecortar_Click(object sender, EventArgs e)
        {
            string algoritmo = cmbAlgoritmo.SelectedItem?.ToString();

            // Refresco visual
            if (puntosActuales.Count > 0)
            {
                motor.DibujarEntrada(puntosActuales, !rbLinea.Checked, ptbCanvas);
            }

            if (rbLinea.Checked)
            {
                if (puntosActuales.Count != 2)
                {
                    MessageBox.Show("Dibuje una línea completa primero.");
                    return;
                }

                if (algoritmo == "Cohen-Sutherland")
                    motor.RecortarLineaCohenSutherland(puntosActuales[0], puntosActuales[1], ptbCanvas);
                else if (algoritmo == "Liang-Barsky")
                    motor.RecortarLineaLiangBarsky(puntosActuales[0], puntosActuales[1], ptbCanvas);
                else if (algoritmo == "Explícito (Naive)")
                    motor.RecortarLineaExplicita(puntosActuales[0], puntosActuales[1], ptbCanvas);
                else
                    MessageBox.Show("Por favor, seleccione un algoritmo de línea.");
            }
            else // Polígono
            {
                if (puntosActuales.Count < 3)
                {
                    MessageBox.Show("Dibuje al menos 3 vértices para el polígono.");
                    return;
                }

                if (algoritmo == "Sutherland-Hodgman (Cerrado)")
                    motor.RecortarPoligonoSutherland(puntosActuales, ptbCanvas);
                else if (algoritmo == "Recorte de Aristas (Cohen)")
                    motor.RecortarPoligonoPorAristas_Cohen(puntosActuales, ptbCanvas);
                else if (algoritmo == "Recorte de Aristas (Liang)")
                    motor.RecortarPoligonoPorAristas_Liang(puntosActuales, ptbCanvas);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            puntosActuales.Clear();
            motor.Inicializar(ptbCanvas);
            lblInfo.Text = "Limpio. Seleccione modo y dibuje.";
        }

        private void rbLinea_CheckedChanged(object sender, EventArgs e) { if (rbLinea.Checked) ActualizarControles(); }
        private void rbPoligono_CheckedChanged(object sender, EventArgs e) { if (rbPoligono.Checked) ActualizarControles(); }

        private void ActualizarControles()
        {
            puntosActuales.Clear();
            if (motor != null && ptbCanvas != null) motor.Inicializar(ptbCanvas);
            cmbAlgoritmo.Items.Clear();

            if (rbLinea.Checked)
            {
                cmbAlgoritmo.Items.Add("Cohen-Sutherland");
                cmbAlgoritmo.Items.Add("Liang-Barsky");
                cmbAlgoritmo.Items.Add("Explícito (Naive)");
                lblInfo.Text = "Modo Línea: Dibuje 2 puntos.";
            }
            else
            {
                cmbAlgoritmo.Items.Add("Sutherland-Hodgman (Cerrado)");
                cmbAlgoritmo.Items.Add("Recorte de Aristas (Cohen)");
                cmbAlgoritmo.Items.Add("Recorte de Aristas (Liang)");
                lblInfo.Text = "Modo Polígono: Dibuje vértices.";
            }

            if (cmbAlgoritmo.Items.Count > 0) cmbAlgoritmo.SelectedIndex = 0;
            cmbAlgoritmo.Enabled = true;
        }
    }
}