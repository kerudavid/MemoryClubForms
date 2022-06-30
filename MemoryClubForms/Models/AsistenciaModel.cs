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
        public string Fecha { get; set; }
        public string Hora { get; set; }
        public string Observacion { get; set; }
        public int Sucursal { get; set; }
        public string Usuario { get; set; }
        public string Fecha_mod { get; set; }

        //metodo para validar datos
        public string Validate(AsistenciaModel asistenciaModel)
        {

            string message = string.Empty;
            DateTime hoy = DateTime.Today;

            if (asistenciaModel.Fk_id_cliente <= 0)
            {
                return "Por favor, debe ingresar un cliente válido";
            }

            if (string.IsNullOrEmpty(asistenciaModel.Fecha))
            {
                return "Por favor, debe ingresar una fecha válida";
            }

            DateTime ldt_date = DateTime.ParseExact(asistenciaModel.Fecha, "dd/MM/yyyy", null);
            if (ldt_date > hoy)
            {
                return "Por favor, La fecha no puede ser mayor a hoy";
            }

            if (string.IsNullOrEmpty(asistenciaModel.Hora))
            {
                return "Por favor, debe ingresar una hora válida";
            }

            if (asistenciaModel.Sucursal <= 0)
            {
                return "Por favor, debe ingresar una sucursal válida";
            }

            return message;


        }

    }
}
