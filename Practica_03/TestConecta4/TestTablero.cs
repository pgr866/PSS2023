using Microsoft.VisualStudio.TestTools.UnitTesting;
using PSS.pgr866.Practica_03;
using System.Drawing;

namespace PSS.pgr866.Practica_03
{
    [TestClass]
    public class TestTablero
    {
        [TestMethod]
        public void Constructor_SinParametros_EsNoNulo()
        {
            Tablero tablero = new Tablero();
            Assert.IsNotNull(tablero);
        }

        [TestMethod]
        public void Dimension_InstanciarTableroSinParametros_DimensionEsIgual3()
        {
            Tablero tablero = new Tablero();
            bool resultado = tablero.Dimension == 9;
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void Dimension_InstanciarTableroConParametros_DimensionEsIgual()
        {
            Tablero tablero = new Tablero(5); bool resultado = tablero.Dimension == 5;
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void Casilla_PongoFicha_FichaEsIgual()
        {
            Tablero tablero = new Tablero(5);
            var ficha = new Ficha(ColorEnum.Rojo);
            tablero.PonerFichaColumna(ficha, 1);
            bool resultado = tablero[4, 1].Color == ficha.Color;
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void Casilla_PongoFicha_FichaEsIqual()
        {
            Tablero tablero = new Tablero(5);
            var ficha = new Ficha(ColorEnum.Rojo);
            tablero.PonerFichaColumna(ficha, 1);
            bool resultado = tablero[4, 1].Color == ficha.Color;
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void PonerFichaPosicion_PongoFichaColumnaDisponible_EsTrue()
        {
            Tablero tablero = new Tablero(5);
            var ficha = new Ficha(ColorEnum.Rojo);
            bool resultado = tablero.PonerFichaColumna(ficha, 1);
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void PonerFichaPosicion_PongoFichaColumnaLlena_EsFalse()
        {
            Tablero tablero = new Tablero(2);
            var ficha = new Ficha(ColorEnum.Rojo);
            tablero.PonerFichaColumna(ficha, 0);
            tablero.PonerFichaColumna(ficha, 0);
            bool resultado = tablero.PonerFichaColumna(ficha, 0);
            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void PonerFichaPosicion_FueraDelTablero_EsFalse()
        {
            Tablero tablero = new Tablero(5);
            var ficha = new Ficha(ColorEnum.Rojo);
            bool resultado = tablero.PonerFichaColumna(ficha, 5);
            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void NumeroCasillasOcupadas_TableroNuevo_EsCero()
        {
            Tablero tablero = new Tablero();
            bool resultado = tablero.NumeroCasillasOcupadas == 0;
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void NumeroCasillas0cupadas_TableroConUnaFichaPuesta_EsUno()
        {
            Tablero tablero = new Tablero();
            var ficha = new Ficha(ColorEnum.Rojo);
            tablero.PonerFichaColumna(ficha, 1);
            bool resultado = tablero.NumeroCasillasOcupadas == 1;
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void EsFinJuego_TableroSinFichas_EsFalse()
        {
            Tablero tablero = new Tablero();
            Assert.IsFalse(tablero.EsLLeno);
        }

        [TestMethod]
        public void EsFinJuego_TablaroLlenoFichas_EsTrue()
        {
            Tablero tablero = new Tablero(2);
            var ficha = new Ficha(ColorEnum.Rojo);
            tablero.PonerFichaColumna(ficha, 0);
            tablero.PonerFichaColumna(ficha, 0);
            tablero.PonerFichaColumna(ficha, 1);
            tablero.PonerFichaColumna(ficha, 1);
            Assert.IsTrue(tablero.EsLLeno);
        }
    }
}