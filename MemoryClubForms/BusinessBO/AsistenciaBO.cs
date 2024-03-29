﻿using MemoryClubForms.Data;
using MemoryClubForms.Models;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryClubForms.BusinessBO
{
    /// <summary>
    /// Clase para gestionar la tabla Asistencia
    /// </summary>
    public class AsistenciaBO
    {
        public static int nivel = VariablesGlobales.Nivel;
        public static int sucursal = VariablesGlobales.sucursal;
        public static string usuario = VariablesGlobales.usuario;
        CultureInfo ci = new CultureInfo("en-US");

        /// <summary>
        /// Consulta la lista de usuarios
        /// </summary>
        /// <returns></returns>
        public List<NombresUsuarios> LoadUsuarios()
        {
            string query = $"SELECT id_usuario, usuario FROM Usuario";

            List<NombresUsuarios> nombresList = new List<NombresUsuarios>();

            //Las consultas siempre retornan el obtejo dentro de una lista.
            nombresList = this.ObtenerListaSQL<NombresUsuarios>(query).ToList();

            return nombresList;
        }

        /// <summary>
        /// Consulta la lista de clientes
        /// </summary>
        /// <returns></returns>
        public List<NombresClientes> LoadClientes()
        {
            string query = "";

            if (nivel <= 1)
            {
                 query = $"SELECT id_Cliente, nombre, sucursal FROM Cliente WHERE estado <> \'I\'";
            }
            else
            {
                query = $"SELECT id_Cliente, nombre, sucursal FROM Cliente WHERE sucursal = {sucursal} AND estado <> \'I\'";
            }
            
            List<NombresClientes> nombresList = new List<NombresClientes>();
            //Las consultas siempre retornan el obtejo dentro de una lista.
            nombresList = this.ObtenerListaSQL<NombresClientes>(query).ToList();

            return nombresList.OrderBy(x => x.nombre).ToList();
        }

        /// <summary>
        /// Consulta la Lista de Códigos de las Sucursales
        /// </summary>
        /// <returns></returns>
        public List<CodigosSucursales> LoadSucursales()
        {
            string query = "";
            query = $"SELECT valor1 as sucursales FROM Codigo WHERE grupo = \'SUC\' AND subgrupo = \'SUC\' AND elemento <> \'\' AND estado = \'A\'";
            List<CodigosSucursales> codigosSucursaleslist = new List<CodigosSucursales>();
            codigosSucursaleslist = this.ObtenerListaSQL<CodigosSucursales>(query).ToList();

            return codigosSucursaleslist;
        }

        /// <summary>
        /// Devuelve la lista de los estados y descripción para los clientes (A, I, P = prueba)
        /// </summary>
        /// <returns></returns>
        public List<CodigosEstados> LoadEstados()
        {
            string query = "";
            query = $"SELECT elemento as estados, descripcion from Codigo WHERE grupo = \'CLI\' AND subgrupo = \'ESTADO\' AND elemento <> \'\' AND estado = \'A\'";
            List<CodigosEstados> codigosEstadoslist = new List<CodigosEstados>();
            codigosEstadoslist = this.ObtenerListaSQL<CodigosEstados>(query).ToList();

            return codigosEstadoslist;
        }

        /// <summary>
        /// CONSULTA GENERAL DE ASISTENCIA POR TODOS LOS PARAMETROS
        /// </summary>
        /// <param name="Pdesde"></param>
        /// <param name="Phasta"></param>
        /// <param name="Psucursal"></param>
        /// <param name="Pidcliente"></param>
        /// <param name="Pestado"></param>
        /// <returns>lista</returns>
        public List<AsistenciaModel> ConsultaAsistencia(string Pdesde, string Phasta, int Psucursal, int Pidcliente, string Pestado)
        {
            DateTime fechadesde = DateTime.Now;
            DateTime fechahasta = DateTime.Now;
            string query = "";
            string condiciones = "";
            
            //valido las fechas - cuando no viene una fecha desde busco 30 días atrás
            if (string.IsNullOrEmpty(Pdesde) || string.IsNullOrWhiteSpace(Pdesde))
            {
                fechadesde = fechadesde.AddDays(-30);
                Pdesde = fechadesde.ToString("MM/dd/yyyy", ci);
            }
                     
            //si no viene la fecha hasta pongo la fecha de hoy
            if (string.IsNullOrEmpty(Phasta) || string.IsNullOrWhiteSpace(Phasta))
            {
                Phasta = fechahasta.ToString("MM/dd/yyyy", ci);
            }

            if (!(string.IsNullOrEmpty(Pdesde)) & !(string.IsNullOrEmpty(Phasta)))
            {
                condiciones += $" WHERE CONVERT(date, A.fecha,101) BETWEEN CAST('{Pdesde}' AS date) AND CAST('{Phasta}' AS date) ";
            }

            //valido la sucursal
            if (Psucursal > 0)
            {
                if (nivel <= 1) //solo el nivel administrador puede consultar cualquier sucursal
                { condiciones += $" AND A.sucursal = {Psucursal} "; }
                else
                { condiciones += $" AND A.sucursal = {sucursal} "; } //los otros niveles solo consultan su propia sucursal
            }
            else //no se ha seleccionado sucursal
            {
                if (nivel > 1)  //para cualquier otro nivel de usuario se envia su propia sucursal
                { condiciones += $" AND A.sucursal = {sucursal} "; }
            }
            //valido el Id cliente
            if (Pidcliente > 0)
            {
                condiciones += $" AND A.fk_id_cliente = {Pidcliente} ";
            }
           
            //valido el ESTADO
            if (!(string.IsNullOrEmpty(Pestado)))
            {
                condiciones += $" AND C.estado = '{Pestado}' ";
            }

            //armo el select con las opciones dadas
            query = $"SET LANGUAGE us_english " +
                $"SELECT A.id_asistencia, A.fk_id_cliente, C.nombre, A.fecha, A.hora, A.observacion, A.sucursal, A.usuario, A.fecha_mod, C.estado, CONVERT(date, A.fecha,101) fechahora " +
            $"FROM Asistencia A JOIN Cliente C ON A.fk_id_cliente = C.id_cliente " +
            $"{condiciones}";


            List<AsistenciaModel> asistenciaModelList = new List<AsistenciaModel>();
            //Las consultas siempre retornan el obtejo dentro de una lista.
            asistenciaModelList = this.ObtenerListaSQL<AsistenciaModel>(query).ToList();
            return asistenciaModelList.OrderBy(x => x.Fechahora).ToList();

        }

        /// <summary>
        /// recuperar información de asistencia por periodo de fechas
        /// </summary>
        /// <param name="Pdesde"></param>
        /// <param name="Phasta"></param>
        /// <returns></returns>
        public List<AsistenciaModel> ConsultarPeriodoAsis(string Pdesde, string Phasta)
        {
            DateTime fechadesde = DateTime.Now;
            DateTime fechahasta = DateTime.Now;
            string query = "";
            if (string.IsNullOrEmpty(Pdesde) || string.IsNullOrWhiteSpace(Pdesde))
            //cuando no viene una fecha desde, toma la fecha de hoy menos 30 días
            {
                fechadesde = fechadesde.AddDays(-30);
                Pdesde = fechadesde.ToString("MM/dd/yyyy", ci);
            }
            //si fecha hasta es blanco o nula pone en fecha hasta la fecha de hoy
            if (string.IsNullOrEmpty(Phasta) || string.IsNullOrWhiteSpace(Phasta))
            {
                Phasta = fechahasta.ToString("MM/dd/yyyy", ci);
            }
            //
            if (nivel <= 1) // los usuarios que pueden gestionar todas las sucursales
            {
                query = $"SET LANGUAGE us_english " +
                        $"SELECT A.id_asistencia, A.fk_id_cliente, C.nombre, A.fecha, A.hora, A.observacion, A.sucursal, A.usuario, A.fecha_mod, C.estado, CONVERT(date, A.fecha,101) fechahora " +
                        $"FROM Asistencia A JOIN Cliente C ON A.fk_id_cliente = C.id_cliente WHERE CONVERT(date, A.fecha,101) BETWEEN " +
                        $"CAST('{Pdesde}' AS date) AND CAST('{Phasta}' AS date) ORDER BY A.sucursal, fechahora ASC";
            }
            else
            {
                query = $"SET LANGUAGE us_english " +
                        $"SELECT A.id_asistencia, A.fk_id_cliente, C.nombre, A.fecha, A.hora, A.observacion, A.sucursal, A.usuario, A.fecha_mod, C.estado, CONVERT(date, A.fecha,101) fechahora " +
                        $"FROM Asistencia A JOIN Cliente C ON A.fk_id_cliente = C.id_cliente WHERE A.sucursal = {sucursal}" +
                        $" AND (CONVERT(date,A.fecha,101) BETWEEN CAST('{Pdesde}' AS date) AND CAST('{Phasta}' AS date)) ORDER BY fechahora ASC";
            }

            List<AsistenciaModel> asistenciaModelList = new List<AsistenciaModel>();
            //Las consultas siempre retornan el obtejo dentro de una lista.
            asistenciaModelList = this.ObtenerListaSQL<AsistenciaModel>(query).ToList();
            return asistenciaModelList;
        }

        /// <summary>
        /// Recupera información de Asistencia por Id Cliente
        /// </summary>
        /// <param name="pfk_id_cliente"></param>
        /// <returns></returns>
        public List<AsistenciaModel> ConsultarIdclienteAsis(int pfk_id_cliente)
        {
            string query = "";
            if (nivel <= 1) // los usuarios que pueden gestionar todas las sucursales
            {
                query = $"SET LANGUAGE us_english " +
                        $"SELECT A.id_asistencia, A.fk_id_cliente, C.nombre, A.fecha, A.hora, A.observacion, A.sucursal, A.usuario, A.fecha_mod, C.estado, CONVERT(date, A.fecha,101) fechahora " +
                        $"FROM Asistencia A JOIN Cliente C ON A.fk_id_cliente = C.id_cliente WHERE A.fk_id_cliente = {pfk_id_cliente}  ORDER BY fechahora ASC";
            }
            else
            {
                query = $"SET LANGUAGE us_english " +
                        $"SELECT A.id_asistencia, A.fk_id_cliente, C.nombre, A.fecha, A.hora, A.observacion, A.sucursal, A.usuario, A.fecha_mod, C.estado, CONVERT(date, A.fecha,101) fechahora " +
                        $"FROM Asistencia A JOIN Cliente C ON A.fk_id_cliente = C.id_cliente WHERE A.sucursal = {sucursal} " +
                        $"AND A.fk_id_cliente = {pfk_id_cliente} ORDER BY fechahora ASC";
            }

            List<AsistenciaModel> asistenciaModelList = new List<AsistenciaModel>();
            //Las consultas siempre retornan el obtejo dentro de una lista.
            asistenciaModelList = this.ObtenerListaSQL<AsistenciaModel>(query).ToList();
            return asistenciaModelList;
        }
        
        /// <summary>
        /// RECUPERAR ASISTENCIA POR PERIODO Y ID CLIENTE
        /// </summary>
        /// <param name="Pdesde"></param>
        /// <param name="Phasta"></param>
        /// <param name="pfk_id_cliente"></param>
        /// <returns></returns>
        public List<AsistenciaModel> ConsultarPeriodoIdCliente(string Pdesde, string Phasta, int pfk_id_cliente)
        {
            DateTime fechadesde = DateTime.Now;
            DateTime fechahasta = DateTime.Now;
            string query = "";

            if (string.IsNullOrEmpty(Pdesde) || string.IsNullOrWhiteSpace(Pdesde))
            //cuando no viene una fecha desde, toma la fecha de hoy menos 30 días
            {
                fechadesde = fechadesde.AddDays(-30);
                Pdesde = fechadesde.ToString("MM/dd/yyyy", ci);
            }
            //si fecha hasta es blanco o nula pone en fecha hasta la fecha de hoy
            if (string.IsNullOrEmpty(Phasta) || string.IsNullOrWhiteSpace(Phasta))
            {
                Phasta = fechahasta.ToString("MM/dd/yyyy", ci);
            }
            if (nivel <= 1) // los usuarios que pueden gestionar todas las sucursales
            {
                query = $"SET LANGUAGE us_english " +
                        $"SELECT A.id_asistencia, A.fk_id_cliente, C.nombre, A.fecha, A.hora, A.observacion, A.sucursal, A.usuario, A.fecha_mod, C.estado, CONVERT(date, A.fecha,101) fechahora " +
                        $"FROM Asistencia A JOIN Cliente C ON A.fk_id_cliente = C.id_cliente WHERE CONVERT(date, A.fecha,101) BETWEEN " +
                        $"CAST('{Pdesde}' AS date) AND CAST('{Phasta}' AS date) AND A.fk_id_cliente = {pfk_id_cliente}  ORDER BY A.sucursal, fechahora ASC";
            }
            else
            {
                query = $"SET LANGUAGE us_english " +
                        $"SELECT A.id_asistencia, A.fk_id_cliente, C.nombre, A.fecha, A.hora, A.observacion, A.sucursal, A.usuario, A.fecha_mod, C.estado, CONVERT(date, A.fecha,101) fechahora " +
                        $"FROM Asistencia A JOIN Cliente C ON A.fk_id_cliente = C.id_cliente WHERE CONVERT(date, A.fecha,101) BETWEEN " +
                        $"CAST('{Pdesde}' AS date) AND CAST('{Phasta}' AS date) AND A.sucursal = {sucursal} AND A.fk_id_cliente = {pfk_id_cliente} " +
                        $"ORDER BY fechahora ASC";
            }

            List<AsistenciaModel> asistenciaModelList = new List<AsistenciaModel>();
            //Las consultas siempre retornan el obtejo dentro de una lista.
            asistenciaModelList = this.ObtenerListaSQL<AsistenciaModel>(query).ToList();
            return asistenciaModelList;
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
        /// Valida que no se duplique una registro en Asistencia
        /// </summary>
        /// <param name="asistenciaModel"></param>
        /// <returns>bool True/False</returns>
        public bool ValidarDuplicadoAsis(AsistenciaModel asistenciaModel)
        {
            string query = $"SET LANGUAGE us_english " +
                           $"SELECT * FROM Asistencia WHERE fk_id_cliente = {asistenciaModel.Fk_id_cliente} AND CONVERT(date, fecha,101) = CAST('{asistenciaModel.Fecha}' AS date)";

            List<AsistenciaModel> nombresList = new List<AsistenciaModel>();
            //Las consultas siempre retornan el obtejo dentro de una lista.
            nombresList = this.ObtenerListaSQL<AsistenciaModel>(query).ToList();

            if (nombresList.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }

        /// <summary>
        /// Valida que pueda insertar asistencia dependiendo de la sucursal
        /// </summary>
        /// <param name="asistenciaModel"></param>
        /// <returns>bool TRUE/FALSE</returns>
        public bool ValidaSucursalAsis(AsistenciaModel asistenciaModel)
        {
            if (nivel > 1) //nivel general solo inserta registros de su misma sucursal
            {
                if (sucursal != asistenciaModel.Sucursal)
                { return false; }  //error no puede insertar registro
                else
                { return true; }   //ok puede insertar registro
            }
            else
            { return true; } //ok puede insertar para cualquier sucursal
                
        }

        /// <summary>
        /// Actualiza en la tabla calendario la asistencia cambiando el estado del registro a Completo
        /// </summary>
        /// <param name="asistenciaModel"></param>
        /// <returns>true/false</returns>
        private bool ActualizaCalendario(AsistenciaModel asistenciaModel)
        {
            //busca si hay un registro en el calendario para ese cliente, con un plan vigente y en la fecha dada
            string query = $"SET LANGUAGE us_english " +
                           $"SELECT id_calendario FROM Calendario C INNER JOIN Planes P ON fk_id_plan = id_plan " +
                           $"WHERE P.estado = 'VIGENTE' AND C.fk_id_cliente = {asistenciaModel.Fk_id_cliente} AND CONVERT(date, C.fecha, 101) = CAST('{asistenciaModel.Fecha}' AS date)";

            List<Calendarios> calendariosList = new List<Calendarios>();
            calendariosList = this.ObtenerListaSQL<Calendarios>(query).ToList();
            int ll_i = 0;
            ll_i = calendariosList.Count;

            if (ll_i > 0) //si encontró la fecha reservada en el calendario
            {
                ll_i--;
                var idcalendario = calendariosList[ll_i].Id_calendario;
                //actualiza el estado del registro del calendario a completo
                query = "";
                query = $"UPDATE Calendario SET estado = 'COMPLETO', usuario = '{asistenciaModel.Usuario}', fecha_mod = '{asistenciaModel.Fecha_mod}' " +
                        $"WHERE id_calendario = {idcalendario} ";
                try
                {
                    bool execute = SQLConexionDataBase.Execute(query);
                    return execute;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error al actualizar calendario", ex.Message);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Insertar registro en Asistencia
        /// </summary>
        /// <param name="asistenciaModel"></param>
        /// <returns>true-false</returns>
        public string InsertarAsistencia(AsistenciaModel asistenciaModel)
        {
            string msg = "";
            bool valida = this.ValidarDuplicadoAsis(asistenciaModel);
            if (valida)
            {
                bool aux = this.ValidaSucursalAsis(asistenciaModel); //solo añade si es de la misma sucursal o es de nivel administrador
                if (aux == true)
                {
                    string query = $"INSERT INTO Asistencia (fk_id_cliente, fecha, hora, observacion, sucursal, usuario, fecha_mod) VALUES ({asistenciaModel.Fk_id_cliente}, " +
                                   $" '{asistenciaModel.Fecha}', '{asistenciaModel.Hora}', '{asistenciaModel.Observacion}', {asistenciaModel.Sucursal}, '{asistenciaModel.Usuario}', " +
                                   $" '{asistenciaModel.Fecha_mod}')";
                    try
                    {
                        bool execute = SQLConexionDataBase.Execute(query);
                        if (execute)
                        { msg = "OK"; }
                        //ActualizaCalendario(asistenciaModel);
                    }
                    catch (SqlException ex)
                    {
                        msg = "Error al insertar Asistencia\n " + ex.Message;
                        return msg;                      
                    }
                }
                else
                {
                    msg = "\nNo puede ingresar asistencia para otra sucursal\n";
                    return msg;
                }
            }
            else
            {
                msg = "\nRegistro Duplicado";
                return msg;
            }
            return msg;
        }

        /// <summary>
        /// Actualizar registro en Asistencia
        /// </summary>
        /// <param name="asistenciaModel"></param>
        /// <returns>true-false</returns>
        public string ActualizarAsistencia(AsistenciaModel asistenciaModel)
        {
            string msg = "";
            bool aux = this.ValidaSucursalAsis(asistenciaModel); //solo modifica si es de la misma sucursal o si es de nivel administrador
            if (aux == true)
            {
                string query = $"UPDATE Asistencia SET hora = '{asistenciaModel.Hora}', observacion = '{asistenciaModel.Observacion}', usuario = '{asistenciaModel.Usuario}', " +
                               $"fecha_mod = '{asistenciaModel.Fecha_mod}' WHERE id_asistencia = {asistenciaModel.Id_asistencia} ";
                try
                {
                    bool execute = SQLConexionDataBase.Execute(query);
                    if (execute)
                    { msg = "OK"; }
                }
                catch (SqlException ex)
                {
                    msg = "Error al actualizar Asistencia\n " + ex.Message;
                    return msg;                   
                }
            }
            else
            {
                msg = "\nNo puede editar asistencia para otra sucursal\n";
                return msg;
            }
            return msg.ToString();
        }

        /// <summary>
        /// Elimina registro de asistencia
        /// </summary>
        /// <param name="Pid_asistencia"></param>
        /// <returns>true-false</returns>
        public bool EliminarAsistencia(int Pid_asistencia)
        {
            if (nivel <= 1) //solo elimina asistencia nivel administrador
                {
                string query = $"DELETE FROM Asistencia WHERE id_asistencia = {Pid_asistencia} ";
                try
                {
                    bool execute = SQLConexionDataBase.Execute(query);
                    return execute;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error al eliminar Asistencia ", ex.Message);
                    return false;
                }
            }
            else
            { return false; }
        }
        /// <summary>
        /// Recibe cadena de id's de asistencia para eliminar d forma masiva los registros de asistencia
        /// </summary>
        /// <param name="Pcadena"></param>
        /// <returns></returns>
        public string EliminarMasivo(string Pcadena)
        {
            string msg = "";
            if (nivel <= 1) //solo elimina asistencia masivamente el nivel administrador
            {
                string query = $"DELETE FROM Asistencia WHERE id_asistencia in {Pcadena} "; //elimina la cadena de Id's
                try
                {
                    bool execute = SQLConexionDataBase.Execute(query);
                    if (execute)
                    { msg = "OK"; }
                }
                catch (SqlException ex)
                {
                    msg = "Error al eliminar Asistencia\n " + ex.Message;
                    return msg;
                }
            }
            else
            {
                msg = "\nUsuario no autorizado\n";
                return msg;
            }
            return msg.ToString();
        }
            

        public class NombresClientes
        {
            public int Id_Cliente { get; set; }
            public string nombre { get; set; }
            public int Sucursal { get; set; }
        }
        public class NombresUsuarios
        {
            public int id_usuario { get; set; }
            public string usuario { get; set; }
        }

        public class CodigosSucursales
        {
            public int Sucursales { get; set; }
        }
        //List Model de los códigos de estado de clientes
        public class CodigosEstados
        {
            public string Estados { get; set; }

            public string Descripcion { get; set; }
        }

        private class Calendarios
        {
            public int Id_calendario { get; set; }
        }
    }
}
