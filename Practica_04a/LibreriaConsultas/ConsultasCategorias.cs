namespace PSS.pgr866.Practica_04a
{
    public class ConsultasCategorias
    {
        private UserData datos;

        //Constructor donde cargamos los datos llamando a un metodo de la clase UserData
        public ConsultasCategorias()
        {
            datos = new UserData();
            datos.CargarDatos();
        }

        //**********   Categorias ***************
        /// <summary>
        /// Lista de pares (Categoria,Usuario) para  una aplicación dada
        /// </summary>

        /// <param name="aplicación">nombre de la aplicación</param>
        /// <returns>Lista de pares (nombre de categoria y nombre de Usuario)</returns>
        public IEnumerable<vmCategoriaNombre> ListaParCategoriaUsuarioParaApp(string aplicacion)
        {
            var result = from cat in datos.Categorias
                         join apl in datos.Aplicaciones on cat.AplicacionId equals apl.Id
                         join usu in datos.Usuarios on apl.Id equals usu.AplicacionId
                         where apl.NombreAplicacion.ToUpper() == aplicacion.ToUpper()
                         select new vmCategoriaNombre {
                             Nombre = usu.NombreUsuario.ToUpper(),
                             Categoria = cat.NombreCategoria.ToUpper()
                         };
            return result;
        }

        /// <summary>
        /// Lista de Usuarios agrupados en lista de categorias  (un mismo usuario puede estar en dos categorias)
        /// </summary>
        /// <returns> Lista  de nombres de usuario agrupados para cada categoria (de otra lista)  </returns>
        public IEnumerable<IGrouping<string, vmCategoriaNombre>> AgrupacionUsuariosCategorias()
        {
            var resultado = from cat in datos.Categorias
                            join usucat in datos.UsuariosCategorias on cat.Id equals usucat.CategoriaId
                            join usu in datos.Usuarios on usucat.UsuarioId equals usu.Id
                            group new vmCategoriaNombre
                            {
                                Categoria = cat.NombreCategoria.ToUpper(),
                                Nombre = usu.NombreUsuario.ToUpper()
                            }
                           by cat.NombreCategoria
                            into g
                            select g;
            return resultado;

        }

        /// <summary>
        /// Relacion de Usuarios agrupados en categorias ordenadas éstas en orden descendente alfabéticamente 
        ///(un mismo puede aparecer  varias veces si esta en varias categorias)
        /// </summary>
        /// <returns> Lista agrupada de usuarios por categorias </returns>
        public IEnumerable<vmCategoriaNombre> AgrupacionUsuariosCategoriasOrdenadas()
        {
            var resultado = from cat in datos.Categorias
                            join usucat in datos.UsuariosCategorias on cat.Id equals usucat.CategoriaId
                            join usu in datos.Usuarios on usucat.UsuarioId equals usu.Id
                            orderby usu.NombreUsuario.ToUpper() descending
                            select new vmCategoriaNombre
                            {
                                Categoria = cat.NombreCategoria.ToUpper(),
                                Nombre = usu.NombreUsuario.ToUpper()
                            };

            return resultado;
        }



        // <summary>
        // Categoria con mayor numero de usuarios y total 
        // </summary>
        // <returns>Devuelve nombre de la categoria con más usurios y el numero de usuarios</returns>
        public IEnumerable<vmCategoriaNombre> CategoriaMaximoNumeroUsuarios()
        {
            var resultado = (from cat in datos.Categorias
                             join usucat in datos.UsuariosCategorias on cat.Id equals usucat.CategoriaId
                             group usucat.UsuarioId by cat.NombreCategoria into g
                             orderby g.Count() descending
                             select new vmCategoriaNombre
                             {
                                 Categoria = g.Key,
                                 Nombre = g.Count().ToString()
                             }).Take(1); // Tomamos solo el primer resultado, el de la categoría con mayor número de usuarios

            return resultado;
        }




        /// <summary>
        /// Todas las categorias de usuarios para una aplicación dada
        /// </summary>
        /// <param name="aplicacion"> nombre de la aplicación</param>
        /// <returns>Lista de los nombres de las categorias de usuarios</returns>
        public IEnumerable<vmCategoriaNombre> TodasCategoriasApp(string aplicacion)
        {
            var registro = (from apl in datos.Aplicaciones
                           join cat in datos.Categorias on apl.Id equals cat.AplicacionId
                           join usu in datos.Usuarios on apl.Id equals usu.AplicacionId
                           where apl.NombreAplicacion == aplicacion
                           select new vmCategoriaNombre {
                               Nombre = apl.NombreAplicacion,
                               Categoria = cat.NombreCategoria
                           }).Distinct();
            return registro;
        }



        /// <summary>
        /// Lista de Categoria/Aplicación  para un usuario dado 
        /// </summary>
        /// <param name="usuario">nombre del usuario</param>
        /// <returns>Lista de pares (nombre de categoria y nombre de aplicación)</returns>
        public IEnumerable<vmCategoriaNombre> CategoriasAplicacionParaUsuario(string usuario)
        {
            var registro = from usu in datos.Usuarios
                           join apl in datos.Aplicaciones on usu.AplicacionId equals apl.Id
                           join cat in datos.Categorias on apl.Id equals cat.AplicacionId
                           
                           where usu.NombreUsuario == usuario
                           select new vmCategoriaNombre { Categoria = cat.NombreCategoria, Nombre = apl.NombreAplicacion };
            return registro;
        }

    }
}