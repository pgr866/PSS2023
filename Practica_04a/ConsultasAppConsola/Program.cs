using PSS.pgr866.Practica_04a;
using System;
using System.Data;
using System.Resources;

int opcion;

//Mientras que la opcion sea distinta a 0 ejecutame el MainMenu

while (true)
{
    switch (MainMenu())
    {
        case 1:
            OpcionConsultasUsuarios();
            break;
        case 2:
            OpcionConsultasCategorias();
            break;
        case 3:
            OpcionConsultasAgrupaciones();
            break;
    }
}

static int MainMenu()
{
    Console.Clear();
    Console.WriteLine("Menu Principal\n");
    Console.WriteLine("1) ConsultasUsuarios");
    Console.WriteLine("2) ConsultasCategorias");
    Console.WriteLine("3) ConsultasAgrupaciones");
    Console.Write("Selecciona la opción que desee: ");
    int opcion = Int32.Parse(Console.ReadLine());
    Console.Clear();
    return opcion;
}

/* Metodos para las ConsultasUsuarios */
static void OpcionConsultasUsuarios()
{
    switch (MenuConsultasUsuarios())
    {
        case 1:
            PrimeraOpcionUsuarios();
            break;
        case 2:
            SegundaOpcionUsuarios();
            break;
        case 3:
            TerceraOpcionUsuarios();
            break;
        case 4:
            CuartaOpcionUsuarios();
            break;
        case 5:
            QuintaOpcionUsuarios();
            break;
        case 6:
            SextaOpcionUsuarios();
            break;
    }
    Console.ReadLine();
}


static int MenuConsultasUsuarios()
{
    Console.WriteLine("Menu ConsultasUsuarios\n");
    Console.WriteLine("1) Usuarios dado el CategoriaId");
    Console.WriteLine("2) Usuarios dado el CategoriaNombre");
    Console.WriteLine("3) Usuarios UsuarioNombre comienza");
    Console.WriteLine("4) Usuarios UsuarioNombre comienza en CategoriaNombre");
    Console.WriteLine("5) Usuarios dado el ConexionIP");
    Console.WriteLine("6) Encontrar Usuario Aplicacion-Email");
    Console.Write("Selecciona la opcion que desee: ");
    return Int32.Parse(Console.ReadLine());
}


static void PrimeraOpcionUsuarios()
{
    int idCat;
    ConsultasUsuarios consulta = new ConsultasUsuarios();
    IEnumerable<vmNombre> resultado;
    Console.Write("Id Categoria: ");
    idCat = Int32.Parse(Console.ReadLine());
    resultado = consulta.UsuariosEnCategoria(idCat);
    ImprimirUsuarios(resultado);
}

static void SegundaOpcionUsuarios()
{
    string nombreCat;
    ConsultasUsuarios consulta = new ConsultasUsuarios();
    IEnumerable<vmNombre> resultado;
    Console.Write("Nombre de la categoria: ");
    nombreCat = Console.ReadLine();
    resultado = consulta.UsuariosEnCategoria(nombreCat);
    ImprimirUsuarios(resultado);

}

static void TerceraOpcionUsuarios()
{
    string cadena;
    ConsultasUsuarios consulta = new ConsultasUsuarios();
    IEnumerable<vmNombre> resultado;
    Console.Write("Cadena de comienzo del nombre: ");
    cadena = Console.ReadLine();
    resultado = consulta.UsuariosConNombreComienza(cadena);
    ImprimirUsuarios(resultado);

}

static void CuartaOpcionUsuarios()
{
    string cadena, categoria;
    ConsultasUsuarios consulta = new ConsultasUsuarios();
    IEnumerable<vmNombre> resultado;
    Console.Write("Cadena de comienzo del nombre: ");
    cadena = Console.ReadLine();
    Console.Write("Nombre de la categoria: ");
    categoria = Console.ReadLine();
    resultado = consulta.UsuariosConNombreComienzaEnCategoria(cadena, categoria);
    ImprimirUsuarios(resultado);
}

static void QuintaOpcionUsuarios()
{
    string ip;
    ConsultasUsuarios consulta = new ConsultasUsuarios();
    IEnumerable<vmNombre> resultado;
    Console.Write("IP: ");
    ip = Console.ReadLine();
    resultado = consulta.UsuariosConectadosIP(ip);
    ImprimirUsuarios(resultado);
}

static void SextaOpcionUsuarios()
{
    string aplicacion, email;
    ConsultasUsuarios consulta = new ConsultasUsuarios();
    IEnumerable<vmNombre> resultado;
    Console.Write("Nombre aplicacion: ");
    aplicacion = Console.ReadLine();
    Console.Write("Email: ");
    email = Console.ReadLine();
    resultado = consulta.EncontrarUsuarioAppEmail(aplicacion, email);
    ImprimirUsuarios(resultado);
}


