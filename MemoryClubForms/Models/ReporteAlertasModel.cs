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
        public int Sucursal { get; set; }
        public string  Nombre { get; set; }
        public string Fecha_vigencia { get; set; }
        public int Max_dia_plan { get; set; }
        public int Dias_asistidos { get; set; }

    }
}
