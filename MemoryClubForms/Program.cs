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

           /* UsuarioBO caten = new UsuarioBO();
            UsuarioModel model = new UsuarioModel();
            model.Id_usuario = 3;
            model.Usuario = "fgomez";
            model.Clave = "clavenueva";
            model.Nivel = 2;
            model.Estado = "A";
            model.Descripcion = "Fernando Gomez";
            model.Sucursal = 1;
            model.Observacion = "prueba de modificacion";
            model.Fecha_mod = "03/08/2022";

            caten.EliminarUsuario(model);*/




            Application.Run(new LoginForm());

        }
    }
}