/* Metodos para las ConsultasCategorias */
static void OpcionConsultasCategorias()
{
    switch (MenuConsultasCategorias())
    {
        case 1:
            PrimeraOpcionCategorias();
            break;
        case 2:
            SegundaOpcionCategorias();
            break;
        case 3:
            TerceraOpcionCategorias();
            break;
        case 4:
            CuartaOpcionCategorias();
            break;
        case 5:
            QuintaOpcionCategorias();
            break;
        case 6:
            SextaOpcionCategorias();
            break;
    }
    Console.ReadLine();
}

static int MenuConsultasCategorias()
{
    Console.WriteLine("Menu ConsultasCategorias\n");
    Console.WriteLine("1) Lista Categoria/Usuario (nombre App)");
    Console.WriteLine("2) Agrupacion Categoria/Usuario");
    Console.WriteLine("3) Agrupacion Categoria/Usuario Ordenadas");
    Console.WriteLine("4) Categoria Maximo Numero Usuarios");
    Console.WriteLine("5) Todas Categorias (Aplicacion)");
    Console.WriteLine("6) Categorias Aplicacion (Usuario)");
    Console.Write("Selecciona la opcion que desee: ");
    return Int32.Parse(Console.ReadLine());
}

static void PrimeraOpcionCategorias()
{
    string aplicacion;
    ConsultasCategorias consulta = new ConsultasCategorias();
    IEnumerable<vmCategoriaNombre> resultado;
    Console.Write("Nombre aplicacion: ");
    aplicacion = Console.ReadLine();
    resultado = consulta.ListaParCategoriaUsuarioParaApp(aplicacion);
    ImprimirCategoriaYUsuario(resultado);
}

static void SegundaOpcionCategorias()
{
    ConsultasCategorias consulta = new ConsultasCategorias();
    IEnumerable<IGrouping<string, vmCategoriaNombre>> resultado;
    resultado = consulta.AgrupacionUsuariosCategorias();
    ImprimirCategoriaYUsuarioGrouping(resultado);
}

static void TerceraOpcionCategorias()
{
    ConsultasCategorias consulta = new ConsultasCategorias();
    IEnumerable<vmCategoriaNombre> resultado;
    resultado = consulta.AgrupacionUsuariosCategoriasOrdenadas();
    ImprimirCategoriaYUsuario(resultado);
}

static void CuartaOpcionCategorias()
{
    ConsultasCategorias consulta = new ConsultasCategorias();
    IEnumerable<vmCategoriaNombre> resultado;
    resultado = consulta.CategoriaMaximoNumeroUsuarios();
    ImprimirCategoriaYUsuario(resultado);
}

static void QuintaOpcionCategorias()
{
    string aplicacion;
    ConsultasCategorias consulta = new ConsultasCategorias();
    IEnumerable<vmCategoriaNombre> resultado;
    Console.Write("Dime la aplicacion: ");
    aplicacion = Console.ReadLine();
    resultado = consulta.TodasCategoriasApp(aplicacion);
    ImprimirCategoriaYUsuario(resultado);
}

static void SextaOpcionCategorias()
{
    string usuario;
    ConsultasCategorias consulta = new ConsultasCategorias();
    IEnumerable<vmCategoriaNombre> resultado;
    Console.Write("Dime el usuario: ");
    usuario = Console.ReadLine();
    resultado = consulta.CategoriasAplicacionParaUsuario(usuario);
    ImprimirCategoriaYAplicacion(resultado);
}

/* Metodos para las ConsultasAgrupaciones */
static void OpcionConsultasAgrupaciones()
{
    switch (MenuConsultasAgrupaciones())
    {
        case 1:
            PrimeraOpcionAgrupaciones();
            break;
        case 2:
            SegundaOpcionAgrupaciones();
            break;
        case 3:
            TerceraOpcionAgrupaciones();
            break;
        case 4:
            CuartaOpcionAgrupaciones();
            break;
        case 5:
            QuintaOpcionAgrupaciones();
            break;
        case 6:
            SextaOpcionAgrupaciones();
            break;
    }
    Console.ReadLine();
}

