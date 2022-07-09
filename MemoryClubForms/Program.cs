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
            CateringBO catering = new CateringBO();
           /* CateringModel model = new CateringModel();
            model.Id_catering = 18;
            model.Fk_id_cliente = 0;
            model.Tipo_cliente = "";
            model.Tipo_menu = "";
            model.Fecha = "";
            model.Hora = "";
            model.Observacion = "";
            model.Sucursal = 0;
            model.Usuario = "";
            model.Fecha_mod = "";
            catering.EliminarCatering(55);*/
       
            Application.Run(new LoginForm());
       
        }
    }
}
