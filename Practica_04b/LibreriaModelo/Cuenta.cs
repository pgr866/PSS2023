namespace PSS.pgr866.Practica_04b
{
    public class Cuenta
    {
        private int _Id;
        private int _VisorId;
        private int _PlataformaId;
        private string _Password;
        private string _Email;
        private bool _EstaBloqueado;
        private DateTime _FechaAlta;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        public int VisorId
        {
            get { return _VisorId; }
            set { _VisorId = value; }
        }

        public int PlataformaId
        {
            get { return _PlataformaId; }
            set { _PlataformaId = value; }
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