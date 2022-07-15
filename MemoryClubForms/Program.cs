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

            AlimentacionBO alimentacion = new AlimentacionBO();
            AlimentacionModel model = new AlimentacionModel();
            //model.Id_alimentacion = 
           /* model.Fk_id_cliente = 2;
            model.Alimento_restringido = "MARISCOS";
            model.Observacion = "Prueba insertar";
            model.Usuario = "mmoreta";
            model.Fecha_mod = "15/07/2022";*/


            alimentacion.ConsultaAlimentacion(1, "");



           // Application.Run(new LoginForm());
       
        }
    }
}
