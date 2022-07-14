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
    //gestiona la tabla Transportista
    public class TransportistaBO
    {
        int nivel = VariablesGlobales.Nivel;
        int sucursal = VariablesGlobales.sucursal;

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
        /// Devuelve Lista de las Rutas de transporte (1,2,3, etc)
        /// </summary>
        /// <returns></returns>
        public List<CodigosRutas> LoadRutas()
        {
            string query = "";
            query = $"SELECT valor1 as rutas FROM Codigo WHERE grupo = \'TRA\' AND subgrupo = \'RUTA\' AND elemento <> \'\' AND estado = \'A\'";
            List<CodigosRutas> codigosRutaslist = new List<CodigosRutas>();
            codigosRutaslist = this.ObtenerListaSQL<CodigosRutas>(query).ToList();

            return codigosRutaslist;
        }
        /// <summary>
        /// Devuelve Lista de los Sectores para transporte (norte, sur,etc)
        /// </summary>
        /// <returns></returns>
        public List<CodigosSectores> LoadSectores()
        {
            string query = "";
            query = $"SELECT elemento as sectores FROM Codigo WHERE grupo = \'TRA\' AND subgrupo = \'SECTOR\' AND elemento <> \'\' AND estado = \'A\'";
            List<CodigosSectores> codigosSectoreslist = new List<CodigosSectores>();
            codigosSectoreslist = this.ObtenerListaSQL<CodigosSectores>(query).ToList();

            return codigosSectoreslist;
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
        /// Consulta General de Transportista (Id Trasportista, sucursal, ruta, sector)
        /// </summary>
        /// <param name="Pidtransportista"></param>
        /// <param name="Psucursal"></param>
        /// <param name="Pruta"></param>
        /// <param name="Psector"></param>
        /// <returns>Lista</returns>
        public List<TransportistaModel> ConsultaTransportista(int Pidtransportista, int Psucursal, int Pruta, string Psector)
        {
            string query = "";
            string condiciones = "";

            //valido el id_transportista
            if (Pidtransportista > 0)
            {
                condiciones += $" AND id_transportista = {Pidtransportista} ";
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
            //valido la ruta
            if (Pruta > 0)
            {
                condiciones += $" AND ruta = {Pruta} ";
            }
            //valido el sector
            if (!(string.IsNullOrEmpty(Psector)))
            {
                condiciones += $" AND sector = '{Psector}' ";
            }

            //armo el select con las opciones dadas          
            query = $"SELECT * FROM Transportista WHERE id_transportista >= 0 {condiciones}";

            List<TransportistaModel> transportistaModelList = new List<TransportistaModel>();
            //Las consultas siempre retornan el obtejo dentro de una lista.
            transportistaModelList = this.ObtenerListaSQL<TransportistaModel>(query).ToList();
            return transportistaModelList;
        }

        //valida que no haya ningun registro con estado activo para el mismo transportista
        private bool ValidaTransportistas(TransportistaModel PtransportistaModel)
        {
            string query = $"SELECT * FROM Transportista WHERE cedula = '{PtransportistaModel.Cedula}' AND estado = \'A\'";

            List<TransportistaModel> cedulasList = new List<TransportistaModel>();
            cedulasList = this.ObtenerListaSQL<TransportistaModel>(query).ToList();

            if (cedulasList.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Valida que solo un usuario nivel 0 o 1 pueda añadir, modificar o eliminar en la tabla Transportista
        /// </summary>
        /// <returns>TRUE/FALSE</returns>
        private bool ValidaNivelTransportista()
        {
            if (nivel <= 1) //solo usuario administrador inserta, modifica o elimina Transportista
            { return true; }
            else
            { return false; }
        }

        /// <summary>
        /// Inserta registro en Transportista 
        /// </summary>
        /// <param name="PtransportistaModel"></param>
        /// <returns>TRUE/FALSE</returns>
        public bool InsertaTransportista(TransportistaModel PtransportistaModel)
        {
            bool valida = this.ValidaNivelTransportista(); //solo administrador puede insertar transportista
            if (valida)
            {
                //valida que no haya uno o mas registros para el mismo transportista con estado Activo
                bool aux = this.ValidaTransportistas(PtransportistaModel);
                if (aux)
                {
                    string query = $"INSERT INTO Transportista (sucursal, cedula, nombre, ruta, sector, placa_veh, telefono, direccion, estado, observacion, usuario, fecha_mod ) " +
                                   $" VALUES ({PtransportistaModel.Sucursal}, '{PtransportistaModel.Cedula}', '{PtransportistaModel.Nombre}', {PtransportistaModel.Ruta}, '{PtransportistaModel.Sector}', " +
                                   $"'{PtransportistaModel.Placa_veh}', '{PtransportistaModel.Telefono}', '{PtransportistaModel.Direccion}', '{PtransportistaModel.Estado}', '{PtransportistaModel.Observacion}', " +
                                   $"'{PtransportistaModel.Usuario}', '{PtransportistaModel.Fecha_mod}')";

                    try
                    {
                        bool execute = SQLConexionDataBase.Execute(query);
                        return execute;
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("Error al insertar  Transportista", ex.Message);
                        return false;
                    }
                }
                else
                { return false; }
            }
            else
            {return false; }    
        }

        /// <summary>
        /// Actualiza la tabla Transportista (ruta, sector, placa, tlfono, direcc, estado, observ, usuario, fecha_mod)
        /// </summary>
        /// <param name="PtransportistaModel"></param>
        /// <returns>TRUE/FALSE</returns>
        public bool ActualizarTransportista(TransportistaModel PtransportistaModel) //no actualiza ruta, ni sector. Se deberia crear transportista dando de baja 'I' el otro registro
        {
            bool valida = this.ValidaNivelTransportista(); //solo administrador puede modificar transportista
            if (valida)
            {
                string query = $"UPDATE Transportista SET ruta = {PtransportistaModel.Ruta}, sector = '{PtransportistaModel.Sector}', placa_veh  = '{PtransportistaModel.Placa_veh}', " +
                               $"telefono = '{PtransportistaModel.Telefono}', direccion = '{PtransportistaModel.Direccion}', estado = '{PtransportistaModel.Estado}', " +
                               $"observacion = '{PtransportistaModel.Observacion}', usuario = '{PtransportistaModel.Usuario}', fecha_mod = '{PtransportistaModel.Fecha_mod}' " +
                               $"WHERE id_transportista = {PtransportistaModel.Id_transportista}";

                try
                {
                    bool execute = SQLConexionDataBase.Execute(query);
                    return execute;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error al actualizar Transportista", ex.Message);
                    return false;
                }
            }
            else
            { return false; }
        }

        /// <summary>
        /// Elimina registro de Transportista
        /// </summary>
        /// <param name="Pid_transportista"></param>
        /// <returns>TRUE/FALSE</returns>
        public bool EliminarTransportista(int Pid_transportista)
        {
            bool aux = this.ValidaNivelTransportista (); //solo nivel de usuario <= 1 puede eliminar
            if (aux == true)
            {
                string query = $"DELETE FROM Transportista WHERE id_transportista = {Pid_transportista} ";
                try
                {
                    bool execute = SQLConexionDataBase.Execute(query);
                    return execute;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error al eliminar Transportista", ex.Message);
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
        }
        /// <summary>
        /// List Model de los códigos de rutas
        /// </summary>
        public class CodigosRutas
        {
            public int Rutas { get; set; }
        }
        /// <summary>
        /// List Model de los sectores para el transporte
        /// </summary>
        public class CodigosSectores
        {
            public string Sectores { get; set; }
            public string Descripcion { get; set; }
        }
    }
}
