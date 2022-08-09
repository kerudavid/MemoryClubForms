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
using static MemoryClubForms.BusinessBO.ClienteBO;

namespace MemoryClubForms.Forms
{
    public partial class EditarClienteForm : Form
    {
        public static List<ListaTransportistas> listaTransportistas = new List<ListaTransportistas>();
        public static List<CodigosMediosPago> codigosMediosPagoList = new List<CodigosMediosPago>();
        public static List<CodigosGenero> codigosGeneroList = new List<CodigosGenero>();
        public static List<CodigosSucursales> codigosSucursalesList = new List<CodigosSucursales>();
        public static List<CodigosEstados> codigosEstadosList = new List<CodigosEstados>();
        public static ClienteModel ClienteModelStatic = new ClienteModel();
        public static List<ListaFrecuencias> frecuenciaList = new List<ListaFrecuencias>();

        public EditarClienteForm(ClienteModel clienteModel)
        {
            InitializeComponent();

            if (clienteModel != null)
            {
                ClienteModelStatic = clienteModel;
            }

            bool response = LoadInformation();
            if (response)
            {
                ChargueElements();
            }
            else
            {
                MessageBox.Show("No se pudo cargar la informacón para añadir un nuevo elemento, intente recargar la página de nuevo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            VariablesGlobales.OpenEdit = true;
        }

        private void ChargueElements()
        {
            tbxApodo.Text = ClienteModelStatic.Apodo;

            if (!string.IsNullOrEmpty(ClienteModelStatic.Fecha_free))
            {
                DateTime date = DateTime.ParseExact(ClienteModelStatic.Fecha_free, "dd/MM/yyyy", null);
                dtmFechaFree.Value = date;
            }

            foreach (var item in codigosEstadosList)
            {

                cbxEstados.Items.Add(item.Descripcion);
                cbxEstados.SelectedItem = codigosEstadosList.Where(x=>x.Estados== ClienteModelStatic.Estado).Select(x=>x.Descripcion).FirstOrDefault().ToString();
                cbxEstados.Text = codigosEstadosList.Where(x => x.Estados == ClienteModelStatic.Estado).Select(x => x.Descripcion).FirstOrDefault().ToString();

            }

            tbxAula.Text = ClienteModelStatic.Aula.ToString();

            tbxDia.Text=ClienteModelStatic.Dia_nacim.ToString();

            tbxMes.Text = ClienteModelStatic.Mes_nacim.ToString();

            tbxAnio.Text = ClienteModelStatic.Anio_nacim.ToString();

            tbxTelefono.Text = ClienteModelStatic.Telefono;

            foreach (var item in codigosSucursalesList)
            {

                cbxFiltroSucursal.Items.Add(item.Sucursales);
                cbxFiltroSucursal.SelectedItem = ClienteModelStatic.Sucursal;
                cbxFiltroSucursal.Text = ClienteModelStatic.Sucursal.ToString();
            }

            tbxDireccion.Text = ClienteModelStatic.Direccion;

            tbxObseraciones.Text = ClienteModelStatic.Observacion;

            tbxNombreContacto.Text = ClienteModelStatic.Nombre_contacto;

            tbxParentescoCto.Text = ClienteModelStatic.Parentesco_contacto;

            tbxTelefonoCto.Text = ClienteModelStatic.Telefono_contacto;

            tbxCelularCto.Text = ClienteModelStatic.Celular_contacto;

            tbxEncargadoPago.Text = ClienteModelStatic.Encargado_pago;

            tbxParentescoPago.Text = ClienteModelStatic.Parentesco_pago;

            tbxTelefonoPago.Text = ClienteModelStatic.Telefono_pago;

            tbxCedulaPago.Text = ClienteModelStatic.Celular_pago;

            tbxEmailPago.Text = ClienteModelStatic.Email_pago;

            foreach (var item in codigosMediosPagoList)
            {

                cbxFiltroMedioPago.Items.Add(item.Mediospago);
                cbxFiltroMedioPago.SelectedItem = ClienteModelStatic.Medio_pago;
                cbxFiltroMedioPago.Text = ClienteModelStatic.Medio_pago.ToString();


            }

            foreach (var item in frecuenciaList)
            {

                cbxFrecuenciaPago.Items.Add(item.Frecuencias);
                cbxFrecuenciaPago.SelectedItem = frecuenciaList.Where(x => x.Frecuencias == item.Frecuencias).FirstOrDefault().Frecuencias;
                cbxFrecuenciaPago.Text = frecuenciaList.Where(x => x.Frecuencias == item.Frecuencias).FirstOrDefault().Frecuencias;
            }

            tbxParienteTransp.Text = ClienteModelStatic.Pariente_transp;

            cbxTomaTransp.Items.Add("SI");
            cbxTomaTransp.Items.Add("NO");
            cbxTomaTransp.SelectedItem = ClienteModelStatic.Toma_transp;
            cbxTomaTransp.Text = ClienteModelStatic.Toma_transp.ToString();

            foreach (var item in listaTransportistas)
            {

                cbxFiltroTransportista.Items.Add(item.Nombre);
                cbxFiltroTransportista.SelectedItem = listaTransportistas.Where(x => x.Id_transportista == ClienteModelStatic.Id_transportista).Select(x => x.Nombre).FirstOrDefault().ToString();
                cbxFiltroTransportista.Text = listaTransportistas.Where(x => x.Id_transportista == ClienteModelStatic.Id_transportista).Select(x => x.Nombre).FirstOrDefault().ToString();
            }

            cbxRetiraSolo.Items.Add("SI");
            cbxRetiraSolo.Items.Add("NO");
            cbxRetiraSolo.SelectedItem = ClienteModelStatic.Retirarse_solo;
            cbxRetiraSolo.Text = ClienteModelStatic.Retirarse_solo.ToString();

            tbxNombreFactura.Text = ClienteModelStatic.Nombre_factu;

            tbxCedulaFactura.Text = ClienteModelStatic.Cedula_factu;

            tbxDireccionFactura.Text = ClienteModelStatic.Direccion_factu;
        }

        public bool LoadInformation()
        {
            bool responseTransportistas = LoadTransportistas();
            bool responseGenero = LoadGenero();
            bool responseMedios = LoadMediosPago();
            bool responseSucursales = LoadSucursales();
            bool responseEstados = LoadEstados();
            bool responseFrecuencia = LoadFrecuenciasPago();

            if (!responseTransportistas || !responseGenero || !responseMedios || !responseSucursales || !responseEstados ||!responseFrecuencia)
            {
                return false;
            }
            return true;
        }

        private bool LoadTransportistas()
        {
            try
            {
                listaTransportistas = new List<ListaTransportistas>();
                ClienteBO clienteBO = new ClienteBO();
                listaTransportistas = clienteBO.LoadTransportistas();
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
                codigosGeneroList = new List<CodigosGenero>();
                ClienteBO clienteBO = new ClienteBO();
                codigosGeneroList = clienteBO.LoadGeneros();
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
                ClienteBO clienteBO = new ClienteBO();
                codigosSucursalesList = clienteBO.LoadSucursales();
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
                codigosMediosPagoList = new List<CodigosMediosPago>();
                ClienteBO clienteBO = new ClienteBO();
                codigosMediosPagoList = clienteBO.LoadMediosPago();
                return true;
            }
            catch
            {
                return false;
            }

        }

        private bool LoadFrecuenciasPago()
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            VariablesGlobales.OpenEdit = false;
        }

        private bool ValidarInformacion()
        {
            if (VariablesGlobales.Nivel > 1)
            {
                MessageBox.Show("Su usuario no tiene privilegios necesarios para ingresar asistencias de otra sucursal.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            //Datos Cliente

            //Apodo
            if (string.IsNullOrEmpty(tbxApodo.Text))
            {
                MessageBox.Show("Ingrese el apodo del cliente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
           
            //Aula
            if (!string.IsNullOrEmpty(tbxAula.Text))
            {
                try
                {
                    if (int.Parse(tbxAula.Text) < 0)
                    {
                        MessageBox.Show("Ingrese un número de aula válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ingrese un número de aula válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
               
            
            if (!string.IsNullOrEmpty(tbxDia.Text))
            {
                //Dia
                try
                {
                    if (int.Parse(tbxDia.Text) <= 0 || int.Parse(tbxDia.Text) > 31)
                    {
                        MessageBox.Show("Ingrese un día válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ingrese un día válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }

            if (!string.IsNullOrEmpty(tbxMes.Text))
            {
                try
                {
                    if (int.Parse(tbxMes.Text) <= 0 || int.Parse(tbxMes.Text) > 12)
                    {
                        MessageBox.Show("Ingrese un Mes válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ingrese un Mes válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            //Mes


            //Anio
            if (!string.IsNullOrEmpty(tbxAnio.Text))
            {
                try
                {
                    if (int.Parse(tbxAnio.Text) <= 0 || int.Parse(tbxAnio.Text) > DateTime.Today.Year)
                    {
                        MessageBox.Show("Ingrese un Año válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ingrese un Año válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
                

            //Estado
            if (cbxEstados.SelectedItem==null)
            {
                MessageBox.Show("Ingrese el Estado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (!string.IsNullOrEmpty(tbxDireccion.Text))
            {
                //Direccion
                if (tbxDireccion.Text.Length > 100)
                {
                    MessageBox.Show("Ha superado el número máximo de caracteres en dirección del cliente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }


            //telefono
            if (!string.IsNullOrEmpty(tbxTelefono.Text))
               
            {
                if (tbxTelefono.Text.Length > 50)
                {
                    MessageBox.Show("Ha superado el número máximo de caracteres en el teléfono del cliente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                    
            }

            //Sucursal
            if (cbxFiltroSucursal.SelectedItem == null)
            {
                MessageBox.Show("Seleccione una sucursal", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }


            //Contacto
            //NombreContacto
            if (!string.IsNullOrEmpty(tbxNombreContacto.Text))
            {
                if (tbxNombreContacto.Text.Length > 40)
                {
                    MessageBox.Show("Ha superado el número máximo de caracteres en Nombre Contacto", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }


            //ParentescoContacto
            if (!string.IsNullOrEmpty(tbxParentescoCto.Text))
            {
                if (tbxParentescoCto.Text.Length > 20)
                {
                    MessageBox.Show("Ha superado el número máximo de caracteres en Parentesco Contacto", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }


            //TelefonoContacto
            if (!string.IsNullOrEmpty(tbxTelefonoCto.Text))
            {
                if (tbxTelefonoCto.Text.Length > 50)
                {
                    MessageBox.Show("Ha superado el número máximo de caracteres en Teléfono Contacto", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }


            //CelularContacto
            if (!string.IsNullOrEmpty(tbxCelularCto.Text))
            {
                if (tbxCelularCto.Text.Length > 50)
                {
                    MessageBox.Show("Ha superado el número máximo de caracteres en Celular Contacto", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }


            //Pago
            //EncargadoPago
            if (!string.IsNullOrEmpty(tbxEncargadoPago.Text))
            {
                if (tbxEncargadoPago.Text.Length > 40)
                {
                    MessageBox.Show("Ha superado el número máximo de caracteres en Encargado pago", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }


            //ParentescoPago
            if (!string.IsNullOrEmpty(tbxParentescoPago.Text))
            {
                if (tbxParentescoPago.Text.Length > 20)
                {
                    MessageBox.Show("Ha superado el número máximo de caracteres en Parentesco pago", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }


            //ParentescoPago
            if (!string.IsNullOrEmpty(tbxTelefonoPago.Text))
            {
                if (tbxTelefonoPago.Text.Length > 50)
                {
                    MessageBox.Show("Ha superado el número máximo de caracteres en Teléfono pago", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }


            //CedulaPago
            if (!string.IsNullOrEmpty(tbxCedulaPago.Text))
            {
                if (tbxCedulaPago.Text.Length > 20)
                {
                    MessageBox.Show("Ha superado el número máximo de caracteres en Cédula pago", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }


            //CelularPago
            if (!string.IsNullOrEmpty(tbxCelularPago.Text))
            {
                if (tbxCelularPago.Text.Length > 50)
                {
                    MessageBox.Show("Ha superado el número máximo de caracteres en Celular pago", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }


            //EmailPago
            if (!string.IsNullOrEmpty(tbxEmailPago.Text))
            {
                if (tbxEmailPago.Text.Length > 50)
                {
                    MessageBox.Show("Ha superado el número máximo de caracteres en Email pago", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }


            //MedioPago
            if (!string.IsNullOrEmpty(cbxFiltroMedioPago.Text))
            {
                if (cbxFiltroMedioPago.SelectedItem == null)
                {
                    MessageBox.Show("Seleccione un medio de pago", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }


            //FrecuenciaPago
            if (cbxFrecuenciaPago.SelectedItem==null)
            {

                MessageBox.Show("Ha superado el número máximo de caracteres en Frecuencia pago", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
                
            }


            //Transporte
            //ParienteTransporte
            if (!string.IsNullOrEmpty(tbxParienteTransp.Text))
            {
                if (tbxParienteTransp.Text.Length > 50)
                {
                    MessageBox.Show("Ha superado el número máximo de caracteres en Pariente  transporte", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
                

            //ParienteTransporte
            if (cbxFiltroTransportista.SelectedItem==null)
            {
                MessageBox.Show("Seleccione el Transportista, en caso de que el cliente sea transportado por un tercero, seleccione Otros", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            //Facturacion
            //nombreFactura
            if (!string.IsNullOrEmpty(tbxNombreFactura.Text))
            {
                if (tbxNombreFactura.Text.Length > 60)
                {
                    MessageBox.Show("Ha superado el número máximo de caracteres en Nombre Factura", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }


            //cedulaFactura
            if (!string.IsNullOrEmpty(tbxCedulaFactura.Text))
            {
                if (tbxCedulaFactura.Text.Length > 20)
                {
                    MessageBox.Show("Ha superado el número máximo de caracteres en Cédula Factura", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }


            //direccionFactura

            if (tbxDireccionFactura.Text.Length > 80)
            {
                MessageBox.Show("Ha superado el número máximo de caracteres en Dirección Factura", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            


            //emailFactura

            if (tbxEmailFactura.Text.Length > 100)
            {
                MessageBox.Show("Ha superado el número máximo de caracteres en Email Factura", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

                

            //Observacion
            if (tbxObseraciones.Text.Length > 100)
            {
                MessageBox.Show("Ha superado el número máximo de caracteres en Observación", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }


            return true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                if (!ValidarInformacion())
                {
                    return;
                }

                ClienteBO clienteBO = new ClienteBO();
                ClienteModel clienteModel = new ClienteModel();
                clienteModel = ClienteModelStatic;
                var nombreTransportista = cbxFiltroTransportista.SelectedItem.ToString();


                clienteModel.Apodo = tbxApodo.Text;

                if (dtmFechaFree.Enabled)
                {
                    clienteModel.Fecha_free = dtmFechaFree.Value.ToString("dd/MM/yyyy");
                }
                else
                {
                    clienteModel.Fecha_free = null;
                }

                clienteModel.Estado = codigosEstadosList.Where(x => x.Descripcion == cbxEstados.SelectedItem.ToString()).Select(x => x.Estados).FirstOrDefault();

                if (!string.IsNullOrEmpty(tbxAula.Text))
                {
                    clienteModel.Aula = int.Parse(tbxAula.Text);
                }

                if (!string.IsNullOrEmpty(tbxDia.Text))
                {
                    clienteModel.Dia_nacim = int.Parse(tbxDia.Text);
                }

                if (!string.IsNullOrEmpty(tbxMes.Text))
                {
                    clienteModel.Mes_nacim = int.Parse(tbxMes.Text);
                }

                if (!string.IsNullOrEmpty(tbxAnio.Text))
                {
                    clienteModel.Anio_nacim = int.Parse(tbxAnio.Text);
                }


                clienteModel.Telefono = tbxTelefono.Text;
                clienteModel.Nombre_contacto = tbxNombreContacto.Text;
                clienteModel.Parentesco_contacto = tbxParentescoCto.Text;
                clienteModel.Telefono_contacto = tbxTelefonoCto.Text;
                clienteModel.Celular_contacto = tbxCelularCto.Text;
                clienteModel.Encargado_pago = tbxEncargadoPago.Text;
                clienteModel.Parentesco_pago = tbxParentescoPago.Text;
                clienteModel.Telefono_pago = tbxTelefonoPago.Text;
                clienteModel.Cedula_pago = tbxCedulaPago.Text;
                clienteModel.Celular_pago = tbxCelularPago.Text;
                clienteModel.Email_pago = tbxEmailPago.Text;

                if (cbxFiltroMedioPago.SelectedItem != null)
                {
                    clienteModel.Medio_pago = cbxFiltroMedioPago.SelectedItem.ToString();
                }

                clienteModel.Frecuencia_pago = cbxFrecuenciaPago.SelectedItem.ToString();
                clienteModel.Pariente_transp = tbxParienteTransp.Text;
                clienteModel.Direccion = tbxDireccion.Text;

                if (cbxTomaTransp.SelectedItem != null)
                {
                    clienteModel.Toma_transp = cbxTomaTransp.SelectedItem.ToString();
                }

                clienteModel.Id_transportista = listaTransportistas.Where(x => x.Nombre == cbxFiltroTransportista.SelectedItem.ToString()).Select(x => x.Id_transportista).FirstOrDefault();

                if (cbxRetiraSolo.SelectedItem != null)
                {
                    clienteModel.Retirarse_solo = cbxRetiraSolo.SelectedItem.ToString();
                }

                clienteModel.Nombre_factu = tbxNombreFactura.Text;
                clienteModel.Cedula_factu = tbxCedulaFactura.Text;
                clienteModel.Direccion_factu = tbxDireccionFactura.Text;
                clienteModel.Email_factu = tbxDireccionFactura.Text;

                if (cbxFiltroSucursal.SelectedItem != null)
                {
                    clienteModel.Sucursal = int.Parse(cbxFiltroSucursal.SelectedItem.ToString());
                }

                clienteModel.Observacion = tbxObseraciones.Text;
                clienteModel.Usuario = VariablesGlobales.usuario.ToString();
                clienteModel.Fecha_mod = DateTime.Now.ToString("dd/MM/yyyy");

                bool responseInsert = clienteBO.ActualizarCliente(clienteModel);

                if (!responseInsert)
                {
                    MessageBox.Show("No se pudo guardar la información, inténtelo más tarde.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                MessageBox.Show("La información se ha guardado EXITOSAMENTE!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);




            }
            catch (Exception ex)
            {
                MessageBox.Show("Alerta, No se pudo guardar el registro\n" + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void FechaFree_Change(object sender, EventArgs e)
        {
            if (ckbFechaFree.Checked)
            {
                dtmFechaFree.Enabled = true;
            }
            else
            {
                dtmFechaFree.Enabled = false;
            }
        }

        private void EditarClienteForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            VariablesGlobales.OpenEdit = false;
        }
    }
}
