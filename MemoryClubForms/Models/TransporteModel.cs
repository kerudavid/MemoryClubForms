using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryClubForms.Models
{
    /// <summary>
    /// Modelo de la tabla Transporte
    /// </summary>
    public class TransporteModel
    {
        public int Id_transporte {get; set;}
        public int Fk_id_cliente {get; set;}
        public string Nombre { get; set; }
        public string Tipo_cliente { get; set;}
        public string Fecha { get; set;}
        public string Hora { get; set;}
        public int Id_transportista { get; set;}
        public string Entrada_salida { get; set;}
        public string Observacion { get; set;}
        public int Sucursal { get; set;}
        public string Usuario { get; set;}
        public string Fecha_mod { get; set; }
        public string Estado { get; set;}
        public DateTime Fechahora { get; set;} 


        /// <summary>
        /// Metodo para validar los datos de transporte
        /// </summary>
        /// <param name="PtransporteModel"></param>
        /// <returns></returns>
        public string Validate(TransporteModel PtransporteModel)
        {

            string message = string.Empty;
            DateTime hoy = DateTime.Today;
            Boolean x = false;
            string cadenahora = string.Empty;

            if (PtransporteModel.Fk_id_cliente <= 0)
            {
                return "Por favor, debe ingresar un cliente válido";
            }
            if (string.IsNullOrEmpty(PtransporteModel.Tipo_cliente))
            {
                return "Por favor, debe ingresar Tipo de Cliente";
            }

            if (string.IsNullOrEmpty(PtransporteModel.Fecha) || string.IsNullOrWhiteSpace(PtransporteModel.Fecha))
            {
                return "Por favor, debe ingresar una fecha válida";
            }

            x = Validafecha(PtransporteModel.Fecha);
            if (!x)
            {
                return "Por favor, debe ingresar una Fecha Válida";
            }
            DateTime ldt_date = DateTime.ParseExact(PtransporteModel.Fecha, "dd/MM/yyyy", null);
            if (ldt_date > hoy)
            {
                return "Por favor, La fecha no puede ser mayor a hoy";
            }

            if (string.IsNullOrEmpty(PtransporteModel.Hora) || string.IsNullOrWhiteSpace(PtransporteModel.Hora))
            {
                return "Por favor, debe ingresar una hora válida";
            }

            cadenahora = "01/01/1900 " + PtransporteModel.Hora;
            x = Validafecha(cadenahora);
            if (!x)
            {
                return "Por favor, debe ingresar una Hora Válida Formato (24hs)";
            }
            if (PtransporteModel.Id_transportista <= 0)
            {
                return "Por favor, debe registrar el Transportista";

            }

            if (PtransporteModel.Sucursal <= 0)
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
