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
using MemoryClubForms.Models;
using static MemoryClubForms.BusinessBO.TransportistaBO;

namespace MemoryClubForms.Forms
{
    public partial class TransportistaForm : Form
    {
        public int action = 0;//Valida que acción debe realizar el boton de guardar. si insertar o editar, insertar=1 y editar =2

        public int idTransportista = 0;

        public int filaSeleccionada = 0;

        public static int sucursalUser = VariablesGlobales.sucursal;

        public static List<CodigosSucursales> codigosSucursalesList = new List<CodigosSucursales>();

        public static List<CodigosEstados> codigosEstadosList = new List<CodigosEstados>();

        public static List<TransportistaModel> TransportistaListComplete = new List<TransportistaModel>();

        public static List<CodigosSectores> sectoresList = new List<CodigosSectores>();

        public static List<CodigosRutas> rutasList = new List<CodigosRutas>();

        public static bool actionsInUse = true;
        public TransportistaForm()
        {
            InitializeComponent();

            LoadInformation();
        }

        private void btnReiniciarFiltro_Click(object sender, EventArgs e)
        {
            ResetFilterElements();
            LoadInformation();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CleanData();
            ResetElements();
        }

        private void LoadInformation()
        {
            try
            {
                grdTransportista.Rows.Clear();
                ResetFilterElements();

                TransportistaBO transportistaBO = new TransportistaBO();
                TransportistaListComplete = new List<TransportistaModel>();
                List<TransportistaModel> transportistaList = transportistaBO.ConsultaTransportista(0,0,0,null);

                if (transportistaList.Count > 0)
                {
                    TransportistaListComplete = transportistaList;
                    foreach (var trsp in transportistaList)
                    {
                        grdTransportista.Rows.Add(trsp.Id_transportista,trsp.Nombre,trsp.Cedula,trsp.Sucursal,trsp.Direccion,trsp.Telefono,trsp.Placa_veh,trsp.Estado, trsp.Sector, trsp.Ruta,trsp.Observacion,trsp.Usuario,trsp.Fecha_mod);
                    }
                    grdTransportista.ReadOnly = true;
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
                MessageBox.Show("No se pudo cargar los datos para realizar filtros" + ex, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void CargarElemFiltros()
        {

            foreach (var item in TransportistaListComplete)
            {
                cbxFiltroNombreTransp.Items.Add(item.Nombre);
            }

            foreach (var item in codigosSucursalesList)
            {
                cbxFiltroSucursal.Items.Add(item.Sucursales.ToString());
            }
            
            foreach (var item in codigosEstadosList)
            {
                cbxFiltroEstado.Items.Add(item.Estados.ToString());
            }
            cbxFiltroEstado.Items.Add("TODOS");

            foreach (var item in rutasList)
            {
                cbxFiltroRuta.Items.Add(item.Rutas);
            }

            foreach (var item in sectoresList)
            {
                cbxFiltroSector.Items.Add(item.Sectores.ToString());
            }
        }

        private void CargarElementsEdit()
        {

            foreach (var item in codigosEstadosList)
            {
                if (cbxEstado.SelectedItem.ToString().ToLower() != item.Estados.ToLower())
                {
                    cbxEstado.Items.Add(item.Estados);
                }
                
            }

            foreach (var item in rutasList)
            {
                if (int.Parse(cbxRuta.SelectedItem.ToString()) != item.Rutas)
                {
                    cbxRuta.Items.Add(item.Rutas);
                }
                
            }

            foreach (var item in sectoresList)
            {
                if (cbxSector.SelectedItem.ToString().ToLower() != item.Sectores.ToLower())
                {
                    cbxSector.Items.Add(item.Sectores);
                }
                
            }
        }

        private void CargarElemActions()
        {
            //Cargo el nombre de los clientes y de los colaboradores
            foreach (var item in codigosSucursalesList)
            {
                cbxSucursal.Items.Add(item.Sucursales);
            }

            foreach (var item in rutasList)
            {
                cbxRuta.Items.Add(item.Rutas);
            }

            foreach (var item in sectoresList)
            {
                cbxSector.Items.Add(item.Sectores);
            }

        }

        private void ResetFilterElements()
        {
            cbxFiltroNombreTransp.Items.Clear();

            cbxFiltroSucursal.Items.Clear();

            cbxFiltroEstado.Items.Clear();

            cbxFiltroSector.Items.Clear();

            cbxFiltroRuta.Items.Clear();
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

            tbxNombreTransp.Enabled = false;
            tbxCedula.Enabled = false;
            tbxDireccion.Enabled = false;
            tbxTelefono.Enabled = false;
            tbxPlaca.Enabled = false;
            txtObservciones.Enabled = false;

            btnFiltrar.Enabled = true;
            btnFiltrar.Visible = true;

            actionsInUse = true;
        }

        private void CleanData()
        {
            idTransportista = 0;

            cbxSucursal.Items.Clear();//Limpia los valores que pueda tene
            cbxSucursal.Text = "";

            lblEstado.Visible=false;

            cbxEstado.Visible = false;
            cbxEstado.Enabled = false;
            cbxEstado.Items.Clear();
            cbxEstado.Text = "";

            cbxSector.Items.Clear();
            cbxSector.Text = "";

            cbxRuta.Items.Clear();
            cbxRuta.Text = "";

            tbxNombreTransp.Text = "";

            tbxCedula.Text = "";

            tbxDireccion.Text = "";

            tbxTelefono.Text = "";

            tbxPlaca.Text = "";

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

            tbxNombreTransp.Enabled = true;
            tbxCedula.Enabled = true;
            tbxDireccion.Enabled = true;
            tbxTelefono.Enabled = true;
            tbxPlaca.Enabled = true;
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

                tbxCedula.Enabled = false;
                tbxNombreTransp.Enabled = false;

                CargarElementsEdit();

            }


            btnFiltrar.Enabled = false;
            btnFiltrar.Visible = false;
        }
 
        private bool LoadSucursales()
        {
            try
            {
                codigosSucursalesList = new List<CodigosSucursales>();
                TransportistaBO transportistaBO = new TransportistaBO();
                codigosSucursalesList = transportistaBO.LoadSucursales();
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
                TransportistaBO transportistaBO = new TransportistaBO();
                codigosEstadosList = transportistaBO.LoadEstados();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool LoadSectores()
        {
            try
            {
                sectoresList = new List<CodigosSectores>();
                TransportistaBO transportistaBO = new TransportistaBO();
                sectoresList = transportistaBO.LoadSectores();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool LoadRutas()
        {
            try
            {
                rutasList = new List<CodigosRutas>();
                TransportistaBO transportistaBO = new TransportistaBO();
                rutasList = transportistaBO.LoadRutas();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool ValidarInformacionElementosFiltros()
        {
            bool responseEstados = LoadEstados();

            bool responseSucursales = LoadSucursales();

            bool responseSectores = LoadSectores();

            bool responseRutas = LoadRutas();

            if (!responseEstados || !responseSucursales || !responseSectores || !responseRutas)
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
            //Transportista
            if (string.IsNullOrEmpty(tbxNombreTransp.Text))
            {
                MessageBox.Show("Ingrese el nombre", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (tbxNombreTransp.Text.Length > 80)
            {
                MessageBox.Show("Has superado el número de caracteres del nombre.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            //Ruta
            if (cbxRuta.SelectedItem==null)
            {
                MessageBox.Show("Seleccione la ruta.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            //Sector
            if (cbxSector.SelectedItem == null)
            {
                MessageBox.Show("Seleccione el sector.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            //Cedula
            if (string.IsNullOrEmpty(tbxCedula.Text))
            {
                MessageBox.Show("Ingrese la cédula.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (tbxCedula.Text.Length > 50)
            {
                MessageBox.Show("Has superado el número de caracteres en cédula.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            //Sucursal
            if (cbxSucursal.SelectedItem == null)
            {
                MessageBox.Show("Seleccione la sucursal.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            //Direccion
            if (string.IsNullOrEmpty(tbxDireccion.Text))
            {
                MessageBox.Show("Ingrese la dirección.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (tbxDireccion.Text.Length > 80)
            {
                MessageBox.Show("Has superado el número de caracteres en dirección.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            //Telefono
            if (string.IsNullOrEmpty(tbxTelefono.Text))
            {
                MessageBox.Show("Ingrese el teléfono del cliente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (tbxTelefono.Text.Length > 50)
            {
                MessageBox.Show("Has superado el número de caracteres en teléfono.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            //Placa
            if (string.IsNullOrEmpty(tbxPlaca.Text))
            {
                MessageBox.Show("Ingrese la placa.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (tbxPlaca.Text.Length > 50)
            {
                MessageBox.Show("Has superado el número de caracteres en Placa.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            //observaciones
            if (txtObservciones.Text.Length > 50)
            {
                MessageBox.Show("Has superado el número de caracteres para Observación. Caracteres máximos: 100", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        private void Row_Clicked(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (!actionsInUse)
                {
                    return;
                }

                filaSeleccionada = e.RowIndex;

                idTransportista = 0;

                //Valida que el clic no sea de los headers
                if (filaSeleccionada != -1)
                {
                    idTransportista = int.Parse(grdTransportista.Rows[filaSeleccionada].Cells[0].Value.ToString());

                    tbxNombreTransp.Text = (string)grdTransportista.Rows[filaSeleccionada].Cells[1].Value.ToString();

                    tbxCedula.Text = (string)grdTransportista.Rows[filaSeleccionada].Cells[2].Value;

                    cbxSucursal.Items.Clear();
                    cbxSucursal.SelectedItem = (string)grdTransportista.Rows[filaSeleccionada].Cells[3].Value.ToString();
                    cbxSucursal.Items.Add((string)grdTransportista.Rows[filaSeleccionada].Cells[3].Value.ToString());
                    cbxSucursal.Text = (string)grdTransportista.Rows[filaSeleccionada].Cells[3].Value.ToString();

                    tbxDireccion.Text = (string)grdTransportista.Rows[filaSeleccionada].Cells[4].Value;

                    tbxTelefono.Text = (string)grdTransportista.Rows[filaSeleccionada].Cells[5].Value;

                    tbxPlaca.Text = (string)grdTransportista.Rows[filaSeleccionada].Cells[6].Value;

                    cbxEstado.Items.Clear();
                    cbxEstado.SelectedItem = (string)grdTransportista.Rows[filaSeleccionada].Cells[7].Value.ToString();
                    cbxEstado.Items.Add((string)grdTransportista.Rows[filaSeleccionada].Cells[7].Value.ToString());
                    cbxEstado.Text = (string)grdTransportista.Rows[filaSeleccionada].Cells[7].Value.ToString();

                    cbxSector.Items.Clear();
                    cbxSector.SelectedItem = (string)grdTransportista.Rows[filaSeleccionada].Cells[8].Value.ToString();
                    cbxSector.Items.Add((string)grdTransportista.Rows[filaSeleccionada].Cells[8].Value.ToString());
                    cbxSector.Text = (string)grdTransportista.Rows[filaSeleccionada].Cells[8].Value.ToString();

                    cbxRuta.Items.Clear();
                    cbxRuta.SelectedItem = (string)grdTransportista.Rows[filaSeleccionada].Cells[9].Value.ToString();
                    cbxRuta.Items.Add((string)grdTransportista.Rows[filaSeleccionada].Cells[9].Value.ToString());
                    cbxRuta.Text = (string)grdTransportista.Rows[filaSeleccionada].Cells[9].Value.ToString();

                    txtObservciones.Text = (string)grdTransportista.Rows[filaSeleccionada].Cells[10].Value;
                }
            }
            catch (Exception ex)
            {

            }
            
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                TransportistaBO transportistaBO = new TransportistaBO();

                List<TransportistaModel> transportistaList = new List<TransportistaModel>();

                grdTransportista.Rows.Clear();

                string nombre = null;

                if (cbxFiltroNombreTransp.SelectedItem != null)
                {
                    nombre = cbxFiltroNombreTransp.SelectedItem.ToString();
                }

                int idTransportista = TransportistaListComplete.Where(x => x.Nombre == nombre).Select(x => x.Id_transportista).FirstOrDefault();

                int sucursal = 0;

                if (cbxFiltroSucursal.SelectedItem != null)
                {
                    sucursal = int.Parse(cbxFiltroSucursal.SelectedItem.ToString());
                }

                int ruta = 0;

                if (cbxFiltroRuta.SelectedItem != null)
                {
                    ruta = int.Parse(cbxFiltroRuta.SelectedItem.ToString());
                }

                string sector=null;

                if (cbxFiltroSector.SelectedItem != null)
                {
                    sector = cbxFiltroSector.SelectedItem.ToString();
                }

                string estado = null;
                string pEstado = null;

                if (cbxFiltroEstado.SelectedItem != null)
                {
                    estado = cbxFiltroEstado.SelectedItem.ToString();
                }

                pEstado = codigosEstadosList.Where(x => x.Estados == estado).Select(x => x.Estados).FirstOrDefault();


                transportistaList = transportistaBO.ConsultaTransportista(idTransportista,sucursal,ruta,sector);

                if (transportistaList.Count > 0)
                {
                    TransportistaListComplete = transportistaList;

                    foreach (var trsp in transportistaList)
                    {
                        grdTransportista.Rows.Add(trsp.Id_transportista, trsp.Nombre, trsp.Cedula, trsp.Sucursal, trsp.Direccion, trsp.Telefono, trsp.Placa_veh, trsp.Estado, trsp.Sector, trsp.Ruta, trsp.Observacion, trsp.Usuario, trsp.Fecha_mod);
                    }
                    grdTransportista.ReadOnly = true;
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
            try
            {
                if (string.IsNullOrEmpty(tbxNombreTransp.Text)) //Valida que tenga un item seleccionado del grid
                {
                    return;
                }
                /*if (cbxEstado.SelectedItem.ToString() == "I")
                {
                    MessageBox.Show("Este registro está en estado Inactivo y no se lo puede editar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }*/
                if (idTransportista == 1)
                {
                    MessageBox.Show("Este registro no está permitido editarse o eliminarse.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (string.IsNullOrEmpty(tbxNombreTransp.Text)) //Valida que tenga un item seleccionado del grid
                {
                    return;
                }
                if (idTransportista == 1)
                {
                    MessageBox.Show("Este registro no está permitido editarse o eliminarse.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                DialogResult response = MessageBox.Show("Eliminar item seleccionado", "Está seguro de que desea eliminar este elemento?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (response == DialogResult.Yes)
                {
                    TransportistaBO transportistaBO = new TransportistaBO();
                    TransportistaModel transportistaModel = new TransportistaModel();
                 
                    transportistaModel.Id_transportista = idTransportista;

                    bool responseDB = transportistaBO.EliminarTransportista(transportistaModel.Id_transportista);
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
                MessageBox.Show("No se pudo eliminar el registro, inténtelo más tarde." + ex, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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
                    TransportistaBO transportistaBO = new TransportistaBO();
                    TransportistaModel transportistaModel = new TransportistaModel();

                    var nombreColaborador = tbxNombreTransp.Text;

                    transportistaModel.Nombre = nombreColaborador;
                    transportistaModel.Cedula = tbxCedula.Text;
                    transportistaModel.Ruta=int.Parse(cbxRuta.SelectedItem.ToString());
                    transportistaModel.Sector = cbxSector.SelectedItem.ToString();
                    transportistaModel.Placa_veh = tbxPlaca.Text;
                    transportistaModel.Telefono = tbxTelefono.Text;
                    transportistaModel.Direccion = tbxDireccion.Text;
                    transportistaModel.Estado = codigosEstadosList.Where(x => x.Estados == "A").Select(x => x.Estados).FirstOrDefault();
                    transportistaModel.Observacion = txtObservciones.Text;
                    transportistaModel.Sucursal = int.Parse(cbxSucursal.SelectedItem.ToString());
                    transportistaModel.Usuario = VariablesGlobales.usuario.ToString();
                    transportistaModel.Fecha_mod = DateTime.Now.ToString("dd/MM/yyyy");

                    bool responseInsert = transportistaBO.InsertaTransportista(transportistaModel);

                    if (!responseInsert)
                    {
                        MessageBox.Show("No se pudo guardar la información, inténtelo más tarde.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    MessageBox.Show("La información se ha guardado EXITOSAMENTE!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    TransportistaBO transportistaBO = new TransportistaBO();
                    TransportistaModel transportistaModel = new TransportistaModel();

                    var nombreColaborador = tbxNombreTransp.Text;

                    transportistaModel.Id_transportista = idTransportista;
                    transportistaModel.Nombre = nombreColaborador;
                    transportistaModel.Cedula = tbxCedula.Text;
                    transportistaModel.Ruta = int.Parse(cbxRuta.SelectedItem.ToString());
                    transportistaModel.Sector = cbxSector.SelectedItem.ToString();
                    transportistaModel.Placa_veh = tbxPlaca.Text;
                    transportistaModel.Telefono = tbxTelefono.Text;
                    transportistaModel.Direccion = tbxDireccion.Text;
                    transportistaModel.Estado = cbxEstado.SelectedItem.ToString();
                    transportistaModel.Observacion = txtObservciones.Text;
                    transportistaModel.Sucursal = int.Parse(cbxSucursal.SelectedItem.ToString());
                    transportistaModel.Usuario = VariablesGlobales.usuario.ToString();
                    transportistaModel.Fecha_mod = DateTime.Now.ToString("dd/MM/yyyy");


                    bool response = transportistaBO.ActualizarTransportista(transportistaModel);
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
