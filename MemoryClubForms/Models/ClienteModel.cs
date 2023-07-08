using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace MemoryClubForms.Models
{
    //List Model de Cliente
    public class ClienteModel
    {
        CultureInfo ci = new CultureInfo("en-US");
        public int Id_cliente { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apodo { get; set; }
        public string Fecha_ingreso { get; set; }
        public string Fecha_free { get; set; }
        public string Sexo { get; set; }
        public string Estado { get; set; }
        public int Aula { get; set; }
        public int Dia_nacim { get; set; }
        public int Mes_nacim { get; set; }
        public int Anio_nacim { get; set; }
        public string Telefono { get; set; }
        public string Nombre_contacto { get; set; }
        public string Parentesco_contacto { get; set; }
        public string Telefono_contacto { get; set; }
        public string Celular_contacto { get; set; }
        public string Encargado_pago { get; set; }
        public string Parentesco_pago { get; set; }
        public string Telefono_pago { get; set; }
        public string Cedula_pago { get; set; }
        public string Celular_pago { get; set; }
        public string Email_pago { get; set; }
        public string Medio_pago { get; set; }
        public string Frecuencia_pago { get; set; }
        public string Pariente_transp { get; set; }
        public string Direccion { get; set; }
        public string Toma_transp { get; set; }
        public int Id_transportista { get; set; }
        public string Nombre_transportista { get; set; }
        public string Retirarse_solo { get; set; }
        public string Nombre_factu { get; set; }
        public string Cedula_factu { get; set; }
        public string Direccion_factu { get; set; }
        public string Email_factu { get; set; }
        public int Sucursal { get; set; }
        public string Observacion { get; set; }
        public string Usuario { get; set; }
        public string Fecha_mod { get; set; }
        public DateTime Fechaing { get; set; }
        public decimal Valor_transporte { get; set; }

        /// <summary>
        /// Valida los campos que no pueden ser nulos
        /// </summary>
        /// <param name="clientemodel"></param>
        /// <returns></returns>
        public string Validate(ClienteModel clientemodel)
        {
            string message = string.Empty;
            DateTime hoy = DateTime.Today;
            Boolean x = false;
            string cadena = string.Empty;

            if (string.IsNullOrEmpty(clientemodel.Cedula))
            {
                return "Por favor, debe ingresar un Número de Cédula";
            }
            if (string.IsNullOrEmpty(clientemodel.Nombre) || string.IsNullOrWhiteSpace(clientemodel.Nombre))
            {
                return "Por favor, debe ingresar Nombre de Cliente";
            }
            if (string.IsNullOrEmpty(clientemodel.Apodo) || string.IsNullOrWhiteSpace(clientemodel.Apodo))
            {
                return "Por favor, debe ingresar Apodo";
            }
            if (string.IsNullOrEmpty(clientemodel.Sexo) || string.IsNullOrWhiteSpace(clientemodel.Sexo))
            {
                return "Por favor, debe ingresar sexo del cliente";
            }
            if (clientemodel.Id_transportista <= 0)
            {
                return "Por favor, debe ingresar Id Transportista";
            }

            if (string.IsNullOrEmpty(clientemodel.Estado) || string.IsNullOrWhiteSpace(clientemodel.Estado))
            {
                return "Por favor, debe ingresar Estado";
            }
            if (clientemodel.Sucursal <= 0)
            {
                return "Por favor, debe ingresar la Sucursal";
            }

            if (string.IsNullOrEmpty(clientemodel.Fecha_ingreso) || string.IsNullOrWhiteSpace(clientemodel.Fecha_ingreso))
            {
                return "Por favor, debe ingresar Fecha de Ingreso del Cliente";
            }

            x = Validafecha(clientemodel.Fecha_ingreso);
            if (!x)
            {
                return "Por favor, debe ingresar una Fecha de Ingreso Válida";
            }

            DateTime ldt_date = DateTime.ParseExact(clientemodel.Fecha_ingreso, "MM/dd/yyyy", ci);
            if (ldt_date > hoy)
            {
                return "Por favor, la Fecha de Ingreso no puede ser mayor a Hoy";
            }

            if (Valor_transporte < 0)
            {
                Valor_transporte = 0;
            }
                                             
            return message;

        }
        /// <summary>
        /// METODO PARA VALIDAR LA FECHA /  HORA
        /// </summary>
        /// <param name="pfecha"></param>
        /// <returns></returns>
        private Boolean Validafecha(String pfecha)
        {
            try
            {
                DateTime.Parse(pfecha, ci);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
