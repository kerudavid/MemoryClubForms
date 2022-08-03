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
    //Reporte de alertas de la tabla Calendario, Plan y Código
    public class ReporteAlertasBO
    {
        /// <summary>
        /// Devuelve una lista de alertas de los clientes que deben renovar su plan que está por finalizar
        /// </summary>
        /// <returns>ReporteAlertasModel</returns>
        public List<ReporteAlertasModel> LoadReporteAlertas()
        {
            string query = "";
            query = $"SELECT id_plan, L.nombre, CONVERT(varchar, MAX(CONVERT(date, C.fecha, 103)), 103) AS fecha_max, " +
                    $"CONVERT(varchar, DATEADD(DAY,-G.valor1,(MAX(CONVERT(date, C.fecha, 103)))), 103) AS fecha_alerta " +
                    $"FROM Calendario C LEFT JOIN Planes P ON fk_id_plan = id_plan LEFT JOIN Cliente L ON C.fk_id_cliente = L.id_cliente, " +
                    $"Codigo G WHERE P.estado = 'VIGENTE' AND G.grupo = 'PLN' AND G.subgrupo = 'NDIAS' AND G.elemento = '' AND G.estado = 'A' " +
                    $"GROUP BY G.valor1, id_plan, L.nombre HAVING  DATEADD(DAY,-G.valor1,(MAX(CONVERT(date, C.fecha, 103)))) <= CONVERT(DATE, GETDATE())";

            List<ReporteAlertasModel> AlertasList = new List<ReporteAlertasModel>();
            AlertasList = this.ObtenerListaSQL<ReporteAlertasModel>(query).ToList();

            return AlertasList;
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
