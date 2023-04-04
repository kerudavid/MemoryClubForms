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
using System.Globalization;

namespace MemoryClubForms.Forms
{
    public partial class InsertarClienteForm : Form
    {
        CultureInfo ci = new CultureInfo("en-US");
        public static List<ListaTransportistas> listaTransportistas = new List<ListaTransportistas>();
        public static List<CodigosMediosPago> codigosMediosPagoList = new List<CodigosMediosPago>();
        public static List<CodigosGenero> codigosGeneroList = new List<CodigosGenero>();
        public static List<CodigosSucursales> codigosSucursalesList = new List<CodigosSucursales>();
        public static List<CodigosEstados> codigosEstadosList = new List<CodigosEstados>();
        public static List<ListaFrecuencias> frecuenciaList = new List<ListaFrecuencias>();
        public InsertarClienteForm()
        {
            InitializeComponent();
            bool response = LoadInformation();
            if (response)
            {
                ChargueElements();
            }
            else
            {
                MessageBox.Show("No se pudo cargar la informacón para añadir un nuevo elemento, intente recargar la página de nuevo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            VariablesGlobales.OpentInsert = true;
        }

        private void ChargueElements()
        {
            foreach (var item in codigosGeneroList)
            {
                cbxGenero.Items.Add(item.Generos);
            }
            
            foreach (var item in listaTransportistas)
            {
                cbxFiltroTransportista.Items.Add(item.Nombre);
            }
            foreach (var item in codigosSucursalesList)
            {
                cbxFiltroSucursal.Items.Add(item.Sucursales);
            }
            foreach (var item in codigosEstadosList)
            {
                if (item.Descripcion.ToLower() != "inactivo")
                {
                    cbxEstados.Items.Add(item.Descripcion);
                }
                
            }
            foreach (var item in frecuenciaList)
            {
                cbxFrecuenciaPago.Items.Add(item.Frecuencias);
                
            }


            cbxTomaTransp.Items.Add("SI");
            cbxTomaTransp.Items.Add("NO");

            cbxRetiraSolo.Items.Add("SI");
            cbxRetiraSolo.Items.Add("NO");
        }

        public bool LoadInformation()
        {
            bool responseTransportistas = LoadTransportistas();
            bool responseGenero = LoadGenero();
            bool responseMedios = LoadMediosPago();
            bool responseSucursales = LoadSucursales();
            bool responseEstados = LoadEstados();
            bool responseFrecuencia = LoadFrecuenciaPago();

            if (!responseTransportistas||!responseGenero||!responseMedios||!responseSucursales||!responseEstados||!responseFrecuencia)
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

        private bool LoadFrecuenciaPago()
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

        private bool ValidarInformacion()
        {
            if (VariablesGlobales.Nivel > 1)
            {
                MessageBox.Show("Su usuario no tiene privilegios para añadir clientes.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            //Datos Cliente

            //Cedula
            if (string.IsNullOrEmpty(tbxCedula.Text))
            {
                MessageBox.Show("Ingrese la cédula del cliente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (tbxCedula.Text.Length > 20)
            {
                MessageBox.Show("Ha superado el número máximo de caracteres de cédula de.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            //Nombre
            if (string.IsNullOrEmpty(tbxNombre.Text))
            {
                MessageBox.Show("Ingrese el nombre del cliente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (tbxCedula.Text.Length > 60)
            {
                MessageBox.Show("Ha superado el número máximo de caracteres del nombre del cliente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            //Genero
            if (cbxGenero.SelectedItem==null)
            {
                MessageBox.Show("Ingrese el género del cliente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            //Apodo
            if (string.IsNullOrEmpty(tbxApodo.Text))
            {
                MessageBox.Show("Ingrese el apodo del cliente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (tbxCedula.Text.Length > 30)
            {
                MessageBox.Show("Ha superado el número máximo de caracteres del apodo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            //FechaIngreso
            
            if (dtmFecha.Value==null)
            {
                MessageBox.Show("Ingrese la fecha de ingreso.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

            //FrecuenciaPago
            if (cbxFrecuenciaPago.SelectedItem==null)
            {

                MessageBox.Show("Seleccione la Frecuencia de pago", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            VariablesGlobales.OpentInsert = false;
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

                var nombreTransportista = cbxFiltroTransportista.SelectedItem.ToString();

                clienteModel.Cedula = tbxCedula.Text;
                clienteModel.Nombre = tbxNombre.Text;
                clienteModel.Apodo = tbxApodo.Text;
                clienteModel.Fecha_ingreso = dtmFecha.Value.ToString("MM/dd/yyyy", ci);
                if (dtmFechaFree.Enabled)
                {
                    clienteModel.Fecha_free = dtmFechaFree.Value.ToString("MM/dd/yyyy", ci);
                }
                else
                {
                    clienteModel.Fecha_free = null;
                }
                

                if (cbxGenero.SelectedItem != null)
                {
                    clienteModel.Sexo = cbxGenero.SelectedItem.ToString();
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
                clienteModel.Cedula_pago=tbxCedulaPago.Text;
                clienteModel.Celular_pago = tbxCelularPago.Text;
                clienteModel.Email_pago = tbxEmailPago.Text;
                clienteModel.Medio_pago = string.Empty;                            
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
                clienteModel.Fecha_mod = DateTime.Now.ToString("MM/dd/yyyy", ci);

                bool responseInsert = clienteBO.InsertarCliente(clienteModel);

                if (!responseInsert)
                {
                    MessageBox.Show("No se pudo guardar la información, inténtelo más tarde.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                MessageBox.Show("La información se ha guardado EXITOSAMENTE!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Alerta, No se pudo guardar el registro\n" + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
        }

        private void ckbFechaFree_Change(object sender, EventArgs e)
        {
            if (ckbFechaFree.Checked)
            {
                dtmFechaFree.Enabled=true;
            }
            else
            {
                dtmFechaFree.Enabled=false; 
            }
        }

        private void InsertarClienteForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            VariablesGlobales.OpentInsert = false;
        }
    }
}
