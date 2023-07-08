using MemoryClubForms.Data;
using MemoryClubForms.Models;
using System.Data.SqlClient;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace MemoryClubForms.BusinessBO
{
    //Para gestionar la tabla Catering
    public class CateringBO
    {
        public static int nivel = VariablesGlobales.Nivel;
        public static int sucursal = VariablesGlobales.sucursal;
        CultureInfo ci = new CultureInfo("en-US");

        /// <summary>
        /// Recupera en una lista los nombres de los clientes NO INACTIVOS
        /// </summary>
        /// <returns>Lista </returns>
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
        /// Retorna una lista de Tipos de Clientes
        /// </summary>
        /// <returns></returns>
        public List<TiposClientes> LoadTiposClientes()
        {
            string query = "";

            query = $"SELECT elemento as tipoCliente  FROM Codigo WHERE grupo = \'GEN\' AND subgrupo = \'TCLIENTE\' " +
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

            query = $"SELECT elemento as tipoMenu FROM Codigo WHERE grupo = \'CAT\' AND subgrupo = \'TMENU\' " +
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
            query = $"SELECT valor1 as sucursales FROM Codigo WHERE grupo = \'SUC\' AND subgrupo = \'SUC\' AND elemento <> \'\' AND estado = \'A\'";
            List<CodigosSucursales> codigosSucursaleslist = new List<CodigosSucursales>();
            codigosSucursaleslist = this.ObtenerListaSQL<CodigosSucursales>(query).ToList();

            return codigosSucursaleslist;
        }


        /// <summary>
        /// Devuelve lista de id colaboradores y sus nombres
        /// </summary>
        /// <returns></returns>
        public List<NombresColaboradores> LoadNombresColaboradores()
        {
            string query = "";
            query = $"SELECT id_colaborador, nombre, sucursal FROM Colaborador WHERE estado = \'A\'";
            List<NombresColaboradores> nombrescolaboradoresList = new List<NombresColaboradores>();
            nombrescolaboradoresList = this.ObtenerListaSQL<NombresColaboradores>(query).ToList();

            return nombrescolaboradoresList.OrderBy(x => x.nombre).ToList();
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
        public List<CateringModel> ConsultaCatering(string Pdesde, string Phasta, string Ptcliente, string Ptmenu, int Psucursal, int Pidcliente, string Pestado)
        {
            DateTime fechadesde = DateTime.Now;
            DateTime fechahasta = DateTime.Now;
            string query = "";
            string condiciones = "";
            string condiciones_aux = "";

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
                condiciones += $" AND CONVERT(date, C.fecha,101) BETWEEN CAST('{Pdesde}' AS date) AND CAST('{Phasta}' AS date) ";
            }
                        
            //valido el tipo cliente
            if (!(string.IsNullOrEmpty(Ptcliente)) & !(string.IsNullOrWhiteSpace(Ptcliente)))
            {
                condiciones += $" AND C.tipo_cliente = '{Ptcliente}' ";
            }
            //valido el tipo menu
            if (!(string.IsNullOrEmpty(Ptmenu)) & !(string.IsNullOrWhiteSpace(Ptmenu)))
            {
                condiciones += $" AND C.tipo_menu = '{Ptmenu}' ";
            }
            //valido la sucursal
            if (Psucursal > 0)
            {
                if (nivel <= 1) //solo el nivel administrador puede consultar cualquier sucursal
                { condiciones += $" AND C.sucursal = {Psucursal} "; }
                else
                { condiciones += $" AND C.sucursal = {sucursal} "; } //los otros niveles solo consultan su propia sucursal
            }
            else //no se ha seleccionado sucursal
            {
                if (nivel > 1)  //para cualquier otro nivel de usuario se envia su propia sucursal
                { condiciones += $" AND C.sucursal = {sucursal} "; }
            }
            //valido el Id cliente
            if (Pidcliente > 0)
            {
                condiciones += $" AND C.fk_id_cliente = {Pidcliente} ";
            }
            //******asigno al final a condiciones_aux el valor de condiciones antes de añadir el estado
            condiciones_aux = condiciones;

            //valido el ESTADO
            if (!(string.IsNullOrEmpty(Pestado)))
            {
                condiciones += $" AND L.estado = '{Pestado}' ";
                condiciones_aux  += $" AND B.estado = '{Pestado}' ";
            }

            //armo el select con las opciones dadas

            if (string.IsNullOrEmpty(Ptcliente)) //Cuando la consulta NO es por Tipo Cliente
            {
                query = $"SET LANGUAGE us_english " +
                        $"SELECT DISTINCT C.id_catering, C.fk_id_cliente, L.nombre, C.tipo_cliente, C.tipo_menu, C.fecha, C.hora, C.observacion, C.sucursal, C.usuario, C.fecha_mod, L.estado, CONVERT(date, C.fecha,101) fechahora " + 
                        $"FROM Catering C LEFT JOIN Cliente L ON C.fk_id_cliente = L.id_cliente WHERE C.tipo_cliente = \'CLIENTE\' " +
                        $"{condiciones}" +
                        $"UNION " +
                        $"SELECT DISTINCT C.id_catering, C.fk_id_cliente, B.nombre, C.tipo_cliente, C.tipo_menu, C.fecha, C.hora, C.observacion, C.sucursal, C.usuario, C.fecha_mod, B.estado, CONVERT(date, C.fecha,101) fechahora " +
                        $"FROM Catering C LEFT JOIN Colaborador B ON C.fk_id_cliente = B.id_colaborador WHERE C.tipo_cliente = \'COLABORADOR\' " +
                        $"{condiciones_aux}";
            }
            else //cuando se consulta por tipo cliente
            {
                switch (Ptcliente)
                {
                    case "CLIENTE":
                        query = $"SET LANGUAGE us_english " +
                                $"SELECT DISTINCT C.id_catering, C.fk_id_cliente, L.nombre, C.tipo_cliente, C.tipo_menu, C.fecha, C.hora, C.observacion, C.sucursal, C.usuario, C.fecha_mod, L.estado, CONVERT(date, C.fecha,101) fechahora " +
                                $"FROM Catering C LEFT JOIN Cliente L ON C.fk_id_cliente = L.id_cliente WHERE C.id_catering >= 0 " +
                                $"{condiciones} ORDER BY C.sucursal, C.fecha";
                        break;
                    case "COLABORADOR":
                        query = $"SET LANGUAGE us_english " +
                                $"SELECT DISTINCT C.id_catering, C.fk_id_cliente, B.nombre, C.tipo_cliente, C.tipo_menu, C.fecha, C.hora, C.observacion, C.sucursal, C.usuario, C.fecha_mod, B.estado, CONVERT(date, C.fecha,101) fechahora " +
                                $"FROM Catering C LEFT JOIN Colaborador B ON C.fk_id_cliente = B.id_colaborador WHERE C.id_catering >= 0 " +
                                $"{condiciones_aux} ORDER BY C.sucursal, C.fecha";
                        break;
                }
            }

            List<CateringModel> cateringModelList = new List<CateringModel>();
            //Las consultas siempre retornan el obtejo dentro de una lista.
            cateringModelList = this.ObtenerListaSQL<CateringModel>(query).ToList();
            return cateringModelList.OrderBy(x=>x.Fechahora).ToList();
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
        public string InsertarCatering(CateringModel PcateringModel)
        {
            string msg = "";
            msg = PcateringModel.Validate(PcateringModel);
            if (!(string.IsNullOrEmpty(msg)))   //si hay errores en los datos del modelo retorna falso
            {
                return msg;
            }
            else
            {
                bool aux = ValidarSucursalCate(PcateringModel); //valida que colaborador pueda registrar catering si es de la misma sucursal si no es de nivel <= 1
                if (aux == true)
                {
                    string query = $"INSERT INTO Catering (fk_id_cliente, tipo_cliente, tipo_menu, fecha, hora, observacion, sucursal, usuario, fecha_mod) " +
                                  $"VALUES ({PcateringModel.Fk_id_cliente}, '{PcateringModel.Tipo_cliente}', '{PcateringModel.Tipo_menu}', '{PcateringModel.Fecha}', '{PcateringModel.Hora}', " +
                                  $"'{PcateringModel.Observacion}', {PcateringModel.Sucursal}, '{PcateringModel.Usuario}', '{PcateringModel.Fecha_mod}')";

                    try
                    {
                        bool execute = SQLConexionDataBase.Execute(query);
                        if (execute)
                        { msg = "OK"; }
                    }
                    catch (SqlException ex)
                    {
                        msg = "error " + ex.Message;
                        return msg;
                    }
                }
                else
                {
                    msg = "No puede ingresar catering para otra sucursal";
                    return msg;
                }
            }
            return msg;
        }
        /// <summary>
        /// ACTUALIZA UN REGISTRO DE CATERING
        /// </summary>
        /// <param name="PcateringModel"></param>
        /// <returns>bool True/False</returns>
        public string ActualizarCatering(CateringModel PcateringModel)
        {
            string msg = "";
            msg = PcateringModel.Validate(PcateringModel);
            if (!(string.IsNullOrEmpty(msg)))   //si hay errores en los datos del modelo retorna falso
            {
                return msg;
            }
            else
            {
                bool aux = ValidarSucursalCate(PcateringModel); //valida que colaborador pueda modificar catering si es de la misma sucursal si no es de nivel <= 1
                if (aux == true)
                {
                    string query = $"UPDATE Catering SET tipo_menu = '{PcateringModel.Tipo_menu}', fecha = '{PcateringModel.Fecha}' , hora = '{PcateringModel.Hora}', observacion = '{PcateringModel.Observacion}', " +
                               $"usuario = '{PcateringModel.Usuario}', fecha_mod = '{PcateringModel.Fecha_mod}' WHERE id_catering = {PcateringModel.Id_catering}";

                    try
                    {
                        bool execute = SQLConexionDataBase.Execute(query);
                        if (execute)
                        { msg = "OK"; }
                    }
                    catch (SqlException ex)
                    {
                        msg = "Error al actualizar Catering\n" + ex.Message;
                        return msg;
                    }
                }
                else
                {
                    msg = "No puede modificar catering para otra sucursal";
                    return msg;
                }
            }
            return msg;
        }
        /// <summary>
        /// ELIMINA UN REGISTRO DE CATERING
        /// </summary>
        /// <param name="Pid_catering"></param>
        /// <returns>bool True/False</returns>
        public bool EliminarCatering(int Pid_catering)
        {
            if (nivel <= 1) //solo usuario administrador elimina catering
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
            else
            { return false; }

        }

        /// <summary>
        /// Recibe cadena de id's de catering para eliminar d forma masiva los registros de catering
        /// </summary>
        /// <param name="Pcadena"></param>
        /// <returns></returns>
        public string EliminarCateringMasivo(string Pcadena)
        {
            string msg = "";
            if (nivel <= 1) //solo elimina catering masivamente el nivel administrador
            {
                string query = $"DELETE FROM Catering WHERE id_catering in {Pcadena} "; //elimina la cadena de Id's de catering
                try
                {
                    bool execute = SQLConexionDataBase.Execute(query);
                    if (execute)
                    { msg = "OK"; }
                }
                catch (SqlException ex)
                {
                    msg = "Error al eliminar Catering\n " + ex.Message;
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

        /// <summary>
        /// Model List para los nombres de los clientes
        /// </summary>
        public class NombresClientes
        {
            public int Id_Cliente { get; set; }
            public string nombre { get; set; }
            public int Sucursal { get; set; }
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
            public int Sucursales { get; set; }
        }
        public class NombresColaboradores
        {
            public int Id_colaborador { get; set; }
            public string nombre { get; set; }
            public int Sucursal { get; set; }
        }
        //List Model de los códigos de estado de clientes
        public class CodigosEstados
        {
            public string Estados { get; set; }

            public string Descripcion { get; set; }
        }
    }
}
