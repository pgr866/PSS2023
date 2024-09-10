namespace PSS.pgr866.Practica_04b
{
    public class VisorGenero
    {
        private int _id;
        private int _generoId;
        private int _visorId;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public int GeneroId
        {
            get { return _generoId; }
            set { _generoId = value; }
        }

        public int VisorId
        {
            get { return _visorId; }
            set { _visorId = value; }
        }
    }

}