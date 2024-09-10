namespace PSS.pgr866.Practica_04b
{
    public class Visor
    {
        private int _Id;
        private string _NombreVisor;
        private bool _EsAnonimo;
        private int _PlataformaId;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        public string NombreVisor
        {
            get { return _NombreVisor; }
            set { _NombreVisor = value; }
        }

        public bool EsAnonimo
        {
            get { return _EsAnonimo; }
            set { _EsAnonimo = value; }
        }

        public int PlataformaId
        {
            get { return _PlataformaId; }
            set { _PlataformaId = value; }
        }

        public Visor()
        {
            _Id = 0;
            _NombreVisor = null;
            _EsAnonimo = false;
            _PlataformaId = 0;
        }
    }

}