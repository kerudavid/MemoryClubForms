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
    /// <summary>
    /// Gestiona la tabla Salud
    /// </summary>
    public class SaludBO
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
        /// Devuelve la lista de enfermedades
        /// </summary>
        /// <returns></returns>
        public List<ListaEnfermedades> LoadEnfermedades()
        {
            string query = "";
            query = $"SELECT elemento as enfermedades FROM Codigo WHERE grupo = \'CLI\' AND subgrupo = \'SALUD\' " +
                    $"AND elemento <> \'\' AND  estado = \'A\' ORDER BY elemento";

            List<ListaEnfermedades> enfermedadesList = new List<ListaEnfermedades>();

            //Las consultas siempre retornan el obtejo dentro de una lista.
            enfermedadesList = this.ObtenerListaSQL<ListaEnfermedades>(query).ToList();
            return enfermedadesList.OrderBy(x => x.Enfermedades).ToList();

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
        /// Consulta general de la tabla salud (id cliente, enfermedad)
        /// </summary>
        /// <param name="Pidcliente"></param>
        /// <param name="Penfermdedad"></param>
        /// <returns>Lista Salud</returns>
        public List<SaludModel> ConsultaSalud(int Pidcliente, string Penfermdedad)
        {
            string query = "";
            string condiciones = "";

            //valido el id_cliente
            if (Pidcliente > 0)
            {
                condiciones += $" AND fk_id_cliente = {Pidcliente} ";
            }
            //valido el campo enfermedad
            if (!(string.IsNullOrEmpty(Penfermdedad)) & !(string.IsNullOrWhiteSpace(Penfermdedad)))
            {
                condiciones += $" AND enfermedad = '{Penfermdedad}' ";
            }
            //armo el select con las opciones dadas

            query = $"SELECT S.id_salud, S.fk_id_cliente, C.nombre, S.enfermedad, S.observacion, S.medicacion, S.carnet_vacuna, " +
                    $"S.usuario, S.fecha_mod FROM Salud S LEFT JOIN Cliente C ON S.fk_id_cliente = C.id_cliente WHERE id_salud >= 0 " +
                    $"{condiciones} ORDER BY S.fk_id_cliente, S.enfermedad";

            List<SaludModel> saludModelList = new List<SaludModel>();
            //Las consultas siempre retornan el obtejo dentro de una lista.
            saludModelList = this.ObtenerListaSQL<SaludModel>(query).ToList();
            return saludModelList;
        }

        /// <summary>
        /// Valida que no se duplique una enfermdedad para un mismo cliente
        /// </summary>
        /// <param name="PsaludModel"></param>
        /// <returns>TRUE/FALSE</returns>
        private bool ValidaDuplicadoSalud(SaludModel PsaludModel)
        {
            string query = $"SELECT * FROM Salud WHERE fk_id_cliente = {PsaludModel.Fk_id_cliente} " +
                           $"AND enfermedad = '{PsaludModel.Enfermedad}'";

            List<SaludModel> saludList = new List<SaludModel>();
            saludList = this.ObtenerListaSQL<SaludModel>(query).ToList();

            if (saludList.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Valida que solo un usuario nivel 0 o 1 pueda  eliminar en la tabla Salud
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
        /// insertar registro de salud
        /// </summary>
        /// <param name="saludModel"></param>
        /// <returns>true/falso</returns>
        public string InsertarSalud(SaludModel saludModel)
        {
            string msg = "";
            msg = saludModel.Validate(saludModel);
            if (!(string.IsNullOrEmpty(msg)))   //si hay errores en los datos del modelo retorna falso
            {
                return msg;
            }
            else
            {
                bool aux = ValidaDuplicadoSalud(saludModel); //valida que no se duplique la enfermedad para el mismo cliente
                if (aux == true)
                {
                    string query = $"INSERT INTO Salud (fk_id_cliente, enfermedad, observacion, medicacion, carnet_vacuna, usuario, fecha_mod) " +
                                   $"VALUES ({saludModel.Fk_id_cliente}, '{saludModel.Enfermedad}', '{saludModel.Observacion}', '{saludModel.Medicacion}', " +
                                   $"'{saludModel.Carnet_vacuna}', '{saludModel.Usuario}', '{saludModel.Fecha_mod}')";
                                 
                    try
                    {
                        bool execute = SQLConexionDataBase.Execute(query);
                        if (execute)
                        { msg = "OK"; }
                    }
                    catch (SqlException ex)
                    {
                        msg = "Error " + ex.Message;
                        return msg;
                    }
                }
                else
                {
                    msg = "Este registro ya existe, No se puede duplicar";
                }
                return msg;
            }
        }

        /// <summary>
        /// Actualiza la tabla Salud ( observación, medicacion, carnet vacuna, usuario y fecha modificacción)
        /// </summary>
        /// <param name="saludModel"></param>
        /// <returns>true/false</returns>
        public bool ActualizarSalud(SaludModel saludModel)
        {
            string msg = saludModel.Validate(saludModel);
            if (!(string.IsNullOrEmpty(msg)))   //si hay errores en los datos del modelo retorna falso
            {
                return false;
            }
            else
            {
                string query = $"UPDATE Salud SET  observacion = '{saludModel.Observacion}', medicacion = '{saludModel.Medicacion}', " +
                                $"carnet_vacuna = '{saludModel.Carnet_vacuna}', usuario = '{saludModel.Usuario}', fecha_mod = '{saludModel.Fecha_mod}' " +
                                $"WHERE id_salud = {saludModel.Id_Salud}";

                try
                {
                    bool execute = SQLConexionDataBase.Execute(query);
                    return execute;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error al actualizar el registro", ex.Message);
                    return false;
                }
            }
        }

        /// <summary>
        /// Eliminar registro de Salud para un cliente
        /// </summary>
        /// <param name="saludModel"></param>
        /// <returns>true/false</returns>
        public bool EliminarSalud(SaludModel saludModel)
        {
            bool aux = ValidaNivelCliente(); //solo elimina el nivel administrador
            if (aux)
            {
                string query = $"DELETE FROM Salud WHERE id_salud = {saludModel.Id_Salud}";

                try
                {
                    bool execute = SQLConexionDataBase.Execute(query);
                    return execute;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error al eliminar registro", ex.Message);
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
        /// Model List para listar las enfermedades
        /// </summary>
        public class ListaEnfermedades
        {
            public string Enfermedades { get; set; }    
        }
    }
}
