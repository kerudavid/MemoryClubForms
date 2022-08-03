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
using static MemoryClubForms.BusinessBO.SaludBO;

namespace MemoryClubForms.Forms
{
    public partial class SaludForm : Form
    {
        public int action = 0;//Valida que acción debe realizar el boton de guardar. si insertar o editar, insertar=1 y editar =2

        public int idSalud = 0;
        public int idClienteStatic = 0;

        public int filaSeleccionada = 0;

        public static int sucursalUser = VariablesGlobales.sucursal;

        public static List<NombresClientes> clientesList = new List<NombresClientes>();

        public static List<ListaEnfermedades> enfermedadesList = new List<ListaEnfermedades>();

        public static List<SaludModel> SaludCompletelList = new List<SaludModel>();

        public static bool actionsInUse = true;

        public static string enfermedadEdit = null;

        public SaludForm(int id)
        {
            InitializeComponent();
            VariablesGlobales.OpenAlimentacion = true;
            LoadInformation(id);

        }

        public SaludForm()
        {
            InitializeComponent();
            VariablesGlobales.OpenAlimentacion = true;
            LoadInformation(0);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            VariablesGlobales.OpenAlimentacion = false;
        }
        private void LoadInformation(int idCliente)
        {
            try
            {
                int id = 0;

                if (idCliente > 0)
                {
                    id = idCliente;
                }

                grdSalud.Rows.Clear();
                ResetFilterElements();

                SaludBO saludBO = new SaludBO();
                SaludCompletelList = new List<SaludModel>();
                List<SaludModel> saludList = saludBO.ConsultaSalud(id, null);

                if (saludList.Count > 0)
                {

                    SaludCompletelList = saludList;
                    foreach (var sld in saludList)
                    {
                        grdSalud.Rows.Add(sld.Id_Salud, sld.Fk_id_cliente, sld.Nombre, sld.Enfermedad,sld.Medicacion,sld.Carnet_vacuna, sld.Observacion, sld.Usuario, sld.Fecha_mod);
                    }
                    grdSalud.ReadOnly = true;
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
                SaludBO saludBO = new SaludBO();
                clientesList = saludBO.LoadClientes();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool LoadEnfermedades()
        {
            try
            {
                enfermedadesList = new List<ListaEnfermedades>();
                SaludBO saludBO = new SaludBO();
                enfermedadesList = saludBO.LoadEnfermedades();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void CleanData()
        {
            idClienteStatic = 0;
            idSalud = 0;

            cbxCliente.Items.Clear();//Limpia los valores que pueda tene
            cbxCliente.Text = "";

            tbxMedicacion.Text = "";

            cbxEnfermedades.Items.Clear();
            cbxEnfermedades.Text = "";

            cxbCarnet.Items.Clear();
            cxbCarnet.Text = "";

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

            txtObservciones.Enabled = true;
            tbxMedicacion.Enabled = true;

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

                CargarElementsEdit();

            }


            btnFiltrar.Enabled = false;
            btnFiltrar.Visible = false;
        }

        private void ResetFilterElements()
        {
            cbxFiltroNombreCliente.Items.Clear();

            cbxFiltroEnfermedad.Items.Clear();
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

            txtObservciones.Enabled = false;
            txtObservciones.Enabled=false;

            btnFiltrar.Enabled = true;
            btnFiltrar.Visible = true;

            actionsInUse = true;
        }

        private bool ValidarInformacionElementosFiltros()
        {
            bool resposneClientes = LoadClientes();

            bool responseEnfermedad = LoadEnfermedades();

            if (!resposneClientes || !responseEnfermedad)
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
            //Cliente
            if (cbxCliente.SelectedItem == null)
            {
                MessageBox.Show("Ingrese el nombre.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            //Alimento
            if (cbxEnfermedades.SelectedItem == null)
            {
                MessageBox.Show("Ingrese la enfermedad.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            //observaciones
            if (txtObservciones.Text.Length > 400)
            {
                MessageBox.Show("Has superado el número de caracteres para Observación. Caracteres máximos: 100", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            //Medicacion
            if (tbxMedicacion.Text.Length > 500)
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
                cbxFiltroNombreCliente.Items.Add(item.nombre);
            }

            foreach (var item in enfermedadesList)
            {
                cbxFiltroEnfermedad.Items.Add(item.Enfermedades);
            }
        }

        private void CargarElemActions()
        {
            //Cargo el nombre de los clientes y de los colaboradores
            foreach (var item in enfermedadesList)
            {
                cbxEnfermedades.Items.Add(item.Enfermedades);
            }

            foreach (var item in clientesList)
            {
                cbxCliente.Items.Add(item.nombre);
            }

            cxbCarnet.Items.Add("SI");
            cxbCarnet.Items.Add("NO");
        }

        private void CargarElementsEdit()
        {
            enfermedadEdit = cbxEnfermedades.SelectedItem.ToString();
            foreach (var item in enfermedadesList)
            {        
                if (cbxEnfermedades.SelectedItem.ToString() != item.Enfermedades)
                {
                    cbxEnfermedades.Items.Add(item.Enfermedades);
                }

            }

            if (cxbCarnet.SelectedItem.ToString() == "SI")
            {
                cbxEnfermedades.Items.Add("NO");
            }
            if (cxbCarnet.SelectedItem.ToString() == "NO")
            {
                cbxEnfermedades.Items.Add("SI");
            }
        }

        private void SaludForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            VariablesGlobales.OpenSalud = false;
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            ResetFilterElements();
            LoadInformation(0);
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                SaludBO saludBO = new SaludBO();

                List<SaludModel> saludList = new List<SaludModel>();

                grdSalud.Rows.Clear();

                string nombre = null;

                if (cbxFiltroNombreCliente.SelectedItem != null)
                {
                    nombre = cbxFiltroNombreCliente.SelectedItem.ToString();
                }

                int idCliente = clientesList.Where(x => x.nombre == nombre).Select(x => x.Id_Cliente).FirstOrDefault();

                string enfermedad = null;

                if (cbxFiltroEnfermedad.SelectedItem != null)
                {
                    enfermedad = cbxFiltroEnfermedad.SelectedItem.ToString();
                }

                saludList = saludBO.ConsultaSalud(idCliente, enfermedad);

                if (saludList.Count > 0)
                {
                    SaludCompletelList = saludList;

                    SaludCompletelList = saludList;
                    foreach (var sld in saludList)
                    {
                        grdSalud.Rows.Add(sld.Id_Salud, sld.Fk_id_cliente, sld.Nombre, sld.Enfermedad, sld.Medicacion, sld.Carnet_vacuna, sld.Observacion, sld.Usuario, sld.Fecha_mod);
                    }
                    grdSalud.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                ResetFilterElements();
                LoadInformation(0);
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
                if (cbxCliente.SelectedItem == null) //Valida que tenga un item seleccionado del grid
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
                throw (ex);
            }
        }

        private void grdSalud_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (!actionsInUse)
                {
                    return;
                }

                filaSeleccionada = e.RowIndex;

                idSalud = 0;
                idClienteStatic = 0;

                //Valida que el clic no sea de los headers
                if (filaSeleccionada != -1)
                {
                    idSalud = int.Parse(grdSalud.Rows[filaSeleccionada].Cells[0].Value.ToString());
                    idClienteStatic = int.Parse(grdSalud.Rows[filaSeleccionada].Cells[1].Value.ToString());

                    cbxCliente.Items.Clear();
                    cbxCliente.SelectedItem = (string)grdSalud.Rows[filaSeleccionada].Cells[2].Value;
                    cbxCliente.Items.Add((string)grdSalud.Rows[filaSeleccionada].Cells[2].Value);
                    cbxCliente.Text = (string)grdSalud.Rows[filaSeleccionada].Cells[2].Value;

                    cbxEnfermedades.Items.Clear();
                    cbxEnfermedades.SelectedItem = (string)grdSalud.Rows[filaSeleccionada].Cells[3].Value;
                    cbxEnfermedades.Items.Add((string)grdSalud.Rows[filaSeleccionada].Cells[3].Value);
                    cbxEnfermedades.Text = (string)grdSalud.Rows[filaSeleccionada].Cells[3].Value;

                    tbxMedicacion.Text= (string)grdSalud.Rows[filaSeleccionada].Cells[4].Value;

                    cxbCarnet.Items.Clear();
                    cxbCarnet.SelectedItem = (string)grdSalud.Rows[filaSeleccionada].Cells[5].Value;
                    cxbCarnet.Items.Add((string)grdSalud.Rows[filaSeleccionada].Cells[5].Value);
                    cxbCarnet.Text = (string)grdSalud.Rows[filaSeleccionada].Cells[5].Value;

                    txtObservciones.Text = (string)grdSalud.Rows[filaSeleccionada].Cells[6].Value;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxCliente.SelectedItem == null) //Valida que tenga un item seleccionado del grid
                {
                    return;
                }

                DialogResult response = MessageBox.Show("Eliminar item seleccionado", "Está seguro de que desea eliminar este elemento?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (response == DialogResult.Yes)
                {
                    SaludBO saludBO = new SaludBO();
                    SaludModel saludModel = new SaludModel();

                    saludModel.Id_Salud = idSalud;

                    bool responseDB = saludBO.EliminarSalud(saludModel);
                    if (!responseDB)
                    {
                        MessageBox.Show("No se eliminar el registro, inténtelo más tarde.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    MessageBox.Show("La información se ha eliminado EXITOSAMENTE!", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CleanData();
                    LoadInformation(0);
                }
            }
            catch (Exception ex)
            {
                CleanData();
                LoadInformation(0);
                MessageBox.Show("No se pudo eliminar el registro, inténtelo más tarde." + ex, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
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
                    SaludBO saludBO = new SaludBO();
                    SaludModel saludModel = new SaludModel();

                    var nombreCliente = cbxCliente.SelectedItem.ToString();

                    saludModel.Nombre = nombreCliente;
                    saludModel.Fk_id_cliente = clientesList.Where(x => x.nombre == nombreCliente).Select(x => x.Id_Cliente).FirstOrDefault();
                    saludModel.Enfermedad = cbxEnfermedades.SelectedItem.ToString();
                    saludModel.Carnet_vacuna = cxbCarnet.SelectedItem.ToString();
                    saludModel.Medicacion = tbxMedicacion.Text;
                    saludModel.Observacion = txtObservciones.Text;
                    saludModel.Usuario = VariablesGlobales.usuario.ToString();
                    saludModel.Fecha_mod = DateTime.Now.ToString("dd/MM/yyyy");

                    bool responseInsert = saludBO.InsertarSalud(saludModel);

                    if (!responseInsert)
                    {
                        MessageBox.Show("No se pudo guardar la información, inténtelo más tarde.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    MessageBox.Show("La información se ha guardado EXITOSAMENTE!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    SaludBO saludBO = new SaludBO();
                    SaludModel saludModel = new SaludModel();

                    var nombreCliente = cbxCliente.SelectedItem.ToString();

                    saludModel.Id_Salud = idSalud;
                    saludModel.Fk_id_cliente = clientesList.Where(x => x.nombre == nombreCliente).Select(x => x.Id_Cliente).FirstOrDefault();
                    if (enfermedadEdit!= cbxEnfermedades.SelectedItem.ToString())
                    {
                        saludModel.Enfermedad = cbxEnfermedades.SelectedItem.ToString();
                    }
                    
                    saludModel.Carnet_vacuna = cxbCarnet.SelectedItem.ToString();
                    saludModel.Medicacion = tbxMedicacion.Text;
                    saludModel.Observacion = txtObservciones.Text;
                    saludModel.Usuario = VariablesGlobales.usuario.ToString();
                    saludModel.Fecha_mod = DateTime.Now.ToString("dd/MM/yyyy");


                    bool response = saludBO.ActualizarSalud(saludModel);
                    if (!response)
                    {
                        MessageBox.Show("No se pudo editar la información, inténtelo más tarde.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    MessageBox.Show("La información se ha actualizado EXITOSAMENTE!", "Actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                ResetElements();
                LoadInformation(0);
                CleanData();
            }
            catch (Exception ex)
            {
                CleanData();
                ResetElements();
                LoadInformation(0);
                MessageBox.Show("Alerta, No se pudo guardar el registro\n" + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
