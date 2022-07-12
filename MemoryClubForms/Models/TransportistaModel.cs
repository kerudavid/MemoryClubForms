using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryClubForms.Models
{
    //Gestiona la tabla Transportista
    public class TransportistaModel
    {
        public int Id_transportista { get; set; }
        public int Sucursal { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public int Ruta { get; set; }
        public string Sector { get; set; }
        public string Placa_veh { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Estado { get; set; }
        public string Observacion { get; set; }
        public string Usuario { get; set; }
        public string Fecha_mod { get; set; }


        public string Validate(TransportistaModel PtransportistaModel)
        {

            string message = string.Empty;

            if (PtransportistaModel.Sucursal <= 0)
            {
                return "Por favor, debe ingresar una sucursal válida";
            }
            if (string.IsNullOrEmpty(PtransportistaModel.Cedula))
            {
                return "Por favor, debe registrar el número de cédula";
            }
            if (string.IsNullOrEmpty(PtransportistaModel.Nombre))
            {
                return "Por favor, debe registrar el nombre del transportista";
            }
            if (PtransportistaModel.Ruta <= 0)
            {
                return "Por favor, debe ingresar una ruta válida";
            }
            if (string.IsNullOrEmpty(PtransportistaModel.Sector))
            {
                return "Por favor, debe registrar el sector ";
            }
            if (string.IsNullOrEmpty(PtransportistaModel.Estado))
            {
                return "Por favor, debe registrar el estado (A-I) del transportista";
            }

            return message;
        }



    }
}
