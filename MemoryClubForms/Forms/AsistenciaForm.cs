﻿using MemoryClubForms.BusinessBO;
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
using System.Globalization;

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

        public int idAsistenciaSelected = 0;

        public int idClienteSelected = 0;

        public int filaSeleccionada = 0;

        public AsistenciaModel asistenciaModel = new AsistenciaModel();

        CultureInfo ci = new CultureInfo("en-US");


        /// <summary>
        /// Clase que es parte de AsistenciaBO
        /// </summary>
        public static List<NombresClientes> nombresClientesList = new List<NombresClientes>();

        public static List<NombresUsuarios> nombresUsuariosList = new List<NombresUsuarios>();

        public static List<CodigosSucursales> codigosSucursalesList = new List<CodigosSucursales>();

        public static List<CodigosEstados> codigosEstadosList = new List<CodigosEstados>();

        public static int sucursalUser = VariablesGlobales.sucursal;

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

                CargarFilterElements();

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar el nombre de los clientes para realizar filtros" + ex, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void CargarFilterElements()
        {
            bool response = LoadNombresClientes();

            bool responseSucursal = LoadSucursales();

            bool responseEstado = LoadEstados();

            if (!response || !responseSucursal || !responseEstado)
            {
                MessageBox.Show("No se pudo cargar la información para realizar filtros", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            foreach (var item in nombresClientesList)
            {
                cbxFiltroNombreCliente.Items.Add(item.nombre);
            }

            foreach (var item in codigosSucursalesList)
            {
                cbxSucursal.Items.Add(item.Sucursales);
            }

            foreach (var item in codigosEstadosList)
            {
                cbxEstadoCliente.Items.Add(item.Descripcion);
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
                cbxNombresClientes.Text = (string)grdAsistencia.Rows[filaSeleccionada].Cells[2].Value;//Es el texto que aparece en el recuadro

                string fecha = grdAsistencia.Rows[filaSeleccionada].Cells[3].Value.ToString();
                DateTime fechaDate = DateTime.ParseExact(fecha, "MM/dd/yyyy", ci);


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

        private void ResetFiltersElements()
        {
            cbxFiltroNombreCliente.Items.Clear();

            cbxEstadoCliente.Items.Clear();

            cbxSucursal.Items.Clear();
            //cbxSucursal.Text = "";

            ckbFiltrarFechas.Checked = false;

            dtpDesde.Value = DateTime.Today;

            dtmHasta.Value = DateTime.Today;
        }

        /// <summary>
        /// Vuelve a cargar la informacion depues de editar, eliminar o insertar un registro
        /// </summary>
        private void ReloadInformation()
        {
            ResetFiltersElements();
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

                CargarFilterElements();
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
                MessageBox.Show("No se encontró información.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        public bool LoadSucursales()
        {

            try
            {
                codigosSucursalesList = new List<CodigosSucursales>();
                AsistenciaBO asistenciaBO = new AsistenciaBO();
                codigosSucursalesList = asistenciaBO.LoadSucursales();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool LoadEstados()
        {
            try
            {
                codigosEstadosList = new List<CodigosEstados>();
                AsistenciaBO asistenciaBO = new AsistenciaBO();
                codigosEstadosList = asistenciaBO.LoadEstados();
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

            //tbxCliente.Text = "";
            tbxCliente.Enabled = false;
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
            if (cbxNombresClientes.SelectedItem == null)
            {
                MessageBox.Show("Seleccione el nombre del cliente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    asistenciaModel.Fecha = dtmFecha.Value.ToString("MM/dd/yyyy", ci);
                    asistenciaModel.Hora = txtHora.Text;
                    asistenciaModel.Observacion = txtObservciones.Text;
                    asistenciaModel.Sucursal = nombresClientesList.Where(x => x.nombre == nombreCliente).Select(x => x.Sucursal).FirstOrDefault();
                    asistenciaModel.Usuario = VariablesGlobales.usuario.ToString();
                    asistenciaModel.Fecha_mod = DateTime.Now.ToString("MM/dd/yyyy", ci);


                    bool responserValidate = asistenciaBO.ValidarDuplicadoAsis(asistenciaModel);

                    if (!responserValidate)
                    {
                        MessageBox.Show("Ya existe un registro de la misma fecha con el mismo usuario.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    string responseInsert = asistenciaBO.InsertarAsistencia(asistenciaModel);

                    if (responseInsert.ToLower() != "ok")
                    {
                        MessageBox.Show("No se pudo guardar la información, inténtelo más tarde.\n" + responseInsert, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    asistenciaModel.Fecha = dtmFecha.Value.ToString("MM/dd/yyyy", ci);
                    asistenciaModel.Hora = txtHora.Text;
                    asistenciaModel.Observacion = txtObservciones.Text;
                    asistenciaModel.Sucursal = nombresClientesList.Where(x => x.nombre == nombreCliente).Select(x => x.Sucursal).FirstOrDefault();
                    asistenciaModel.Usuario = VariablesGlobales.usuario.ToString();
                    asistenciaModel.Fecha_mod = DateTime.Now.ToString("MM/dd/yyyy", ci);

                    string response = asistenciaBO.ActualizarAsistencia(asistenciaModel);
                    if (response.ToLower() != "ok")
                    {
                        MessageBox.Show("No se pudo editar la información, inténtelo más tarde\n." + response, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    MessageBox.Show("La información se ha actualizado EXITOSAMENTE!");
                }

                action = 0;
            }
            catch (Exception ex)
            {
                action = 0;
                MessageBox.Show("Alerta, No se pudo guardar el registro\n" + ex.Message);
            }

            ResetElements();
            CleanData();
            if ((cbxFiltroNombreCliente.SelectedItem != null) || (cbxEstadoCliente.SelectedItem != null) || (cbxSucursal.SelectedItem != null) || (ckbFiltrarFechas.Checked == true))
            {
                this.btnFiltrar_Click(null, null);
            }
            else
            {
                ReloadInformation();
            }

        }
        private void btnEdit_Clicked(object sender, EventArgs e)
        {
            if (VariablesGlobales.Nivel > 3)
            {
                MessageBox.Show("Su usuario no tiene los privilegios necesarios para editar registros de asistencia.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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

            EditUpdateElements();//Cambia de aspecto a los elementos para indicar al usuario que se realizara una accion, en este caso insertar
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (VariablesGlobales.Nivel > 3)
            {
                MessageBox.Show("Su usuario no tiene los privilegios necesarios para ingresar registros de asistencia.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

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

                foreach (var item in nombresClientesList)
                {
                    cbxNombresClientes.Items.Add(item.nombre);
                }

                txtHora.Text = "08:15";
                tbxCliente.Enabled = true;

            }
            catch (Exception ex)
            {
                ResetElements();
                MessageBox.Show("Aviso, No se pudo cargar el nombre de los clientes. " + ex);
            }

            string cadena = tbxCliente.Text;
            if (!(string.IsNullOrEmpty(cadena)))
            {
                this.FiltraCliente(cadena);
            }

        }
        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            if (VariablesGlobales.Nivel > 1)
            {
                MessageBox.Show("Su usuario no tiene los privilegios necesarios para eliminar registros de asistencia.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            try
            {
                if (cbxNombresClientes.Items.Count == 0) //Valida que tenga un item seleccionado del grid
                {
                    return;
                }

                DialogResult response = MessageBox.Show("Está seguro de que desea eliminar este elemento?", "Eliminar item seleccionado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (response == DialogResult.Yes)
                {
                    AsistenciaBO asistenciaBO = new AsistenciaBO();
                    AsistenciaModel asistenciaModel = new AsistenciaModel();

                    asistenciaModel.Id_asistencia = idAsistenciaSelected;

                    bool responseDB = asistenciaBO.EliminarAsistencia(idAsistenciaSelected);
                    if (!responseDB)
                    {
                        MessageBox.Show("No se puede eliminar el registro, inténtelo más tarde.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    MessageBox.Show("La información se ha actualizado EXITOSAMENTE!");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo eliminar el registro, inténtelo más tarde." + ex, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }


            CleanData();
            if ((cbxFiltroNombreCliente.SelectedItem != null) || (cbxEstadoCliente.SelectedItem != null) || (cbxSucursal.SelectedItem != null) || (ckbFiltrarFechas.Checked == true))
            {
                this.btnFiltrar_Click(null, null);
            }
            else
            {
                ReloadInformation();
            }


        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                AsistenciaBO asistenciaBO = new AsistenciaBO();

                List<AsistenciaModel> asistenciaList = new List<AsistenciaModel>();

                bool check = ckbFiltrarFechas.Checked;

                asistenciaList = new List<AsistenciaModel>();


                string nombreCliente = null;

                if (cbxFiltroNombreCliente.SelectedItem != null)
                {
                    nombreCliente = cbxFiltroNombreCliente.SelectedItem.ToString();
                }

                int idCliente = nombresClientesList.Where(x => x.nombre == nombreCliente).Select(x => x.Id_Cliente).FirstOrDefault();

                string estadoCliente = null;
                string estadoClienteCode = null;

                if (cbxEstadoCliente.SelectedItem != null)
                {
                    estadoCliente = cbxEstadoCliente.SelectedItem.ToString();
                }

                estadoClienteCode = codigosEstadosList.Where(x => x.Descripcion == estadoCliente).Select(x => x.Estados).FirstOrDefault();

                int sucursal = 0;

                if (cbxSucursal.SelectedItem != null)
                {
                    sucursal = int.Parse(cbxSucursal.SelectedItem.ToString());
                }

                string fechaDesde = null;
                string fechaHasta = null;

                if (check)
                {
                    fechaDesde = dtpDesde.Value.ToString("MM/dd/yyyy", ci);
                    fechaHasta = dtmHasta.Value.ToString("MM/dd/yyyy", ci);
                }

                asistenciaList = asistenciaBO.ConsultaAsistencia(fechaDesde, fechaHasta, sucursal, idCliente, estadoClienteCode);

                CargarInformacionFiltrada(asistenciaList);

            }
            catch (Exception ex)
            {
                ResetFiltersElements();
                ReloadInformation();
                MessageBox.Show("Alerta, No se pudo filtrar el registro\n" + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


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

            ReloadInformation();
        }

        private void tbxCliente_TextChanged(object sender, EventArgs e)
        {
            //primero recupero la lista original
            cbxNombresClientes.BeginUpdate();
            cbxNombresClientes.Items.Clear();
            foreach (var item in nombresClientesList)
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
            //  tbxCliente.Text = "";
        }

        /// <summary>
        /// ELIMINAR MASIVO: Elimina todos los registros que se encuentran en el datagrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnElimMasivo_Click(object sender, EventArgs e)
        {
            if (VariablesGlobales.Nivel > 1)
            {
                MessageBox.Show("Su usuario no tiene privilegios necesarios para eliminar registros de asistencia.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                DialogResult response = MessageBox.Show("¿Está seguro de eliminar todos los registros de la pantalla?\nEste proceso es irreversible", "Eliminar Masivo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (response == DialogResult.Yes)
                {
                    string cadena = "";
                    int contador = 0;
                    //armo una cadena con los id de asistencia que deben eliminarse
                    if (grdAsistencia.RowCount > 0)
                    {
                        foreach (DataGridViewRow dtg in grdAsistencia.Rows)
                        {
                            contador++;
                            var idasistencia = dtg.Cells["id_asistencia"].Value; // para obtener el valor de la celda

                            if (contador == 1 && cadena.Length <= 0)
                            {
                                cadena = "(" + Convert.ToString(idasistencia);
                            }
                            else
                            {
                                cadena += ", " + Convert.ToString(idasistencia);
                            }
                        }
                        if (cadena.Length > 0)
                        {
                            AsistenciaBO asistencia = new AsistenciaBO();
                            cadena += ")";
                            string ls_mensaje = asistencia.EliminarMasivo(cadena);
                            if (ls_mensaje != "OK")
                            {
                                MessageBox.Show("No se pudo eliminar todos los registros\n." + response, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return;
                            }
                            MessageBox.Show("La información se ha eliminado EXITOSAMENTE!");
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("No se eliminaron los registros, inténtelo más tarde.\n" + ex, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            ResetElements();
            CleanData();
            if ((cbxFiltroNombreCliente.SelectedItem != null) || (cbxEstadoCliente.SelectedItem != null) || (cbxSucursal.SelectedItem != null) || (ckbFiltrarFechas.Checked == true))
            {
                this.btnFiltrar_Click(null, null);
            }
            else
            {
                ReloadInformation();
            }
        }
    }
}
