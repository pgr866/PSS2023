using System.Linq;
using System.Xml.Linq;

namespace PSS.pgr866.Practica_04b
{
    public class ConsultasAgrupaciones
    {
        private XDocument datos;

        //Constructor donde cargamos los datos llamando a un metodo de la clase UserData
        public ConsultasAgrupaciones()
        {
            // Cargar el documento XML
            datos = XDocument.Load(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.Parent.FullName + "\\LibreriaConsultas\\Datos.xml");
        }

        //**********   Agrupaciones ***************
        /// <summary>
        /// ¿Desde que IP ha habido más visualizaciones y cuantas para una genero dado? 
        /// </summary>
        /// <returns>Lista con la IP y el número de visualizaciones</returns>
        public IEnumerable<vmNombreCantidad> IPconMasVisualizacionesSegunGenero(string nombreGenero)
        {
            var resultado = (from visgen in datos.Descendants("VisorGenero")
                             join gen in datos.Descendants("Genero") on (int)visgen.Element("GeneroId") equals (int)gen.Element("Id")
                             join visu in datos.Descendants("Visualizacion") on (int)visgen.Element("Id") equals (int)visu.Element("VisorGeneroId")
                             where (string)gen.Element("NombreGenero") == nombreGenero
                             group (int)visgen.Element("VisorId") by (string)visu.Element("IP") into g
                             orderby g.Count() descending
                             select new vmNombreCantidad
                             {
                                 Nombre = g.Key,
                                 Cantidad = g.Count()
                             }).Take(1); // Tomamos solo el primer resultado, el de la genero con mayor número de visores
            return resultado;
        }



        /// <summary>
        /// Secuencia de pares (visores, suma total duración de visualizacion) ordenados de mayor a menor duración
        /// </summary>

        /// <returns>Lista de pares NombreVisor, suma de la duración de las visualizaciones</returns>
        public IEnumerable<vmNombreCantidad> VisorSumaDuracionVisualizaciones()
        {
            var resultado = from vis in datos.Descendants("Visor")
                            join visgen in datos.Descendants("VisorGenero") on (int)vis.Element("Id") equals (int)visgen.Element("VisorId")
                            join visu in datos.Descendants("Visualizacion") on (int)visgen.Element("Id") equals (int)visu.Element("VisorGeneroId")
                            group (int)visu.Element("Duracion") by (string)vis.Element("NombreVisor") into g
                            orderby g.Sum() descending
                            select new vmNombreCantidad
                            {
                                Nombre = g.Key,
                                Cantidad = (double?)g.Sum() ?? 0
                            };
            return resultado;
        }





        /// <summary>
        /// LEFT OUTER JOIN
        /// Secuencia de pares (visores, suma total de duración de visualizaciones) ordenados de menor a mayor duración 
        /// Visores que no se hayan conectado nunca deberán aparecer con una cantidad de 0
        /// </summary>

        /// <returns>Lista de pares NombreVisor, total suma de duración de visualizaciones</returns>
        public IEnumerable<vmNombreCantidad> VisorSumaDuracionVisualizacionesNulos()
        {
            var resultado = from vis in datos.Descendants("Visor")
                            join visgen in datos.Descendants("VisorGenero") on (int)vis.Element("Id") equals (int)visgen.Element("VisorId")
                            join visu in datos.Descendants("Visualizacion") on (int)visgen.Element("Id") equals (int)visu.Element("VisorGeneroId") into resul
                            from r in resul.DefaultIfEmpty()
                            group (r == null ? 0 : (int)r.Element("Duracion")) by (string)vis.Element("NombreVisor") into g
                            orderby g.Sum() descending
                            select new vmNombreCantidad
                            {
                                Nombre = g.Key,
                                Cantidad = g.Sum()
                            };

            return resultado;
        }





        /// <summary>
        /// LEFT OUTER JOIN
        /// Relacion de visores cuya suma total de duración de visualizacion sea superior a la media. 
        /// </summary>
        /// <returns>Lista con el nombre de visor y suma total de duracion de visualizaciones</returns>
        public IEnumerable<vmNombreCantidad> VisoresSumaDuracionMayorMedia()
        {
            var resultado = from vis in datos.Descendants("Visor")
                            join visgen in datos.Descendants("VisorGenero") on (int)vis.Element("Id") equals (int)visgen.Element("VisorId")
                            join visu in datos.Descendants("Visualizacion") on (int)visgen.Element("Id") equals (int)visu.Element("VisorGeneroId") into resul
                            from r in resul.DefaultIfEmpty()
                            group (r == null ? 0 : (int)r.Element("Duracion")) by (string)vis.Element("NombreVisor") into g
                            orderby g.Sum()
                            select new vmNombreCantidad
                            {
                                Nombre = g.Key,
                                Cantidad = g.Sum()
                            };

            double media = resultado.Average(e => e.Cantidad);
            var resultado2 = resultado.Where(e => e.Cantidad > media);

            return resultado2;
        }





        /// <summary>
        /// Relacion de plataformas y su respectiva suma de tiempos de visualizacion de todos los visores 
        /// </summary>
        /// <returns>Lista con el nombre de plataforma y  suma total de duracion de visualizaciones</returns>
        public IEnumerable<vmNombreCantidad> PlataformasMasUsadas()
        {
            var resultado = from plat in datos.Descendants("Plataforma")
                            join vis in datos.Descendants("Visor") on (int)plat.Element("Id") equals (int)vis.Element("PlataformaId")
                            join visgen in datos.Descendants("VisorGenero") on (int)vis.Element("Id") equals (int)visgen.Element("VisorId")
                            join visu in datos.Descendants("Visualizacion") on (int)visgen.Element("Id") equals (int)visu.Element("VisorGeneroId")
                            group (int)visu.Element("Duracion") by (string)plat.Element("NombrePlataforma") into g
                            orderby g.Sum()
                            select new vmNombreCantidad
                            {
                                Nombre = g.Key,
                                Cantidad = (double?)g.Sum() ?? 0
                            };
            return resultado;
        }

        /// <summary>
        /// Relacion de plataformas y su respectiva suma de tiempos de visualizacion de todos los visores (ordenas de mayor a menor) 
        /// </summary>
        /// <returns>Lista con el nombre de plataforma y  suma total de duracion de visualizaciones</returns>
        public IEnumerable<vmNombreCantidad> PlataformasMasUsadasOrdenadas()
        {
            var resultado = from plat in datos.Descendants("Plataforma")
                            join vis in datos.Descendants("Visor") on (int)plat.Element("Id") equals (int)vis.Element("PlataformaId")
                            join visgen in datos.Descendants("VisorGenero") on (int)vis.Element("Id") equals (int)visgen.Element("VisorId")
                            join visu in datos.Descendants("Visualizacion") on (int)visgen.Element("Id") equals (int)visu.Element("VisorGeneroId")
                            group (int)visu.Element("Duracion") by (string)plat.Element("NombrePlataforma") into g
                            orderby g.Sum() descending
                            select new vmNombreCantidad
                            {
                                Nombre = g.Key,
                                Cantidad = (double?)g.Sum() ?? 0
                            };
            return resultado;
        }

    }
}
