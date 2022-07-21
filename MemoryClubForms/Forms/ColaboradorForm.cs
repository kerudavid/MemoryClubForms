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
using static MemoryClubForms.BusinessBO.ColaboradorBO;

namespace MemoryClubForms.Forms
{
    public partial class ColaboradorForm : Form
    {
        public int action = 0;//Valida que acción debe realizar el boton de guardar. si insertar o editar, insertar=1 y editar =2

        public int idColaborador = 0;

        public int filaSeleccionada = 0;

        public static int sucursalUser = VariablesGlobales.sucursal;

        public static List<CodigosSucursales> codigosSucursalesList = new List<CodigosSucursales>();

        public static List<CodigosEstados> codigosEstadosList = new List<CodigosEstados>();

        public static List<ColaboradorModel> ColaboradorListComplete = new List<ColaboradorModel>();

        public static bool actionsInUse = true;
        public ColaboradorForm()
        {
            InitializeComponent();

            LoadInformation();
        }

        private void btnReiniciarFiltro_Click(object sender, EventArgs e)
        {
            ResetFilterElements();
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
                grdColaborador.Rows.Clear();
                ResetFilterElements();

                ColaboradorBO colaboradorBO = new ColaboradorBO();
                ColaboradorListComplete = new List<ColaboradorModel>();
                List<ColaboradorModel> colaboradorList = colaboradorBO.ConsultaColaborador(0, 0, null);

                if (colaboradorList.Count > 0)
                {
                    ColaboradorListComplete = colaboradorList;
                    foreach (var colab in colaboradorList)
                    {
                        grdColaborador.Rows.Add(colab.Id_colaborador,colab.Nombre,colab.Cedula,colab.Sucursal,colab.Direccion,colab.Telefono,colab.Cargo,colab.Estado,colab.Observacion,colab.Usuario,colab.Fecha_mod);
                    }
                    grdColaborador.ReadOnly = true;
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
            bool responseEstados = LoadEstados();

            bool responseSucursales = LoadSucursales();

            if (!responseEstados || !responseSucursales )
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

            if (string.IsNullOrEmpty(tbxNombreColab.Text))
            {
                MessageBox.Show("Ingrese el nombre.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (tbxNombreColab.Text.Length>80)
            {
                MessageBox.Show("Has superado el número de caracteres del nombre del colaborador.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

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

            if (cbxSucursal.SelectedItem == null)
            {
                MessageBox.Show("Seleccione la sucursal.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

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

            if (string.IsNullOrEmpty(tbxTelefono.Text))
            {
                MessageBox.Show("Ingrese el teléfono.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (tbxTelefono.Text.Length > 50)
            {
                MessageBox.Show("Has superado el número de caracteres en teléfono.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (string.IsNullOrEmpty(tbxCargo.Text))
            {
                MessageBox.Show("Ingrese el cargo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (tbxCargo.Text.Length > 50)
            {
                MessageBox.Show("Has superado el número de caracteres en Cargo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (txtObservciones.Text.Length > 50)
            {
                MessageBox.Show("Has superado el número de caracteres para Observación. Caracteres máximos: 100", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        private bool LoadSucursales()
        {
            try
            {
                codigosSucursalesList = new List<CodigosSucursales>();
                ColaboradorBO colaboradorBO = new ColaboradorBO();
                codigosSucursalesList = colaboradorBO.LoadSucursales();
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
                ColaboradorBO colaboradorBO = new ColaboradorBO();
                codigosEstadosList = colaboradorBO.LoadEstados();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void CargarElemFiltros()
        {

            foreach (var item in ColaboradorListComplete)
            {
                cbxFiltroNombreColab.Items.Add(item.Nombre);
            }

            foreach (var item in codigosSucursalesList)
            {
                cbxFiltroSucursal.Items.Add(item.Sucursales.ToString());
            }

            foreach (var item in codigosEstadosList)
            {
                cbxFiltroEstadoCliente.Items.Add(item.Descripcion.ToString());
            }
            cbxFiltroEstadoCliente.Items.Add("TODOS");

        }

        private void CargarElementsEdit()
        {
            foreach (var item in codigosSucursalesList)
            {
                if (int.Parse(cbxSucursal.SelectedIndex.ToString()) != item.Sucursales)
                {
                    cbxSucursal.Items.Add(item.Sucursales);
                }
                
            }

            foreach (var item in codigosEstadosList)
            {
                if(cbxEstado.SelectedItem.ToString().ToLower()!= item.Estados.ToLower())
                    cbxEstado.Items.Add(item.Estados);
            }
        }
        private void CargarElemActions()
        {
            //Cargo el nombre de los clientes y de los colaboradores
            foreach (var item in codigosSucursalesList)
            {
                cbxSucursal.Items.Add(item.Sucursales);
            }    
        }

        private void ResetFilterElements()
        {
            cbxFiltroNombreColab.Items.Clear();

            cbxFiltroSucursal.Items.Clear();

            cbxFiltroEstadoCliente.Items.Clear();
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

            tbxNombreColab.Enabled = false;
            tbxCedula.Enabled = false;
            tbxDireccion.Enabled = false;
            tbxTelefono.Enabled = false;
            tbxCargo.Enabled = false;
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

            tbxNombreColab.Enabled = true;
            tbxCedula.Enabled = true;
            tbxDireccion.Enabled = true;
            tbxTelefono.Enabled = true;
            tbxCargo.Enabled = true;
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

                lblEstado.Visible=true;
                
                cbxEstado.Visible=true;
                cbxEstado.Enabled = true;

                CargarElementsEdit();

            }


            btnFiltrar.Enabled = false;
            btnFiltrar.Visible = false;
        }

        private void CleanData()
        {
            idColaborador = 0;

            cbxSucursal.Items.Clear();//Limpia los valores que pueda tene
            cbxSucursal.Text = "";

            lblEstado.Visible = false;

            cbxEstado.Visible = false;
            cbxEstado.Enabled = false;
            cbxEstado.Items.Clear();
            cbxEstado.Text = "";

            tbxNombreColab.Text = "";

            tbxCedula.Text = "";

            tbxDireccion.Text = "";

            tbxTelefono.Text = "";

            tbxCargo.Text = "";

            txtObservciones.Text = "";

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

                idColaborador = 0;

                //Valida que el clic no sea de los headers
                if (filaSeleccionada != -1)
                {
                    idColaborador = int.Parse(grdColaborador.Rows[filaSeleccionada].Cells[0].Value.ToString());

                    tbxNombreColab.Text = (string)grdColaborador.Rows[filaSeleccionada].Cells[1].Value;

                    tbxCedula.Text = (string)grdColaborador.Rows[filaSeleccionada].Cells[2].Value;

                    cbxSucursal.Items.Clear();
                    cbxSucursal.SelectedItem = (string)grdColaborador.Rows[filaSeleccionada].Cells[3].Value.ToString();
                    cbxSucursal.Items.Add((string)grdColaborador.Rows[filaSeleccionada].Cells[3].Value.ToString());
                    cbxSucursal.Text = (string)grdColaborador.Rows[filaSeleccionada].Cells[3].Value.ToString();

                    cbxEstado.Items.Clear();
                    cbxEstado.SelectedItem = (string)grdColaborador.Rows[filaSeleccionada].Cells[7].Value.ToString();
                    cbxEstado.Items.Add((string)grdColaborador.Rows[filaSeleccionada].Cells[7].Value.ToString());
                    cbxEstado.Text = (string)grdColaborador.Rows[filaSeleccionada].Cells[7].Value.ToString();

                    tbxDireccion.Text = (string)grdColaborador.Rows[filaSeleccionada].Cells[4].Value;

                    tbxTelefono.Text = (string)grdColaborador.Rows[filaSeleccionada].Cells[5].Value;

                    tbxCargo.Text = (string)grdColaborador.Rows[filaSeleccionada].Cells[6].Value;

                    txtObservciones.Text = (string)grdColaborador.Rows[filaSeleccionada].Cells[8].Value;
                }
            }
            catch (Exception ex)
            {

            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CleanData();
            ResetElements();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                ColaboradorBO colaboradorBO = new ColaboradorBO();

                List<ColaboradorModel> colaboradorList = new List<ColaboradorModel>();

                grdColaborador.Rows.Clear();

                string nombre = null;

                if (cbxFiltroNombreColab.SelectedItem != null)
                {
                    nombre = cbxFiltroNombreColab.SelectedItem.ToString();
                }

                int idColaborador = ColaboradorListComplete.Where(x => x.Nombre == nombre).Select(x => x.Id_colaborador).FirstOrDefault();
               
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

         
                colaboradorList = colaboradorBO.ConsultaColaborador(idColaborador, sucursal, pEstado);

                if (colaboradorList.Count > 0)
                {
                    foreach (var colab in colaboradorList)
                    {
                        grdColaborador.Rows.Add(colab.Id_colaborador, colab.Nombre, colab.Cedula, colab.Sucursal, colab.Direccion, colab.Telefono, colab.Cargo, colab.Estado, colab.Observacion, colab.Usuario, colab.Fecha_mod);
                    }
                    grdColaborador.ReadOnly = true;
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
                if (string.IsNullOrEmpty(tbxNombreColab.Text)) //Valida que tenga un item seleccionado del grid
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
                    ColaboradorBO colaboradorBO = new ColaboradorBO();
                    ColaboradorModel colaboradorModel = new ColaboradorModel();

                    var nombreColaborador = tbxNombreColab.Text;

                    colaboradorModel.Nombre = nombreColaborador;
                    colaboradorModel.Cedula = tbxCedula.Text;
                    colaboradorModel.Direccion = tbxDireccion.Text;
                    colaboradorModel.Telefono = tbxTelefono.Text;
                    colaboradorModel.Cargo = tbxCargo.Text;
                    colaboradorModel.Estado = codigosEstadosList.Where(x => x.Descripcion == "ACTIVO").Select(x => x.Estados).FirstOrDefault();
                    colaboradorModel.Observacion = txtObservciones.Text;
                    colaboradorModel.Sucursal = int.Parse(cbxSucursal.SelectedItem.ToString());
                    colaboradorModel.Usuario = VariablesGlobales.usuario.ToString();
                    colaboradorModel.Fecha_mod = DateTime.Now.ToString("dd/MM/yyyy");

                    bool responseInsert = colaboradorBO.InsertaColaborador(colaboradorModel);

                    if (!responseInsert)
                    {
                        MessageBox.Show("No se pudo guardar la información, inténtelo más tarde.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    MessageBox.Show("La información se ha guardado EXITOSAMENTE!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    ColaboradorBO colaboradorBO = new ColaboradorBO();
                    ColaboradorModel colaboradorModel = new ColaboradorModel();

                    var nombreColaborador = tbxNombreColab.Text;

                    colaboradorModel.Id_colaborador = idColaborador;
                    colaboradorModel.Nombre = nombreColaborador;
                    colaboradorModel.Cedula = tbxCedula.Text;
                    colaboradorModel.Direccion = tbxDireccion.Text;
                    colaboradorModel.Telefono = tbxTelefono.Text;
                    colaboradorModel.Cargo = tbxCargo.Text;
                    colaboradorModel.Estado = cbxEstado.SelectedItem.ToString();
                    colaboradorModel.Observacion = txtObservciones.Text;
                    colaboradorModel.Sucursal = int.Parse(cbxSucursal.SelectedItem.ToString());
                    colaboradorModel.Usuario = VariablesGlobales.usuario.ToString();
                    colaboradorModel.Fecha_mod = DateTime.Now.ToString("dd/MM/yyyy");

                    bool response = colaboradorBO.ActualizarColaborador(colaboradorModel);
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
            try
            {
                if (string.IsNullOrEmpty(tbxNombreColab.Text)) //Valida que tenga un item seleccionado del grid
                {
                    return;
                }

                DialogResult response = MessageBox.Show("Eliminar item seleccionado", "Está seguro de que desea eliminar este elemento?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (response == DialogResult.Yes)
                {
                    ColaboradorBO colaboradorBO = new ColaboradorBO();
                    ColaboradorModel colaboradorModel = new ColaboradorModel();

                    colaboradorModel.Id_colaborador = idColaborador;

                    bool responseDB = colaboradorBO.EliminarColaborador(colaboradorModel.Id_colaborador);
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
    }
}
