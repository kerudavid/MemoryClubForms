using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace MemoryClubForms.Models
{
    /// <summary>
    /// MODELO DE LA CLASE CATERING
    /// </summary>
    public class CateringModel
    {
        public int Id_catering { get; set; }
        public int Fk_id_cliente { get; set; }
        public string Nombre { get; set; }
        public string Tipo_cliente { get; set; }
        public string Tipo_menu { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set;  }
        public string Observacion { get; set; }
        public int Sucursal { get; set; }
        public string Usuario { get; set; }
        public string Fecha_mod { get; set; }
        public string Estado { get; set; }
        public DateTime Fechahora { get; set; }

        CultureInfo ci = new CultureInfo("en-US");

        /// <summary>
        /// VALIDAR DATOS DE CATERING
        /// </summary>
        /// <param name="cateringmodel"></param>
        /// <returns></returns>
        public string Validate(CateringModel cateringmodel)
        {
            string message = string.Empty;
            DateTime hoy = DateTime.Today;
            Boolean x = false;
            string cadena = string.Empty;

            if (cateringmodel.Fk_id_cliente <= 0)
            {
                return "Por favor, debe ingresar un Cliente Válido";
            }
            if (string.IsNullOrEmpty(cateringmodel.Tipo_cliente) || string.IsNullOrWhiteSpace(cateringmodel.Tipo_cliente))
            {
                return "Por favor, debe ingresar Tipo Cliente";
            }
            if (string.IsNullOrEmpty(cateringmodel.Tipo_menu) || string.IsNullOrWhiteSpace(cateringmodel.Tipo_menu))
            {
                return "Por favor, debe ingresar un de Tipo Menú";
            }

            if (string.IsNullOrEmpty(cateringmodel.Fecha) || string.IsNullOrWhiteSpace(cateringmodel.Fecha))
            {
                return "Por favor, debe ingresar Fecha";
            }

            x = Validafecha(cateringmodel.Fecha);
            if (!x)
            {
                return "Por favor, debe ingresar una Fecha Válida";
            }

            DateTime ldt_date = DateTime.ParseExact(cateringmodel.Fecha, "MM/dd/yyyy", ci);
            if (ldt_date > hoy)
            {
                return "Por favor, la Fecha no puede ser mayor a Hoy";
            }

            if (string.IsNullOrEmpty(cateringmodel.Hora) || string.IsNullOrWhiteSpace(cateringmodel.Hora))
            {
                return "Por favor, debe ingresar Hora";
            }

            cadena = "01/01/1900 " + cateringmodel.Hora;
            x = Validafecha(cadena);
            if (!x)
            {
                return "Por favor, debe ingresar una Hora Válida Formato (24hs)";
            }

            if (cateringmodel.Sucursal <= 0)
            {
                return "Por favor, debe ingresar una Sucursal Válida";
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
