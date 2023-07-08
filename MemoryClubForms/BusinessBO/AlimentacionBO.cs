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
    //gestiona la tabla Alimentación
    public class AlimentacionBO
    {
        public static int nivel = VariablesGlobales.Nivel;
        public static int sucursal = VariablesGlobales.sucursal;


        /// <summary>
        /// Devuelve la lista de clientes A o P, dependiendo del nivel del usuario todos los clientes o los de su sucursal
        /// </summary>
        /// <returns>Lista Clientes</returns>
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
        /// Devuelve la lista de los alimentos restringidos de códigos
        /// </summary>
        /// <returns></returns>
        public List<AlimentosRestringidos> LoadAlimentosR()
        {
            string query = "";
            query = $"SELECT elemento as alimentos_r FROM Codigo WHERE grupo = \'CLI\' AND subgrupo = \'ALIMEN\' " +
                    $"AND elemento <> \'\' AND  estado = \'A\' ORDER BY elemento";

            List<AlimentosRestringidos> alimentosList = new List<AlimentosRestringidos>();

            //Las consultas siempre retornan el obtejo dentro de una lista.
            alimentosList = this.ObtenerListaSQL<AlimentosRestringidos>(query).ToList();
            return alimentosList;

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
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Consulta general de Alimentacion Restringida (Id cliente, alimento restringido)
        /// </summary>
        /// <param name="Pidcliente"></param>
        /// <param name="Palimento"></param>
        /// <returns></returns>
        public List<AlimentacionModel> ConsultaAlimentacion(int Pidcliente, string Palimento)
        {
            string query = "";
            string condiciones = "";

            //valido el id_cliente
            if (Pidcliente > 0)
            {
                condiciones += $" AND fk_id_cliente = {Pidcliente} ";
            }
            //valido el alimento restringido
            if (!(string.IsNullOrEmpty(Palimento)) & !(string.IsNullOrWhiteSpace(Palimento)))
            {
                condiciones += $" AND alimento_restringido = '{Palimento}' ";
            }
            //armo el select con las opciones dadas

            query = $"SELECT A.id_alimentacion, A.fk_id_cliente, C.nombre, A.alimento_restringido, A.observacion, A.usuario, A.fecha_mod " +
                    $"FROM Alimentacion A LEFT JOIN Cliente C ON A.fk_id_cliente = C.id_cliente WHERE id_alimentacion >= 0  {condiciones}" +
                    $"ORDER BY fk_id_cliente, alimento_restringido";

            List<AlimentacionModel> alimentosModelList = new List<AlimentacionModel>();
            //Las consultas siempre retornan el obtejo dentro de una lista.
            alimentosModelList = this.ObtenerListaSQL<AlimentacionModel>(query).ToList();
            return alimentosModelList;
        }

        /// <summary>
        /// Valida que no se duplique un alimento restringido para un mismo cliente
        /// </summary>
        /// <param name="PalimentacionModel"></param>
        /// <returns>TRUE/FALSE</returns>
        private bool ValidaDuplicadoAlimentacion(AlimentacionModel PalimentacionModel)
        {
            string query = $"SELECT * FROM Alimentacion WHERE fk_id_cliente = {PalimentacionModel.Fk_id_cliente} " +
                           $"AND alimento_restringido = '{PalimentacionModel.Alimento_restringido}'";

            List<AlimentacionModel> alimentosList = new List<AlimentacionModel>();
            alimentosList = this.ObtenerListaSQL<AlimentacionModel>(query).ToList();

            if (alimentosList.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Valida que solo un usuario nivel 0 o 1 pueda  eliminar en la tabla Alimento R
        /// </summary>
        /// <returns>TRUE/FALSE</returns>
        private bool ValidaNivelCliente()
        {
            if (nivel <= 1) //solo usuario administrador elimina alimento r
            { return true; }
            else
            { return false; }
        }

        /// <summary>
        /// insertar registro de alimento restringido
        /// </summary>
        /// <param name="PalimentacionModel"></param>
        /// <returns>true/falso</returns>
        public string InsertarAlimentoR(AlimentacionModel PalimentacionModel)
        {
            string msg = "";
            msg = PalimentacionModel.Validate(PalimentacionModel);
            if (!(string.IsNullOrEmpty(msg)))   //si hay errores en los datos del modelo retorna falso
            {
                return msg;
            }
            else
            {
                bool aux = ValidaDuplicadoAlimentacion(PalimentacionModel); //valida que no se duplique el alimento para el mismo cliente
                if (aux == true)
                {
                    string query = $"INSERT INTO Alimentacion (fk_id_cliente, alimento_restringido, observacion, usuario, fecha_mod) " +
                                   $"VALUES ({PalimentacionModel.Fk_id_cliente}, '{PalimentacionModel.Alimento_restringido}', '{PalimentacionModel.Observacion}', " +
                                   $"'{PalimentacionModel.Usuario}', '{PalimentacionModel.Fecha_mod}' )";
                    try
                    {
                        bool execute = SQLConexionDataBase.Execute(query);
                        if (execute)
                        { msg = "OK"; }
                        return msg;
                    }
                    catch (SqlException ex)
                    {
                        msg = "Error al insertar alimentación restringida Plan. " + ex.Message;
                        return msg;
                    }
                }
                else
                {
                    msg = "Error, registro duplicado. ";
                    return msg;
                }
            }
        }

        /// <summary>
        /// Actualiza la tabla Alimentación (alimento, observación, usuario y fecha modificacción)
        /// </summary>
        /// <param name="PalimentacionModel"></param>
        /// <returns>true/false</returns>
        public string ActualizarAlimentoR(AlimentacionModel PalimentacionModel)
        {
            string msg = "";
            msg = PalimentacionModel.Validate(PalimentacionModel);
            if (!(string.IsNullOrEmpty(msg)))   //si hay errores en los datos del modelo retorna falso
            {
                return msg;
            }
            else
            {               
                string query = $"UPDATE Alimentacion SET  alimento_restringido = '{PalimentacionModel.Alimento_restringido}', observacion = '{PalimentacionModel.Observacion}', " +
                                $"usuario = '{PalimentacionModel.Usuario}', fecha_mod = '{PalimentacionModel.Fecha_mod}'" +
                                $"WHERE id_alimentacion = {PalimentacionModel.Id_alimentacion}";

                try
                {
                    bool execute = SQLConexionDataBase.Execute(query);
                    if (execute)
                    { msg = "OK"; }
                    return msg;
                }
                catch (SqlException ex)
                {
                    msg = "Error al actualizar alimentación restringida Plan. " + ex.Message;
                    return msg;
                }              
            }
        }

       /// <summary>
       /// Eliminar Alimento restringido para un cliente
       /// </summary>
       /// <param name="PalimentacionModel"></param>
       /// <returns>true/false</returns>
        public bool EliminarAlimentoR(AlimentacionModel PalimentacionModel)
        {
            bool aux = ValidaNivelCliente(); //solo elimina el nivel administrador
            if (aux)
            {
                string query = $"DELETE FROM Alimentacion WHERE id_alimentacion = {PalimentacionModel.Id_alimentacion}";

                try
                {
                    bool execute = SQLConexionDataBase.Execute(query);
                    return execute;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error al eliminar Alimento Restringido", ex.Message);
                    return false;
                }
            }
            else
            { return false; }
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
        /// List Model de los alimentos restringidos
        /// </summary>
        public class AlimentosRestringidos
        {
            public string Alimentos_r { get; set; }
        }
    }
}
