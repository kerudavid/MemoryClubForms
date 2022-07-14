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
using static MemoryClubForms.BusinessBO.AsistenciaBO;

namespace MemoryClubForms.Forms
{
    public partial class AsistenciaForm : Form
    {
        /// <summary>
        /// Fecha inicial y final
        /// </summary>
        public string fechaini;
        public string fechafin;

        public int action = 0;//Valida que acción debe realizar el boton de guardar. si insertar o editar, insertar=1 y editar =2

        public int idAsistenciaSelected= 0;

        public int idClienteSelected= 0;

        public int filaSeleccionada=0;

        public AsistenciaModel asistenciaModel = new AsistenciaModel();



        /// <summary>
        /// Clase que es parte de AsistenciaBO
        /// </summary>
        public static List<NombresClientes> nombresClientesList = new List<NombresClientes>();

        public static List<NombresUsuarios> nombresUsuariosList = new List<NombresUsuarios>();

        public static bool actionsUse = true;

        //Contiene los datos de la ultima consulta de asistencia.
        List<AsistenciaModel> asistenciaInfoList = new List<AsistenciaModel>();
        public AsistenciaForm(string fechaInicial, string fechaFinal)
        {
            InitializeComponent();

            fechaini = fechaInicial;
            fechafin = fechaFinal;

            dtmFecha.MinDate = new DateTime(1990, 1, 1);
            dtmFecha.MaxDate = DateTime.Today;

            dtpDesde.MinDate = new DateTime(1990, 1, 1);
            dtpDesde.MaxDate = DateTime.Today;

            dtmHasta.MinDate = new DateTime(1990, 1, 1);
            dtmHasta.MaxDate = DateTime.Today;

            

        }
        

        #region Carga de elementos de informacion

