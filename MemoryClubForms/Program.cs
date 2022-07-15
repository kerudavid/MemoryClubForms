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

            TransporteBO cliente = new TransporteBO();
            TransporteModel model = new TransporteModel();
            //model.Id_transporte = 
            model.Fk_id_cliente = 4;
            model.Tipo_cliente = "CLIENTE";
            model.Fecha = "14/07/2022";
            model.Hora = "";
            model.Id_transportista = 0;
            model.Entrada_salida = "ENTRADA";
            model.Observacion = "Prueba";
            model.Sucursal = 0;
            model.Usuario = "mmoreta";
            model.Fecha_mod = "14/07/2022";
                      

            cliente.InsertarTransporte(model);



            Application.Run(new LoginForm());
       
        }
    }
}
