using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryClubForms.Forms
{
    public partial class HomeForm : Form
    {
        private Form activeForm=null;
        public HomeForm()
        {
            InitializeComponent();
        }

        private void OpenForm(Form newForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }

            activeForm = newForm;

            newForm.TopLevel = false;
            newForm.FormBorderStyle= FormBorderStyle.None;
            newForm.Dock = DockStyle.Fill;

            panelContenedor.Controls.Add(newForm);
            panelContenedor.Tag = newForm;

            newForm.BringToFront();
            newForm.Show();

        }

        private void cateringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(new CateringForm());
        }

        private void LoadHomeForm(object sender, EventArgs e)
        {
            label1.Text = "Usuario: " + VariablesGlobales.usuario;
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm login = new LoginForm();
            login.Show();
        }

        private void asistenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(new AsistenciaForm(null,null));
        }

        private void transporteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(new TransporteForm());
        }

        private void colaboradoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(new ColaboradorForm());
        }

        private void transportistasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(new TransportistaForm());
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(new ClienteForm());
        }
    }
}
