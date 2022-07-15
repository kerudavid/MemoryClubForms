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
        /// Recupera en una lista los nombres de los clientes Activos
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
            return nombresList;
        }
        /// <summary>
        /// Devuelve una lista con los Tipos de Clientes
        /// </summary>
        /// <returns></returns>
        public List<TiposClientes> LoadTiposClientes()
        {
            string query = "";

            query = $"SELECT elemento as tipoCliente FROM Codigo WHERE grupo = \'GEN\' AND subgrupo = \'TCLIENTE\' " +
                    $"AND elemento <> \'\' AND estado = \'A\'";

            List<TiposClientes> tiposclientesList = new List<TiposClientes>();

            //Las consultas siempre retornan el obtejo dentro de una lista.
            tiposclientesList = this.ObtenerListaSQL<TiposClientes>(query).ToList();
            return tiposclientesList;
        }
        /// <summary>
        /// Devuelve una lista con los Id y Nombres de los Transportistas Activos
        /// </summary>
        /// <returns></returns>
        public List<NombresTransportistas> LoadNombresTransportistas()
        {
            string query = "";

            query = $"SELECT id_transportista, nombre FROM Transportista WHERE estado = \'A\'";

            List<NombresTransportistas> nombresTransportistasList = new List<NombresTransportistas>();

            //Las consultas siempre retornan el obtejo dentro de una lista.
            nombresTransportistasList = this.ObtenerListaSQL<NombresTransportistas>(query).ToList();
            return nombresTransportistasList;
        }
        /// <summary>
        /// Devuelve una lista con los horarios de transporte (Entrada/Salida)
        /// </summary>
        /// <returns></returns>
        public List<HorariosTransporte> LoadHorariosTransporte()
        {
            string query = "";

            query = $"SELECT elemento as horario FROM Codigo WHERE grupo = \'TRA\' AND subgrupo = \'HORAES\' AND elemento <> \'\' AND estado = \'A\'";

            List<HorariosTransporte> horariosTransporteList = new List<HorariosTransporte>();

            //Las consultas siempre retornan el obtejo dentro de una lista.
            horariosTransporteList = this.ObtenerListaSQL<HorariosTransporte>(query).ToList();
            return horariosTransporteList;
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

            return nombrescolaboradoresList;
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
        /// Consulta general por varios parámetros de la tabla Transporte
        /// </summary>
        /// <param name="Pdesde"></param>
        /// <param name="Phasta"></param>
        /// <param name="Ptcliente"></param>
        /// <param name="Pidtransportista"></param>
        /// <param name="Psucursal"></param>
        /// <param name="Pidcliente"></param>
        /// <returns>lista Trasportemodel</returns>
        public List<TransporteModel> ConsultaTransporte(string Pdesde, string Phasta, string Ptcliente, int Pidtransportista, int Psucursal, int Pidcliente, string Pestado)
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
                Pdesde = fechadesde.ToString("dd/MM/yyyy");
            }

            //si no viene la fecha hasta pongo la fecha de hoy
            if (string.IsNullOrEmpty(Phasta) || string.IsNullOrWhiteSpace(Phasta))
            {
                Phasta = fechahasta.ToString("dd/MM/yyyy");
            }
            //armo condiciones con las fechas
            
            if (!(string.IsNullOrEmpty(Pdesde)) & !(string.IsNullOrEmpty(Phasta)))
            {
                condiciones += $" AND CONVERT(date, T.fecha,103) BETWEEN CAST('{Pdesde}' AS date) AND CAST('{Phasta}' AS date) ";
            }

            //valido el tipo cliente
            if (!(string.IsNullOrEmpty(Ptcliente)) & !(string.IsNullOrWhiteSpace(Ptcliente)))
            {
                condiciones += $" AND T.tipo_cliente = '{Ptcliente}' ";
            }
            //valido el id_transportista
            if (Pidtransportista > 0)
            {
                condiciones += $" AND T.id_transportista = '{Pidtransportista}' ";
            }
            //valido la sucursal
            if (Psucursal > 0)
            {
                if (nivel <= 1) //solo el nivel administrador puede consultar cualquier sucursal
                { condiciones += $" AND T.sucursal = {Psucursal} "; }
                else
                { condiciones += $" AND T.sucursal = {sucursal} "; } //los otros niveles solo consultan su propia sucursal
            }
            else //no se ha seleccionado sucursal
            {
                if (nivel > 1)  //para cualquier otro nivel de usuario se envia su propia sucursal
                { condiciones += $" AND T.sucursal = {sucursal} "; }
            }
            //valido el Id cliente
            if (Pidcliente > 0)
            {
                condiciones += $" AND T.fk_id_cliente = {Pidcliente} ";
            }

            //******asigno al final a condiciones_aux el valor de condiciones antes de añadir el estado ********************
            condiciones_aux = condiciones;

            //valido el ESTADO
            if (!(string.IsNullOrEmpty(Pestado)))
            {
                condiciones += $" AND C.estado = '{Pestado}' ";
                condiciones_aux += $" AND B.estado = '{Pestado}' ";
            }

            //armo el select con las opciones dadas

            if (string.IsNullOrEmpty(Ptcliente)) //Cuando la consulta NO es por Tipo Cliente
            {
                query = $"SELECT DISTINCT T.id_transporte, T.fk_id_cliente, C.nombre, T.tipo_cliente, T.fecha, T.hora, T.id_transportista, X.nombre as nombre_tra, " +
                        $"T.entrada_salida, T.observacion, T.sucursal, T.usuario, T.fecha_mod, C.estado, CONVERT(date, T.fecha,103) fechahora " +
                        $"FROM Transporte T LEFT JOIN Cliente C ON T.fk_id_cliente = C.id_cliente  " +
                        $"LEFT JOIN Transportista X ON T.id_transportista = X.id_transportista WHERE tipo_cliente = 'CLIENTE' " +
                        $"{condiciones}" +
                        $"UNION " +
                        $"SELECT DISTINCT T.id_transporte, T.fk_id_cliente, B.nombre, T.tipo_cliente, T.fecha, T.hora, T.id_transportista, X.nombre as nombre_tra, " +
                        $"T.entrada_salida, T.observacion, T.sucursal, T.usuario, T.fecha_mod, B.estado, CONVERT(date, T.fecha,103) fechahora " +
                        $"FROM Transporte T LEFT JOIN Colaborador B ON T.fk_id_cliente = B.id_colaborador " +
                        $"LEFT JOIN Transportista X ON T.id_transportista = X.id_transportista WHERE tipo_cliente = 'COLABORADOR' " +
                        $"{condiciones_aux} ";
            }
            else //cuando se consulta por tipo cliente
            {
                switch (Ptcliente)
                {
                    case "CLIENTE":
                        query = $"SELECT DISTINCT T.id_transporte, T.fk_id_cliente, C.nombre, T.tipo_cliente, T.fecha, T.hora, T.id_transportista, X.nombre as nombre_tra, " +
                            $"T.entrada_salida, T.observacion, T.sucursal, T.usuario, T.fecha_mod, C.estado, CONVERT(date, T.fecha,103) fechahora " +
                                $"FROM Transporte T LEFT JOIN Cliente C ON T.fk_id_cliente = C.id_cliente " +
                                $"LEFT JOIN Transportista X ON T.id_transportista = X.id_transportista  WHERE id_transporte >= 0 " +
                                $"{condiciones} ORDER BY T.sucursal";
                        break;
                    case "COLABORADOR":
                        query = $"SELECT DISTINCT T.id_transporte, T.fk_id_cliente, B.nombre, T.tipo_cliente, T.fecha, T.hora, T.id_transportista, X.nombre as nombre_tra, " +
                            $"T.entrada_salida, T.observacion, T.sucursal, T.usuario, T.fecha_mod, B.estado, CONVERT(date, T.fecha,103) fechahora " +
                                $"FROM Transporte T LEFT JOIN Colaborador B ON T.fk_id_cliente = B.id_colaborador " +
                                $"LEFT JOIN Transportista X ON T.id_transportista = X.id_transportista WHERE id_transporte >= 0 " +
                                $"{condiciones_aux} ORDER BY T.sucursal";                   
                        break;
                }
            }
            List<TransporteModel> transporteModelList = new List<TransporteModel>();
            //Las consultas siempre retornan el obtejo dentro de una lista.
            transporteModelList = this.ObtenerListaSQL<TransporteModel>(query).ToList();
            return transporteModelList.OrderBy(x => x.Fechahora).ToList();
        }

        /// <summary>
        /// Valida que pueda insertar transporte dependiendo de la sucursal
        /// </summary>
        /// <param name="PtransporteModel"></param>
        /// <returns></returns>
        private bool ValidarSucursalTransp(TransporteModel PtransporteModel)
        {
            if (nivel > 1) //nivel general solo inserta registros de su misma sucursal
            {
                if (sucursal != PtransporteModel.Sucursal)
                { return false; }  //error no puede insertar registro
                else
                { return true; }   //ok puede insertar registro
            }
            else
            { return true; } //ok puede insertar cualquier sucursal
        }

        /// <summary>
        /// Inserta registro en Transporte
        /// </summary>
        /// <param name="PtransporteModel"></param>
        /// <returns></returns>
        public bool InsertarTransporte(TransporteModel PtransporteModel)
        {
            string msg = PtransporteModel.Validate(PtransporteModel);
            if (!(string.IsNullOrEmpty(msg)))   //si hay errores en los datos del modelo retorna falso
            {
                return false;
            }
            else
            {
                bool aux = ValidarSucursalTransp(PtransporteModel); //solo puede insertar si es de su misma sucursal un usuario nivel > 1
                if (aux == true)
                {
                    string query = $"INSERT INTO Transporte (fk_id_cliente, tipo_cliente, fecha, hora, id_transportista, entrada_salida, observacion, sucursal, usuario, fecha_mod) " +
                               $"VALUES ({PtransporteModel.Fk_id_cliente}, '{PtransporteModel.Tipo_cliente}', '{PtransporteModel.Fecha}', '{PtransporteModel.Hora}', " +
                               $"{PtransporteModel.Id_transportista}, '{PtransporteModel.Entrada_salida}', '{PtransporteModel.Observacion}', {PtransporteModel.Sucursal}, " +
                               $"'{PtransporteModel.Usuario}', '{PtransporteModel.Fecha_mod}')";

                    try
                    {
                        bool execute = SQLConexionDataBase.Execute(query);
                        return execute;
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("Error al insertar  Transporte", ex.Message);
                        return false;
                    }
                }
                else
                { return false; }
            }
        }
      
        /// <summary>
        /// Actualiza un registro de Transporte, fecha, hora, entrada/salida, observación, usuario, fecha_mod
        /// </summary>
        /// <param name="PtransporteModel"></param>
        /// <returns></returns>
        public bool ActualizarTransporte(TransporteModel PtransporteModel)
        {
            string msg = PtransporteModel.Validate(PtransporteModel);
            if (!(string.IsNullOrEmpty(msg)))   //si hay errores en los datos del modelo retorna falso
            {
                return false;
            }
            else
            {
                bool aux = ValidarSucursalTransp(PtransporteModel); //solo puede insertar si es de su misma sucursal un usuario nivel > 1
                if (aux == true)
                {
                    string query = $"UPDATE Transporte SET fecha = '{PtransporteModel.Fecha}', hora = '{PtransporteModel.Hora}', entrada_salida = '{PtransporteModel.Entrada_salida}', " +
                                   $"observacion = '{PtransporteModel.Observacion}', usuario = '{PtransporteModel.Usuario}', fecha_mod = '{PtransporteModel.Fecha_mod}' " +
                                   $"WHERE id_transporte = {PtransporteModel.Id_transporte}";
                    try
                    {
                        bool execute = SQLConexionDataBase.Execute(query);
                        return execute;
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("Error al actualizar Transporte", ex.Message);
                        return false;
                    }
                }
                else
                { return false; }
            }
        }

        /// <summary>
        /// Eliminar registro de Transporte
        /// </summary>
        /// <param name="Pid_transporte"></param>
        /// <returns>True-False</returns>
        public bool EliminarTransporte(int Pid_transporte)
        {
            if (nivel <= 1) //solo usuario administrador elimina transporte
            {
                string query = $"DELETE FROM Transporte WHERE id_transporte = {Pid_transporte} ";
                try
                {
                    bool execute = SQLConexionDataBase.Execute(query);
                    return execute;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error al eliminar Transporte", ex.Message);
                    return false;
                }
            }
            else
            { return false;  }
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
        /// Model List de los Tipos de Clientes
        /// </summary>
        public class TiposClientes
        {
            public string TipoCliente { get; set; }
        }
        /// <summary>
        /// Model List de los Id y Nombres de Transportistas
        /// </summary>
        public class NombresTransportistas
        {
            public int Id_transportista { get; set; }
            public string Nombre { get; set; }
        }
        public class CodigosSucursales
        {
            public int Sucursales { get; set; }
        }
        /// <summary>
        /// Model List de los horarios de transporte (Entrada/Salida)
        /// </summary>
        public class HorariosTransporte
        {
            public string Horario { get; set; }
        }
        //List Model de los nombres de los colaboradores
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
