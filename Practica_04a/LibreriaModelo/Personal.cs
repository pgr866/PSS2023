namespace PSS.pgr866.Practica_04a
{
    public class Personal
    {
        private int _Id;
        private int _UsuarioId;
        private int _AplicacionId;
        private string _Password;
        private string _Email;
        private bool _EstaBloqueado;
        private DateTime _FechaAlta;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        public int UsuarioId
        {
            get { return _UsuarioId; }
            set { _UsuarioId = value; }
        }

        public int AplicacionId
        {
            get { return _AplicacionId; }
            set { _AplicacionId = value; }
        }

        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        public bool EstaBloqueado
        {
            get { return _EstaBloqueado; }
            set { _EstaBloqueado = value; }
        }

        public DateTime FechaAlta
        {
            get { return _FechaAlta; }
            set { _FechaAlta = value; }
        }
    }

}