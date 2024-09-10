using PSS.pgr866.Practica_04b;
using System.Xml.Linq;

List<Visor> Visores = new List<Visor>
            {
                new Visor { Id = 1, NombreVisor = "Diana", EsAnonimo = false,PlataformaId = 1},
                new Visor { Id = 2, NombreVisor = "Juan", EsAnonimo = false,PlataformaId=2},
                new Visor { Id = 3, NombreVisor = "Antonio", EsAnonimo = false,PlataformaId=1},
                new Visor { Id = 4, NombreVisor = "Ana", EsAnonimo = false,PlataformaId=1},
                new Visor { Id = 5, NombreVisor = "Jose", EsAnonimo = false,PlataformaId=3},
                new Visor { Id = 6, NombreVisor = "Julio", EsAnonimo = false,PlataformaId=2},
                new Visor { Id = 7, NombreVisor = "Mercedes",EsAnonimo = false,PlataformaId=2},
                new Visor { Id = 8, NombreVisor = "Anonimo",EsAnonimo = true,PlataformaId=2},
                new Visor { Id = 9, NombreVisor = "Jose", EsAnonimo = false,PlataformaId=2},
            };

List<Cuenta> Cuentas = new List<Cuenta>
            {
                new Cuenta{Id = 1,VisorId=1,PlataformaId = 1,Password="pss-1",Email="",
                EstaBloqueado=false,FechaAlta =new DateTime(1980, 1, 9, 3, 0, 0) },
                new Cuenta{Id = 2,VisorId=2,PlataformaId = 2,Password="pss-2",Email="Juan.pss-2@ual.es",
                EstaBloqueado=false,FechaAlta =new DateTime(1979, 4, 6, 5, 0, 0) },
                new Cuenta{Id = 4,VisorId=3,PlataformaId = 1,Password="pss-3",Email="Antonio.pss-3@hotmail.es",
                EstaBloqueado=false,FechaAlta =new DateTime(1980, 2, 6, 7, 0, 0) },
                new Cuenta{Id = 5,VisorId=4,PlataformaId = 1,Password="pss-4",Email="",
                EstaBloqueado=false,FechaAlta =new DateTime(1982, 4, 7, 9, 0, 0) },
                new Cuenta{Id = 6,VisorId=5,PlataformaId = 3,Password="pss-5",Email="Jose.pss-5@ual.es",
                EstaBloqueado=false,FechaAlta =new DateTime(1960, 5, 5, 6, 0, 0) },
                new Cuenta{Id = 7,VisorId=6,PlataformaId = 2,Password="pss-6",Email="",
                EstaBloqueado=false,FechaAlta =new DateTime(1961, 3, 6, 8, 0, 0) },
                new Cuenta{Id = 8,VisorId=7,PlataformaId = 2,Password="pss-7",Email="",
                EstaBloqueado=false,FechaAlta =new DateTime(1962, 5, 2, 9, 0, 0) },
            };

List<Genero> Generos = new List<Genero>
            {
                new Genero{Id=1, NombreGenero="Terror",PlataformaId=1},
                new Genero{Id=2, NombreGenero="Terror",PlataformaId=4},
                new Genero{Id=3, NombreGenero="Comedia",PlataformaId=1},
                new Genero{Id=4, NombreGenero="Comedia",PlataformaId=2},
                new Genero{Id=5, NombreGenero="Accion",PlataformaId=3},
                new Genero{Id=8, NombreGenero="Drama",PlataformaId=4}
            };

List<Plataforma> Plataformas = new List<Plataforma>
            {
                new Plataforma{Id=1, NombrePlataforma="Netflix",Path=@"c:\netflix"},
                new Plataforma{Id=2, NombrePlataforma="Hbo",Path=@"c:\hbo"},
                new Plataforma{Id=3, NombrePlataforma="AmazonPrime",Path=@"c:\amazonprime"},
                new Plataforma{Id=4, NombrePlataforma="DisneyPlus",Path=@"c:\disneyplus"}
            };

List<VisorGenero> VisoresGeneros = new List<VisorGenero>
            {
                new VisorGenero{Id=1,GeneroId=1,VisorId=1},
                new VisorGenero{Id=2,GeneroId=1,VisorId=2},
                new VisorGenero{Id=3,GeneroId=1,VisorId=3},
                new VisorGenero{Id=4,GeneroId=1,VisorId=4},
                new VisorGenero{Id=5,GeneroId=3,VisorId=5},
                new VisorGenero{Id=8,GeneroId=2,VisorId=6},
                new VisorGenero{Id=10,GeneroId=2,VisorId=7},
                new VisorGenero{Id=14,GeneroId=8,VisorId=8},
                new VisorGenero{Id=16,GeneroId=5,VisorId=9},
            };


