namespace PSS.pgr866.Practica_04b
{
    public class vmGeneroNombre
    {

        public string Genero { get; set; }
        public string Nombre { get; set; }

        public override bool Equals(Object obj)
        {
            vmGeneroNombre vm = obj as vmGeneroNombre;
            if (ReferenceEquals(vm, null))
                return false;
            else
                return Genero.Equals(vm.Genero);
        }

        public override int GetHashCode()
        {
            return this.Genero.GetHashCode();
        }
    }

}