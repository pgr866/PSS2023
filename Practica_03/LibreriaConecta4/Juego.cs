using PSS.pgr866.Practica_03;
using System.Drawing;
using System.Runtime.Serialization;

namespace PSS.pgr866.Practica_03
{
    [Serializable]

    public class NombreJugadorDuplicadoException : Exception
    {
        public NombreJugadorDuplicadoException()
        {
        }

        public NombreJugadorDuplicadoException(string? message) : base(message)
        {
        }

        public NombreJugadorDuplicadoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NombreJugadorDuplicadoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
    public class Juego
    {
        private Dictionary<string, Jugador> Jugadores = new Dictionary<string, Jugador>();
        public int NumeroJugadores { get { return Jugadores.Count; } }
        public Tablero Tablero { get; set; }

        public Juego()
        {
            Jugador.NumeroJugadores = 0;
            this.Tablero = new Tablero();
        }

        public Juego(int dimension)
        {
            Jugador.NumeroJugadores = 0;
            this.Tablero = new Tablero(dimension);
        }

        public void AnnadirJugador(Jugador jugador)
        {
            try
            {
                Jugadores.Add(jugador.Nombre, jugador);
            }
            catch (Exception ex)
            {
                throw new NombreJugadorDuplicadoException("El nombre del jugador " + jugador.Nombre + " ya existe.");
            }
        }

        public Jugador ObtenerJugador(int idJugador)
        {
            foreach (var jug in this.Jugadores.Values)
            {
                if (jug.Id == idJugador) return Jugadores[jug.Nombre];
            }
            throw new IndexOutOfRangeException("Id jugador no existe " + idJugador);
        }

        public Jugador ObtenerJugador(string nombre)
        {
            try
            {
                return Jugadores[nombre];
            }
            catch (Exception ex)
            {
                throw new IndexOutOfRangeException("Nombre de jugador no existe " + nombre);
            }
        }

        public bool EsGanador(Jugador jugadorActual)
        {
            if (EsFila(jugadorActual) || EsColumna(jugadorActual) || EsDiagonal(jugadorActual) || EsDiagonalInversa(jugadorActual)) return true;
            return false;
        }

        private bool EsFila(Jugador jugadorActual)
        {
            for (int fila = 0; fila < Tablero.Dimension; fila++)
            {
                int contador = 0;
                for (int col = 0; col < Tablero.Dimension; col++)
                {
                    if (Tablero[fila, col] == jugadorActual.Ficha)
                    {
                        contador++;
                        if (contador == 4) return true;
                    }
                    else contador = 0;
                }
            }
            return false;
        }

        private bool EsColumna(Jugador jugadorActual)
        {
            for (int col = 0; col < Tablero.Dimension; col++)
            {
                int contador = 0;
                for (int fila = 0; fila < Tablero.Dimension; fila++)
                {
                    if (Tablero[fila, col] == jugadorActual.Ficha)
                    {
                        contador++;
                        if (contador == 4) return true;
                    }
                    else contador = 0;
                }
            }
            return false;
        }

        private bool EsDiagonal(Jugador jugadorActual)
        {
            for (int fila = 0; fila <= Tablero.Dimension - 4; fila++)
            {
                for (int col = 0; col <= Tablero.Dimension - 4; col++)
                {
                    int contador = 0;
                    for (int i = 0; i < 4; i++)
                    {
                        if (Tablero[fila + i, col + i] == jugadorActual.Ficha)
                        {
                            contador++;
                            if (contador == 4) return true;
                        }
                        else contador = 0;
                    }
                }
            }
            return false;
        }

        private bool EsDiagonalInversa(Jugador jugadorActual)
        {
            for (int fila = Tablero.Dimension - 1; fila >= 4 - 1; fila--)
            {
                for (int col = 0; col <= Tablero.Dimension - 4; col++)
                {
                    int contador = 0;
                    for (int i = 0; i < 4; i++)
                    {
                        if (Tablero[fila - i, col + i] == jugadorActual.Ficha)
                        {
                            contador++;
                            if (contador == 4) return true;
                        }
                        else contador = 0;
                    }
                }
            }
            return false;
        }
    }
}