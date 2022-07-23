using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryClubForms.Models
{
    public class ReporteClientePlanModel
    {
        public string Tipo_plan { get; set; }
        public string Pagado { get; set; }
        public int Num_clientes { get; set; }

        public ReporteClientePlanModel()
        { }
    }
}
