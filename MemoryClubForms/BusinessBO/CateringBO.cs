using MemoryClubForms.Data;
using MemoryClubForms.Models;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryClubForms.BusinessBO
{
    //Para gestionar la tabla Catering
    internal class CateringBO
    {
        int nivel = VariablesGlobales.Nivel;
        int sucursal = VariablesGlobales.sucursal;
        /// <summary>
        /// ´RECUPERA INFORMACION DE CATERING POR PERIODO
        /// </summary>
        /// <param name="Pdesde"></param>
        /// <param name="Phasta"></param>
        /// <returns></returns>
        public List<CateringModel> ConsultaPeriodoCater(string Pdesde, string Phasta)
        {
            DateTime fechadesde = DateTime.Now;
            DateTime fechahasta = DateTime.Now;
            string query = "";

            if (string.IsNullOrEmpty(Pdesde) || string.IsNullOrWhiteSpace(Pdesde))
            //cuando no viene una fecha desde, toma la fecha de hoy menos 30 días
            {
                fechadesde = fechadesde.AddDays(-30);
                Pdesde = fechadesde.ToString("dd/MM/yyyy");
            }
            //si fecha hasta es blanco o nula pone en fecha hasta la fecha de hoy
            if (string.IsNullOrEmpty(Phasta) || string.IsNullOrWhiteSpace(Phasta))
            {
                Phasta = fechahasta.ToString("dd/MM/yyyy");
            }
            //
            if (nivel <= 1) // los usuarios que pueden gestionar todas las sucursales
            {
                query = $"SELECT DISTINCT C.id_catering, C.fk_id_cliente, L.nombre, C.tipo_cliente, C.tipo_menu, C.fecha, C.hora, C.observacion, C.sucursal, C.usuario, C.fecha_mod " +
                        $"FROM Catering C LEFT JOIN Cliente L ON C.fk_id_cliente = L.id_cliente WHERE CONVERT(date, C.fecha,103) BETWEEN CAST('{Pdesde}' AS date) AND CAST('{Phasta}' AS date) " +
                        $"AND C.tipo_cliente = \'Cliente\' " +
                        $"UNION " +
                        $"SELECT DISTINCT C.id_catering, C.fk_id_cliente, B.nombre, C.tipo_cliente, C.tipo_menu, C.fecha, C.hora, C.observacion, C.sucursal, C.usuario, C.fecha_mod " +
                        $"FROM Catering C LEFT JOIN Colaborador B ON C.fk_id_cliente = B.id_colaborador WHERE CONVERT(date, C.fecha,103) BETWEEN CAST('{Pdesde}' AS date) AND CAST('{Phasta}' AS date) " +
                        $"AND C.tipo_cliente = \'Colaborador\' ORDER BY C.sucursal";
            }
            else //se recupera de acuerdo a la sucursal del usuario que está consultando
            {
                query = $"SELECT DISTINCT C.id_catering, C.fk_id_cliente, L.nombre, C.tipo_cliente, C.tipo_menu, C.fecha, C.hora, C.observacion, C.sucursal, C.usuario, C.fecha_mod " +
                        $"FROM Catering C LEFT JOIN Cliente L ON C.fk_id_cliente = L.id_cliente WHERE CONVERT(date, C.fecha,103) BETWEEN CAST('{Pdesde}' AS date) AND CAST('{Phasta}' AS date) " +
                        $"AND C.sucursal = {sucursal} AND C.tipo_cliente = \'Cliente\' " +
                        $"UNION " +
                        $"SELECT DISTINCT C.id_catering, C.fk_id_cliente, B.nombre, C.tipo_cliente, C.tipo_menu, C.fecha, C.hora, C.observacion, C.sucursal, C.usuario, C.fecha_mod " +
                        $"FROM Catering C LEFT JOIN Colaborador B ON C.fk_id_cliente = B.id_colaborador WHERE CONVERT(date, C.fecha,103) BETWEEN CAST('{Pdesde}' AS date) AND CAST('{Phasta}' AS date) " +
                        $"AND C.sucursal = {sucursal} AND C.tipo_cliente = \'Colaborador\' ORDER BY C.sucursal";
            }
            List<CateringModel> cateringModelList = new List<CateringModel>();
            //Las consultas siempre retornan el obtejo dentro de una lista.
            cateringModelList = this.ObtenerListaSQL<CateringModel>(query).ToList();
            return cateringModelList;
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
        /// <summary>
        /// RECUPERAR CATERING POR TIPO CLIENTE
        /// </summary>
        /// <param name="Ptipo_cliente"></param>
        /// <returns></returns>
        public List<CateringModel> ConsultaTipoCliente(string Ptipo_cliente)
        {
            string query = "";
            if (nivel <= 1) // los usuarios que pueden gestionar todas las sucursales
            {
                switch (Ptipo_cliente)
                {
                    case "Cliente":
                        query = $"SELECT DISTINCT C.id_catering, C.fk_id_cliente, L.nombre, C.tipo_cliente, C.tipo_menu, C.fecha, C.hora, C.observacion, C.sucursal, C.usuario, C.fecha_mod " +
                                $"FROM Catering C LEFT JOIN Cliente L ON C.fk_id_cliente = L.id_cliente WHERE C.tipo_cliente = '{Ptipo_cliente}' ORDER BY C.sucursal, C.fecha";
                        break;
                    case "Colaborador":
                        query = $"SELECT DISTINCT C.id_catering, C.fk_id_cliente, B.nombre, C.tipo_cliente, C.tipo_menu, C.fecha, C.hora, C.observacion, C.sucursal, C.usuario, C.fecha_mod " +
                                $"FROM Catering C LEFT JOIN Colaborador B ON C.fk_id_cliente = B.id_colaborador WHERE C.tipo_cliente = '{Ptipo_cliente}' ORDER BY C.sucursal, C.fecha";
                        break;
                }
            }
            else
            {
                switch (Ptipo_cliente)
                {
                    case "Cliente":
                        query = $"SELECT DISTINCT C.id_catering, C.fk_id_cliente, L.nombre, C.tipo_cliente, C.tipo_menu, C.fecha, C.hora, C.observacion, C.sucursal, C.usuario, C.fecha_mod " +
                                $"FROM Catering C LEFT JOIN Cliente L ON C.fk_id_cliente = L.id_cliente WHERE C.sucursal = {sucursal} AND C.tipo_cliente = '{Ptipo_cliente}' ORDER BY C.fecha";
                        break;
                    case "Colaborador":
                        query = $"SELECT DISTINCT C.id_catering, C.fk_id_cliente, B.nombre, C.tipo_cliente, C.tipo_menu, C.fecha, C.hora, C.observacion, C.sucursal, C.usuario, C.fecha_mod " +
                                $"FROM Catering C LEFT JOIN Colaborador B ON C.fk_id_cliente = B.id_colaborador WHERE C.sucursal = {sucursal} AND C.tipo_cliente = '{Ptipo_cliente}' ORDER BY C.fecha";
                        break;
                }
            }
            List<CateringModel> cateringModelList = new List<CateringModel>();
            //Las consultas siempre retornan el obtejo dentro de una lista.
            cateringModelList = this.ObtenerListaSQL<CateringModel>(query).ToList();
            return cateringModelList;
        }

        /// <summary>
        /// CONSULTA GENERAL POR VARIOS PARAMETROS DE LA TABLA CATERING
        /// </summary>
        /// <param name="Pdesde"></param>
        /// <param name="Phasta"></param>
        /// <param name="Ptcliente"></param>
        /// <param name="Ptmenu"></param>
        /// <param name="Psucursal"></param>
        /// <param name="Pidcliente"></param>
        /// <returns></returns>
        public List<CateringModel> ConsultaCatering(string Pdesde, string Phasta, string Ptcliente, string Ptmenu, int Psucursal, int Pidcliente)
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
            //valido el tipo menu
            if (!(string.IsNullOrEmpty(Ptmenu)) & !(string.IsNullOrWhiteSpace(Ptmenu)))
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
                query = $"SELECT DISTINCT C.id_catering, C.fk_id_cliente, L.nombre, C.tipo_cliente, C.tipo_menu, C.fecha, C.hora, C.observacion, C.sucursal, C.usuario, C.fecha_mod " +
                        $"FROM Catering C LEFT JOIN Cliente L ON C.fk_id_cliente = L.id_cliente WHERE C.tipo_cliente = \'Cliente\' " +
                        $"'{condiciones}'" +
                        $"UNION " +
                        $"SELECT DISTINCT C.id_catering, C.fk_id_cliente, B.nombre, C.tipo_cliente, C.tipo_menu, C.fecha, C.hora, C.observacion, C.sucursal, C.usuario, C.fecha_mod " +
                        $"FROM Catering C LEFT JOIN Colaborador B ON C.fk_id_cliente = B.id_colaborador WHERE C.tipo_cliente = \'Colaborador\' " +
                        $"'{condiciones}' ORDER BY C.sucursal";
            }
            else //cuando se consulta por tipo cliente
            {
                switch (Ptcliente)
                {
                    case "Cliente":
                        query = $"SELECT DISTINCT C.id_catering, C.fk_id_cliente, L.nombre, C.tipo_cliente, C.tipo_menu, C.fecha, C.hora, C.observacion, C.sucursal, C.usuario, C.fecha_mod " +
                                $"FROM Catering C LEFT JOIN Cliente L ON C.fk_id_cliente = L.id_cliente WHERE C.id_catering > 0 " +
                                $"'{condiciones}' ORDER BY C.sucursal, C.fecha";
                        break;
                    case "Colaborador":
                        query = $"SELECT DISTINCT C.id_catering, C.fk_id_cliente, B.nombre, C.tipo_cliente, C.tipo_menu, C.fecha, C.hora, C.observacion, C.sucursal, C.usuario, C.fecha_mod " +
                                $"FROM Catering C LEFT JOIN Colaborador B ON C.fk_id_cliente = B.id_colaborador WHERE C.id_catering > 0 " +
                                $"'{condiciones}' ORDER BY C.sucursal, C.fecha";
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
