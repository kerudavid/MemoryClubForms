using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryClubForms.Models
{
    //Modelo de la tabla Usuario
    public class UsuarioModel
    {
        public int Id_usuario { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }
        public int Nivel { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public int Sucursal { get; set; }
        public string Observacion { get; set; }
        public string Fecha_mod { get; set; }

        /// <summary>
        /// Valida los campos de la tabla Usuario que no pueden ser nulos
        /// </summary>
        /// <param name="usuarioModel"></param>
        /// <returns></returns>
        public string LoadUsuarioModel(UsuarioModel usuarioModel)
        {
            string msg = "";
            if (string.IsNullOrEmpty(usuarioModel.Usuario))
            {
                msg = "Digite un Usuario. Máximo 20 caracteres";
                return msg;
            }
            if (string.IsNullOrEmpty(usuarioModel.Clave))
            {
                msg = "Digite una Clave, Máximo 20 caracteres";
                return msg;
            }
            if (usuarioModel.Nivel < 0)
            {
                msg = "Seleccione un Nivel para el Usuario";
                return msg;
            }
            if (string.IsNullOrEmpty(usuarioModel.Descripcion))
            {
                msg = "Ingrese el Nombre y Apellido del Usuario";
                return msg;
            }
            if (string.IsNullOrEmpty(usuarioModel.Estado))
            {
                msg = "Indique el Estado del Usuario";
                return msg;
            }
            if (usuarioModel.Sucursal <= 0)
            {
                msg = "Seleccione la Sucursal del Usuario";
                return msg;
            }
            return msg;
        }
    }
}
