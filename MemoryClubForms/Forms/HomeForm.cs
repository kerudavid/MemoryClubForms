using MemoryClubForms.Reports;
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

        public void OpenForm(Form newForm)
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

        public void OpenFormEx(Form newForm)
        {
       
            activeForm = newForm;

            newForm.TopLevel = false;
            newForm.FormBorderStyle = FormBorderStyle.None;
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

        private void reporteClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (VariablesGlobales.Nivel <= 1)
            {
                OpenForm(new FormReporteClientePlan());
            }
            else
            {
                MessageBox.Show("Usuario no autorizado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void alertaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (VariablesGlobales.Nivel <= 1)
            {
                OpenForm(new ReporteAlertasForm());
            }
            else
            {
                MessageBox.Show("Usuario no autorizado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }  
        }

        private void reporteCateringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (VariablesGlobales.Nivel <= 1)
            {
                OpenForm(new ReporteCateringForm());
            }
            else
            {
                MessageBox.Show("Usuario no autorizado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
        }

        private void reporteTransporteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (VariablesGlobales.Nivel <= 1)
            {
                OpenForm(new ReporteTransporteForm());
            }
            else
            {
                MessageBox.Show("Usuario no autorizado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
        }

        private void alimentaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(new AlimentosForm());
        }

        private void saludToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(new SaludForm());
        }

        private void planToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(new PlanForm());
        }

        private void usuarioSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (VariablesGlobales.Nivel <= 1)
            {
                OpenForm(new UsuariosForm());
            }
            else
            {
                MessageBox.Show("Usuario no autorizado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;

            }
        }
        /// <summary>
        /// Reporte mensual de ventas de planes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void reporteAsistenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (VariablesGlobales.Nivel <= 1)
            {
                OpenForm(new ReporteVentaPlanesForm());
            }
            else
            {
                MessageBox.Show("Usuario no autorizado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void parámetrosSistemasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (VariablesGlobales.Nivel <= 1)
            {
                OpenForm(new CodigoForm());
            }
            else
            {
                MessageBox.Show("Usuario no autorizado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }
    }
}
