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
using System.Globalization;

namespace MemoryClubForms.Forms
{
    public partial class PlanForm : Form
    {
        CultureInfo ci = new CultureInfo("en-US");

        public int action = 0;//Valida que acción debe realizar el boton de guardar. si insertar o editar, insertar=1 y editar =2
        public int idPlanificacion = 0;
        public int idClient = 0;
        public int ii_Valor1 = 0;
        public decimal id_Valor2 = 0;
        public int filaSeleccionada = 0;

        public static int sucursalUser = VariablesGlobales.sucursal;

        public static List<NombresClientes> clientesList = new List<NombresClientes>();

        public static List<EstadosPlan> estadosList = new List<EstadosPlan>();

        public static List<TipoPlan> tipoPlanList = new List<TipoPlan>();

        public static List<ListaPagado> pagoList = new List<ListaPagado>();

        public static List<PlanModel> planListComplete = new List<PlanModel>();

        public static List<CodigosSucursales> codigosSucursalesList = new List<CodigosSucursales>();

        public static List<ActStsFV> actstsFVList = new List<ActStsFV>();

        public static List<ActStsNDias> actstsNDiasList = new List<ActStsNDias>();

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
                List<PlanModel> planList = planBO.ConsultaPlan(null, null, 0, null, 0, null);

                if (planList.Count > 0)
                {
                    planListComplete = planList;
                    foreach (var plan in planList)
                    {
                        grdPlan.Rows.Add(plan.Id_plan, plan.Fk_id_cliente, plan.Nombre, plan.Tipo_plan, plan.Fecha_inicio_plan, plan.Fecha_fin_plan, plan.Max_dia_plan, plan.Estado, plan.Fecha_mod/**TODO NO DEBE IR FECHA FIN PLAN?*/, plan.Observacion, plan.Idplan_anterior, plan.Sucursal, plan.Pagado, plan.Usuario);
                    }
                    grdPlan.ReadOnly = true;
                }

