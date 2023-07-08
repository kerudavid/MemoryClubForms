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
        /// Devuelve una lista de alertas de los clientes que deben renovar su plan que está por finalizar por fecha de vigencia o porque ya faltan 
        /// hasta 3 días o menos para que completen los días asistidos
        /// </summary>
        /// <returns>ReporteAlertasModel</returns>
        public List<ReporteAlertasModel> LoadReporteAlertas()
        {
            string query = "";
            query = $"SELECT p.sucursal, L.nombre, CONVERT(varchar, CONVERT(date, P.fecha_fin_plan, 101), 101) AS fecha_vigencia, " +
                $"max_dia_plan, AVG(-1000) as dias_asistidos FROM Planes P LEFT JOIN Cliente L ON P.fk_id_cliente = L.id_cliente, " +
                $"Codigo G " +
                $"WHERE P.estado = 'VIGENTE' AND G.grupo = 'PLN' AND G.subgrupo = 'NDIAS' AND G.elemento = \'\'  AND " +
                $"G.estado = 'A' AND DATEADD(DAY,-G.valor1,CONVERT(date, P.fecha_fin_plan, 101)) <= GETDATE() " +
                $"group by p.sucursal, L.nombre,  P.fecha_fin_plan, max_dia_plan " +
                $"UNION " +
                $"SELECT t1.sucursal as sucursal, C.nombre as nombre, CONVERT(varchar, CONVERT(date,t1.fecha_fin_plan, 101), 101) AS fecha_max, " +
                $"t1.max_dia_plan as dias_comprados, t5.dias_asistidos as dias_asistidos " +
                $"FROM Planes AS t1 INNER JOIN Cliente C ON t1.fk_id_cliente = c.id_cliente " +
                $"LEFT OUTER JOIN (Select a.fk_id_cliente, count(id_asistencia) dias_asistidos from Asistencia a inner join Planes x " +
                $"on (a.fk_id_cliente = x.fk_id_cliente AND x.estado = 'VIGENTE') " +
                $"where (CONVERT(date, A.fecha,101) BETWEEN CONVERT(date, x.fecha_inicio_plan,101) AND GETDATE()) " +
                $"OR a.id_asistencia is null " +
                $"group by a.fk_id_cliente) t5 on t1.fk_id_cliente = t5.fk_id_cliente " +
                $"WHERE t1.estado = 'VIGENTE' AND (t1.max_dia_plan - t5.dias_asistidos <= 3) " +
                $"ORDER BY p.sucursal, L.nombre";
                
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
