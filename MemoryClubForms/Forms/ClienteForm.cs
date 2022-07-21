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

namespace MemoryClubForms.Forms
{
    public partial class ClienteForm : Form
    {

        public int action = 0;//Valida que acción debe realizar el boton de guardar. si insertar o editar, insertar=1 y editar =2

        public int idTransportista = 0;

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
            LoadInformation();
            //OcultarPaneles();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadInformation()
        {/*
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
                        grdCliente.Rows.Add(
                            cliente.Id_cliente,cliente.Cedula,cliente.Nombre,cliente.Apodo,
                            cliente.Fecha_ingreso, cliente.Fecha_free, cliente.Sexo, cliente.Estado,cliente.Aula,
                            cliente.Dia_nacim,cliente.Mes_nacim,cliente.Anio_nacim,cliente.Telefono,
                            cliente.Nombre_contacto,cliente.Parentesco_contacto,cliente.Telefono_contacto,
                            cliente.Celular_contacto,cliente.Encargado_pago,cliente.Parentesco_pago,
                            cliente.Telefono_pago,cliente.Cedula_pago, cliente.Celular_pago,
                            cliente.Email_pago,cliente.Medio_pago,cliente.Pariente_transp,cliente.Direccion,
                            cliente.Toma_transp, cliente.Id_transportista,cliente.Nombre_transportista,cliente.Retirarse_solo, cliente.Nombre_factu,
                            cliente.Cedula_factu,cliente.Direccion_factu, cliente.Email_factu,
                            cliente.Sucursal,cliente.Observacion,cliente.Usuario,cliente.Fecha_mod);
                    }
                    grdCliente.ReadOnly = true;
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
            }*/
        }

    }
}
