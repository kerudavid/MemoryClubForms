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
using static MemoryClubForms.BusinessBO.AlimentacionBO;

namespace MemoryClubForms.Forms
{
    public partial class AlimentosForm : Form
    {
        public int action = 0;//Valida que acción debe realizar el boton de guardar. si insertar o editar, insertar=1 y editar =2

        public int idAlimentacion = 0;
        public int idClienteStatic = 0;

        public int filaSeleccionada = 0;

        public static int sucursalUser = VariablesGlobales.sucursal;

        public static List<NombresClientes> clientesList = new List<NombresClientes>();

        public static List<AlimentosRestringidos> alimentosList = new List<AlimentosRestringidos>();

        public static List<AlimentacionModel> AlimentacionCompletelList = new List<AlimentacionModel>();

        public static bool actionsInUse = true;

        public AlimentosForm(int id)
        {
            InitializeComponent();
            VariablesGlobales.OpenAlimentacion = true;
            LoadInformation(id);

        }

        public AlimentosForm()
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

                if (idCliente>0)
                {
                    id = idCliente;
                }

                grdAlimentos.Rows.Clear();
                ResetFilterElements();

                AlimentacionBO alimentacionBO = new AlimentacionBO();
                AlimentacionCompletelList = new List<AlimentacionModel>();
                List<AlimentacionModel> alimentacionList = alimentacionBO.ConsultaAlimentacion(id, null);

