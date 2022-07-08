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
       /* public List<TransporteModel> ConsultaColaborador(int Pidcolaborador, string Pestado)
        {
            string query = "";
            string condiciones = "";

            //Consulta habilitada solo para usuario administrador
            if (nivel <= 1)
            { 
                //valido el id_colaborador
                if (Pidcolaborador > 0)
                {
                    condiciones += " AND T.id_transportista = '{Pidtransportista}' ";
                }
                //valido el estado
                if (!(string.IsNullOrEmpty(Pestado)))
                {
                    condiciones += " AND T.fk_id_cliente = {Pidcliente} ";
                }

                //armo el select con las opciones dadas          
                query = $"SELECT DISTINCT T.id_transporte, T.fk_id_cliente, C.nombre, T.tipo_cliente, T.fecha, T.hora, T.id_transportista, T.entrada_salida, T.observacion, T.sucursal, T.usuario, T.fecha_mod " +
                        $"FROM Transporte T LEFT JOIN Cliente C ON T.fk_id_cliente = C.id_cliente  WHERE tipo_cliente = 'CLIENTE' " +
                        $"'{condiciones}'" +
                        $"UNION " +
                        $"SELECT DISTINCT T.id_transporte, T.fk_id_cliente, B.nombre, T.tipo_cliente, T.fecha, T.hora, T.id_transportista, T.entrada_salida, T.observacion, T.sucursal, T.usuario, T.fecha_mod " +
                        $"FROM Transporte T LEFT JOIN Colaborador B ON T.fk_id_cliente = B.id_colaborador  WHERE tipo_cliente = 'COLABORADOR' " +
                        $"'{condiciones}' ";
                       
                List<TransporteModel> transporteModelList = new List<TransporteModel>();
                //Las consultas siempre retornan el obtejo dentro de una lista.
                transporteModelList = this.ObtenerListaSQL<TransporteModel>(query).ToList();
                return transporteModelList;
            }
        }*/

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
