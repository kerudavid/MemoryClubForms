using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemoryClubForms.Data;
using MemoryClubForms.Models;

namespace MemoryClubForms.BusinessBO
{
    public class LoginBO
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<LoginModel> IsLoggedIn(LoginModel loginModel)
        {
            string query = $"SELECT * FROM Usuario WHERE usuario = '{loginModel.usuario}'"
                + $"AND clave ='{loginModel.clave}'";

            List<LoginModel> loginModelList = new List<LoginModel>();

            //Las consultas siempre retornan el obtejo dentro de una lista.
            loginModelList = this.ObtenerListaSQL<LoginModel>(query).ToList();

            return loginModelList;
        }

        /// <summary>
        /// Método para convertir una lista DataTable a un TModel (Modelo genérico)
        /// </summary>
        /// <returns>IList<TModel></returns>
        private IList<TModel> ObtenerListaSQL<TModel>(string query)
        {
            try
            {
                DataTable dataTableInformacion = SQLConexionDataBase.Query(query);
                var listaResultante = dataTableInformacion.MapDataTableToList<TModel>();

                return listaResultante;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
