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
using static MemoryClubForms.BusinessBO.CateringBO;

namespace MemoryClubForms.Forms
{
    public partial class CateringForm : Form
    {
        public string fechaini;
        public string fechafin;

        public int action = 0;//Valida que acción debe realizar el boton de guardar. si insertar o editar, insertar=1 y editar =2

        public int idAsistenciaSelected = 0;

        public int idClienteSelected = 0;

        public int filaSeleccionada = 0;

        public CateringModel asistenciaModel = new CateringModel();

        public static int sucursalUser = VariablesGlobales.sucursal;

        /// <summary>
        /// Clase que es parte de AsistenciaBO
        /// </summary>
        public static List<NombresClientes> nombresClientesList = new List<NombresClientes>();

        public static List<NombresColaboradores> nombresColaboradoresList = new List<NombresColaboradores>();

        public static List<TiposClientes> tiposClientesList = new List<TiposClientes>();

        public static List<TiposMenus> tipoMenusList = new List<TiposMenus>();

        public static List<CodigosSucursales> sucursalesList = new List<CodigosSucursales>();

        List<string> estadoClienteList = new List<string>();

        public static bool actionsInUse = true;
        public CateringForm()
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

        #region Cargar Informacion

        private void LoadInformation()
        {
            try
            {
                grdCatering.Rows.Clear();

                CateringBO cateringBO = new CateringBO();
                List<CateringModel> cateringList = cateringBO.ConsultaCatering(null, null,null,null, 0, 0,null);

                if (cateringList.Count > 0)
                {


                    foreach (var catering in cateringList)
                    {
                        grdCatering.Rows.Add(catering.Id_catering, catering.Fk_id_cliente,catering.Nombre, catering.Tipo_cliente,catering.Tipo_menu, catering.Fecha, catering.Hora, catering.Observacion, catering.Sucursal, catering.Usuario, catering.Fecha_mod);
                    }
                    grdCatering.ReadOnly = true;
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

        /// <summary>
        /// Carga los elementos de insert y elementos de filtro con la informacion necesaria
        /// </summary>
        /// <returns></returns>
        private bool ValidarInformacionElementosFiltros()
        {
            bool responseClientes = LoadNombresClientes();

            bool responseTipoCliente = LoadTipoCliente();

            bool responseTipoMenu = LoadTipoMenu();

            bool responseSucursales = LoadSucursales();

            bool reponseColaboradores = LoadNombresColaboradores();

            if (!responseClientes || !responseTipoCliente || !responseTipoMenu || !responseSucursales||!reponseColaboradores)
            {
                 return false;
            }

            return true;
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

            foreach (var item in tipoMenusList)
            {
                cbxFiltroMenu.Items.Add(item.TipoMenu);
            }

            foreach (var item in sucursalesList)
            {
                cbxFiltroSucursal.Items.Add(item.Sucursales.ToString());
            }

            cbxFiltroEstadoCliente.Items.Add("Activo");
            cbxFiltroEstadoCliente.Items.Add("Prueba");
            cbxFiltroEstadoCliente.Items.Add("Inactivo");

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


            foreach (var item in tipoMenusList)
            {
                cbxMenu.Items.Add(item.TipoMenu);
            }

            foreach (var item in sucursalesList)
            {
                cbxSucursal.Items.Add(item.Sucursales);
            }

            txtHora.Text = "08:15";
        }

        private bool LoadNombresClientes()
        {
            try
            {
                nombresClientesList = new List<NombresClientes>();
                CateringBO cateringBO = new CateringBO();
                nombresClientesList = cateringBO.LoadClientes();
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
                CateringBO cateringBO = new CateringBO();
                nombresColaboradoresList = cateringBO.LoadNombresColaboradores();
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
                CateringBO cateringBO = new CateringBO();
                tiposClientesList = cateringBO.LoadTiposClientes();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool LoadTipoMenu()
        {
            try
            {
                tipoMenusList = new List<TiposMenus>();
                CateringBO cateringBO = new CateringBO();
                tipoMenusList = cateringBO.LoadTiposMenus();
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
                sucursalesList = new List<CodigosSucursales>();
                CateringBO cateringBO = new CateringBO();
                sucursalesList = cateringBO.LoadSucursales();
                return true;
            }
            catch
            {
                return false;
            }
        }


        #endregion

        private void btnInsertarClicked(object sender, EventArgs e)
        {
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
        private void btnEdit_Clicked(object sender, EventArgs e)
        {

            if (cbxNombresClientes.Items.Count == 0) //Valida que tenga un item seleccionado del grid
            {
                return;
            }
            btnGuardar.Enabled = true;
            btnGuardar.Visible = true;

            lblAction.Text = "Editando";

            action = 2;

            EditElements(2);//Cambia de aspecto a los elementos para indicar al usuario que se realizara una accion, en este caso insertar
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxNombresClientes.Items.Count == 0) //Valida que tenga un item seleccionado del grid
                {
                    return;
                }

                DialogResult response = MessageBox.Show("Eliminar item seleccionado", "Está seguro de que desea eliminar este elemento?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (response == DialogResult.Yes)
                {
                    CateringBO cateringBO = new CateringBO();
                    CateringModel cateringModel = new CateringModel();

                    string nombreCliente = cbxNombresClientes.SelectedItem.ToString();
                    cateringModel.Id_catering = idAsistenciaSelected;
                    cateringModel.Fk_id_cliente = idClienteSelected;
                    if (nombresClientesList.Select(x => x.nombre == nombreCliente).FirstOrDefault())
                    {
                        cateringModel.Tipo_cliente = tiposClientesList.Where(x => x.TipoCliente == "CLIENTE").Select(x => x.TipoCliente).FirstOrDefault();

                    }
                    else if (nombresColaboradoresList.Select(x => x.nombre == nombreCliente).FirstOrDefault())
                    {
                        cateringModel.Tipo_cliente = tiposClientesList.Where(x => x.TipoCliente == "COLABORADOR").Select(x => x.TipoCliente).FirstOrDefault();
                    }

                    cateringModel.Tipo_menu = cbxMenu.SelectedItem.ToString();
                    cateringModel.Fecha = dtmFecha.Value.ToString("dd/MM/yyyy");
                    cateringModel.Hora = txtHora.Text;
                    cateringModel.Observacion = txtObservciones.Text;
                    cateringModel.Sucursal = int.Parse(cbxSucursal.SelectedItem.ToString());
                    cateringModel.Usuario = VariablesGlobales.usuario.ToString();
                    cateringModel.Fecha_mod = DateTime.Now.ToString("dd/MM/yyyy");

                    bool responseDB = cateringBO.EliminarCatering(cateringModel.Id_catering);
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

        //Carga la informacion de los elementos de insert
        private void RowGrid_Clicked(object sender, DataGridViewCellEventArgs e)
        {
            if (!actionsInUse)
            {
                return;
            }

            filaSeleccionada = e.RowIndex;

            idAsistenciaSelected = 0;
            idClienteSelected = 0;

            //Valida que el clic no sea de los headers
            if (filaSeleccionada != -1)
            {
                idAsistenciaSelected = int.Parse(grdCatering.Rows[filaSeleccionada].Cells[0].Value.ToString());

                idClienteSelected = int.Parse(grdCatering.Rows[filaSeleccionada].Cells[1].Value.ToString());

                cbxNombresClientes.Items.Clear();//Limpia los valores que pueda tener
                cbxNombresClientes.SelectedItem = (string)grdCatering.Rows[filaSeleccionada].Cells[2].Value;//Selecciona ese valor y lo guarda como objeto
                cbxNombresClientes.Items.Add((string)grdCatering.Rows[filaSeleccionada].Cells[2].Value);//Son los valores que puede seleccionar
                cbxNombresClientes.Text = (string)grdCatering.Rows[filaSeleccionada].Cells[2].Value;//Es el texto que aparece en el recuadro

                cbxMenu.Items.Clear();
                cbxMenu.SelectedItem = (string)grdCatering.Rows[filaSeleccionada].Cells[4].Value;
                cbxMenu.Items.Add((string)grdCatering.Rows[filaSeleccionada].Cells[4].Value);
                cbxMenu.Text = (string)grdCatering.Rows[filaSeleccionada].Cells[4].Value;

                string fecha = grdCatering.Rows[filaSeleccionada].Cells[5].Value.ToString();
                DateTime fechaDate = DateTime.ParseExact(fecha, "dd/MM/yyyy", null);

                dtmFecha.Value = fechaDate;

                txtHora.Text = (string)grdCatering.Rows[filaSeleccionada].Cells[6].Value;

                txtObservciones.Text = (string)grdCatering.Rows[filaSeleccionada].Cells[7].Value;

                cbxSucursal.Items.Clear();
                cbxSucursal.SelectedItem = (string)grdCatering.Rows[filaSeleccionada].Cells[8].Value.ToString();
                _ = cbxSucursal.Items.Add((string)grdCatering.Rows[filaSeleccionada].Cells[8].Value.ToString());
                cbxSucursal.Text = (string)grdCatering.Rows[filaSeleccionada].Cells[8].Value.ToString();

            }
        }

        private void CleanData()
        {
            idAsistenciaSelected = 0;
            idClienteSelected = 0;

            cbxNombresClientes.Items.Clear();//Limpia los valores que pueda tene
            cbxNombresClientes.Text = "";

            cbxMenu.Items.Clear();//Limpia los valores que pueda tene
            cbxMenu.Text = "";

            dtmFecha.Value = DateTime.Today;

            txtHora.Text = "";

            txtObservciones.Text = "";

            cbxSucursal.Items.Clear();
            cbxSucursal.Text = "";

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
                txtHora.Enabled = true;
                txtObservciones.Enabled = true;
            }
            else if (action == 2)
            {
                btnInsertar.BackColor = Color.FromArgb(160, 160, 160);
                btnInsertar.ForeColor = Color.FromArgb(221, 221, 221);
                btnInsertar.FlatAppearance.BorderColor = Color.FromArgb(221, 221, 221);
                btnInsertar.Enabled = false;

                txtHora.Enabled = true;
                txtObservciones.Enabled = true;
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

        private void btnReiniciarFiltro_Click(object sender, EventArgs e)
        {
            cbxFiltroNombreCliente.Items.Clear();

            cbxFiltroMenu.Items.Clear();

            cbxFiltroSucursal.Items.Clear();

            cbxFiltroTipoCli.Items.Clear();

            cbxFiltroEstadoCliente.Items.Clear();

            ckbFiltrarFechas.Checked = false;
          
            LoadInformation();

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
                    CateringBO cateringBO = new CateringBO();
                    CateringModel cateringModel = new CateringModel();

                    var nombreCliente = cbxNombresClientes.SelectedItem.ToString();

                    cateringModel.Fk_id_cliente = nombresClientesList.Where(x => x.nombre == nombreCliente).Select(x => x.Id_Cliente).FirstOrDefault();
                    if (cateringModel.Fk_id_cliente==0)
                    {
                        cateringModel.Fk_id_cliente = nombresColaboradoresList.Where(x => x.nombre == nombreCliente).Select(x => x.Id_colaborador).FirstOrDefault();
                    }

                    string cliente = nombresClientesList.Where(x => x.nombre == nombreCliente).Select(x=>x.nombre).FirstOrDefault();
                    string colaborador = nombresColaboradoresList.Where(x => x.nombre == nombreCliente).Select(x=>x.nombre).FirstOrDefault();

                    if (!string.IsNullOrEmpty(cliente))
                    {
                        cateringModel.Tipo_cliente = tiposClientesList.Where(x => x.TipoCliente == "CLIENTE").Select(x => x.TipoCliente).FirstOrDefault();

                    }
                    else if (!string.IsNullOrEmpty(colaborador))
                    {
                        cateringModel.Tipo_cliente = tiposClientesList.Where(x => x.TipoCliente == "COLABORADOR").Select(x => x.TipoCliente).FirstOrDefault();
                    }

                    cateringModel.Tipo_menu = cbxMenu.SelectedItem.ToString();
                    cateringModel.Fecha = dtmFecha.Value.ToString("dd/MM/yyyy");
                    cateringModel.Hora = txtHora.Text;
                    cateringModel.Observacion = txtObservciones.Text;
                    cateringModel.Sucursal = int.Parse(cbxSucursal.SelectedItem.ToString());
                    cateringModel.Usuario = VariablesGlobales.usuario.ToString();
                    cateringModel.Fecha_mod = DateTime.Now.ToString("dd/MM/yyyy");

                    bool responseInsert = cateringBO.InsertarCatering(cateringModel);

                    if (!responseInsert)
                    {
                        MessageBox.Show("No se pudo guardar la información, inténtelo más tarde.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    MessageBox.Show("La información se ha guardado EXITOSAMENTE!","Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    CateringBO cateringBO = new CateringBO();
                    CateringModel cateringModel= new CateringModel();

                    string nombreCliente = cbxNombresClientes.SelectedItem.ToString();

                    cateringModel.Id_catering = idAsistenciaSelected;
                    cateringModel.Fk_id_cliente = idClienteSelected;
                    cateringModel.Nombre = nombreCliente;

                    string cliente = nombresClientesList.Where(x => x.nombre == nombreCliente).Select(x => x.nombre).FirstOrDefault();
                    string colaborador = nombresColaboradoresList.Where(x => x.nombre == nombreCliente).Select(x => x.nombre).FirstOrDefault();

                    if (!string.IsNullOrEmpty(cliente))
                    {
                        cateringModel.Tipo_cliente = tiposClientesList.Where(x => x.TipoCliente == "CLIENTE").Select(x => x.TipoCliente).FirstOrDefault();

                    }
                    else if (!string.IsNullOrEmpty(colaborador))
                    {
                        cateringModel.Tipo_cliente = tiposClientesList.Where(x => x.TipoCliente == "COLABORADOR").Select(x => x.TipoCliente).FirstOrDefault();
                    }
                

                    cateringModel.Tipo_menu = cbxMenu.SelectedItem.ToString();
                    cateringModel.Fecha = dtmFecha.Value.ToString("dd/MM/yyyy");
                    cateringModel.Hora = txtHora.Text;
                    cateringModel.Observacion = txtObservciones.Text;
                    cateringModel.Sucursal = int.Parse(cbxSucursal.SelectedItem.ToString());
                    cateringModel.Usuario = VariablesGlobales.usuario.ToString();
                    cateringModel.Fecha_mod = DateTime.Now.ToString("dd/MM/yyyy");

                    bool response = cateringBO.ActualizarCatering(cateringModel);
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
                MessageBox.Show("Alerta, No se pudo guardar el registro\n" + ex.Message ,"Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private bool ValidarInformacion()
        {
            if (VariablesGlobales.Nivel > 1 && VariablesGlobales.sucursal != int.Parse(cbxSucursal.SelectedItem.ToString()))
            {
                MessageBox.Show("Su usuario no tiene privilegios necesarios para ingresar asistencias de otra sucursal.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (cbxNombresClientes.SelectedItem == null)
            {
                MessageBox.Show("Seleccione el nombre del cliente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (cbxMenu.SelectedItem == null)
            {
                MessageBox.Show("Seleccione el tipo de menú.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (cbxSucursal.SelectedItem == null)
            {
                MessageBox.Show("Seleccione la sucursal.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (!ValidateHora())
            {
                return false;
            }

            if (txtObservciones.Text.Length > 100)
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

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                CateringBO cateringBO = new CateringBO();

                List<CateringModel> cateringList = new List<CateringModel>();

                bool check = ckbFiltrarFechas.Checked;

                cateringList = new List<CateringModel>();

                string nombre = null;

                if (cbxFiltroNombreCliente.SelectedItem!=null)
                {
                    nombre=cbxFiltroNombreCliente.SelectedItem.ToString();
                }

                int idCliente = nombresClientesList.Where(x => x.nombre == nombre).Select(x => x.Id_Cliente).FirstOrDefault();

                if (idCliente <= 0)
                {
                    idCliente = nombresColaboradoresList.Where(x => x.nombre == nombre).Select(x => x.Id_colaborador).FirstOrDefault();
                }


                grdCatering.Rows.Clear();

                string estado = null;

                if (cbxFiltroEstadoCliente.SelectedItem!=null)
                {
                    estado = cbxFiltroEstadoCliente.SelectedItem.ToString();
                }
                

                string pEstado = null;

                if (estado == "Activo")
                {
                    pEstado = "A";

                }
                else if (estado == "Prueba")
                {
                    pEstado = "P";
                }
                else if (estado == "Inactivo")//estado = Inactivo
                {
                    pEstado = "I";
                }

                string fechaDesde = null;
                string fechaHasta = null;

                if (check)
                {
                    fechaDesde = dtpDesde.Value.ToString("dd/MM/yyyy");
                    fechaHasta = dtmHasta.Value.ToString("dd/MM/yyyy");
                }

                string tipoCliente=null;

                if (cbxFiltroTipoCli.SelectedItem!=null)
                {
                    tipoCliente = cbxFiltroTipoCli.SelectedItem.ToString();
                }

                string tipoMenu = null;

                if (cbxFiltroMenu.SelectedItem != null)
                {
                    tipoMenu = cbxFiltroMenu.SelectedItem.ToString();
                }

                int sucursal = sucursalUser;

                if (cbxFiltroSucursal.SelectedItem != null)
                {
                    sucursal = int.Parse(cbxFiltroSucursal.SelectedItem.ToString());
                }

                cateringList = cateringBO.ConsultaCatering(fechaDesde, fechaHasta, tipoCliente,tipoMenu ,sucursal , idCliente, pEstado);

                if (cateringList.Count > 0)
                {


                    foreach (var catering in cateringList)
                    {
                        grdCatering.Rows.Add(catering.Id_catering, catering.Fk_id_cliente, catering.Nombre, catering.Tipo_cliente, catering.Tipo_menu, catering.Fecha, catering.Hora, catering.Observacion, catering.Sucursal, catering.Usuario, catering.Fecha_mod);
                    }
                    grdCatering.ReadOnly = true;
                }

            }catch(Exception ex)
            {
                CleanData();
                LoadInformation();
                MessageBox.Show("Alerta, No se pudo filtrarel registro\n" + ex.Message,"Aviso",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }       
        }
    }
}

