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
    //para gestionar la tabla Usuario
    public class UsuarioBO
    {
        public static int nivel = VariablesGlobales.Nivel;
        public static int sucursal = VariablesGlobales.sucursal;

        /// <summary>
        /// Devuelve lista de los Niveles de Usuario y su Descripción
        /// </summary>
        /// <returns>Lista los niveles de usuario y su descripción</returns>
        public List<CodigosNiveles> LoadNiveles()
        {
            string query = "";
            query = $"SELECT valor1 as niveles, descripcion FROM Codigo WHERE grupo = \'GEN\' AND subgrupo = \'USUARIO\' AND elemento <> \'\' AND estado = \'A\' AND valor1 > 0";
            List<CodigosNiveles> Niveleslist = new List<CodigosNiveles>();
            Niveleslist = this.ObtenerListaSQL<CodigosNiveles>(query).ToList();

            return Niveleslist;
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
        /// Lista la información de la tabla Usuario para los niveles mayores a cero (No gestión del Sistema) validando el nivel del usuario
        /// </summary>
        /// <returns>Lista tabla usuario</returns>
        public List<UsuarioModel> ConsultaUsuarios(int Psucursal, string Pestado)
        {
            string query = "";
            string condiciones = "";

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

            List<UsuarioModel> UsuariosList = new List<UsuarioModel>();

            if (nivel <= 1) //nivel administrador o gestor
            {
                //armo el select con las opciones dadas          
                query = $"SELECT * FROM Usuario WHERE nivel > 0 {condiciones}" +
                        $"ORDER BY usuario";  //solo los usuarios nivel > 0
            
                //Las consultas siempre retornan el obtejo dentro de una lista.
                UsuariosList = this.ObtenerListaSQL<UsuarioModel>(query).ToList();
            }
            return UsuariosList;
        }

        private string ValidaDuplicado(UsuarioModel usuarioModel)
        {
            string msg = "";
            string query = ""; 
            query = $"SELECT * FROM Usuario WHERE usuario = '{usuarioModel.Usuario}'";  

            List<UsuarioModel> UsuariosList = new List<UsuarioModel>();
            //Las consultas siempre retornan el obtejo dentro de una lista.
            UsuariosList = this.ObtenerListaSQL<UsuarioModel>(query).ToList();
            if (UsuariosList.Count > 0)
            {
                msg = "Registro Duplicado. Ya existe este Usuario";
                return msg;
            }
            else
            {
                return msg;
            }
        }

        /// <summary>
        /// Inserta un regsitro en la tabla Usuario
        /// </summary>
        /// <param name="usuarioModel"></param>
        /// <returns></returns>
        public string InsertUsuario(UsuarioModel usuarioModel)
        {
            string msg = "";
            //valido en nivel del usuario que va a añadir el registro
            if (nivel <= 1) //nivel administrador o gestor
            {
                msg = usuarioModel.LoadUsuarioModel(usuarioModel); //valida los datos según el modelo
                if (msg == "")
                {
                    msg = ValidaDuplicado(usuarioModel); //valida duplicados
                    if (!string.IsNullOrEmpty(msg))
                    {
                        return msg;
                    }
                    else
                    {
                        string query = $"INSERT INTO Usuario (usuario, clave, nivel, descripcion, estado, sucursal, observacion, fecha_mod)" +
                                       $" VALUES ('{usuarioModel.Usuario}', '{usuarioModel.Clave}', {usuarioModel.Nivel}, '{usuarioModel.Descripcion}', '{usuarioModel.Estado}', " +
                                       $"{usuarioModel.Sucursal}, '{usuarioModel.Observacion}', '{usuarioModel.Fecha_mod}')";
                        try
                        {
                            bool execute = SQLConexionDataBase.Execute(query);
                            if (execute)
                            { msg = "OK"; }
                            return msg;
                        }
                        catch (SqlException ex)
                        {
                            msg = "Error al insertar usuario " + ex.Message;
                            return msg;
                        }
                    }
                }
                else
                {
                    return msg;
                }
            }
            else
            {
                msg = "No está autorizado a añadir registro";
                return msg;
            }
        }


        /// <summary>
        /// Modifica tabla Usuario (clave, nivel, descripcion, estado, sucursal, observacion, fecha_mod)
        /// </summary>
        /// <param name="usuarioModel"></param>
        /// <returns></returns>
        public string ActualizarUsuario(UsuarioModel usuarioModel)
        {
            string msg = "";
            //valido en nivel del usuario que va a añadir el registro
            if (nivel <= 1) //nivel administrador o gestor
            {
                msg = usuarioModel.LoadUsuarioModel(usuarioModel); //valida los datos según el modelo
                if (msg == "")
                {
                    string query = $"UPDATE Usuario SET clave = '{usuarioModel.Clave}', nivel = {usuarioModel.Nivel}, descripcion = '{usuarioModel.Descripcion}', " +
                                   $"estado = '{usuarioModel.Estado}', sucursal = {usuarioModel.Sucursal}, observacion = '{usuarioModel.Observacion}', " +
                                   $"fecha_mod = '{usuarioModel.Fecha_mod}' WHERE id_usuario = {usuarioModel.Id_usuario}";

                    try
                    {
                        bool execute = SQLConexionDataBase.Execute(query);
                        if (execute)
                        { msg = "OK"; }
                        return msg;
                    }
                    catch (SqlException ex)
                    {
                        msg = "Error al modificar usuario " + ex.Message;
                        return msg;
                    }
                }
                else
                { return msg; }
            }
            else
            {
                msg = "No está autorizado a modificar registro";
                return msg;
            }
        }

        /// <summary>
        /// Elimina registrro de la tabla Usuario
        /// </summary>
        /// <param name="usuarioModel"></param>
        /// <returns></returns>
        public string EliminarUsuario(UsuarioModel usuarioModel)
        {
            string mensaje = string.Empty;

            if (nivel <= 1) //solo usuario administrador puede eliminar
            {
                string query = $"DELETE FROM Usuario WHERE id_usuario = {usuarioModel.Id_usuario} ";
                try
                {
                    bool execute = SQLConexionDataBase.Execute(query);
                    if (execute)
                    { mensaje = "OK"; } 
                    return mensaje;
                }
                catch (SqlException ex)
                {
                    mensaje = "Error al eliminar Usuario " + ex.Message;
                    return mensaje;
                }
            }
            else
            {
                mensaje = "No está autorizado a eliminar registro";
                return mensaje;
            }
        }


        /// <summary>
        /// Clase para los niveles de usuario
        /// </summary>
        public class CodigosNiveles
        {
            public int Niveles { get; set; }
            public string Descripcion { get; set; }
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
