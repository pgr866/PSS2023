using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSS.pgr866.Practica_05
{
    public class AutentificacionTextFile: IAutentificacion
    {
        private FormatoRegistro formatoRegistro;
        private string textFile;
        private string finCampo;
        private Dictionary<string, IUsuarioView> diccionarioUsuarios;

        /// <summary>
        /// Constructor sobre cargado, en el que se especifica: nombre del archivo que contiene las 
        /// lineas de texto que representan a cada Usuario, 
        /// el orden de los campos que constituye la información del usuario, y la cadena separadora.
        /// </summary>
        /// <param name="textFile">nombre del archivo de texto</param>
        /// <param name="formatoRegistro">Descripcion del formato del registro (orden de los campos en cada linea del archivo de texto)</param>
        /// <param name="finCampo">cadena que determina la separación entre campos</param>
        public AutentificacionTextFile(string textFile, FormatoRegistro formatoRegistro, string finCampo)
        {
            this.textFile = textFile;
            this.formatoRegistro = formatoRegistro;
            this.finCampo = finCampo;
            this.diccionarioUsuarios = new Dictionary<string, IUsuarioView>();
            if ((textFile != null) && File.Exists(textFile))
            {
                using (var fs = File.OpenRead(textFile))
                {
                    StreamReader srTextFile = new StreamReader(fs);
                    string reg = null;

                    while ((reg = srTextFile.ReadLine()) != null)
                    {
                        IUsuarioView user = Decodificar(reg);
                        try
                        {
                            diccionarioUsuarios.Add(user.Id, user);
                        }
                        catch
                        {
                            throw new AutentificacionExcepcion("Id " + user.Id + " ya existe.",
                                    CodigoAutentificacion.ErrorDatos);
                        }
                    }
                }
            }
            else
                throw new AutentificacionExcepcion("El fichero " + textFile + " no existe.",
                    CodigoAutentificacion.ErrorDatos);
        }

        private IUsuarioView Decodificar(string lineaFichero)
        {
            IUsuarioView user = new UsuarioView();
            int indexCampo = 0;
            bool hayError = false;
            string[] trozos = lineaFichero.Split(finCampo.ToCharArray());
            for (int i = 0; i < trozos.Count(); i++)
            {
                CamposRegistro campo = formatoRegistro.CamposRegistro[i];
                switch (campo)
                {
                    case CamposRegistro.Id:
                        {
                            user.Id = trozos[i];
                            break;
                        }
                    case CamposRegistro.Nombre:
                        {
                            user.Nombre = trozos[i];
                            break;
                        }
                    case CamposRegistro.PalabraPaso:
                        {
                            user.PalabraPaso = trozos[i];
                            break;
                        }
                    case CamposRegistro.Categoria:
                        {
                            user.Categoria = trozos[i];
                            break;
                        }
                    case CamposRegistro.EsValido:
                        {
                            if (trozos[i].ToUpper() == "TRUE")
                                user.EsValido = true;
                            else
                                user.EsValido = false;
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
                indexCampo++;
                if (indexCampo >= formatoRegistro.CamposRegistro.Length)
                    hayError = true;
            }

            return user;
        }

        

        public CodigoAutentificacion EsUsuarioAutentificado(string id, string PalabraPaso)
        {
            IUsuarioView usuario = ObtenerUsuario(id);
            if (usuario == null)
                return CodigoAutentificacion.ErrorIdUsuario;
            if (usuario.PalabraPaso != PalabraPaso)
            {
                if (usuario.EsValido)
                    return CodigoAutentificacion.ErrorPalabraPaso;
                return CodigoAutentificacion.ErrorPalabraPaso | CodigoAutentificacion.AccesoInvalido;
            }
            if (usuario.EsValido)
                return CodigoAutentificacion.AccesoCorrecto;
            return CodigoAutentificacion.AccesoInvalido;
        }

        public IUsuarioView ObtenerUsuario(string id)
        {
            if (diccionarioUsuarios.ContainsKey(id))
                return diccionarioUsuarios[id];
            return null;
        }

        public bool ModificarUsuario(string id, IUsuarioView user)
        {
            if (diccionarioUsuarios == null)
                return false;
            if (diccionarioUsuarios.ContainsKey(id)) 
            {
                diccionarioUsuarios[id] = user;
                GuardarDatos();
                return true;
            }
            else
                return false;
        }

        public bool InsertarUsuario(IUsuarioView user)
        {
            if (diccionarioUsuarios.ContainsKey(user.Id))
                return false;
            diccionarioUsuarios.Add(user.Id, user);
            GuardarDatos();
            return true;
        }

        public bool EliminarUsuario(string id)
        {
            if (!diccionarioUsuarios.ContainsKey(id))
                return false;
            diccionarioUsuarios.Remove(id);
            GuardarDatos();
            return true;
        }

        public void GuardarDatos()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(textFile))
                {
                    foreach (KeyValuePair<string, IUsuarioView> usu in diccionarioUsuarios)
                    {
                        string cadena = Codificar(usu.Value);
                        sw.WriteLine(cadena);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        private string Codificar(IUsuarioView user)
        {
            string cadena;

            cadena = "";
            for (int j = 0; j < formatoRegistro.CamposRegistro.Length; j++)
            {
                switch (formatoRegistro.CamposRegistro[j])
                {
                    case CamposRegistro.Id: cadena = cadena + user.Id; break;
                    case CamposRegistro.Nombre: cadena = cadena + user.Nombre; break;
                    case CamposRegistro.PalabraPaso: cadena = cadena + user.PalabraPaso; break;
                    case CamposRegistro.Categoria: cadena = cadena + user.Categoria; break;
                    case CamposRegistro.EsValido: cadena = cadena + user.EsValido; break;
                }
                if (j < formatoRegistro.CamposRegistro.Length - 1)
                    cadena = cadena + finCampo;
            }
            return cadena;
        }

        public void Listado()
        {
        }
    }
}
