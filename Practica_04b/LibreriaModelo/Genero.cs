namespace PSS.pgr866.Practica_04b
{
    public class Genero
    {
        private int _Id;
        private string _NombreGenero;
        private int _PlataformaId;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        public string NombreGenero
        {
            get { return _NombreGenero; }
            set { _NombreGenero = value; }
        }
        public int PlataformaId
        {
            get { return _PlataformaId; }
            set { _PlataformaId = value; }
        }
    }

}