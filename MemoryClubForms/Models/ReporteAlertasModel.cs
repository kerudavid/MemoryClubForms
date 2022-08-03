using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryClubForms.Models
{
    //Modelo para datos de alertas tablas calendario y planes
    public class ReporteAlertasModel
    {
        public int Id_plan { get; set; }
        public string  Nombre { get; set; }
        public string Fecha_max { get; set; }
        public string Fecha_alerta { get; set; }

    }
}
