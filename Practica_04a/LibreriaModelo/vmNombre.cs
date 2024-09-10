namespace PSS.pgr866.Practica_04a
{
    public class vmNombre : IEquatable<Object>
    {
        public string Nombre { get; set; }
        public override bool Equals(Object obj)
        {
            vmNombre vm = obj as vmNombre;
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