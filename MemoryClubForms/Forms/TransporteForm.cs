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
using static MemoryClubForms.BusinessBO.TransporteBO;

namespace MemoryClubForms.Forms
{
    public partial class TransporteForm : Form
    {
        public int action = 0;//Valida que acción debe realizar el boton de guardar. si insertar o editar, insertar=1 y editar =2

        public int idAsistenciaSelected = 0;

        public int idClienteSelected = 0;

        public int filaSeleccionada = 0;

        public static int sucursalUser = VariablesGlobales.sucursal;

        public static List<NombresClientes> nombresClientesList = new List<NombresClientes>();

        public static List<TiposClientes> tiposClientesList = new List<TiposClientes>();

        public static List<NombresTransportistas> nombresTransportistasList = new List<NombresTransportistas>();

        public static List<CodigosSucursales> codigosSucursalesList = new List<CodigosSucursales>();

        public static List<HorariosTransporte> horariosTransportesList = new List<HorariosTransporte>();

        public static List<NombresColaboradores> nombresColaboradoresList = new List<NombresColaboradores>();

        public static List<CodigosEstados> codigosEstadosList = new List<CodigosEstados>();
        public TransporteForm()
        {
            InitializeComponent();

            dtmFecha.MinDate = new DateTime(1990, 1, 1);
            dtmFecha.MaxDate = DateTime.Today;

            dtpDesde.MinDate = new DateTime(1990, 1, 1);
            dtpDesde.MaxDate = DateTime.Today;

            dtmHasta.MinDate = new DateTime(1990, 1, 1);
            dtmHasta.MaxDate = DateTime.Today;

            LoadInformation();
        }

        private void btnClose_Clicked(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadInformation()
        {
            try
            {
                grdTransporte.Rows.Clear();
                ResetFilterElements();

                TransporteBO transporteBO = new TransporteBO();
                List<TransporteModel> transporteList = transporteBO.ConsultaTransporte(null, null, null, 0, 0, 0, null);

                if (transporteList.Count > 0)
                {


                    foreach (var trasnp in transporteList)
                    {
                        grdTransporte.Rows.Add(trasnp.Id_transporte, trasnp.Fk_id_cliente, trasnp.Nombre, trasnp.Tipo_cliente, trasnp.Fecha, trasnp.Hora,trasnp.Id_transportista,"Nombre Transportista", trasnp.Entrada_salida, trasnp.Observacion, trasnp.Sucursal, trasnp.Usuario, trasnp.Fecha_mod,trasnp.Estado);
                    }
                    grdTransporte.ReadOnly = true;
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
            bool responseClientes = LoadNombresClientes();

            bool responseTipoCliente = LoadTipoCliente();

            bool responseEstados = LoadEstados();

            bool responseSucursales = LoadSucursales();

            bool reponseColaboradores = LoadNombresColaboradores();

            bool responseTransportista = LoadTransportistas();

            bool responseHorariosTransporte = LoadHorariosTransporte();

            if (!responseClientes || !responseTipoCliente || !responseEstados || !responseSucursales || !reponseColaboradores||!responseTransportista||!responseHorariosTransporte)
            {
                return false;
            }

            return true;
        }

        private bool LoadNombresClientes()
        {
            try
            {
                nombresClientesList = new List<NombresClientes>();
                TransporteBO transporteBO = new TransporteBO();
                nombresClientesList = transporteBO.LoadClientes();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool LoadTipoCliente()
        {
            try
            {
                tiposClientesList = new List<TiposClientes>();
                TransporteBO transporteBO = new TransporteBO();
                tiposClientesList = transporteBO.LoadTiposClientes();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool LoadTransportistas()
        {
            try
            {
                nombresTransportistasList = new List<NombresTransportistas>();
                TransporteBO transporteBO = new TransporteBO();
                nombresTransportistasList = transporteBO.LoadNombresTransportistas();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool LoadHorariosTransporte()
        {
            try
            {
                horariosTransportesList = new List<HorariosTransporte>();
                TransporteBO transporteBO = new TransporteBO();
                horariosTransportesList = transporteBO.LoadHorariosTransporte();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool LoadSucursales()
        {
            try
            {
                codigosSucursalesList = new List<CodigosSucursales>();
                TransporteBO transporteBO = new TransporteBO();
                codigosSucursalesList = transporteBO.LoadSucursales();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool LoadNombresColaboradores()
        {
            try
            {
                nombresColaboradoresList = new List<NombresColaboradores>();
                TransporteBO transporteBO = new TransporteBO();
                nombresColaboradoresList = transporteBO.LoadNombresColaboradores();
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
                TransporteBO transporteBO = new TransporteBO();
                codigosEstadosList = transporteBO.LoadEstados();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void CargarElemFiltros()
        {
            foreach (var item in nombresClientesList)
            {
                cbxFiltroNombreCliente.Items.Add(item.nombre);
            }
            foreach (var item in nombresColaboradoresList)
            {
                cbxFiltroNombreCliente.Items.Add(item.nombre);
            }

            foreach (var item in tiposClientesList)
            {
                cbxFiltroTipoCli.Items.Add(item.TipoCliente);
            }

            foreach (var item in horariosTransportesList)
            {
                cbxFiltroHorarios.Items.Add(item.Horario);
            }

            foreach (var item in codigosSucursalesList)
            {
                cbxFiltroSucursal.Items.Add(item.Sucursales.ToString());
            }

            foreach (var item in codigosEstadosList)
            {
                cbxFiltroEstadoCliente.Items.Add(item.Descripcion.ToString());
            }

            foreach (var item in nombresTransportistasList)
            {
                cbxFiltroTransportista.Items.Add(item.Nombre.ToString());
            }

        }

        private void ResetFilterElements()
        {
            cbxFiltroNombreCliente.Items.Clear();

            cbxFiltroTipoCli.Items.Clear();

            cbxFiltroHorarios.Items.Clear();

            cbxFiltroSucursal.Items.Clear();

            cbxFiltroEstadoCliente.Items.Clear();

            cbxFiltroTransportista.Items.Clear();

        }
    }
}
