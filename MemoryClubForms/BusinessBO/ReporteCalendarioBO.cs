using MemoryClubForms.Models;
using MemoryClubForms.Data;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryClubForms.BusinessBO
{
    internal class ReporteCalendarioBO
    {
        /// <summary>
        /// Devuelve lista de clientes con planes vigentes y su número de días reservados y tomados
        /// </summary>
        /// <returns>ReporteAlertasModel</returns>
        public List<ReporteCalendarioModel> LoadReporteCalendario()
        {
            string query = "";
            query = $"SELECT P.sucursal as sucursal, C.fk_id_plan as id_plan, L.nombre as nombre, C.estado as estado, count(*) numdias FROM Calendario " +
                    $"C LEFT JOIN Planes P ON fk_id_plan = id_plan LEFT JOIN Cliente L ON C.fk_id_cliente = L.id_cliente " +
                    $"WHERE P.estado = 'VIGENTE' GROUP BY P.sucursal, C.fk_id_plan, L.nombre, C.estado ORDER BY P.sucursal, L.nombre, C.estado";

            List<ReporteCalendarioModel> CalendariosList = new List<ReporteCalendarioModel>();
            CalendariosList = this.ObtenerListaSQL<ReporteCalendarioModel>(query).ToList();

            return CalendariosList;
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
