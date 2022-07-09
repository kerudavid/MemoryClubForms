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
    //Gestiona la tabla Colaborador
    internal class ColaboradorBO
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
            query = $"SELECT valor1 FROM Codigo WHERE grupo = \'SUC\' AND subgrupo = \'SUC\' AND elemento <> \'\' AND estado = \'A\'";
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
            query = $"SELECT elemento FROM Codigo WHERE grupo = \'GEN\' AND subgrupo = \'ESTADO\' AND elemento <> \'\' AND estado = \'A\'";
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
        /// Consulta general de la tabla Colaborador
        /// </summary>
        /// <param name="Pidcolaborador"></param>
        /// <param name="Pestado"></param>
        /// <returns></returns>
        public List<TransporteModel> ConsultaColaborador(int Pidcolaborador, string Pestado)
        {
            string query = "";
            string condiciones = "";

            //valido el id_colaborador
            if (Pidcolaborador > 0)
            {
                condiciones += " AND id_colaborador = '{Pidcolaborador}' ";
            }
            //valido el estado
            if (!(string.IsNullOrEmpty(Pestado)))
            {
                condiciones += " AND estado = {Pestado} ";
            }

            //armo el select con las opciones dadas          
            query = $"SELECT id_colaborador, sucursal, cedula, nombre, direccion, telefono, cargo, estado, observacion, " +
                    $"usuario, fecha_mod FROM Colaborador WHERE id_colaborador >= 0";
                       
            List<TransporteModel> transporteModelList = new List<TransporteModel>();
            //Las consultas siempre retornan el obtejo dentro de una lista.
            transporteModelList = this.ObtenerListaSQL<TransporteModel>(query).ToList();

            //Consulta habilitada solo para usuario administrador
            if (nivel <= 1)
            { return transporteModelList; }
            else
            {
                transporteModelList.Clear(); //caso contrario devuelve la lista en blanco
                return transporteModelList;
            }
        }

        /// <summary>
        /// List Model de los códigos de sucursales
        /// </summary>
        public class CodigosSucursales
        {
            public int Codigos_sucursales { get; set; }
        }

        public class CodigosEstados
        {
            public string Codigos_estados { get; set; }
        }
    }
}
