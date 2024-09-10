namespace PSS.pgr866.Practica_04a
{
    public class Aplicacion
    {
        private int _id;
        private string _nombreAplicacion;
        private string _path;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string NombreAplicacion
        {
            get { return _nombreAplicacion; }
            set { _nombreAplicacion = value; }
        }

        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }
    }

}