static int MenuConsultasAgrupaciones()
{
    Console.WriteLine("Menu ConsultasAgrupaciones\n");
    Console.WriteLine("1) IP ha habido más conexiones y cuantas");
    Console.WriteLine("2) Lista de pares NombreUsuario, suma de la duración de las conexiones");
    Console.WriteLine("3) Usuarios, suma total de duración de conexiones");
    Console.WriteLine("4) Usuarios cuya suma total de duración de conexión sea superior a la media");
    Console.WriteLine("5) Aplicaciones y su suma de tiempos de conexión de todos los usuarios ");
    Console.WriteLine("6) Aplicaciones y su suma de tiempos de conexión de todos los usuarios(ordenas de mayor a menor)");
    Console.Write("Selecciona la opcion que desee: ");
    return Int32.Parse(Console.ReadLine());
}

static void PrimeraOpcionAgrupaciones()
{
    string nombreCat;
    ConsultasAgrupaciones consulta = new ConsultasAgrupaciones();
    IEnumerable<vmNombreCantidad> resultado;
    Console.Write("Dime la categoria: ");
    nombreCat = Console.ReadLine();
    resultado = consulta.IPconMasConexionesSegunCategoria(nombreCat);
    ImprimirCategoriaYAplicacionAgrupaciones(resultado);
}

static void SegundaOpcionAgrupaciones()
{
    ConsultasAgrupaciones consulta = new ConsultasAgrupaciones();
    IEnumerable<vmNombreCantidad> resultado;
    resultado = consulta.UsuarioSumaDuracionConexiones();
    ImprimirCategoriaYAplicacionAgrupaciones(resultado);
}

static void TerceraOpcionAgrupaciones()
{
    ConsultasAgrupaciones consulta = new ConsultasAgrupaciones();
    IEnumerable<vmNombreCantidad> resultado;
    resultado = consulta.UsuarioSumaDuracionConexionesNulos();
    ImprimirCategoriaYAplicacionAgrupaciones(resultado);
}

static void CuartaOpcionAgrupaciones()
{
    ConsultasAgrupaciones consulta = new ConsultasAgrupaciones();
    IEnumerable<vmNombreCantidad> resultado;
    resultado = consulta.UsuariosSumaDuracionMayorMedia();
    ImprimirCategoriaYAplicacionAgrupaciones(resultado);
}

static void QuintaOpcionAgrupaciones()
{
    ConsultasAgrupaciones consulta = new ConsultasAgrupaciones();
    IEnumerable<vmNombreCantidad> resultado;
    resultado = consulta.AplicacionesMasUsadas();
    ImprimirCategoriaYAplicacionAgrupaciones(resultado);
}

static void SextaOpcionAgrupaciones()
{
    ConsultasAgrupaciones consulta = new ConsultasAgrupaciones();
    IEnumerable<vmNombreCantidad> resultado;
    resultado = consulta.AplicacionesMasUsadasOrdenadas();
    ImprimirCategoriaYAplicacionAgrupaciones(resultado);
}

static void ImprimirUsuarios(IEnumerable<vmNombre> result)
{
    Console.WriteLine();
    foreach (vmNombre x in result)
    {
        Console.WriteLine(x.Nombre); //Asi visualizamos la propiedad Nombre de x
    }
}

static void ImprimirCategoria(IEnumerable<vmCategoriaNombre> result)
{
    Console.WriteLine();
    foreach (vmCategoriaNombre x in result)
    {
        Console.WriteLine(x.Categoria); //Asi visualizamos la propiedad Categoria de x
    }
}

static void ImprimirCategoriaYUsuario(IEnumerable<vmCategoriaNombre> result)
{
    Console.WriteLine();
    foreach (vmCategoriaNombre x in result)
    {
        Console.WriteLine(x.Categoria + " " + x.Nombre); //Asi visualizamos las propiedades Categoria y Nombre de x
    }
}

static void ImprimirCategoriaYUsuarioGrouping(IEnumerable<IGrouping<string, vmCategoriaNombre>> result)
{
    Console.WriteLine();
    foreach (IGrouping<string, vmCategoriaNombre> x in result)
    {
        foreach (vmCategoriaNombre entrada in x)
        {
            Console.WriteLine(entrada.Categoria + " " + entrada.Nombre);
        }
    }
}

static void ImprimirCategoriaYAplicacion(IEnumerable<vmCategoriaNombre> result)
{
    Console.WriteLine();
    foreach (vmCategoriaNombre x in result)
    {
        Console.WriteLine(x.Categoria + " " + x.Nombre);
    }
}

static void ImprimirCategoriaYAplicacionAgrupaciones(IEnumerable<vmNombreCantidad> result)
{
    Console.WriteLine();
    foreach (vmNombreCantidad cantidad in result)
    {
        Console.WriteLine(cantidad.Nombre + " " + cantidad.Cantidad);
    }
}
