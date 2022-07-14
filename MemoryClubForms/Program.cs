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

            ClienteBO cliente = new ClienteBO();
            /*ClienteModel model = new ClienteModel();
             model.Id_cliente = 12;
            // model.Cedula = "1727374757";
            // model.Nombre = "Tabata Zurita";
             model.Apodo = "Tabita";
             model.Fecha_free = "";
             model.Estado = "P";
             model.Aula = 5;
             model.Dia_nacim = 1;
             model.Mes_nacim = 10;
             model.Anio_nacim = 1950;
             model.Telefono = "";
             model.Nombre_contacto = "Julian Zurita";
             model.Parentesco_contacto = "Hermano";
             model.Telefono_contacto = "";
             model.Celular_contacto = "0997845784";
             model.Encargado_pago = "María Moreno";
             model.Parentesco_pago = "Hija";
             model.Telefono_pago = "";
             model.Cedula_pago = "1728384858";
             model.Celular_pago = "";
             model.Email_pago = "mzurita@outlook.com";
             model.Medio_pago = "EFECTIVO";
             model.Pariente_transp = "";
             model.Direccion = "Calderon";
             model.Toma_transp = "SI";
             model.Id_transportista = 2;
             model.Retirarse_solo = "NO";
             model.Nombre_factu = "Tabata Zurita";
             model.Cedula_factu = "1727374757";
             model.Direccion_factu = "Calderon";
             model.Email_factu = "mzurita@outlook.com";
             model.Sucursal = 1;
             model.Observacion = "prueba de actualizacion apodo, estado, aula, medio pago, idt";
             model.Usuario = "mmoreta";
             model.Fecha_mod = "13/07/2022";


            cliente.EliminarCliente(model);*/

            cliente.LoadEstados();



            Application.Run(new LoginForm());
       
        }
    }
}
