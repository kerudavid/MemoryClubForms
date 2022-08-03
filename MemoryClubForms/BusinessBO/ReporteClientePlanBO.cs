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
        /// <summary>
        /// Devuelve número de clientes que se encuentran en cada tipo de plan y si está pagado o no
        /// </summary>
        /// <returns>ReporteClientePlanModel</returns>
        public List<ReporteClientePlanModel1> LoadReporteClientePlan()
        {
            string query = "";
            query = $"SELECT sucursal, tipo_plan, pagado, COUNT(*) as num_clientes FROM Planes WHERE estado = 'VIGENTE' GROUP BY sucursal, tipo_plan, pagado";
      
            List<ReporteClientePlanModel1> ReporteCliPlanList = new List<ReporteClientePlanModel1>();
            ReporteCliPlanList = this.ObtenerListaSQL<ReporteClientePlanModel1>(query).ToList();

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
