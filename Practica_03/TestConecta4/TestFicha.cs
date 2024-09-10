using Microsoft.VisualStudio.TestTools.UnitTesting;
using PSS.pgr866.Practica_03;
using System.Drawing;

namespace PSS.pgr866.Practica_03
{
    [TestClass]
    public class TestFicha
    {
        [TestMethod]
        public void Constructor_SinParametros_EsNoNulo()
        {
            Ficha ficha = new Ficha();
            Assert.IsNotNull(ficha);

        }

        [TestMethod]
        public void Constructor_SinParametros_ColorEsSinColor()
        {
            Ficha ficha = new Ficha();
            Assert.AreEqual(ficha.Color, ColorEnum.SinColor);
        }

        [TestMethod]
        public void Constructor_ParametroColor_ColorEsIgual()
        {
            Ficha ficha = new Ficha(ColorEnum.Rojo);
            Assert.AreEqual(ficha.Color, ColorEnum.Rojo);

        }
    }
}