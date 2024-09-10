using Microsoft.VisualStudio.TestTools.UnitTesting;
using PSS.pgr866.Practica_04b;

namespace PSS.pgr866.Practica_04bd
{
    [TestClass]
    public class TestConsultasVisores
    {

        [TestMethod]
        public void Visores_En_Genero_IdGen()
        {
            IEnumerable<vmNombre> esperado = new List<vmNombre>
            {
                new vmNombre { Nombre = "ANA" },
                new vmNombre { Nombre = "ANTONIO" },
                new vmNombre { Nombre = "DIANA" },
                new vmNombre { Nombre = "JUAN" }
            };

            ConsultasVisores consulta = new ConsultasVisores();
            IEnumerable<vmNombre> resultado = consulta.VisoresEnGenero(1);

            Assert.IsTrue(esperado.SequenceEqual(resultado));
        }

        [TestMethod]
        public void Visores_En_Genero_NombreGen()
        {
            IEnumerable<vmNombre> esperado = new List<vmNombre>
            {
                new vmNombre { Nombre = "ANA" },
                new vmNombre { Nombre = "ANTONIO" },
                new vmNombre { Nombre = "DIANA" },
                new vmNombre { Nombre = "JUAN" },
                new vmNombre { Nombre = "JULIO" },
                new vmNombre { Nombre = "MERCEDES" }
            };

            ConsultasVisores consulta = new ConsultasVisores();
            IEnumerable<vmNombre> resultado = consulta.VisoresEnGenero("Terror");

            Assert.IsTrue(esperado.SequenceEqual(resultado));
        }

        [TestMethod]
        public void Visores_Con_Nombre_Comienza()
        {
            IEnumerable<vmNombre> esperado = new List<vmNombre>
            {
                new vmNombre { Nombre = "JOSE" },
                new vmNombre { Nombre = "JOSE" },
                new vmNombre { Nombre = "JUAN" },
                new vmNombre { Nombre = "JULIO" }
            };

            ConsultasVisores consulta = new ConsultasVisores();
            IEnumerable<vmNombre> resultado = consulta.VisoresConNombreComienza("J");

            Assert.IsTrue(esperado.SequenceEqual(resultado));
        }

        [TestMethod]
        public void Visores_Con_Nombre_Comienza_En_Genero()
        {
            IEnumerable<vmNombre> esperado = new List<vmNombre>
            {
                new vmNombre { Nombre = "ANTONIO" },
                new vmNombre { Nombre = "ANA" },
            };

            ConsultasVisores consulta = new ConsultasVisores();
            IEnumerable<vmNombre> resultado = consulta.VisoresConNombreComienzaEnGenero("A", "Terror");

            Assert.IsTrue(esperado.SequenceEqual(resultado));
        }

        [TestMethod]
        public void Visores_Conectados_IP()
        {
            IEnumerable<vmNombre> esperado = new List<vmNombre>
            {
                new vmNombre { Nombre = "ANTONIO" },
                new vmNombre { Nombre = "ANTONIO" },
                new vmNombre { Nombre = "ANTONIO" }
            };

            ConsultasVisores consulta = new ConsultasVisores();
            IEnumerable<vmNombre> resultado = consulta.VisoresConectadosIP("192.168.134.18");

            Assert.IsTrue(esperado.SequenceEqual(resultado));
        }

        [TestMethod]
        public void Encontrar_Visor_Plat_Email()
        {
            IEnumerable<vmNombre> esperado = new List<vmNombre>
            {
                new vmNombre { Nombre = "JUAN" }
            };

            ConsultasVisores consulta = new ConsultasVisores();
            IEnumerable<vmNombre> resultado = consulta.EncontrarVisorPlatEmail("Hbo", "Juan.pss-2@ual.es");

            Assert.IsTrue(esperado.SequenceEqual(resultado));
        }

    }
}
