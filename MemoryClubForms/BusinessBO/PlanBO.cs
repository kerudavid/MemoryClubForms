
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
                query = $"SELECT id_Cliente, nombre, sucursal FROM Cliente ORDER BY nombre";
            }
            else
            {
                query = $"SELECT id_Cliente, nombre, sucursal FROM Cliente WHERE sucursal = {sucursal} ORDER BY nombre";
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
            query = $"SELECT elemento as tipos_plan, valor1, valor2 FROM Codigo WHERE grupo = \'PLN\' AND subgrupo = \'TPLAN\' " +
                    $"AND elemento <> \'\' AND  estado = \'A\' ORDER BY elemento";

            List<TipoPlan> tipoplanList = new List<TipoPlan>();
            //Las consultas siempre retornan el obtejo dentro de una lista.
            tipoplanList = this.ObtenerListaSQL<TipoPlan>(query).ToList();
            return tipoplanList.OrderBy(x => x.Tipos_plan).ToList();
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
            return pagadoList.OrderBy(x => x.Pagados).ToList();
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
        ///  Calcula el saldo de días del último plan de un determinado cliente
        /// </summary>
        /// <param name="Pfecha_Ini"></param>
        /// <param name="Pid_cliente"></param>
        /// <returns></returns>
        public List<SaldoDias> CalculaSaldo(int Pid_cliente)
        {
            string query = "";
            query = $"SELECT P.max_dia_plan as dias_contratados, COUNT(A.id_asistencia) dias_tomados, (P.max_dia_plan - COUNT(A.id_asistencia)) saldo " +
                $"FROM Planes P INNER JOIN Asistencia A ON P.fk_id_cliente = A.fk_id_cliente WHERE CONVERT(date, A.fecha,101) BETWEEN CONVERT(date, P.fecha_inicio_plan,101) AND GETDATE() " +
                $"AND P.id_plan = (SELECT MAX(id_plan) FROM Planes WHERE fk_id_cliente = {Pid_cliente})  GROUP BY P.max_dia_plan ";


            List<SaldoDias> saldoList = new List<SaldoDias>();
            //Las consultas siempre retornan el obtejo dentro de una lista.
            saldoList = this.ObtenerListaSQL<SaldoDias>(query).ToList();
            return saldoList;
        }

        /// <summary>
        /// Recupera la lista de clientes de los que se ha vencido la fecha de vigencia de su plan PARA CADUCAR LOS PLANES NO VIGENTES
        /// </summary>
        /// <returns></returns>
        public List<ActStsFV> RecuperaStsFV()
        {
            string query = "";
            query = $"SELECT id_plan, id_cliente, nombre, fecha_fin_plan FROM Planes P LEFT JOIN Cliente L ON P.fk_id_cliente = L.id_cliente " +
                    $"WHERE P.estado = \'VIGENTE\' AND CONVERT(date, P.fecha_fin_plan, 101) < GETDATE() ";

            List<ActStsFV> fechaVencList = new List<ActStsFV>();
            //Las consultas siempre retornan el obtejo dentro de una lista.
            fechaVencList = this.ObtenerListaSQL<ActStsFV>(query).ToList();
            return fechaVencList;
        } 

        /// <summary>
        /// Recupera la lista de los clientes que ya han superado el número de días de su plan PARA CADUCAR LOS PLANES NO VIGENTES
        /// </summary>
        /// <returns></returns>
        public List<ActStsNDias> RecuperaStsNDias()
        {
            string query = "";
            query = $"SELECT id_plan, P.fk_id_cliente as id_cliente, P.max_dia_plan as dias_contratados, " +
                $"COUNT(A.id_asistencia) dias_tomados FROM Planes P INNER JOIN Asistencia A ON P.fk_id_cliente = A.fk_id_cliente " +
                $"WHERE CONVERT(date, A.fecha,101) BETWEEN CONVERT(date, P.fecha_inicio_plan,101) AND GETDATE() AND P.estado = \'VIGENTE\' " +
                $"GROUP BY id_plan, P.fk_id_cliente, P.max_dia_plan HAVING COUNT(A.id_asistencia) >= max_dia_plan ";

            List<ActStsNDias> ndiasList = new List<ActStsNDias>();
            //Las consultas siempre retornan el obtejo dentro de una lista.
            ndiasList = this.ObtenerListaSQL<ActStsNDias>(query).ToList();
            return ndiasList;
        }

        /// <summary>
        /// ACTUALIZA EL ESTADO DE LOS CLIENTES Y DE LOS PLANES CADUCADOS, PONE EN FECHA_MOD LA FECHA EN QUE SE CADUCARON LOS PLANES PARA USAR EN LA ASISTENCIA COMO FECHA FIN
        /// </summary>
        /// <param name="Pid_planes"></param>
        /// <param name="Pid_clientes"></param>
        /// <param name="Pfecha_mod"></param>
        /// <returns></returns>
        public string Actualiza_Cli_Plan(string Pid_planes, string Pid_clientes, string Pfecha_mod)
        {
            string msg = "";                  
            string cadena2 = $"UPDATE Cliente SET estado = \'I\' WHERE id_cliente in {Pid_clientes}"; //OJO poner ' {Pid_clientes}'?
            try
            {
                bool aux = SQLConexionDataBase.Execute(cadena2);
                if (aux)
                { msg = "OK"; }
            }
            catch (SqlException ex)
            {
                msg = "Error " + ex.Message;
                return msg;
            }

            //actualiza los Planes "vigentes" a "caducados"
            msg = "";
            string cadena = $"UPDATE Planes SET estado = \'CADUCADO\', fecha_mod = '{Pfecha_mod}' WHERE id_plan in {Pid_planes}"; //OJO poner ' {Pid_planes}'?
            try
            {
                bool ejecuta = SQLConexionDataBase.Execute(cadena);
                if (ejecuta)
                { msg = "OK"; }
            }
            catch (SqlException ex)
            {
                msg = "Error " + ex.Message;
                return msg;
            }
            return msg;
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
                if (Pestado == "VIGENTE" || Pestado == "CADUCADO")
                {
                    condiciones += $" AND P.estado = '{Pestado}' ";
                }
            }
            else
            {
                condiciones += $" AND P.estado = \'VIGENTE\' "; //por defecto siempre muestra planes vigentes
            }

            //armo el select con las opciones dadas
            query = $"SET LANGUAGE us_english " +
                    $"SELECT P.id_plan, P.fk_id_cliente, C.nombre, P.sucursal, P.tipo_plan, P.fecha_inicio_plan, P.pagado, " +
                    $"P.max_dia_plan, P.estado, P.observacion, P.usuario, P.fecha_mod, CONVERT(date, P.fecha_inicio_plan,101) fechahora, " +
                    $"P.fecha_fin_plan, CONVERT(date, P.fecha_fin_plan,101) fechafin, P.idplan_anterior " +
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
        /// <returns>int id_plan</returns>
        private int ValidarDuplicado(int Pid_cliente)
        {
            string query = $"SELECT MAX(id_plan) max_id FROM Planes WHERE fk_id_cliente = {Pid_cliente} AND estado = \'VIGENTE\'";

            List<MaxPlan> planesList = new List<MaxPlan>();
            //Las consultas siempre retornan el obtejo dentro de una lista.
            planesList = this.ObtenerListaSQL<MaxPlan>(query).ToList();

            var idplan = 0;

            if (planesList.Count > 0)
            {
                foreach (MaxPlan plane in planesList)
                {
                    idplan = plane.Max_id;     //devuelve el id plan vigente
                }
                return idplan;
            }
            else
            {
                return 0;
            }
        }

        private int BuscaIdAnterior(int Pid_cliente)
        {
            string query = $"SELECT MAX(id_plan) max_id FROM Planes WHERE fk_id_cliente = {Pid_cliente}";

            List<MaxPlan> planesList = new List<MaxPlan>();
            //Las consultas siempre retornan el obtejo dentro de una lista.
            planesList = this.ObtenerListaSQL<MaxPlan>(query).ToList();

            var idplan = 0;

            if (planesList.Count > 0)
            {
                foreach (MaxPlan plane in planesList)
                {
                    idplan = plane.Max_id;     //devuelve el id plan vigente
                }
                return idplan;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Valida el estadod del cliente, si se está insertando un nuevo plan se debe activar el estado del cliente
        /// </summary>
        /// <param name="pid_cliente"></param>
        /// <returns></returns>
        private bool ValidarEstado(int pid_cliente)
        {
            string query = $"SELECT * FROM Cliente WHERE id_cliente = {pid_cliente} AND  estado = \'I\' ";

            List<PlanModel> planesList = new List<PlanModel>();
            //Las consultas siempre retornan el obtejo dentro de una lista.
            planesList = this.ObtenerListaSQL<PlanModel>(query).ToList();

            if (planesList.Count > 0)
            {
                return true; //el cliente no está activo hay que cambiar el estado
            }
            else
            {
                return false;
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
            var valida = 0;
            string msg = string.Empty;
            msg = planModel.Validate(planModel);
            if (!(string.IsNullOrEmpty(msg)))   //si hay errores en los datos del modelo retorna falso
            {
                return msg;
            }
            else
            {
                //cambia el estado del cliente a "Activo" porque se va a insertar un plan vigente
                bool valesta = ValidarEstado(planModel.Fk_id_cliente); //recupera el estado actual del cliente
                if (valesta)
                {
                    string cadena2 = $"UPDATE Cliente SET estado = \'A\' WHERE id_cliente = {planModel.Fk_id_cliente}";
                    try
                    {
                        bool aux = SQLConexionDataBase.Execute(cadena2);
                        if (aux)
                        { msg = "OK"; }
                    }
                    catch (SqlException ex)
                    {
                        msg = "error " + ex.Message;
                    }
                }
                //actualiza el último Plan "vigente" a "caducado", solo si está caducado el plan anterior permite crear un nuevo plan
                msg = string.Empty;
                valida = this.ValidarDuplicado(planModel.Fk_id_cliente);  //recupera el último plan vigente para este cliente
                if (valida > 0)
                {                   //el campo FECHA_MOD se usará para poner la fecha en que se caducó realmente el plan, esto servirá para la fecha fin de asistencia
                    string femod = DateTime.Now.ToString("MM/dd/yyyy", ci);
                    string cadena = $"UPDATE Planes SET estado = \'CADUCADO\', fecha_mod = '{femod}' WHERE id_plan = {valida}";
                    try
                    {
                        bool ejecuta = SQLConexionDataBase.Execute(cadena);
                        if (ejecuta)
                        { msg = "OK"; }
                    }
                    catch (SqlException ex)
                    {
                        msg = "ERROR al <Caducar> el Plan Anterior. Podría Modificar usted mismo el < estado > del plan anterior: " + valida + " a CADUCADO\n" + ex.Message;
                        return msg;
                    }
                }
                int li_idplan = 0;
                li_idplan = this.BuscaIdAnterior(planModel.Fk_id_cliente);
                if (li_idplan < 0 )
                { li_idplan = 0; }

                //inserta el plan
                msg = string.Empty;
                string query = $"INSERT INTO Planes (fk_id_cliente, sucursal, tipo_plan, fecha_inicio_plan, pagado, max_dia_plan, estado, observacion, usuario, " +
                               $"fecha_mod, fecha_fin_plan, idplan_anterior) " +
                               $"VALUES ({planModel.Fk_id_cliente}, {planModel.Sucursal}, '{planModel.Tipo_plan}', '{planModel.Fecha_inicio_plan}', '{planModel.Pagado}', " +
                               $"{planModel.Max_dia_plan},'{planModel.Estado}', '{planModel.Observacion}', '{planModel.Usuario}', '{planModel.Fecha_mod}', " +
                               $"'{planModel.Fecha_fin_plan}', {li_idplan})"; //li_idplan es el id plan anterior para este cliente que ahora ya está caducado 
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
        }

        /// <summary>
        /// Recupera la clave para modificar fecha fin
        /// </summary>
        /// <returns></returns>
        public string BuscaClv()
        {
            string elemento = "";
            string query = $"SELECT elemento FROM Codigo WHERE grupo = 'PLN' and subgrupo = 'CLAVE'";
            List<Clvid> elemlist = new List<Clvid>();
            elemlist = this.ObtenerListaSQL<Clvid>(query).ToList();
            if (elemlist.Count > 0)
            {
                foreach (var item in elemlist)
                {
                    elemento = (item.Elemento);
                }
            }
            else
            { elemento = ""; }
            return elemento;
        }
        
        /// <summary>
        /// Actualiza un registro de PLAN,(fecha ini plan, pagado, número días vigencia del plan, estado, observación, usuario, fecha_mod)
        ///  *** OJO si se puede modificar un registro con estado "CADUCADO" **** solo la fecha finalizó plan
        /// </summary>
        /// <param name="planModel"></param>
        /// <returns>string mensaje</returns>
        public string ActualizarPlan(PlanModel planModel)
        {
            string msg = planModel.Validate(planModel);
            if (!(string.IsNullOrEmpty(msg)))   //si hay errores en los datos del modelo retorna falso
            {
                return msg;
            }
            else
            {
                string query = $"UPDATE Planes SET tipo_plan = '{planModel.Tipo_plan}', fecha_inicio_plan = '{planModel.Fecha_inicio_plan}', pagado = '{planModel.Pagado}', max_dia_plan = {planModel.Max_dia_plan}, " +
                               $"estado = '{planModel.Estado}', observacion = '{planModel.Observacion}', usuario = '{planModel.Usuario}', fecha_mod = '{planModel.Fecha_mod}', " +
                               $"fecha_fin_plan = '{planModel.Fecha_fin_plan}' WHERE id_plan = {planModel.Id_plan}";
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
        /// <summary>
        /// graba la fecha fin del plan solo con una clave 
        /// </summary>
        /// <param name="Pfefin"></param>
        /// <param name="Pid_plan"></param>
        /// <returns></returns>
        public string ActualizaFechaFin(string Pfefin, int Pid_plan, string Pfemod, string Pestado, string Pusuario)
        {
            string msg = "";
            string query = $"UPDATE Planes SET fecha_fin_plan = '{Pfefin}', fecha_mod = '{Pfemod}', estado = '{Pestado}', usuario = '{Pusuario}'WHERE id_plan = {Pid_plan}";
            try
            {
                bool execute = SQLConexionDataBase.Execute(query);
                if (execute)
                { msg = "OK"; }
                return msg;
            }
            catch (SqlException ex)
            {
                msg = "Error al actualizar Fecha Fin del Plan. " + ex.Message;
                return msg;
            }           
        }

        // <summary>
        /// Eliminar PLAN *** OJO no se puede eliminar un registro con estado "CADUCADO" ****
        /// </summary>
        /// <param name="planModel"></param>
        /// <returns>True-False</returns>
        public string EliminarPlan(PlanModel planModel)
        {
            string mensaje = string.Empty;

            if (nivel <= 1) //solo usuario administrador puede eliminar
            {
                if (planModel.Estado == "VIGENTE") //no se puede eliminar un plan caducado
                {
                    string query = $"DELETE FROM Planes WHERE id_plan = {planModel.Id_plan} ";
                    try
                    {
                        bool execute = SQLConexionDataBase.Execute(query);
                        if (execute)
                        {
                            //cambia el estado del cliente a "Inactivo" porque se va a eliminar un plan vigente
                            bool valesta = ValidarEstado(planModel.Fk_id_cliente); //recupera el estado actual del cliente
                            if (valesta == false)    //cliente está activo hay que inactivarlo porque no tendrá un plan vigente
                            {
                                string cadena2 = $"UPDATE Cliente SET estado = \'I\' WHERE id_cliente = {planModel.Fk_id_cliente}";
                                try
                                {
                                    bool aux = SQLConexionDataBase.Execute(cadena2);
                                    if (aux)
                                    { mensaje = "OK"; }
                                    return mensaje;
                                }
                                catch (SqlException ex)
                                {
                                    mensaje = "Se eliminó el Plan, pero no se pudo cambiar el estado del cliente a Inactivo.\n " + ex;
                                    return mensaje;
                                }
                            }
                            mensaje = "OK";
                        }
                        return mensaje;
                    }
                    catch (SqlException ex)
                    {
                        mensaje = "Error al eliminar Plan.\n " + ex.Message;
                        return mensaje;
                    }
                }
                else
                {
                    mensaje = "No se puede eliminar un Plan Caducado";
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
            public int Valor1 { get; set; }
            public decimal Valor2 { get; set; }
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
        /// <summary>
        /// Modelo para el saldo de días de un plan
        /// </summary>
        public class SaldoDias
        {
            public int Dias_contratados { get; set; }
            public int Dias_tomados { get; set; }
            public int Saldo { get; set; }
        }
        public class ActStsFV
        {
            public int Id_plan { get; set; }
            public int Id_cliente { get; set; }
            public string Nombre { get; set; }
            public string Fecha_fin_plan { get; set; }
        }
        public class ActStsNDias
        {
            //id_plan, P.fk_id_cliente as id_cliente, P.max_dia_plan as dias_contratados, COUNT(A.id_asistencia) dias_tomados
            public int Id_plan { get; set; }
            public int Id_cliente { get; set; }
            public int Dias_contratados { get; set; }
            public int Dias_tomados { get; set; }
        }
        private  class MaxPlan
        {
            public int Max_id { get; set; }
        }
        private class Clvid
        {
            public string Elemento { get; set; }  
        }
    }
}
