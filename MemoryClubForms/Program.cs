using System;
using MemoryClubForms.Models;
using MemoryClubForms.BusinessBO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using MemoryClubForms.Reports;

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

            /*CalendarioBO calen = new CalendarioBO();
            CalendarioModel model = new CalendarioModel();
            model.Id_calendario = 16;
            model.Fk_id_plan = 3;
            model.Fk_id_cliente = 2;
            model.Fecha = "15/07/2022";
            model.Estado = "RESERVADO";
            model.Usuario = "mmoreta";
            model.Fecha_mod = "21/07/2022";

            //calen.EliminarCalendario(model);


            //calen.InsertarAutomatico(4, 4, "Martes", "Miercoles", "Jueves", "", "");*/


            //OpenForm(new FormReporteClientePlan());
            
             


            Application.Run(new LoginForm());

        }
    }
}
