using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryClubForms.Models
{
    /// <summary>
    /// List model de la tabla Plan
    /// </summary>
    public class PlanModel
    {
        public int Id_plan { get; set; }
        public int Fk_id_cliente { get; set; }
        public string Nombre { get; set; }
        public int Sucursal { get; set; }
        public string Tipo_plan { get; set; }    
        public string Fecha_inicio_plan { get; set; }   
        public string Pagado { get; set; }
        public int Max_dia_plan { get; set; }    
        public string Estado { get; set; }  
        public string Observacion { get; set; }
        public  string Usuario { get; set; }
        public string Fecha_mod { get; set; }
        public DateTime Fechahora { get; set; }

        public string Validate(PlanModel planModel)
        {
            string message = string.Empty;
            DateTime hoy = DateTime.Today;
            Boolean x = false;
            string cadena = string.Empty;

            if (planModel.Fk_id_cliente <= 0)
            {
                return "Por favor, debe ingresar un Cliente Válido";
            }
            if (planModel.Sucursal <= 0)
            {
                return "Por favor, debe ingresar una Sucursal Válida";
            }
            if (string.IsNullOrEmpty(planModel.Tipo_plan) || string.IsNullOrWhiteSpace(planModel.Tipo_plan))
            {
                return "Por favor, debe ingresar Tipo Plan";
            }

            if (planModel.Max_dia_plan <= 0)
            {
                return "Por favor, Ingrese Máximo Número de Días para Uso del Plan";
            }
                        
            if (string.IsNullOrEmpty(planModel.Fecha_inicio_plan) || string.IsNullOrWhiteSpace(planModel.Fecha_inicio_plan))
            {
                return "Por favor, debe ingresar Fecha de Inicio del Plan";
            }
            x = Validafecha(planModel.Fecha_inicio_plan);
            if (!x)
            {
                return "Por favor, debe ingresar una Fecha Inicio de Plan Válida";
            }
            //la fecha inicio de plan si puede ser mayor a hoy porque es una planificacion

            /*DateTime ldt_date = DateTime.ParseExact(planModel.Fecha_inicio_plan, "dd/MM/yyyy", null);
            if (ldt_date > hoy)
            {
                return "Por favor, la Fecha de Plan no puede ser mayor a Hoy";
            }*/

            if (string.IsNullOrEmpty(planModel.Pagado) || string.IsNullOrWhiteSpace(planModel.Pagado))
            {
                return "Por favor, debe indicar si el Plan está Pagado";
            }
            
            if (string.IsNullOrEmpty(planModel.Estado))
            {
                return "Por favor, indique el estado del Plan";
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
