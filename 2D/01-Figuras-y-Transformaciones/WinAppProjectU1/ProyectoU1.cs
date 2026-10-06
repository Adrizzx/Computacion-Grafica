using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinAppProjectU1
{
    public partial class ProyectoU1 : Form
    {
        public ProyectoU1()
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


        private void figura1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            poligono16 poligono16frm = new poligono16();
            poligono16frm.MdiParent = this;
            poligono16frm.WindowState = FormWindowState.Maximized;
            poligono16frm.Show();
        }

        private void figura2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            Figura2 figura2 = new Figura2();
            figura2.MdiParent = this;
            figura2.WindowState = FormWindowState.Maximized;
            figura2.Show();
        }

        private void figura2ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            Figura3 figura3 = new Figura3();
            figura3.MdiParent = this;
            figura3.WindowState = FormWindowState.Maximized;
            figura3.Show();
        }

        private void figura4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            circuloCuadrado circuloCuadradofrm = new circuloCuadrado();
            circuloCuadradofrm.MdiParent = this;
            circuloCuadradofrm.WindowState = FormWindowState.Maximized;
            circuloCuadradofrm.Show();
        }

        private void figura5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            Figura5Rombo figura5Rombofrm = new Figura5Rombo();
            figura5Rombofrm.MdiParent = this;
            figura5Rombofrm.WindowState = FormWindowState.Maximized;
            figura5Rombofrm.Show();
        }

        private void figura6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();
            Figura6 figura6 = new Figura6();
            figura6.MdiParent = this;
            figura6.WindowState = FormWindowState.Maximized;
            figura6.Show();
        }
    }
}
