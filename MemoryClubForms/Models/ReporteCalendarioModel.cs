using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryClubForms.Models
{
    internal class ReporteCalendarioModel
    {
        public int Sucursal { get; set; }
        public int Id_plan { get; set; }
        public string Nombre { get; set; }
        public string Estado{ get; set; }
        public int Numdias { get; set; }
    }
}
