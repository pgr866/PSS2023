using PSS.pgr866.Practica_03;
using System;
using System.Data;
using Conecta4AppConsola;
using System.Resources;

ResourceManager idioma = null;
while (true)
{
    Console.Clear();
    Console.WriteLine("1) Español\n2) English");
    Console.Write("Elige tu idioma / Choose your language: ");
    string aux = Console.ReadLine();
    if (aux == "1") idioma = new ResourceManager("Conecta4AppConsola.Conecta4ResourceES", typeof(Program).Assembly);
    if (aux == "2") idioma = new ResourceManager("Conecta4AppConsola.Conecta4Resource", typeof(Program).Assembly);
    if (aux != "1" && aux != "2") continue;
    break;
}

Console.Clear();
Console.Write(idioma.GetString("Name1"));
string nombre1 = Console.ReadLine();

string algoritmo1;
Jugador jugador1 = null;
while (true)
{
    Console.Clear();
    Console.WriteLine(idioma.GetString("Algoritmo"));
    Console.Write(idioma.GetString("Algoritmo1"));
    algoritmo1 = Console.ReadLine();

    switch (algoritmo1)
    {
        case "1":
            jugador1 = new Jugador(nombre1, Algoritmos.Humano);
            break;
        case "2":
            jugador1 = new Jugador(nombre1, Algoritmos.IAAleatoria);
            break;
        case "3":
            jugador1 = new Jugador(nombre1, Algoritmos.IALista);
            break;
    }
    if (algoritmo1 != "1" && algoritmo1 != "2" && algoritmo1 != "3") continue;
    break;
}

Console.Clear();
Console.Write(idioma.GetString("Name2"));
string nombre2 = Console.ReadLine();

string algoritmo2;
Jugador jugador2 = null;
while (true)
{
    Console.Clear();
    Console.WriteLine(idioma.GetString("Algoritmo"));
    Console.Write(idioma.GetString("Algoritmo2"));
    algoritmo2 = Console.ReadLine();

    switch (algoritmo2)
    {
        case "1":
            jugador2 = new Jugador(nombre2, Algoritmos.Humano);
            break;
        case "2":
            jugador2 = new Jugador(nombre2, Algoritmos.IAAleatoria);
            break;
        case "3":
            jugador2 = new Jugador(nombre2, Algoritmos.IALista);
            break;
    }
    if (algoritmo2 != "1" && algoritmo2 != "2" && algoritmo2 != "3") continue;
    break;
}

jugador1.Ficha = new Ficha(ColorEnum.Rojo);
jugador2.Ficha = new Ficha(ColorEnum.Azul);

int dimension;
while (true)
{
    Console.Clear();
    Console.Write(idioma.GetString("Dimension"));
    if (!int.TryParse(Console.ReadLine(), out dimension)) continue;
    break;
}

Juego juego = new Juego(dimension);
juego.AnnadirJugador(jugador1);
juego.AnnadirJugador(jugador2);

bool hayGanador = false;
Jugador jugadorActual = null;

var rnd = new Random(DateTime.Now.Millisecond);
int id = rnd.Next(2) + 1;

do
{
    bool columnaValida = false;
    do
    {
        jugadorActual = juego.ObtenerJugador(id);
        Console.Clear();
        juego.Tablero.PrintTablero();
        Console.Write(jugadorActual.Nombre + idioma.GetString("InputColumna"));
        columnaValida = jugadorActual.ColocarFichaColumna(juego, out int columna);
        if (!columnaValida) Console.WriteLine(idioma.GetString("ColumnaInvalida"));
    } while (!columnaValida);

    id = (id % 2) + 1;
    hayGanador = juego.EsGanador(jugadorActual);
} while (!juego.Tablero.EsLLeno && !hayGanador);

Console.Clear();
juego.Tablero.PrintTablero();
if (hayGanador) Console.WriteLine(idioma.GetString("Ganador") + jugadorActual.Nombre);
else Console.WriteLine(idioma.GetString("Empate"));
