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
using static MemoryClubForms.BusinessBO.TransporteBO;

namespace MemoryClubForms.Forms
{
    public partial class TransporteForm : Form
    {
        public int action = 0;//Valida que acción debe realizar el boton de guardar. si insertar o editar, insertar=1 y editar =2

        public int idTransporteSelected = 0;

        public int idClienteSelected = 0;

        public int filaSeleccionada = 0;

        public static int sucursalUser = VariablesGlobales.sucursal;

        public static List<NombresClientes> nombresClientesList = new List<NombresClientes>();

        public static List<TiposClientes> tiposClientesList = new List<TiposClientes>();

        public static List<NombresTransportistas> nombresTransportistasList = new List<NombresTransportistas>();

        public static List<CodigosSucursales> codigosSucursalesList = new List<CodigosSucursales>();

        public static List<HorariosTransporte> horariosTransportesList = new List<HorariosTransporte>();

        public static List<NombresColaboradores> nombresColaboradoresList = new List<NombresColaboradores>();

        public static List<CodigosEstados> codigosEstadosList = new List<CodigosEstados>();

        public static List<TransporteModel> transporteListComplete = new List<TransporteModel>();

        public static string elemento = "T";

        public static bool actionsInUse = true;
        public TransporteForm()
        {
            InitializeComponent();

            dtmFecha.MinDate = new DateTime(1990, 1, 1);
            dtmFecha.MaxDate = DateTime.Today;

            dtpDesde.MinDate = new DateTime(1990, 1, 1);
            dtpDesde.MaxDate = DateTime.Today;

            dtmHasta.MinDate = new DateTime(1990, 1, 1);
            dtmHasta.MaxDate = DateTime.Today;

            LoadInformation();
        }

