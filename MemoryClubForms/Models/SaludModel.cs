using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryClubForms.Models
{   
    //List model de la tabla salud
    public class SaludModel
    {
        public int Id_Salud { get; set; }
        public int Fk_id_cliente { get; set; }
        public string Nombre { get; set; }
        public string Enfermedad { get; set; }
        public string Observacion { get; set; }
        public string Medicacion { get; set; } 
        public string Carnet_vacuna { get; set; }
        public string Usuario { get; set; }
        public string Fecha_mod { get; set; }

        /// <summary>
        /// Para validar los datos que vienen en el list model
        /// </summary>
        /// <returns></returns>
        public string Validate(SaludModel PsaludModel)
        {
            string mensaje = string.Empty;

            if (PsaludModel.Fk_id_cliente <= 0)
            {
                mensaje = "Por favor, Ingrese el Cliente";
            }
            
            if (string.IsNullOrEmpty(PsaludModel.Enfermedad))
            {
                mensaje = "Por favor, Ingrese el campo Enfermedad";
            }
           
            return mensaje;
        }
    }
}
