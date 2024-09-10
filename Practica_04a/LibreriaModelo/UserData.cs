namespace PSS.pgr866.Practica_04a
{
    public class UserData
    {
        public List<Usuario> Usuarios;
        public List<Personal> Personales;
        public List<Categoria> Categorias;
        public List<Aplicacion> Aplicaciones;
        public List<UsuarioCategoria> UsuariosCategorias;
        public List<Conexion> Conexiones;

        public void CargarDatos()
        {

            Usuarios = new List<Usuario>
            {
                new Usuario { Id = 1, NombreUsuario = "Diana", EsAnonimo = false,AplicacionId = 1},
                new Usuario { Id = 2, NombreUsuario = "Juan", EsAnonimo = false,AplicacionId=2},
                new Usuario { Id = 3, NombreUsuario = "Antonio", EsAnonimo = false,AplicacionId=1},
                new Usuario { Id = 4, NombreUsuario = "Ana", EsAnonimo = false,AplicacionId=1},
                new Usuario { Id = 5, NombreUsuario = "Jose", EsAnonimo = false,AplicacionId=3},
                new Usuario { Id = 6, NombreUsuario = "Julio", EsAnonimo = false,AplicacionId=2},
                new Usuario { Id = 7, NombreUsuario = "Mercedes",EsAnonimo = false,AplicacionId=2},
                new Usuario { Id = 8, NombreUsuario = "Anonimo",EsAnonimo = true,AplicacionId=2},
                new Usuario { Id = 9, NombreUsuario = "Jose", EsAnonimo = false,AplicacionId=2},
            };

            Personales = new List<Personal>
            {
                new Personal{Id = 1,UsuarioId=1,AplicacionId = 1,Password="pss-1",Email="",
                EstaBloqueado=false,FechaAlta =new DateTime(1980, 1, 9, 3, 0, 0) },
                new Personal{Id = 2,UsuarioId=2,AplicacionId = 2,Password="pss-2",Email="Juan.pss-2@ual.es",
                EstaBloqueado=false,FechaAlta =new DateTime(1979, 4, 6, 5, 0, 0) },
                new Personal{Id = 4,UsuarioId=3,AplicacionId = 1,Password="pss-3",Email="Antonio.pss-3@hotmail.es",
                EstaBloqueado=false,FechaAlta =new DateTime(1980, 2, 6, 7, 0, 0) },
                new Personal{Id = 5,UsuarioId=4,AplicacionId = 1,Password="pss-4",Email="",
                EstaBloqueado=false,FechaAlta =new DateTime(1982, 4, 7, 9, 0, 0) },
                new Personal{Id = 6,UsuarioId=5,AplicacionId = 3,Password="pss-5",Email="Jose.pss-5@ual.es",
                EstaBloqueado=false,FechaAlta =new DateTime(1960, 5, 5, 6, 0, 0) },
                new Personal{Id = 7,UsuarioId=6,AplicacionId = 2,Password="pss-6",Email="",
                EstaBloqueado=false,FechaAlta =new DateTime(1961, 3, 6, 8, 0, 0) },
                new Personal{Id = 8,UsuarioId=7,AplicacionId = 2,Password="pss-7",Email="",
                EstaBloqueado=false,FechaAlta =new DateTime(1962, 5, 2, 9, 0, 0) },
            };

            Categorias = new List<Categoria>
            {
                new Categoria{Id=1, NombreCategoria="Alumno",AplicacionId=1},
                new Categoria{Id=2, NombreCategoria="Alumno",AplicacionId=4},
                new Categoria{Id=3, NombreCategoria="Profesor",AplicacionId=1},
                new Categoria{Id=4, NombreCategoria="Profesor",AplicacionId=2},
                new Categoria{Id=5, NombreCategoria="Administrador",AplicacionId=3},
                new Categoria{Id=8, NombreCategoria="Invitado",AplicacionId=4}
            };

            Aplicaciones = new List<Aplicacion>
            {
                new Aplicacion{Id=1, NombreAplicacion="Word",Path=@"c:\word"},
                new Aplicacion{Id=2, NombreAplicacion="Excel",Path=@"c:\excel"},
                new Aplicacion{Id=3, NombreAplicacion="GestionUsuarios",Path=@"c:\gestionusuarios"},
                new Aplicacion{Id=4, NombreAplicacion="Explorer",Path=@"c:\explorer"}
            };

            UsuariosCategorias = new List<UsuarioCategoria>
            {
                new UsuarioCategoria{Id=1,CategoriaId=1,UsuarioId=1},
                new UsuarioCategoria{Id=2,CategoriaId=1,UsuarioId=2},
                new UsuarioCategoria{Id=3,CategoriaId=1,UsuarioId=3},
                new UsuarioCategoria{Id=4,CategoriaId=1,UsuarioId=4},
                new UsuarioCategoria{Id=5,CategoriaId=3,UsuarioId=5},
                new UsuarioCategoria{Id=8,CategoriaId=2,UsuarioId=6},
                new UsuarioCategoria{Id=10,CategoriaId=2,UsuarioId=7},
                new UsuarioCategoria{Id=14,CategoriaId=8,UsuarioId=8},
                new UsuarioCategoria{Id=16,CategoriaId=5,UsuarioId=9},
            };


            Conexiones = new List<Conexion>
            {
                new Conexion {Id=1,IP="192.168.134.23",FechaInicio=new DateTime(2012, 3, 21, 1, 40, 12),Duracion=1214,UsuarioCategoriaId=1},
                new Conexion {Id=3,IP="192.168.134.28",FechaInicio=new DateTime(2011, 4, 22, 2, 30, 22),Duracion=1874,UsuarioCategoriaId=1},
                new Conexion {Id=4,IP="192.168.134.28",FechaInicio=new DateTime(2011, 5, 23, 3, 20, 32),Duracion=167,UsuarioCategoriaId=1},

                new Conexion {Id=6,IP="192.168.134.123",FechaInicio=new DateTime(2011, 4, 20, 2, 50, 11),Duracion=114,UsuarioCategoriaId=2},
                new Conexion {Id=7,IP="192.168.134.128",FechaInicio=new DateTime(2011, 5, 24, 1, 10, 21),Duracion=1678,UsuarioCategoriaId=2},

                new Conexion {Id=8,IP="192.168.134.18",FechaInicio=new DateTime(2011, 3, 11, 0, 10, 2),Duracion=14,UsuarioCategoriaId=3},
                new Conexion {Id=9,IP="192.168.134.13",FechaInicio=new DateTime(2012, 4, 21, 1, 35, 12),Duracion=11,UsuarioCategoriaId=3},
                new Conexion {Id=10,IP="192.168.134.18",FechaInicio=new DateTime(2011, 5, 01, 0, 37, 22),Duracion=84,UsuarioCategoriaId=3},
                new Conexion {Id=11,IP="192.168.134.18",FechaInicio=new DateTime(2012, 5, 20, 1, 12, 32),Duracion=168,UsuarioCategoriaId=3},

                new Conexion {Id=12,IP="192.168.134.108",FechaInicio=new DateTime(2012, 1, 01, 1, 11, 12),Duracion=141,UsuarioCategoriaId=4},
                new Conexion {Id=14,IP="192.168.134.103",FechaInicio=new DateTime(2011, 2, 02, 1, 12, 02),Duracion=111,UsuarioCategoriaId=4},
                new Conexion {Id=16,IP="192.168.134.108",FechaInicio=new DateTime(2011, 3, 12, 2, 45, 51),Duracion=84,UsuarioCategoriaId=4},
                new Conexion {Id=17,IP="192.168.134.108",FechaInicio=new DateTime(2011, 5, 13, 1, 32, 22),Duracion=568,UsuarioCategoriaId=4},
                new Conexion {Id=18,IP="192.168.134.108",FechaInicio=new DateTime(2011, 5, 19, 0, 55, 33),Duracion=2,UsuarioCategoriaId=4},
                new Conexion {Id=19,IP="192.168.134.103",FechaInicio=new DateTime(2011, 6, 21, 1, 30, 44),Duracion=11,UsuarioCategoriaId=4},
                new Conexion {Id=20,IP="192.168.134.108",FechaInicio=new DateTime(2011, 7, 22, 0, 44, 55),Duracion=84,UsuarioCategoriaId=4},
                new Conexion {Id=21,IP="192.168.134.108",FechaInicio=new DateTime(2011, 9, 29, 1, 16, 03),Duracion=368,UsuarioCategoriaId=4},

                new Conexion {Id=22,IP="193.161.134.18",FechaInicio=new DateTime(2011, 3, 1, 2, 31, 57),Duracion=14,UsuarioCategoriaId=5},
                new Conexion {Id=24,IP="193.161.134.18",FechaInicio=new DateTime(2011, 5, 11, 4, 32, 56),Duracion=11,UsuarioCategoriaId=16},
                new Conexion {Id=27,IP="193.161.134.18",FechaInicio=new DateTime(2012, 1, 21, 6, 33, 55),Duracion=18,UsuarioCategoriaId=10},
                new Conexion {Id=28,IP="193.161.134.18",FechaInicio=new DateTime(2011, 6, 28, 8, 34, 54),Duracion=16,UsuarioCategoriaId=10},

                new Conexion {Id=31,IP="193.161.134.15",FechaInicio=new DateTime(2011, 2, 12, 18, 10, 25),Duracion=38,UsuarioCategoriaId=14},
                new Conexion {Id=32,IP="193.162.134.15",FechaInicio=new DateTime(2011, 5, 13, 18, 10, 27),Duracion=162,UsuarioCategoriaId=10}
            };

        }
    }

}