using MemoryClubForms.BusinessBO;
using MemoryClubForms.Forms;
using MemoryClubForms.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryClubForms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Clicked(object sender, EventArgs e)
        {
            try
            {
                LoginModel loginModel = new LoginModel();
                LoginBO loginBO = new LoginBO();

                loginModel.usuario = txtUser.Text;
                loginModel.clave = txtPassword.Text;

                string message = loginModel.Validate(loginModel);

                if (!string.IsNullOrEmpty(message))
                {
                    MessageBox.Show(message);
                    return;
                }

                var response = loginBO.IsLoggedIn(loginModel);

                //Valida que la lista contenga informacion

                //En este caso si retorna algo, quiere decir que si encontró al usuario y
                //puede proceder al sistema
                if (response.Count <= 0)
                {
                    MessageBox.Show("Usuario no registrado.");
                    return;
                }

                //Valido que sea un usuario de nivel 1 o inferior, tenga estado A.
                var level = response.Select(p => p.nivel <= 1).FirstOrDefault();//loginModelList.Where(p => p.estado == "A").FirstOrDefault();

                var estado = response.Select(p => p.estado == "A").FirstOrDefault();
                if (!level || !estado)
                {
                    MessageBox.Show("Este usuario no tiene los privilegios para entrar al sistema.");
                    return;
                }

                //Agrego los datos del usuario logueado
                VariablesGlobales.idUsuario = response.Select(x => x.id_usuario).FirstOrDefault();
                VariablesGlobales.usuario = response.Select(x => x.usuario).FirstOrDefault();
                VariablesGlobales.sucursal = response.Select(x => x.sucursal).FirstOrDefault();
                VariablesGlobales.Nivel = response.Select(x => x.nivel).FirstOrDefault();

                //Navego a la siguiente pagina
                // Envío el Id del Padre al FormHome                        
                this.Hide();
                HomeForm homeForm = new HomeForm();
                homeForm.Show();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Alerta, ocurrió un error en el sistema. " + ex.Message);
            }
        }

    }
}
