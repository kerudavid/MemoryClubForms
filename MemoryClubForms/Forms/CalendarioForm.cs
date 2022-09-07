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
    public partial class CalendarioForm : Form
    {
        public int action = 0;//Valida que acción debe realizar el boton de guardar. si insertar o editar, insertar=1 y editar =2

        public int idCalendario = 0;

        public int idPlan = 0;

        public int filaSeleccionada = 0;

        public static int sucursalUser = VariablesGlobales.sucursal;

        public static bool actionsInUse = true;

        public static List<PlanesClientes> PlanesClientesList = new List<PlanesClientes>();
        public static List<EstadosCalend> estadosList = new List<EstadosCalend>();
        public static List<TiposPlanes> tiposPlanesList = new List<TiposPlanes>();
        public static List<CalendarioModel> calendarioListComplete = new List<CalendarioModel>();
        public static List<NombresClientes> nombresClientesList = new List<NombresClientes>();

        
        public CalendarioForm()
        {
            InitializeComponent();
            LoadInformation();
        }

        private void LoadInformation()
        {
            try
            {
                grdCalendario.Rows.Clear();
                ResetFilterElements();

                CalendarioBO calendarioBO = new CalendarioBO();
                calendarioListComplete = new List<CalendarioModel>();
                List<CalendarioModel> calendarioList = calendarioBO.ConsultarCalendario(null, null, 0, 0, null);

                if (calendarioList.Count > 0)
                {
                    calendarioListComplete = calendarioList;

                    foreach (var calend in calendarioList)
                    {
                        grdCalendario.Rows.Add(calend.Id_calendario,calend.Fk_id_plan,calend.Fk_id_cliente,calend.Nombre,calend.Fecha,calend.Estado,calend.Usuario,calend.Fecha_mod);
                    }
                    grdCalendario.ReadOnly = true;
                }

                bool response = ValidarInformacionElementosFiltros();
                if (!response)
                {
                    MessageBox.Show("No se pudo cargar la informacón para realizar filtros, intente recargar la página de nuevo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                CargarElemFiltros();

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar el nombre de los clientes para realizar filtros" + ex, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private bool LoadClientes()
        {
            try
            {
                nombresClientesList = new List<NombresClientes>();
                CalendarioBO calendarioBO = new CalendarioBO();
                nombresClientesList = calendarioBO.LoadClientes();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool LoadPlanesClientes ()
        {
            try
            {
                PlanesClientesList = new List<PlanesClientes>();
                CalendarioBO calendarioBO = new CalendarioBO();
                PlanesClientesList = calendarioBO.LoadPlanesClientes();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool LoadEstados()
        {
            try
            {
                estadosList = new List<EstadosCalend>();
                CalendarioBO calendarioBO = new CalendarioBO();
                estadosList = calendarioBO.LoadEstadosCalendario();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool LoadTipoPlan()
        {
            try
            {
                tiposPlanesList = new List<TiposPlanes>();
                CalendarioBO calendarioBO = new CalendarioBO();
                tiposPlanesList = calendarioBO.LoadTiposPlanes();
                return true;
            }
            catch
            {
                return false;
            }
        }
      
        private bool ValidarInformacionElementosFiltros()
        {
            bool responseClientes = LoadPlanesClientes();

            bool responseEstados = LoadEstados();

            bool responseTipoPlan = LoadTipoPlan();

            bool responseCliente = LoadClientes();


            if (!responseEstados || !responseClientes || !responseTipoPlan||!responseCliente)
            {
                return false;
            }

            return true;
        }

        private bool ValidarInformacion()
        {
            if (VariablesGlobales.Nivel > 1)
            {
                MessageBox.Show("Su usuario no tiene privilegios necesarios para ingresar asistencias de otra sucursal.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (cbxNombresClientes.SelectedItem == null)
            {
                MessageBox.Show("Ingrese el nombre.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (cbxTipoPlan.SelectedItem == null)
            {
                MessageBox.Show("Seleccione el número de plan vigente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }

        private void CargarElementsEdit()
        {
            foreach (var item in estadosList)
            {
                if (cbxEstado.SelectedItem.ToString().ToLower() != item.Estados.ToLower())
                    cbxEstado.Items.Add(item.Estados);
            }
        }

        private void CargarElemActions()
        {
            foreach (var item in PlanesClientesList)
            {
                cbxNombresClientes.Items.Add(item.Nombres);
            }

            foreach (var item in PlanesClientesList)
            {
                cbxTipoPlan.Items.Add(item.Idplan);
            }

            foreach (var item in estadosList)
            {
                cbxEstado.Items.Add(item.Estados);
            }
        }

        private void EditElements(int action)
        {
            actionsInUse = false;

            pnlActions.BackColor = Color.FromArgb(245, 245, 245);
            pnlActions.BorderStyle = BorderStyle.FixedSingle;
            pnlActions.ForeColor = Color.FromArgb(3, 79, 150);

            btnEliminar.BackColor = Color.FromArgb(160, 160, 160);
            btnEliminar.ForeColor = Color.FromArgb(221, 221, 221);
            btnEliminar.FlatAppearance.BorderColor = Color.FromArgb(221, 221, 221);
            btnEliminar.Enabled = false;

            

            if (action == 1)
            {

                btnEditar.BackColor = Color.FromArgb(160, 160, 160);
                btnEditar.ForeColor = Color.FromArgb(221, 221, 221);
                btnEditar.FlatAppearance.BorderColor = Color.FromArgb(221, 221, 221);
                btnEditar.Enabled = false;
                dtmFecha.Enabled = true;

            }
            else if (action == 2)
            {
                btnInsertar.BackColor = Color.FromArgb(160, 160, 160);
                btnInsertar.ForeColor = Color.FromArgb(221, 221, 221);
                btnInsertar.FlatAppearance.BorderColor = Color.FromArgb(221, 221, 221);
                btnInsertar.Enabled = false;

                lblEstado.Visible = true;

                cbxEstado.Visible = true;
                cbxEstado.Enabled = true;

                CargarElementsEdit();

            }


            btnFiltrar.Enabled = false;
            btnFiltrar.Visible = false;
        }

        private void CleanData()
        {
            idPlan = 0;
            idCalendario = 0;

            cbxNombresClientes.Items.Clear();//Limpia los valores que pueda tene
            cbxNombresClientes.Text = "";

            dtmFecha.Value = DateTime.Today;

            cbxTipoPlan.Items.Clear();
            cbxTipoPlan.Text = "";

            dtmFecha.Enabled = false;

            lblEstado.Visible = false;

            cbxEstado.Visible = false;
            cbxEstado.Enabled = false;
            cbxEstado.Items.Clear();
            cbxEstado.Text = "";
        }

        private void CargarElemFiltros()
        {
            foreach (var item in nombresClientesList)
            {
                cbxFiltroCliente.Items.Add(item.nombre);
            }

           
            foreach (var item in estadosList)
            {
                cbxFiltroEstadoCalen.Items.Add(item.Estados);
            }
            cbxFiltroEstadoCalen.Items.Add("TODOS");
        }

        private void ResetElements()
        {
            lblAction.Text = "";

            btnEliminar.BackColor = Color.FromArgb(26, 188, 156);
            btnEliminar.ForeColor = Color.FromArgb(255, 255, 255);
            btnEliminar.FlatAppearance.BorderColor = Color.FromArgb(27, 171, 142);
            btnEliminar.Enabled = true;

            btnEditar.BackColor = Color.FromArgb(26, 188, 156);
            btnEditar.ForeColor = Color.FromArgb(255, 255, 255);
            btnEditar.FlatAppearance.BorderColor = Color.FromArgb(27, 171, 142);
            btnEditar.Enabled = true;

            btnInsertar.BackColor = Color.FromArgb(26, 188, 156);
            btnInsertar.ForeColor = Color.FromArgb(255, 255, 255);
            btnInsertar.FlatAppearance.BorderColor = Color.FromArgb(27, 171, 142);
            btnInsertar.Enabled = true;

            btnGuardar.Enabled = false;
            btnGuardar.Visible = false;

            pnlActions.BackColor = Color.FromArgb(255, 255, 255);
            pnlActions.ForeColor = Color.FromArgb(0, 0, 0);

            btnFiltrar.Enabled = true;
            btnFiltrar.Visible = true;

            actionsInUse = true;
        }

        private void ResetFilterElements()
        {
            cbxFiltroCliente.Items.Clear();

            txbPlan.Text = "";

            cbxFiltroEstadoCalen.Items.Clear();

            dtmHasta.Value = DateTime.Now;
            dtpDesde.Value = DateTime.Now;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReiniciarFiltro_Click(object sender, EventArgs e)
        {
            ResetFilterElements();
            LoadInformation();

            ckbFiltrarFechas.Checked = false;
            dtpDesde.Enabled = false;
            dtmHasta.Enabled = false;
        }

        private void ckbFiltrarFechas_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbFiltrarFechas.Checked)
            {
                dtmHasta.Enabled = true;
                dtpDesde.Enabled = true;
            }
            else
            {
                dtpDesde.Enabled = false;
                dtmHasta.Enabled=false;
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                CalendarioBO calendarioBO = new CalendarioBO();

                List<CalendarioModel> calendarioModelList = new List<CalendarioModel>();

                grdCalendario.Rows.Clear();

                string nombre = string.Empty;

                if (cbxFiltroCliente.SelectedItem != null)
                {
                    nombre = cbxFiltroCliente.SelectedItem.ToString();
                }

                int idCliente = nombresClientesList.Where(x => x.nombre == nombre).Select(x=>x.Id_Cliente).FirstOrDefault();

                int idPlan = 0;

                if ( (txbPlan.Text != null) && (!(string.IsNullOrEmpty(txbPlan.Text))))
                {
                    idPlan = Convert.ToInt32(txbPlan.Text);
                }

                //int idPlan = PlanesClientesList.Where(x => x.Tipoplan == tipoPlan).Select(x => x.Idplan).FirstOrDefault();

                string estado = null;


                if (cbxFiltroEstadoCalen.SelectedItem != null)
                {
                    estado = cbxFiltroEstadoCalen.SelectedItem.ToString();
                }

                string desde = null;
                string hasta = null;

                if (ckbFiltrarFechas.Checked)
                {
                    desde = dtpDesde.Value.ToString("dd/MM/yyyy");
                    hasta = dtmHasta.Value.ToString("dd/MM/yyyy");
                }

                calendarioModelList = calendarioBO.ConsultarCalendario(desde, hasta, idPlan, idCliente, estado);

                if (calendarioModelList.Count > 0)
                {
                    calendarioListComplete = calendarioModelList;
                    foreach (var calend in calendarioModelList)
                    {
                        grdCalendario.Rows.Add(calend.Id_calendario, calend.Fk_id_plan, calend.Fk_id_cliente, calend.Nombre, calend.Fecha, calend.Estado, calend.Usuario, calend.Fecha_mod);
                    }
                    grdCalendario.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                ResetFilterElements();
                LoadInformation();
                MessageBox.Show("Alerta, No se pudo filtrar el registro\n" + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void grdCalendario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (!actionsInUse)
                {
                    return;
                }

                filaSeleccionada = e.RowIndex;

                idCalendario = 0;

                idPlan = 0;

                //Valida que el clic no sea de los headers
                if (filaSeleccionada != -1)
                {
                    idCalendario = int.Parse(grdCalendario.Rows[filaSeleccionada].Cells[0].Value.ToString());

                    idPlan = int.Parse(grdCalendario.Rows[filaSeleccionada].Cells[1].Value.ToString());



                    cbxNombresClientes.Items.Clear();
                    cbxNombresClientes.SelectedItem = (string)grdCalendario.Rows[filaSeleccionada].Cells[3].Value.ToString();
                    cbxNombresClientes.Items.Add((string)grdCalendario.Rows[filaSeleccionada].Cells[3].Value.ToString());
                    cbxNombresClientes.Text = (string)grdCalendario.Rows[filaSeleccionada].Cells[3].Value.ToString();

                   
                    //plan = PlanesClientesList.Where(x => x.Idplan == idPlan).FirstOrDefault().Tipoplan;

                    cbxTipoPlan.Items.Clear();
                    cbxTipoPlan.SelectedItem = (string)grdCalendario.Rows[filaSeleccionada].Cells[1].Value.ToString();
                    cbxTipoPlan.Items.Add((string)grdCalendario.Rows[filaSeleccionada].Cells[1].Value.ToString());
                    cbxTipoPlan.Text = (string)grdCalendario.Rows[filaSeleccionada].Cells[1].Value.ToString();

                    string fecha = grdCalendario.Rows[filaSeleccionada].Cells[4].Value.ToString();
                    DateTime fechaDate = DateTime.ParseExact(fecha, "dd/MM/yyyy", null);

                    dtmFecha.Value = fechaDate;

                    cbxEstado.Items.Clear();
                    cbxEstado.SelectedItem = (string)grdCalendario.Rows[filaSeleccionada].Cells[5].Value.ToString();
                    cbxEstado.Items.Add((string)grdCalendario.Rows[filaSeleccionada].Cells[5].Value.ToString());
                    cbxEstado.Text = (string)grdCalendario.Rows[filaSeleccionada].Cells[5].Value.ToString();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            action = 1;
            btnGuardar.Enabled = true;
            btnGuardar.Visible = true;

            lblAction.Text = "Insertando";

            CleanData();//Limpia la data que se haya seleccionado del grid

            EditElements(1);//Cambia de aspecto a los elementos para indicar al usuario que se realizara una accion, en este caso insertar

            try
            {
                CargarElemActions();

            }
            catch (Exception ex)
            {
                ResetElements();
                MessageBox.Show("Aviso, No se pudo cargar el nombre de los clientes. " + ex);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxNombresClientes.SelectedItem == null || string.IsNullOrEmpty(cbxNombresClientes.Text)) //Valida que tenga un item seleccionado del grid
                {
                    return;
                }
                /*if (cbxEstado.SelectedItem.ToString().ToLower() == "completo")
                {
                    return;
                }*/

                btnGuardar.Enabled = true;
                btnGuardar.Visible = true;

                lblAction.Text = "Editando";

                action = 2;

                EditElements(2);
            }
            catch (Exception ex)
            {

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxNombresClientes.SelectedItem == null || string.IsNullOrEmpty(cbxNombresClientes.Text)) //Valida que tenga un item seleccionado del grid
                {
                    return;
                }

                if (cbxEstado.SelectedItem.ToString().ToLower() == "completo")
                {
                    return;
                }

                DialogResult response = MessageBox.Show("Está seguro de que desea eliminar este elemento?", "Eliminar item seleccionado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (response == DialogResult.Yes)
                {
                    CalendarioBO calendarioBO = new CalendarioBO();
                    CalendarioModel calendarioModel = new CalendarioModel();

                    calendarioModel.Id_calendario = idCalendario;
                    calendarioModel.Estado = cbxEstado.SelectedItem.ToString();

                    string responseDB = calendarioBO.EliminarCalendario(calendarioModel);
                    if (responseDB.ToLower() != "ok")
                    {
                        MessageBox.Show("No se puede eliminar el registro.\n" + responseDB, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    MessageBox.Show("La información se ha eliminado EXITOSAMENTE!", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CleanData();
                    LoadInformation();
                }
            }
            catch (Exception ex)
            {
                CleanData();
                LoadInformation();
                MessageBox.Show("No se eliminar el registro, inténtelo más tarde." + ex, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarInformacion())
                {
                    return;
                }

                if (action == 1) //Insertar
                {
                    CalendarioBO calendarioBO = new CalendarioBO();
                    CalendarioModel calendarioModel = new CalendarioModel();

                    var nombreCliente = cbxNombresClientes.SelectedItem.ToString();

                    calendarioModel.Nombre = nombreCliente;
                    calendarioModel.Fk_id_cliente = PlanesClientesList.Where(x => x.Nombres == nombreCliente).FirstOrDefault().Idcliente;
                    calendarioModel.Fk_id_plan = Convert.ToInt32(cbxTipoPlan.SelectedItem.ToString());
                    calendarioModel.Fecha = dtmFecha.Value.ToString("dd/MM/yyyy");
                    calendarioModel.Estado = "RESERVADO";
                    calendarioModel.Usuario = VariablesGlobales.usuario.ToString();
                    calendarioModel.Fecha_mod = DateTime.Now.ToString("dd/MM/yyyy");

                    string responseDB = calendarioBO.InsertaManual(calendarioModel);

                    if (responseDB.ToLower() != "ok")
                    {
                        MessageBox.Show("No se pudo guardar la información.\n " + responseDB, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    MessageBox.Show("La información se ha guardado EXITOSAMENTE!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    CalendarioBO calendarioBO = new CalendarioBO();
                    CalendarioModel calendarioModel = new CalendarioModel();

                    var nombreCliente = cbxNombresClientes.SelectedItem.ToString();

                    calendarioModel.Id_calendario = idCalendario;
                    calendarioModel.Fk_id_cliente = PlanesClientesList.Where(x => x.Nombres == nombreCliente).FirstOrDefault().Idcliente;
                    calendarioModel.Fk_id_plan = Convert.ToInt32(cbxTipoPlan.SelectedItem.ToString());
                    calendarioModel.Fecha = dtmFecha.Value.ToString("dd/MM/yyyy");
                    calendarioModel.Estado = cbxEstado.SelectedItem.ToString();
                    calendarioModel.Usuario = VariablesGlobales.usuario.ToString();
                    calendarioModel.Fecha_mod = DateTime.Now.ToString("dd/MM/yyyy");



                    string responseDB = calendarioBO.ActualizarCalendario(calendarioModel);

                    if (responseDB.ToLower() != "ok")
                    {
                        MessageBox.Show("No se pudo editar la información.\n" + responseDB, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    MessageBox.Show("La información se ha actualizado EXITOSAMENTE!", "Actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                ResetElements();
                LoadInformation();
                CleanData();
            }
            catch (Exception ex)
            {
                CleanData();
                ResetElements();
                LoadInformation();
                MessageBox.Show("Alerta, No se pudo guardar el registro\n" + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnInsertarAutomatico_Click(object sender, EventArgs e)
        {
            if (!VariablesGlobales.InsertCalendario)
            {
                InsertarAutomaticCalendarioForm calendarioInsertForm = new InsertarAutomaticCalendarioForm();
                calendarioInsertForm.Show();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CleanData();
            ResetElements();
        }

        //pone el id plan en el combobox, el id plan es tomado de la lista plan porque alli tengo el cliente asignado de ese plan
        private void cbxNombresClientes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string nomcliente = Convert.ToString(cbxNombresClientes.SelectedItem);
            int idplan = PlanesClientesList.Where(x => x.Nombres == nomcliente).Select(x => x.Idplan).FirstOrDefault();
            string idplan_s = Convert.ToString(idplan);
            var fechaini = PlanesClientesList.Where(x => x.Idplan == idplan).Select(x => x.Fecha_ini_plan).FirstOrDefault();

            cbxTipoPlan.Items.Clear();
            cbxTipoPlan.SelectedItem = (string)idplan_s;
            cbxTipoPlan.Items.Add((string)idplan_s);
            cbxTipoPlan.Text = (string)idplan_s;

            dtmFecha.Value = Convert.ToDateTime(fechaini);

        }

        private void txbPlan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255) )
            {
                MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
}
