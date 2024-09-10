using System.Xml.Linq;

namespace PSS.pgr866.Practica_04b
{
    public class ConsultasGeneros
    {
        private XDocument datos;

        //Constructor donde cargamos los datos llamando a un metodo de la clase UserData
        public ConsultasGeneros()
        {
            // Cargar el documento XML
            datos = XDocument.Load(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.Parent.FullName + "\\LibreriaConsultas\\Datos.xml");
        }

        //**********   Generos ***************
        /// <summary>
        /// Lista de pares (Genero,Visor) para  una plataforma dada
        /// </summary>

        /// <param name="plataforma">nombre de la plataforma</param>
        /// <returns>Lista de pares (nombre de genero y nombre de Visor)</returns>
        public IEnumerable<vmGeneroNombre> ListaParGeneroVisorParaPlat(string plataforma)
        {
            var result = from gen in datos.Descendants("Genero")
                         join plat in datos.Descendants("Plataforma") on (int)gen.Element("PlataformaId") equals (int)plat.Element("Id")
                         join vis in datos.Descendants("Visor") on (int)plat.Element("Id") equals (int)vis.Element("PlataformaId")
                         where ((string)plat.Element("NombrePlataforma")).ToUpper() == plataforma.ToUpper()
                         select new vmGeneroNombre
                         {
                             Nombre = ((string)vis.Element("NombreVisor")).ToUpper(),
                             Genero = ((string)gen.Element("NombreGenero")).ToUpper()
                         };
            return result;
        }

        /// <summary>
        /// Lista de Visores agrupados en lista de generos  (un mismo visor puede estar en dos generos)
        /// </summary>
        /// <returns> Lista  de nombres de visor agrupados para cada genero (de otra lista)  </returns>
        public IEnumerable<IGrouping<string, vmGeneroNombre>> AgrupacionVisoresGeneros()
        {
            var resultado = from gen in datos.Descendants("Genero")
                            join visgen in datos.Descendants("VisorGenero") on (int)gen.Element("Id") equals (int)visgen.Element("GeneroId")
                            join vis in datos.Descendants("Visor") on (int)visgen.Element("VisorId") equals (int)vis.Element("Id")
                            group new vmGeneroNombre
                            {
                                Genero = ((string)gen.Element("NombreGenero")).ToUpper(),
                                Nombre = ((string)vis.Element("NombreVisor")).ToUpper()
                            }
                           by ((string)gen.Element("NombreGenero")).ToUpper()
                            into g
                            select g;
            return resultado;

        }

        /// <summary>
        /// Relacion de Visores agrupados en generos ordenadas éstas en orden descendente alfabéticamente 
        ///(un mismo puede aparecer  varias veces si esta en varias generos)
        /// </summary>
        /// <returns> Lista agrupada de visores por generos </returns>
        public IEnumerable<vmGeneroNombre> AgrupacionVisoresGenerosOrdenados()
        {
            var resultado = from gen in datos.Descendants("Genero")
                            join visgen in datos.Descendants("VisorGenero") on (int)gen.Element("Id") equals (int)visgen.Element("GeneroId")
                            join vis in datos.Descendants("Visor") on (int)visgen.Element("VisorId") equals (int)vis.Element("Id")
                            orderby ((string)vis.Element("NombreVisor")).ToUpper() descending
                            select new vmGeneroNombre
                            {
                                Genero = ((string)gen.Element("NombreGenero")).ToUpper(),
                                Nombre = ((string)vis.Element("NombreVisor")).ToUpper()
                            };

            return resultado;
        }



        // <summary>
        // Genero con mayor numero de visores y total
        // </summary>
        // <returns>Devuelve nombre de el genero con más usurios y el numero de visores</returns>
        public IEnumerable<vmGeneroNombre> GeneroMaximoNumeroVisores()
        {
            var resultado = (from gen in datos.Descendants("Genero")
                             join visgen in datos.Descendants("VisorGenero") on (int)gen.Element("Id") equals (int)visgen.Element("GeneroId")
                             group (int)visgen.Element("VisorId") by (string)gen.Element("NombreGenero") into g
                             orderby g.Count() descending
                             select new vmGeneroNombre
                             {
                                 Genero = g.Key,
                                 Nombre = g.Count().ToString()
                             }).Take(1); // Tomamos solo el primer resultado, el de la genero con mayor número de visores

            return resultado;
        }




        /// <summary>
        /// Todas las generos de visores para una plataforma dada
        /// </summary>
        /// <param name="plataforma"> nombre de la plataforma</param>
        /// <returns>Lista de los nombres de las generos de visores</returns>
        public IEnumerable<vmGeneroNombre> TodosGenerosPlat(string plataforma)
        {
            var registro = (from plat in datos.Descendants("Plataforma")
                            join gen in datos.Descendants("Genero") on (int)plat.Element("Id") equals (int)gen.Element("PlataformaId")
                            join vis in datos.Descendants("Visor") on (int)plat.Element("Id") equals (int)vis.Element("PlataformaId")
                            where (string)plat.Element("NombrePlataforma") == plataforma
                            select new vmGeneroNombre
                            {
                                Nombre = (string)plat.Element("NombrePlataforma"),
                                Genero = (string)gen.Element("NombreGenero")
                            }).Distinct();
            return registro;
        }



        /// <summary>
        /// Lista de Genero/Plataforma  para un visor dado 
        /// </summary>
        /// <param name="visor">nombre del visor</param>
        /// <returns>Lista de pares (nombre de genero y nombre de plataforma)</returns>
        public IEnumerable<vmGeneroNombre> GenerosPlataformaParaVisor(string visor)
        {
            var registro = from vis in datos.Descendants("Visor")
                           join plat in datos.Descendants("Plataforma") on (int)vis.Element("PlataformaId") equals (int)plat.Element("Id")
                           join gen in datos.Descendants("Genero") on (int)plat.Element("Id") equals (int)gen.Element("PlataformaId")
                           where (string)vis.Element("NombreVisor") == visor
                           select new vmGeneroNombre { Genero = (string)gen.Element("NombreGenero"), Nombre = (string)plat.Element("NombrePlataforma") };
            return registro;
        }

    }
}
