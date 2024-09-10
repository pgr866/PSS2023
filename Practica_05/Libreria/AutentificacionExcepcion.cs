using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSS.pgr866.Practica_05
{
    public class AutentificacionExcepcion: Exception
    {
        public AutentificacionExcepcion(String mensaje, CodigoAutentificacion codigo) : base(mensaje)
        {
        }
    }
}
