using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSS.pgr866.Practica_05
{
    /// <summary>
    /// Tipo de dato Enumerado  con los distintos campos que integran el registro
    /// </summary>
    public enum CamposRegistro { Id, Nombre, PalabraPaso, Categoria, EsValido };
    /// <summary>
    /// Clase para describir del orden secuencial de los distintos campos en el registro de datos 
    /// </summary>
    public class FormatoRegistro
    {
        /// <summary>
        /// Array de CamposRegistro que contiene la secuencia ordenada de los campos 
        /// </summary>
        private CamposRegistro[] _camposRegistro;
        public CamposRegistro[] CamposRegistro
        {
            get { return _camposRegistro; }
            set { _camposRegistro = value; }
        }
        /// <summary>
        /// En el constructor se estable la secuencia de campos ordenada
        /// </summary>
        /// <param name="camposRegistro">array con la secuencia de los campos</param>
        public FormatoRegistro(CamposRegistro[] camposRegistro)
        {
            _camposRegistro = camposRegistro;
        }
    }

}
