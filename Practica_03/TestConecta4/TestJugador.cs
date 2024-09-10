using Microsoft.VisualStudio.TestTools.UnitTesting;
using PSS.pgr866.Practica_03;
using System.Drawing;

namespace PSS.pgr866.Practica_03
{
    [TestClass]
    public class TestJugador
    {
        [TestMethod]
        public void Constructor_SinParametros_EsNoNulo()
        {
            Jugador jugador = new Jugador();
            Assert.IsNotNull(jugador);
        }

        [TestMethod]
        public void Constructor_SinParametros_NombreEsNombreInstancia()
        {
            Jugador.NumeroJugadores = 0;
            Jugador jugador = new Jugador();
            Assert.IsTrue(jugador.Nombre == "Jugador1");
        }

        [TestMethod]
        public void Constructor_ParametroNombre_NombreEsIgual()
        {
        Jugador jugador = new Jugador("Nombre Jugador");
        Assert.AreEqual(jugador.Nombre, "Nombre Jugador");
        }

        [TestMethod]
        public void Ficha_ColorRojo_ColorFichaJugadorEsIgual()
        {
            Jugador jugador = new Jugador();
            jugador.Ficha = new Ficha(ColorEnum.Rojo);
            Assert.IsTrue(jugador.Ficha.Color == ColorEnum.Rojo);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Ficha_SinAsignar_Excepcion()
        {
            Jugador jugador = new Jugador();
            bool resultado = jugador.Ficha.Color == ColorEnum.Rojo;
            Assert.Fail("Se esperaba excepción JugadorSinFichaException");
        }

        [TestMethod]
        public void ColocarFichaColumna_PosicionValida_EsTrue()
        {
            Jugador jugador = new Jugador("Nombre Jugador", Algoritmos.IAAleatoria);
            jugador.Ficha = new Ficha(ColorEnum.Rojo);
            Juego juego = new Juego();
            juego.AnnadirJugador(jugador);
            Assert.IsTrue(jugador.ColocarFichaColumna(juego, out int columna));
        }

        [TestMethod]
        public void AlgoritmoColumna_AlgoritmoIAAleatoria_EsPosicionAdecuada()
        {
            Jugador jugador = new Jugador("Nombre Jugador", Algoritmos.IAAleatoria);
            jugador.Ficha = new Ficha(ColorEnum.Rojo);
            Juego juego = new Juego();
            juego.AnnadirJugador(jugador);
            Assert.IsTrue(jugador.ColocarFichaColumna(juego, out int columna));
        }

        [TestMethod]
        public void AlgoritmoColumna_AlgoritmoIALista_EsPosicionAdecuada()
        {
            Jugador jugador = new Jugador("Nombre Jugador", Algoritmos.IALista);
            jugador.Ficha = new Ficha(ColorEnum.Rojo);
            Juego juego = new Juego();
            juego.AnnadirJugador(jugador);
            Assert.IsTrue(jugador.ColocarFichaColumna(juego, out int columna));
        }
    }
}
