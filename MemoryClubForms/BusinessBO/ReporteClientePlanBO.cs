using MemoryClubForms.Models;
using MemoryClubForms.Data;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace MemoryClubForms.BusinessBO
{
    //Gestiona el Reporte de la tabla Plan
    public class ReporteClientePlanBO
    {
        CultureInfo ci = new CultureInfo("en-US");
        /// <summary>
        /// Devuelve los planes de un cliente en un periodo determinado versus la asistencia
        /// </summary>
        /// <returns>ReporteClientePlanModel</returns>
        public List<ReporteVentasModel> LoadReporteClientePlan(string Pdesde, string Phasta, string Pcliente)
        {
            DateTime fechadesde = DateTime.Now;
            DateTime fechahasta = DateTime.Now;
            int dias = 0;
            string cadena = "";

            //valido las fechas - cuando no viene una fecha Busco la fecha de inicio del mes en curso para fecha desde
            if (string.IsNullOrEmpty(Pdesde) || string.IsNullOrWhiteSpace(Pdesde))
            {
                dias = Convert.ToInt32(fechadesde.Day);
                dias--;
                fechadesde = fechadesde.AddDays(-dias);
                Pdesde = fechadesde.ToString("MM/dd/yyyy", ci);
            }
            //si no viene la fecha hasta pongo la fecha de hoy
            if (string.IsNullOrEmpty(Phasta) || string.IsNullOrWhiteSpace(Phasta))
            {
                Phasta = fechahasta.ToString("MM/dd/yyyy", ci);
            }

            if (!(string.IsNullOrEmpty(Pcliente)) & Pcliente != "TODOS")
            {
                cadena = $"AND C.nombre LIKE \'%{Pcliente}%\'";                 
            }
            else
            { cadena = ""; }

            string query = "";
            query = $"SELECT  t1.sucursal as sucursal, t1.id_plan as idplan, t1.fk_id_cliente as idcliente, C.nombre as nombre, t1.fecha_inicio_plan as fechaini, " +
                $"t1.fecha_fin_plan as fechafin, t1.max_dia_plan as dias_comprados, t5.dias_asistidos as dias_asistidos, DateName(month,CONVERT(date, t1.fecha_inicio_plan,101)) mes, " +
                $"t1.fecha_mod as fecha_mod, t1.idplan_anterior as plan_anterior FROM Planes AS t1 INNER JOIN Cliente C ON t1.fk_id_cliente = c.id_cliente " +
                $"LEFT OUTER JOIN (Select distinct a.fk_id_cliente, count(id_asistencia) dias_asistidos, t2.id_plan from Asistencia a " +
                $"inner join (SELECT * FROM Planes x where CONVERT(date, fecha_inicio_plan,101) BETWEEN CONVERT(date, '{Pdesde}',101) AND CONVERT(date, '{Phasta}',101)) t2 ON " +
                $"(a.fk_id_cliente=t2.fk_id_cliente) where (CONVERT(date, A.fecha,101) BETWEEN CONVERT(date, t2.fecha_inicio_plan,101) AND CONVERT(date,t2.fecha_mod,101)) or a.id_asistencia is null " +
                $"group by a.fk_id_cliente, t2.id_plan) t5 on t1.fk_id_cliente = t5.fk_id_cliente and t1.id_plan = t5.id_plan " +
                $"WHERE CONVERT(date, t1.fecha_inicio_plan,101) BETWEEN CONVERT(date, '{Pdesde}',101) AND CONVERT(date, '{Phasta}',101)  " +
                $"{cadena} " +
                $"ORDER BY t1.sucursal, C.nombre, t1.id_plan ";

            List<ReporteVentasModel> ReporteCliPlanList = new List<ReporteVentasModel>();
            ReporteCliPlanList = this.ObtenerListaSQL<ReporteVentasModel>(query).ToList();

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
