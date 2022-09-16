using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace MemoryClubForms.Models
{   
    //List Model del Calendario
    public class CalendarioModel
    {
        public int Id_calendario { get; set; }
        public int Fk_id_plan { get; set; }
        public int Fk_id_cliente { get; set; }
        public string Nombre { get; set; }
        public string Fecha { get; set; }
        public string Estado { get; set; }
        public string Usuario { get; set; }
        public string Fecha_mod { get; set; }

        CultureInfo ci = new CultureInfo("en-US");

        public string Validate(CalendarioModel calendarioModel)
        {
            string message = string.Empty;
            DateTime hoy = DateTime.Today;
            Boolean x = false;
            string cadena = string.Empty;

            if (calendarioModel.Fk_id_plan <= 0)
            {
                return "Por favor, debe ingresar Número de Plan";
            }
            if (calendarioModel.Fk_id_cliente <= 0)
            {
                return "Por favor, debe ingresar un Cliente Válido";
            }
 
            if (string.IsNullOrEmpty(calendarioModel.Fecha) || string.IsNullOrWhiteSpace(calendarioModel.Fecha))
            {
                return "Por favor, debe ingresar Fecha";
            }
            x = Validafecha(calendarioModel.Fecha);
            if (!x)
            {
                return "Por favor, debe ingresar una Fecha Válida";
            }

            //en el calendario las fechas si deben ser mayores a hoy porque es una planificación

            /*DateTime ldt_date = DateTime.ParseExact(calendarioModel.Fecha, "dd/MM/yyyy", null);
            if (ldt_date > hoy)
            {
                return "Por favor, la Fecha no puede ser mayor a Hoy";
            }*/

            if (string.IsNullOrEmpty(calendarioModel.Estado))
            {
                return "Por favor, indique el Estado";
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
