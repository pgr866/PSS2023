namespace PSS.pgr866.Practica_04a
{
    public class Categoria
    {
        private int _Id;
        private string _NombreCategoria;
        private int _AplicacionId;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        public string NombreCategoria
        {
            get { return _NombreCategoria; }
            set { _NombreCategoria = value; }
        }
        public int AplicacionId
        {
            get { return _AplicacionId; }
            set { _AplicacionId = value; }
        }
    }

}