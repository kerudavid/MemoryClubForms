using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryClubForms
{
    public static class VariablesGlobales
    {
        public static int idUsuario { get; set; }
        public static string usuario { get; set; }
        public static int sucursal { get; set; }
        public static int Nivel { get; set; }
        public static bool OpentInsert { get; set; }
        public static bool OpenEdit { get; set; }
        public static bool OpenAlimentacion { get; set; }
        public static bool OpenSalud { get; set; }
        
        public static bool InsertCalendario { get; set; }
    }
}
