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
    public class ReporteVtaMesBO
    {
        CultureInfo ci = new CultureInfo("en-US");
        /// <summary>
        /// Recupera los penúltimos planes del periodo seleccionado usando el campo idplan_anterior
        /// </summary>
        /// <returns></returns>
        public List<ReporteVtaMesAntModel> LoadReporteVtaMesAnt(string Pdesde, string Phasta, string Pestado)
        {
            DateTime fechadesde = DateTime.Now;
            DateTime fechahasta = DateTime.Now;       
            //int dias = 0;

            if (string.IsNullOrEmpty(Pdesde) || string.IsNullOrWhiteSpace(Pdesde))
            {
                /*dias = Convert.ToInt32(fechadesde.Day);
                dias--;
                fechadesde = fechadesde.AddDays(-dias);
                Pdesde = fechadesde.ToString("MM/dd/yyyy", ci);*/
                Pdesde = string.Empty;
            }
            
            if (string.IsNullOrEmpty(Phasta) || string.IsNullOrWhiteSpace(Phasta))
            {
                //Phasta = fechahasta.ToString("MM/dd/yyyy", ci);
                Phasta = string.Empty;  
            }

            if (string.IsNullOrEmpty(Pestado) || string.IsNullOrWhiteSpace(Pestado))
            {
                Pestado = string.Empty;
            }

            string query = "";

            query = $"EXECUTE CONSULTA_PLANES_ANT '{Pdesde}', '{Phasta}', '{Pestado}' "; //Ejecuta StoreProcedure en la bdd para los planes anteriores

            List<ReporteVtaMesAntModel> vtaMesAntList = new List<ReporteVtaMesAntModel>();
            vtaMesAntList = this.ObtenerListaSQL<ReporteVtaMesAntModel>(query).ToList();

            return vtaMesAntList;
        }
        /// <summary>
        /// Recupera los planes del periodo solicitado
        /// </summary>
        /// <returns></returns>

        public List<ReporteVentasModel> LoadReporteVentas(string Pdesde, string Phasta, string Pestado)
        {
            DateTime fechadesde = DateTime.Now;
            DateTime fechahasta = DateTime.Now;
            //int dias = 0;

            //valido las fechas - cuando no viene una fecha Busco la fecha de inicio del mes en curso para fecha desde
            if (string.IsNullOrEmpty(Pdesde) || string.IsNullOrWhiteSpace(Pdesde))
            {
                /*dias = Convert.ToInt32(fechadesde.Day);
                dias--;
                fechadesde = fechadesde.AddDays(-dias);
                Pdesde = fechadesde.ToString("MM/dd/yyyy", ci);*/

                Pdesde = string.Empty;
            }
            //si no viene la fecha hasta pongo la fecha de hoy
            if (string.IsNullOrEmpty(Phasta) || string.IsNullOrWhiteSpace(Phasta))
            {
                // Phasta = fechahasta.ToString("MM/dd/yyyy", ci);
                Phasta = string.Empty;
            }
            string query = "";

            query = $"EXECUTE CONSULTA_PLANES_ACT '{Pdesde}', '{Phasta}', '{Pestado}' "; //Ejecuta StoreProcedure en la bdd

            List<ReporteVentasModel> vtaMesList = new List<ReporteVentasModel>();
            vtaMesList = this.ObtenerListaSQL<ReporteVentasModel>(query).ToList();

            return vtaMesList;
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
