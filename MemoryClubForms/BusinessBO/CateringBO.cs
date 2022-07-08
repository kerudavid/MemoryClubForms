﻿using MemoryClubForms.Data;
using MemoryClubForms.Models;
using System.Data.SqlClient;
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
        /// Recupera en una lista los nombres de los clientes Activos
        /// </summary>
        /// <returns>Lista </returns>
        public List<NombresClientes> LoadClientes()
        {
            string query = "";

            if (nivel <= 1)
            {
                query = $"SELECT id_Cliente, nombre FROM Cliente WHERE estado = \'A\'";
            }
            else
            {
                query = $"SELECT id_Cliente, nombre FROM Cliente WHERE sucursal = {sucursal} AND estado = \'A\'";
            }

            List<NombresClientes> nombresList = new List<NombresClientes>();

            //Las consultas siempre retornan el obtejo dentro de una lista.
            nombresList = this.ObtenerListaSQL<NombresClientes>(query).ToList();
            return nombresList;
        }
        /// <summary>
        /// Retorna una lista de Tipos de Clientes
        /// </summary>
        /// <returns></returns>
        public List<TiposClientes> LoadTiposClientes()
        {
            string query = "";

            query = $"SELECT elemento FROM Codigo WHERE grupo = \'GEN\' AND subgrupo = \'TCLIENTE\' " +
                    $"AND elemento <> \'\' AND estado = \'A\'";

            List<TiposClientes> tiposclientesList = new List<TiposClientes>();

            //Las consultas siempre retornan el obtejo dentro de una lista.
            tiposclientesList = this.ObtenerListaSQL<TiposClientes>(query).ToList();
            return tiposclientesList;
        }
        /// <summary>
        /// Devuelve una lista con los Tipos de Menús
        /// </summary>
        /// <returns>List</returns>
        public List<TiposMenus> LoadTiposMenus()
        {
            string query = "";

            query = $"SELECT elemento FROM Codigo WHERE grupo = \'CAT\' AND subgrupo = \'TMENU\' " +
                    $"AND elemento <> \'\' AND estado = \'A\'";

            List<TiposMenus> tiposmenusList = new List<TiposMenus>();

            //Las consultas siempre retornan el obtejo dentro de una lista.
            tiposmenusList = this.ObtenerListaSQL<TiposMenus>(query).ToList();
            return tiposmenusList;
        }
        /// <summary>
        /// Consulta la Lista de Códigos de las Sucursales
        /// </summary>
        /// <returns></returns>
        public List<CodigosSucursales> LoadSucursales()
        {
            string query = "";
            query = $"SELECT valor1 FROM Codigo WHERE grupo = \'SUC\' AND subgrupo = \'SUC\' AND elemento <> \'\' AND estado = \'A\'";
            List<CodigosSucursales> codigosSucursaleslist = new List<CodigosSucursales>();
            codigosSucursaleslist = this.ObtenerListaSQL<CodigosSucursales>(query).ToList();

            return codigosSucursaleslist;
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
        /// CONSULTA GENERAL POR VARIOS PARAMETROS DE LA TABLA CATERING
        /// </summary>
        /// <param name="Pdesde"></param>
        /// <param name="Phasta"></param>
        /// <param name="Ptcliente"></param>
        /// <param name="Ptmenu"></param>
        /// <param name="Psucursal"></param>
        /// <param name="Pidcliente"></param>
        /// <returns>Lista(CateringModel)</returns>
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
                        $"FROM Catering C LEFT JOIN Cliente L ON C.fk_id_cliente = L.id_cliente WHERE C.tipo_cliente = \'CLIENTE\' " +
                        $"'{condiciones}'" +
                        $"UNION " +
                        $"SELECT DISTINCT C.id_catering, C.fk_id_cliente, B.nombre, C.tipo_cliente, C.tipo_menu, C.fecha, C.hora, C.observacion, C.sucursal, C.usuario, C.fecha_mod " +
                        $"FROM Catering C LEFT JOIN Colaborador B ON C.fk_id_cliente = B.id_colaborador WHERE C.tipo_cliente = \'COLABORADOR\' " +
                        $"'{condiciones}' ORDER BY C.sucursal";
            }
            else //cuando se consulta por tipo cliente
            {
                switch (Ptcliente)
                {
                    case "CLIENTE":
                        query = $"SELECT DISTINCT C.id_catering, C.fk_id_cliente, L.nombre, C.tipo_cliente, C.tipo_menu, C.fecha, C.hora, C.observacion, C.sucursal, C.usuario, C.fecha_mod " +
                                $"FROM Catering C LEFT JOIN Cliente L ON C.fk_id_cliente = L.id_cliente WHERE C.id_catering > 0 " +
                                $"'{condiciones}' ORDER BY C.sucursal, C.fecha";
                        break;
                    case "COLABORADOR":
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

        /// <summary>
        /// Valida que pueda insertar catering dependiendo de la sucursal
        /// </summary>
        /// <param name="PcateringModel"></param>
        /// <returns>bool True/False</returns>
        public bool ValidarSucursalCate(CateringModel PcateringModel)
        {
            if (nivel > 1) //nivel general solo inserta registros de su misma sucursal
            {
                if (sucursal != PcateringModel.Sucursal)
                { return false; }  //error no puede insertar registro
                else
                { return true; }   //ok puede insertar registro
            }
            else
            { return true; } //ok puede insertar cualquier sucursal
        }

        /// <summary>
        /// INSERTA UN REGISTRO DE CATERING
        /// </summary>
        /// <param name="PcateringModel"></param>
        /// <returns>bool TRUE/FALSE</returns>
        public bool InsertarCatering(CateringModel PcateringModel)
        {
             string query = $"INSERT INTO Catering (fk_id_cliente, tipo_cliente, tipo_menu, fecha, hora, observacion, sucursal, usuario, fecha_mod) " +
                           $"VALUES ({PcateringModel.Fk_id_cliente}, '{PcateringModel.Tipo_cliente}', '{PcateringModel.Tipo_menu}', '{PcateringModel.Fecha}', '{PcateringModel.Hora}', " +
                           $"'{PcateringModel.Observacion}', {PcateringModel.Sucursal}, '{PcateringModel.Usuario}', '{PcateringModel.Fecha_mod}')";

            try
            {
                bool execute = SQLConexionDataBase.Execute(query);
                return execute;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error al insertar  catering", ex.Message);
                return false;
            }
            
        }
        /// <summary>
        /// ACTUALIZA UN REGISTRO DE CATERING
        /// </summary>
        /// <param name="PcateringModel"></param>
        /// <returns>bool True/False</returns>
        public bool ActualizarCatering(CateringModel PcateringModel)
        {
            string query = $"UPDATE Catering SET tipo_menu = '{PcateringModel.Tipo_menu}', hora = '{PcateringModel.Hora}', observacion = '{PcateringModel.Observacion}', " +
                           $"usuario = '{PcateringModel.Usuario}', fecha_mod = '{PcateringModel.Fecha_mod}' WHERE id_catering = {PcateringModel.Id_catering}";

            try
            {
                bool execute = SQLConexionDataBase.Execute(query);
                return execute;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error al actualizar catering", ex.Message);
                return false;
            }
        }
        /// <summary>
        /// ELIMINA UN REGISTRO DE CATERING
        /// </summary>
        /// <param name="Pid_catering"></param>
        /// <returns>bool True/False</returns>
        public bool EliminarCatering(int Pid_catering)
        {
            string query = $"DELETE FROM Catering WHERE id_catering = {Pid_catering} ";
            try
            {
                bool execute = SQLConexionDataBase.Execute(query);
                return execute;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error al eliminar catering", ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Model List para los nombres de los clientes
        /// </summary>
        public class NombresClientes
        {
            public int Id_Cliente { get; set; }
            public string nombre { get; set; }
        }
        /// <summary>
        /// Model List para los tipos de clientes
        /// </summary>
        public class TiposClientes
        {
            public string TipoCliente { get; set; }
        }
        /// <summary>
        /// Model List para los tipos de menús
        /// </summary>
        public class TiposMenus
        {
            public string TipoMenu { get; set; }
        }
        public class CodigosSucursales
        {
            public int Codigos_sucursales { get; set; }
        }
    }
}