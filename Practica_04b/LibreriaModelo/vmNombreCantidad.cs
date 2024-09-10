using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSS.pgr866.Practica_04b
{
    public class vmNombreCantidad
    {
        public string Nombre { get; set; }
        public double Cantidad { get; set; }

        public override bool Equals(Object obj)
        {
            vmNombreCantidad vm = obj as vmNombreCantidad;
            if (ReferenceEquals(vm, null))
                return false;
            else
                return Nombre.Equals(vm.Nombre);
        }

        public override int GetHashCode()
        {
            return this.Nombre.GetHashCode();
        }
    }

}