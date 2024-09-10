using Microsoft.VisualStudio.TestTools.UnitTesting;
using PSS.pgr866.Practica_02;
using System.Collections.Generic;

namespace PSS.pgr866.Practica_02
{
    [TestClass]
    public class TestRecorridoSecuencia
    {
        UsuarioView user1 = new UsuarioView(1, "Pablo", "palabra1", "cat1", true);
        UsuarioView user2 = new UsuarioView(2, "Antonio", "palabra2", "cat2", false);
        UsuarioView user3 = new UsuarioView(3, "Carmen", "palabra3", "cat3", true);
        UsuarioView user4 = new UsuarioView(4, "Miguel", "palabra4", "cat4", false);
        UsuarioView user5 = null;

        [TestMethod]
        public void RecorridoAdelante()
        {
            Secuencia<UsuarioView> secuenciaOriginal = new Secuencia<UsuarioView>() { user2, user3, user1 };
            Secuencia<UsuarioView> esperada = new Secuencia<UsuarioView>() { user2, user3, user1 };
            Secuencia<UsuarioView> resultado = new Secuencia<UsuarioView>();

            foreach (UsuarioView user in secuenciaOriginal.RecorridoAdelante())
            {
                resultado.Añadir(user);
            }
            CollectionAssert.AreEqual(esperada, resultado);
        }

        [TestMethod]
        public void RecorridoAtras()
        {
            Secuencia<UsuarioView> secuenciaOriginal = new Secuencia<UsuarioView>() { user1, user3, user2, user4 };
            Secuencia<UsuarioView> esperada = new Secuencia<UsuarioView>() { user4, user2, user3, user1 };
            Secuencia<UsuarioView> resultado = new Secuencia<UsuarioView>();

            foreach (UsuarioView user in secuenciaOriginal.RecorridoAtras())
            {
                resultado.Añadir(user);
            }
            CollectionAssert.AreEqual(esperada, resultado);
        }

        [TestMethod]
        public void RecorridoAscendente()
        {
            Secuencia<UsuarioView> secuenciaOriginal = new Secuencia<UsuarioView>() { user4, user2, user3, user1 };
            Secuencia<UsuarioView> esperada = new Secuencia<UsuarioView>() { user1, user2, user3, user4 };
            Secuencia<UsuarioView> resultado = new Secuencia<UsuarioView>();
            ComparadorPropiedad<UsuarioView> cmp = new ComparadorPropiedad<UsuarioView>("Id");

            foreach (UsuarioView user in secuenciaOriginal.RecorridoAscendente(cmp))
            {
                resultado.Añadir(user);
            }
            CollectionAssert.AreEqual(esperada, resultado);
        }

        [TestMethod]
        public void RecorridoDescendente()
        {
            Secuencia<UsuarioView> secuenciaOriginal = new Secuencia<UsuarioView>() { user3, user1, user4, user2 };
            Secuencia<UsuarioView> esperada = new Secuencia<UsuarioView>() { user4, user3, user2, user1 };
            Secuencia<UsuarioView> resultado = new Secuencia<UsuarioView>();
            ComparadorPropiedad<UsuarioView> cmp = new ComparadorPropiedad<UsuarioView>("Id");

            foreach (UsuarioView user in secuenciaOriginal.RecorridoDescendente(cmp))
            {
                resultado.Añadir(user);
            }

            CollectionAssert.AreEqual(esperada, resultado);
        }

        [TestMethod]
        public void RecorridoAdelante_Null()
        {
            Secuencia<UsuarioView> secuenciaOriginal = new Secuencia<UsuarioView>() { user5, user2, user1, user4, user3 };
            Secuencia<UsuarioView> esperada = new Secuencia<UsuarioView>() { user5, user2, user1, user4, user3 };
            Secuencia<UsuarioView> resultado = new Secuencia<UsuarioView>();

            foreach (UsuarioView user in secuenciaOriginal.RecorridoAdelante())
            {
                resultado.Añadir(user);
            }
            CollectionAssert.AreEqual(esperada, resultado);
        }

        [TestMethod]
        public void RecorridoAtras_Null()
        {
            Secuencia<UsuarioView> secuenciaOriginal = new Secuencia<UsuarioView>() { user5, user2, user1, user4, user3 };
            Secuencia<UsuarioView> esperada = new Secuencia<UsuarioView>() { user3, user4, user1, user2, user5 };
            Secuencia<UsuarioView> resultado = new Secuencia<UsuarioView>();

            foreach (UsuarioView user in secuenciaOriginal.RecorridoAtras())
            {
                resultado.Añadir(user);
            }
            CollectionAssert.AreEqual(esperada, resultado);
        }

        [TestMethod]
        public void RecorridoAscendente_Null()
        {
            Secuencia<UsuarioView> secuenciaOriginal = new Secuencia<UsuarioView>() { user5, user2, user1, user4, user3 };
            Secuencia<UsuarioView> esperada = new Secuencia<UsuarioView>() { user5, user1, user2, user3, user4 };
            Secuencia<UsuarioView> resultado = new Secuencia<UsuarioView>();
            ComparadorPropiedad<UsuarioView> cmp = new ComparadorPropiedad<UsuarioView>("Categoria");

            foreach (UsuarioView user in secuenciaOriginal.RecorridoAscendente(cmp))
            {
                resultado.Añadir(user);
            }
            CollectionAssert.AreEqual(esperada, resultado);
        }

        [TestMethod]
        public void RecorridoDescendente_Null()
        {
            Secuencia<UsuarioView> secuenciaOriginal = new Secuencia<UsuarioView>() { user5, user2, user1, user4, user3 };
            Secuencia<UsuarioView> esperada = new Secuencia<UsuarioView>() { user4, user3, user2, user1, user5 };
            Secuencia<UsuarioView> resultado = new Secuencia<UsuarioView>();
            ComparadorPropiedad<UsuarioView> cmp = new ComparadorPropiedad<UsuarioView>("Id");

            foreach (UsuarioView user in secuenciaOriginal.RecorridoDescendente(cmp))
            {
                resultado.Añadir(user);
            }
            CollectionAssert.AreEqual(esperada, resultado);
        }

    }
}