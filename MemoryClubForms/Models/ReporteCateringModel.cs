using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryClubForms.Models
{
    //Reporte de la tabla Catering
    public class ReporteCateringModel
    {
        public int Sucursal { get; set; }
        public string Tipo_menu { get; set; }
        public string Tipo_cliente { get; set; }
        public int Numero { get; set; }
    }
}
