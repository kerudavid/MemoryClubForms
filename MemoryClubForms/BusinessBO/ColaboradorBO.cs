﻿using MemoryClubForms.Models;
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
    //Gestiona la tabla Colaborador
    public class ColaboradorBO
    {
        public static int nivel = VariablesGlobales.Nivel;
        public static int sucursal = VariablesGlobales.sucursal;

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
        /// Consulta general de la tabla Colaborador
        /// </summary>
        /// <param name="Pidcolaborador"></param>
        /// <param name="Pestado"></param>
        /// <returns></returns>
        public List<ColaboradorModel> ConsultaColaborador(int Pidcolaborador, int Psucursal, string Pestado)
        {
            string query = "";
            string condiciones = "";

            //valido el id_colaborador
            if (Pidcolaborador > 0)
            {
                condiciones += $" AND id_colaborador = {Pidcolaborador} ";
            }
            //valido el estado
            if (Pestado == "T")
            {
                Pestado = string.Empty;
            }
            if (!(string.IsNullOrEmpty(Pestado)))
            {
                condiciones += $" AND estado = '{Pestado}' ";
            }
           
            //valido la sucursal
            if (Psucursal > 0)
            {
                if (nivel <= 1) //solo el nivel administrador puede consultar cualquier sucursal
                { condiciones += $" AND sucursal = {Psucursal} "; }
                else
                { condiciones += $" AND sucursal = {sucursal} "; } //los otros niveles solo consultan su propia sucursal
            }
            else //no se ha seleccionado sucursal
            {
                if (nivel > 1)  //para cualquier otro nivel de usuario se envia su propia sucursal
                { condiciones += $" AND sucursal = {sucursal} "; }
            }

            //armo el select con las opciones dadas          
            query = $"SELECT id_colaborador, sucursal, cedula, nombre, direccion, telefono, cargo, estado, observacion, " +
                    $"usuario, fecha_mod FROM Colaborador WHERE id_colaborador >= 0 {condiciones}";
                       
            List<ColaboradorModel> colaboradorModelList = new List<ColaboradorModel>();
            //Las consultas siempre retornan el obtejo dentro de una lista.
            colaboradorModelList = this.ObtenerListaSQL<ColaboradorModel>(query).ToList();
            return colaboradorModelList; 
        }

        /// <summary>
        /// Valida si se duplica la cédula del colaborador al añadir un registro (cedula)
        /// </summary>
        /// <param name="Pcedula"></param>
        /// <returns>TRUE/FALSE</returns>
        public bool ValidaDuplicadoColab(ColaboradorModel PcolaboradorModel)
        {
            string query = $"SELECT * FROM Colaborador WHERE cedula = '{PcolaboradorModel.Cedula}'";

            List<ColaboradorModel> validalist = new List<ColaboradorModel>();
            //Las consultas siempre retornan el obtejo dentro de una lista.
            validalist = this.ObtenerListaSQL<ColaboradorModel>(query).ToList();

            if (validalist.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Valida que solo un usuario nivel 0 o 1 pueda añadir, modificar o eliminar en la tabla Colaborador
        /// </summary>
        /// <returns>TRUE/FALSE</returns>
        private bool ValidaNivelColab()
        {
            if (nivel <= 1) //solo usuario admonistrador inserta, modifica o elimina colaborador
            { return true; }
            else
            { return false; }
        }

        /// <summary>
        /// Inserta registro de Colaborador
        /// </summary>
        /// <param name="PcolaboradorModel"></param>
        /// <returns>True/False</returns>
        public bool InsertaColaborador(ColaboradorModel PcolaboradorModel)
        {
            string msg = PcolaboradorModel.Validate(PcolaboradorModel);
            if (!(string.IsNullOrEmpty(msg)))   //si hay errores en los datos del modelo retorna falso
            {
                return false;
            }
            else
            {
                bool valida = this.ValidaNivelColab(); //solo nivel administrador puede insertar colaborador
                if (valida)
                {
                    bool aux = this.ValidaDuplicadoColab(PcolaboradorModel); //valida q' no se duplique la cedula
                    if (aux)
                    {
                        string query = $"INSERT INTO Colaborador (sucursal, cedula, nombre, direccion, telefono, cargo, estado, observacion, usuario, fecha_mod ) " +
                                       $" VALUES ({PcolaboradorModel.Sucursal}, '{PcolaboradorModel.Cedula}', '{PcolaboradorModel.Nombre}', '{PcolaboradorModel.Direccion}', " +
                                       $"'{PcolaboradorModel.Telefono}', '{PcolaboradorModel.Cargo}', '{PcolaboradorModel.Estado}', '{PcolaboradorModel.Observacion}', " +
                                       $"'{PcolaboradorModel.Usuario}', '{PcolaboradorModel.Fecha_mod}')";

                        try
                        {
                            bool execute = SQLConexionDataBase.Execute(query);
                            return execute;
                        }
                        catch (SqlException ex)
                        {
                            Console.WriteLine("Error al insertar  Colaborador", ex.Message);
                            return false;
                        }
                    }
                    else
                    { return false; }
                }
                else
                { return false; }
            }
        }

        /// <summary>
        /// Actualiza registro de Colaborador (direcc, tfno, cargo, estado, obs, usuario, fecha_mod)
        /// </summary>
        /// <param name="PcolaboradorModel"></param>
        /// <returns>true/false</returns>
        public bool ActualizarColaborador(ColaboradorModel PcolaboradorModel)
        {
            string msg = PcolaboradorModel.Validate(PcolaboradorModel);
            if (!(string.IsNullOrEmpty(msg)))   //si hay errores en los datos del modelo retorna falso
            {
                return false;
            }
            else
            {
                bool valida = this.ValidaNivelColab(); //solo nivel administrador puede modificar colaborador
                if (valida)
                {
                    string query = $"UPDATE Colaborador SET direccion = '{PcolaboradorModel.Direccion}', telefono = '{PcolaboradorModel.Telefono}', " +
                                   $"cargo = '{PcolaboradorModel.Cargo}', estado = '{PcolaboradorModel.Estado}', observacion = '{PcolaboradorModel.Observacion}', " +
                                   $"usuario = '{PcolaboradorModel.Usuario}', fecha_mod = '{PcolaboradorModel.Fecha_mod}' WHERE id_colaborador = {PcolaboradorModel.Id_colaborador}";

                    try
                    {
                        bool execute = SQLConexionDataBase.Execute(query);
                        return execute;
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("Error al actualizar Colaborador", ex.Message);
                        return false;
                    }
                }
                else
                { return false; }
            }
        }

        /// <summary>
        /// Eliminar registro de Colaborador
        /// </summary>
        /// <param name="Pid_colaborador"></param>
        /// <returns>True/False</returns>
        public bool EliminarColaborador(int Pid_colaborador)
        {
            bool aux = this.ValidaNivelColab(); //solo administrador puede eliminar
            if (aux)    
            {
                string query = $"DELETE FROM Colaborador WHERE id_colaborador = {Pid_colaborador} ";
                try
                {
                    bool execute = SQLConexionDataBase.Execute(query);
                    return execute;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error al eliminar Colaborador", ex.Message);
                    return false;
                }
            }
            else
            { return false; }   
        }

        /// <summary>
        /// List Model de los códigos de sucursales
        /// </summary>
        public class CodigosSucursales
        {
            public int Sucursales { get; set; }
        }

        public class CodigosEstados
        {
            public string Estados { get; set; }
            public string Descripcion { get; set; }
        }
    }
}
