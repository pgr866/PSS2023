namespace PSS.pgr866.Practica_04b
{
    public class Plataforma
    {
        private int _id;
        private string _nombrePlataforma;
        private string _path;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string NombrePlataforma
        {
            get { return _nombrePlataforma; }
            set { _nombrePlataforma = value; }
        }

        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }
    }

}