                bool response = ValidarInformacionElementosFiltros();
                if (!response)
                {
                    MessageBox.Show("No se pudo cargar la información de los filtros, intente recargar la página de nuevo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
        private bool LoadActStsFV() //Recupera la lista de clientes con planes de fecha fin vencidos 
        {
            try
            {
                actstsFVList = new List<ActStsFV>();
                PlanBO planBO = new PlanBO();
                actstsFVList = planBO.RecuperaStsFV();
                return true;
            }
            catch
            {
                return false;
            }
        }
        private bool LoadActStsNDias() //Recupera la lista de clientes que ya han tomado todos los días contratados de su plan
        {
            try
            {
                actstsNDiasList = new List<ActStsNDias>();
                PlanBO planBO = new PlanBO();
                actstsNDiasList = planBO.RecuperaStsNDias();
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

            if (!responseEstados || !responseClientes || !responseTipoPlan || !responsePago || !responseSucursal)
            {
                return false;
            }

            return true;
        }
        private bool ValidarInformacion()
        {
            if (VariablesGlobales.Nivel > 1)
            {
                MessageBox.Show("Su usuario no tiene acceso para registrar planes", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (cbxNombresClientes.SelectedItem == null)
            {
                MessageBox.Show("Ingrese el nombre.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            /* if (cbxSucursal.SelectedItem == null)
             {
                 MessageBox.Show("Seleccione la sucursal.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                 return false;
             }*/

            if (cbxTipoPlan.SelectedItem == null)
            {
                MessageBox.Show("Seleccione el tipo de plan.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (cbxPagado.SelectedItem == null)
            {
                /*MessageBox.Show("Seleccione si el plan está pagado SI/NO", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;*/
            }

            string ls_tipo_plan = cbxTipoPlan.SelectedItem.ToString();
            if (string.IsNullOrEmpty(tbxNumeroDiasPlan.Text) && ls_tipo_plan == "OTROS")
            {
                MessageBox.Show("Ingrese el número de días contratados para el plan OTROS.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            ii_Valor1 = tipoPlanList.Where(x => x.Tipos_plan == ls_tipo_plan).Select(x => x.Valor1).FirstOrDefault(); //#dias vigencia plan
            id_Valor2 = tipoPlanList.Where(x => x.Tipos_plan == ls_tipo_plan).Select(x => x.Valor2).FirstOrDefault(); //#dias contratados

            if (!int.TryParse(tbxNumeroDiasPlan.Text, out int result))
            {
                MessageBox.Show("Caracteres incorrectos. Ingrese números en #Días vigencia del plan.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (result <= 0 || result > 100)
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
            foreach (var item in tipoPlanList)
            {
                if (cbxTipoPlan.SelectedItem.ToString().ToLower() != item.Tipos_plan.ToLower())
                    cbxTipoPlan.Items.Add(item.Tipos_plan);
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

            btneditar_fechafin.Enabled = true;
            btneditar_fechafin.Visible = true;

            btnOk.Visible = false;
            btnOk.Enabled = false;
            btngraba_fefin.Visible = false;
            btngraba_fefin.Enabled = false;

            pnlActions.BackColor = Color.FromArgb(255, 255, 255);
            pnlActions.ForeColor = Color.FromArgb(0, 0, 0);

            tbxNumeroDiasPlan.Enabled = false;
            txtObservciones.Enabled = false;

            btnFiltrar.Enabled = true;
            btnFiltrar.Visible = true;

            btnActualizaEstados.Enabled = true;

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
                btneditar_fechafin.Enabled = false;

            }
            else if (action == 2)
            {
                btnInsertar.BackColor = Color.FromArgb(160, 160, 160);
                btnInsertar.ForeColor = Color.FromArgb(221, 221, 221);
                btnInsertar.FlatAppearance.BorderColor = Color.FromArgb(221, 221, 221);
                btnInsertar.Enabled = false;
                btneditar_fechafin.Enabled = false;

                lblEstado.Visible = true;

                cbxEstado.Visible = true;
                cbxEstado.Enabled = true;

                lblsucursal.Visible = true;

                cbxSucursal.Enabled = false;
                cbxSucursal.Visible = true;

                CargarElementsEdit();

            }


            btnFiltrar.Enabled = false;
            btnFiltrar.Visible = false;
            btnActualizaEstados.Enabled = false;
        }
        private void CleanData()
        {
            idClient = 0;
            idPlanificacion = 0;
            ii_Valor1 = 0;
            id_Valor2 = 0;

            cbxNombresClientes.Items.Clear();//Limpia los valores que pueda tene
            cbxNombresClientes.Text = "";
            cbxNombresClientes.Enabled = true;

            dtmFecha.Value = DateTime.Today;
            dtmFecha.Enabled = true;

            cbxSucursal.Items.Clear();//Limpia los valores que pueda tene
            cbxSucursal.Text = "";

            cbxTipoPlan.Items.Clear();
            cbxTipoPlan.Text = "";
            cbxTipoPlan.Enabled = true;
            
            dtmFechaFin.Enabled = false;
            dtmFechaFinalizoPlan.Enabled = false;

            lblEstado.Visible = false;

            cbxEstado.Visible = false;
            cbxEstado.Enabled = false;
            cbxEstado.Items.Clear();
            cbxEstado.Text = "";

            lblsucursal.Visible = false;

            cbxSucursal.Visible = false;
            cbxSucursal.Enabled = false;
            cbxSucursal.Items.Clear();
            cbxSucursal.Text = "";

            cbxPagado.Items.Clear();
            cbxPagado.Text = "";
            cbxPagado.Enabled = true;

            tbxNumeroDiasPlan.Text = "";
            tbxNumeroDiasPlan.Enabled = true;

            txtObservciones.Text = "";
            txtObservciones.Enabled = true;

            tbxCliente.Text = "";
            tbxCliente.Enabled = false;

           
            txbclave.Visible = false;
            txbclave.Enabled = false;
            txbclave.Text = "";
            labelclave.Visible = false;
            labelclave.Enabled = false;

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
                    desde = dtpDesde.Value.ToString("MM/dd/yyyy", ci);
                    hasta = dtmHasta.Value.ToString("MM/dd/yyyy", ci);
                }

                planModelList = planBO.ConsultaPlan(desde, hasta, sucursal, tipoPlan, idCliente, estado);

                if (planModelList.Count > 0)
                {
                    planListComplete = planModelList;
                    foreach (var plan in planModelList)
                    {
                        grdPlan.Rows.Add(plan.Id_plan, plan.Fk_id_cliente, plan.Nombre, plan.Tipo_plan, plan.Fecha_inicio_plan, plan.Fecha_fin_plan, plan.Max_dia_plan, plan.Estado, plan.Fecha_mod, plan.Observacion, plan.Idplan_anterior, plan.Sucursal, plan.Pagado, plan.Usuario);
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

                    cbxTipoPlan.Items.Clear();
                    cbxTipoPlan.SelectedItem = (string)grdPlan.Rows[filaSeleccionada].Cells[3].Value.ToString();
                    cbxTipoPlan.Items.Add((string)grdPlan.Rows[filaSeleccionada].Cells[3].Value.ToString());
                    cbxTipoPlan.Text = (string)grdPlan.Rows[filaSeleccionada].Cells[3].Value.ToString();

                    string fecha = grdPlan.Rows[filaSeleccionada].Cells[4].Value.ToString();
                    DateTime fechaDate = DateTime.ParseExact(fecha, "MM/dd/yyyy", ci);
                    dtmFecha.Value = fechaDate;

                    string fefin = grdPlan.Rows[filaSeleccionada].Cells[5].Value.ToString();
                    DateTime ldt_fefin = DateTime.ParseExact(fefin, "MM/dd/yyyy", ci);
                    dtmFechaFin.Value = ldt_fefin;
                    
                    tbxNumeroDiasPlan.Text = (string)grdPlan.Rows[filaSeleccionada].Cells[6].Value.ToString();

                    cbxEstado.Items.Clear();
                    cbxEstado.SelectedItem = (string)grdPlan.Rows[filaSeleccionada].Cells[7].Value.ToString();
                    cbxEstado.Items.Add((string)grdPlan.Rows[filaSeleccionada].Cells[7].Value.ToString());
                    cbxEstado.Text = (string)grdPlan.Rows[filaSeleccionada].Cells[7].Value.ToString();

                    string fecha_finalizo = grdPlan.Rows[filaSeleccionada].Cells[8].Value.ToString();
                    DateTime ldt_fecha_finalizo = DateTime.ParseExact(fecha_finalizo, "MM/dd/yyyy", ci);
                    dtmFechaFinalizoPlan.Value = ldt_fecha_finalizo;


                    txtObservciones.Text = (string)grdPlan.Rows[filaSeleccionada].Cells[9].Value;

                    cbxSucursal.Items.Clear();
                    cbxSucursal.SelectedItem = (string)grdPlan.Rows[filaSeleccionada].Cells[11].Value.ToString();
                    cbxSucursal.Items.Add((string)grdPlan.Rows[filaSeleccionada].Cells[11].Value.ToString());
                    cbxSucursal.Text = (string)grdPlan.Rows[filaSeleccionada].Cells[11].Value.ToString();

                    cbxPagado.Items.Clear();
                    cbxPagado.SelectedItem = (string)grdPlan.Rows[filaSeleccionada].Cells[12].Value.ToString();
                    cbxPagado.Items.Add((string)grdPlan.Rows[filaSeleccionada].Cells[12].Value.ToString());
                    cbxPagado.Text = (string)grdPlan.Rows[filaSeleccionada].Cells[12].Value.ToString();

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

            lblAction.Text = "Inserte el Plan el día en que caduque el anterior";

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

            tbxCliente.Enabled = true;
            string cadena = tbxCliente.Text;
            if (!(string.IsNullOrEmpty(cadena)))
            {
                this.FiltraCliente(cadena);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            CleanData();
            ResetElements();
        }

        private void editarplancaducado()
        {
            actionsInUse = false;
            cbxNombresClientes.Enabled = false;

            dtmFecha.Enabled = false;
          
            cbxTipoPlan.Enabled = false;

            dtmFechaFin.Enabled = false;
            dtmFechaFinalizoPlan.Enabled = true;
            cbxEstado.Enabled = false;
            cbxSucursal.Enabled = false;
            cbxPagado.Enabled = false;
            tbxNumeroDiasPlan.Enabled = false;
            txtObservciones.Enabled = false;

            tbxCliente.Enabled = false;
            txbclave.Visible = false;
            txbclave.Enabled = false;
            txbclave.Text = "";
            labelclave.Visible = false;
            labelclave.Enabled = false;

            btnEliminar.Enabled = false;
            btnInsertar.Enabled = false;
            btneditar_fechafin.Enabled = false;
            action = 2;
        }      
        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxNombresClientes.SelectedItem == null || string.IsNullOrEmpty(cbxNombresClientes.Text)) //Valida que tenga un item seleccionado del grid
                {
                    MessageBox.Show("Primero seleccione el registro a modificar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (cbxEstado.SelectedItem.ToString().ToLower() == "caducado")
                {
                    MessageBox.Show("Es un Plan Caducado, solo podrá modificar la Fecha Finalizó Plan", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    editarplancaducado();
                }
                else
                {
                    action = 2;

                    EditElements(2);
                }
                btnGuardar.Enabled = true;
                btnGuardar.Visible = true;

                lblAction.Text = "Editando";

                
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

                if (cbxEstado.SelectedItem.ToString().ToLower() == "caducado")
                {
                    MessageBox.Show("No se puede eliminar un Plan Caducado.\n ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                DialogResult response = MessageBox.Show("Está seguro de eliminar este plan?\n Este proceso es irreversble", "Eliminar item seleccionado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (response == DialogResult.Yes)
                {
                    PlanBO planBO = new PlanBO();
                    PlanModel planModel = new PlanModel();

                    planModel.Id_plan = idPlanificacion;
                    planModel.Estado = cbxEstado.SelectedItem.ToString();

                    string responseDB = planBO.EliminarPlan(planModel);
                    if (responseDB.ToLower() != "ok")
                    {
                        MessageBox.Show("No se eliminó el registro, inténtelo más tarde.\n " + responseDB, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    MessageBox.Show("La información se ha eliminado EXITOSAMENTE!", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se eliminó el registro, inténtelo más tarde.\n" + ex, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            CleanData();
            if ((cbxFiltroCliente.SelectedItem != null) || (cbxFiltroTipoPlan.SelectedItem != null) || (cbxFiltroSucursal.SelectedItem != null) || (cbxFiltroEstadoPlan.SelectedItem != null) || (ckbFiltrarFechas.Checked != true))
            {
                this.btnFiltrar_Click(null, null);
            }
            else
            {
                LoadInformation();
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
                    int li_dias_saldo = 0;
                    string ls_obs = "";


                    var nombreCliente = cbxNombresClientes.SelectedItem.ToString();
                    planModel.Nombre = nombreCliente;
                    int li_id_cliente = clientesList.Where(x => x.nombre == nombreCliente).FirstOrDefault().Id_Cliente;
                    planModel.Fk_id_cliente = li_id_cliente;

                    var li_sucursal = clientesList.Where(x => x.nombre == nombreCliente).FirstOrDefault().Sucursal;

                    //verifico si en el último plan del cliente quedaron días de saldo, si es así sumo esos días a los días del nuevo plan
                    List<SaldoDias> saldoList = new List<SaldoDias>();
                    saldoList = planBO.CalculaSaldo(li_id_cliente);
                    if (saldoList.Count > 0)
                    {
                        foreach (var item in saldoList)
                        {
                            li_dias_saldo = (item.Saldo);
                            if (li_dias_saldo <= 0)
                            {
                                li_dias_saldo = 0;
                                ls_obs = "";
                            }
                            else
                            { ls_obs = "(Saldo de Días = " + li_dias_saldo + ") "; }
                        }
                    }
                    else
                    { li_dias_saldo = 0; }

                    planModel.Tipo_plan = cbxTipoPlan.SelectedItem.ToString();

                    //cálculo fecha fin
                    planModel.Fecha_inicio_plan = dtmFecha.Value.ToString("MM/dd/yyyy", ci);
                    DateTime fechaini = Convert.ToDateTime(dtmFecha.Value);
                    planModel.Fecha_fin_plan = fechaini.AddMonths(ii_Valor1).ToString("MM/dd/yyyy", ci); //en valor1 se encuentran los meses de vigencia, se suma uno o dos meses

                    //dias contratados
                    if (id_Valor2 > 0)
                    {   //para los planes tipo PAQUETE recupera de los códigos y suma el saldo de días
                        planModel.Max_dia_plan = (Convert.ToInt32(id_Valor2) + li_dias_saldo);
                    }
                    else
                    {   //para los otros planes lee de lo ingresado y suma el saldo de días
                        planModel.Max_dia_plan = (int.Parse(tbxNumeroDiasPlan.Text) + li_dias_saldo);
                    }

                    if (cbxPagado.SelectedItem == null)
                    { planModel.Pagado = "NO"; } //por defecto se pone no   
                    else
                    { planModel.Pagado = cbxPagado.SelectedItem.ToString(); }

                    planModel.Estado = estadosList.Where(x => x.Estados == "VIGENTE").FirstOrDefault().Estados;
                    ls_obs = ls_obs + txtObservciones.Text;
                    if (ls_obs.Length > 200)
                    { ls_obs = ls_obs.Substring(0, 200); }

                    planModel.Observacion = ls_obs;
                    planModel.Sucursal = li_sucursal;
                    planModel.Usuario = VariablesGlobales.usuario.ToString();                   
                    planModel.Fecha_mod = planModel.Fecha_fin_plan;

                    string responseDB = planBO.InsertarPlan(planModel);

                    if (responseDB.ToLower() != "ok")
                    {
                        MessageBox.Show("No se pudo guardar la información, inténtelo más tarde \n" + responseDB, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    MessageBox.Show("La información se ha guardado EXITOSAMENTE!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else    //Modificar
                {
                    PlanBO planBO = new PlanBO();
                    PlanModel planModel = new PlanModel();

                    var nombreCliente = cbxNombresClientes.SelectedItem.ToString();
                    planModel.Id_plan = idPlanificacion;
                    planModel.Fk_id_cliente = idClient;
                    planModel.Nombre = nombreCliente;
                    planModel.Tipo_plan = cbxTipoPlan.SelectedItem.ToString();

                    //cálculo fecha fin
                    planModel.Fecha_inicio_plan = dtmFecha.Value.ToString("MM/dd/yyyy", ci);
                    DateTime fechaini = Convert.ToDateTime(dtmFecha.Value);
                    DateTime fecha_fin_vig = fechaini.AddMonths(ii_Valor1);
                    planModel.Fecha_fin_plan = fecha_fin_vig.ToString("MM/dd/yyyy", ci);
                    DateTime fecha_finalizo = dtmFechaFinalizoPlan.Value.Date;

                    if (fecha_finalizo <= dtmFecha.Value.Date)
                    {
                        MessageBox.Show("Fecha Finalizó Plan no puede ser menor o igual a la fecha inicio del plan", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                   

                    //dias contratados
                    if (id_Valor2 > 0)
                    {
                        planModel.Max_dia_plan = Convert.ToInt32(id_Valor2); //para los planes tipo PAQUETE recupera de los códigos
                    }
                    else
                    {
                        planModel.Max_dia_plan = int.Parse(tbxNumeroDiasPlan.Text); //para los otros planes lee de lo ingresado
                    }

                    //No es obligatorio seleccionar si el plan está pagado
                    if (cbxPagado.SelectedItem == null)
                    { planModel.Pagado = "NO"; } //por defecto se pone no   
                    else
                    { planModel.Pagado = cbxPagado.SelectedItem.ToString(); }

                    planModel.Estado = cbxEstado.SelectedItem.ToString();
                    planModel.Observacion = txtObservciones.Text;
                    planModel.Sucursal = int.Parse(cbxSucursal.SelectedItem.ToString());
                    planModel.Usuario = VariablesGlobales.usuario.ToString();
                    //uso la fecha_mod para poner la fecha en que finalizó el plan
                    if (cbxEstado.SelectedItem.ToString().ToLower() == "caducado" ) 
                    {
                        if (fecha_finalizo == fecha_fin_vig) //pone la fecha de hoy
                        {
                            planModel.Fecha_mod = DateTime.Now.ToString("MM/dd/yyyy", ci);
                        }
                        else
                        { planModel.Fecha_mod = fecha_finalizo.ToString("MM/dd/yyyy", ci); }  //pone la fecha digitada por el usuario que modificó
                        
                    }
                    else 
                    { planModel.Fecha_mod = planModel.Fecha_fin_plan; }   //caso contrario vuelve a poner la fecha de caducidad del plan
                                           
                    string responseDB = planBO.ActualizarPlan(planModel);

                    if (responseDB.ToLower() != "ok")
                    {
                        MessageBox.Show("No se pudo editar la información, inténtelo más tarde.\n " + responseDB, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }                     
                    MessageBox.Show("La información se ha actualizado EXITOSAMENTE!", "Actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Alerta, No se pudo guardar el registro\n" + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            ResetElements();
            CleanData();
            if ((cbxFiltroCliente.SelectedItem != null) || (cbxFiltroTipoPlan.SelectedItem != null) || (cbxFiltroSucursal.SelectedItem != null) || (cbxFiltroEstadoPlan.SelectedItem != null) || (ckbFiltrarFechas.Checked != true))
            {
                this.btnFiltrar_Click(null, null);
            }
            else
            {
                LoadInformation();
            }
        }

        private void tbxNumeroDiasPlan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Bloquea el carácter si no es una letra, un dígito, un carácter de control o un espacio en blanco
                MessageBox.Show("Solo se aceptan números", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        /// <summary>
        /// Cuando selecciona un Tipo de Plan habilita o no el control número de días contratados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxTipoPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tipoPlan = cbxTipoPlan.SelectedItem.ToString();
            if (tipoPlan == "OTROS")
            {
                tbxNumeroDiasPlan.Text = "";
                tbxNumeroDiasPlan.Enabled = true;
            }
            else
            {
                tbxNumeroDiasPlan.Enabled = false;
                decimal val2 = tipoPlanList.Where(x => x.Tipos_plan == tipoPlan).Select(x => x.Valor2).FirstOrDefault(); //#dias contratados
                tbxNumeroDiasPlan.Text = (Convert.ToInt32(val2)).ToString();
            }
        }

        private void tbxCliente_TextChanged(object sender, EventArgs e)
        {
            //primero recupero la lista original
            cbxNombresClientes.BeginUpdate();
            cbxNombresClientes.Items.Clear();
            foreach (var item in clientesList)
            {
                cbxNombresClientes.Items.Add(item.nombre);
            }
            cbxNombresClientes.EndUpdate();

            //Si el valor no ha sido modificado por el usuario no realiza cambios
            if (!this.tbxCliente.Focused || this.tbxCliente.Text.Length < 3)
                return;
            //Obtenemos valor de búsqueda  
            string search = this.tbxCliente.Text.Trim().ToLower();
            FiltraCliente(search);
        }

        private void FiltraCliente(string searchString)
        {
            // Filtrar los elementos del ComboBox que contengan la cadena de búsqueda
            List<string> filteredItems = cbxNombresClientes.Items.Cast<string>().Where(item => item.ToLower().Contains(searchString)).ToList();

            // Actualizar la lista de elementos del ComboBox con los elementos filtrados
            if (filteredItems.Count > 0)
            {
                cbxNombresClientes.BeginUpdate();
                cbxNombresClientes.Items.Clear();
                cbxNombresClientes.Items.AddRange(filteredItems.ToArray());
                cbxNombresClientes.EndUpdate();

                // Seleccionar el primer elemento del ComboBox
                cbxNombresClientes.SelectedIndex = 0;
            }
        }

        private void cbxNombresClientes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //tbxCliente.Text = "";
        }

        private void btnActualizaEstados_Click(object sender, EventArgs e)
        {
            DialogResult response = MessageBox.Show("¿Está seguro de Caducar los Planes\ny de Inactivar los Clientes en este momento?\n Este proceso es irreversble", "Proceso Automático", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (response == DialogResult.Yes)
            {
                try
                {
                    PlanBO planBO = new PlanBO();

                    string ls_clientes = "";
                    string ls_planes = "";
                    int li_cuenta = 0;
                    int li_count = 0;
                    string ls_mensaje = "";

                    // recupera las listas de clientes que se deben cambiar a Inactivos
                    LoadActStsFV();
                    LoadActStsNDias();
                    if (actstsFVList.Count > 0)
                    {
                        //armo un string con los id's de los clientes y de los planes que deben cambiar de estado
                        foreach (var item in actstsFVList)
                        {
                            li_cuenta++;
                            if (li_cuenta == 1)
                            {
                                ls_clientes = "(" + Convert.ToString(item.Id_cliente);
                                ls_planes = "(" + Convert.ToString(item.Id_plan);
                            }
                            else
                            {
                                ls_clientes += ", " + Convert.ToString(item.Id_cliente);
                                ls_planes += ", " + Convert.ToString(item.Id_plan);
                            }
                        }
                    }
                    //valida como quedó la cadena con la primera lista
                    if (actstsNDiasList.Count > 0)
                    {
                        foreach (var plan in actstsNDiasList)
                        {
                            li_count++;
                            if (li_count == 1 && ls_clientes.Length <= 0)
                            {
                                ls_clientes = "(" + Convert.ToString(plan.Id_cliente);
                            }
                            else
                            {
                                ls_clientes += ", " + Convert.ToString(plan.Id_cliente);
                            }
                            if (li_count == 1 && ls_planes.Length <= 0)
                            {
                                ls_planes = "(" + Convert.ToString(plan.Id_plan);
                            }
                            else
                            {
                                ls_planes += ", " + Convert.ToString(plan.Id_plan);
                            }
                        }
                    }

                    if (ls_clientes.Length > 0 && ls_planes.Length > 0)
                    {
                        ls_clientes += ")";
                        ls_planes += ")";
                        string ls_fecha_mod = DateTime.Now.ToString("MM/dd/yyyy", ci); //fecha en que finalizaron todos los planes caducados
                        ls_mensaje = planBO.Actualiza_Cli_Plan(ls_planes, ls_clientes, ls_fecha_mod);
                        if (ls_mensaje != "OK")
                        {
                            MessageBox.Show("Alerta, No se inactivaron los clientes\n ni se caducaron los planes.\n" + ls_mensaje, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                        MessageBox.Show("La información se ha actualizado EXITOSAMENTE!", "Actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    MessageBox.Show("No hay información para actualizar", "Actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Alerta, No se cargaron las listas de clientes \n" + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
        }

        /// <summary>
        /// Solo puede editar la fecha fin del plan el administrador del sistema, se solicitará una clave y se validará contra códigos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btneditar_fechafin_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxNombresClientes.SelectedItem == null || string.IsNullOrEmpty(cbxNombresClientes.Text)) //Valida que tenga un item seleccionado del grid
                {
                    MessageBox.Show("Primero seleccione el registro a modificar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                MessageBox.Show("Digite la Clave para modificar la fecha fin del plan", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                btnGuardar.Enabled = false;
                btnInsertar.Enabled = false;
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;
                btneditar_fechafin.Enabled = false; 

                lblAction.Text = "Editando Fecha Fin";
           
                btnOk.Visible = true;
                btnOk.Enabled = true;
                txbclave.Visible = true;
                txbclave.Enabled = true;
                labelclave.Visible = true;
                labelclave.Enabled = true;                        
            }
            catch (Exception ex)
            {
                btnInsertar.Enabled = true;
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;
                btneditar_fechafin.Enabled = true;
                MessageBox.Show("Error  " + ex, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;

            }
        }

        /// <summary>
        /// valida la clave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            PlanBO planBO = new PlanBO();
            string ls_clv = txbclave.Text;
            string ls_auxiliar = planBO.BuscaClv();

            btnOk.Visible = false;
            btnOk.Enabled = false;
            txbclave.Visible = false;
            txbclave.Enabled = false;
            labelclave.Visible = false;
            labelclave.Enabled = false;
            txbclave.Text = "";

            if (ls_auxiliar == ls_clv)
            {
                dtmFechaFin.Enabled = true;
                dtmFechaFin.Visible = true;
                btngraba_fefin.Enabled = true;
                btngraba_fefin.Visible = true;
                lblEstado.Visible = true;
                cbxEstado.Visible = true;
                cbxEstado.Enabled = true;
                //cbxEstado.Items.Clear();
                //cbxEstado.Text = "";

                //TODO:KA
                //Implementación para modificación fecha fin plan
                //Se requiere que el reporte salga en 0 no en días a favor en resportes anteriores (Hablar con Kleber)

                //dtmFechaFinalizoPlan.Enabled = true;
                //dtmFechaFinalizoPlan.Visible = true;

                foreach (var item in estadosList)
                {
                    if (cbxEstado.SelectedItem.ToString().ToLower() != item.Estados.ToLower())
                        cbxEstado.Items.Add(item.Estados);
                }
               
            }
            else
            {
                btnGuardar.Enabled = true;
                btnInsertar.Enabled = true;
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;
                lblAction.Text = "";
                btneditar_fechafin.Enabled = true;

                MessageBox.Show("Error Clave Incorrecta! ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }           
        }

        /// <summary>
        /// graba la nueva fecha
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btngraba_fefin_Click(object sender, EventArgs e)
        {
            btnGuardar.Enabled = true;
            btnInsertar.Enabled = true;
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
            btneditar_fechafin.Enabled = true;
            lblAction.Text = "";
            btngraba_fefin.Visible = false;
            btngraba_fefin.Enabled = false;
            dtmFechaFin.Enabled = false;
            lblEstado.Visible = false;
            cbxEstado.Visible = false;
            cbxEstado.Enabled = false;

            PlanBO planBO = new PlanBO();

            string fefin = dtmFechaFin.Value.ToString("MM/dd/yyyy", ci);            
            string femod = fefin;   //pone la misma fecha de caducidad del plan
            string ls_sts = cbxEstado.SelectedItem.ToString();
            string ls_usuario = VariablesGlobales.usuario.ToString();

            string msg = planBO.ActualizaFechaFin(fefin, idPlanificacion, femod, ls_sts, ls_usuario);

            if (msg.ToLower() != "ok")
            {
                MessageBox.Show("No se pudo editar la Fecha Fin del Plan.\n " + msg, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            MessageBox.Show("La fecha fin se actualizo EXITOSAMENTE!", "Actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
