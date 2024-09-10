using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using PSS.pgr866.Practica_03;
using System.Drawing;
using System.Text;

namespace PSS.pgr866.Practica_03
{
    [TestClass]
    public class TestJuego
    {
        [TestMethod]
        public void Constructor_SinParametros_EsNoNulo()
        {
            Juego juego = new Juego();
            Assert.IsNotNull(juego);
        }

        [TestMethod]
        public void AnnadirJugador_NombreJugador_NumeroJugadoresEs1()
        {
            Juego juego = new Juego();
            Jugador jugador = new Jugador();
            juego.AnnadirJugador(jugador);
            Assert.IsTrue(juego.NumeroJugadores == 1);
        }

        [TestMethod]
        public void ObtenerJugador_NombreJugador_EsElMismo()
        {
            Juego juego = new Juego();
            Jugador jugador1 = new Jugador();
            juego.AnnadirJugador(jugador1);
            Jugador jugador2 = new Jugador();
            juego.AnnadirJugador(jugador2);
            Assert.AreEqual(juego.ObtenerJugador("Jugador1"), jugador1);
        }

        [TestMethod]
        [ExpectedException(typeof(NombreJugadorDuplicadoException))]
        public void AnnadirJugador_NombreJugadorExistente_NombreJugadorDuplicadoException()
        {
            Juego juego = new Juego();
            Jugador jugador1 = new Jugador("Jugador1");
            juego.AnnadirJugador(jugador1);
            Jugador jugador2 = new Jugador("Jugador1");
            juego.AnnadirJugador(jugador2);
            bool resultado = juego.ObtenerJugador(1) == jugador1;
            Assert.Fail("No se ha lanzado la excepción NombreJugadorDuplicadoException");
        }

        [TestMethod]
        public void ObtenerJugador_IdJugadorEs_ElMismo()
        {
            Juego juego = new Juego();
            Jugador jugador = new Jugador();
            juego.AnnadirJugador(jugador);

            Assert.AreEqual(juego.ObtenerJugador(1).Id, 1);
        }

        [TestMethod]
        public void ObtenerGanador_HayGanadorFila_EsTrue()
        {
            Juego juego = new Juego();
            Jugador jugador = new Jugador();
            jugador.Ficha = new Ficha(ColorEnum.Rojo);
            juego.AnnadirJugador(jugador);

            juego.Tablero.PonerFichaColumna(jugador.Ficha, 0);
            juego.Tablero.PonerFichaColumna(jugador.Ficha, 1);
            juego.Tablero.PonerFichaColumna(jugador.Ficha, 2);
            juego.Tablero.PonerFichaColumna(jugador.Ficha, 3);
            Assert.IsTrue(juego.EsGanador(jugador));
        }

        [TestMethod]
        public void ObtenerGanador_NoHayGanadorFilaFaltaFicha_EsFalso()
        {
            Juego juego = new Juego();
            Jugador jugador = new Jugador();
            jugador.Ficha = new Ficha(ColorEnum.Rojo);
            juego.AnnadirJugador(jugador);

            juego.Tablero.PonerFichaColumna(jugador.Ficha, 0);
            juego.Tablero.PonerFichaColumna(jugador.Ficha, 1);
            juego.Tablero.PonerFichaColumna(jugador.Ficha, 2);
            Assert.IsFalse(juego.EsGanador(jugador));
        }

        [TestMethod]
        public void ObtenerGanador_NoHayGanadorFilaOtroJugador_EsFalso()
        {
            Juego juego = new Juego();
            Jugador jugador1 = new Jugador();
            jugador1.Ficha = new Ficha(ColorEnum.Rojo);
            juego.AnnadirJugador(jugador1);
            Jugador jugador2 = new Jugador();
            jugador2.Ficha = new Ficha(ColorEnum.Azul);
            juego.AnnadirJugador(jugador2);

            juego.Tablero.PonerFichaColumna(jugador1.Ficha, 0);
            juego.Tablero.PonerFichaColumna(jugador1.Ficha, 1);
            juego.Tablero.PonerFichaColumna(jugador1.Ficha, 2);
            juego.Tablero.PonerFichaColumna(jugador2.Ficha, 3);
            Assert.IsFalse(juego.EsGanador(jugador1));
        }

        [TestMethod]
        public void ObtenerGanador_HayGanadorColumna_EsTrue()
        {
            Juego juego = new Juego();
            Jugador jugador = new Jugador();
            jugador.Ficha = new Ficha(ColorEnum.Rojo);
            juego.AnnadirJugador(jugador);

            juego.Tablero.PonerFichaColumna(jugador.Ficha, 0);
            juego.Tablero.PonerFichaColumna(jugador.Ficha, 0);
            juego.Tablero.PonerFichaColumna(jugador.Ficha, 0);
            juego.Tablero.PonerFichaColumna(jugador.Ficha, 0);
            Assert.IsTrue(juego.EsGanador(jugador));
        }

