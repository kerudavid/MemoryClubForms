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
    public class ReporteTransporteBO
    {
        CultureInfo ci = new CultureInfo("en-US");
        /// <summary>
        /// Devuelve número de clientes por sucursal, transportista, tipo cliente, entrada_salida
        /// </summary>
        /// <returns>ReporteClientePlanModel</returns>
        public List<ReporteTransporteModel> LoadReporteTransporte(string Fdesde, string Fhasta)
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

            query = $"SELECT T.sucursal as sucursal, S.nombre as nombre, tipo_cliente, entrada_salida, COUNT(*) AS numero FROM Transporte T LEFT JOIN Transportista S ON T.id_transportista = S.id_transportista " +
                    $"{condiciones}" +
                    $" GROUP BY T.sucursal, S.nombre, tipo_cliente, entrada_salida";

            List<ReporteTransporteModel> ReporTranspList = new List<ReporteTransporteModel>();
            ReporTranspList = this.ObtenerListaSQL<ReporteTransporteModel>(query).ToList();

            return ReporTranspList;
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
