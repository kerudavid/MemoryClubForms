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
using static MemoryClubForms.BusinessBO.CalendarioBO;
using MemoryClubForms.Models;
using System.Globalization;


namespace MemoryClubForms.Forms
{
    public partial class InsertarAutomaticCalendarioForm : Form
    {
        CultureInfo ci = new CultureInfo("en-US");

        public static List<PlanesClientes> PlanesClientesList = new List<PlanesClientes>();
        public static List<EstadosCalend> estadosList = new List<EstadosCalend>();
        public static List<TiposPlanes> tiposPlanesList = new List<TiposPlanes>();
        public static List<CalendarioModel> calendarioListComplete = new List<CalendarioModel>();
        public static List<NombresClientes> nombresClientesList = new List<NombresClientes>();

        public InsertarAutomaticCalendarioForm()
        {
            InitializeComponent();
            VariablesGlobales.InsertCalendario = true;
            ValidarInformacionElementos();
        }

        private void InsertarAutomaticCalendarioForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            VariablesGlobales.InsertCalendario = false;
        }

        //carga los planes vigentes
        private bool LoadPlanesClientes()
        {
            try
            {
                PlanesClientesList = new List<PlanesClientes>();
                CalendarioBO calendarioBO = new CalendarioBO();
                PlanesClientesList = calendarioBO.LoadPlanesClientes();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool ValidarInformacionElementos()
        {
            bool responseClientes = LoadPlanesClientes();


            if (!responseClientes)
            {
                return false;
            }

            CargarElemActions();

            return true;
        }

        private bool ValidarInformacion()
        {
            if (VariablesGlobales.Nivel > 1)
            {
                MessageBox.Show("Su usuario no tiene privilegios necesarios para ingresar asistencias de otra sucursal.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (cbxNombresClientes.SelectedItem == null)
            {
                MessageBox.Show("Ingrese el nombre.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (cbxDia1.SelectedItem == null || Convert.ToString(cbxDia1.SelectedItem) == "NINGUNO")
            {
                MessageBox.Show("Debe al menos seleccionar un día de la semana", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            string d1 = cbxDia1.SelectedItem.ToString();
            string d2 = cbxDia2.SelectedItem.ToString();
            string d3 = cbxDia3.SelectedItem.ToString();
            string d4 = cbxDia4.SelectedItem.ToString();
            string d5 = cbxDia5.SelectedItem.ToString();

            if (d1 != "NINGUNO" && d3 != "NINGUNO" && d2 == "NINGUNO")
            {
                MessageBox.Show("Dia 2 no puede ser NINGUNO si ha seleccionado un día para Dia 3", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (d2 != "NINGUNO" && d4 != "NINGUNO" && d3 == "NINGUNO")
            {
                MessageBox.Show("Dia 3 no puede ser NINGUNO si ha seleccionado un día para Dia 4", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (d3 != "NINGUNO" && d5 != "NINGUNO" && d4 == "NINGUNO")
            {
                MessageBox.Show("Dia 4 no puede ser NINGUNO si ha seleccionado un día para Dia 5", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            //
            //valida el orden
            if (d1 == "Martes" && (d2 == "Lunes"))
            {
                MessageBox.Show("Dia 2 no puede ser anterior a Dia 1", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (d1 == "Miercoles" && (d2 == "Lunes" || d2 == "Martes"))
            {
                MessageBox.Show("Dia 2 no puede ser anterior a Dia 1", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (d1 == "Jueves" && (d2 == "Lunes" || d2 == "Martes" || d2 == "Miercoles"))
            {
                MessageBox.Show("Dia 2 no puede ser anterior a Dia 1", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (d1 == "Viernes" && (d2 != "NINGUNO"))
            {
                MessageBox.Show("Es mejor que utilice el método de ingreso manual,\nla semana no puede empezar en viernes ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            //dia2
            if (d2 == "Martes" && (d3 == "Lunes"))
            {
                MessageBox.Show("Dia 3 no puede ser anterior a Dia 2", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (d2 == "Miercoles" && (d3 == "Lunes" || d3 == "Martes"))
            {
                MessageBox.Show("Dia 3 no puede ser anterior a Dia 2", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (d2 == "Jueves" && (d3 == "Lunes" || d3 == "Martes" || d3 == "Miercoles"))
            {
                MessageBox.Show("Dia 3 no puede ser anterior a Dia 2", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (d2 == "Viernes" && (d3 != "NINGUNO"))
            {
                MessageBox.Show("Es mejor que utilice el método de ingreso manual,\nsi la semana no concluye el viernes ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            //dia3
            if (d3 == "Martes" )
            {
                MessageBox.Show("Dia 3 no puede ser Martes, no está ingresando los días en orden", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (d3 == "Miercoles" && (d4 == "Lunes" || d4 == "Martes"))
            {
                MessageBox.Show("Dia 4 no puede ser anterior a Dia 3", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (d3 == "Jueves" && (d4 == "Lunes" || d4 == "Martes" || d4 == "Miercoles"))
            {
                MessageBox.Show("Dia 4 no puede ser anterior a Dia 3", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (d3 == "Viernes" && (d4 != "NINGUNO"))
            {
                MessageBox.Show("Dia 4 no puede ser anterior a Dia 3 ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            //dia4
            if (d4 == "Martes" || d4 == "Miercoles")
            {
                MessageBox.Show("Dia 4 no puede ser Martes o Miércoles,\n no está ingresando los días en orden", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (d4 == "Jueves" && (d5 == "Lunes" || d5 == "Martes" || d5 == "Miercoles"))
            {
                MessageBox.Show("Dia 5 no puede ser anterior a Dia 4", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (d4 == "Viernes" && (d5 != "NINGUNO"))
            {
                MessageBox.Show("Dia 5 no puede ser anterior a Dia 4 ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            //dia 5
            if (d5 == "Lunes" || d5 ==  "Martes" || d5 == "Miercoles" || d5 == "Jueves")
            {
                MessageBox.Show("Dia 5 no puede estar entre Lunes y Jueves,\n no está ingresando los días en orden", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            //para la siguiente validación
            if (d1 == "NINGUNO")
            { d1 = "1"; }

            if (d2 == "NINGUNO")
            { d2 = "2"; }

            if (d3 == "NINGUNO")
            { d3 = "3"; }

            if (d4 == "NINGUNO")
            { d4 = "4"; }

            if (d5 == "NINGUNO")
            { d5 = "5"; }

            //valida que no haya escogido el mismo día más de una vez
            if (d1 == d2 || d1 == d3 || d1 == d4 || d1 == d5 || d2 == d3 || d2 == d4 || d2 == d5 || d3 == d4 || d3 == d5 || d4 == d5)
            {
                MessageBox.Show("Los días de la semana seleccionados no se pueden repetir", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }

        private void CargarElemActions()
        {
            foreach (var item in PlanesClientesList)
            {
                cbxNombresClientes.Items.Add(item.Nombres);
            }


            cbxDia1.Items.Add("Lunes");
            cbxDia1.Items.Add("Martes");
            cbxDia1.Items.Add("Miercoles");
            cbxDia1.Items.Add("Jueves");
            cbxDia1.Items.Add("Viernes");
            cbxDia1.Items.Add("NINGUNO");

            cbxDia2.Items.Add("Lunes");
            cbxDia2.Items.Add("Martes");
            cbxDia2.Items.Add("Miercoles");
            cbxDia2.Items.Add("Jueves");
            cbxDia2.Items.Add("Viernes");
            cbxDia2.Items.Add("NINGUNO");

            cbxDia3.Items.Add("Lunes");
            cbxDia3.Items.Add("Martes");
            cbxDia3.Items.Add("Miercoles");
            cbxDia3.Items.Add("Jueves");
            cbxDia3.Items.Add("Viernes");
            cbxDia3.Items.Add("NINGUNO");

            cbxDia4.Items.Add("Lunes");
            cbxDia4.Items.Add("Martes");
            cbxDia4.Items.Add("Miercoles");
            cbxDia4.Items.Add("Jueves");
            cbxDia4.Items.Add("Viernes");
            cbxDia4.Items.Add("NINGUNO");

            cbxDia5.Items.Add("Lunes");
            cbxDia5.Items.Add("Martes");
            cbxDia5.Items.Add("Miercoles");
            cbxDia5.Items.Add("Jueves");
            cbxDia5.Items.Add("Viernes");
            cbxDia5.Items.Add("NINGUNO");

            cbxDia1.SelectedIndex = 5;
            cbxDia2.SelectedIndex = 5;
            cbxDia3.SelectedIndex = 5;
            cbxDia4.SelectedIndex = 5;
            cbxDia5.SelectedIndex = 5;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarInformacion())
                {
                    return;
                }
                int Pid_plan = 0;
                int Pid_cliente = 0;
                string Pdia1 = "";
                string Pdia2 = "";
                string Pdia3 = "";
                string Pdia4 = "";
                string Pdia5 = "";


                CalendarioBO calendarioBO = new CalendarioBO();

                var nombreCliente = cbxNombresClientes.SelectedItem.ToString();

                Pid_cliente = PlanesClientesList.Where(x => x.Nombres == nombreCliente).FirstOrDefault().Idcliente;
                Pid_plan = PlanesClientesList.Where(x => x.Nombres == nombreCliente).FirstOrDefault().Idplan;
                Pdia1 = cbxDia1.SelectedItem.ToString();
                Pdia2 = cbxDia2.SelectedItem.ToString();
                Pdia3 = cbxDia3.SelectedItem.ToString();
                Pdia4 = cbxDia4.SelectedItem.ToString();
                Pdia5 = cbxDia5.SelectedItem.ToString();


                string msg = calendarioBO.InsertarAutomatico(Pid_plan, Pid_cliente, Pdia1, Pdia2, Pdia3, Pdia4, Pdia5);

                if (msg.ToLower() != "ok")
                {
                    MessageBox.Show("No se pudo guardar la información.\n " + msg, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                MessageBox.Show("La información se ha guardado EXITOSAMENTE!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                CleanData();
                MessageBox.Show("Alerta, No se pudo guardar el registro\n" + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            btnGuardar.Enabled = false;
        }

        private void CleanData()
        {
            cbxNombresClientes.Items.Clear();//Limpia los valores que pueda tene
            cbxNombresClientes.Text = "";

            cbxTipoPlan.Items.Clear();//Limpia los valores que pueda tene
            cbxTipoPlan.Text = "";

            cbxDia1.Items.Clear();
            cbxDia1.Text = "";

            cbxDia2.Items.Clear();
            cbxDia2.Text = "";
            cbxDia3.Items.Clear();
            cbxDia3.Text = "";
            cbxDia4.Items.Clear();
            cbxDia4.Text = "";
            cbxDia5.Items.Clear();
            cbxDia5.Text = "";

            cbxDia1.Enabled = false;
            cbxDia2.Enabled = false;
            cbxDia3.Enabled = false;
            cbxDia4.Enabled = false;
            cbxDia5.Enabled = false;
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            VariablesGlobales.InsertCalendario = false;
        }

        //pone el id del plan a partir del combo box en donde selecciona el cliente
        private void cbxNombresClientes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string nomcliente = Convert.ToString(cbxNombresClientes.SelectedItem);
            int idplan = PlanesClientesList.Where(x => x.Nombres == nomcliente).Select(x => x.Idplan).FirstOrDefault();
            string idplan_s = Convert.ToString(idplan);
            var fechaplan = PlanesClientesList.Where(x => x.Nombres == nomcliente).Select(x => x.Fecha_ini_plan).FirstOrDefault();
            DateTime fechaux = Convert.ToDateTime(fechaplan, ci);
            string diasemana = "";

            if (fechaux.DayOfWeek == DayOfWeek.Monday)
            {
                diasemana = "Lunes";
            }
            if (fechaux.DayOfWeek == DayOfWeek.Tuesday)
            {
                diasemana = "Martes";
            }
            if (fechaux.DayOfWeek == DayOfWeek.Wednesday)
            {
                diasemana = "Miercoles";
            }
            if (fechaux.DayOfWeek == DayOfWeek.Thursday)
            {
                diasemana = "Jueves";
            }
            if (fechaux.DayOfWeek == DayOfWeek.Friday)
            {
                diasemana = "Viernes";
            }

            cbxTipoPlan.Items.Clear();
            cbxTipoPlan.SelectedItem = (string)idplan_s;
            cbxTipoPlan.Items.Add((string)idplan_s);
            cbxTipoPlan.Text = (string)idplan_s;

            cbxDia1.Items.Clear();
            cbxDia1.SelectedItem = (string)diasemana;
            cbxDia1.Items.Add((string)diasemana);
            cbxDia1.Text = (string)diasemana;

            txbFechaini.Text = fechaplan;
            cbxDia2.Enabled = true;

        }


        private void cbxDia2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cbxDia3.Enabled = true;
        }

        private void cbxDia3_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cbxDia4.Enabled = true;
        }

        private void cbxDia4_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cbxDia5.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CleanData();
            CargarElemActions();
        }

     
    }
}