        [TestMethod]
        public void ObtenerGanador_NoHayGanadorColumnaFaltaFicha_EsFalso()
        {
            Juego juego = new Juego();
            Jugador jugador = new Jugador();
            jugador.Ficha = new Ficha(ColorEnum.Rojo);
            juego.AnnadirJugador(jugador);

            juego.Tablero.PonerFichaColumna(jugador.Ficha, 0);
            juego.Tablero.PonerFichaColumna(jugador.Ficha, 0);
            juego.Tablero.PonerFichaColumna(jugador.Ficha, 0);
            Assert.IsFalse(juego.EsGanador(jugador));
        }

        [TestMethod]
        public void ObtenerGanador_NoHayGanadorColumnaOtroJugador_EsFalso()
        {
            Juego juego = new Juego();
            Jugador jugador1 = new Jugador();
            jugador1.Ficha = new Ficha(ColorEnum.Rojo);
            juego.AnnadirJugador(jugador1);
            Jugador jugador2 = new Jugador();
            jugador2.Ficha = new Ficha(ColorEnum.Azul);
            juego.AnnadirJugador(jugador2);

            juego.Tablero.PonerFichaColumna(jugador1.Ficha, 0);
            juego.Tablero.PonerFichaColumna(jugador1.Ficha, 0);
            juego.Tablero.PonerFichaColumna(jugador1.Ficha, 0);
            juego.Tablero.PonerFichaColumna(jugador2.Ficha, 0);
            Assert.IsFalse(juego.EsGanador(jugador1));
        }

        [TestMethod]
        public void ObtenerGanador_HayGanadorDiagonal_EsTrue()
        {
            Juego juego = new Juego();
            Jugador jugador = new Jugador();
            jugador.Ficha = new Ficha(ColorEnum.Rojo);
            juego.AnnadirJugador(jugador);
            Ficha fichaAux = new Ficha(ColorEnum.Azul);

            juego.Tablero.PonerFichaColumna(jugador.Ficha, 0);
            juego.Tablero.PonerFichaColumna(fichaAux, 1);
            juego.Tablero.PonerFichaColumna(jugador.Ficha, 1);
            juego.Tablero.PonerFichaColumna(fichaAux, 2);
            juego.Tablero.PonerFichaColumna(fichaAux, 2);
            juego.Tablero.PonerFichaColumna(jugador.Ficha, 2);
            juego.Tablero.PonerFichaColumna(fichaAux, 3);
            juego.Tablero.PonerFichaColumna(fichaAux, 3);
            juego.Tablero.PonerFichaColumna(fichaAux, 3);
            juego.Tablero.PonerFichaColumna(jugador.Ficha, 3);
            Assert.IsTrue(juego.EsGanador(jugador));
        }

        [TestMethod]
        public void ObtenerGanador_NoHayGanadorDiagonalFaltaFicha_EsFalso()
        {
            Juego juego = new Juego();
            Jugador jugador = new Jugador();
            jugador.Ficha = new Ficha(ColorEnum.Rojo);
            juego.AnnadirJugador(jugador);
            Ficha fichaAux = new Ficha(ColorEnum.Azul);

            juego.Tablero.PonerFichaColumna(jugador.Ficha, 0);
            juego.Tablero.PonerFichaColumna(fichaAux, 1);
            juego.Tablero.PonerFichaColumna(jugador.Ficha, 1);
            juego.Tablero.PonerFichaColumna(fichaAux, 2);
            juego.Tablero.PonerFichaColumna(fichaAux, 2);
            juego.Tablero.PonerFichaColumna(jugador.Ficha, 2);
            juego.Tablero.PonerFichaColumna(fichaAux, 3);
            juego.Tablero.PonerFichaColumna(fichaAux, 3);
            juego.Tablero.PonerFichaColumna(fichaAux, 3);
            Assert.IsFalse(juego.EsGanador(jugador));
        }

        [TestMethod]
        public void ObtenerGanador_NoHayGanadorDiagonalOtroJugador_EsFalso()
        {
            Juego juego = new Juego();
            Jugador jugador1 = new Jugador();
            jugador1.Ficha = new Ficha(ColorEnum.Rojo);
            juego.AnnadirJugador(jugador1);
            Jugador jugador2 = new Jugador();
            jugador2.Ficha = new Ficha(ColorEnum.Azul);
            juego.AnnadirJugador(jugador2);
            Ficha fichaAux = new Ficha(ColorEnum.Azul);

            juego.Tablero.PonerFichaColumna(jugador1.Ficha, 0);
            juego.Tablero.PonerFichaColumna(fichaAux, 1);
            juego.Tablero.PonerFichaColumna(jugador1.Ficha, 1);
            juego.Tablero.PonerFichaColumna(fichaAux, 2);
            juego.Tablero.PonerFichaColumna(fichaAux, 2);
            juego.Tablero.PonerFichaColumna(jugador1.Ficha, 2);
            juego.Tablero.PonerFichaColumna(fichaAux, 3);
            juego.Tablero.PonerFichaColumna(fichaAux, 3);
            juego.Tablero.PonerFichaColumna(fichaAux, 3);
            juego.Tablero.PonerFichaColumna(jugador2.Ficha, 3);
            Assert.IsFalse(juego.EsGanador(jugador1));
        }

