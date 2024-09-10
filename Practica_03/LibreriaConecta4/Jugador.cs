using PSS.pgr866.Practica_03;

namespace PSS.pgr866.Practica_03
{
    [Serializable]
    public class Jugador
    {
        public int Id { get; }
        public string Nombre { get; }
        public AlgoritmosColumna Algoritmo;
        public static int NumeroJugadores = 0;

        private Ficha _ficha;
        public Ficha Ficha
        {
            get
            {
                if (_ficha == null) throw new Exception("Jugador sin Ficha");
                else return _ficha;
            }
            set { _ficha = value; }
        }


        public Jugador()
        {
            NumeroJugadores++;
            Id = NumeroJugadores;
            Nombre = "Jugador" + NumeroJugadores.ToString();
            Algoritmo = Algoritmos.Humano;
        }

        public Jugador(string nombre)
        {
            NumeroJugadores++;
            Id = NumeroJugadores;
            Nombre = (nombre == "") ? "Jugador" + NumeroJugadores.ToString() : nombre;
            Algoritmo = Algoritmos.Humano;
        }

        public Jugador(string nombre, AlgoritmosColumna algoritmo)
        {
            NumeroJugadores++;
            Id = NumeroJugadores;
            Nombre = nombre;
            Algoritmo = algoritmo;
        }

        public virtual bool ColocarFichaColumna(Juego juego, out int columna)
        {
            columna = Algoritmo(juego, this);
            return juego.Tablero.PonerFichaColumna(this.Ficha, columna);
        }
    }
}