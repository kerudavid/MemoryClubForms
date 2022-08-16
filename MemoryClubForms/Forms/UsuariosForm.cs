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
using static MemoryClubForms.BusinessBO.UsuarioBO;
using System.Text.RegularExpressions;



namespace MemoryClubForms.Forms
{
    public partial class UsuariosForm : Form
    {
        public int action = 0;//Valida que acción debe realizar el boton de guardar. si insertar o editar, insertar=1 y editar =2

        public int filaSeleccionada = 0;

        public int idUsuario = 0;

        public static List<CodigosNiveles> codigosNivelesList = new List<CodigosNiveles>();

        public static int sucursalUser = VariablesGlobales.sucursal;

        public static List<CodigosSucursales> codigosSucursalesList = new List<CodigosSucursales>();

        public static List<CodigosEstados> codigosEstadosList = new List<CodigosEstados>();

        public static List<UsuarioModel> UsuarioListComplete = new List<UsuarioModel>();

        public static bool actionsInUse = true;
        public UsuariosForm()
        {
            InitializeComponent();
            LoadInformation();
        }

        //cerrar la ventana
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //botón reiniciar filtro
        private void btnReiniciarFiltro_Click(object sender, EventArgs e)
        {
            ResetFilterElements();
            LoadInformation();
        }

        //limpiar los combo box de los filtros
        private void ResetFilterElements()
        {

            cbxFiltroSucursal.Items.Clear();
            cbxFiltroEstado.Items.Clear();
         }

