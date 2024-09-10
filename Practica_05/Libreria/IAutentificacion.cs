using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSS.pgr866.Practica_05
{
    /// <summary>
    /// Interface IAutentificacion describe el contrato que debe cumplir las clases que implementen la autentificación.
    /// </summary>
    public interface IAutentificacion
    {
        /// <summary>
        /// Su finalidad es comprobar que el usuario está autentificado.
        /// </summary>
        /// <param name="id"> Clave primaria = id</param>
        /// <param name="passWord"> Palabra de paso </param>
        /// <returns> Devuelve el código de autentificación </returns>
        CodigoAutentificacion EsUsuarioAutentificado(string id, string PalabraPaso);

        /// <summary>
        /// Su finalidad es modificar un usuario que debe de estar autentificado.
        /// </summary>
        /// <param name="id"> Clave primaria = id</param>
        /// <param name="user"> Nuevos datos del usuario </param>
        /// <returns> Devuelve si se ha efectuado la modificación adecuadamente </returns>
        bool ModificarUsuario(string id, IUsuarioView user);

        /// <summary>
        /// Su finalidad es Insertar un nuevo usuario que no debe de existir.
        /// </summary>
        /// <param name="user"> Nuevos datos del usuario </param>
        /// <returns> Devuelve si se ha efectuado la insercción adecuadamente </returns>
        bool InsertarUsuario(IUsuarioView user);

        /// <summary>
        /// Su finalidad es eliminar un usuario que debe de existir.
        /// </summary>
        /// <param name="id"> Clave primaria = id</param>
        /// <returns> Devuelve si se ha efectuado la eliminación adecuadamente </returns>
        bool EliminarUsuario(string id);

        /// <summary>
        /// Su finalidad es obtener la información de un usuario.
        /// </summary>
        /// <param name="id"> Clave primaria = id</param>
        /// <returns> Devuelve el Usuario o null en caso de que no exista </returns>
        IUsuarioView ObtenerUsuario(string id);


        /// <summary>
        /// Su finalidad es guardar la información en el origen de datos (si procede). 
        /// </summary>
        void GuardarDatos();

        void Listado();

    }

}
