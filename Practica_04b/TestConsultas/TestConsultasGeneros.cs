using Microsoft.VisualStudio.TestTools.UnitTesting;
using PSS.pgr866.Practica_04b;

namespace PSS.pgr866.Practica_04bd
{
    [TestClass]
    public class TestConsultasGeneros
    {

        [TestMethod]
        public void Lista_Par_GeneroVisor_Para_Plat()
        {
            IEnumerable<vmGeneroNombre> esperado = new List<vmGeneroNombre>
            {
                new vmGeneroNombre { Nombre = "DIANA", Genero = "TERROR" },
                new vmGeneroNombre { Nombre = "ANTONIO", Genero = "TERROR" },
                new vmGeneroNombre { Nombre = "ANA", Genero = "TERROR" },
                new vmGeneroNombre { Nombre = "DIANA", Genero = "COMEDIA" },
                new vmGeneroNombre { Nombre = "ANTONIO", Genero = "COMEDIA" },
                new vmGeneroNombre { Nombre = "ANA", Genero = "COMEDIA" }
            };

            ConsultasGeneros consulta = new ConsultasGeneros();
            IEnumerable<vmGeneroNombre> resultado = consulta.ListaParGeneroVisorParaPlat("Netflix");

            Assert.IsTrue(esperado.SequenceEqual(resultado));
        }

        [TestMethod]
        public void Agrupacion_Visores_Generos()
        {

            IEnumerable<IGrouping<string, vmGeneroNombre>> esperado = new List<vmGeneroNombre>
            {
                new vmGeneroNombre { Genero = "TERROR", Nombre = "DIANA" },
                new vmGeneroNombre { Genero = "TERROR", Nombre = "JUAN" },
                new vmGeneroNombre { Genero = "TERROR", Nombre = "ANTONIO" },
                new vmGeneroNombre { Genero = "TERROR", Nombre = "ANA" },
                new vmGeneroNombre { Genero = "TERROR", Nombre = "JULIO" },
                new vmGeneroNombre { Genero = "TERROR", Nombre = "MERCEDES" },
                new vmGeneroNombre { Genero = "COMEDIA", Nombre = "JOSE" },
                new vmGeneroNombre { Genero = "ACCION", Nombre = "JOSE" },
                new vmGeneroNombre { Genero = "DRAMA", Nombre = "ANONIMO" }
            }
            .GroupBy(item => item.Genero);

            ConsultasGeneros consulta = new ConsultasGeneros();
            IEnumerable<IGrouping<string, vmGeneroNombre>> resultado = consulta.AgrupacionVisoresGeneros();

            Assert.AreEqual(esperado.Count(), resultado.Count());
            foreach (var grupoEsperado in esperado)
            {
                var grupoEncontrado = resultado.FirstOrDefault(grupo => grupo.Key == grupoEsperado.Key);
                Assert.IsNotNull(grupoEncontrado, $"No se encontró el grupo con clave: {grupoEsperado.Key}");

                Assert.IsTrue(grupoEsperado.SequenceEqual(grupoEncontrado), $"Los elementos en el grupo {grupoEsperado.Key} no coinciden");
            }

        }

        [TestMethod]
        public void Agrupacion_Visores_Generos_Ordenados()
        {
            IEnumerable<vmGeneroNombre> esperado = new List<vmGeneroNombre>
            {
                new vmGeneroNombre { Genero = "TERROR", Nombre = "MERCEDES" },
                new vmGeneroNombre { Genero = "TERROR", Nombre = "JULIO" },
                new vmGeneroNombre { Genero = "TERROR", Nombre = "JUAN" },
                new vmGeneroNombre { Genero = "COMEDIA", Nombre = "JOSE" },
                new vmGeneroNombre { Genero = "ACCION", Nombre = "JOSE" },
                new vmGeneroNombre { Genero = "TERROR", Nombre = "DIANA" },
                new vmGeneroNombre { Genero = "TERROR", Nombre = "ANTONIO" },
                new vmGeneroNombre { Genero = "DRAMA", Nombre = "ANONIMO" },
                new vmGeneroNombre { Genero = "TERROR", Nombre = "ANA" }
            };

            ConsultasGeneros consulta = new ConsultasGeneros();
            IEnumerable<vmGeneroNombre> resultado = consulta.AgrupacionVisoresGenerosOrdenados();

            Assert.IsTrue(esperado.SequenceEqual(resultado));
        }

        [TestMethod]
        public void Genero_Maximo_Numero_Visores()
        {
            IEnumerable<vmGeneroNombre> esperado = new List<vmGeneroNombre>
            {
                new vmGeneroNombre { Genero = "Terror", Nombre = "6" }
            };

            ConsultasGeneros consulta = new ConsultasGeneros();
            IEnumerable<vmGeneroNombre> resultado = consulta.GeneroMaximoNumeroVisores();

            Assert.IsTrue(esperado.SequenceEqual(resultado));
        }

        [TestMethod]
        public void Todos_Generos_Plat()
        {
            IEnumerable<vmGeneroNombre> esperado = new List<vmGeneroNombre>
            {
                new vmGeneroNombre { Genero = "Comedia", Nombre = "Hbo" }
            };

            ConsultasGeneros consulta = new ConsultasGeneros();
            IEnumerable<vmGeneroNombre> resultado = consulta.TodosGenerosPlat("Hbo");

            Assert.IsTrue(esperado.SequenceEqual(resultado));
        }

        [TestMethod]
        public void Generos_Plataforma_Para_Visor()
        {
            IEnumerable<vmGeneroNombre> esperado = new List<vmGeneroNombre>
            {
                new vmGeneroNombre { Genero = "Terror", Nombre = "Netflix" },
                new vmGeneroNombre { Genero = "Comedia", Nombre = "Netflix" }
            };

            ConsultasGeneros consulta = new ConsultasGeneros();
            IEnumerable<vmGeneroNombre> resultado = consulta.GenerosPlataformaParaVisor("Diana");

            Assert.IsTrue(esperado.SequenceEqual(resultado));
        }

    }
}
