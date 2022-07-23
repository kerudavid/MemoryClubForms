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
    //Gestiona el Reporte de la tabla Plan
    public class ReporteClientePlanBO
    {
        public List<ReporteClientePlanModel> LoadReporteClientePlan()
        {
            string query = "";
            query = $"SELECT tipo_plan, pagado, COUNT(*) as num_clientes FROM Planes WHERE estado = 'VIGENTE' GROUP BY tipo_plan, pagado";
            List<ReporteClientePlanModel> ReporteCliPlanList = new List<ReporteClientePlanModel>();
            ReporteCliPlanList = this.ObtenerListaSQL<ReporteClientePlanModel>(query).ToList();

            return ReporteCliPlanList;
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
