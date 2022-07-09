using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryClubForms.Models
{
    /// <summary>
    /// Modelo de la tabla Asistencia
    /// </summary>
    public class AsistenciaModel
    {
        public int Id_asistencia { get; set; }
        public int Fk_id_cliente { get; set; }
        public string Nombre { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }
        public string Observacion { get; set; }
        public int Sucursal { get; set; }
        public string Usuario { get; set; }
        public string Fecha_mod { get; set; }
        public string Estado { get; set; }
        public DateTime Fechahora { get; set; }



        //metodo para validar datos
        public string Validate(AsistenciaModel asistenciaModel)
        {

            string message = string.Empty;
            DateTime hoy = DateTime.Today;
            Boolean x = false;
            string cadenahora = string.Empty;

            if (asistenciaModel.Fk_id_cliente <= 0)
            {
                return "Por favor, debe ingresar un cliente válido";
            }

            if (string.IsNullOrEmpty(asistenciaModel.Fecha) || string.IsNullOrWhiteSpace(asistenciaModel.Fecha))
            {
                return "Por favor, debe ingresar una fecha válida";
            }

            x = Validafecha(asistenciaModel.Fecha);
            if (!x)
            {
                return "Por favor, debe ingresar una Fecha Válida";
            }
            DateTime ldt_date = DateTime.ParseExact(asistenciaModel.Fecha, "dd/MM/yyyy", null);
            if (ldt_date > hoy)
            {
                return "Por favor, La fecha no puede ser mayor a hoy";
            }

            if (string.IsNullOrEmpty(asistenciaModel.Hora) || string.IsNullOrWhiteSpace(asistenciaModel.Hora))
            {
                return "Por favor, debe ingresar una hora válida";
            }

            cadenahora = "01/01/1900 " + asistenciaModel.Hora;
            x = Validafecha(cadenahora);
            if (!x)
            {
                return "Por favor, debe ingresar una Hora Válida Formato (24hs)";
            }

            if (asistenciaModel.Sucursal <= 0)
            {
                return "Por favor, debe ingresar una sucursal válida";
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
                DateTime.Parse(pfecha);
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
