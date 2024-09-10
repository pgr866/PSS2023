using System.Linq;
using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PSS.pgr866.Practica_04a
{
    public class ConsultasAgrupaciones
    {
        private UserData datos;

        //Constructor donde cargamos los datos llamando a un metodo de la clase UserData
        public ConsultasAgrupaciones()
        {
            datos = new UserData();
            datos.CargarDatos();
        }

        //**********   Agrupaciones ***************
        /// <summary>
        /// ¿Desde que IP ha habido más conexiones y cuantas para una categoria dada? 
        /// </summary>
        /// <returns>Lista con la IP y el número de conexiones</returns>
        public IEnumerable<vmNombreCantidad> IPconMasConexionesSegunCategoria(string nombreCategoria)
        {
            var resultado = (from usucat in datos.UsuariosCategorias
                             join cat in datos.Categorias on usucat.CategoriaId equals cat.Id
                             join con in datos.Conexiones on usucat.Id equals con.UsuarioCategoriaId
                             where cat.NombreCategoria == nombreCategoria
                             group usucat.UsuarioId by con.IP into g
                             orderby g.Count() descending
                             select new vmNombreCantidad
                             {
                                 Nombre = g.Key,
                                 Cantidad = g.Count()
                             }).Take(1); // Tomamos solo el primer resultado, el de la categoría con mayor número de usuarios
            return resultado;
        }



        /// <summary>
        /// Secuencia de pares (usuarios, suma total duración de conexion) ordenados de mayor a menor duración
        /// </summary>

        /// <returns>Lista de pares NombreUsuario, suma de la duración de las conexiones</returns>
        public IEnumerable<vmNombreCantidad> UsuarioSumaDuracionConexiones()
        {
            var resultado =  from usu in datos.Usuarios
                             join usucat in datos.UsuariosCategorias on usu.Id equals usucat.UsuarioId
                             join con in datos.Conexiones on usucat.Id equals con.UsuarioCategoriaId
                             group con.Duracion by usu into g
                             orderby g.Sum() descending
                             select new vmNombreCantidad
                             {
                                 Nombre = g.Key.NombreUsuario,
                                 Cantidad = (double?)g.Sum() ?? 0
                             };
            return resultado;
        }





        /// <summary>
        /// LEFT OUTER JOIN
        /// Secuencia de pares (usuarios, suma total de duración de conexiones) ordenados de menor a mayor duración 
        /// Usuarios que no se hayan conectado nunca deberán aparecer con una cantidad de 0
        /// </summary>

        /// <returns>Lista de pares NombreUsuario, total suma de duración de conexiones</returns>
        public IEnumerable<vmNombreCantidad> UsuarioSumaDuracionConexionesNulos()
        {
            var resultado = from usu in datos.Usuarios
                            join usucat in datos.UsuariosCategorias on usu.Id equals usucat.UsuarioId
                            join con in datos.Conexiones on usucat.Id equals con.UsuarioCategoriaId into resul
                            from r in resul.DefaultIfEmpty()
                            group (r == null ? 0 : r.Duracion) by usu into g
                            orderby g.Sum() descending
                            select new vmNombreCantidad
                            {
                                Nombre = g.Key.NombreUsuario,
                                Cantidad = g.Sum()
                            };

            return resultado;
        }





        /// <summary>
        /// LEFT OUTER JOIN
        /// Relacion de usuarios cuya suma total de duración de conexión sea superior a la media. 
        /// </summary>
        /// <returns>Lista con el nombre de usuario y suma total de duracion de conexiones</returns>
        public IEnumerable<vmNombreCantidad> UsuariosSumaDuracionMayorMedia()
        {
            var resultado = from usu in datos.Usuarios
                            join usucat in datos.UsuariosCategorias on usu.Id equals usucat.UsuarioId
                            join con in datos.Conexiones on usucat.Id equals con.UsuarioCategoriaId into resul
                            from r in resul.DefaultIfEmpty()
                            group (r == null ? 0 : r.Duracion) by usu into g
                            orderby g.Sum()
                            select new vmNombreCantidad
                            {
                                Nombre = g.Key.NombreUsuario,
                                Cantidad = g.Sum()
                            };

            double media = resultado.Average(e => e.Cantidad);
            var resultado2 = resultado.Where(e => e.Cantidad > media);

            return resultado2;
        }





        /// <summary>
        /// Relacion de aplicaciones y su respectiva suma de tiempos de conexión de todos los usuarios 
        /// </summary>
        /// <returns>Lista con el nombre de aplicacion y  suma total de duracion de conexiones</returns>
        public IEnumerable<vmNombreCantidad> AplicacionesMasUsadas()
        {
            var resultado = from apl in datos.Aplicaciones
                            join usu in datos.Usuarios on apl.Id equals usu.AplicacionId
                            join usucat in datos.UsuariosCategorias on usu.Id equals usucat.UsuarioId
                            join con in datos.Conexiones on usucat.Id equals con.UsuarioCategoriaId
                            group con.Duracion by apl into g
                            orderby g.Sum()
                            select new vmNombreCantidad
                            {
                                Nombre = g.Key.NombreAplicacion,
                                Cantidad = (double?)g.Sum() ?? 0
                            };
            return resultado;
        }

        /// <summary>
        /// Relacion de aplicaciones y su respectiva suma de tiempos de conexión de todos los usuarios (ordenas de mayor a menor) 
        /// </summary>
        /// <returns>Lista con el nombre de aplicacion y  suma total de duracion de conexiones</returns>
        public IEnumerable<vmNombreCantidad> AplicacionesMasUsadasOrdenadas()
        {
            var resultado = from apl in datos.Aplicaciones
                            join usu in datos.Usuarios on apl.Id equals usu.AplicacionId
                            join usucat in datos.UsuariosCategorias on usu.Id equals usucat.UsuarioId
                            join con in datos.Conexiones on usucat.Id equals con.UsuarioCategoriaId
                            group con.Duracion by apl into g
                            orderby g.Sum() descending
                            select new vmNombreCantidad
                            {
                                Nombre = g.Key.NombreAplicacion,
                                Cantidad = (double?)g.Sum() ?? 0
                            };
            return resultado;
        }

    }
}