        /// <summary>
        /// Carga la informacion de la pagina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AsistenciaForm_Load(object sender, EventArgs e)
        {
            try
            {
                asistenciaInfoList = new List<AsistenciaModel>();
                AsistenciaBO asistenciaBO = new AsistenciaBO();
                List<AsistenciaModel> asistenciaList = asistenciaBO.ConsultarPeriodoAsis(this.fechaini, this.fechafin);

                if (asistenciaList.Count > 0)
                {
                    asistenciaInfoList = asistenciaList;

                    foreach (var asistencia in asistenciaList)
                    {
                        grdAsistencia.Rows.Add(asistencia.Id_asistencia, asistencia.Fk_id_cliente, asistencia.Nombre, asistencia.Fecha, asistencia.Hora, asistencia.Observacion, asistencia.Sucursal, asistencia.Usuario, asistencia.Fecha_mod);
                    }
                    grdAsistencia.ReadOnly = true;
                }

                bool response = LoadNombresClientes();

                if (!response)
                {
                    MessageBox.Show("No se pudo cargar el nombre de los clientes para realizar filtros","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    return;
                }
                foreach (var item in nombresClientesList)
                {
                    cbxFiltroNombreCliente.Items.Add(item.nombre);
                }

                cbxEstadoCliente.Items.Add("Activo");
                cbxEstadoCliente.Items.Add("Prueba");
                cbxEstadoCliente.Items.Add("Inactivo");


            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar el nombre de los clientes para realizar filtros"+ex, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
                
        }

        /// <summary>
        /// Envia la informacion de la fila seleccionada del grid, a los combobox y textbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EnviarInfo_Clicked(object sender, DataGridViewCellEventArgs e)
        {
            if (!actionsUse)
            {
                return;
            } 

            filaSeleccionada = e.RowIndex;

            idAsistenciaSelected = 0;
            idClienteSelected = 0;

            //Valida que el clic no sea de los headers
            if (filaSeleccionada != -1)
            {
                idAsistenciaSelected = int.Parse(grdAsistencia.Rows[filaSeleccionada].Cells[0].Value.ToString());

                idClienteSelected = int.Parse(grdAsistencia.Rows[filaSeleccionada].Cells[1].Value.ToString());

                cbxNombresClientes.Items.Clear();//Limpia los valores que pueda tener
                cbxNombresClientes.SelectedItem = (string)grdAsistencia.Rows[filaSeleccionada].Cells[2].Value;//Selecciona ese valor y lo guarda como objeto
                cbxNombresClientes.Items.Add((string)grdAsistencia.Rows[filaSeleccionada].Cells[2].Value);//Son los valores que puede seleccionar
                cbxNombresClientes.Text= (string)grdAsistencia.Rows[filaSeleccionada].Cells[2].Value;//Es el texto que aparece en el recuadro

                string fecha = grdAsistencia.Rows[filaSeleccionada].Cells[3].Value.ToString();
                DateTime fechaDate= DateTime.ParseExact(fecha, "dd/MM/yyyy", null);


                //dtmFecha.CustomFormat = "MMMM dd, yyyy - dddd";
                //dtmFecha.Format = DateTimePickerFormat.Custom;

                dtmFecha.Value = fechaDate;

                txtHora.Text = (string)grdAsistencia.Rows[filaSeleccionada].Cells[4].Value;

                txtObservciones.Text = (string)grdAsistencia.Rows[filaSeleccionada].Cells[5].Value;

                cbxSucursal.Items.Clear();
                cbxSucursal.SelectedItem = (string)grdAsistencia.Rows[filaSeleccionada].Cells[6].Value.ToString();
                _ = cbxSucursal.Items.Add((string)grdAsistencia.Rows[filaSeleccionada].Cells[6].Value.ToString());
                cbxSucursal.Text = (string)grdAsistencia.Rows[filaSeleccionada].Cells[6].Value.ToString();

            }
        }


        /// <summary>
        /// Vuelve a cargar la informacion depues de editar, eliminar o insertar un registro
        /// </summary>
        private void ReloadInformation()
        {
            try
            {
                asistenciaInfoList = new List<AsistenciaModel>();
                grdAsistencia.Rows.Clear();
                AsistenciaBO asistenciaBO = new AsistenciaBO();
                List<AsistenciaModel> asistenciaList = asistenciaBO.ConsultarPeriodoAsis(this.fechaini, this.fechafin);

                if (asistenciaList.Count > 0)
                {
                    asistenciaInfoList = asistenciaList;

                    foreach (var asistencia in asistenciaList)
                    {
                        grdAsistencia.Rows.Add(asistencia.Id_asistencia, asistencia.Fk_id_cliente, asistencia.Nombre, asistencia.Fecha, asistencia.Hora, asistencia.Observacion, asistencia.Sucursal, asistencia.Usuario, asistencia.Fecha_mod);
                    }
                    grdAsistencia.ReadOnly = true;
                }

                bool response = LoadNombresClientes();

                if (!response)
                {
                    MessageBox.Show("Aviso, no se pudo cargar el nombre de los clientes para realizar filtros");
                    return;
                }
                foreach (var item in nombresClientesList)
                {
                    cbxFiltroNombreCliente.Items.Add(item.nombre);
                }

                cbxEstadoCliente.Items.Add("Activo");
                cbxEstadoCliente.Items.Add("Prueba");
                cbxEstadoCliente.Items.Add("Inactivo");
            } 
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar el nombre de los clientes para realizar filtros" + ex, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }


        private void CargarInformacionFiltrada(List<AsistenciaModel> asistenciaList)
        {
            grdAsistencia.Rows.Clear();

            if (asistenciaList.Count > 0)
            {
                asistenciaInfoList = asistenciaList;

                foreach (var asistencia in asistenciaList)
                {
                    grdAsistencia.Rows.Add(asistencia.Id_asistencia, asistencia.Fk_id_cliente, asistencia.Nombre, asistencia.Fecha, asistencia.Hora, asistencia.Observacion, asistencia.Sucursal, asistencia.Usuario, asistencia.Fecha_mod);
                }
                grdAsistencia.ReadOnly = true;
            }
            else
            {
                MessageBox.Show("No se encontró información.", "Aviso", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }

        }


        /// <summary>
        /// Consulta y recupera los nombres de los clientes
        /// </summary>
        /// <returns></returns>
        public bool LoadNombresClientes()
        {
            try
            {
                nombresClientesList = new List<NombresClientes>();
                AsistenciaBO asistenciaBO = new AsistenciaBO();
                nombresClientesList = asistenciaBO.LoadClientes();
                return true;
            }
            catch
            {
                return false;
            }

        }
        #endregion

        #region limpiar / resetear elementos visibles

        /// <summary>
        /// Habilita o desabilita que se filtre por fechas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbkFechasChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;

            if (cb.Checked)
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
        
        /// <summary>
        /// Limpia los valores existentes de los comboBox, los textbox, etc.
        /// </summary>
        private void CleanData()
        {
            idAsistenciaSelected = 0;
            idClienteSelected = 0;

            cbxNombresClientes.Items.Clear();//Limpia los valores que pueda tene
            cbxNombresClientes.Text = "";

            dtmFecha.Value = DateTime.Today;

            txtHora.Text = "";

            txtObservciones.Text = "";

            cbxSucursal.Items.Clear();
            cbxSucursal.Text = "";

        }

        /// <summary>
        /// Vuelve los labels y panels a los parametros originales luego de editar o insertar un objeto
        /// </summary>
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

            actionsUse = true;
        }

        /// <summary>
        /// Edita los colores de panels y labels cuando se va a insertar un objeto
        /// </summary>
        private void EditElements()
        {
            actionsUse = false;

            pnlActions.BackColor = Color.FromArgb(245, 245, 245);
            pnlActions.BorderStyle = BorderStyle.FixedSingle;
            pnlActions.ForeColor = Color.FromArgb(3, 79, 150);

            btnEliminar.BackColor = Color.FromArgb(160, 160, 160);
            btnEliminar.ForeColor = Color.FromArgb(221, 221, 221);
            btnEliminar.FlatAppearance.BorderColor = Color.FromArgb(221, 221, 221);
            btnEliminar.Enabled = false;

            btnEditar.BackColor = Color.FromArgb(160, 160, 160);
            btnEditar.ForeColor = Color.FromArgb(221, 221, 221);
            btnEditar.FlatAppearance.BorderColor = Color.FromArgb(221, 221, 221);
            btnEditar.Enabled = false;

            dtmFecha.Enabled = true;
            txtHora.Enabled = true;
            txtObservciones.Enabled = true;

            btnFiltrar.Enabled = false;
            btnFiltrar.Visible = false;
        }

        /// <summary>
        /// Edita los colores de panels y labels cuando se va a editar un objeto
        /// </summary>
        private void EditUpdateElements()
        {
            actionsUse = false;

            pnlActions.BackColor = Color.FromArgb(245, 245, 245);
            pnlActions.BorderStyle = BorderStyle.FixedSingle;
            pnlActions.ForeColor = Color.FromArgb(3, 79, 150);

            btnEliminar.BackColor = Color.FromArgb(160, 160, 160);
            btnEliminar.ForeColor = Color.FromArgb(221, 221, 221);
            btnEliminar.FlatAppearance.BorderColor = Color.FromArgb(221, 221, 221);
            btnEliminar.Enabled = false;

            btnInsertar.BackColor = Color.FromArgb(160, 160, 160);
            btnInsertar.ForeColor = Color.FromArgb(221, 221, 221);
            btnInsertar.FlatAppearance.BorderColor = Color.FromArgb(221, 221, 221);
            btnInsertar.Enabled = false;

            txtHora.Enabled = true;
            txtObservciones.Enabled = true;

            btnFiltrar.Enabled = false;
            btnFiltrar.Visible = false;
        }


        #endregion

        #region Validar datos
        /// <summary>
        /// Valida que la infromacion de los combobox y textbox sea correcta 
        /// </summary>
        /// 
        private bool ValidarInformacion()
        {
            if (VariablesGlobales.Nivel > 1 && VariablesGlobales.sucursal != int.Parse(cbxSucursal.SelectedItem.ToString()))
            {
                MessageBox.Show("Su usuario no tiene privilegios necesarios para ingresar asistencias de otra sucursal.","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return false;
            }
            if (cbxNombresClientes.SelectedItem == null)
            {
                MessageBox.Show("Seleccione el nombre del cliente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        /// <summary>
        /// Guarda los cambios efectuados por Insert o Edit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        

        private bool ValidateHora()
        {
            if (txtHora.Text.Length > 5 || string.IsNullOrEmpty(txtHora.Text) || txtHora.Text == " " || txtHora.Text == "")
            {
                MessageBox.Show("El formato de la hora es 21:00 o 08:15 \nRecuerde que se usa el formato de 24 horas.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (!txtHora.Text.Contains(":"))
            {
                MessageBox.Show("El formato de la hora es hh:mm Ejemplo: 08:15 \nRecuerde que se usa el formato de 24 horas.","Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            string horas = txtHora.Text.Split(':')[0];
            string minutos = txtHora.Text.Split(':')[1];
            

            if(horas.Length<2 || horas.Length > 2)
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

        #endregion

        #region Guardar Editar, insertar, eliminar, filtrar
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (action == 0)//Valida que se este realizando una accion, sino no ejecutara nada.
            {
                return;
            }
            try
            {
                if (!ValidarInformacion())
                {
                    return;
                }

                if (action == 1) //Insertar
                {
                    AsistenciaBO asistenciaBO = new AsistenciaBO();
                    AsistenciaModel asistenciaModel = new AsistenciaModel();

                    var nombreCliente = cbxNombresClientes.SelectedItem.ToString();

                    asistenciaModel.Fk_id_cliente = nombresClientesList.Where(x => x.nombre == nombreCliente).Select(x => x.Id_Cliente).FirstOrDefault();
                    asistenciaModel.Fecha = dtmFecha.Value.ToString("dd/MM/yyyy");
                    asistenciaModel.Hora = txtHora.Text;
                    asistenciaModel.Observacion = txtObservciones.Text;
                    asistenciaModel.Sucursal = int.Parse(cbxSucursal.SelectedItem.ToString());
                    asistenciaModel.Usuario = VariablesGlobales.usuario.ToString();
                    asistenciaModel.Fecha_mod = DateTime.Now.ToString("dd/MM/yyyy");


                    bool responserValidate = asistenciaBO.ValidarDuplicadoAsis(asistenciaModel);

                    if (!responserValidate)
                    {
                        MessageBox.Show("Ya existe un registro de la misma fecha con el mismo usuario.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    bool responseInsert = asistenciaBO.InsertarAsistencia(asistenciaModel);

                    if (!responseInsert)
                    {
                        MessageBox.Show("No se pudo guardar la información, inténtelo más tarde.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    MessageBox.Show("La información se ha guardado EXITOSAMENTE!");

                }
                else
                {
                    AsistenciaBO asistenciaBO = new AsistenciaBO();
                    AsistenciaModel asistenciaModel = new AsistenciaModel();

                    string nombreCliente = cbxNombresClientes.SelectedItem.ToString();
                    asistenciaModel.Id_asistencia = idAsistenciaSelected;
                    asistenciaModel.Fk_id_cliente = idClienteSelected;
                    asistenciaModel.Nombre = nombreCliente;
                    asistenciaModel.Fecha = dtmFecha.Value.ToString("dd/MM/yyyy");
                    asistenciaModel.Hora = txtHora.Text;
                    asistenciaModel.Observacion = txtObservciones.Text;
                    asistenciaModel.Sucursal = int.Parse(cbxSucursal.SelectedItem.ToString());
                    asistenciaModel.Usuario = VariablesGlobales.usuario.ToString();
                    asistenciaModel.Fecha_mod = DateTime.Now.ToString("dd/MM/yyyy");

                    bool response = asistenciaBO.ActualizarAsistencia(asistenciaModel);
                    if (!response)
                    {
                        MessageBox.Show("No se pudo editar la información, inténtelo más tarde.","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                        return;
                    }
                    MessageBox.Show("La información se ha actualizado EXITOSAMENTE!");
                }

                ResetElements();

                ReloadInformation();

                action = 0;

                CleanData();
            }
            catch (Exception ex)
            {
                CleanData();
                ResetElements();
                ReloadInformation();
                action = 0;
                MessageBox.Show("Alerta, No se pudo guardar el registro\n" + ex.Message);
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

            EditUpdateElements();//Cambia de aspecto a los elementos para indicar al usuario que se realizara una accion, en este caso insertar
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            btnGuardar.Enabled = true;
            btnGuardar.Visible = true;

            lblAction.Text = "Insertando";

            action = 1;

            EditElements();//Cambia de aspecto a los elementos para indicar al usuario que se realizara una accion, en este caso insertar

            CleanData();//Limpia la data que se haya seleccionado del grid

            try
            {
                if (!LoadNombresClientes())
                {
                    ResetElements();//Vuelve los elementos al estado original indicando al usuario que no se esta realizando ninguna accion
                    MessageBox.Show("Aviso, No se pudo cargar el nombre de los clientes. ");
                    return;
                }

                //if (!LoadUsuarios())
                //{
                //    ResetElements();
                //    MessageBox.Show("Aviso, No se pudo cargar el nombre de los usuarios. ");
                //    return;
                //}

                //Llenar el comboBox Nombres Clientes

                //cbxNombresClientes.Text = nombresClientesList.Select(x => x.nombre).FirstOrDefault();
                //cbxNombresClientes.SelectedItem= nombresClientesList.Select(x => x.nombre).FirstOrDefault();

                foreach (var item in nombresClientesList)
                {
                    cbxNombresClientes.Items.Add(item.nombre);
                }

                txtHora.Text = "08:15";

                //La sucursal deberia tener su propia tabla no datos quemados
                cbxSucursal.Items.Add("1");


            }
            catch (Exception ex)
            {
                ResetElements();
                MessageBox.Show("Aviso, No se pudo cargar el nombre de los clientes. " + ex);
            }

        }
        private void btnEliminar_Clicked(object sender, EventArgs e)
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
                    AsistenciaBO asistenciaBO = new AsistenciaBO();
                    AsistenciaModel asistenciaModel = new AsistenciaModel();

                    string nombreCliente = cbxNombresClientes.SelectedItem.ToString();
                    asistenciaModel.Id_asistencia = idAsistenciaSelected;
                    asistenciaModel.Fk_id_cliente = idClienteSelected;
                    asistenciaModel.Nombre = nombreCliente;
                    asistenciaModel.Fecha = dtmFecha.Value.ToString("dd/MM/yyyy");
                    asistenciaModel.Hora = txtHora.Text;
                    asistenciaModel.Observacion = txtObservciones.Text;
                    asistenciaModel.Sucursal = int.Parse(cbxSucursal.SelectedItem.ToString());
                    asistenciaModel.Usuario = VariablesGlobales.usuario.ToString();
                    asistenciaModel.Fecha_mod = DateTime.Now.ToString("dd/MM/yyyy");

                    bool responseDB = asistenciaBO.EliminarAsistencia(idAsistenciaSelected);
                    if (!responseDB)
                    {
                        MessageBox.Show("No se eliminar el registro, inténtelo más tarde.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    MessageBox.Show("La información se ha actualizado EXITOSAMENTE!");

                    CleanData();
                    ReloadInformation();
                }
            }
            catch (Exception ex)
            {
                CleanData();
                ReloadInformation();
                MessageBox.Show("No se eliminar el registro, inténtelo más tarde." + ex, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                
            }
            


        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {

            AsistenciaBO asistenciaBO = new AsistenciaBO();

            List<AsistenciaModel> asistenciaList = new List<AsistenciaModel>();

            bool check = ckbFiltrarFechas.Checked;

            asistenciaList = new List<AsistenciaModel>();
            if (check && cbxFiltroNombreCliente.SelectedItem!=null && cbxEstadoCliente.SelectedItem != null)
            {
                string nombre = cbxFiltroNombreCliente.SelectedItem.ToString();

                int idCliente = nombresClientesList.Where(x => x.nombre == nombre).Select(x => x.Id_Cliente).FirstOrDefault();

                if (idCliente > 0)
                {
                    string estado = cbxEstadoCliente.SelectedItem.ToString();

                    string pEstado = null;

                    if (estado == "Activo")
                    {
                        pEstado = "A";

                    }
                    else if (estado == "Prueba")
                    {
                        pEstado = "P";
                    }
                    else //estado = Inactivo
                    {
                        pEstado = "I";
                    }

                    asistenciaList = asistenciaBO.ConsultaAsistencia(dtpDesde.Value.ToString("dd/MM/yyyy"), dtmHasta.Value.ToString("dd/MM/yyyy"), VariablesGlobales.sucursal, idCliente, pEstado);
                    CargarInformacionFiltrada(asistenciaList);
                }            
            }
            else if (cbxFiltroNombreCliente.SelectedItem == null && !check && cbxEstadoCliente.SelectedItem == null)
            {
                MessageBox.Show("No ha seleccionado parámetros para filtrar la información.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }else if (cbxFiltroNombreCliente.SelectedItem != null && !check && cbxEstadoCliente.SelectedItem == null)
            {
                string nombre = cbxFiltroNombreCliente.SelectedItem.ToString();

                int idCliente = nombresClientesList.Where(x => x.nombre == nombre).Select(x => x.Id_Cliente).FirstOrDefault();

                if (idCliente > 0)
                {
                    asistenciaList = asistenciaBO.ConsultaAsistencia(null,null, VariablesGlobales.sucursal, idCliente, null);
                    CargarInformacionFiltrada(asistenciaList);
                }

            }else if (cbxFiltroNombreCliente.SelectedItem == null && check && cbxEstadoCliente.SelectedItem == null)
            {
                asistenciaList = asistenciaBO.ConsultaAsistencia(dtpDesde.Value.ToString("dd/MM/yyyy"), dtmHasta.Value.ToString("dd/MM/yyyy"), VariablesGlobales.sucursal, 0, null);
                CargarInformacionFiltrada(asistenciaList);

            }else if (cbxFiltroNombreCliente.SelectedItem == null && !check && cbxEstadoCliente.SelectedItem != null)
            {
                string estado = cbxEstadoCliente.SelectedItem.ToString();

                string pEstado = null;

                if (estado == "Activo")
                {
                    pEstado = "A";

                }
                else if (estado == "Prueba")
                {
                    pEstado = "P";
                }
                else //estado = Inactivo
                {
                    pEstado = "I";
                }

                asistenciaList = asistenciaBO.ConsultaAsistencia(null,null, VariablesGlobales.sucursal, 0, pEstado);
                CargarInformacionFiltrada(asistenciaList);

            }else if (cbxFiltroNombreCliente.SelectedItem != null && !check && cbxEstadoCliente.SelectedItem != null)
            {
                string nombre = cbxFiltroNombreCliente.SelectedItem.ToString();

                int idCliente = nombresClientesList.Where(x => x.nombre == nombre).Select(x => x.Id_Cliente).FirstOrDefault();

                if (idCliente > 0)
                {
                    string estado = cbxEstadoCliente.SelectedItem.ToString();

                    string pEstado = null;

                    if (estado == "Activo")
                    {
                        pEstado = "A";

                    }
                    else if (estado == "Prueba")
                    {
                        pEstado = "P";
                    }
                    else //estado = Inactivo
                    {
                        pEstado = "I";
                    }

                    asistenciaList = asistenciaBO.ConsultaAsistencia(null,null, VariablesGlobales.sucursal, idCliente, pEstado);
                    CargarInformacionFiltrada(asistenciaList);
                }

            }else if (cbxFiltroNombreCliente.SelectedItem != null && check && cbxEstadoCliente.SelectedItem == null)
            {

                string nombre = cbxFiltroNombreCliente.SelectedItem.ToString();

                int idCliente = nombresClientesList.Where(x => x.nombre == nombre).Select(x => x.Id_Cliente).FirstOrDefault();

                if (idCliente > 0)
                {
                   
                    asistenciaList = asistenciaBO.ConsultaAsistencia(dtpDesde.Value.ToString("dd/MM/yyyy"), dtmHasta.Value.ToString("dd/MM/yyyy"), VariablesGlobales.sucursal, idCliente, null);
                    CargarInformacionFiltrada(asistenciaList);
                }

            } else if (cbxFiltroNombreCliente.SelectedItem == null && check && cbxEstadoCliente.SelectedItem != null)
            {

                string estado = cbxEstadoCliente.SelectedItem.ToString();

                string pEstado = null;

                if (estado == "Activo")
                {
                    pEstado = "A";

                }
                else if (estado == "Prueba")
                {
                    pEstado = "P";
                }
                else //estado = Inactivo
                {
                    pEstado = "I";
                }

                asistenciaList = asistenciaBO.ConsultaAsistencia(dtpDesde.Value.ToString("dd/MM/yyyy"), dtmHasta.Value.ToString("dd/MM/yyyy"), VariablesGlobales.sucursal, 0, pEstado);
                CargarInformacionFiltrada(asistenciaList);


            }



            /*

            if (cbxFiltroNombreCliente.SelectedItem==null && check)
            {
                asistenciaList = new List<AsistenciaModel>();
                asistenciaList = asistenciaBO.ConsultarPeriodoAsis(dtpDesde.Value.ToString("dd/MM/yyyy"), dtmHasta.Value.ToString("dd/MM/yyyy"));
                FiltrarInformacion(asistenciaList);
            }
            else if(cbxFiltroNombreCliente.SelectedItem == null && !check)
            {
                MessageBox.Show("No ha seleccionado parámetros para filtrar la información.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            if (cbxFiltroNombreCliente.SelectedItem != null)
            {
                string nombre = cbxFiltroNombreCliente.SelectedItem.ToString();

                int idCliente = nombresClientesList.Where(x => x.nombre == nombre).Select(x => x.Id_Cliente).FirstOrDefault();

                if (idCliente > 0)
                {
                    if (ckbFiltrarFechas.Checked)
                    {
                        asistenciaList = new List<AsistenciaModel>();
                        asistenciaList = asistenciaBO.ConsultarPeriodoIdCliente(dtpDesde.Value.ToString("dd/MM/yyyy"), dtmHasta.Value.ToString("dd/MM/yyyy"), idCliente);
                        FiltrarInformacion(asistenciaList);
                    }
                    else
                    {
                        asistenciaList = new List<AsistenciaModel>();
                        asistenciaList = asistenciaBO.ConsultarIdclienteAsis(idCliente);
                        FiltrarInformacion(asistenciaList);
                    }
                }
            }

            */



        }

        #endregion

        /// <summary>
        /// Cierra la vista actual
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Clicked(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Cancela una operacion, sea de insertar o editar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            CleanData();
            ResetElements();
            action = 0;
        }

        private void btnReiniciarFiltro_Click(object sender, EventArgs e)
        {
            cbxFiltroNombreCliente.Items.Clear();

            cbxEstadoCliente.Items.Clear();

            ckbFiltrarFechas.Checked = false;

            ReloadInformation();

        }
    }
}
