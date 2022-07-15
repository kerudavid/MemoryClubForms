using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryClubForms.Models
{
    //Modelo de la tabla Alimentacion (extension de cliente)
    public class AlimentacionModel
    {
        public int Id_alimentacion { get; set; }
        public int Fk_id_cliente { get; set; }
        public string Nombre { get; set; }
        public string Alimento_restringido { get; set; }
        public string Observacion { get; set; }
        public string Usuario { get; set; }
        public string Fecha_mod { get; set; }


        /// <summary>
        /// Valida los campos no nulos de la tabla Alimentación
        /// </summary>
        /// <param name="PalimentacionModel"></param>
        /// <returns>string mensaje</returns>
        public string Validate(AlimentacionModel PalimentacionModel)
        {
            string message = string.Empty;

            if (PalimentacionModel.Fk_id_cliente <= 0)
            {
                return "Por favor, debe ingresar un cliente válido";
            }
            if (string.IsNullOrEmpty(PalimentacionModel.Alimento_restringido))
            {
                return "Por favor, debe ingresar el Alimento Restringido del Cliente";
            }

            return message;
        }
    }
}