                if (alimentacionList.Count > 0)
                {

                    AlimentacionCompletelList = alimentacionList;
                    foreach (var alm in alimentacionList)
                    {
                        grdAlimentos.Rows.Add(alm.Id_alimentacion,alm.Fk_id_cliente,alm.Nombre,alm.Alimento_restringido,alm.Observacion,alm.Usuario,alm.Fecha_mod);
                    }
                    grdAlimentos.ReadOnly = true;
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
                AlimentacionBO alimentacionBO = new AlimentacionBO();
                clientesList = alimentacionBO.LoadClientes();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool LoadAlimentos()
        {
            try
            {
                alimentosList = new List<AlimentosRestringidos>();
                AlimentacionBO alimentacionBO = new AlimentacionBO();
                alimentosList = alimentacionBO.LoadAlimentosR();
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
            idAlimentacion = 0;

            cbxCliente.Items.Clear();//Limpia los valores que pueda tene
            cbxCliente.Text = "";

            cbxAlimentos.Items.Clear();
            cbxAlimentos.Text = "";

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

        private bool ValidarInformacionElementosFiltros()
        {
            bool resposneClientes = LoadClientes();

            bool responseAlimentos = LoadAlimentos();

            if (!resposneClientes || !responseAlimentos)
            {
                return false;
            }

            return true;
        }

        private void CargarElemActions()
        {
            //Cargo el nombre de los clientes y de los colaboradores
            foreach (var item in alimentosList)
            {
                cbxAlimentos.Items.Add(item.Alimentos_r);
            }

            foreach (var item in clientesList)
            {
                cbxCliente.Items.Add(item.nombre);
            }
        }

        private void CargarElemFiltros()
        {

            foreach (var item in clientesList)
            {
                cbxFiltroNombreCliente.Items.Add(item.nombre);
            }

            foreach (var item in alimentosList)
            {
                cbxFiltroAlimentos.Items.Add(item.Alimentos_r);
            }        
        }

        private void CargarElementsEdit()
        {
            /*
            foreach (var item in clientesList)
            {
                if (cbxCliente.SelectedItem.ToString().ToLower() != item.nombre.ToLower())
                {
                    cbxCliente.Items.Add(item.nombre);
                }

            }*/

            foreach (var item in alimentosList)
            {
                if (cbxAlimentos.SelectedItem.ToString() != item.Alimentos_r)
                {
                    cbxAlimentos.Items.Add(item.Alimentos_r);
                }

            }
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

            btnFiltrar.Enabled = true;
            btnFiltrar.Visible = true;

            actionsInUse = true;
        }

        private void ResetFilterElements()
        {
            cbxFiltroNombreCliente.Items.Clear();

            cbxFiltroAlimentos.Items.Clear();
        }

        private bool ValidarInformacion()
        {
            if (VariablesGlobales.Nivel > 1)
            {
                MessageBox.Show("Su usuario no tiene privilegios necesarios para ingresar asistencias de otra sucursal.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            //Transportista
            if (cbxCliente.SelectedItem==null)
            {
                MessageBox.Show("Ingrese el nombre.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            //Alimento
            if (cbxAlimentos.SelectedItem==null)
            {
                MessageBox.Show("Ingrese el alimento.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
       
            //observaciones
            if (txtObservciones.Text.Length > 500)
            {
                MessageBox.Show("Has superado el número de caracteres para Observación. Caracteres máximos: 100", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        private void AlimentosForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            VariablesGlobales.OpenAlimentacion = false;
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

                idAlimentacion = 0;
                idClienteStatic = 0;

                //Valida que el clic no sea de los headers
                if (filaSeleccionada != -1)
                {
                    idAlimentacion = int.Parse(grdAlimentos.Rows[filaSeleccionada].Cells[0].Value.ToString());
                    idClienteStatic = int.Parse(grdAlimentos.Rows[filaSeleccionada].Cells[1].Value.ToString());

                    cbxCliente.Items.Clear();
                    cbxCliente.SelectedItem = (string)grdAlimentos.Rows[filaSeleccionada].Cells[2].Value.ToString();
                    cbxCliente.Items.Add((string)grdAlimentos.Rows[filaSeleccionada].Cells[2].Value.ToString());
                    cbxCliente.Text = (string)grdAlimentos.Rows[filaSeleccionada].Cells[2].Value.ToString();

                    cbxAlimentos.Items.Clear();
                    cbxAlimentos.SelectedItem = (string)grdAlimentos.Rows[filaSeleccionada].Cells[3].Value.ToString();
                    cbxAlimentos.Items.Add((string)grdAlimentos.Rows[filaSeleccionada].Cells[3].Value.ToString());
                    cbxAlimentos.Text = (string)grdAlimentos.Rows[filaSeleccionada].Cells[3].Value.ToString();

                    txtObservciones.Text = (string)grdAlimentos.Rows[filaSeleccionada].Cells[4].Value;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                AlimentacionBO alimentacionBO = new AlimentacionBO();

                List<AlimentacionModel> alimentacionList = new List<AlimentacionModel>();

                grdAlimentos.Rows.Clear();

                string nombre = null;

                if (cbxFiltroNombreCliente.SelectedItem != null)
                {
                    nombre = cbxFiltroNombreCliente.SelectedItem.ToString();
                }

                int idCliente = clientesList.Where(x => x.nombre == nombre).Select(x => x.Id_Cliente).FirstOrDefault();

                string alimento = null;

                if (cbxFiltroAlimentos.SelectedItem != null)
                {
                    alimento = cbxFiltroAlimentos.SelectedItem.ToString();
                }

                alimentacionList = alimentacionBO.ConsultaAlimentacion(idCliente, alimento);

                if (alimentacionList.Count > 0)
                {
                    AlimentacionCompletelList = alimentacionList;

                    foreach (var alm in alimentacionList)
                    {
                        grdAlimentos.Rows.Add(alm.Id_alimentacion, alm.Fk_id_cliente, alm.Nombre, alm.Alimento_restringido, alm.Observacion, alm.Usuario, alm.Fecha_mod);
                    }
                    grdAlimentos.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                ResetFilterElements();
                LoadInformation(0);
                MessageBox.Show("Alerta, No se pudo filtrar el registro\n" + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            ResetFilterElements();
            LoadInformation(0);
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
                if (cbxCliente.SelectedItem==null) //Valida que tenga un item seleccionado del grid
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxCliente.SelectedItem==null) //Valida que tenga un item seleccionado del grid
                {
                    return;
                }
               
                DialogResult response = MessageBox.Show("Eliminar item seleccionado", "Está seguro de que desea eliminar este elemento?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (response == DialogResult.Yes)
                {
                    AlimentacionBO alimentacionBO = new AlimentacionBO();
                    AlimentacionModel alimentacionModel = new AlimentacionModel();

                    alimentacionModel.Id_alimentacion = idAlimentacion;

                    bool responseDB = alimentacionBO.EliminarAlimentoR(alimentacionModel);
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
                    AlimentacionBO alimentacionBO = new AlimentacionBO();
                    AlimentacionModel alimentacionModel = new AlimentacionModel();

                    var nombreColaborador = cbxCliente.SelectedItem.ToString();

                    alimentacionModel.Nombre = nombreColaborador;
                    alimentacionModel.Fk_id_cliente = clientesList.Where(x => x.nombre == nombreColaborador).Select(x => x.Id_Cliente).FirstOrDefault();
                    alimentacionModel.Alimento_restringido=cbxAlimentos.SelectedItem.ToString();
                    alimentacionModel.Observacion = txtObservciones.Text;
                    alimentacionModel.Usuario = VariablesGlobales.usuario.ToString();
                    alimentacionModel.Fecha_mod = DateTime.Now.ToString("dd/MM/yyyy");

                    bool responseInsert = alimentacionBO.InsertarAlimentoR(alimentacionModel);

                    if (!responseInsert)
                    {
                        MessageBox.Show("No se pudo guardar la información, inténtelo más tarde.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    MessageBox.Show("La información se ha guardado EXITOSAMENTE!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    AlimentacionBO alimentacionBO = new AlimentacionBO();
                    AlimentacionModel alimentacionModel = new AlimentacionModel();

                    var nombreColaborador = cbxCliente.SelectedItem.ToString();

                    alimentacionModel.Id_alimentacion = idAlimentacion;
                    alimentacionModel.Fk_id_cliente = clientesList.Where(x => x.nombre == nombreColaborador).Select(x => x.Id_Cliente).FirstOrDefault();
                    alimentacionModel.Alimento_restringido = cbxAlimentos.SelectedItem.ToString();
                    alimentacionModel.Observacion = txtObservciones.Text;
                    alimentacionModel.Usuario = VariablesGlobales.usuario.ToString();
                    alimentacionModel.Fecha_mod = DateTime.Now.ToString("dd/MM/yyyy");


                    bool response = alimentacionBO.ActualizarAlimentoR(alimentacionModel);
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
