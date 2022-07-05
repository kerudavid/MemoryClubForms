using MemoryClubForms.Data;
using MemoryClubForms.Models;
using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryClubForms.BusinessBO
{
    //Gestionar la tabla Transporte
    public class TransporteBO
    {
        int nivel = VariablesGlobales.Nivel;
        int sucursal = VariablesGlobales.sucursal;

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
        
        /// <summary>
        /// Consulta general por varios parámetros de la tabla Transporte
        /// </summary>
        /// <param name="Pdesde"></param>
        /// <param name="Phasta"></param>
        /// <param name="Ptcliente"></param>
        /// <param name="Pidtransportista"></param>
        /// <param name="Psucursal"></param>
        /// <param name="Pidcliente"></param>
        /// <returns>lista Trasportemodel</returns>
        public List<CateringModel> ConsultaTransporte(string Pdesde, string Phasta, string Ptcliente, int Pidtransportista, int Psucursal, int Pidcliente)
        {
            DateTime fechahasta = DateTime.Now;
            string query = "";
            string condiciones = "";

            //valido las fechas
            if (!(string.IsNullOrEmpty(Pdesde)) & !(string.IsNullOrWhiteSpace(Pdesde)))
            //cuando viene una fecha desde
            {
                //si no viene la fecha hasta pongo la fecha de hoy
                if (string.IsNullOrEmpty(Phasta) || string.IsNullOrWhiteSpace(Phasta))
                {
                    Phasta = fechahasta.ToString("dd/MM/yyyy");
                }
                condiciones += " AND CONVERT(date, C.fecha,103) BETWEEN CAST('{Pdesde}' AS date) AND CAST('{Phasta}' AS date) ";
            }
            //valido el tipo cliente
            if (!(string.IsNullOrEmpty(Ptcliente)) & !(string.IsNullOrWhiteSpace(Ptcliente)))
            {
                condiciones += " AND C.tipo_cliente = '{Ptcliente}' ";
            }
            //valido el id_transportista
            if (Pidtransportista > 0)
            {
                condiciones += " AND C.tipo_menu = '{Ptmenu}' ";
            }
            //valido la sucursal
            if (Psucursal > 0)
            {
                if (nivel <= 1) //solo el nivel administrador puede consultar cualquier sucursal
                { condiciones += " AND C.sucursal = {Psucursal} "; }
                else
                { condiciones += " AND C.sucursal = {sucursal} "; } //los otros niveles solo consultan su propia sucursal
            }
            else //no se ha seleccionado sucursal
            {
                if (nivel > 1)  //para cualquier otro nivel de usuario se envia su propia sucursal
                { condiciones += " AND C.sucursal = {sucursal} "; }
            }
            //valido el Id cliente
            if (Pidcliente > 0)
            {
                condiciones += " AND C.fk_id_cliente = {Pidcliente} ";
            }

            //armo el select con las opciones dadas

            if (string.IsNullOrEmpty(Ptcliente)) //Cuando la consulta NO es por Tipo Cliente
            {
                query = $"SELECT DISTINCT T.id_transporte, T.fk_id_cliente, C.nombre, T.tipo_cliente, T.fecha, T.hora, T.id_transportista, T.entrada_salida, T.observacion, T.sucursal, T.usuario, T.fecha_mod " +
                        $"FROM Transporte T LEFT JOIN Cliente C ON T.fk_id_cliente = C.id_cliente  WHERE tipo_cliente = 'Cliente' " +
                        $"'{condiciones}'" +
                        $"UNION " +
                        $"SELECT DISTINCT T.id_transporte, T.fk_id_cliente, B.nombre, T.tipo_cliente, T.fecha, T.hora, T.id_transportista, T.entrada_salida, T.observacion, T.sucursal, T.usuario, T.fecha_mod " +
                        $"FROM Transporte T LEFT JOIN Colaborador B ON T.fk_id_cliente = B.id_colaborador  WHERE tipo_cliente = 'Colaborador' " +
                        $"'{condiciones}' ";
            }
            else //cuando se consulta por tipo cliente
            {
                switch (Ptcliente)
                {
                    case "Cliente":
                        query = $"SELECT DISTINCT T.id_transporte, T.fk_id_cliente, C.nombre, T.tipo_cliente, T.fecha, T.hora, T.id_transportista, T.entrada_salida, T.observacion, T.sucursal, T.usuario, T.fecha_mod " +
                                $"FROM Transporte T LEFT JOIN Cliente C ON T.fk_id_cliente = C.id_cliente  WHERE tipo_cliente = 'Cliente' " +
                                $"'{condiciones}' ORDER BY T.sucursal, T.fecha";
                        break;
                    case "Colaborador":
                        query = $"SELECT DISTINCT T.id_transporte, T.fk_id_cliente, B.nombre, T.tipo_cliente, T.fecha, T.hora, T.id_transportista, T.entrada_salida, T.observacion, T.sucursal, T.usuario, T.fecha_mod " +
                                $"FROM Transporte T LEFT JOIN Colaborador B ON T.fk_id_cliente = B.id_colaborador  WHERE tipo_cliente = 'Colaborador' " +
                                $"'{condiciones}' ORDER BY T.sucursal, T.fecha";                   
                        break;
                }
            }
            List<CateringModel> cateringModelList = new List<CateringModel>();
            //Las consultas siempre retornan el obtejo dentro de una lista.
            cateringModelList = this.ObtenerListaSQL<CateringModel>(query).ToList();
            return cateringModelList;
        }
    }
}