List<Visualizacion> Visualizaciones = new List<Visualizacion>
            {
                new Visualizacion {Id=1,IP="192.168.134.23",FechaInicio=new DateTime(2012, 3, 21, 1, 40, 12),Duracion=1214,VisorGeneroId=1},
                new Visualizacion {Id=3,IP="192.168.134.28",FechaInicio=new DateTime(2011, 4, 22, 2, 30, 22),Duracion=1874,VisorGeneroId=1},
                new Visualizacion {Id=4,IP="192.168.134.28",FechaInicio=new DateTime(2011, 5, 23, 3, 20, 32),Duracion=167,VisorGeneroId=1},

                new Visualizacion {Id=6,IP="192.168.134.123",FechaInicio=new DateTime(2011, 4, 20, 2, 50, 11),Duracion=114,VisorGeneroId=2},
                new Visualizacion {Id=7,IP="192.168.134.128",FechaInicio=new DateTime(2011, 5, 24, 1, 10, 21),Duracion=1678,VisorGeneroId=2},

                new Visualizacion {Id=8,IP="192.168.134.18",FechaInicio=new DateTime(2011, 3, 11, 0, 10, 2),Duracion=14,VisorGeneroId=3},
                new Visualizacion {Id=9,IP="192.168.134.13",FechaInicio=new DateTime(2012, 4, 21, 1, 35, 12),Duracion=11,VisorGeneroId=3},
                new Visualizacion {Id=10,IP="192.168.134.18",FechaInicio=new DateTime(2011, 5, 01, 0, 37, 22),Duracion=84,VisorGeneroId=3},
                new Visualizacion {Id=11,IP="192.168.134.18",FechaInicio=new DateTime(2012, 5, 20, 1, 12, 32),Duracion=168,VisorGeneroId=3},

                new Visualizacion {Id=12,IP="192.168.134.108",FechaInicio=new DateTime(2012, 1, 01, 1, 11, 12),Duracion=141,VisorGeneroId=4},
                new Visualizacion {Id=14,IP="192.168.134.103",FechaInicio=new DateTime(2011, 2, 02, 1, 12, 02),Duracion=111,VisorGeneroId=4},
                new Visualizacion {Id=16,IP="192.168.134.108",FechaInicio=new DateTime(2011, 3, 12, 2, 45, 51),Duracion=84,VisorGeneroId=4},
                new Visualizacion {Id=17,IP="192.168.134.108",FechaInicio=new DateTime(2011, 5, 13, 1, 32, 22),Duracion=568,VisorGeneroId=4},
                new Visualizacion {Id=18,IP="192.168.134.108",FechaInicio=new DateTime(2011, 5, 19, 0, 55, 33),Duracion=2,VisorGeneroId=4},
                new Visualizacion {Id=19,IP="192.168.134.103",FechaInicio=new DateTime(2011, 6, 21, 1, 30, 44),Duracion=11,VisorGeneroId=4},
                new Visualizacion {Id=20,IP="192.168.134.108",FechaInicio=new DateTime(2011, 7, 22, 0, 44, 55),Duracion=84,VisorGeneroId=4},
                new Visualizacion {Id=21,IP="192.168.134.108",FechaInicio=new DateTime(2011, 9, 29, 1, 16, 03),Duracion=368,VisorGeneroId=4},

                new Visualizacion {Id=22,IP="193.161.134.18",FechaInicio=new DateTime(2011, 3, 1, 2, 31, 57),Duracion=14,VisorGeneroId=5},
                new Visualizacion {Id=24,IP="193.161.134.18",FechaInicio=new DateTime(2011, 5, 11, 4, 32, 56),Duracion=11,VisorGeneroId=16},
                new Visualizacion {Id=27,IP="193.161.134.18",FechaInicio=new DateTime(2012, 1, 21, 6, 33, 55),Duracion=18,VisorGeneroId=10},
                new Visualizacion {Id=28,IP="193.161.134.18",FechaInicio=new DateTime(2011, 6, 28, 8, 34, 54),Duracion=16,VisorGeneroId=10},

                new Visualizacion {Id=31,IP="193.161.134.15",FechaInicio=new DateTime(2011, 2, 12, 18, 10, 25),Duracion=38,VisorGeneroId=14},
                new Visualizacion {Id=32,IP="193.162.134.15",FechaInicio=new DateTime(2011, 5, 13, 18, 10, 27),Duracion=162,VisorGeneroId=10}
            };


// Crear el documento XML y agregar las tablas
XDocument datos = new XDocument(new XElement("Datos",

new XElement("Visores",
            from vis in Visores
            select new XElement("Visor",
                new XElement("Id", vis.Id),
                new XElement("NombreVisor", vis.NombreVisor),
                new XElement("EsAnonimo", vis.EsAnonimo),
                new XElement("PlataformaId", vis.PlataformaId)
            )
        ),

new XElement("Cuentas",
            from cue in Cuentas
            select new XElement("Cuenta",
                new XElement("Id", cue.Id),
                new XElement("VisorId", cue.VisorId),
                new XElement("PlataformaId", cue.PlataformaId),
                new XElement("Password", cue.Password),
                new XElement("Email", cue.Email),
                new XElement("EstaBloqueado", cue.EstaBloqueado),
                new XElement("FechaAlta", cue.FechaAlta)
            )
        ),

new XElement("Generos",
            from gen in Generos
            select new XElement("Genero",
                new XElement("Id", gen.Id),
                new XElement("NombreGenero", gen.NombreGenero),
                new XElement("PlataformaId", gen.PlataformaId)
            )
        ),

new XElement("Plataformas",
            from plat in Plataformas
            select new XElement("Plataforma",
                new XElement("Id", plat.Id),
                new XElement("NombrePlataforma", plat.NombrePlataforma),
                new XElement("Path", plat.Path)
            )
        ),

new XElement("VisoresGeneros",
            from visgen in VisoresGeneros
            select new XElement("VisorGenero",
                new XElement("Id", visgen.Id),
                new XElement("GeneroId", visgen.GeneroId),
                new XElement("VisorId", visgen.VisorId)
            )
        ),

new XElement("Visualizaciones",
            from visu in Visualizaciones
            select new XElement("Visualizacion",
                new XElement("Id", visu.Id),
                new XElement("IP", visu.IP),
                new XElement("FechaInicio", visu.FechaInicio),
                new XElement("Duracion", visu.Duracion),
                new XElement("VisorGeneroId", visu.VisorGeneroId)
            )
        )
    )
);

// Guardar el documento XML en un archivo
datos.Save(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.Parent.FullName + "\\LibreriaConsultas\\Datos.xml");
