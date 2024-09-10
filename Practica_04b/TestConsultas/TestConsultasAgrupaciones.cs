using Microsoft.VisualStudio.TestTools.UnitTesting;
using PSS.pgr866.Practica_04b;

namespace PSS.pgr866.Practica_04bd
{
    [TestClass]
    public class TestConsultasAgrupaciones
    {

        [TestMethod]
        public void IP_con_Mas_Visualizaciones_Segun_Genero()
        {
            IEnumerable<vmNombreCantidad> esperado = new List<vmNombreCantidad>
            {
                new vmNombreCantidad { Nombre = "192.168.134.108", Cantidad = 6.0 }
            };

            ConsultasAgrupaciones consulta = new ConsultasAgrupaciones();
            IEnumerable<vmNombreCantidad> resultado = consulta.IPconMasVisualizacionesSegunGenero("Terror");

            Assert.IsTrue(esperado.SequenceEqual(resultado));
        }

        [TestMethod]
        public void Visor_Suma_Duracion_Visualizaciones()
        {
            IEnumerable<vmNombreCantidad> esperado = new List<vmNombreCantidad>
            {
                new vmNombreCantidad { Nombre = "Diana", Cantidad = 3255 },
                new vmNombreCantidad { Nombre = "Juan", Cantidad = 1792 },
                new vmNombreCantidad { Nombre = "Ana", Cantidad = 1369 },
                new vmNombreCantidad { Nombre = "Antonio", Cantidad = 277 },
                new vmNombreCantidad { Nombre = "Mercedes", Cantidad = 196 },
                new vmNombreCantidad { Nombre = "Anonimo", Cantidad = 38 },
                new vmNombreCantidad { Nombre = "Jose", Cantidad = 25 }
            };

            ConsultasAgrupaciones consulta = new ConsultasAgrupaciones();
            IEnumerable<vmNombreCantidad> resultado = consulta.VisorSumaDuracionVisualizaciones();

            Assert.IsTrue(esperado.SequenceEqual(resultado));
        }

        [TestMethod]
        public void Visor_Suma_Duracion_Visualizaciones_Nulos()
        {
            IEnumerable<vmNombreCantidad> esperado = new List<vmNombreCantidad>
            {
                new vmNombreCantidad { Nombre = "Diana", Cantidad = 3255 },
                new vmNombreCantidad { Nombre = "Juan", Cantidad = 1792 },
                new vmNombreCantidad { Nombre = "Ana", Cantidad = 1369 },
                new vmNombreCantidad { Nombre = "Antonio", Cantidad = 277 },
                new vmNombreCantidad { Nombre = "Mercedes", Cantidad = 196 },
                new vmNombreCantidad { Nombre = "Anonimo", Cantidad = 38 },
                new vmNombreCantidad { Nombre = "Jose", Cantidad = 25 },
                new vmNombreCantidad { Nombre = "Julio", Cantidad = 0 }
            };

            ConsultasAgrupaciones consulta = new ConsultasAgrupaciones();
            IEnumerable<vmNombreCantidad> resultado = consulta.VisorSumaDuracionVisualizacionesNulos();

            Assert.IsTrue(esperado.SequenceEqual(resultado));
        }

        [TestMethod]
        public void Visores_Suma_Duracion_Mayor_Media()
        {
            IEnumerable<vmNombreCantidad> esperado = new List<vmNombreCantidad>
            {
                new vmNombreCantidad { Nombre = "Ana", Cantidad = 1369 },
                new vmNombreCantidad { Nombre = "Juan", Cantidad = 1792 },
                new vmNombreCantidad { Nombre = "Diana", Cantidad = 3255 }
            };

            ConsultasAgrupaciones consulta = new ConsultasAgrupaciones();
            IEnumerable<vmNombreCantidad> resultado = consulta.VisoresSumaDuracionMayorMedia();

            Assert.IsTrue(esperado.SequenceEqual(resultado));
        }

        [TestMethod]
        public void Plataformas_Mas_Usadas()
        {
            IEnumerable<vmNombreCantidad> esperado = new List<vmNombreCantidad>
            {
                new vmNombreCantidad { Nombre = "AmazonPrime", Cantidad = 14 },
                new vmNombreCantidad { Nombre = "Hbo", Cantidad = 2037 },
                new vmNombreCantidad { Nombre = "Netflix", Cantidad = 4901 }
            };

            ConsultasAgrupaciones consulta = new ConsultasAgrupaciones();
            IEnumerable<vmNombreCantidad> resultado = consulta.PlataformasMasUsadas();

            Assert.IsTrue(esperado.SequenceEqual(resultado));
        }

        [TestMethod]
        public void Plataformas_Mas_Usadas_Ordenadas()
        {
            IEnumerable<vmNombreCantidad> esperado = new List<vmNombreCantidad>
            {
                new vmNombreCantidad { Nombre = "Netflix", Cantidad = 4901 },
                new vmNombreCantidad { Nombre = "Hbo", Cantidad = 2037 },
                new vmNombreCantidad { Nombre = "AmazonPrime", Cantidad = 14 } 
            };

            ConsultasAgrupaciones consulta = new ConsultasAgrupaciones();
            IEnumerable<vmNombreCantidad> resultado = consulta.PlataformasMasUsadasOrdenadas();

            Assert.IsTrue(esperado.SequenceEqual(resultado));
        }

    }
}
