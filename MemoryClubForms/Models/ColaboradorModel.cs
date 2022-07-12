using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryClubForms.Models
{
    public class ColaboradorModel
    {
        public int Id_colaborador { get; set; }
        public int Sucursal { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Cargo { get; set; }
        public string Estado { get; set; }
        public string Observacion { get; set; }
        public string Usuario { get; set; }
        public string Fecha_mod { get; set; }

        public string Validate(ColaboradorModel PcolaboradorModel)
        {

            string message = string.Empty;

            if (PcolaboradorModel.Sucursal <= 0)
            {
                return "Por favor, debe ingresar una sucursal válida";
            }
            if (string.IsNullOrEmpty(PcolaboradorModel.Cedula))
            {
                return "Por favor, debe registrar el número de cédula";
            }
            if (string.IsNullOrEmpty(PcolaboradorModel.Nombre))
            {
                return "Por favor, debe registrar el nombre del colaborador";
            }
            if (string.IsNullOrEmpty(PcolaboradorModel.Estado))
            {
                return "Por favor, debe registrar el estado (A-I) del colaborador";
            }

            return message;
        }
    }
}
