using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MemoryClubForms.Models;
using MemoryClubForms.BusinessBO;
using static MemoryClubForms.BusinessBO.PlanBO;

namespace MemoryClubForms.Forms
{
    public partial class PlanForm : Form
    {
        public int action = 0;//Valida que acción debe realizar el boton de guardar. si insertar o editar, insertar=1 y editar =2

        public int idPlanificacion = 0;

        public int idClient = 0;

        public int filaSeleccionada = 0;

        public static int sucursalUser = VariablesGlobales.sucursal;

        public static List<NombresClientes> clientesList = new List<NombresClientes>();

        public static List<EstadosPlan> estadosList = new List<EstadosPlan>();

        public static List<TipoPlan> tipoPlanList = new List<TipoPlan>();

        public static List<ListaPagado> pagoList = new List<ListaPagado>();

        public static List<PlanModel> planListComplete = new List<PlanModel>();

        public static List<CodigosSucursales> codigosSucursalesList = new List<CodigosSucursales>();

        public static bool actionsInUse = true;
        public PlanForm()
        {
            InitializeComponent();
            LoadInformation();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadInformation()
        {
            try
            {
                grdPlan.Rows.Clear();
                ResetFilterElements();

                PlanBO planBO = new PlanBO();
                planListComplete = new List<PlanModel>();
                List<PlanModel> planList = planBO.ConsultaPlan(null,null,0,null,0,null);

                if (planList.Count > 0)
                {
                    planListComplete = planList;
                    foreach (var plan in planList)
                    {
                        grdPlan.Rows.Add(plan.Id_plan,plan.Fk_id_cliente,plan.Nombre,plan.Sucursal,plan.Tipo_plan,plan.Fecha_inicio_plan,plan.Pagado,plan.Max_dia_plan,plan.Estado, plan.Observacion, plan.Usuario, plan.Fecha_mod);
                    }
                    grdPlan.ReadOnly = true;
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
                clientesList = new List<NombresClientes>();
                PlanBO planBO = new PlanBO();
                clientesList = planBO.LoadClientes();
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
                estadosList = new List<EstadosPlan>();
                PlanBO planBO = new PlanBO();
                estadosList = planBO.LoadEstadosPlan();
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
                tipoPlanList = new List<TipoPlan>();
                PlanBO planBO = new PlanBO();
                tipoPlanList = planBO.LoadTipoPlan();
                return true;
            }
            catch
            {
                return false;
            }
        }
        private bool LoadPago()
        {
            try
            {
                pagoList = new List<ListaPagado>();
                PlanBO planBO = new PlanBO();
                pagoList = planBO.LoadPagado();
                return true;
            }
            catch
            {
                return false;
            }
        }
        private bool LoadSucursal()
        {
            try
            {
                codigosSucursalesList = new List<CodigosSucursales>();
                PlanBO planBO = new PlanBO();
                codigosSucursalesList = planBO.LoadSucursales();
                return true;
            }
            catch
            {
                return false;
            }
        }
        private bool ValidarInformacionElementosFiltros()
        {
            bool responseClientes = LoadClientes();

            bool responseEstados = LoadEstados();

            bool responseTipoPlan = LoadTipoPlan();

            bool responsePago = LoadPago();

            bool responseSucursal = LoadSucursal();

            if (!responseEstados || !responseClientes||!responseTipoPlan||!responsePago||!responseSucursal)
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

            if (cbxNombresClientes.SelectedItem==null)
            {
                MessageBox.Show("Ingrese el nombre.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (cbxSucursal.SelectedItem == null)
            {
                MessageBox.Show("Seleccione la sucursal.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (cbxTipoPlan.SelectedItem == null)
            {
                MessageBox.Show("Seleccione el tipo de plan.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (cbxPagado.SelectedItem == null)
            {
                MessageBox.Show("Seleccione si el plan está pagado SI/NO", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (string.IsNullOrEmpty(tbxNumeroDiasPlan.Text))
            {
                MessageBox.Show("Ingrese el número de días del plan.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (!int.TryParse(tbxNumeroDiasPlan.Text, out int result))
            {
                MessageBox.Show("Caracteres incorrectos. Ingrese números en #Días vigencia del plan.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if(result<=0 || result > 100)
            {
                MessageBox.Show("#Días vigencia del plan debe ser mayor que 0 y menor que 100", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (txtObservciones.Text.Length > 200)
            {
                MessageBox.Show("Has superado el número de caracteres para Observación. Caracteres máximos: 100", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }
        private void CargarElemFiltros()
        {
            foreach (var item in clientesList)
            {
                cbxFiltroCliente.Items.Add(item.nombre);
            }

            foreach (var item in tipoPlanList)
            {
                cbxFiltroTipoPlan.Items.Add(item.Tipos_plan);
            }

            foreach (var item in codigosSucursalesList)
            {
                cbxFiltroSucursal.Items.Add(item.Sucursales);
            }

            foreach (var item in estadosList)
            {
                cbxFiltroEstadoPlan.Items.Add(item.Estados);
            }
            cbxFiltroEstadoPlan.Items.Add("TODOS");
        }
        private void CargarElemActions()
        {
            foreach (var item in clientesList)
            {
                cbxNombresClientes.Items.Add(item.nombre);
            }

            foreach (var item in codigosSucursalesList)
            {
                cbxSucursal.Items.Add(item.Sucursales);
            }

            foreach (var item in tipoPlanList)
            {
                cbxTipoPlan.Items.Add(item.Tipos_plan);
            }

            foreach (var item in estadosList)
            {
                cbxEstado.Items.Add(item.Estados);
            }

            foreach (var item in pagoList)
            {
                cbxPagado.Items.Add(item.Pagados);
            }
        }
        private void CargarElementsEdit()
        {
            foreach (var item in estadosList)
            {
                if (cbxEstado.SelectedItem.ToString().ToLower() != item.Estados.ToLower())
                    cbxEstado.Items.Add(item.Estados);
            }

            foreach (var item in pagoList)
            {
                if (cbxPagado.SelectedItem.ToString().ToLower() != item.Pagados.ToLower())
                    cbxPagado.Items.Add(item.Pagados);
            }
        }
        private void ResetFilterElements()
        {
            cbxFiltroCliente.Items.Clear();

            cbxFiltroTipoPlan.Items.Clear();   

            cbxFiltroSucursal.Items.Clear();

            cbxFiltroEstadoPlan.Items.Clear();

            dtmHasta.Value = DateTime.Now;
            dtpDesde.Value = DateTime.Now;
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

            tbxNumeroDiasPlan.Enabled = false;
            txtObservciones.Enabled = false;

            btnFiltrar.Enabled = true;
            btnFiltrar.Visible = true;

            actionsInUse = true;
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

            dtmFecha.Enabled = true;

            tbxNumeroDiasPlan.Enabled = true;
            txtObservciones.Enabled = true;

            if (action == 1)
            {

                btnEditar.BackColor = Color.FromArgb(160, 160, 160);
                btnEditar.ForeColor = Color.FromArgb(221, 221, 221);
                btnEditar.FlatAppearance.BorderColor = Color.FromArgb(221, 221, 221);
                btnEditar.Enabled = false;

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
            idClient = 0;
            idPlanificacion = 0;

            cbxNombresClientes.Items.Clear();//Limpia los valores que pueda tene
            cbxNombresClientes.Text = "";

            dtmFecha.Value = DateTime.Today;

            cbxSucursal.Items.Clear();//Limpia los valores que pueda tene
            cbxSucursal.Text = "";

            cbxTipoPlan.Items.Clear();
            cbxTipoPlan.Text = "";

            dtmFecha.Enabled = false;

            lblEstado.Visible = false;

            cbxEstado.Visible = false;
            cbxEstado.Enabled = false;
            cbxEstado.Items.Clear();
            cbxEstado.Text = "";

            cbxPagado.Items.Clear();
            cbxPagado.Text = "";

            tbxNumeroDiasPlan.Text = "";

            txtObservciones.Text = "";

        }
        private void btnReiniciarFiltro_Click(object sender, EventArgs e)
        {
            ResetFilterElements();
            LoadInformation();

            ckbFiltrarFechas.Checked = false;
            dtpDesde.Enabled = false;
            dtmHasta.Enabled = false;

        }
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                PlanBO planBO = new PlanBO();

                List<PlanModel> planModelList = new List<PlanModel>();

                grdPlan.Rows.Clear();

                string nombre = null;

                if (cbxFiltroCliente.SelectedItem != null)
                {
                    nombre = cbxFiltroCliente.SelectedItem.ToString();
                }

                int idCliente = clientesList.Where(x => x.nombre == nombre).Select(x => x.Id_Cliente).FirstOrDefault();

                string tipoPlan = null;

                if (cbxFiltroTipoPlan.SelectedItem != null)
                {
                    tipoPlan = cbxFiltroTipoPlan.SelectedItem.ToString();
                }

                int sucursal = 0;

                if (cbxFiltroSucursal.SelectedItem != null)
                {
                    sucursal = int.Parse(cbxFiltroSucursal.SelectedItem.ToString());
                }

                string estado = null;


                if (cbxFiltroEstadoPlan.SelectedItem != null)
                {
                    estado = cbxFiltroEstadoPlan.SelectedItem.ToString();
                }

                string desde = null;
                string hasta = null;

                if (ckbFiltrarFechas.Checked)
                {
                    desde = dtpDesde.Value.ToString("dd/MM/yyyy");
                    hasta = dtmHasta.Value.ToString("dd/MM/yyyy");
                }

                planModelList = planBO.ConsultaPlan(desde,hasta,sucursal,tipoPlan,idCliente,estado);

                if (planModelList.Count > 0)
                {
                    planListComplete = planModelList;
                    foreach (var plan in planModelList)
                    {
                        grdPlan.Rows.Add(plan.Id_plan, plan.Fk_id_cliente, plan.Nombre, plan.Sucursal, plan.Tipo_plan, plan.Fecha_inicio_plan, plan.Pagado, plan.Max_dia_plan, plan.Estado, plan.Observacion, plan.Usuario, plan.Fecha_mod);
                    }
                    grdPlan.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                ResetFilterElements();
                LoadInformation();
                MessageBox.Show("Alerta, No se pudo filtrar el registro\n" + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void ckbFiltrarFechas_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbFiltrarFechas.Checked)
            {
                dtpDesde.Enabled = true;
                dtmHasta.Enabled = true;
            }
            else
            {
                dtpDesde.Enabled = false;
                dtmHasta.Enabled = false;
            }
        }
        private void grdPlan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (!actionsInUse)
                {
                    return;
                }

                filaSeleccionada = e.RowIndex;

                idPlanificacion = 0;

                idClient = 0;

                //Valida que el clic no sea de los headers
                if (filaSeleccionada != -1)
                {
                    idPlanificacion = int.Parse(grdPlan.Rows[filaSeleccionada].Cells[0].Value.ToString());

                    idClient = int.Parse(grdPlan.Rows[filaSeleccionada].Cells[1].Value.ToString());

                    cbxNombresClientes.Items.Clear();
                    cbxNombresClientes.SelectedItem = (string)grdPlan.Rows[filaSeleccionada].Cells[2].Value.ToString();
                    cbxNombresClientes.Items.Add((string)grdPlan.Rows[filaSeleccionada].Cells[2].Value.ToString());
                    cbxNombresClientes.Text = (string)grdPlan.Rows[filaSeleccionada].Cells[2].Value.ToString();

                    cbxSucursal.Items.Clear();
                    cbxSucursal.SelectedItem = (string)grdPlan.Rows[filaSeleccionada].Cells[3].Value.ToString();
                    cbxSucursal.Items.Add((string)grdPlan.Rows[filaSeleccionada].Cells[3].Value.ToString());
                    cbxSucursal.Text = (string)grdPlan.Rows[filaSeleccionada].Cells[3].Value.ToString();

                    cbxTipoPlan.Items.Clear();
                    cbxTipoPlan.SelectedItem = (string)grdPlan.Rows[filaSeleccionada].Cells[4].Value.ToString();
                    cbxTipoPlan.Items.Add((string)grdPlan.Rows[filaSeleccionada].Cells[4].Value.ToString());
                    cbxTipoPlan.Text = (string)grdPlan.Rows[filaSeleccionada].Cells[4].Value.ToString();

                    string fecha = grdPlan.Rows[filaSeleccionada].Cells[5].Value.ToString();
                    DateTime fechaDate = DateTime.ParseExact(fecha, "dd/MM/yyyy", null);

                    dtmFecha.Value = fechaDate;

                    cbxPagado.Items.Clear();
                    cbxPagado.SelectedItem = (string)grdPlan.Rows[filaSeleccionada].Cells[6].Value.ToString();
                    cbxPagado.Items.Add((string)grdPlan.Rows[filaSeleccionada].Cells[6].Value.ToString());
                    cbxPagado.Text = (string)grdPlan.Rows[filaSeleccionada].Cells[6].Value.ToString();

                    tbxNumeroDiasPlan.Text = (string)grdPlan.Rows[filaSeleccionada].Cells[7].Value.ToString();

                    cbxEstado.Items.Clear();
                    cbxEstado.SelectedItem = (string)grdPlan.Rows[filaSeleccionada].Cells[8].Value.ToString();
                    cbxEstado.Items.Add((string)grdPlan.Rows[filaSeleccionada].Cells[8].Value.ToString());
                    cbxEstado.Text = (string)grdPlan.Rows[filaSeleccionada].Cells[8].Value.ToString();

                    txtObservciones.Text = (string)grdPlan.Rows[filaSeleccionada].Cells[9].Value;
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
        private void btnCancel_Click(object sender, EventArgs e)
        {
            CleanData();
            ResetElements();
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxNombresClientes.SelectedItem==null || string.IsNullOrEmpty(cbxNombresClientes.Text)) //Valida que tenga un item seleccionado del grid
                {
                    return;
                }
                if (cbxEstado.SelectedItem.ToString().ToLower() == "cerrado")
                {
                    return;
                }
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

                if (cbxEstado.SelectedItem.ToString().ToLower() == "cerrado")
                {
                    return;
                }

                DialogResult response = MessageBox.Show("Eliminar item seleccionado", "Está seguro de que desea eliminar este elemento? Al eliminar este item se eliminará el calendario de este plan conjuntamente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (response == DialogResult.Yes)
                {
                    PlanBO planBO = new PlanBO();
                    PlanModel planModel = new PlanModel();

                    planModel.Id_plan = idPlanificacion;
                    planModel.Estado=cbxEstado.SelectedItem.ToString();

                    string responseDB = planBO.EliminarPlan(planModel);
                    if (responseDB.ToLower()!="ok")
                    {
                        MessageBox.Show("No se eliminar el registro, inténtelo más tarde. "+responseDB, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    PlanBO planBO = new PlanBO();
                    PlanModel planModel = new PlanModel();

                    var nombreCliente = cbxNombresClientes.SelectedItem.ToString();

                    planModel.Nombre = nombreCliente;
                    planModel.Fk_id_cliente = clientesList.Where(x=>x.nombre==nombreCliente).FirstOrDefault().Id_Cliente;
                    planModel.Tipo_plan = cbxTipoPlan.SelectedItem.ToString();
                    planModel.Fecha_inicio_plan = dtmFecha.Value.ToString("dd/MM/yyyy");
                    planModel.Pagado = cbxPagado.SelectedItem.ToString();
                    planModel.Max_dia_plan=int.Parse(tbxNumeroDiasPlan.Text);
                    planModel.Estado= estadosList.Where(x => x.Estados == "VIGENTE").FirstOrDefault().Estados;
                    planModel.Observacion = txtObservciones.Text;
                    planModel.Sucursal = int.Parse(cbxSucursal.SelectedItem.ToString());
                    planModel.Usuario = VariablesGlobales.usuario.ToString();
                    planModel.Fecha_mod = DateTime.Now.ToString("dd/MM/yyyy");

                    string responseDB = planBO.InsertarPlan(planModel);

                    if (responseDB.ToLower() != "ok")
                    {
                        MessageBox.Show("No se pudo guardar la información, inténtelo más tarde. "+responseDB, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    MessageBox.Show("La información se ha guardado EXITOSAMENTE!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    PlanBO planBO = new PlanBO();
                    PlanModel planModel = new PlanModel();

                    var nombreCliente = cbxNombresClientes.SelectedItem.ToString();
                    planModel.Id_plan = idPlanificacion;
                    planModel.Fk_id_cliente = idClient;
                    planModel.Nombre = nombreCliente;
                    planModel.Tipo_plan = cbxTipoPlan.SelectedItem.ToString();
                    planModel.Fecha_inicio_plan = dtmFecha.Value.ToString("dd/MM/yyyy");
                    planModel.Pagado = cbxPagado.SelectedItem.ToString();
                    planModel.Max_dia_plan = int.Parse(tbxNumeroDiasPlan.Text);
                    planModel.Estado = estadosList.Where(x => x.Estados == "VIGENTE").FirstOrDefault().Estados;
                    planModel.Observacion = txtObservciones.Text;
                    planModel.Sucursal = int.Parse(cbxSucursal.SelectedItem.ToString());
                    planModel.Usuario = VariablesGlobales.usuario.ToString();
                    planModel.Fecha_mod = DateTime.Now.ToString("dd/MM/yyyy");

                    string responseDB = planBO.ActualizarPlan(planModel);

                    if (responseDB.ToLower() != "ok")
                    {
                        MessageBox.Show("No se pudo editar la información, inténtelo más tarde. " + responseDB, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
    }
}
