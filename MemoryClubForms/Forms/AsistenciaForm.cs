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
        }
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
        /// Carga la informacion de la pagina
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AsistenciaForm_Load(object sender, EventArgs e)
        {
            AsistenciaBO asistenciaBO = new AsistenciaBO();
            List<AsistenciaModel> asistenciaList = asistenciaBO.ConsultarPeriodoAsis(this.fechaini, this.fechafin);

            if (asistenciaList.Count > 0)
            {
                asistenciaInfoList = asistenciaList;

                foreach (var asistencia in asistenciaList)
                {
                    grdAsistencia.Rows.Add(asistencia.Id_asistencia, asistencia.Fk_id_cliente,asistencia.Nombre, asistencia.Fecha, asistencia.Hora, asistencia.Observacion, asistencia.Sucursal, asistencia.Usuario, asistencia.Fecha_mod);
                }
                grdAsistencia.ReadOnly = true;
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
        /// Cancela una operacion, sea de insertar o editar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
           
            CleanData();
            ResetElements();
            
            
        }

        /// <summary>
        /// Vuelve a cargar la informacion depues de editar, eliminar o insertar un registro
        /// </summary>
        private void ReloadInformation()
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

        }
        private void btnEdit_Clicked(object sender, EventArgs e)
        {

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
                if (!LoadUsuarios())
                {
                    ResetElements();
                    MessageBox.Show("Aviso, No se pudo cargar el nombre de los usuarios. ");
                    return;
                }

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

        /// <summary>
        /// Consulta y recupera los nombres de los clientes
        /// </summary>
        /// <returns></returns>
        public bool LoadUsuarios()
        {
            try
            {
                nombresUsuariosList = new List<NombresUsuarios>();
                AsistenciaBO asistenciaBO = new AsistenciaBO();
                nombresUsuariosList = asistenciaBO.LoadUsuarios();
                return true;
            }
            catch
            {
                return false;
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
            
            pnlActions.BackColor = Color.FromArgb(255, 255, 255);
            pnlActions.ForeColor = Color.FromArgb(0, 0, 0);

            actionsUse = true;
        }

        /// <summary>
        /// Edita los colores de panels y labels cuando se va a editar o insertar un objeto
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
        }

        /// <summary>
        /// Guarda los cambios efectuados por Insert o Edit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardar_Click(object sender, EventArgs e)
        {         
            if (action == 0)//Valida que se este realizando una accion, sino no ejecutara nada.
            {
                return;
            }

            ResetElements();

            try
            {
                if (action == 1) //Insertar
                {
                    AsistenciaBO asistenciaBO = new AsistenciaBO();
                    AsistenciaModel asistenciaModel = new AsistenciaModel();

                    if (VariablesGlobales.Nivel > 1 && VariablesGlobales.sucursal != int.Parse(cbxSucursal.SelectedItem.ToString()))
                    {
                        MessageBox.Show("Aviso. Su usuario no tiene privilegios necesarios para ingresar asistencias de otra sucursal.");
                        return;
                    }
                    if (cbxNombresClientes.SelectedItem==null)
                    {
                        MessageBox.Show("Aviso. Seleccione el nombre del cliente.");
                        return;
                    }

                    if (cbxSucursal.SelectedItem == null)
                    {
                        MessageBox.Show("Aviso. Seleccione la sucursal.");
                        return;
                    }

                    if (!ValidateHora())
                    {
                        return;
                    }

                    if (txtObservciones.Text.Length > 100)
                    {
                        MessageBox.Show("Aviso. Has superado el númerod e caracteres para Observación. Caracteres máximos: 100");
                        return;
                    }

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
                        MessageBox.Show("Aviso. Ya existe un registro de la misma fecha con el mismo usuario.");
                        return;
                    }

                    bool responseInsert = asistenciaBO.InsertarAsistencia(asistenciaModel);

                    if (!responseInsert) 
                    {
                        MessageBox.Show("Aviso. No se pudo guardar la información, inténtelo más tarde.");
                        return;
                    }

                    ReloadInformation();
                    MessageBox.Show("La información se ha guardado EXITOSAMENTE!");
                    action = 0;
                }
                else
                {
                    action = 0;
                }

                CleanData();
                btnGuardar.Enabled = false;
                btnGuardar.Visible = false;

            }
            catch (Exception ex)
            {
                CleanData();
                btnGuardar.Enabled = false;
                btnGuardar.Visible = false;
                action = 0;
                MessageBox.Show("Alerta, No se pudo guardar el registro\n" + ex.Message);
            }
        }

        private bool ValidateHora()
        {
            if (txtHora.Text.Length > 5 || string.IsNullOrEmpty(txtHora.Text) || txtHora.Text == " " || txtHora.Text == "")
            {
                MessageBox.Show("Aviso. El formato de la hora es 21:00 o 08:15 \nRecuerde que se usa el formato de 24 horas.");
                return false;
            }

            if (!txtHora.Text.Contains(":"))
            {
                MessageBox.Show("Aviso. El formato de la hora es hh:mm Ejemplo: 08:15 \nRecuerde que se usa el formato de 24 horas.");
                return false;
            }

            string horas = txtHora.Text.Split(':')[0];
            string minutos = txtHora.Text.Split(':')[1];
            

            if(horas.Length<2 || horas.Length > 2)
            {
                MessageBox.Show("Aviso. El formato de la hora es hh:mm Ejemplo: 08:15 \nRecuerde que se usa el formato de 24 horas.");
                return false;
            }

            if (minutos.Length < 2 || minutos.Length > 2)
            {
                MessageBox.Show("Aviso. El formato de la hora es hh:mm Ejemplo: 08:15 \nRecuerde que se usa el formato de 24 horas");
                return false;
            }



            if (int.Parse(horas) > 23 || int.Parse(horas) < 0)
            {
                MessageBox.Show("Aviso. Las horas deben ser mayores a 00 y menores a 23, formatos aceptables 00:00 o 23:59");
                return false;
            }

            if (int.Parse(minutos) > 59 || int.Parse(minutos) < 0)
            {
                MessageBox.Show("Aviso. Los minutos deben ser mayores a 00 y menores a 59 , formatos aceptables 00:00 o 23:59");
                return false;
            }
            return true;
        }


    }
}
