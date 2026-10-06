using System;
using System.Windows.Forms;

namespace WinAppTodosAlgoritmos
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void CerrarFormulariosHijos()
        {
            foreach (Form childForm in this.MdiChildren)
            {
                childForm.Close();
            }
        }

        private void AbrirFormulario<T>() where T : Form, new()
        {
            CerrarFormulariosHijos();
            T formulario = new T();
            formulario.MdiParent = this;
            formulario.WindowState = FormWindowState.Maximized;
            formulario.Show();
        }

        private void algoritmosDeLineaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<AlgoritmosLinea>();
        }

        private void circuloYRellenoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<CirculoRelleno>();
        }

        private void dibujadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Drawer>();
        }

        private void algoritmosDeRecorteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<AlgoritmosRecorte>();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {

        }
    }
}