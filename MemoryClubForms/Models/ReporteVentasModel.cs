using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryClubForms.Models
{
    public class ReporteVentasModel
    {
        public int Sucursal { get; set; }
        public int Idplan { get; set; }
        public int Idcliente { get; set; }
        public string Nombre { get; set; }
        public string Fechaini { get; set; }
        public string Fechafin { get; set; }
        public int Dias_comprados { get; set; }
        public int Dias_asistidos { get; set; }
        public string Mes { get; set; }
        public string Fecha_mod { get; set; }   
        public int Plan_anterior { get; set; }
    }
}
