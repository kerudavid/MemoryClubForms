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
        public static int nivel = VariablesGlobales.Nivel;
        public static int sucursal = VariablesGlobales.sucursal;
        public static string usuario = VariablesGlobales.usuario;

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
            query = $"SELECT L.id_calendario, L.fk_id_plan, L.fk_id_cliente, C.nombre, L.fecha, L.estado, " +
                    $"L.usuario, L.fecha_mod, CONVERT(date, L.fecha, 103) as fechahora " +
                    $"FROM Calendario L  INNER JOIN Cliente C ON L.fk_id_cliente = C.id_cliente INNER JOIN Planes P ON L.fk_id_plan = P.id_plan " +
                    $"WHERE L.id_calendario >= 0 {condiciones} ORDER BY C.nombre, L.fk_id_plan, fechahora";

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
        /// Insertar manualmente un registro de calendario, validar string != "OK" es error
        /// </summary>
        /// <param name="calendarioModel"></param>
        /// <returns>msg = "OK"/ "cualquier texto de error"</returns>
        public string InsertaManual(CalendarioModel calendarioModel)
        {
            string msg = "";
            bool aux = Validaduplicadomanual(calendarioModel);
            if (!(aux))
            {
                msg = "Ya existe un registro para este plan, cliente y fecha";
                return msg;
            }

            aux = Validafinsemana(calendarioModel);
            if (!(aux))
            {
                msg = "Error. La fecha seleccionada es sábado o domingo";
                return msg;
            }
            msg = InsertarCalendarioBdd(calendarioModel);
  
            return msg;

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
        /// <param name="Pid_plan"></param>
        /// <param name="Pid_cliente"></param>
        /// <param name="Pdia1" ejemplo "Lunes"></param>
        /// <param name="Pdia2" ejemplo "Miercoles"></param>
        /// <param name="Pdia3" ejemplo "Viernes"></param>
        /// <param name="Pdia4" ejemplo ""></param>
        /// <param name="Pdia5" ejemplo ""></param>
        /// <returns></returns>
        public string InsertarAutomatico(int Pid_plan, int Pid_cliente, string Pdia1, string Pdia2, string Pdia3, string Pdia4, string Pdia5)
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

            //recupero lista de tipos de planes
            List<TiposPlanes> tiposPlanes = new List<TiposPlanes>();
            tiposPlanes = LoadTiposPlanes();
            if (tiposPlanes.Count <= 0)
            {
                msg = "No se pudo recuperar Tipos de Planes de la tabla Codigo";
                return msg;
            }
         
            //inicializo un arreglo con los dias de la semana seleccionados
            string[] dia = new string[5] {Pdia1, Pdia2, Pdia3, Pdia4, Pdia5};

            //recupero lista de los planes vigentes
            List <PlanesClientes> planesClientes = new List<PlanesClientes>();
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
                    int indice = tiposPlanes.FindIndex(x => x.Tipoplan.Equals(tipoplan));
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
                        string mensaje = string.Empty;
                        
                        DateTime primerdia = fini;
                        int contador = 0;
                        //se ejecuta hasta que el numero de veces sea igual o mayor a los dias contratados o hasta que la fecha auxiliar sea igual a la fecha fin
                        while (fechaaux <= ffin & nveces < dias_contratados)
                        {
                            contador++;
                            for (int i = 0; i < 5; i++)    //representa los 5 días de la semana
                            {
                                mensaje = string.Empty;
                                if (fechaaux <= ffin & nveces < dias_contratados)
                                {
                                    // busco los días seleccionados por el usuario en este rango de fechas
                                    switch (dia[i])
                                    {
                                        case "Lunes":
                                            if (fechaaux.DayOfWeek == DayOfWeek.Monday)
                                            {
                                                nveces++; //ya estaría tomado un día de los contratados
                                                string Fecha = fechaaux.ToString("dd/MM/yyyy"); //esta es la fecha que será creada en el calendario
                                                mensaje = LlenaCalendario(Pid_plan, Pid_cliente, Fecha, fechamod); //llama a método que llena el calendario model con los datos y a su vez invoca otro método que graba en la bdd
                                                if (mensaje != "OK")
                                                { return mensaje; }
                                            }
                                            break;

                                        case "Martes":
                                            if (fechaaux.DayOfWeek == DayOfWeek.Tuesday)
                                            {
                                                nveces++; //ya estaría tomado un día de los contratados
                                                string Fecha = fechaaux.ToString("dd/MM/yyyy"); //esta es la fecha que será creada en el calendario
                                                mensaje = LlenaCalendario(Pid_plan, Pid_cliente, Fecha, fechamod); //llama a método que llena el calendario model con los datos y a su vez invoca otro método que graba en la bdd
                                                if (mensaje != "OK")
                                                { return mensaje; }
                                            }
                                            break;
                                        case "Miercoles":
                                            if (fechaaux.DayOfWeek == DayOfWeek.Wednesday)
                                            {
                                                nveces++; //ya estaría tomado un día de los contratados
                                                string Fecha = fechaaux.ToString("dd/MM/yyyy"); //esta es la fecha que será creada en el calendario
                                                mensaje = LlenaCalendario(Pid_plan, Pid_cliente, Fecha, fechamod); //llama a método que llena el calendario model con los datos y a su vez invoca otro método que graba en la bdd
                                                if (mensaje != "OK")
                                                { return mensaje; }
                                            }
                                            break;
                                        case "Jueves":
                                            if (fechaaux.DayOfWeek == DayOfWeek.Thursday)
                                            {
                                                nveces++; //ya estaría tomado un día de los contratados
                                                string Fecha = fechaaux.ToString("dd/MM/yyyy"); //esta es la fecha que será creada en el calendario
                                                mensaje = LlenaCalendario(Pid_plan, Pid_cliente, Fecha, fechamod); //llama a método que llena el calendario model con los datos y a su vez invoca otro método que graba en la bdd
                                                if (mensaje != "OK")
                                                { return mensaje; }
                                            }
                                            break;
                                        case "Viernes":
                                            if (fechaaux.DayOfWeek == DayOfWeek.Friday)
                                            {
                                                nveces++; //ya estaría tomado un día de los contratados
                                                string Fecha = fechaaux.ToString("dd/MM/yyyy"); //esta es la fecha que será creada en el calendario
                                                mensaje = LlenaCalendario(Pid_plan, Pid_cliente, Fecha, fechamod); //llama a método que llena el calendario model con los datos y a su vez invoca otro método que graba en la bdd
                                                if (mensaje != "OK")
                                                { return mensaje; }
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                    if (nveces == 1)
                                    { primerdia = fechaaux; }
                                   fechaaux = fechaaux.AddDays(1);
                                }
                                else
                                { i = 6; } //para que se detenga el for
                            } //fin del for
                            fechaaux = primerdia.AddDays(7*contador);//añade de 7 en 7 días al primer día encontrado en la primera semana para buscar el mismo día en las sig semanas
                        }//fin del while
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

        private  string LlenaCalendario(int Pid_plan, int Pid_cliente, string Pfecha, string Pfmod)
        {
            string response = string.Empty;

            CalendarioModel calendarioModel = new CalendarioModel();
            calendarioModel = new CalendarioModel();

            //Genero datos para el calendadio
            calendarioModel.Fk_id_plan = Pid_plan;
            calendarioModel.Fk_id_cliente = Pid_cliente;
            calendarioModel.Fecha = Pfecha;  
            calendarioModel.Estado = "RESERVADO";
            calendarioModel.Usuario = usuario;
            calendarioModel.Fecha_mod = Pfmod;

            //llama a método que inserta en la bdd
            response =  InsertarCalendarioBdd(calendarioModel);
            return response;

        }

        /// <summary>
        /// Insertar un registro de Calendario
        /// </summary>
        /// <param name="calendarioModel"></pa0000ram>
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
        /// Actualiza un registro del calendario (fecha, estado, usuario, fecha_mod)
        /// </summary>
        /// <param name="calendarioModel"></param>
        /// <returns></returns>
        public string ActualizarCalendario(CalendarioModel calendarioModel)
        {
            string msg = "";
            msg = calendarioModel.Validate(calendarioModel);
            if (!(string.IsNullOrEmpty(msg)))   //si hay errores en los datos del modelo retorna falso
            {
                return msg;
            }
            else
            {
                bool aux = Validaduplicadomanual(calendarioModel);
                if (!(aux))
                {
                    msg = "Ya existe un registro para este plan, cliente y fecha";
                    return msg;
                }

                aux = Validafinsemana(calendarioModel);
                if (!(aux))
                {
                    msg = "Error. La fecha seleccionada es sábado o domingo";
                    return msg;
                }

                string query = $"UPDATE Calendario SET fecha = '{calendarioModel.Fecha}', estado = '{calendarioModel.Estado}', " +
                               $"usuario = '{calendarioModel.Usuario}', fecha_mod = '{calendarioModel.Fecha_mod}'" +
                               $"WHERE id_calendario = {calendarioModel.Id_calendario}";
                try
                {
                    bool execute = SQLConexionDataBase.Execute(query);
                    if (execute)
                    { msg = "OK"; }
                    return msg;
                }
                catch (SqlException ex)
                {
                    msg = "Error al actualizar Calendario. " + ex.Message;
                    return msg;
                }
            }
        }

        /// <summary>
        /// Eliminar un registro con estado "RESERVADO" de Calendario
        /// </summary>
        /// <param name="calendarioModel"></param>
        /// <returns></returns>
        public string EliminarCalendario(CalendarioModel calendarioModel)
        {
            string mensaje = string.Empty;

            if (calendarioModel.Estado != "RESERVADO")
            {
                mensaje = "Registro no puede ser eliminado. Estado = COMPLETO";
                return mensaje;
            }

            string query = $"DELETE FROM Calendario WHERE id_calendario = {calendarioModel.Id_calendario}";
            try
            {
                bool execute = SQLConexionDataBase.Execute(query);
                if (execute)
                { mensaje = "OK"; }
                return mensaje;
            }
            catch (SqlException ex)
            {
                mensaje = "Error al eliminar Calendario " + ex.Message;
                return mensaje;
            }
        }


        /// <summary>
        /// Model List para los nombres de los clientes 
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

        /// <summary>
        /// Model List para los nombres de los clientes
        /// </summary>
        public class NombresClientes
        {
            public int Id_Cliente { get; set; }
            public string nombre { get; set; }
            public int Sucursal { get; set; }
        }
    }
}
