using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSS.pgr866.Practica_05
{
    /// <summary>
    /// Tipo enumerado con Flags para representar los posibles errores codificados de autentificación que se pueden dar conjuntamente 
    /// </summary>
    [FlagsAttribute]
    public enum CodigoAutentificacion
    {
        /// El identificador de usuario y la palabra de paso coinciden con la que está almacenada en el origen de dato
        AccesoCorrecto = 0,
        /// Error en el acceso a la fuente de datos (por ej. error en la apertura del fichero de Usuarios, conexión a la base de datos ...)
        ErrorDatos = 1,
        /// El identificador de usuario existe, pero además es un usuario no válido (no le está permitido acceder al sistema). Es acumulativo con ErrorPalabrapaso.     
        AccesoInvalido = 2,
        /// La clave primaria (UsuarioId) no se encuentra en el origen de datos
        ErrorIdUsuario = 4,
        /// La palabra de paso del usuario encontrado no coincide con la que está almacenada en el origen de dato
        ErrorPalabraPaso = 8
    }

}
