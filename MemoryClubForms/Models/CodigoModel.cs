using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace MemoryClubForms.Models
{
    //Modelo de la tabla Código
    public class CodigoModel
    {
        CultureInfo ci = new CultureInfo("en-US");
        public int Id_codigo { get; set; }
        public string Grupo { get; set; }
        public string Subgrupo { get; set; }
        public string Elemento { get; set; }
        public string Descripcion { get; set; } 
        public int Valor1 { get; set; }
        public decimal Valor2 { get; set; }
        public string Estado { get; set; }
        public string Usuario { get; set; }
        public string Fecha_mod { get; set; }

        /// <summary>
        /// Valida los campos no nulos de la tabla Codigos
        /// </summary>
        /// <param name="codigoModel"></param>
        /// <returns>string mensaje</returns>
        public string Validate(CodigoModel codigoModel)
        {
            string message = string.Empty;

            if (string.IsNullOrEmpty(codigoModel.Grupo))
            {
                return "Código de Grupo no puede ser nulo o blanco";
            }
            if (string.IsNullOrEmpty(codigoModel.Subgrupo))
            {
                return "Código de Subgrupo no puede ser nulo o blanco";
            }
            if (string.IsNullOrEmpty(codigoModel.Elemento))
            {
                return "Código de Elemento no puede ser nulo o blanco";
            }
            if (string.IsNullOrEmpty(codigoModel.Descripcion))
            {
                return "Por favor, debe ingresar la descripción para el parámetro";
            }
            if (string.IsNullOrEmpty(codigoModel.Estado))
            {
                return "Por favor, debe ingresar el estado del parámetro";
            }
            return message;
        }
    }
}
