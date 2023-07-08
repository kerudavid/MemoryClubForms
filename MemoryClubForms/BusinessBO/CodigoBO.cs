using MemoryClubForms.Data;
using MemoryClubForms.Models;
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
    //Gestionar la tabla Codigos (Parametros)
    public class CodigoBO
    {
        public static int nivel = VariablesGlobales.Nivel;
        public static int sucursal = VariablesGlobales.sucursal;
        CultureInfo ci = new CultureInfo("en-US");

        /// <summary>
        /// Recupera los parámetros seleccionados por el usuario
        /// </summary>
        /// <returns>Lista </returns>
        public List<TiposParametros> LoadTiposParame()
        {
            string query = "";
            query = $"SELECT id_codigo, grupo, subgrupo, descripcion FROM Codigo where grupo in (\'CLI\', \'TRA\') " +
                $"and subgrupo in (\'ALIMEN\', \'SALUD\', \'RUTA\', \'SECTOR\') and elemento = \'\' and estado = \'A\'  order by grupo, subgrupo";                  
            List<TiposParametros> TipoParamList = new List<TiposParametros>();
            //Las consultas siempre retornan el obtejo dentro de una lista.
            TipoParamList = this.ObtenerListaSQL<TiposParametros>(query).ToList();
            return TipoParamList;
        }
        /// <summary>
        /// Devuelve lista de los Estados de un registro 'A'/'I'
        /// </summary>
        /// <returns></returns>
        public List<CodigosEstados> LoadEstados()
        {
            string query = "";
            query = $"SELECT elemento as estados, descripcion FROM Codigo WHERE grupo = \'GEN\' AND subgrupo = \'ESTADO\' AND elemento <> \'\' AND estado = \'A\'";
            List<CodigosEstados> codigosEstadoslist = new List<CodigosEstados>();
            codigosEstadoslist = this.ObtenerListaSQL<CodigosEstados>(query).ToList();

            return codigosEstadoslist;
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
        /// Consulta de Parametros manejados por el usuario
        /// </summary>
        /// <param name="Pgrupo"></param>
        /// <param name="Psubgrupo"></param>
        /// <returns></returns>
        public List<CodigoModel> ConsultaParametros(string Pgrupo, string Psubgrupo, string Pestado)
        {
            string query = "";
            string condiciones = "";
            if (!(string.IsNullOrEmpty(Pgrupo)) & !(string.IsNullOrWhiteSpace(Pgrupo)))
            {
                condiciones += $" AND grupo = '{Pgrupo}' ";
            }
            if (!(string.IsNullOrEmpty(Psubgrupo)) & !(string.IsNullOrWhiteSpace(Psubgrupo)))
            {
                condiciones += $" AND subgrupo = '{Psubgrupo}' ";
            }
            if (!(string.IsNullOrEmpty(Pestado)) & !(string.IsNullOrWhiteSpace(Pestado)))
            {
                if (condiciones == "" ) //no se escogió el tipo parámetro, para no mostrar todos los parémetros
                {
                    condiciones = "AND grupo in (\'CLI\', \'TRA\') and subgrupo in (\'ALIMEN\', \'SALUD\', \'RUTA\', \'SECTOR\') ";               
                }
                condiciones += $" AND estado = '{Pestado}' ";

            }
            if (string.IsNullOrEmpty(condiciones))
            {
                query = $"SELECT * FROM Codigo " +
                        $"where grupo in (\'CLI\', \'TRA\') " +
                        $"and subgrupo in (\'ALIMEN\', \'SALUD\', \'RUTA\', \'SECTOR\') and elemento <> \'\'  order by grupo, subgrupo, elemento";
            }
            else
            {
                query = $"SELECT * FROM Codigo where elemento<> \'\' " +
                        $"{condiciones} " +
                        $" order by grupo, subgrupo, elemento ";
            }
            List<CodigoModel>CodigosModelList = new List<CodigoModel>();
            //Las consultas siempre retornan el obtejo dentro de una lista.
            CodigosModelList = this.ObtenerListaSQL<CodigoModel>(query).ToList();
            return CodigosModelList;
        }

        /// <summary>
        /// VALIDAR DUPLICADOS EN TABLA CODIGO
        /// </summary>
        /// <param name="codigoModel"></param>
        /// <returns></returns>
        private bool ValidaParametro(CodigoModel codigoModel)
        {
            string query = $"SELECT * FROM Codigo WHERE grupo = '{codigoModel.Grupo}'" +
                           $" AND subgrupo = '{codigoModel.Subgrupo}' AND elemento = '{codigoModel.Elemento}'";

            List<CodigoModel> CodigosList = new List<CodigoModel>();
            //Las consultas siempre retornan el obtejo dentro de una lista.
            CodigosList = this.ObtenerListaSQL<CodigoModel>(query).ToList();

            if (CodigosList.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// INSERTAR UN PARAMETRO   
        /// </summary>
        /// <param name="codigoModel"></param>
        /// <returns></returns>
        public string InsertarParametro(CodigoModel codigoModel)
        {
            bool valida = true;
            string msg = codigoModel.Validate(codigoModel);
            if (!(string.IsNullOrEmpty(msg)))   //si hay errores en los datos del modelo retorna falso
            {
                return msg;
            }
            else
            {
                valida = this.ValidaParametro(codigoModel); //valida duplicado
                if (valida)
                {
                    string query = $"INSERT INTO Codigo ( grupo,subgrupo,elemento,descripcion,valor1,valor2,estado,usuario,fecha_mod) " +
                                    $"VALUES ('{codigoModel.Grupo}', '{codigoModel.Subgrupo}', '{codigoModel.Elemento}', '{codigoModel.Descripcion}', {codigoModel.Valor1}, " +
                                    $"{codigoModel.Valor2},'{codigoModel.Estado}', '{codigoModel.Usuario}', '{codigoModel.Fecha_mod}')";
                    try
                    {
                        bool execute = SQLConexionDataBase.Execute(query);
                        if (execute)
                        { msg = "OK"; }
                        return msg;
                    }
                    catch (SqlException ex)
                    {

                        msg = "Error al insertar Parámetro " + ex.Message;
                        return msg;
                    }

                }
                else
                {
                    msg = "Ya existe este parámetro, No se añadió este registro";
                    return msg;
                }
            }
        }

        /// <summary>
        /// ACTUALIZAR TABLA CODIGO 
        /// </summary>
        /// <param name="codigoModel"></param>
        /// <returns></returns>
        public string ActualizarParámetro(CodigoModel codigoModel)
        {
            string msg = codigoModel.Validate(codigoModel);
            if (!(string.IsNullOrEmpty(msg)))   //si hay errores en los datos del modelo retorna falso
            {
                return msg;
            }
            else
            {
                string query = $"UPDATE Codigo SET elemento = '{codigoModel.Elemento}', descripcion = '{codigoModel.Descripcion}', estado = '{codigoModel.Estado}', " +
                                $"usuario = '{codigoModel.Usuario}', fecha_mod = '{codigoModel.Fecha_mod}' " +
                                $"WHERE id_codigo = {codigoModel.Id_codigo}";
                try
                {
                    bool execute = SQLConexionDataBase.Execute(query);
                    if (execute)
                    { msg = "OK"; }
                    return msg;
                }
                catch (SqlException ex)
                {
                    msg = "Error al actualizar Parámetro " + ex.Message;
                    return msg;
                }
            }
        }

        //List Model de los tipos de parámetros a los que puede acceder el usuario
        public class TiposParametros
        {
            public int Id_codigo { get; set; }
            public string Grupo { get; set; }
            public string Subgrupo { get; set; }
            public string Descripcion { get; set; }
        }
        //list Model de los estados de un registro
        public class CodigosEstados
        {
            public string Estados { get; set; }
            public string Descripcion { get; set; }
        }

    }
}
