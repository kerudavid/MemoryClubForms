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
using static MemoryClubForms.BusinessBO.ClienteBO;
using System.Globalization;

namespace MemoryClubForms.Forms
{
    public partial class ClienteForm : Form
    {
        CultureInfo ci = new CultureInfo("en-US");

        public int action = 0;//Valida que acción debe realizar el boton de guardar. si insertar o editar, insertar=1 y editar =2

        public int idCliente = 0;

        public int filaSeleccionada = 0;

        public static int sucursalUser = VariablesGlobales.sucursal;

        public static List<CodigosSucursales> codigosSucursalesList = new List<CodigosSucursales>();

        public static List<CodigosEstados> codigosEstadosList = new List<CodigosEstados>();

        public static List<ClienteModel> clienteModelList = new List<ClienteModel>();

        public static List<CodigosGenero> generoList = new List<CodigosGenero>();

        public static List<CodigosMediosPago> medioPagoList = new List<CodigosMediosPago>();

        public static List<ListaTransportistas> transportistaList= new List<ListaTransportistas>();

        public static List<ListaFrecuencias> frecuenciaList = new List<ListaFrecuencias>();

        public static bool actionsInUse = true;

        public ClienteForm()
        {
            InitializeComponent();

            dtmFecha.MinDate = new DateTime(1990, 1, 1);
            dtmFecha.MaxDate = DateTime.Today;

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
                
                grdCliente.Rows.Clear();
                ResetFilterElements();

                ClienteBO clienteBO = new ClienteBO();
                clienteModelList = new List<ClienteModel>();
                List<ClienteModel> clienteList = clienteBO.ConsultaCliente(null,null,null,null,null,0,0,0,0,0,null);

                if (clienteList.Count > 0)
                {
                    clienteModelList = clienteList;
                    foreach (var cliente in clienteList)
                    {
                        // Creamos un objeto DateTime con la fecha de nacimiento de la persona
                        int edad = 0;

                        try
                        {
                            DateTime fechaNacimiento = new DateTime(cliente.Anio_nacim, cliente.Mes_nacim, cliente.Dia_nacim);

                            // Calculamos la edad de la persona a partir de su fecha de nacimiento
                            edad = DateTime.Today.Year - fechaNacimiento.Year;

                            if (DateTime.Today < fechaNacimiento.AddYears(edad))
                            {
                                edad--;
                            }
                        }
                        catch
                        {
                            //Manejo de excepcion
                        }


                        /*
                        string input = cliente.Anio_nacim + "-"+ cliente.Mes_nacim+"-" +cliente.Dia_nacim;

                        //DateTime fechaNacimiento = DateTime.Now;

                        bool isValidDate = DateTime.TryParseExact(input, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fechaNacimiento);
                        int edad = 0;

                        if (isValidDate)
                        {
                            // Calculamos la edad de la persona a partir de su fecha de nacimiento
                            edad = DateTime.Today.Year - fechaNacimiento.Year;

                            if (DateTime.Today < fechaNacimiento.AddYears(edad))
                            {
                                edad--;
                            }
                        }     
                        */                       

                        grdCliente.Rows.Add(
                            cliente.Id_cliente,cliente.Cedula,cliente.Nombre,cliente.Apodo,
                            cliente.Fecha_ingreso, /*cliente.Fecha_free,*/ cliente.Sexo, cliente.Estado, /*cliente.Aula,*/
                            cliente.Dia_nacim,cliente.Mes_nacim,cliente.Anio_nacim,edad, cliente.Telefono, cliente.Direccion, 
                            cliente.Nombre_contacto,cliente.Parentesco_contacto,cliente.Telefono_contacto,
                            cliente.Celular_contacto,/*cliente.Encargado_pago,cliente.Parentesco_pago,
                            cliente.Telefono_pago,cliente.Cedula_pago,*/ 
                            /*cliente.Email_pago,cliente.Medio_pago,cliente.Frecuencia_pago,*/cliente.Pariente_transp,
                            cliente.Toma_transp, cliente.Id_transportista,cliente.Nombre_transportista,cliente.Valor_transporte, cliente.Retirarse_solo, cliente.Nombre_factu,
                            cliente.Cedula_factu,cliente.Direccion_factu, cliente.Celular_pago, cliente.Email_factu,
                            cliente.Sucursal,cliente.Observacion,cliente.Usuario,cliente.Fecha_mod);
                    }
                    grdCliente.ReadOnly = true;
                    Filtros();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar el nombre de los clientes para realizar filtros" + ex, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Filtros()
        {
            try
            {
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
                MessageBox.Show("No se pudo cargar la informacón para realizar filtros, intente recargar la página de nuevo."+ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }

        private void CargarElemFiltros()
        {
            dtmFecha.Value = DateTime.Today;

            foreach (var item in codigosSucursalesList)
            {
                cbxFiltroSucursal.Items.Add(item.Sucursales.ToString());
            }

            foreach (var item in codigosEstadosList)
            {
                cbxFiltroEstadoCliente.Items.Add(item.Estados.ToString());
            }
            cbxFiltroEstadoCliente.Items.Add("TODOS");

            foreach (var item in transportistaList)
            {
                cbxFiltroTransportista.Items.Add(item.Nombre);
            }

            
        }

        private void ResetFilterElements()
        {
            tbxFiltroCedula.Text = "";

            tbxFiltroNombre.Text = "";

            cbxFiltroSucursal.Items.Clear();

            tbxFiltroApodo.Text = "";

            dtmFecha.Value = DateTime.Today;

            ckbFiltrarFechas.Checked = false;

            cbxFiltroEstadoCliente.Items.Clear();

            cbxFiltroTransportista.Items.Clear();


            tbxDia.Text = "";

            tbxMes.Text = "";

            tbxAnio.Text = "";
        }

        private bool LoadSucursales()
        {
            try
            {
                codigosSucursalesList = new List<CodigosSucursales>();
                ClienteBO clienteBO = new ClienteBO();
                codigosSucursalesList = clienteBO.LoadSucursales();
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
                ClienteBO clienteBO = new ClienteBO();
                codigosEstadosList = clienteBO.LoadEstados();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool LoadGenero()
        {
            try
            {
                generoList = new List<CodigosGenero>();
                ClienteBO clienteBO = new ClienteBO();
                generoList = clienteBO.LoadGeneros();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool LoadMediosPago()
        {
            try
            {
                medioPagoList = new List<CodigosMediosPago>();
                ClienteBO clienteBO = new ClienteBO();
                medioPagoList = clienteBO.LoadMediosPago();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool LoadTransportista()
        {
            try
            {
                transportistaList = new List<ListaTransportistas>();
                ClienteBO clienteBO = new ClienteBO();
                transportistaList = clienteBO.TodosTransportistas(); //recupero todos los transportistas
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool LoadFrecuencias()
        {
            try
            {
                frecuenciaList = new List<ListaFrecuencias>();
                ClienteBO clienteBO = new ClienteBO();
                frecuenciaList = clienteBO.LoadFrecuencias();
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

            bool responseGenero = LoadGenero();

            bool responseMedios = LoadMediosPago();

            bool responseFrecuencias = LoadFrecuencias();

            bool responseTransportista = LoadTransportista();

            if (!responseEstados || !responseSucursales || !responseGenero || !responseMedios ||!responseFrecuencias ||!responseTransportista)
            {
                return false;
            }

            return true;
        }

        private void btnReiniciarFiltro_Click(object sender, EventArgs e)
        {
            idCliente = 0;
            lblRegistroSeleccionado.Text = "Ninguno";
            ResetFilterElements();
            LoadInformation();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                ClienteBO clienteBO = new ClienteBO();

                List<ClienteModel> clientesList = new List<ClienteModel>();

                grdCliente.Rows.Clear();

                string cedula = null;

                if (!string.IsNullOrEmpty(tbxFiltroCedula.Text))
                {
                    cedula = tbxFiltroCedula.Text;
                }

                string nombre = null;

                if (!string.IsNullOrEmpty(tbxFiltroNombre.Text))
                {
                    nombre = tbxFiltroNombre.Text;
                }

                int idCliente = clienteModelList.Where(x => x.Nombre == nombre).Select(x => x.Id_cliente).FirstOrDefault();

                string apodo = null;
                if (!string.IsNullOrEmpty(tbxFiltroApodo.Text))
                {
                    apodo = tbxFiltroApodo.Text;
                }

                string fechaIngreso = null;
                if (ckbFiltrarFechas.Checked == true)
                {
                    fechaIngreso = dtmFecha.Value.ToString("MM/dd/yyyy", ci);
                }

                string estado = null;
                string pEstado = null;

                if (cbxFiltroEstadoCliente.SelectedItem != null)
                {
                    estado = cbxFiltroEstadoCliente.SelectedItem.ToString();
                }

                pEstado = codigosEstadosList.Where(x => x.Estados == estado).Select(x => x.Estados).FirstOrDefault();

                int sucursal = 0;
                if (cbxFiltroSucursal.SelectedItem != null)
                {
                    sucursal = int.Parse(cbxFiltroSucursal.SelectedItem.ToString());
                }

                int dia = 0;
                if (!string.IsNullOrEmpty(tbxDia.Text))
                {
                    dia = int.Parse(tbxDia.Text);
                }

                int mes = 0;
                if (!string.IsNullOrEmpty(tbxMes.Text))
                {
                    mes = int.Parse(tbxMes.Text);
                }

                int anio = 0;
                if (!string.IsNullOrEmpty(tbxAnio.Text))
                {
                    anio = int.Parse(tbxAnio.Text);
                }

                string nomreTransp = null;
                if (cbxFiltroTransportista.SelectedItem != null)
                {
                    nomreTransp = cbxFiltroTransportista.SelectedItem.ToString();
                }

                int idTransp = transportistaList.Where(x => x.Nombre == nomreTransp).Select(x => x.Id_transportista).FirstOrDefault();

                string medioPago = null;             

                clientesList = clienteBO.ConsultaCliente(cedula,nombre,apodo,fechaIngreso,pEstado,sucursal,dia,mes,anio,idTransp,medioPago);

                if (clientesList.Count > 0)
                {
                    clienteModelList = clientesList;


                    foreach (var cliente in clientesList)
                    {
                        // Creamos un objeto DateTime con la fecha de nacimiento de la persona
                        DateTime fechaNacimiento = new DateTime(cliente.Anio_nacim, cliente.Mes_nacim, cliente.Dia_nacim);

                        // Calculamos la edad de la persona a partir de su fecha de nacimiento
                        int edad = DateTime.Today.Year - fechaNacimiento.Year;
                        if (DateTime.Today < fechaNacimiento.AddYears(edad))
                        {
                            edad--;
                        }

                        grdCliente.Rows.Add(
                            cliente.Id_cliente, cliente.Cedula, cliente.Nombre, cliente.Apodo,
                            cliente.Fecha_ingreso, /*cliente.Fecha_free,*/ cliente.Sexo, cliente.Estado, /*cliente.Aula,*/
                            cliente.Dia_nacim, cliente.Mes_nacim, cliente.Anio_nacim,edad, cliente.Telefono, cliente.Direccion,
                            cliente.Nombre_contacto, cliente.Parentesco_contacto, cliente.Telefono_contacto,
                            cliente.Celular_contacto, /*cliente.Encargado_pago, cliente.Parentesco_pago,
                            cliente.Telefono_pago, cliente.Cedula_pago, 
                            cliente.Email_pago, cliente.Medio_pago, cliente.Frecuencia_pago, */cliente.Pariente_transp, 
                            cliente.Toma_transp, cliente.Id_transportista, cliente.Nombre_transportista, cliente.Valor_transporte, cliente.Retirarse_solo, cliente.Nombre_factu,
                            cliente.Cedula_factu, cliente.Direccion_factu, cliente.Celular_pago, cliente.Email_factu,
                            cliente.Sucursal, cliente.Observacion, cliente.Usuario, cliente.Fecha_mod);
                    }
                    grdCliente.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                ResetFilterElements();
                LoadInformation();
                MessageBox.Show("Alerta, No se pudo filtrar el registro\n" + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
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

                idCliente = 0;

                //Valida que el clic no sea de los headers
                if (filaSeleccionada != -1)
                {
                    idCliente = int.Parse(grdCliente.Rows[filaSeleccionada].Cells[0].Value.ToString());
                    lblRegistroSeleccionado.Text = grdCliente.Rows[filaSeleccionada].Cells[2].Value.ToString();                 
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
                if (idCliente<=0) //Valida que tenga un item seleccionado del grid
                {
                    return;
                }

                DialogResult response = MessageBox.Show("Está seguro que desea eliminar este elemento?\nSolo hágalo si el cliente acaba de ser creado,\ncaso contrario podría ocasionar errores en el sistema", "Eliminar item seleccionado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (response == DialogResult.Yes)
                {
                    ClienteBO clienteBO = new ClienteBO();
                    ClienteModel clienteModel = new ClienteModel();

                    clienteModel.Id_cliente = idCliente;

                    bool responseDB = clienteBO.EliminarCliente(clienteModel);
                    if (!responseDB)
                    {
                        MessageBox.Show("No se puede eliminar el registro, inténtelo más tarde.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    MessageBox.Show("La información se ha eliminado EXITOSAMENTE!", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadInformation();
                }
            }
            catch (Exception ex)
            {
                LoadInformation();
                MessageBox.Show("No se pudo eliminar el registro, inténtelo más tarde." + ex, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            //Valida que no existan dos ventanas de insert cliente abiertas
            if (VariablesGlobales.OpentInsert)
            {
                return;
            }
            InsertarClienteForm insertarClienteForm = new InsertarClienteForm();
            insertarClienteForm.Show();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                //Valida que no existan dos ventanas de Edit Cliente abiertas
                if (VariablesGlobales.OpenEdit)
                {
                    return;
                }

                if (idCliente <= 0) //Valida que tenga un item seleccionado del grid
                {
                    return;
                }

                ClienteModel clienteModel = new ClienteModel();
                clienteModel = clienteModelList.Where(x => x.Id_cliente == idCliente).FirstOrDefault();
                EditarClienteForm editarClienteForm = new EditarClienteForm(clienteModel);
                editarClienteForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se puede editar  el registro, inténtelo más tarde." + ex, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

        private void btnAlimentos_Click(object sender, EventArgs e)
        {
            if (!VariablesGlobales.OpenAlimentacion)
            {
                AlimentosForm alimentosForm = new AlimentosForm(idCliente);
                alimentosForm.Show();
            }
        }

        private void btnSalud_Click(object sender, EventArgs e)
        {
            if (!VariablesGlobales.OpenSalud)
            {
                SaludForm saludForm = new SaludForm(idCliente);
                saludForm.Show();
            }
        }

        private void ckbFiltrarFechas_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbFiltrarFechas.Checked)
            {
                dtmFecha.Enabled = true;
            }
            else
            {
                dtmFecha.Enabled = false;
            }
        }

        private void grdCliente_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // asegúrate de que la celda esté seleccionada
            {
                DataGridViewCell cell = grdCliente.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell.Value != null & cell.Value.ToString() != "") // asegúrate de que la celda no esté vacía
                {
                    Clipboard.SetText(cell.Value.ToString()); // copia el contenido de la celda al portapapeles
                }
            }
        }

    }
}
