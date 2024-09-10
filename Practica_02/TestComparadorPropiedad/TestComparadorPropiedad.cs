using Microsoft.VisualStudio.TestTools.UnitTesting;
using PSS.pgr866.Practica_02;
using System.Runtime.Intrinsics.X86;

namespace PSS.pgr866.Practica_02
{
    [TestClass]
    public class TestComparadorPropiedad
    {
        [TestMethod]
        public void ComparadorPropiedadNombre()
        {
            UsuarioView user1 = new UsuarioView(3, "Antonio", "palabra1", "Cat1", true);
            UsuarioView user2 = new UsuarioView(12, "Antonio", "palabra2", "Cat2", true);
            UsuarioView user3 = new UsuarioView(12, "Pablo", "palabra2", "Cat1", false);
            UsuarioView user4 = user1;
            UsuarioView user5 = null;
            ComparadorPropiedad<UsuarioView> cmp = new ComparadorPropiedad<UsuarioView>("Nombre");

            Assert.IsTrue(cmp.Compare(user1, user2) == 0);
            Assert.IsTrue(cmp.Compare(user1, user3) < 0);
            Assert.IsTrue(cmp.Compare(user3, user2) > 0);
            Assert.IsTrue(cmp.Compare(user1, user4) == 0);
            Assert.IsTrue(cmp.Compare(user5, user3) < 0);
            Assert.IsTrue(cmp.Compare(user5, null) == 0);
        }

        [TestMethod]
        public void ComparadorPropiedadPalabraPaso()
        {
            UsuarioView user1 = new UsuarioView(3, "Antonio", "palabra1", "Cat1", true);
            UsuarioView user2 = new UsuarioView(12, "Antonio", "palabra2", "Cat2", true);
            UsuarioView user3 = new UsuarioView(12, "Pablo", "palabra2", "Cat1", false);
            UsuarioView user4 = user1;
            UsuarioView user5 = null;
            ComparadorPropiedad<UsuarioView> cmp = new ComparadorPropiedad<UsuarioView>("PalabraPaso");

            Assert.IsTrue(cmp.Compare(user2, user3) == 0);
            Assert.IsTrue(cmp.Compare(user1, user2) < 0);
            Assert.IsTrue(cmp.Compare(user3, user1) > 0);
            Assert.IsTrue(cmp.Compare(user1, user4) == 0);
            Assert.IsTrue(cmp.Compare(user5, user1) < 0);
            Assert.IsTrue(cmp.Compare(user5, null) == 0);
        }

        [TestMethod]
        public void ComparadorPropiedadCategoria()
        {
            UsuarioView user1 = new UsuarioView(3, "Antonio", "palabra1", "Cat1", true);
            UsuarioView user2 = new UsuarioView(12, "Antonio", "palabra2", "Cat2", true);
            UsuarioView user3 = new UsuarioView(12, "Pablo", "palabra2", "Cat1", false);
            UsuarioView user4 = user1;
            UsuarioView user5 = null;
            ComparadorPropiedad<UsuarioView> cmp = new ComparadorPropiedad<UsuarioView>("Categoria");

            Assert.IsTrue(cmp.Compare(user1, user3) == 0);
            Assert.IsTrue(cmp.Compare(user1, user2) < 0);
            Assert.IsTrue(cmp.Compare(user2, user3) > 0);
            Assert.IsTrue(cmp.Compare(user1, user4) == 0);
            Assert.IsTrue(cmp.Compare(user5, user1) < 0);
            Assert.IsTrue(cmp.Compare(user5, null) == 0);
        }

        [TestMethod]
        public void ComparadorPropiedadEsValido()
        {
            UsuarioView user1 = new UsuarioView(3, "Antonio", "palabra1", "Cat1", true);
            UsuarioView user2 = new UsuarioView(12, "Antonio", "palabra2", "Cat2", true);
            UsuarioView user3 = new UsuarioView(12, "Pablo", "palabra2", "Cat1", false);
            UsuarioView user4 = user1;
            UsuarioView user5 = null;
            ComparadorPropiedad<UsuarioView> cmp = new ComparadorPropiedad<UsuarioView>("EsValido");

            Assert.IsTrue(cmp.Compare(user1, user2) == 0);
            Assert.IsTrue(cmp.Compare(user3, user1) < 0);
            Assert.IsTrue(cmp.Compare(user2, user3) > 0);
            Assert.IsTrue(cmp.Compare(user1, user4) == 0);
            Assert.IsTrue(cmp.Compare(user5, user3) < 0);
            Assert.IsTrue(cmp.Compare(user5, null) == 0);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void ComparadorPropiedadNoExistente()
        {
            ComparadorPropiedad<UsuarioView> cmp = new ComparadorPropiedad<UsuarioView>("atributo");

            Assert.Fail("No se ha lanzado la excepcion");
        }

        [TestMethod]
        public void ComparadorPropiedadLista()
        {
            UsuarioView user1 = new UsuarioView(3, "Antonio", "palabra1", "Cat1", true);
            UsuarioView user2 = new UsuarioView(12, "Antonio", "palabra2", "Cat2", true);
            UsuarioView user3 = new UsuarioView(12, "Pablo", "palabra2", "Cat1", false);
            UsuarioView user4 = user1;
            UsuarioView user5 = null;

            List<UsuarioView> usuarios = new List<UsuarioView>() { user1, user2, user3, user4, user5 };
            List<string> atributos = new List<string>() { "Id", "Nombre", "PalabraPaso", "Categoria", "EsValido" };
            ComparadorPropiedad<UsuarioView> cmp;

            foreach (string at in atributos)
            {
                cmp = new ComparadorPropiedad<UsuarioView>(at);
                usuarios.Sort(cmp);
                UsuarioView temp = null;
                foreach (UsuarioView user in usuarios)
                {
                    Assert.IsTrue(cmp.Compare(temp, user) <= 0);
                    temp = user;
                }
            }
        }
    }
}