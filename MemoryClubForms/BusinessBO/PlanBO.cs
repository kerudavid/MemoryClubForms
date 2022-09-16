
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
    //gestiona la tabla Plan
    public class PlanBO
    {
        public static int nivel = VariablesGlobales.Nivel;
        public static int sucursal = VariablesGlobales.sucursal;
        CultureInfo ci = new CultureInfo("en-US");

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
        /// Recupera en una lista los nombres de los clientes NO INACTIVOS
        /// </summary>
        /// <returns>Lista </returns>
        public List<NombresClientes> LoadClientes()
        {
            string query = "";

            if (nivel <= 1)
            {
                query = $"SELECT id_Cliente, nombre, sucursal FROM Cliente WHERE estado <> \'I\' ORDER BY nombre";
            }
            else
            {
                query = $"SELECT id_Cliente, nombre, sucursal FROM Cliente WHERE sucursal = {sucursal} AND estado <> \'I\' ORDER BY nombre";
            }

            List<NombresClientes> nombresList = new List<NombresClientes>();

            //Las consultas siempre retornan el obtejo dentro de una lista.
            nombresList = this.ObtenerListaSQL<NombresClientes>(query).ToList();
            return nombresList.OrderBy(x => x.nombre).ToList();
        }

        /// <summary>
        /// Devuelve una lista con los Estados del PLAN
        /// </summary>
        /// <returns></returns>
        public List<EstadosPlan> LoadEstadosPlan()
        {
            string query = "";
            query = $"SELECT elemento as estados FROM Codigo WHERE grupo = \'PLN\' AND subgrupo = \'ESTADO\' " +
                    $"AND elemento <> \'\' AND  estado = \'A\' ORDER BY elemento";

            List<EstadosPlan> estadosplanList = new List<EstadosPlan>();
            //Las consultas siempre retornan el obtejo dentro de una lista.
            estadosplanList = this.ObtenerListaSQL<EstadosPlan>(query).ToList();
            return estadosplanList;
        }

        /// <summary>
        /// Devuelve lista de los TIPOS de PLAN
        /// </summary>
        /// <returns></returns>
        public List<TipoPlan> LoadTipoPlan()
        {
            string query = "";
            query = $"SELECT elemento as tipos_plan FROM Codigo WHERE grupo = \'PLN\' AND subgrupo = \'TPLAN\' " +
                    $"AND elemento <> \'\' AND  estado = \'A\' ORDER BY elemento";

            List<TipoPlan> tipoplanList = new List<TipoPlan>();
            //Las consultas siempre retornan el obtejo dentro de una lista.
            tipoplanList = this.ObtenerListaSQL<TipoPlan>(query).ToList();
            return tipoplanList.OrderBy(x => x.Tipos_plan).ToList(); ;
        }

        /// <summary>
        /// Devuelve lista de Pagado (SI/NO)
        /// </summary>
        /// <returns>Lista(SI/NO)</returns>
        public List<ListaPagado> LoadPagado()
        {
            string query = "";
            query = $"SELECT elemento as pagados FROM Codigo WHERE grupo = \'PLN\' AND subgrupo = \'PAGOS\' " +
                    $"AND elemento <> \'\' AND  estado = \'A\' ORDER BY elemento";

            List<ListaPagado> pagadoList = new List<ListaPagado>();
            //Las consultas siempre retornan el obtejo dentro de una lista.
            pagadoList = this.ObtenerListaSQL<ListaPagado>(query).ToList();
            return pagadoList.OrderBy(x => x.Pagados).ToList(); ;
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
        /// Consulta general de Planes (Fecha inicio plan desde, fecha inicio plan hasta, sucursal, tipo plan, id cliente, estado)
        /// </summary>
        /// <param name="Pdesde"></param>
        /// <param name="Phasta"></param>
        /// <param name="Psucursal"></param>
        /// <param name="PtipoPlan"></param>
        /// <param name="Pidcliente"></param>
        /// <param name="Pestado"></param>
        /// <returns></returns>
        public List<PlanModel> ConsultaPlan(string Pdesde, string Phasta, int Psucursal, string PtipoPlan, int Pidcliente, string Pestado)
        {
            DateTime fechadesde = DateTime.Now;
            DateTime fechahasta = DateTime.Now;
            string query = "";
            string condiciones = "";

           /* //valido las fechas - cuando no viene una fecha desde busco 30 días atrás
            if (string.IsNullOrEmpty(Pdesde) || string.IsNullOrWhiteSpace(Pdesde))
            {
                fechadesde = fechadesde.AddDays(-30);
                Pdesde = fechadesde.ToString("dd/MM/yyyy");
            }

            //si no viene la fecha hasta pongo la fecha de hoy
            if (string.IsNullOrEmpty(Phasta) || string.IsNullOrWhiteSpace(Phasta))
            {
                Phasta = fechahasta.ToString("dd/MM/yyyy");
            }*/

            if (!(string.IsNullOrEmpty(Pdesde)) & !(string.IsNullOrEmpty(Phasta)))
            {
                condiciones += $" WHERE CONVERT(date, P.fecha_inicio_plan,101) BETWEEN CAST('{Pdesde}' AS date) AND CAST('{Phasta}' AS date) ";
            }

            //valido la sucursal
            if (Psucursal > 0)
            {
                if (nivel <= 1) //solo el nivel administrador puede consultar cualquier sucursal
                { condiciones += $" AND P.sucursal = {Psucursal} "; }
                else
                { condiciones += $" AND P.sucursal = {sucursal} "; } //los otros niveles solo consultan su propia sucursal
            }
            else //no se ha seleccionado sucursal
            {
                if (nivel > 1)  //para cualquier otro nivel de usuario se envia su propia sucursal
                { condiciones += $" AND P.sucursal = {sucursal} "; }
            }
            //valido el Id cliente
            if (Pidcliente > 0)
            {
                condiciones += $" AND P.fk_id_cliente = {Pidcliente} ";
            }

            //valido el TIPO PLAN
            if (!(string.IsNullOrEmpty(PtipoPlan)))
            {
                condiciones += $" AND P.tipo_plan = '{PtipoPlan}' ";
            }

            //valido el ESTADO
            if (!(string.IsNullOrEmpty(Pestado)))
            {
                if (Pestado == "VIGENTE" || Pestado == "CERRADO")
                {
                    condiciones += $" AND P.estado = '{Pestado}' ";
                }
            }
            else
            {
                condiciones += $" AND P.estado = 'VIGENTE' "; //por defecto siempre muestra planes vigentes
            }

            //armo el select con las opciones dadas
            query = $"SELECT P.id_plan, P.fk_id_cliente, C.nombre, P.sucursal, P.tipo_plan, P.fecha_inicio_plan, P.pagado, " +
                    $"P.max_dia_plan, P.estado, P.observacion, P.usuario, P.fecha_mod, CONVERT(date, P.fecha_inicio_plan,101) fechahora " +
                    $"FROM Planes P INNER JOIN Cliente C ON P.fk_id_cliente = C.id_cliente {condiciones}";

            List<PlanModel> PlanesModelList = new List<PlanModel>();
            //Las consultas siempre retornan el obtejo dentro de una lista.
            PlanesModelList = this.ObtenerListaSQL<PlanModel>(query).ToList();
            return PlanesModelList.OrderBy(x => x.Nombre).ToList();

        }

        /// <summary>
        /// Valida que no exista un PLAN que esté VIGENTE para el cliente que se desea añadir
        /// </summary>
        /// <param name="planModel"></param>
        /// <returns>true/false</returns>
        private bool ValidarDuplicado(PlanModel planModel)
        {
            string query = $"SELECT * FROM Planes WHERE fk_id_cliente = {planModel.Fk_id_cliente} AND estado = 'VIGENTE'";

            List<PlanModel> planesList = new List<PlanModel>();
            //Las consultas siempre retornan el obtejo dentro de una lista.
            planesList = this.ObtenerListaSQL<PlanModel>(query).ToList();

            if (planesList.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        /// <summary>
        /// Insertar nuevo PLAN para cliente
        /// </summary>
        /// <param name="planModel"></param>
        /// <returns>string Mensaje</returns>
        public string InsertarPlan(PlanModel planModel) 
         {
            planModel.Estado = "VIGENTE"; //solo inserta planes vigentes
            bool valida = true;
            string msg = planModel.Validate(planModel);
            if (!(string.IsNullOrEmpty(msg)))   //si hay errores en los datos del modelo retorna falso
            {
                return msg;
            }
            else
            {
                valida  = this.ValidarDuplicado(planModel); 
                if (valida)
                {
                    string query = $"INSERT INTO Planes (fk_id_cliente, sucursal, tipo_plan, fecha_inicio_plan, pagado, max_dia_plan, estado, observacion, usuario, fecha_mod) " +
                                    $"VALUES ({planModel.Fk_id_cliente}, {planModel.Sucursal}, '{planModel.Tipo_plan}', '{planModel.Fecha_inicio_plan}', '{planModel.Pagado}', " +
                                    $"{planModel.Max_dia_plan},'{planModel.Estado}', '{planModel.Observacion}', '{planModel.Usuario}', '{planModel.Fecha_mod}')";
                    try
                    {
                        bool execute = SQLConexionDataBase.Execute(query);
                        if (execute)
                        { msg = "OK"; }
                         return msg;
                    }
                    catch (SqlException ex)
                    {

                        msg = "Error al insertar Plan. " + ex.Message;
                        return msg;
                    }

                }
                else
                {
                    msg = "Ya existe un Plan Vigente para este Cliente, no se añadió este registro";
                    return msg;
                }
            }
        }

        /// <summary>
        /// Actualiza un registro de PLAN,(fecha ini plan, pagado, número días vigencia del plan, estado, observación, usuario, fecha_mod)
        ///  *** OJO no se puede modificar un registro con estado "CERRADO" ****
        /// </summary>
        /// <param name="planModel"></param>
        /// <returns>string mensaje</returns>
        public string  ActualizarPlan(PlanModel planModel)
        {
            string msg = planModel.Validate(planModel);
            if (!(string.IsNullOrEmpty(msg)))   //si hay errores en los datos del modelo retorna falso
            {
                return msg;
            }
            else
            {   
                string query = $"UPDATE Planes SET fecha_inicio_plan = '{planModel.Fecha_inicio_plan}', pagado = '{planModel.Pagado}', max_dia_plan = {planModel.Max_dia_plan}, " +
                                $"estado = '{planModel.Estado}', observacion = '{planModel.Observacion}', usuario = '{planModel.Usuario}', fecha_mod = '{planModel.Fecha_mod}' " +
                                $"WHERE id_plan = {planModel.Id_plan}";
                try
                {
                    bool execute = SQLConexionDataBase.Execute(query);
                    if (execute)
                    { msg = "OK"; }
                    return msg;
                }
                catch (SqlException ex)
                {
                    msg = "Error al actualizar Plan. " + ex.Message;
                    return msg;
                }
            }
        }

        // <summary>
        /// Eliminar PLAN *** OJO no se puede eliminar un registro con estado "CERRADO" ****
        /// </summary>
        /// <param name="Pid_transporte"></param>
        /// <returns>True-False</returns>
        public string EliminarPlan(PlanModel planModel)
        {
            string mensaje = string.Empty;

            if (nivel <= 1) //solo usuario administrador puede eliminar
            {
               if (planModel.Estado == "VIGENTE") //no se puede eliminar un plan cerrado
               {

                    string aux = this.EliminaCalendario(planModel.Id_plan); //antes se elimina todo el calendario para este plan
                    if (aux == "OK")
                    {
                        string query = $"DELETE FROM Planes WHERE id_plan = {planModel.Id_plan} ";
                        try
                        {
                            bool execute = SQLConexionDataBase.Execute(query);
                            if (execute)
                            { mensaje = "OK"; } //cuando el plan y el calendario se han eliminado existosamente  
                            return mensaje;
                        }
                        catch (SqlException ex)
                        {
                            mensaje = "Error al eliminar Plan. " + ex.Message;
                            return mensaje;
                        }
                    }
                    else
                    {
                        mensaje = "Error al eliminar Calendario";
                        return mensaje;
                    }
                }
                else
                {
                    mensaje = "No se puede eliminar un Plan Cerrado";
                    return mensaje;
                }
            }
            else
            {
                mensaje = "Solo Nivel Administrador puede eliminar un Plan";
                return mensaje; 
            }
        }

        /// <summary>
        /// Elimina todos los registros de calendario para el plan que se va a eliminar
        /// </summary>
        /// <param name="Pid_plan"></param>
        /// <returns>true/false</returns>
        private string EliminaCalendario(int Pid_plan)
        {
            string mensaje = string.Empty;

            string query = $"DELETE FROM Calendario WHERE fk_id_plan = {Pid_plan} ";
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
        public class NombresClientes
        {
            public int Id_Cliente { get; set; }
            public string nombre { get; set; }
            public int Sucursal { get; set; }
        }

        /// <summary>
        /// List Model para los estados del plan
        /// </summary>
        public class EstadosPlan
        {
            public string Estados { get; set; }
        }

        /// <summary>
        /// List Model para los TIPOS de PLAN
        /// </summary>
        public class TipoPlan
        {
            public string Tipos_plan { get; set; }
        }

        /// <summary>
        /// List Model para indicar si el PLAN está pagado
        /// </summary>
        public class ListaPagado
        {
            public string Pagados { get; set; } 
        }
        public class CodigosSucursales
        {
            public int Sucursales { get; set; }
        }
    }
}
