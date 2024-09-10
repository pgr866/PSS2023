using PSS.pgr866.Practica_03;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PSS.pgr866.Practica_03
{
    public delegate int AlgoritmosColumna(Juego juego, Jugador jugadorActual);
    public static class Algoritmos
    {

        public static int Humano(Juego juego, Jugador jugadorActual)
        {
            try
            {
                return int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                return -1;
            }
            
        }
        public static int IAAleatoria(Juego juego, Jugador jugadorActual)
        {
            int sol;
            do
            {
                sol = new Random().Next(0, juego.Tablero.Dimension);
            }
            while (juego.Tablero.SiguenteFilaLibre(sol) == -1);
            Console.WriteLine(sol);
            return sol;
        }

        public static int IALista(Juego juego, Jugador jugadorActual)
        {
            int mejorColumna = 0;
            int mejorPuntuacion = int.MinValue;
            // Obtener lista de columnas posibles
            List<int> columnasPosibles = new List<int>();
            for (int i = 0; i < juego.Tablero.Dimension; i++)
            {
                if (juego.Tablero.SiguenteFilaLibre(i) != -1)
                {
                    columnasPosibles.Add(i);
                }
            }

            // Evaluar cada columna y asignar una puntuación
            foreach (int columna in columnasPosibles)
            {
                int puntuacion = PuntuacionColumna(juego.Tablero, jugadorActual.Ficha.Color, columna);
                if (puntuacion > mejorPuntuacion)
                {
                    mejorPuntuacion = puntuacion;
                    mejorColumna = columna;
                }
            }
            return mejorColumna;
        }

        private static int PuntuacionColumna(Tablero tablero, ColorEnum colorFicha, int columna)
        {
            int puntuacion = 0;
            int fichasConsecutivas = 0;
            for (int fila = tablero.Dimension - 1; fila >= 0; fila--)
            {
                if (tablero[fila, columna] == null)
                {
                    fichasConsecutivas++;
                    if (fichasConsecutivas >= 4)
                    {
                        puntuacion += fichasConsecutivas;
                    }
                }
                else if (tablero[fila, columna].Color == colorFicha)
                {
                    fichasConsecutivas++;
                    if (fichasConsecutivas >= 4)
                    {
                        puntuacion += fichasConsecutivas;
                    }
                }
                else
                {
                    break;
                }
            }
            return puntuacion;
        }
    }
}