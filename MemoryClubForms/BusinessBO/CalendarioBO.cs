using MemoryClubForms.Data;
using MemoryClubForms.Models;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryClubForms.BusinessBO
{
    //Gestiona la tabla Calendario
    public class CalendarioBO
    {
        int nivel = VariablesGlobales.Nivel;
        int sucursal = VariablesGlobales.sucursal;
        string usuario = VariablesGlobales.usuario;

        /// <summary>
        /// Devuelve los planes vigentes que se usan al insertar un registro en el calendario (id plan, id cliente, nombre cli, sucursal, fecha ini plan, tipo plan, num max dias)
        /// </summary>
        /// <returns>Lista </returns>
        public List<PlanesClientes> LoadPlanesClientes()
        {
            string query = "";

            if (nivel <= 1)
            {
                query = $"SELECT P.id_plan as idplan, P.fk_id_cliente as idcliente, C.nombre as nombres, P.sucursal as sucursales, " +
                        $"P.fecha_inicio_plan as fecha_ini_plan, P.tipo_plan as tipoplan, P.max_dia_plan as max_dias " +
                        $"FROM Planes P INNER JOIN Cliente C ON P.fk_id_cliente = C.id_cliente WHERE P.estado = \'VIGENTE\'";
            }
            else //para los usuarios que no son administradores solo pueden ver los planes de su misma sucursal
            {
                query = $"SELECT P.id_plan as idplan, P.fk_id_cliente as idcliente, C.nombre as nombres, P.sucursal as sucursales, " +
                        $"P.fecha_inicio_plan as fecha_ini_plan, P.tipo_plan as tipoplan, P.max_dia_plan as max_dias " +
                        $"FROM Planes P INNER JOIN Cliente C ON P.fk_id_cliente = C.id_cliente WHERE P.estado = 'VIGENTE' AND P.sucursal = {sucursal}";
            }

            List<PlanesClientes> planesClientesList = new List<PlanesClientes>();

            //Las consultas siempre retornan el obtejo dentro de una lista.
            planesClientesList = this.ObtenerListaSQL<PlanesClientes>(query).ToList();
            return planesClientesList.OrderBy(x => x.Nombres).ToList();
        }

        /// <summary>
        /// Devuelve una lista con los Estados del Calendario
        /// </summary>
        /// <returns></returns>
        public List<EstadosCalend> LoadEstadosCalendario()
        {
            string query = "";
            query = $"SELECT elemento as estados FROM Codigo WHERE grupo = \'CAL\' AND subgrupo = \'ESTADO\' " +
                    $"AND elemento <> \'\' AND  estado = \'A\' ORDER BY elemento";

            List<EstadosCalend> estadosCalendList = new List<EstadosCalend>();
            //Las consultas siempre retornan el obtejo dentro de una lista.
            estadosCalendList = this.ObtenerListaSQL<EstadosCalend>(query).ToList();
            return estadosCalendList;
        }

        public List<TiposPlanes> LoadTiposPlanes()
        {
            string query = "";
            query = $"SELECT elemento as tipoplan, valor1 as num_dias_contratados FROM Codigo WHERE grupo = \'PLN\' AND subgrupo = \'TPLAN\' " +
                    $"AND elemento <> \'\' AND  estado = \'A\' ORDER BY elemento";

            List<TiposPlanes> tiposplanList = new List<TiposPlanes>();
            //Las consultas siempre retornan el obtejo dentro de una lista.
            tiposplanList = this.ObtenerListaSQL<TiposPlanes>(query).ToList();
            return tiposplanList;
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
        /// Consulta de Calendario (fecha desde, hasta, id plan, id cliente, estado)
        /// </summary>
        /// <param name="Pdesde"></param>
        /// <param name="Phasta"></param>
        /// <param name="Pidplan"></param>
        /// <param name="Pidcliente"></param>
        /// <param name="Pestado"></param>
        /// <returns></returns>
        public List<CalendarioModel> ConsultarCalendario(string Pdesde, string Phasta, int Pidplan, int Pidcliente, string Pestado)
        {
            string query = "";
            string condiciones = "";

            if (!(string.IsNullOrEmpty(Pdesde)) & !(string.IsNullOrEmpty(Phasta)))
            {
                condiciones += $" AND CONVERT(date, L.fecha,103) BETWEEN CAST('{Pdesde}' AS date) AND CAST('{Phasta}' AS date) ";
            }
            //valido el plan
            if (Pidplan > 0)
            {
                condiciones += $" AND L.fk_id_plan = {Pidplan} ";  // Si envia un Id plan, se recuperan todos los registros de ese plan si en estado se pone todos
            }
            else
            {
                condiciones += $" AND P.estado = 'VIGENTE'"; // cuando no se envia un plan específico se recuperan solo los calendarios cuyos planes estén vigentes.
            }

            //valido el Id cliente
            if (Pidcliente > 0)
            {
                condiciones += $" AND L.fk_id_cliente = {Pidcliente} ";
            }

            //valido el ESTADO
            if (!(string.IsNullOrEmpty(Pestado)))
            {
                if (Pestado == "RESERVADO" || Pestado == "COMPLETO")
                {
                    condiciones += $" AND L.estado = '{Pestado}' ";
                }
            }

            //armo el select con las opciones dadas
            query = $"SELECT L.id_calendario, L.fk_id_plan, L.fk_id_cliente, C.nombre, L.fecha, L.estado L. usuario, L.fecha_mod FROM Calendario L " +
                    $"INNER JOIN Cliente C ON L.fk_id_cliente = C.id_cliente INNER JOIN Planes P ON L.fk_id_plan = P.id_plan " +
                    $"WHERE L.id_calendario >= 0 {condiciones} ORDER BY C.nombre, L.fk_id_plan, L.fecha";

            List<CalendarioModel> CalenModelList = new List<CalendarioModel>();
            //Las consultas siempre retornan el obtejo dentro de una lista.
            CalenModelList = this.ObtenerListaSQL<CalendarioModel>(query).ToList();
            return CalenModelList.ToList();
        }

        /// <summary>
        /// Valida que la fecha a registrar no sea fin de semana
        /// </summary>
        /// <param name="calendarioModel"></param>
        /// <returns></returns>
        public bool Validafinsemana(CalendarioModel calendarioModel)
        {
            DateTime fechahora = DateTime.ParseExact(calendarioModel.Fecha, "dd/MM/yyyy", null);
            string nombredia = fechahora.ToString("dddd");

            if (nombredia.StartsWith("sá") || nombredia.StartsWith("do") || nombredia.StartsWith("sa") || nombredia.StartsWith("su"))
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        /// <summary>
        /// Validacion de duplicados para el insertar manual (por id plan, id, cliente y fecha)
        /// </summary>
        /// <param name="calendarioModel"></param>
        /// <returns></returns>
        private bool Validaduplicadomanual(CalendarioModel calendarioModel)
        {
            string query = $"SELECT * FROM Calendario WHERE fk_id_cliente = {calendarioModel.Fk_id_cliente} AND " +
                           $"fk_id_plan = {calendarioModel.Fk_id_plan} AND CONVERT(date, fecha,103) = '{calendarioModel.Fecha}'";

            List<CalendarioModel> calendariosList = new List<CalendarioModel>();
            //Las consultas siempre retornan el obtejo dentro de una lista.
            calendariosList = this.ObtenerListaSQL<CalendarioModel>(query).ToList();

            if (calendariosList.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Validacion de duplicados para el insertar automático (por id plan y el id cliente)
        /// </summary>
        /// <param name="Pid_plan"></param>
        /// <param name="Pid_cliente"></param>
        /// <returns></returns>
        private bool Validaduplicadoauto(int Pid_plan, int Pid_cliente)
        {
            string query = $"SELECT * FROM Calendario WHERE fk_id_cliente = {Pid_cliente} AND " +
                           $"fk_id_plan = {Pid_plan} ";

            List<CalendarioModel> calendariosList = new List<CalendarioModel>();
            //Las consultas siempre retornan el obtejo dentro de una lista.
            calendariosList = this.ObtenerListaSQL<CalendarioModel>(query).ToList();

            if (calendariosList.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Obtiene las fechas para generar el calendario en base a los días de la semana dados por el usuario
        /// las fechas se buscan entre la fecha ini plan y la fecha fin (dada por el máx núm de días del plan).
        /// En el Model viene solo id plan, id cliente y en las var los días marcados.
        /// *ESTE METODO FUNCIONA PARA QUE EL CALENDARIO SE GENERE A SEMANA SEGUIDA, SI FUERA PASANDO UNA SEMANA HACERLO MANUALMENTE
        /// </summary>
        /// <returns>string mensaje</returns>
        public async Task<string> InsertarAutomatico(int Pid_plan, int Pid_cliente, string Plunes, string Pmartes, string Pmiercoles, string Pjueves, string Pviernes)
        {
            string msg = string.Empty;
            DateTime fini;
            DateTime ffin;
            DateTime fechaaux;
            DateTime fehoy = DateTime.Now;

            string fechamod = fehoy.ToString("dd/MM/yyyy");

            if (Pid_cliente <= 0 || Pid_plan <= 0)
            {
                msg = $"Id Plan y/o Id Cliente no pueden ser igual a Cero";
                return msg;
            }

            //valida si hay duplicados
            bool aux = Validaduplicadoauto(Pid_plan, Pid_cliente);
            if (!(aux))
            {
                msg = $"¡Error Duplicado!. Ya existe calendario para este plan: {Pid_plan}";
                return msg;
            }
  
            CalendarioModel calendarioModel = new CalendarioModel();

            //recupero lista de tipos de planes
            List<TiposPlanes> tiposPlanes = new List<TiposPlanes>();
            tiposPlanes = LoadTiposPlanes();
            if (tiposPlanes.Count <= 0)
            {
                msg = "No se pudo recuperar Tipos de Planes de la tabla Codigo";
                return msg;
            }

            //recupero lista de los planes vigentes
            List<PlanesClientes> planesClientes = new List<PlanesClientes>();
            planesClientes = LoadPlanesClientes();
            if (planesClientes.Count > 0)
            {
                int index = planesClientes.FindIndex(c => c.Idplan.Equals(Pid_plan));  //busco el indice donde el id_plan sea el del cliente que quiero añadir
                if (index > -1)
                {
                    //leo información del plan
                    var feini_plan = planesClientes.ElementAt(index).Fecha_ini_plan;
                    var max_num_dias = planesClientes.ElementAt(index).Max_dias; //el número de días de vigencia del plan
                    var tipoplan = planesClientes.ElementAt(index).Tipoplan;
                    //calculo la fecha fin
                    fini = DateTime.ParseExact(feini_plan, "dd/MM/yyyy", null);
                    ffin = fini.AddDays(max_num_dias);
                    //recupero el número días contratados según el plan (tabla código, ej: plan paquete: 20 días contratados)
                    int indice = tiposPlanes.FindIndex(x => x.Equals(tipoplan));
                    if (indice > -1)
                    {
                        //leo los días contratados
                        var dias_contratados = tiposPlanes.ElementAt(indice).Num_dias_contratados;
                        if (dias_contratados == 0 )
                        {
                            dias_contratados = 9999;    //si dias contratados = 0, entonces se cambia a 9999 para que solo se ejecute el ciclo para el rango de fechas
                        }

                        int nveces = 0;
                        fechaaux = fini;
                        //se ejecuta hasta que el numero de veces sea igual o mayor a los dias contratados o hasta que la fecha auxiliar sea igual a la fecha fin
                        while (fechaaux <= ffin & nveces < dias_contratados)
                        {
                            calendarioModel = new CalendarioModel();
                            //busco los días seleccionados por el usuario en este rango de fechas
                            if (!(string.IsNullOrEmpty(Plunes)))
                            {
                                if (fechaaux.DayOfWeek == DayOfWeek.Monday)
                                {
                                    nveces++; //ya estaría tomado un día de los contratados
                                    //Genero datos para el calendadio
                                    calendarioModel.Fk_id_plan = Pid_plan;
                                    calendarioModel.Fk_id_cliente = Pid_cliente;
                                    calendarioModel.Fecha = fechaaux.ToString("dd/MM/yyyy");    //asigno la fecha que coincide con un lunes dentro del rango de fechas
                                    calendarioModel.Estado = "RESERVADO";
                                    calendarioModel.Usuario = usuario;
                                    calendarioModel.Fecha_mod = "fechamod";
                                    string response = InsertarCalendarioBdd(calendarioModel);
                                    if (response != "OK")
                                    {
                                        msg = "No se pudo recuperar Tipos de Planes de la tabla Codigo";
                                        return msg;
                                    }
                                }
                            }

                            fechaaux = fechaaux.AddDays(1);
                            
                        }


                    }
                    else
                    {
                        msg = $"No se encontró el tipo de plan {tipoplan} en la tabla Codigo.";
                        return msg;
                    }
                }
            }
            else
            {
                msg = "No se pudo recuperar Planes Vigentes";
                return msg;
            }
            return msg;
        }

        /// <summary>
        /// Insertar un registro de Calendario
        /// </summary>
        /// <param name="calendarioModel"></param>
        /// <returns></returns>
        private string InsertarCalendarioBdd(CalendarioModel calendarioModel)
        {
            string msg = calendarioModel.Validate(calendarioModel);
            if (!(string.IsNullOrEmpty(msg)))   //si hay errores en los datos del modelo retorna falso
            {
                return msg;
            }
            else
            {
                 string query = $"INSERT INTO Calendario (fk_id_plan, fk_id_cliente, fecha, estado, usuario, fecha_mod) " +
                                $"VALUES ({calendarioModel.Fk_id_plan}, {calendarioModel.Fk_id_cliente}, '{calendarioModel.Fecha}', " +
                                $"'{calendarioModel.Estado}', '{calendarioModel.Usuario}', '{calendarioModel.Fecha_mod}')";
                try
                {
                    bool execute = SQLConexionDataBase.Execute(query);
                    if (execute)
                    { msg = "OK"; }
                    return msg;
                }
                catch (SqlException ex)
                {

                    msg = "Error al insertar Calendario. " + ex.Message;
                    return msg;
                }

            }
        }


        /// <summary>
        /// Model List para los nombres de los clientes    idplan, P.fk_id_cliente as idcliente, C.nombre as nombres
        /// </summary>
        public class PlanesClientes  
        {
            public int Idplan { get; set; }
            public int Idcliente { get; set; }
            public string Nombres { get; set; }
            public int Sucursales { get; set; }
            public string Fecha_ini_plan { get; set; }
            public string Tipoplan { get; set; }
            public int Max_dias { get; set; }

        }

        /// <summary>
        /// List Model para los estados del plan
        /// </summary>
        public class EstadosCalend
        {
            public string Estados { get; set; }
        }

        /// <summary>
        /// List model de los tipos de planes y los números de días del plan
        /// </summary>
        public class TiposPlanes
        {
            public string Tipoplan { get; set; }
            public int Num_dias_contratados { get; set; }
        }

    }
}
