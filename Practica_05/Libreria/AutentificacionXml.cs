using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PSS.pgr866.Practica_05
{
    public class AutentificacionXml : IAutentificacion
    {

        private String _xmlFilename = "claves.xml";
        private XDocument _xmlDocument = null;


        IUsuarioView _usuarioAutentificado;



        /// <summary>
        /// Constructor en el que se especifica: nombre del archivo Xml que contiene los Usuario.
        /// </summary>
        /// <param name="xmlFile">nombre del archivo de Xml</param>

        public AutentificacionXml(string xmlFile)
        {
            _xmlFilename = xmlFile;

            if ((_xmlFilename != null) && File.Exists(_xmlFilename))
            {

                try
                {
                    _xmlDocument = XDocument.Load(_xmlFilename);
                }
                catch
                {
                    throw new AutentificacionExcepcion("Error al acceder al archivo Xml", CodigoAutentificacion.ErrorDatos);
                }


            }
            else throw new AutentificacionExcepcion("El fichero " + xmlFile + " no existe.", CodigoAutentificacion.ErrorDatos);
        }

        public bool EliminarUsuario(string id)
        {
            try
            {
                XElement usuxml = (from usu in _xmlDocument.Elements("Usuarios").Elements("Usuario")
                                   where usu.Attribute("Id").Value == id
                                   select usu).First();
                usuxml.Remove();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public CodigoAutentificacion EsUsuarioAutentificado(string id, string PalabraPaso)
        {
            IUsuarioView usu = ObtenerUsuario(id);
            if (usu.PalabraPaso != PalabraPaso)
                return CodigoAutentificacion.ErrorPalabraPaso;
            if (!usu.EsValido)
                return CodigoAutentificacion.AccesoInvalido;
            return CodigoAutentificacion.AccesoCorrecto;
        }

        public void GuardarDatos()
        {
            try
            {
                _xmlDocument.Save(_xmlFilename);
            }
            catch (Exception e) { }
        }

        public bool InsertarUsuario(IUsuarioView user)
        {
            try
            {
                IUsuarioView usu = ObtenerUsuario(user.Id);

                return false;
            }
            catch (AutentificacionExcepcion e)
            {

                XElement usuxml = new XElement("Usuario",
                                        new XAttribute("Id", user.Id),
                                        new XElement("Nombre", user.Nombre),
                                        new XElement("PalabraPaso", user.PalabraPaso),
                                        new XElement("Categoria", user.Categoria),
                                        new XElement("EsValido", user.EsValido));
                _xmlDocument.Element("Usuarios").Add(usuxml);

                return true;
            }
        }

        public void Listado()
        {
            var resul = from x in _xmlDocument.Descendants() select x;
            foreach (var x in resul)
            {
                Console.WriteLine("------" + x);
            }
        }

        public bool ModificarUsuario(string id, IUsuarioView user)
        {
            try
            {
                XElement usuxml = (from usu in _xmlDocument.Elements("Usuarios").Elements("Usuario")
                                   where usu.Attribute("Id").Value == id
                                   select usu).First();

                usuxml.SetElementValue("Nombre", user.Nombre);
                usuxml.SetElementValue("PalabraPaso", user.PalabraPaso);
                usuxml.SetElementValue("Categoria", user.Categoria);
                usuxml.SetElementValue("EsValido", user.EsValido);

                return true;
            }
            catch (AutentificacionExcepcion e)
            {
                return false;
            }
        }

        public IUsuarioView ObtenerUsuario(string id)
        {
            if (_xmlDocument is null)
                throw new AutentificacionExcepcion("El fichero de datos no se encuentra", CodigoAutentificacion.ErrorDatos);
            try
            {
                var resul = from usu in _xmlDocument.Elements("Usuarios").Elements("Usuario")
                            where usu.Attribute("Id").Value == id
                            select new UsuarioView
                            {
                                Id = usu.Attribute("Id").Value,
                                Nombre = usu.Element("Nombre").Value,
                                PalabraPaso = usu.Element("PalabraPaso").Value,
                                Categoria = usu.Element("Categoria").Value,
                                EsValido = Boolean.Parse(usu.Element("EsValido").Value)
                            };
                
                return resul.First();
            }
            catch
            {
                throw new AutentificacionExcepcion("El Id de usuario no existe", CodigoAutentificacion.ErrorIdUsuario);
            }
        }
    }
}
