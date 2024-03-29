﻿using MemoryClubForms.Data;
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
    //Gestiona la tabla Cliente
    public class ClienteBO
    {
        public static int nivel = VariablesGlobales.Nivel;
        public static int sucursal = VariablesGlobales.sucursal;

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
        /// Devuelve la lista de los generos para los clientes (M/F)
        /// </summary>
        /// <returns>Lista</returns>
        public List<CodigosGenero> LoadGeneros()
        {
            string query = "";
            query = $"SELECT elemento as generos from Codigo WHERE grupo = \'GEN\' AND subgrupo = \'GENERO\' AND elemento <> \'\' AND estado = \'A\'";
            List<CodigosGenero> codigosGeneroslist = new List<CodigosGenero>();
            codigosGeneroslist = this.ObtenerListaSQL<CodigosGenero>(query).ToList();

            return codigosGeneroslist;
        }

        /// <summary>
        /// Devuelve la lista de los estados para los clientes (A, I, P = prueba)
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
        /// Devuelve lista de los medios de pago de los clientes (efec/cheque/deposito/etc)
        /// </summary>
        /// <returns></returns>
        public List<CodigosMediosPago> LoadMediosPago()
        {
            string query = "";
            query = $"SELECT elemento as mediospago from Codigo WHERE grupo = \'CLI\' AND subgrupo = \'MPAGO\' AND elemento <> \'\' AND estado = \'A\'";
            List<CodigosMediosPago> codigosMediosPlist = new List<CodigosMediosPago>();
            codigosMediosPlist = this.ObtenerListaSQL<CodigosMediosPago>(query).ToList();

            return codigosMediosPlist;
        }

        /// <summary>
        /// Devuelve Lista de Transportistas activos ordenado por nombre
        /// </summary>
        /// <returns></returns>
        public List<ListaTransportistas> LoadTransportistas()
        {
            string query = "";
            query = $"SELECT id_transportista, nombre FROM Transportista WHERE estado = \'A\'";
            List<ListaTransportistas> transportistaslist = new List<ListaTransportistas>();
            transportistaslist = this.ObtenerListaSQL<ListaTransportistas>(query).ToList();

            return transportistaslist.OrderBy(x => x.Nombre).ToList();
        }


        /// <summary>
        /// Devuelve Lista de todos los Transportistas ordenado por nombre
        /// </summary>
        /// <returns></returns>
        public List<ListaTransportistas> TodosTransportistas()
        {
            string query = "";
            query = $"SELECT id_transportista, nombre FROM Transportista ";
            List<ListaTransportistas> transportistaslist = new List<ListaTransportistas>();
            transportistaslist = this.ObtenerListaSQL<ListaTransportistas>(query).ToList();

            return transportistaslist.OrderBy(x => x.Nombre).ToList();
        }

        /// <summary>
        /// Devuelve Lista de Frecuencias de Pago
        /// </summary>
        /// <returns></returns>
        public List<ListaFrecuencias> LoadFrecuencias()
        {
            string query = "";
            query = $"SELECT elemento as frecuencias, descripcion from Codigo WHERE grupo = \'CLI\' AND subgrupo = \'FPAGO\' AND elemento <> \'\' AND estado = \'A\'";
            List<ListaFrecuencias> frecuenciaslist = new List<ListaFrecuencias>();
            frecuenciaslist = this.ObtenerListaSQL<ListaFrecuencias>(query).ToList();

            return frecuenciaslist;
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
        /// Consulta general de Clientes (cedula, nombre, apodo, fechaing, estado, sucursal, dia, mes, año nacim, id_transportista, medios de pago)
        /// </summary>
        /// <param name="Pcedula"></param>
        /// <param name="Pnombre"></param>
        /// <param name="Papodo"></param>
        /// <param name="Pfecha_ing"></param>
        /// <param name="Pestado"></param>
        /// <param name="Psucursal"></param>
        /// <param name="Pdia_nacim"></param>
        /// <param name="Pmes_nacim"></param>
        /// <param name="Panio_nacim"></param>
        /// <param name="Pid_transportista"></param>
        /// <param name="Pmedio_pago"></param>
        /// <returns></returns>
        public List<ClienteModel> ConsultaCliente(string Pcedula, string Pnombre, string Papodo, string Pfecha_ing, string Pestado, int Psucursal, int Pdia_nacim, int Pmes_nacim, int Panio_nacim, int Pid_transportista, string Pmedio_pago)
        {
            string query = "";
            string condiciones = "";
  
            //valido cedula
            if (!(string.IsNullOrEmpty(Pcedula)))
            {
                condiciones += $" AND C.cedula LIKE '%{Pcedula}%' ";
            }
            //valido nombre
            if (!(string.IsNullOrEmpty(Pnombre)))
            {
                condiciones += $" AND C.nombre LIKE '%{Pnombre}%' ";
            }
            //valido apodo
            if (!(string.IsNullOrEmpty(Papodo)))
            {
                condiciones += $" AND C.apodo LIKE '%{Papodo}%' ";
            }
            //valido fecha ingreso
            if (!(string.IsNullOrEmpty(Pfecha_ing)) )
            {
                condiciones += $" AND CONVERT(date, C.fecha_ingreso,101) = CAST('{Pfecha_ing}' AS date) ";
            }
            if (Pestado == "T")
            {
                Pestado = string.Empty;
            }
            //valida estado
            if (!(string.IsNullOrEmpty(Pestado)))
            {
                condiciones += $" AND C.estado = '{Pestado}' ";
            }
            else //si el estado es nulo o blanco, recupera por defecto solo los clientes activos y de prueba
            {
                condiciones += $" AND C.estado IN (\'A\',\'P\') ";
            }
            //valido sucursal
            if (Psucursal > 0)
            {
                if (nivel <= 1) //solo el nivel administrador puede consultar cualquier sucursal
                { condiciones += $" AND C.sucursal = {Psucursal} "; }
                else
                { condiciones += $" AND C.sucursal = {sucursal} "; } //los otros niveles solo consultan su propia sucursal
            }
            else //no se ha seleccionado sucursal
            {
                if (nivel > 1)  //para cualquier otro nivel de usuario se envia su propia sucursal
                { condiciones += $" AND C.sucursal = {sucursal} "; }
            }
            //valido dia de nacimiento
            if (Pdia_nacim > 0)
            {
                condiciones += $" AND C.dia_nacim = {Pdia_nacim} ";
            }
            //valido mes de nacimiento
            if (Pmes_nacim > 0)
            {
                condiciones += $" AND C.mes_nacim = {Pmes_nacim} ";
            }
            //valido año de nacimiento
            if (Panio_nacim > 0)
            {
                condiciones += $" AND C.anio_nacim = {Panio_nacim} ";
            }
            //valido transportista
            if (Pid_transportista > 0)
            {
                condiciones += $" AND C.id_transportista = {Pid_transportista} ";
            }
            //valido medio de pago
            if (!(string.IsNullOrEmpty(Pmedio_pago)))
            {
                condiciones += $" AND C.medio_pago = '{Pmedio_pago}' ";
            }

            //armo el select con las opciones dadas          
            query = $"SET LANGUAGE us_english " +
                $"SELECT C.id_cliente, C.cedula, C.nombre, C.apodo, C.fecha_ingreso, C.fecha_free, C.sexo, C.estado, C.aula, " +
                $"C.dia_nacim, C.mes_nacim, C.anio_nacim,C.telefono, C.nombre_contacto, C.parentesco_contacto, C.telefono_contacto, " +
                $"C.celular_contacto, C.encargado_pago, C.parentesco_pago, C.telefono_pago, C.cedula_pago, C.celular_pago, C.email_pago," +
                $" C.medio_pago, C.frecuencia_pago, C.pariente_transp, C.direccion, C.toma_transp, C.id_transportista, T.nombre as nombre_transportista, " +
                $"C.retirarse_solo, C.nombre_factu, C.cedula_factu, C.direccion_factu, C.email_factu, C.sucursal, C.observacion, C.usuario, " +
                $"C.fecha_mod, C.valor_transporte, CONVERT(date, C.fecha_ingreso, 101) fechaing FROM Cliente C LEFT JOIN Transportista T ON C.id_transportista = T.id_transportista " +
                $"WHERE C.id_cliente >= 0  {condiciones}";

            List<ClienteModel> clienteModelList = new List<ClienteModel>();
            //Las consultas siempre retornan el obtejo dentro de una lista.
            clienteModelList = this.ObtenerListaSQL<ClienteModel>(query).ToList();
            return clienteModelList.OrderBy(x => x.Fechaing).ThenBy(c => c.Nombre).ToList();

        }

        /// <summary>
        /// Valida si se duplica la cedula de un cliente para añadir un registro
        /// </summary>
        /// <param name="Pcedula"></param>
        /// <returns></returns>
        private bool ValidaDuplicadoCliente(ClienteModel clienteModel)
        {
            string query = $"SELECT * FROM Cliente WHERE cedula = '{clienteModel.Cedula}'";

            List<ClienteModel> cedulasList = new List<ClienteModel>();
            cedulasList = this.ObtenerListaSQL<ClienteModel>(query).ToList();

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
        /// Valida que solo un usuario nivel 0 o 1 pueda añadir, modificar o eliminar en la tabla Cliente
        /// </summary>
        /// <returns>TRUE/FALSE</returns>
        private bool ValidaNivelCliente()
        {
            if (nivel <= 1) //solo usuario administrador inserta, modifica o elimina Cliente
            { return true; }
            else
            { return false; }
        }

        /// <summary>
        /// Inserta un registro en la tabla Cliente
        /// </summary>
        /// <param name="clienteModel"></param>
        /// <returns>TRUE/FALSE</returns>
        public string InsertarCliente(ClienteModel clienteModel)
        {
            string msg = "";
            bool valida = this.ValidaNivelCliente();
            if (valida == true)
            {
                msg = clienteModel.Validate(clienteModel);
                if (!(string.IsNullOrEmpty(msg)))   //si hay errores en los datos del modelo retorna falso
                {
                    return msg;
                }
                else
                {
                    bool aux = ValidaDuplicadoCliente(clienteModel); //valida que no se duplique la cedula
                    if (aux == true)
                    {
                        string query = $"INSERT INTO Cliente (cedula, nombre, apodo, fecha_ingreso, fecha_free, sexo, estado, aula, dia_nacim, mes_nacim, anio_nacim, " +
                                   $"telefono, nombre_contacto, parentesco_contacto, telefono_contacto, celular_contacto, encargado_pago, parentesco_pago, telefono_pago, " +
                                   $"cedula_pago, celular_pago, email_pago, medio_pago, frecuencia_pago, pariente_transp, direccion, toma_transp, id_transportista, retirarse_solo, nombre_factu, " +
                                   $"cedula_factu, direccion_factu, email_factu, sucursal, observacion, usuario, fecha_mod, valor_transporte) " +
                                   $"VALUES ('{clienteModel.Cedula}', '{clienteModel.Nombre}', '{clienteModel.Apodo}', '{clienteModel.Fecha_ingreso}', '{clienteModel.Fecha_free}', '{clienteModel.Sexo}', " +
                                   $"'{clienteModel.Estado}', {clienteModel.Aula}, {clienteModel.Dia_nacim}, {clienteModel.Mes_nacim}, {clienteModel.Anio_nacim}, '{clienteModel.Telefono}', " +
                                   $"'{clienteModel.Nombre_contacto}', '{clienteModel.Parentesco_contacto}', '{clienteModel.Telefono_contacto}', '{clienteModel.Celular_contacto}', '{clienteModel.Encargado_pago}', " +
                                   $"'{clienteModel.Parentesco_pago}', '{clienteModel.Telefono_pago}', '{clienteModel.Cedula_pago}', '{clienteModel.Celular_pago}', '{clienteModel.Email_pago}', " +
                                   $"'{clienteModel.Medio_pago}',  '{clienteModel.Frecuencia_pago}', '{clienteModel.Pariente_transp}', '{clienteModel.Direccion}', '{clienteModel.Toma_transp}', {clienteModel.Id_transportista}, " +
                                   $"'{clienteModel.Retirarse_solo}', '{clienteModel.Nombre_factu}', '{clienteModel.Cedula_factu}', '{clienteModel.Direccion_factu}', '{clienteModel.Email_factu}', " +
                                   $"{clienteModel.Sucursal}, '{clienteModel.Observacion}', '{clienteModel.Usuario}', '{clienteModel.Fecha_mod}', {clienteModel.Valor_transporte})";
                        try
                        {
                            bool execute = SQLConexionDataBase.Execute(query);
                            if(execute)
                            { msg = "OK"; }
                        }
                        catch (SqlException ex)
                        {
                            msg = "Error al insertar Cliente\n" + ex.Message;
                            return msg;                            
                        }
                    }
                    else
                    {
                        msg = "\nError, Este número de cédula ya existe";
                        return msg;
                    } //ya existe esa cedula
                }
            }
            else
            {
                msg = "Usuario no autorizado para insertar Cliente";
                return msg;
            }
            return msg;
        }

        /// <summary>
        /// Actualiza Cliente (apodo, fecha_free, estado, aula, dia, mes, año nacimiento, tfono, nombre contac, parentesco contac, tfono contac,celu contac, encargado pago, ...
        /// (parentesco pago, fono pago, cedula pago, celu pago, email pago, medio pago, frecuencia pago, pariente trans, direcc, toma transporte, id transportista, retirarse solo..
        /// (nombre factura, cedula factu, direccion factu, email factu, sucursal, observacion, usuario, fecha mod, valor transp.) son 33 campos que puede modificar
        /// </summary>
        /// <param name="PclienteModel"></param>
        /// <returns></returns>
        public string ActualizarCliente(ClienteModel clienteModel)
        {
            string msg = "";
            bool valida = this.ValidaNivelCliente();
            if (valida == true)
            {
                msg = clienteModel.Validate(clienteModel);
                if (!(string.IsNullOrEmpty(msg)))   //si hay errores en los datos del modelo retorna falso
                {
                    return msg;
                }
                else
                {
                    string query = $"SET LANGUAGE us_english " +
                                   $"UPDATE Cliente SET nombre = '{clienteModel.Nombre}', apodo = '{clienteModel.Apodo}', fecha_free = '{clienteModel.Fecha_free}', estado = '{clienteModel.Estado}', aula = {clienteModel.Aula}, " +
                                   $"dia_nacim = {clienteModel.Dia_nacim}, mes_nacim = {clienteModel.Mes_nacim}, anio_nacim = {clienteModel.Anio_nacim}, telefono = '{clienteModel.Telefono}', " +
                                   $"nombre_contacto = '{clienteModel.Nombre_contacto}', parentesco_contacto = '{clienteModel.Parentesco_contacto}', telefono_contacto = '{clienteModel.Telefono_contacto}', " +
                                   $"celular_contacto = '{clienteModel.Celular_contacto}', encargado_pago = '{clienteModel.Encargado_pago}', parentesco_pago = '{clienteModel.Parentesco_pago}', " +
                                   $"telefono_pago = '{clienteModel.Telefono_pago}', cedula_pago = '{clienteModel.Cedula_pago}', celular_pago = '{clienteModel.Celular_pago}', email_pago = '{clienteModel.Email_pago}', " +
                                   $"medio_pago = '{clienteModel.Medio_pago}', frecuencia_pago = '{clienteModel.Frecuencia_pago}', pariente_transp = '{clienteModel.Pariente_transp}', direccion = '{clienteModel.Direccion}', toma_transp = '{clienteModel.Toma_transp}', " +
                                   $"id_transportista = '{clienteModel.Id_transportista}', retirarse_solo = '{clienteModel.Retirarse_solo}', nombre_factu = '{clienteModel.Nombre_factu}', " +
                                   $"cedula_factu = '{clienteModel.Cedula_factu}', direccion_factu = '{clienteModel.Direccion_factu}', email_factu = '{clienteModel.Email_factu}', sucursal = {clienteModel.Sucursal}, " +
                                   $"observacion = '{clienteModel.Observacion}', usuario = '{clienteModel.Usuario}', fecha_mod = '{clienteModel.Fecha_mod}', valor_transporte = {clienteModel.Valor_transporte} " +
                                   $"WHERE id_cliente = {clienteModel.Id_cliente}";

                    try
                    {
                        bool execute = SQLConexionDataBase.Execute(query);
                        if (execute)
                        { msg = "OK"; }
                    }
                    catch (SqlException ex)
                    {
                        msg = "Error al actualizar Cliente\n" + ex.Message;
                        return msg;                       
                    }
                }
            }
            else
            {
                msg = "Usuario no autorizado para editar Cliente";
                return msg;
            }
            return msg;
        }

        /// <summary>
        /// Eliminar registro de cliente
        /// </summary>
        /// <param name="clienteModel"></param>
        /// <returns>TRUE/FALSE</returns>
        public bool EliminarCliente(ClienteModel clienteModel)
        {
            bool aux = ValidaNivelCliente(); //solo el nivel administrador puede eliminar cliente
            if (aux == true)
            {
                string query = $"DELETE FROM Cliente WHERE id_cliente = {clienteModel.Id_cliente}";
                try
                {
                    bool execute = SQLConexionDataBase.Execute(query);
                    return execute;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error al eliminar Cliente", ex.Message);
                    return false;
                }
            }
            else
            { return false;  }
        }

        /// <summary>
        /// List model de Sucursales
        /// </summary>
        public class CodigosSucursales
        {
            public int Sucursales { get; set; }
        }

        //List Model de los códigos de género
        public class CodigosGenero //Masculino / femenino
        {
            public string Generos { get; set; }
        }

        //List Model de los códigos de estado de clientes
        public class CodigosEstados
        {
            public string Estados { get; set; }
            public string Descripcion { get; set; }
        }
        //List Model de los códigos de los medios de pago
        public class CodigosMediosPago
        {
            public string Mediospago { get; set; }
        }
        
        //List Model de los id's y nombres de transportistas
        public class ListaTransportistas
        {
            public int Id_transportista { get; set; }
            public string Nombre { get; set; }
        }

        //List Model de las frecuencias de pago
        public class ListaFrecuencias
        {
            public string Frecuencias { get; set; }
        }

    }
}
