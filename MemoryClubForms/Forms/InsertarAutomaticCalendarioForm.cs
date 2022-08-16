using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MemoryClubForms.BusinessBO;
using static MemoryClubForms.BusinessBO.CalendarioBO;
using MemoryClubForms.Models;


namespace MemoryClubForms.Forms
{
    public partial class InsertarAutomaticCalendarioForm : Form
    {

        public static List<PlanesClientes> PlanesClientesList = new List<PlanesClientes>();
        public static List<EstadosCalend> estadosList = new List<EstadosCalend>();
        public static List<TiposPlanes> tiposPlanesList = new List<TiposPlanes>();
        public static List<CalendarioModel> calendarioListComplete = new List<CalendarioModel>();
        public static List<NombresClientes> nombresClientesList = new List<NombresClientes>();

        public InsertarAutomaticCalendarioForm()
        {
            InitializeComponent();
            VariablesGlobales.InsertCalendario = true;
        }

        private void InsertarAutomaticCalendarioForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            VariablesGlobales.InsertCalendario = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            VariablesGlobales.InsertCalendario = false;
        }
    }
}
