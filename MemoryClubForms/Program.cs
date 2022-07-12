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

            ColaboradorBO colaborador = new ColaboradorBO();
            ColaboradorModel model = new ColaboradorModel();
            /*  model.Id_colaborador =  10005;
              model.Sucursal = 2;
              model.Nombre= "Lucia Pazmiño";
              model.Cedula = "1708952587";
              model.Direccion = "Miraflores";
              model.Telefono = "2125-565";
              model.Cargo = "Coordinadora Temporal";
              model.Estado = "A";
              model.Observacion = "prueba modificar";
              model.Usuario = "mmoreta";
              model.Fecha_mod = "11/07/2022";*/

            //colaborador.ConsultaColaborador(10003, 0, "");
           // colaborador.EliminarColaborador(10004);

            Application.Run(new LoginForm());
       
        }
    }
}
