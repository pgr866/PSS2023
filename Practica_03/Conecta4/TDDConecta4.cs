using System;

namespace PSS.pgr866.Practica_03
{
    public class TDDConecta4
    {
        private int[,] tablero = new int[9, 9];
        private string jugador1 = "Jugador1";
        private string jugador2 = "Jugador2";
        private int jugadorActual = 0; // 1 para Jugador1, 2 para Jugador2

        public void IniciarJuego()
        {
            // Pedir los nombres de los jugadores y asignar aleatoriamente el primer turno
            Console.WriteLine("Por favor, {0} Introduzca su Nombre:", jugador1);
            jugador1 = Console.ReadLine();
            Console.WriteLine("Por favor, {0} Introduzca su Nombre:", jugador2);
            jugador2 = Console.ReadLine();
            Console.WriteLine("Bienvenidos, {0} y {1}.", jugador1, jugador2);

            // Seleccionar aleatoriamente el primer jugador
            Random rand = new Random();
            jugadorActual = rand.Next(2);

            // Inicializar todos los elementos del array a 0
            Array.Clear(tablero, 0, tablero.Length);

            Console.WriteLine("Las dimensiones del tablero son de 9x9.");
            Console.WriteLine("El jugador que comienza el juego es {0}.", jugadorActual == 0 ? jugador1 : jugador2);

            while (!(ComprobarGanador() || ComprobarEmpate()))
            {
                do
                {
                    Console.WriteLine($"{0}, elija columna? ", jugadorActual == 1 ? jugador1 : jugador2);
                } while (!IntroducirFicha(int.Parse(Console.ReadLine())));

                if (jugadorActual == 1) jugadorActual = 2;
                else if (jugadorActual == 2) jugadorActual = 1;
            }

            if (ComprobarGanador())
            {
                Console.WriteLine("Ha ganado {0}.", jugadorActual);
            }
            else if(ComprobarEmpate())
            {
                Console.WriteLine("La partida ha terminado en empate.");
            }
        }

        public bool IntroducirFicha(int columna)
        {
            if (ValidarColumna(columna) == false) return false;

            // Introduce la ficha en la columna elegida
            for (int fila = tablero.Length - 1; fila >= 0; fila--)
            {
                if (tablero[fila, columna] == 0)
                {
                    tablero[fila, columna] = jugadorActual;
                    return true;
                }
            }

            // Si no se puede introducir la ficha en la columna, entonces la columna está llena
            Console.WriteLine($"La columna [{columna}] está llena, por favor elija otra? ");
            return false;
        }

        private bool ValidarColumna(int columna)
        {
            // Verifica si la columna está dentro del tablero
            if (columna < 0 || columna >= tablero.GetLength(1))
            {
                Console.WriteLine($"La columna [{columna}] no está dentro del tablero, por favor elija otra? ");
                return false;
            }

            // Verifica si hay espacio disponible en la columna
            if (tablero[0, columna] != 0)
            {
                Console.WriteLine($"La columna [{columna}] está llena, por favor elija otra? ");
                return false;
            }
            return true;
        }

        public bool ComprobarGanador()
        {
            // Comprobar filas
            for (int fila = 0; fila < tablero.GetLength(0); fila++)
            {
                for (int columna = 0; columna < tablero.GetLength(1) - 3; columna++)
                {
                    if (tablero[fila, columna] != 0 &&
                        tablero[fila, columna] == tablero[fila, columna + 1] &&
                        tablero[fila, columna] == tablero[fila, columna + 2] &&
                        tablero[fila, columna] == tablero[fila, columna + 3])
                    {
                        return true;
                    }
                }
            }

            // Comprobar columnas
            for (int fila = 0; fila < tablero.GetLength(0) - 3; fila++)
            {
                for (int columna = 0; columna < tablero.GetLength(1); columna++)
                {
                    if (tablero[fila, columna] != 0 &&
                        tablero[fila, columna] == tablero[fila + 1, columna] &&
                        tablero[fila, columna] == tablero[fila + 2, columna] &&
                        tablero[fila, columna] == tablero[fila + 3, columna])
                    {
                        return true;
                    }
                }
            }

            // Comprobar diagonales descendentes
            for (int fila = 0; fila < tablero.GetLength(0) - 3; fila++)
            {
                for (int columna = 0; columna < tablero.GetLength(1) - 3; columna++)
                {
                    if (tablero[fila, columna] != 0 &&
                        tablero[fila, columna] == tablero[fila + 1, columna + 1] &&
                        tablero[fila, columna] == tablero[fila + 2, columna + 2] &&
                        tablero[fila, columna] == tablero[fila + 3, columna + 3])
                    {
                        return true;
                    }
                }
            }
            // Comprobar diagonales ascendentes
            for (int fila = 3; fila < tablero.GetLength(0); fila++)
            {
                for (int columna = 0; columna < tablero.GetLength(1) - 3; columna++)
                {
                    if (tablero[fila, columna] != 0 &&
                        tablero[fila, columna] == tablero[fila - 1, columna + 1] &&
                        tablero[fila, columna] == tablero[fila - 2, columna + 2] &&
                        tablero[fila, columna] == tablero[fila - 3, columna + 3])
                    {
                        return true;
                    }
                }
            }

            // No hay ganador
            return false;
        }

        private bool ComprobarEmpate()
        {
            // Comprobar si hay empate (es decir, si no hay más espacio disponible en el tablero)
            // Devolver true si hay empate, false en caso contrario

            // Recorremos todas las celdas del tablero
            for (int fila = 0; fila < tablero.GetLength(0); fila++)
            {
                for (int columna = 0; columna < tablero.GetLength(1); columna++)
                {
                    // Si encontramos una celda vacía, no hay empate todavía
                    if (tablero[fila, columna] == 0)
                    {
                        return false;
                    }
                }
            }

            // Si no encontramos celdas vacías, es un empate
            return true;
        }
    }

}