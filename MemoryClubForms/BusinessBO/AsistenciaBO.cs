using MemoryClubForms.Data;
using MemoryClubForms.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryClubForms.BusinessBO
{
    /// <summary>
    /// Clase para gestionar la tabla Asistencia
    /// </summary>
    public class AsistenciaBO
    {
        //recuperar información de asistencia por periodo de fechas
        public List<AsistenciaModel> ConsultarPeriodoAsis(string Pdesde, string Phasta)
        {

            DateTime fechadesde = DateTime.Now;
            if (string.IsNullOrEmpty(Pdesde))
            //cuando no viene una fecha desde, toma la fecha de hoy menos 30 días
            {
                fechadesde = fechadesde.AddDays(-30);
                Pdesde = fechadesde.ToString("MM/dd/yyyy");           
            }


            //podria usar fechadesde
            string query = $"SELECT * FROM Asistencia WHERE CONVERT(date,fecha,103)  >= CAST('{Pdesde}' AS date)";
            List<AsistenciaModel> asistenciaModelList = new List<AsistenciaModel>();
            //Las consultas siempre retornan el obtejo dentro de una lista.
            asistenciaModelList = this.ObtenerListaSQL<AsistenciaModel>(query).ToList();
            return asistenciaModelList;
        }

        /// <summary>
        /// Método para convertir una lista DataTable a un TModel(Modelo genérico)
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