        private void btnClose_Clicked(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReiniciarFiltro_Click(object sender, EventArgs e)
        {

            ResetFilterElements();
            LoadInformation();

            ckbFiltrarFechas.Checked = false;
            dtmHasta.Enabled = false;
            dtpDesde.Enabled = false;

        }

        private void LoadInformation()
        {
            try
            {
                grdTransporte.Rows.Clear();
                ResetFilterElements();

                TransporteBO transporteBO = new TransporteBO();
                transporteListComplete = new List<TransporteModel>();
                List<TransporteModel> transporteList = transporteBO.ConsultaTransporte(null, null, null, 0, 0, 0, null,null);

                if (transporteList.Count > 0)
                {
                    transporteListComplete = transporteList;
                    foreach (var trasnp in transporteList)
                    {
                        grdTransporte.Rows.Add(trasnp.Id_transporte, trasnp.Fk_id_cliente, trasnp.Nombre, trasnp.Tipo_cliente, trasnp.Fecha, trasnp.Hora,trasnp.Id_transportista,trasnp.Nombre_tra, trasnp.Entrada_salida, trasnp.Observacion, trasnp.Sucursal, trasnp.Usuario, trasnp.Fecha_mod,trasnp.Estado);
                    }
                    grdTransporte.ReadOnly = true;
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

        private bool ValidarInformacionElementosFiltros()
        {
            bool responseClientes = LoadNombresClientes();

            bool responseTipoCliente = LoadTipoCliente();

            bool responseEstados = LoadEstados();

            bool responseSucursales = LoadSucursales();

            bool reponseColaboradores = LoadNombresColaboradores();

            bool responseTransportista = LoadTransportistas();

            bool responseHorariosTransporte = LoadHorariosTransporte();

            if (!responseClientes || !responseTipoCliente || !responseEstados || !responseSucursales || !reponseColaboradores||!responseTransportista||!responseHorariosTransporte)
            {
                return false;
            }

            return true;
        }

        private bool ValidarInformacion()
        {            
            if (cbxNombresClientes.SelectedItem == null)
            {
                MessageBox.Show("Seleccione el nombre del cliente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (cbxTransportista.SelectedItem == null)
            {
                MessageBox.Show("Seleccione el transportista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if(cbxEntradaSalida.SelectedItem == null)
            {
                MessageBox.Show("Seleccione si es Entrada o Salida", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (!ValidateHora())
            {
                return false;
            }

            if (txtObservciones.Text.Length > 150)
            {
                MessageBox.Show("Has superado el númerod e caracteres para Observación. Caracteres máximos: 100", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        private bool ValidateHora()
        {
            if (txtHora.Text.Length > 5 || string.IsNullOrEmpty(txtHora.Text) || txtHora.Text == " " || txtHora.Text == "")
            {
                MessageBox.Show("El formato de la hora es 21:00 o 08:15 \nRecuerde que se usa el formato de 24 horas.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (!txtHora.Text.Contains(":"))
            {
                MessageBox.Show("El formato de la hora es hh:mm Ejemplo: 08:15 \nRecuerde que se usa el formato de 24 horas.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            string horas = txtHora.Text.Split(':')[0];
            string minutos = txtHora.Text.Split(':')[1];


            if (horas.Length < 2 || horas.Length > 2)
            {
                MessageBox.Show("El formato de la hora es hh:mm Ejemplo: 08:15 \nRecuerde que se usa el formato de 24 horas.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (minutos.Length < 2 || minutos.Length > 2)
            {
                MessageBox.Show("El formato de la hora es hh:mm Ejemplo: 08:15 \nRecuerde que se usa el formato de 24 horas", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }



            if (int.Parse(horas) > 23 || int.Parse(horas) < 0)
            {
                MessageBox.Show("Las horas deben ser mayores a 00 y menores a 23, formatos aceptables 00:00 o 23:59", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (int.Parse(minutos) > 59 || int.Parse(minutos) < 0)
            {
                MessageBox.Show("Los minutos deben ser mayores a 00 y menores a 59 , formatos aceptables 00:00 o 23:59", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private bool LoadNombresClientes()
        {
            try
            {
                nombresClientesList = new List<NombresClientes>();
                TransporteBO transporteBO = new TransporteBO();
                nombresClientesList = transporteBO.LoadClientes();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool LoadTipoCliente()
        {
            try
            {
                tiposClientesList = new List<TiposClientes>();
                TransporteBO transporteBO = new TransporteBO();
                tiposClientesList = transporteBO.LoadTiposClientes();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool LoadTransportistas()
        {
            try
            {
                nombresTransportistasList = new List<NombresTransportistas>();
                TransporteBO transporteBO = new TransporteBO();
                nombresTransportistasList = transporteBO.LoadNombresTransportistas();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool LoadHorariosTransporte()
        {
            try
            {
                horariosTransportesList = new List<HorariosTransporte>();
                TransporteBO transporteBO = new TransporteBO();
                horariosTransportesList = transporteBO.LoadHorariosTransporte();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool LoadSucursales()
        {
            try
            {
                codigosSucursalesList = new List<CodigosSucursales>();
                TransporteBO transporteBO = new TransporteBO();
                codigosSucursalesList = transporteBO.LoadSucursales();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool LoadNombresColaboradores()
        {
            try
            {
                nombresColaboradoresList = new List<NombresColaboradores>();
                TransporteBO transporteBO = new TransporteBO();
                nombresColaboradoresList = transporteBO.LoadNombresColaboradores();
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
                codigosEstadosList = new List<CodigosEstados>();
                TransporteBO transporteBO = new TransporteBO();
                codigosEstadosList = transporteBO.LoadEstados();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void CargarElemFiltros()
        {
            foreach (var item in nombresClientesList)
            {
                cbxFiltroNombreCliente.Items.Add(item.nombre);
            }
            foreach (var item in nombresColaboradoresList)
            {
                cbxFiltroNombreCliente.Items.Add(item.nombre);
            }

            foreach (var item in tiposClientesList)
            {
                cbxFiltroTipoCli.Items.Add(item.TipoCliente);
            }

            foreach (var item in horariosTransportesList)
            {
                cbxFiltroHorarios.Items.Add(item.Horario);
            }

            foreach (var item in codigosSucursalesList)
            {
                cbxFiltroSucursal.Items.Add(item.Sucursales.ToString());
            }

            foreach (var item in codigosEstadosList)
            {
                cbxFiltroEstadoCliente.Items.Add(item.Descripcion.ToString());
            }

            foreach (var item in nombresTransportistasList)
            {
                cbxFiltroTransportista.Items.Add(item.Nombre.ToString());
            }

        }

        private void ChargeElementsEdit()
        {
            foreach(var item in horariosTransportesList)
            {
                if (cbxEntradaSalida.SelectedItem.ToString().ToLower() != item.Horario)
                {
                    cbxEntradaSalida.Items.Add(item.Horario);
                }
            }
        }
        private void CargarElemActions()
        {
            //Cargo el nombre de los clientes y de los colaboradores
            foreach (var item in nombresClientesList)
            {
                cbxNombresClientes.Items.Add(item.nombre);
            }
            foreach (var item in nombresColaboradoresList)
            {
                cbxNombresClientes.Items.Add(item.nombre);
            }

            foreach (var item in nombresTransportistasList)
            {
                cbxTransportista.Items.Add(item.Nombre);
            }

            foreach (var item in horariosTransportesList)
            {
                cbxEntradaSalida.Items.Add(item.Horario);
            }

            txtHora.Text = "08:15";
        }

        private void ResetFilterElements()
        {
            cbxFiltroNombreCliente.Items.Clear();

            cbxFiltroTipoCli.Items.Clear();

            cbxFiltroHorarios.Items.Clear();

            cbxFiltroSucursal.Items.Clear();

            cbxFiltroEstadoCliente.Items.Clear();

            cbxFiltroTransportista.Items.Clear();

            dtpDesde.Value = DateTime.Today;

            dtmHasta.Value = DateTime.Today;

            ckbFiltrarFechas.Checked = false;

            elemento = "T";

            rbtnTodos.Checked = false;

            rbtnRecorrido.Checked = false;

            rbtnOtros.Checked = false;
        }

        private void Row_Clicked(object sender, DataGridViewCellEventArgs e)
        {
            if (!actionsInUse)
            {
                return;
            }

            filaSeleccionada = e.RowIndex;

            idTransporteSelected = 0;
            idClienteSelected = 0;

            //Valida que el clic no sea de los headers
            if (filaSeleccionada != -1)
            {
                idTransporteSelected = int.Parse(grdTransporte.Rows[filaSeleccionada].Cells[0].Value.ToString());

                idClienteSelected = int.Parse(grdTransporte.Rows[filaSeleccionada].Cells[1].Value.ToString());

                cbxNombresClientes.Items.Clear();//Limpia los valores que pueda tener
                cbxNombresClientes.SelectedItem = (string)grdTransporte.Rows[filaSeleccionada].Cells[2].Value;//Selecciona ese valor y lo guarda como objeto
                cbxNombresClientes.Items.Add((string)grdTransporte.Rows[filaSeleccionada].Cells[2].Value);//Son los valores que puede seleccionar
                cbxNombresClientes.Text = (string)grdTransporte.Rows[filaSeleccionada].Cells[2].Value;//Es el texto que aparece en el recuadro

                string fecha = grdTransporte.Rows[filaSeleccionada].Cells[4].Value.ToString();
                DateTime fechaDate = DateTime.ParseExact(fecha, "dd/MM/yyyy", null);

                dtmFecha.Value = fechaDate;

                txtHora.Text = (string)grdTransporte.Rows[filaSeleccionada].Cells[5].Value;

                cbxTransportista.Items.Clear();
                cbxTransportista.SelectedItem = (string)grdTransporte.Rows[filaSeleccionada].Cells[7].Value;
                cbxTransportista.Items.Add((string)grdTransporte.Rows[filaSeleccionada].Cells[7].Value);
                cbxTransportista.Text = (string)grdTransporte.Rows[filaSeleccionada].Cells[7].Value;

                cbxEntradaSalida.Items.Clear();
                cbxEntradaSalida.SelectedItem = (string)grdTransporte.Rows[filaSeleccionada].Cells[8].Value;
                cbxEntradaSalida.Items.Add((string)grdTransporte.Rows[filaSeleccionada].Cells[8].Value);
                cbxEntradaSalida.Text = (string)grdTransporte.Rows[filaSeleccionada].Cells[8].Value;

                txtObservciones.Text = (string)grdTransporte.Rows[filaSeleccionada].Cells[9].Value;
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                TransporteBO transporteBO = new TransporteBO();

                List<TransporteModel> transporteList = new List<TransporteModel>();

                bool check = ckbFiltrarFechas.Checked;

                transporteList = new List<TransporteModel>();

                grdTransporte.Rows.Clear();

                string nombre = null;

                if (cbxFiltroNombreCliente.SelectedItem != null)
                {
                    nombre = cbxFiltroNombreCliente.SelectedItem.ToString();
                }

                int idCliente = nombresClientesList.Where(x => x.nombre == nombre).Select(x => x.Id_Cliente).FirstOrDefault();

                if (idCliente <= 0)
                {
                    idCliente = nombresColaboradoresList.Where(x => x.nombre == nombre).Select(x => x.Id_colaborador).FirstOrDefault();
                }

                string entradaSalida = null;

                if (cbxFiltroHorarios.SelectedItem != null)
                {
                    entradaSalida = cbxFiltroHorarios.SelectedItem.ToString();
                }

                string tipoCliente = null;

                if (cbxFiltroTipoCli.SelectedItem != null)
                {
                    tipoCliente = cbxFiltroTipoCli.SelectedItem.ToString();
                }

                int sucursal = 0;

                if (cbxFiltroSucursal.SelectedItem != null)
                {
                    sucursal = int.Parse(cbxFiltroSucursal.SelectedItem.ToString());
                }


                string estado = null;
                string pEstado = null;

                if (cbxFiltroEstadoCliente.SelectedItem != null)
                {
                    estado = cbxFiltroEstadoCliente.SelectedItem.ToString();
                }

                pEstado = codigosEstadosList.Where(x => x.Descripcion == estado).Select(x => x.Estados).FirstOrDefault();

                string nombreTransportista = null;

                if (cbxFiltroTransportista.SelectedItem != null)
                {
                    nombreTransportista = cbxFiltroTransportista.SelectedItem.ToString();
                }

                int idTransportisa = nombresTransportistasList.Where(x => x.Nombre == nombreTransportista).Select(x => x.Id_transportista).FirstOrDefault();


                string fechaDesde = null;
                string fechaHasta = null;

                if (check)
                {
                    fechaDesde = dtpDesde.Value.ToString("dd/MM/yyyy");
                    fechaHasta = dtmHasta.Value.ToString("dd/MM/yyyy");
                }

                if (rbtnTodos.Checked)
                {
                    elemento = "T";
                }
                if (rbtnRecorrido.Checked)
                {
                    elemento = "R";
                }
                if (rbtnOtros.Checked)
                {
                    elemento = "O";
                }
             

                transporteList = transporteBO.ConsultaTransporte(fechaDesde, fechaHasta, tipoCliente,idTransportisa , sucursal, idCliente, pEstado,elemento);

                if (transporteList.Count > 0)
                {
                    foreach (var trasnp in transporteList)
                    {
                        grdTransporte.Rows.Add(trasnp.Id_transporte, trasnp.Fk_id_cliente, trasnp.Nombre, trasnp.Tipo_cliente, trasnp.Fecha, trasnp.Hora, trasnp.Id_transportista, trasnp.Nombre_tra, trasnp.Entrada_salida, trasnp.Observacion, trasnp.Sucursal, trasnp.Usuario, trasnp.Fecha_mod, trasnp.Estado);
                    }
                    grdTransporte.ReadOnly = true;
                }

            }
            catch (Exception ex)
            {
                ResetFilterElements();
                LoadInformation();
                MessageBox.Show("Alerta, No se pudo filtrar el registro\n" + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (VariablesGlobales.Nivel > 3)
            {
                MessageBox.Show("Su usuario no tiene los privilegios necesarios para insertar registros de transporte.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            action = 1;
            btnGuardar.Enabled = true;
            btnGuardar.Visible = true;

            lblAction.Text = "Insertando";

            EditElements(1);//Cambia de aspecto a los elementos para indicar al usuario que se realizara una accion, en este caso insertar

            CleanData();//Limpia la data que se haya seleccionado del grid

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
            if (VariablesGlobales.Nivel > 3)
            {
                MessageBox.Show("Su usuario no tiene los privilegios necesarios para editar registros de transporte.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            if (cbxNombresClientes.Items.Count == 0) //Valida que tenga un item seleccionado del grid
            {
                return;
            }
            btnGuardar.Enabled = true;
            btnGuardar.Visible = true;

            lblAction.Text = "Editando";

            action = 2;

            EditElements(2);
        }

        private void CleanData()
        {
            idTransporteSelected = 0;
            idClienteSelected = 0;

            cbxNombresClientes.Items.Clear();//Limpia los valores que pueda tene
            cbxNombresClientes.Text = "";

            cbxTransportista.Items.Clear();//Limpia los valores que pueda tene
            cbxTransportista.Text = "";

            cbxEntradaSalida.Items.Clear();
            cbxEntradaSalida.Text = "";

            dtmFecha.Value = DateTime.Today;

            txtHora.Text = "";

            txtObservciones.Text = "";

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
            txtHora.Enabled = true;
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

                ChargeElementsEdit();
            }


            btnFiltrar.Enabled = false;
            btnFiltrar.Visible = false;
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

            dtmFecha.Enabled = false;
            txtHora.Enabled = false;
            txtObservciones.Enabled = false;

            btnFiltrar.Enabled = true;
            btnFiltrar.Visible = true;

            actionsInUse = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CleanData();
            ResetElements();
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
                    TransporteBO transporteBO = new TransporteBO();
                    TransporteModel transporteModel = new TransporteModel();

                    var nombreCliente = cbxNombresClientes.SelectedItem.ToString();

                    transporteModel.Fk_id_cliente = nombresClientesList.Where(x => x.nombre == nombreCliente).Select(x => x.Id_Cliente).FirstOrDefault();
                    if (transporteModel.Fk_id_cliente == 0)
                    {
                        transporteModel.Fk_id_cliente = nombresColaboradoresList.Where(x => x.nombre == nombreCliente).Select(x => x.Id_colaborador).FirstOrDefault();
                    }

                    string cliente = nombresClientesList.Where(x => x.nombre == nombreCliente).Select(x => x.nombre).FirstOrDefault();
                    string colaborador = nombresColaboradoresList.Where(x => x.nombre == nombreCliente).Select(x => x.nombre).FirstOrDefault();

                    if (!string.IsNullOrEmpty(cliente))
                    {
                        transporteModel.Tipo_cliente = tiposClientesList.Where(x => x.TipoCliente == "CLIENTE").Select(x => x.TipoCliente).FirstOrDefault();

                    }
                    else if (!string.IsNullOrEmpty(colaborador))
                    {
                        transporteModel.Tipo_cliente = tiposClientesList.Where(x => x.TipoCliente == "COLABORADOR").Select(x => x.TipoCliente).FirstOrDefault();
                    }

                    string nombreTransport = cbxTransportista.SelectedItem.ToString();
                    int idTranspo = nombresTransportistasList.Where(x => x.Nombre == nombreTransport).Select(x => x.Id_transportista).FirstOrDefault();


                    transporteModel.Id_transportista =idTranspo;
                    transporteModel.Entrada_salida = cbxEntradaSalida.SelectedItem.ToString();
                    transporteModel.Fecha = dtmFecha.Value.ToString("dd/MM/yyyy");
                    transporteModel.Hora = txtHora.Text;
                    transporteModel.Observacion = txtObservciones.Text;

                    transporteModel.Sucursal = nombresClientesList.Where(x => x.nombre == nombreCliente).Select(x => x.Sucursal).FirstOrDefault();

                    if (transporteModel.Sucursal == 0)
                    {
                        transporteModel.Sucursal = nombresColaboradoresList.Where(x => x.nombre == nombreCliente).Select(x => x.Sucursal).FirstOrDefault();
                    }

                    transporteModel.Usuario = VariablesGlobales.usuario.ToString();
                    transporteModel.Fecha_mod = DateTime.Now.ToString("dd/MM/yyyy");

                    bool responseInsert = transporteBO.InsertarTransporte(transporteModel);

                    if (!responseInsert)
                    {
                        MessageBox.Show("No se pudo guardar la información, inténtelo más tarde.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    MessageBox.Show("La información se ha guardado EXITOSAMENTE!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    TransporteBO transporteBO = new TransporteBO();
                    TransporteModel transporteModel = new TransporteModel();

                    string nombreCliente = cbxNombresClientes.SelectedItem.ToString();

                    transporteModel.Id_transporte = idTransporteSelected;
                    transporteModel.Fk_id_cliente = idClienteSelected;
                    transporteModel.Nombre = nombreCliente;

                    string cliente = nombresClientesList.Where(x => x.nombre == nombreCliente).Select(x => x.nombre).FirstOrDefault();
                    string colaborador = nombresColaboradoresList.Where(x => x.nombre == nombreCliente).Select(x => x.nombre).FirstOrDefault();

                    if (!string.IsNullOrEmpty(cliente))
                    {
                        transporteModel.Tipo_cliente = tiposClientesList.Where(x => x.TipoCliente == "CLIENTE").Select(x => x.TipoCliente).FirstOrDefault();

                    }
                    else if (!string.IsNullOrEmpty(colaborador))
                    {
                        transporteModel.Tipo_cliente = tiposClientesList.Where(x => x.TipoCliente == "COLABORADOR").Select(x => x.TipoCliente).FirstOrDefault();
                    }

                    string nombreTransport = cbxTransportista.SelectedItem.ToString();
                    int idTranspo = nombresTransportistasList.Where(x => x.Nombre == nombreTransport).Select(x => x.Id_transportista).FirstOrDefault();

                    transporteModel.Id_transportista = idTranspo;
                    transporteModel.Entrada_salida=transporteListComplete.Where(x=>x.Fk_id_cliente==idClienteSelected && x.Nombre==nombreCliente).Select(x => x.Entrada_salida).FirstOrDefault();
                    transporteModel.Fecha = dtmFecha.Value.ToString("dd/MM/yyyy");
                    transporteModel.Hora = txtHora.Text;
                    transporteModel.Observacion = txtObservciones.Text;
                    transporteModel.Sucursal = nombresClientesList.Where(x => x.nombre == nombreCliente).Select(x => x.Sucursal).FirstOrDefault();

                    if (transporteModel.Sucursal == 0)
                    {
                        transporteModel.Sucursal = nombresColaboradoresList.Where(x => x.nombre == nombreCliente).Select(x => x.Sucursal).FirstOrDefault();
                    }

                    transporteModel.Usuario = VariablesGlobales.usuario.ToString();
                    transporteModel.Fecha_mod = DateTime.Now.ToString("dd/MM/yyyy");

                    bool response = transporteBO.ActualizarTransporte(transporteModel);
                    if (!response)
                    {
                        MessageBox.Show("No se pudo editar la información, inténtelo más tarde.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (VariablesGlobales.Nivel > 1)
            {
                MessageBox.Show("Su usuario no tiene los privilegios necesarios para eliminar registros de transporte.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                
                return;
            }

            try
            {
                if (cbxNombresClientes.Items.Count == 0) //Valida que tenga un item seleccionado del grid
                {
                    return;
                }

                DialogResult response = MessageBox.Show("Eliminar item seleccionado", "Está seguro de que desea eliminar este elemento?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (response == DialogResult.Yes)
                {
                    TransporteBO transporteBO = new TransporteBO();
                    TransporteModel transporteModel = new TransporteModel();

                    string nombreCliente = cbxNombresClientes.SelectedItem.ToString();
                    transporteModel.Id_transporte = idTransporteSelected;
                    transporteModel.Fk_id_cliente = idClienteSelected;

                    bool responseDB = transporteBO.EliminarTransporte(transporteModel.Id_transporte);
                    if (!responseDB)
                    {
                        MessageBox.Show("No se eliminar el registro, inténtelo más tarde.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void ckbFiltrarFechas_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbFiltrarFechas.Checked)
            {
                dtmHasta.Enabled = true;
                dtpDesde.Enabled = true;
            }
            else
            {
                dtmHasta.Enabled = false;
                dtpDesde.Enabled = false;
            }
        }
    }
}
