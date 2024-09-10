namespace PSS.pgr866.Practica_04b
{
    public class Visualizacion
    {
        private int _id;
        private string _ip;
        private DateTime _fechaInicio;
        private double _duracion;
        private int _visorGeneroId;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string IP
        {
            get { return _ip; }
            set { _ip = value; }
        }

        public DateTime FechaInicio
        {
            get { return _fechaInicio; }
            set { _fechaInicio = value; }
        }

        public double Duracion
        {
            get { return _duracion; }
            set { _duracion = value; }
        }

        public int VisorGeneroId
        {
            get { return _visorGeneroId; }
            set { _visorGeneroId = value; }
        }

        public Visualizacion()
        {

        }
    }

}