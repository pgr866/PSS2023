using System.Xml.Linq;

namespace PSS.pgr866.Practica_04b
{
    public class ConsultasVisores
    {
        private XDocument datos;

        //Constructor donde cargamos los datos llamando a un metodo de la clase UserData
        public ConsultasVisores()
        {
            // Cargar el documento XML
            datos = XDocument.Load(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.Parent.FullName + "\\LibreriaConsultas\\Datos.xml");
        }

        //**************  Visores ********************************
        /// <summary>
        /// Visores que se han conectado a una plataforma según el genero cuyo codigo es generoId
        /// </summary>
        /// <param name="generoId"> Id de el genero</param>
        /// <returns> Lista ordenada alfabéticamente de los nombres de ls visores en mayúsculas</returns>
        public IEnumerable<vmNombre> VisoresEnGenero(int generoId)
        {
            var resultado = from vis in datos.Descendants("Visor")
                            join visgen in datos.Descendants("VisorGenero") on (int)vis.Element("Id") equals (int)visgen.Element("VisorId") //Con join no ponemos ==, se debe de poner equals
                            join gen in datos.Descendants("Genero") on (int)visgen.Element("GeneroId") equals (int)gen.Element("Id")
                            where (int)gen.Element("Id") == generoId
                            orderby (string)vis.Element("NombreVisor") //En SQL el order by se escribe separado, aqui lo escribimos junto y antes del select
                            select new vmNombre
                            {
                                Nombre = ((string)vis.Element("NombreVisor")).ToUpper()
                            }; //Con ToUpper ordenamos los nombres

            return resultado;
        }

        /// <summary>
        /// Visores que se han conectado a una plataforma según el genero cuyo nombre es nombreGenero
        /// </summary>
        /// <param name="nombreGenero"> Nombre de el genero</param>
        /// <returns> Lista ordenada alfabéticamente de los nombres de ls visores en mayúsculas</returns>
        public IEnumerable<vmNombre> VisoresEnGenero(string nombreGenero)
        {
            var resultado = from vis in datos.Descendants("Visor")
                            join visgen in datos.Descendants("VisorGenero") on (int)vis.Element("Id") equals (int)visgen.Element("VisorId") //Con join no ponemos ==, se debe de poner equals
                            join gen in datos.Descendants("Genero") on (int)visgen.Element("GeneroId") equals (int)gen.Element("Id")
                            where (string)gen.Element("NombreGenero") == nombreGenero
                            orderby (string)vis.Element("NombreVisor") //En SQL el order by se escribe separado, aqui lo escribimos junto y antes del select
                            select new vmNombre
                            {
                                Nombre = ((string)vis.Element("NombreVisor")).ToUpper()
                            }; //Con ToUpper ordenamos los nombres

            return resultado;
        }

        /// <summary>
        /// Visores cuyo nombre comienza por cadenaComienzo 
        /// </summary>
        /// <param name="cadenaComienzo">cadena de comienzo del nombre</param>
        /// <returns> Lista de los nombres de ls visores en mayúsculas</returns>
        public IEnumerable<vmNombre> VisoresConNombreComienza(string cadenaComienzo)
        {
            var resultado = from vis in datos.Descendants("Visor")
                            where ((string)vis.Element("NombreVisor")).ToUpper().StartsWith(cadenaComienzo.ToUpper())
                            orderby (string)vis.Element("NombreVisor")
                            select new vmNombre
                            {
                                Nombre = ((string)vis.Element("NombreVisor")).ToUpper()
                            };

            return resultado;
        }

        /// <summary>
        /// Visores cuyo nombre comienza por cadenaComienzo que pertenecen a una genero dada
        /// </summary>
        /// <param name="genero">nombre de la caegoria</param>
        /// <param name="cadenaComienzo">cadnea de comienzo del nombre</param>
        /// <returns> Lista ordenada alfabéticamente de los nombres de ls visores en mayúsculas</returns>
        public IEnumerable<vmNombre> VisoresConNombreComienzaEnGenero(string cadenaComienzo, string genero)
        {
            var resultado = from vis in datos.Descendants("Visor")
                            join visgen in datos.Descendants("VisorGenero") on (int)vis.Element("Id") equals (int)visgen.Element("VisorId")
                            join gen in datos.Descendants("Genero") on (int)visgen.Element("GeneroId") equals (int)gen.Element("Id")
                            where ((string)gen.Element("NombreGenero")).ToUpper() == genero.ToUpper()
                                    && ((string)vis.Element("NombreVisor")).ToUpper().StartsWith(cadenaComienzo.ToUpper())
                            select new vmNombre
                            {
                                Nombre = ((string)vis.Element("NombreVisor")).ToUpper()
                            };
            return resultado;
        }
        /// <summary>
        /// Visores conectados desde una IP  
        /// </summary>
        /// <param name="ip">ip de la visualizacion</param>
        /// <returns> Lista de los nombres de los visores en mayúsculas</returns>
        public IEnumerable<vmNombre> VisoresConectadosIP(string ip)
        {
            var resultado = from vis in datos.Descendants("Visor")
                            join visgen in datos.Descendants("VisorGenero") on (int)vis.Element("Id") equals (int)visgen.Element("VisorId")
                            join visu in datos.Descendants("Visualizacion") on (int)visgen.Element("Id") equals (int)visu.Element("VisorGeneroId")
                            where ((string)visu.Element("IP")).ToUpper() == ip.ToUpper()
                            select new vmNombre
                            {
                                Nombre = ((string)vis.Element("NombreVisor")).ToUpper()
                            };
            return resultado;
        }

        /// <summary>
        /// Encuentra el  nombre del visor de una plataforma dada a través de su e-mail
        /// </summary>
        /// <param name="Plataforma"> cadena con el nombre de la plataforma</param>
        /// <param name="email">cadena con el e-mail</param>
        /// <returns> Nombre del Visor o null si no se encuentra</returns>
        public IEnumerable<vmNombre> EncontrarVisorPlatEmail(string plataforma, string email)
        {
            var resultado = from vis in datos.Descendants("Visor")
                            join cue in datos.Descendants("Cuenta") on (int)vis.Element("Id") equals (int)cue.Element("VisorId")
                            join plat in datos.Descendants("Plataforma") on (int)cue.Element("PlataformaId") equals (int)plat.Element("Id")
                            where plataforma.ToUpper() == ((string)plat.Element("NombrePlataforma")).ToUpper()
                            && email.ToUpper() == ((string)cue.Element("Email")).ToUpper()
                            select new vmNombre
                            {
                                Nombre = ((string)vis.Element("NombreVisor")).ToUpper()
                            };
            return resultado;
        }

    }
}
