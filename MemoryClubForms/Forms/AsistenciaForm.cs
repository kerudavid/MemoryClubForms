using MemoryClubForms.BusinessBO;
using MemoryClubForms.Models;
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
    public partial class AsistenciaForm : Form
    {
        public string fechaini;
        public string fechafin;
        public int idAsistenciaSelected= 0;
        public int idClienteSelected= 0;
        public int filaSeleccionada=0;
        public AsistenciaForm(string fechaInicial, string fechaFinal)
        {
            InitializeComponent();

            fechaini = fechaInicial;
            fechafin = fechaFinal;
        }

        private void btnClose_Clicked(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AsistenciaForm_Load(object sender, EventArgs e)
        {
            AsistenciaBO asistenciaBO = new AsistenciaBO();
            List<AsistenciaModel> asistenciaList = asistenciaBO.ConsultarPeriodoAsis(this.fechaini, this.fechafin);

            if (asistenciaList.Count > 0)
            {
                foreach (var asistencia in asistenciaList)
                {
                    grdAsistencia.Rows.Add(asistencia.Id_asistencia, asistencia.Fk_id_cliente,asistencia.Nombre, asistencia.Fecha, asistencia.Hora, asistencia.Observacion, asistencia.Sucursal, asistencia.Usuario, asistencia.Fecha_mod);
                }
                grdAsistencia.ReadOnly = true;
            }
        }

        private void EnviarInfo_Clicked(object sender, DataGridViewCellEventArgs e)
        {
            filaSeleccionada = e.RowIndex;

            idAsistenciaSelected = 0;
            idClienteSelected = 0;

            //Valida que el clic no sea de los headers
            if (filaSeleccionada != -1)
            {
                cbxNombresClientes.Items.Clear();//Limpia los valores que pueda tener
                cbxNombresClientes.SelectedItem = (string)grdAsistencia.Rows[filaSeleccionada].Cells[2].Value;//Selecciona ese valor y lo guarda como objeto
                cbxNombresClientes.Items.Add((string)grdAsistencia.Rows[filaSeleccionada].Cells[2].Value);//Son los valores que puede seleccionar
                cbxNombresClientes.Text= (string)grdAsistencia.Rows[filaSeleccionada].Cells[2].Value;//Es el texto que aparece en el recuadro

                string fecha = grdAsistencia.Rows[filaSeleccionada].Cells[3].Value.ToString();
                DateTime fechaDate= DateTime.ParseExact(fecha, "dd/MM/yyyy", null);

                dtmFecha.MinDate = new DateTime(1990, 1, 1);
                dtmFecha.MaxDate = DateTime.Today;

                //dtmFecha.CustomFormat = "MMMM dd, yyyy - dddd";
                //dtmFecha.Format = DateTimePickerFormat.Custom;

                dtmFecha.Value = fechaDate;

                txtHora.Text = (string)grdAsistencia.Rows[filaSeleccionada].Cells[4].Value;

                txtObservciones.Text = (string)grdAsistencia.Rows[filaSeleccionada].Cells[5].Value;

                cbxSucursal.Items.Clear();
                cbxSucursal.SelectedItem = (string)grdAsistencia.Rows[filaSeleccionada].Cells[6].Value.ToString();
                _ = cbxSucursal.Items.Add((string)grdAsistencia.Rows[filaSeleccionada].Cells[6].Value.ToString());
                cbxSucursal.Text = (string)grdAsistencia.Rows[filaSeleccionada].Cells[6].Value.ToString();

                cbxUsuario.Items.Clear();
                cbxUsuario.SelectedItem =(string)grdAsistencia.Rows[filaSeleccionada].Cells[7].Value;
                _ = cbxUsuario.Items.Add((string)grdAsistencia.Rows[filaSeleccionada].Cells[7].Value);//Esta notacion no envia info cuando es null.
                cbxUsuario.Text= (string)grdAsistencia.Rows[filaSeleccionada].Cells[7].Value;


            }
        }
    }
}
