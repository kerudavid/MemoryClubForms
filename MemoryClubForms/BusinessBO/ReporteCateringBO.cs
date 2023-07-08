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
    //para generar reporte de la tabla Catering
    public class ReporteCateringBO
    {
        CultureInfo ci = new CultureInfo("en-US");
        /// <summary>
        /// Devuelve número de clientes por sucursal, tipo menú y tipo cliente
        /// </summary>
        /// <returns>ReporteClientePlanModel</returns>
        public List<ReporteCateringModel> LoadReporteCatering(string Fdesde, string Fhasta)
        {
            DateTime fechadesde = DateTime.Now;
            DateTime fechahasta = DateTime.Now;
            string query = "";
            string condiciones = "";
            int dias = 0;

            //valido las fechas - cuando no viene una fecha Busco la fecha de inicio del mes en curso para fecha desde
            if (string.IsNullOrEmpty(Fdesde) || string.IsNullOrWhiteSpace(Fdesde))
            {
                dias = Convert.ToInt32(fechadesde.Day);
                dias--;
                fechadesde = fechadesde.AddDays(-dias);
                Fdesde = fechadesde.ToString("MM/dd/yyyy", ci);
            }

            //si no viene la fecha hasta pongo la fecha de hoy
            if (string.IsNullOrEmpty(Fhasta) || string.IsNullOrWhiteSpace(Fhasta))
            {
                Fhasta = fechahasta.ToString("MM/dd/yyyy", ci);
            }
             
            if (!(string.IsNullOrEmpty(Fdesde)) & !(string.IsNullOrEmpty(Fhasta)))
            {
                condiciones += $"WHERE CONVERT(date, fecha, 101) BETWEEN CAST('{Fdesde}' AS date) AND CAST('{Fhasta}' AS date) ";
            }

            query = $"SET LANGUAGE us_english " +
                    $"SELECT sucursal, tipo_menu, tipo_cliente, COUNT(*) AS numero FROM Catering " +
                    $"{ condiciones}" +
                    $" GROUP BY sucursal, tipo_menu, tipo_cliente";

            List<ReporteCateringModel> ReporCateringList = new List<ReporteCateringModel>();
            ReporCateringList = this.ObtenerListaSQL<ReporteCateringModel>(query).ToList();

            return ReporCateringList;
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