        //cargar la información de la consulta por defecto
        private void LoadInformation()
        {
            try
            {
                grdUsuario.Rows.Clear();
                ResetFilterElements();

                UsuarioBO usuarioBO = new UsuarioBO();
                UsuarioListComplete = new List<UsuarioModel>();
                List<UsuarioModel> usuarioList = usuarioBO.ConsultaUsuarios( 0, null);

                if (usuarioList.Count > 0)
                {
                    UsuarioListComplete = usuarioList;
                    foreach (var usua in usuarioList)
                    {
                        grdUsuario.Rows.Add(usua.Id_usuario, usua.Usuario, usua.Clave, usua.Nivel, usua.Descripcion, usua.Estado, usua.Sucursal, usua.Observacion, usua.Fecha_mod);
                    }
                    grdUsuario.ReadOnly = true;
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
                MessageBox.Show("No se pudo cargar la información. " + ex, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //carga información en los combo box
        private void CargarElemFiltros()
        {
            foreach (var item in codigosSucursalesList)
            {
                cbxFiltroSucursal.Items.Add(item.Sucursales.ToString());
            }

            foreach (var item in codigosEstadosList)
            {
                cbxFiltroEstado.Items.Add(item.Descripcion.ToString());
            }
            cbxFiltroEstado.Items.Add("TODOS");
        }

        //valida si se pudo cargar información de los filtros
        private bool ValidarInformacionElementosFiltros()
        {
            bool responseEstados = LoadEstados();

            bool responseSucursales = LoadSucursales();

            bool responseNiveles = LoadNiveles();

            if (!responseEstados || !responseSucursales)
            {
                return false;
            }
            return true;
        }

        //trae información de las sucursales
        private bool LoadSucursales()
        {
            try
            {
                codigosSucursalesList = new List<CodigosSucursales>();
                UsuarioBO usuarioBO = new UsuarioBO();
                codigosSucursalesList = usuarioBO.LoadSucursales();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //trae información de los niveles
        private bool LoadNiveles()
        {
            try
            {
                codigosNivelesList = new List<CodigosNiveles>();
                UsuarioBO usuarioBO = new UsuarioBO();
                codigosNivelesList = usuarioBO.LoadNiveles();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //trae información de los estados
        private bool LoadEstados()
        {
            try
            {
                codigosEstadosList = new List<CodigosEstados>();
                UsuarioBO usuarioBO = new UsuarioBO();
                codigosEstadosList = usuarioBO.LoadEstados();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //valida la información 
        private bool ValidarInformacion()
        {
            if (VariablesGlobales.Nivel > 1)
            {
                MessageBox.Show("Su usuario no tiene privilegios para registrar un usuario de otra sucursal.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (string.IsNullOrEmpty(tbxUsuario.Text))
            {
                MessageBox.Show("Digite el Usuario", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (tbxUsuario.Text.Length > 20)
            {
                MessageBox.Show("Has superado el número de caracteres para Usuario", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (string.IsNullOrEmpty(tbxClave.Text))
            {
                MessageBox.Show("Digite una Clave", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (tbxClave.Text.Length > 20) //en la bdd está 50 caracteres, pero el programa lo dejará en máximo 20
            {
                MessageBox.Show("Has superado el número de caracteres de 20 para la Clave", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (cbxNivel.SelectedItem == null)
            {
                MessageBox.Show("Seleccione el Nivel del Usuario.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (cbxEstado.SelectedItem == null)
            {
                MessageBox.Show("Seleccione el Estado del Usuario.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (cbxSucursal.SelectedItem == null)
            {
                MessageBox.Show("Seleccione la sucursal.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (string.IsNullOrEmpty(tbxDescripcion.Text))
            {
                MessageBox.Show("Ingrese el Nombre del Usuario.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (tbxDescripcion.Text.Length > 80)
            {
                MessageBox.Show("Has superado el número de caracteres de 80 en Descripción.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (txtObservciones.Text.Length > 50)
            {
                MessageBox.Show("Has superado el número de caracteres para Observación. Caracteres máximos: 50", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        //valida que en el usuario solo se digiten letras, no permite espacios en blanco
        private void tbxUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }

        }

        //cargar combo box' s para editar
        private void CargarElementsEdit()
        {
            foreach (var item in codigosEstadosList)
            {
                if (cbxEstado.SelectedItem.ToString().ToLower() != item.Estados.ToLower())
                    cbxEstado.Items.Add(item.Estados);
            }
            foreach (var item in codigosSucursalesList)
            {
                cbxSucursal.Items.Add(item.Sucursales);
            }
            foreach (var item in codigosNivelesList)
            {

                if (cbxNivel.SelectedItem.ToString().ToLower() != item.Descripcion.ToLower())
                    cbxNivel.Items.Add(item.Descripcion);
            }
        }
        //Cargar las sucursales, estados y niveles de los usuarios
        private void CargarElemActions()
        {
            //Cargo el nombre de los clientes y de los colaboradores
            foreach (var item in codigosSucursalesList)
            {
                cbxSucursal.Items.Add(item.Sucursales);
            }
            foreach (var items in codigosEstadosList)
            {
                cbxEstado.Items.Add(items.Estados);
            }
            foreach (var ite in codigosNivelesList)
            {
                cbxNivel.Items.Add(ite.Descripcion);
            }
        }
        
        //activa / desactiva los controles de la pantalla
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

            tbxUsuario.Enabled = false;
            tbxClave.Enabled = false;
            tbxDescripcion.Enabled = false;
            txtObservciones.Enabled = false;

            btnFiltrar.Enabled = true;
            btnFiltrar.Visible = true;

            actionsInUse = true;
        }

        //cuando se activa el modo edición
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


            tbxDescripcion.Enabled = true;
            tbxClave.Enabled = true;
            txtObservciones.Enabled = true;

            if (action == 1)
            {
                tbxUsuario.Enabled = true;

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

        //limpia los campos de edición
        private void CleanData()
        {
            idUsuario = 0;

            cbxSucursal.Items.Clear();//Limpia los valores que pueda tener
            cbxSucursal.Text = "";

            cbxNivel.Items.Clear();
            cbxNivel.Text = "";

            lblEstado.Visible = false;
            cbxEstado.Visible = false;
            cbxEstado.Enabled = false;
            cbxEstado.Items.Clear();
            cbxEstado.Text = "";

            tbxUsuario.Text = "";

            tbxClave.Text = "";

            tbxDescripcion.Text = "";

            txtObservciones.Text = "";
        }

        //copia los datos de la consulta en la parte de edición
        private void Row_Clicked(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (!actionsInUse)
                {
                    return;
                }

                filaSeleccionada = e.RowIndex;

                idUsuario = 0;

                //Valida que el clic no sea de los headers
                if (filaSeleccionada != -1)
                {
                    string ls_nivel;

                    idUsuario = int.Parse(grdUsuario.Rows[filaSeleccionada].Cells[0].Value.ToString());

                    tbxUsuario.Text = (string)grdUsuario.Rows[filaSeleccionada].Cells[1].Value;

                    tbxClave.Text = (string)grdUsuario.Rows[filaSeleccionada].Cells[2].Value;

                    tbxDescripcion.Text = (string)grdUsuario.Rows[filaSeleccionada].Cells[4].Value;

                    cbxEstado.Items.Clear();
                    cbxEstado.SelectedItem = (string)grdUsuario.Rows[filaSeleccionada].Cells[5].Value.ToString();
                    cbxEstado.Items.Add((string)grdUsuario.Rows[filaSeleccionada].Cells[5].Value.ToString());
                    cbxEstado.Text = (string)grdUsuario.Rows[filaSeleccionada].Cells[5].Value.ToString();

                    cbxSucursal.Items.Clear();
                    cbxSucursal.SelectedItem = (string)grdUsuario.Rows[filaSeleccionada].Cells[6].Value.ToString();
                    cbxSucursal.Items.Add((string)grdUsuario.Rows[filaSeleccionada].Cells[6].Value.ToString());
                    cbxSucursal.Text = (string)grdUsuario.Rows[filaSeleccionada].Cells[6].Value.ToString();

                    ls_nivel = (string)grdUsuario.Rows[filaSeleccionada].Cells[3].Value.ToString();

                    var level = codigosNivelesList.Where(x => x.Niveles.ToString() == ls_nivel).FirstOrDefault().Descripcion;

                    cbxNivel.Items.Clear();

                    cbxNivel.SelectedItem = (string)level;
                    cbxNivel.Items.Add((string)level);
                    cbxNivel.Text = (string)level;

                    txtObservciones.Text = (string)grdUsuario.Rows[filaSeleccionada].Cells[7].Value;
                }
            }
            catch (Exception ex)
            {
                             
            }

        }

        //al hacer clic en cancelar
        private void btnCancel_Click(object sender, EventArgs e)
        {
            CleanData();
            ResetElements();
        }

        //al filtrar
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioBO usuarioBO = new UsuarioBO();

                List<UsuarioModel> usuarioList = new List<UsuarioModel>();

                grdUsuario.Rows.Clear();

                int sucursal = 0;

                if (cbxFiltroSucursal.SelectedItem != null)
                {
                    sucursal = int.Parse(cbxFiltroSucursal.SelectedItem.ToString());
                }

                string estado = null;
                string pEstado = null;

                if (cbxFiltroEstado.SelectedItem != null)
                {
                    estado = cbxFiltroEstado.SelectedItem.ToString();
                }

                pEstado = codigosEstadosList.Where(x => x.Descripcion == estado).Select(x => x.Estados).FirstOrDefault();

                usuarioList = usuarioBO.ConsultaUsuarios(sucursal, pEstado);

                if (usuarioList.Count > 0)
                {
                    foreach (var usua in usuarioList)
                    {
                        grdUsuario.Rows.Add(usua.Id_usuario, usua.Usuario, usua.Clave, usua.Nivel, usua.Descripcion, usua.Estado, usua.Sucursal, usua.Observacion, usua.Fecha_mod);
                    }
                    grdUsuario.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                ResetFilterElements();
                LoadInformation();
                MessageBox.Show("Alerta, No se pudo filtrar el registro\n" + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //insertar
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
                CargarElemActions(); //cargar los estados, niveles y sucursales
                cbxEstado.SelectedIndex = cbxEstado.FindStringExact("A");
            }
            catch (Exception ex)
            {
                ResetElements();
                MessageBox.Show("Aviso, No se pudo cargar estados, niveles ni sucursales. " + ex);
            }
        }

        //Editar
        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(tbxUsuario.Text)) //Valida que tenga un item seleccionado del grid
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

        //guardar
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
                    string desc_nivel = "";
                    int linivel = -1;
                    UsuarioBO usuarioBO = new UsuarioBO();
                    UsuarioModel usuarioModel = new UsuarioModel();

                    var usuar = tbxUsuario.Text;

                    usuarioModel.Usuario = usuar;
                    usuarioModel.Clave = tbxClave.Text;
                    usuarioModel.Descripcion = tbxDescripcion.Text;

                    if (cbxNivel.SelectedItem != null)
                    {
                        desc_nivel = cbxNivel.SelectedItem.ToString();
                        linivel = codigosNivelesList.Where(x => x.Descripcion == desc_nivel).Select(x => x.Niveles).FirstOrDefault();
                    }

                    usuarioModel.Nivel = linivel;
                    //usuarioModel.Estado = codigosEstadosList.Where(x => x.Descripcion == "ACTIVO").Select(x => x.Estados).FirstOrDefault();
                    usuarioModel.Estado = "A";
                    usuarioModel.Observacion = txtObservciones.Text;
                    usuarioModel.Sucursal = int.Parse(cbxSucursal.SelectedItem.ToString());
                    usuarioModel.Fecha_mod = DateTime.Now.ToString("dd/MM/yyyy");

                    string responseInsert = usuarioBO.InsertUsuario(usuarioModel);

                    if (responseInsert != "OK")
                    {
                        MessageBox.Show("No se pudo guardar la información\n" + responseInsert, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    MessageBox.Show("La información se ha guardado EXITOSAMENTE!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    string desc_nivel = "";
                    int linivel = -1;

                    UsuarioBO usuarioBO = new UsuarioBO();
                    UsuarioModel usuarioModel = new UsuarioModel();

                    var usuar = tbxUsuario.Text;

                    usuarioModel.Id_usuario = idUsuario;
                    usuarioModel.Usuario = usuar;
                    usuarioModel.Clave = tbxClave.Text;
                    usuarioModel.Descripcion = tbxDescripcion.Text;

                    if (cbxNivel.SelectedItem != null)
                    {
                        desc_nivel = cbxNivel.SelectedItem.ToString();
                        linivel = codigosNivelesList.Where(x => x.Descripcion == desc_nivel).Select(x => x.Niveles).FirstOrDefault();
                        usuarioModel.Nivel = linivel;
                    }
                
                    usuarioModel.Estado = cbxEstado.SelectedItem.ToString();
                    usuarioModel.Observacion = txtObservciones.Text;
                    usuarioModel.Sucursal = int.Parse(cbxSucursal.SelectedItem.ToString());
                    usuarioModel.Fecha_mod = DateTime.Now.ToString("dd/MM/yyyy");

                    string response = usuarioBO.ActualizarUsuario(usuarioModel);
                    if (response != "OK")
                    {
                        MessageBox.Show("No se pudo editar la información\n" + response, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        //eliminar
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(tbxUsuario.Text)) //Valida que tenga un item seleccionado del grid
                {
                    return;
                }

                DialogResult response = MessageBox.Show("Eliminar item seleccionado", "Está seguro de que desea eliminar este elemento?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (response == DialogResult.Yes)
                {
                    UsuarioBO usuarioBO = new UsuarioBO();
                    UsuarioModel usuarioModel = new UsuarioModel();

                    usuarioModel.Id_usuario = idUsuario;

                    string responseDB = usuarioBO.EliminarUsuario(usuarioModel);
                    if (responseDB != "OK")
                    {
                        MessageBox.Show("No se eliminar el registro\n" + responseDB, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

    }

}