        [TestMethod]
        public void ObtenerGanador_HayGanadorDiagonalInversa_EsTrue()
        {
            Juego juego = new Juego();
            Jugador jugador = new Jugador();
            jugador.Ficha = new Ficha(ColorEnum.Rojo);
            juego.AnnadirJugador(jugador);
            Ficha fichaAux = new Ficha(ColorEnum.Azul);

            juego.Tablero.PonerFichaColumna(jugador.Ficha, 3);
            juego.Tablero.PonerFichaColumna(fichaAux, 2);
            juego.Tablero.PonerFichaColumna(jugador.Ficha, 2);
            juego.Tablero.PonerFichaColumna(fichaAux, 1);
            juego.Tablero.PonerFichaColumna(fichaAux, 1);
            juego.Tablero.PonerFichaColumna(jugador.Ficha, 1);
            juego.Tablero.PonerFichaColumna(fichaAux, 0);
            juego.Tablero.PonerFichaColumna(fichaAux, 0);
            juego.Tablero.PonerFichaColumna(fichaAux, 0);
            juego.Tablero.PonerFichaColumna(jugador.Ficha, 0);
            Assert.IsTrue(juego.EsGanador(jugador));
        }

        [TestMethod]
        public void ObtenerGanador_NoHayGanadorDiagonalInversaFaltaFicha_EsFalso()
        {
            Juego juego = new Juego();
            Jugador jugador = new Jugador();
            jugador.Ficha = new Ficha(ColorEnum.Rojo);
            juego.AnnadirJugador(jugador);
            Ficha fichaAux = new Ficha(ColorEnum.Azul);

            juego.Tablero.PonerFichaColumna(jugador.Ficha, 3);
            juego.Tablero.PonerFichaColumna(fichaAux, 2);
            juego.Tablero.PonerFichaColumna(jugador.Ficha, 2);
            juego.Tablero.PonerFichaColumna(fichaAux, 1);
            juego.Tablero.PonerFichaColumna(fichaAux, 1);
            juego.Tablero.PonerFichaColumna(jugador.Ficha, 1);
            juego.Tablero.PonerFichaColumna(fichaAux, 0);
            juego.Tablero.PonerFichaColumna(fichaAux, 0);
            juego.Tablero.PonerFichaColumna(fichaAux, 0);
            Assert.IsFalse(juego.EsGanador(jugador));
        }

        [TestMethod]
        public void ObtenerGanador_NoHayGanadorDiagonalInversaOtroJugador_EsFalso()
        {
            Juego juego = new Juego();
            Jugador jugador1 = new Jugador();
            jugador1.Ficha = new Ficha(ColorEnum.Rojo);
            juego.AnnadirJugador(jugador1);
            Jugador jugador2 = new Jugador();
            jugador2.Ficha = new Ficha(ColorEnum.Azul);
            juego.AnnadirJugador(jugador2);
            Ficha fichaAux = new Ficha(ColorEnum.Azul);

            juego.Tablero.PonerFichaColumna(jugador1.Ficha, 3);
            juego.Tablero.PonerFichaColumna(fichaAux, 2);
            juego.Tablero.PonerFichaColumna(jugador1.Ficha, 2);
            juego.Tablero.PonerFichaColumna(fichaAux, 1);
            juego.Tablero.PonerFichaColumna(fichaAux, 1);
            juego.Tablero.PonerFichaColumna(jugador1.Ficha, 1);
            juego.Tablero.PonerFichaColumna(fichaAux, 0);
            juego.Tablero.PonerFichaColumna(fichaAux, 0);
            juego.Tablero.PonerFichaColumna(fichaAux, 0);
            juego.Tablero.PonerFichaColumna(jugador2.Ficha, 0);
            Assert.IsFalse(juego.EsGanador(jugador1));
        }

        [TestMethod]
        public void FinJuego_TableroLleno_EsTrue()
        {
            Juego juego = new Juego(2);
            Jugador jugador = new Jugador();
            jugador.Ficha = new Ficha(ColorEnum.Rojo);
            juego.AnnadirJugador(jugador);
            juego.Tablero.PonerFichaColumna(jugador.Ficha, 0);
            juego.Tablero.PonerFichaColumna(jugador.Ficha, 0);
            juego.Tablero.PonerFichaColumna(jugador.Ficha, 1);
            juego.Tablero.PonerFichaColumna(jugador.Ficha, 1);
            Assert.IsTrue(juego.Tablero.EsLLeno);
        }

        [TestMethod]
        public void FinJuego_TableroNoLleno_EsFalse()
        {
            Juego juego = new Juego(2);
            Jugador jugador = new Jugador();
            jugador.Ficha = new Ficha(ColorEnum.Rojo);
            juego.AnnadirJugador(jugador);
            juego.Tablero.PonerFichaColumna(jugador.Ficha, 0);
            juego.Tablero.PonerFichaColumna(jugador.Ficha, 0);
            juego.Tablero.PonerFichaColumna(jugador.Ficha, 1);
            Assert.IsFalse(juego.Tablero.EsLLeno);
        }
    }
}