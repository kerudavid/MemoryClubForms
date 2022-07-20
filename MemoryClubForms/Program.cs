using System;
using MemoryClubForms.Models;
using MemoryClubForms.BusinessBO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryClubForms
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            CalendarioBO calen = new CalendarioBO();
            CalendarioModel model = new CalendarioModel();
            model.Fecha = "16/07/2022";
            /*model.Id_plan = 2;
            model.Fk_id_cliente = 1;
            model.Sucursal = 1;
            model.Tipo_plan = "CORTESIA";
            model.Fecha_inicio_plan = "15/07/2022";
            model.Pagado = "NO";
            model.Max_dia_plan = 10;
            model.Estado = "VIGENTE";
            model.Observacion = "Prueba de modificar";
            model.Usuario = "";
            model.Fecha_mod = "";*/


            calen.Validafinsemana(model);



            Application.Run(new LoginForm());

        }
    }
}
