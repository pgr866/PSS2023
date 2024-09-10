namespace PSS.pgr866.Practica_04a
{
    public class vmCategoriaNombre
    {
        public string Nombre { get; set; }
        public string Categoria { get; set; }

        public override bool Equals(Object obj)
        {
            vmCategoriaNombre vm = obj as vmCategoriaNombre;
            if (ReferenceEquals(vm, null))
                return false;
            else
                return Categoria.Equals(vm.Categoria);
        }

        public override int GetHashCode()
        {
            return this.Categoria.GetHashCode();
        }
    }

}