using PSS.pgr866.Practica_03;
using System.Text;

namespace PSS.pgr866.Practica_03
{
    public class Tablero
    {
        private Ficha[,] _casillas;
        public Ficha this[int fila, int columna]
        {
            get { return _casillas[fila, columna]; }
            set { _casillas[fila, columna] = value; }
        }

        private static int _dimension = 9;
        public int Dimension { get { return _dimension; } }

        public int NumeroCasillasOcupadas { get; set; }

        public bool EsLLeno { get { return NumeroCasillasOcupadas >= _dimension * _dimension; } }

        public Tablero()
        {
            _dimension = 9;
            _casillas = new Ficha[9, 9];
        }

        public Tablero(int dimension)
        {
            _dimension = dimension;
            _casillas = new Ficha[dimension, dimension];
        }

        public int SiguenteFilaLibre(int columna)
        {
            for (int i = Dimension - 1; i >= 0; i--)
                if (this[i, columna] == null) return i;
            return -1;
        }

        public bool PonerFichaColumna(Ficha ficha, int columna)
        {
            if (columna >= 0 && columna < Dimension)
            {
                int fila = SiguenteFilaLibre(columna);
                if (fila != -1)
                {
                    this[fila, columna] = ficha;
                    NumeroCasillasOcupadas++;
                    return true;
                }
                return false;
            }
            return false;
        }

        public void PrintTablero()
        {
            Console.Write("  ");
            for (int j = 0; j < Dimension; j++)
            {
                Console.Write(j + "  ");
            }
            Console.Write("\n");

            Console.Write("  ");
            for (int j = 0; j < Dimension; j++)
            {
                Console.Write("-- ");
            }
            Console.Write("\n");

            for (int i = 0; i < Dimension; i++)
            {
                Console.Write(i + "| ");
                for (int j = 0; j < Dimension; j++)
                {
                    Ficha ficha = this[i, j];
                    if (ficha == null)
                    {
                        Console.Write(" | ");
                    }
                    else if (ficha.Color == ColorEnum.Rojo)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("R");
                        Console.ResetColor();
                        Console.Write("| ");
                    }
                    else if (ficha.Color == ColorEnum.Azul)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("A");
                        Console.ResetColor();
                        Console.Write("| ");
                    }
                }
                Console.Write("\n  ");
                for (int j = 0; j < Dimension; j++)
                {
                    Console.Write("-- ");
                }
                Console.Write("\n");
            }
        }
    }
}