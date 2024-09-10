namespace PSS.pgr866.Practica_04a
{
    public class Usuario
    {
        private int _Id;
        private string _NombreUsuario;
        private bool _EsAnonimo;
        private int _AplicacionId;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        public string NombreUsuario
        {
            get { return _NombreUsuario; }
            set { _NombreUsuario = value; }
        }

        public bool EsAnonimo
        {
            get { return _EsAnonimo; }
            set { _EsAnonimo = value; }
        }

        public int AplicacionId
        {
            get { return _AplicacionId; }
            set { _AplicacionId = value; }
        }

        public Usuario()
        {
            _Id = 0;
            _NombreUsuario = null;
            _EsAnonimo = false;
            _AplicacionId = 0;
        }
    }

}