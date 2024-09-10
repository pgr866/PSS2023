namespace PSS.pgr866.Practica_04a
{
    public class ConsultasUsuarios
    {
        private UserData datos;

        //Constructor donde cargamos los datos llamando a un metodo de la clase UserData
        public ConsultasUsuarios()
        {
            datos = new UserData();
            datos.CargarDatos();
        }

        //**************  Usuarios ********************************
        /// <summary>
        /// Usuarios que se han conectado a una aplicación según la categoria cuyo codigo es categoriaId
        /// </summary>
        /// <param name="categoriaId"> Id de la categoria</param>
        /// <returns> Lista ordenada alfabéticamente de los nombres de ls usuarios en mayúsculas</returns>
        public IEnumerable<vmNombre> UsuariosEnCategoria(int categoriaId)
        {
            var resultado = from usu in datos.Usuarios
                            join usucat in datos.UsuariosCategorias on usu.Id equals usucat.UsuarioId //Con join no ponemos ==, se debe de poner equals
                            join cat in datos.Categorias on usucat.CategoriaId equals cat.Id
                            where cat.Id == categoriaId
                            orderby usu.NombreUsuario //En SQL el order by se escribe separado, aqui lo escribimos junto y antes del select
                            select new vmNombre {
                                Nombre = usu.NombreUsuario.ToUpper()
                            }; //Con ToUpper ordenamos los nombres

            return resultado;
        }

        /// <summary>
        /// Usuarios que se han conectado a una aplicación según la categoria cuyo nombre es nombreCategoria
        /// </summary>
        /// <param name="nombreCategoria"> Nombre de la categoria</param>
        /// <returns> Lista ordenada alfabéticamente de los nombres de ls usuarios en mayúsculas</returns>
        public IEnumerable<vmNombre> UsuariosEnCategoria(string nombreCategoria)
        {
            var resultado = from usu in datos.Usuarios
                            join usucat in datos.UsuariosCategorias on usu.Id equals usucat.UsuarioId //Con join no ponemos ==, se debe de poner equals
                            join cat in datos.Categorias on usucat.CategoriaId equals cat.Id
                            where cat.NombreCategoria == nombreCategoria
                            orderby usu.NombreUsuario //En SQL el order by se escribe separado, aqui lo escribimos junto y antes del select
                            select new vmNombre {
                                Nombre = usu.NombreUsuario.ToUpper()
                            }; //Con ToUpper ordenamos los nombres

            return resultado;
        }

        /// <summary>
        /// Usuarios cuyo nombre comienza por cadenaComienzo 
        /// </summary>
        /// <param name="cadenaComienzo">cadena de comienzo del nombre</param>
        /// <returns> Lista de los nombres de ls usuarios en mayúsculas</returns>
        public IEnumerable<vmNombre> UsuariosConNombreComienza(string cadenaComienzo)
        {
            var resultado = from usu in datos.Usuarios
                            where usu.NombreUsuario.ToUpper().StartsWith(cadenaComienzo.ToUpper())
                            orderby usu.NombreUsuario
                            select new vmNombre {
                                Nombre = usu.NombreUsuario.ToUpper()
                            };

            return resultado;
        }

        /// <summary>
        /// Usuarios cuyo nombre comienza por cadenaComienzo que pertenecen a una categoria dada
        /// </summary>
        /// <param name="categoria">nombre de la caegoria</param>
        /// <param name="cadenaComienzo">cadnea de comienzo del nombre</param>
        /// <returns> Lista ordenada alfabéticamente de los nombres de ls usuarios en mayúsculas</returns>
        public IEnumerable<vmNombre> UsuariosConNombreComienzaEnCategoria(string cadenaComienzo, string categoria)
        {
            var resultado = from usu in datos.Usuarios
                            join usucat in datos.UsuariosCategorias on usu.Id equals usucat.UsuarioId
                            join cat in datos.Categorias on usucat.CategoriaId equals cat.Id
                            where cat.NombreCategoria.ToUpper() == categoria.ToUpper()
                                    && usu.NombreUsuario.ToUpper().StartsWith(cadenaComienzo.ToUpper())
                            select new vmNombre
                            {
                                Nombre = usu.NombreUsuario.ToUpper()
                            };
            return resultado;
        }
        /// <summary>
        /// Usuarios conectados desde una IP  
        /// </summary>
        /// <param name="ip">ip de la conexion</param>
        /// <returns> Lista de los nombres de los usuarios en mayúsculas</returns>
        public IEnumerable<vmNombre> UsuariosConectadosIP(string ip)
        {
            var resultado = from usu in datos.Usuarios
                            join usucat in datos.UsuariosCategorias on usu.Id equals usucat.UsuarioId
                            join con in datos.Conexiones on usucat.Id equals con.UsuarioCategoriaId
                            where con.IP.ToUpper() == ip.ToUpper()
                            select new vmNombre
                            {
                                Nombre = usu.NombreUsuario.ToUpper()
                            };
            return resultado;
        }

        /// <summary>
        /// Encuentra el  nombre del usuario de una aplicación dada a través de su e-mail
        /// </summary>
        /// <param name="Aplicacion"> cadena con el nombre de la aplicación</param>
        /// <param name="email">cadena con el e-mail</param>
        /// <returns> Nombre del Usuario o null si no se encuentra</returns>
        public IEnumerable<vmNombre> EncontrarUsuarioAppEmail(string aplicacion, string email)
        {
            var resultado = from usu in datos.Usuarios
                            join per in datos.Personales on usu.Id equals per.UsuarioId
                            join apl in datos.Aplicaciones on per.AplicacionId equals apl.Id
                            where aplicacion.ToUpper() == apl.NombreAplicacion.ToUpper()
                            && email.ToUpper() == per.Email.ToUpper()
                            select new vmNombre
                            {
                                Nombre = usu.NombreUsuario.ToUpper()
                            };
            return resultado;
        }

    }
}