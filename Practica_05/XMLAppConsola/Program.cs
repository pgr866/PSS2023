using System.Configuration;

namespace PSS.pgr866.Practica_05
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string id, palabrapaso, nombre, categoria;
            bool esvalido;
            IUsuarioView usu;
            IAutentificacion aut = null;
            int tipo, opcion;

            // Voy a pedirle al usuario el tipo de datos que voy a utilizar
            do
            {
                Console.WriteLine("Tipo de origen:\n1) Fichero de Texto\n2) sqlserver\n3) Fichero xml");
                Console.Write("Introduce opcion: ");
                tipo = Int32.Parse(Console.ReadLine());
            } while (tipo < 1 || tipo > 3);
            switch (tipo)
            {
                case 1:
                    var conexionTxt = ConfigurationManager.AppSettings["conexionTxt"];
                    aut = CrearAutentificacionTextFile(conexionTxt);
                    break;
                case 2:
                    var conexionSql = ConfigurationManager.AppSettings["conexionSql"];
                    aut = CrearAutentificacionSql(conexionSql);
                    break;
                case 3:
                    var conexionXml = ConfigurationManager.AppSettings["conexionXml"];
                    aut = CrearAutentificacionXml(conexionXml);
                    break;
            }

            try
            {
                Console.Write("Introduce Id del usuario: ");
                id = Console.ReadLine();
                Console.Write("\nIntroduce palabra de paso: ");
                palabrapaso = Console.ReadLine();

                CodigoAutentificacion codigo = aut.EsUsuarioAutentificado(id, palabrapaso);
                if (codigo != CodigoAutentificacion.AccesoCorrecto)
                    throw new AutentificacionExcepcion("Error", codigo);
                usu = aut.ObtenerUsuario(id);
                Console.WriteLine("\n\nBienvenido: " + usu.Nombre);


                do
                {
                    Console.WriteLine("\n1. Consultar un usuario");
                    Console.WriteLine("2. Guardar datos");
                    Console.WriteLine("3. Insertar usuario");
                    Console.WriteLine("4. Modificar usuario");
                    Console.WriteLine("5. Eliminar usuario");
                    Console.WriteLine("6. Prueba");
                    Console.WriteLine("0. Salir");
                    Console.Write("Introduce opcion: ");
                    opcion = Int32.Parse(Console.ReadLine());
                    switch (opcion)
                    {
                        case 1:
                            Console.Write("Introduce Id del usuario a consultar: ");
                            id = Console.ReadLine();
                            usu = aut.ObtenerUsuario(id);
                            if (usu == null)
                                Console.WriteLine("Ese usuario no se encuentra");
                            else
                                Console.WriteLine("El usuario es:\n" + usu);
                            break;
                        case 2:
                            aut.GuardarDatos();
                            break;
                        case 3:
                            Console.Write("Introduce Id del usuario a insertar: ");
                            id = Console.ReadLine();
                            Console.Write("Introduce nombre del usuario a insertar: ");
                            nombre = Console.ReadLine();
                            Console.Write("Introduce categoria del usuario a insertar: ");
                            categoria = Console.ReadLine();
                            Console.Write("Introduce palabra de paso del usuario a insertar: ");
                            palabrapaso = Console.ReadLine();
                            Console.Write("Introduce si es valido el usuario a insertar (true, false): ");
                            esvalido = Boolean.Parse(Console.ReadLine());
                            usu = new UsuarioView(Int32.Parse(id), nombre, palabrapaso, categoria, esvalido);
                            if (aut.InsertarUsuario(usu))
                                Console.WriteLine("Usuario insertado con exito");
                            else
                                Console.WriteLine("Ese usuario no se pudo insertar");
                            break;
                        case 4:
                            Console.Write("Introduce Id del usuario a modificar: ");
                            id = Console.ReadLine();
                            Console.Write("Introduce nuevo nombre: ");
                            nombre = Console.ReadLine();
                            Console.Write("Introduce nueva categoria: ");
                            categoria = Console.ReadLine();
                            Console.Write("Introduce nueva palabra de paso: ");
                            palabrapaso = Console.ReadLine();
                            Console.Write("Introduce si es valido el usuario a insertar (true, false): ");
                            esvalido = Boolean.Parse(Console.ReadLine());
                            usu = new UsuarioView(Int32.Parse(id), nombre, palabrapaso, categoria, esvalido);
                            if (aut.ModificarUsuario(id, usu))
                                Console.WriteLine("Usuario modificado con exito");
                            else
                                Console.WriteLine("Ese usuario no se pudo modificar");
                            break;
                        case 5:
                            Console.Write("Introduce Id del usuario a borrar: ");
                            id = Console.ReadLine();
                            if (aut.EliminarUsuario(id))
                                Console.WriteLine("Usuario eliminado con exito");
                            else
                                Console.WriteLine("Ese usuario no se puede eliminar");
                            break;
                        case 6:
                            aut.Listado();
                            break;
                        case 0:
                            Console.WriteLine("Fin del programa");
                            break;
                        default:
                            Console.WriteLine("Opcion no valida");
                            break;
                    }
                } while (opcion != 0);


            }
            catch (AutentificacionExcepcion e)
            {
                Console.WriteLine(e.Message);
            }


            Console.WriteLine("\n\nPulsa ENTER para finalizar...");
            Console.ReadLine();
        }

        public static IAutentificacion CrearAutentificacionTextFile(string conexion)
        {
            string[] a = conexion.Split(',');
            string nombreFichero = a[1].Substring(a[1].IndexOf("=") + 1);
            string finCampo = a[2].Substring(a[2].IndexOf("=") + 1);
            string cadena = a[3].Substring(a[3].IndexOf("="));
            string[] b = cadena.Split(finCampo.ToCharArray());
            CamposRegistro[] campos = new CamposRegistro[b.Length];
            for (int i = 0; i < campos.Length; i++)
            {
                switch (b[i])
                {
                    case "Id": campos[i] = CamposRegistro.Id; break;
                    case "Nombre": campos[i] = CamposRegistro.Nombre; break;
                    case "PalabraPaso": campos[i] = CamposRegistro.PalabraPaso; break;
                    case "Categoria": campos[i] = CamposRegistro.Categoria; break;
                    case "EsValido": campos[i] = CamposRegistro.EsValido; break;
                }
            }
            FormatoRegistro formato = new FormatoRegistro(campos);
            return new AutentificacionTextFile(nombreFichero, formato, finCampo);
        }

        public static IAutentificacion CrearAutentificacionSql(string conexion)
        {
            string cadena = conexion.Substring(conexion.IndexOf(",") + 1);
            return new AutentificacionSqlServerFile(cadena);
        }

        public static IAutentificacion CrearAutentificacionXml(string conexion)
        {
            string[] a = conexion.Split(',');
            string nombreFichero = a[1].Substring(a[1].IndexOf("=") + 1);
            return new AutentificacionXml(nombreFichero);
        }
    }
}

