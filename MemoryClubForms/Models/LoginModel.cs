using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryClubForms.Models
{
    public class LoginModel
    {
        public int id_usuario { get; set; }
        public string usuario { get; set; }
        public string clave { get; set; }
        public int nivel { get; set; }
        public string estado { get; set; }
        public int sucursal { get; set; }



        public string Validate(LoginModel loginModel)
        {
            string message = string.Empty;

            if (string.IsNullOrEmpty(loginModel.usuario) || string.IsNullOrEmpty(loginModel.clave))
            {
                return "Por favor, debe ingresar usuario y contraseña";
            }


            return message;
        }
    }
}
