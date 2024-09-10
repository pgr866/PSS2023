using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PSS.pgr866.Practica_02;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace PSS.pgr866.Practica_02
{
    [TestClass]
    public class TestColeccionUsuarioView
    {

        UsuarioView user1 = new UsuarioView(1, "Anotnio", "palabra1", "Investigador", false);
        UsuarioView user2 = new UsuarioView(2, "Oscar", "palabra2", "Docente", true);
        UsuarioView user3 = new UsuarioView(3, "Felipe", "palabra3", "Docente", false);
        UsuarioView user4 = new UsuarioView(4, "Pepe", "palabra1", "Ingeniero", true);
        UsuarioView user5 = new UsuarioView(2, "Pablo", "palabra1", "Investigador", false);

        [TestMethod]
        public void TestContains()
        {
            List<UsuarioView> lista = new List<UsuarioView>();
            lista.Add(user1);
            lista.Add(user2);
            lista.Add(user3);

            // Comprobamos que contiene los usuarios que añadimos
            Assert.IsTrue(lista.Contains(user1));
            Assert.IsTrue(lista.Contains(user2));
            Assert.IsTrue(lista.Contains(user3));
            // Comprobamos que user4 no esta contenido
            Assert.IsFalse(lista.Contains(user4));
            // Comprobamos que null no esta contenido
            Assert.IsFalse(lista.Contains(null));
            // Si comprobamos cualquier user con mismo Id que alguno de la lista, devuelve true
            Assert.IsTrue(lista.Contains(new UsuarioView(1, "", "", "", true)));
        }

        [TestMethod]
        public void TestIndexOf()
        {
            List<UsuarioView> lista = new List<UsuarioView>();
            lista.Add(user1);
            lista.Add(user2);
            lista.Add(user3);

            // Comprobamos el indice de los usuarios que añadimos
            Assert.AreEqual(lista.IndexOf(user1), 0);
            Assert.AreEqual(lista.IndexOf(user2), 1);
            Assert.AreEqual(lista.IndexOf(user3), 2);
            // Comprobamos que user4 no esta contenido
            Assert.AreEqual(lista.IndexOf(user4), -1);
            // Comprobamos que null no esta contenido
            Assert.AreEqual(lista.IndexOf(null), -1);
        }

        [TestMethod]
        public void TestLastIndexOf()
        {
            List<UsuarioView> lista = new List<UsuarioView>();
            lista.Add(user1);
            lista.Add(user2);
            lista.Add(user3);
            lista.Add(user2);
            lista.Add(user1);
            lista.Add(user5);

            // Comprobamos el ultimo indice de los usuarios que añadimos
            Assert.AreEqual(lista.LastIndexOf(user1), 4);
            // Toma a user5 como user2 porque tienen mismo Id
            Assert.AreEqual(lista.LastIndexOf(user2), 5);
            Assert.AreEqual(lista.LastIndexOf(user3), 2);
            // Comprobamos que user4 no esta contenido
            Assert.AreEqual(lista.LastIndexOf(user4), -1);
            // Comprobamos que null no esta contenido
            Assert.AreEqual(lista.LastIndexOf(null), -1);
        }

        [TestMethod]
        public void TestRemove()
        {
            List<UsuarioView> lista = new List<UsuarioView>();
            lista.Add(user1);
            lista.Add(user2);
            lista.Add(user3);
            lista.Add(user1);
            lista.Add(user5);

            Assert.AreEqual(lista.Count, 5);

            // Es necesario eliminar los elementos duplicados uno a uno
            lista.Remove(user1);
            lista.Remove(user1);
            Assert.AreEqual(lista.Count, 3);

            lista.Remove(user2);
            // Toma user5 como user2 porque tienen mismo Id
            lista.Remove(user2);
            Assert.AreEqual(lista.Count, 1);

            lista.Remove(user3);
            Assert.AreEqual(lista.Count, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestDictionary()
        {
            Dictionary<UsuarioView, string> diccionario = new Dictionary<UsuarioView, string>();

            diccionario.Add(user1, "a");
            Assert.AreEqual(diccionario.Count, 1);
            diccionario.Add(user2, "a");
            Assert.AreEqual(diccionario.Count, 2);
            diccionario.Add(user3, "b");
            Assert.AreEqual(diccionario.Count, 3);
            // Los ultimos dos Adds lanzan excepcion, ya que el diccionario no permite elementos duplicados, es decir, mismo Id
            diccionario.Add(user1, "a");
            Assert.AreEqual(diccionario.Count, 3);
            diccionario.Add(user5, "c");
            Assert.AreEqual(diccionario.Count, 3);
        }

        [TestMethod]
        public void TestSort()
        {
            List<UsuarioView> lista = new List<UsuarioView>();
            lista.Add(user4);
            lista.Add(user1);
            lista.Add(user3);
            lista.Add(user2);
            lista.Add(user5);
            lista.Sort();

            // Comprobamos que los elementos estan ordenador mediante el uso del metodo IndexOf
            Assert.AreEqual(lista.IndexOf(user1), 0);
            Assert.AreEqual(lista.IndexOf(user2), 1);
            Assert.AreEqual(lista.IndexOf(user5), 1);
            Assert.AreEqual(lista.IndexOf(user3), 3);
            Assert.AreEqual(lista.IndexOf(user4), 4);
        }

    }
}