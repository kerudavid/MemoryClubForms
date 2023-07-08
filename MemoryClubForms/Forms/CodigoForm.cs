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
using static MemoryClubForms.BusinessBO.CodigoBO;
using System.Globalization;


namespace MemoryClubForms.Forms
{
    public partial class CodigoForm : Form
    {
        CultureInfo ci = new CultureInfo("en-US");

        public int action = 0;//Valida que acción debe realizar el boton de guardar. si insertar o editar, insertar=1 y editar =2
        public int idcodigo = 0;
        public string Grupo = "";
        public string Subgrupo = "";
        public int filaSeleccionada = 0;
        public static int sucursalUser = VariablesGlobales.sucursal;
        public static List<CodigosEstados> estadosList = new List<CodigosEstados>();
        public static List<TiposParametros> tipoParamList = new List<TiposParametros>();
        public static List<CodigoModel> parametrosComplete = new List<CodigoModel>();
        public static bool actionsInUse = true;

        public CodigoForm()
        {
            InitializeComponent();
            LoadInformation();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// botón reiniciar filtro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReiniciarFiltro_Click(object sender, EventArgs e)
        {
            ResetFilterElements();
            LoadInformation();
        }
        private void ResetFilterElements()
        {
            cbxFiltroParametro.Items.Clear();
            cbxFiltroEstado.Items.Clear();
        }

        private void LoadInformation()
        {
            try
            {
                grdCodigo.Rows.Clear();
                ResetFilterElements();
                CodigoBO codigoBO = new CodigoBO();
                parametrosComplete = new List<CodigoModel>();
                List<CodigoModel> parametrosList = codigoBO.ConsultaParametros(null, null, null);

                if (parametrosList.Count > 0)
                {
                    parametrosComplete = parametrosList;
                    foreach (var param in parametrosList)
                    {
                        grdCodigo.Rows.Add(param.Id_codigo, param.Grupo, param.Subgrupo, param.Elemento, param.Descripcion, param.Valor1, param.Valor2, param.Estado, param.Usuario, param.Fecha_mod);
                    }
                    grdCodigo.ReadOnly = true;
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
                MessageBox.Show("No se pudo cargar la información para realizar filtros" + ex, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private bool ValidarInformacionElementosFiltros()
        {
            bool responseEstados = LoadEstados();
            bool responseSucursales = LoadTiposParam();
            if (!responseEstados || !responseSucursales)
            {
                return false;
            }
            return true;
        }
        private bool LoadTiposParam()
        {
            try
            {
                tipoParamList = new List<TiposParametros>();
                CodigoBO codigosBO = new CodigoBO();
                tipoParamList = codigosBO.LoadTiposParame();
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
                estadosList = new List<CodigosEstados>();
                CodigoBO codigoBO = new CodigoBO();
                estadosList = codigoBO.LoadEstados();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void CargarElemFiltros()
        {
            foreach (var item in tipoParamList)
            {
                cbxFiltroParametro.Items.Add(item.Descripcion);
            }
            foreach (var item in estadosList)
            {
                cbxFiltroEstado.Items.Add(item.Descripcion.ToString());
            }            //cbxFiltroEstadoCliente.Items.Add("TODOS");
        }
        private bool ValidarInformacion(int accion)
        {
            if (VariablesGlobales.Nivel > 1)
            {
                MessageBox.Show("Su usuario no tiene privilegios modificar los Parámetros.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (accion == 1)//valida si es insertar
            {
                if (cbxTipoParametro.SelectedItem == null)
                {
                    MessageBox.Show("Seleccione el Tipo de Parámetro.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            else
            {   //valida si es editar
                if (cbxEstado.SelectedItem == null)
                {
                    MessageBox.Show("Seleccione el Estado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }

            if (string.IsNullOrEmpty(tbxCodigoElemento.Text))
            {
                MessageBox.Show("Ingrese el Código Elemento como quiere visualizarlo en el sistema. Recuerde que no debe dejar espacios en blanco", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (string.IsNullOrEmpty(tbxDescripcion.Text))
            {
                MessageBox.Show("Ingrese la descripción del Parámetro", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            } 
            return true;
        }

        private void tbxCodigoElemento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != 45 && e.KeyChar != 95)//OJO
            {
                e.Handled = true; // Bloquea el carácter si no es una letra, un dígito, un carácter de control o un espacio en blanco
                MessageBox.Show("Recuerde que no debe dejar espacios en blanco ni caracteres especiales", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void CargarElementsEdit() //añade datos al cbxestado
        {
            foreach (var item in estadosList)
            {
                if (cbxEstado.SelectedItem.ToString().ToLower() != item.Estados.ToLower())
                    cbxEstado.Items.Add(item.Estados);
            }
        }
        private void CargarElemActions() //añade datos al cbxparametro
        {
            foreach (var item in tipoParamList)
            {
                cbxTipoParametro.Items.Add(item.Descripcion);
            }
        }
        private void ResetElements() //activar y desactivar botones
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

            tbxCodigoElemento.Enabled = false;
            tbxDescripcion.Enabled = false;

            btnFiltrar.Enabled = true;
            btnFiltrar.Visible = true;

            actionsInUse = true;
        }
        private void EditElements(int action) //configura los controles de la ventana de acuerdo a la elección del usuario
        {
            actionsInUse = false;

            pnlActions.BackColor = Color.FromArgb(245, 245, 245);
            pnlActions.BorderStyle = BorderStyle.FixedSingle;
            pnlActions.ForeColor = Color.FromArgb(3, 79, 150);

            btnEliminar.BackColor = Color.FromArgb(160, 160, 160);
            btnEliminar.ForeColor = Color.FromArgb(221, 221, 221);
            btnEliminar.FlatAppearance.BorderColor = Color.FromArgb(221, 221, 221);
            btnEliminar.Enabled = false;

            tbxCodigoElemento.Enabled = true;
            tbxDescripcion.Enabled = true;

            if (action == 1) //si elije INSERTAR
            {
                tbxCodigoElemento.Enabled = true;
                tbxDescripcion.Enabled = true;
                cbxTipoParametro.Enabled = true;


                btnEditar.BackColor = Color.FromArgb(160, 160, 160);
                btnEditar.ForeColor = Color.FromArgb(221, 221, 221);
                btnEditar.FlatAppearance.BorderColor = Color.FromArgb(221, 221, 221);
                btnEditar.Enabled = false;
            }
            else if (action == 2) //elije EDITAR
            {
                btnInsertar.BackColor = Color.FromArgb(160, 160, 160);
                btnInsertar.ForeColor = Color.FromArgb(221, 221, 221);
                btnInsertar.FlatAppearance.BorderColor = Color.FromArgb(221, 221, 221);
                btnInsertar.Enabled = false;

                lblEstado.Visible = true;
                cbxEstado.Visible = true;
                cbxEstado.Enabled = true;

                CargarElementsEdit(); //carga los estados al cbx estados
            }

            btnFiltrar.Enabled = false;
            btnFiltrar.Visible = false;
        }
        private void CleanData()
        {
            idcodigo = 0;
            Grupo = "";
            Subgrupo = "";
            cbxTipoParametro.Enabled = false;
            cbxTipoParametro.Items.Clear();//Limpia los valores que pueda tener
            cbxTipoParametro.Text = "";

            lblEstado.Visible = false;
            cbxEstado.Visible = false;
            cbxEstado.Enabled = false;
            cbxEstado.Items.Clear();
            cbxEstado.Text = "";

            tbxCodigoElemento.Text = "";
            tbxDescripcion.Text = "";
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
                idcodigo = 0;
                Grupo = "";
                Subgrupo = "";

                if (filaSeleccionada != -1) //Valida que el clic no sea de los headers
                {
                    idcodigo = int.Parse(grdCodigo.Rows[filaSeleccionada].Cells[0].Value.ToString());
                    Grupo = (string)grdCodigo.Rows[filaSeleccionada].Cells[1].Value;
                    Subgrupo = (string)grdCodigo.Rows[filaSeleccionada].Cells[2].Value;

                    tbxCodigoElemento.Text = (string)grdCodigo.Rows[filaSeleccionada].Cells[3].Value;
                    tbxDescripcion.Text = (string)grdCodigo.Rows[filaSeleccionada].Cells[4].Value;

                    cbxTipoParametro.Items.Clear();
                    cbxEstado.Items.Clear();
                    cbxEstado.SelectedItem = (string)grdCodigo.Rows[filaSeleccionada].Cells[7].Value.ToString();
                    cbxEstado.Items.Add((string)grdCodigo.Rows[filaSeleccionada].Cells[7].Value.ToString());
                    cbxEstado.Text = (string)grdCodigo.Rows[filaSeleccionada].Cells[7].Value.ToString();
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
        /// <summary>
        /// Aplica los filtros seleccionados al datagrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                CodigoBO codigoBO = new CodigoBO();

                List<CodigoModel> codigosList = new List<CodigoModel>();

                grdCodigo.Rows.Clear();

                string nombre = null;

                string grupos = null;
                string subgrupos = null;
                if (cbxFiltroParametro.SelectedItem != null)
                {
                    nombre = cbxFiltroParametro.SelectedItem.ToString();
                    grupos = tipoParamList.Where(x => x.Descripcion == nombre).Select(x => x.Grupo).FirstOrDefault();
                    subgrupos = tipoParamList.Where(x => x.Descripcion == nombre).Select(x => x.Subgrupo).FirstOrDefault();
                }
               
                string estado = null;
                string pEstado = null;
                if (cbxFiltroEstado.SelectedItem != null)
                {
                    estado = cbxFiltroEstado.SelectedItem.ToString();
                    pEstado = estadosList.Where(x => x.Descripcion == estado).Select(x => x.Estados).FirstOrDefault();
                }

                if ((!(string.IsNullOrEmpty(grupos)) && !(string.IsNullOrEmpty(subgrupos))) || !(string.IsNullOrEmpty(pEstado)))
                {
                    codigosList = codigoBO.ConsultaParametros(grupos, subgrupos, pEstado);

                    if (codigosList.Count > 0)
                    {
                        foreach (var codi in codigosList)
                        {
                            grdCodigo.Rows.Add(codi.Id_codigo, codi.Grupo, codi.Subgrupo, codi.Elemento, codi.Descripcion, codi.Valor1, codi.Valor2, codi.Estado, codi.Usuario, codi.Fecha_mod);
                        }
                        grdCodigo.ReadOnly = true;
                    }
                }
            }
            catch (Exception ex)
            {
                ResetFilterElements();
                LoadInformation();
                MessageBox.Show("Alerta, No se pudo aplicar el filtro.\n" + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        /// <summary>
        /// Insertar un registro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            action = 1;
            btnGuardar.Enabled = true;
            btnGuardar.Visible = true;

            lblAction.Text = "Insertando";

            CleanData();//Limpia la data que se haya seleccionado del grid

            EditElements(1);//Cambia de aspecto a los elementos para indicar al usuario que se realizara una accion, en este caso insertar

            try
            {
                CargarElemActions(); //carga los datos al cbx tipo parámetro
            }
            catch (Exception ex)
            {
                ResetElements();
                MessageBox.Show("Aviso, No se pudo cargar los tipos de parámetros " + ex);
            }
        }

        /// <summary>
        /// EDITAR parámetro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(tbxCodigoElemento.Text)) //Valida que tenga un item seleccionado del grid
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
                MessageBox.Show("Aviso, Problemas al cargar datos para editar " + ex);
            }
        }
        /// <summary>
        /// GRABAR LOS DATOS INSERTADOS O EDITADOS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (action == 1) //Insertar
                {
                    if (!ValidarInformacion(1))
                    {
                        return;
                    }
                    CodigoBO codigoBO = new CodigoBO();
                    CodigoModel codigoModel = new CodigoModel();
                    string nombre = null;

                    if (cbxTipoParametro.SelectedItem != null)
                    {
                        nombre = cbxTipoParametro.SelectedItem.ToString();
                    }
                    string grupo = tipoParamList.Where(x => x.Descripcion == nombre).Select(x => x.Grupo).FirstOrDefault();
                    string subgrupo = tipoParamList.Where(x => x.Descripcion == nombre).Select(x => x.Subgrupo).FirstOrDefault();

                    codigoModel.Grupo = grupo;
                    codigoModel.Subgrupo = subgrupo;
                    codigoModel.Elemento = tbxCodigoElemento.Text; 
                    codigoModel.Descripcion = tbxDescripcion.Text;
                    codigoModel.Valor1 = 0;
                    codigoModel.Valor2 = Convert.ToDecimal("0.00");
                    codigoModel.Estado = "A";
                    codigoModel.Usuario = VariablesGlobales.usuario.ToString();
                    codigoModel.Fecha_mod = DateTime.Now.ToString("MM/dd/yyyy", ci);

                    string responseInsert = codigoBO.InsertarParametro(codigoModel);

                    if (responseInsert != "OK")
                    {
                        MessageBox.Show(responseInsert, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    MessageBox.Show("La información se ha guardado EXITOSAMENTE!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    CodigoBO codigoBO = new CodigoBO();
                    CodigoModel codigoModel = new CodigoModel();

                    if (!ValidarInformacion(2)) //editar
                    {
                        return;
                    }
                                                                           
                    codigoModel.Id_codigo = idcodigo;
                    codigoModel.Grupo = Grupo;
                    codigoModel.Subgrupo = Subgrupo;
                    codigoModel.Elemento = tbxCodigoElemento.Text;
                    codigoModel.Descripcion = tbxDescripcion.Text;
                    codigoModel.Valor1 = 0;
                    codigoModel.Valor2 = Convert.ToDecimal("0.00");
                    codigoModel.Estado = cbxEstado.SelectedItem.ToString();
                    codigoModel.Usuario = VariablesGlobales.usuario.ToString();
                    codigoModel.Fecha_mod = DateTime.Now.ToString("MM/dd/yyyy", ci);

                    string response = codigoBO.ActualizarParámetro(codigoModel);
                    if (response != "OK")
                    {
                        MessageBox.Show(response, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            if ((cbxFiltroParametro.SelectedItem != null) || (cbxFiltroEstado.SelectedItem != null))
            {
                this.btnFiltrar_Click(null, null);
            }
            else
            {
                LoadInformation();
            }
            
        }
    }
}
