using PSS.pgr866.Practica_04b;
using System;
using System.Data;
using System.Resources;

//Mientras que la opcion sea distinta a 0 ejecutame el MainMenu

while (true)
{
    switch (MainMenu())
    {
        case 1:
            OpcionConsultasVisores();
            break;
        case 2:
            OpcionConsultasGeneros();
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
    Console.WriteLine("1) ConsultasVisores");
    Console.WriteLine("2) ConsultasGeneros");
    Console.WriteLine("3) ConsultasAgrupaciones");
    Console.Write("Selecciona la opción que desee: ");
    int opcion = Int32.Parse(Console.ReadLine());
    Console.Clear();
    return opcion;
}

/* Metodos para las ConsultasVisores */
static void OpcionConsultasVisores()
{
    switch (MenuConsultasVisores())
    {
        case 1:
            PrimeraOpcionVisores();
            break;
        case 2:
            SegundaOpcionVisores();
            break;
        case 3:
            TerceraOpcionVisores();
            break;
        case 4:
            CuartaOpcionVisores();
            break;
        case 5:
            QuintaOpcionVisores();
            break;
        case 6:
            SextaOpcionVisores();
            break;
    }
    Console.ReadLine();
}


static int MenuConsultasVisores()
{
    Console.WriteLine("Menu ConsultasVisores\n");
    Console.WriteLine("1) Visores dado el GeneroId");
    Console.WriteLine("2) Visores dado el GeneroNombre");
    Console.WriteLine("3) Visores VisorNombre comienza");
    Console.WriteLine("4) Visores VisorNombre comienza en GeneroNombre");
    Console.WriteLine("5) Visores dado el VisualizacionIP");
    Console.WriteLine("6) Encontrar Visor Plataforma-Email");
    Console.Write("Selecciona la opcion que desee: ");
    return Int32.Parse(Console.ReadLine());
}


static void PrimeraOpcionVisores()
{
    int idGen;
    ConsultasVisores consulta = new ConsultasVisores();
    IEnumerable<vmNombre> resultado;
    Console.Write("Id Genero: ");
    idGen = Int32.Parse(Console.ReadLine());
    resultado = consulta.VisoresEnGenero(idGen);
    ImprimirVisores(resultado);
}

static void SegundaOpcionVisores()
{
    string nombreGen;
    ConsultasVisores consulta = new ConsultasVisores();
    IEnumerable<vmNombre> resultado;
    Console.Write("Nombre del genero: ");
    nombreGen = Console.ReadLine();
    resultado = consulta.VisoresEnGenero(nombreGen);
    ImprimirVisores(resultado);

}

static void TerceraOpcionVisores()
{
    string cadena;
    ConsultasVisores consulta = new ConsultasVisores();
    IEnumerable<vmNombre> resultado;
    Console.Write("Cadena de comienzo del nombre: ");
    cadena = Console.ReadLine();
    resultado = consulta.VisoresConNombreComienza(cadena);
    ImprimirVisores(resultado);

}

static void CuartaOpcionVisores()
{
    string cadena, genero;
    ConsultasVisores consulta = new ConsultasVisores();
    IEnumerable<vmNombre> resultado;
    Console.Write("Cadena de comienzo del nombre: ");
    cadena = Console.ReadLine();
    Console.Write("Nombre de el genero: ");
    genero = Console.ReadLine();
    resultado = consulta.VisoresConNombreComienzaEnGenero(cadena, genero);
    ImprimirVisores(resultado);
}

static void QuintaOpcionVisores()
{
    string ip;
    ConsultasVisores consulta = new ConsultasVisores();
    IEnumerable<vmNombre> resultado;
    Console.Write("IP: ");
    ip = Console.ReadLine();
    resultado = consulta.VisoresConectadosIP(ip);
    ImprimirVisores(resultado);
}

static void SextaOpcionVisores()
{
    string plataforma, email;
    ConsultasVisores consulta = new ConsultasVisores();
    IEnumerable<vmNombre> resultado;
    Console.Write("Nombre plataforma: ");
    plataforma = Console.ReadLine();
    Console.Write("Email: ");
    email = Console.ReadLine();
    resultado = consulta.EncontrarVisorPlatEmail(plataforma, email);
    ImprimirVisores(resultado);
}


/* Metodos para las ConsultasGeneros */
static void OpcionConsultasGeneros()
{
    switch (MenuConsultasGeneros())
    {
        case 1:
            PrimeraOpcionGeneros();
            break;
        case 2:
            SegundaOpcionGeneros();
            break;
        case 3:
            TerceraOpcionGeneros();
            break;
        case 4:
            CuartaOpcionGeneros();
            break;
        case 5:
            QuintaOpcionGeneros();
            break;
        case 6:
            SextaOpcionGeneros();
            break;
    }
    Console.ReadLine();
}

static int MenuConsultasGeneros()
{
    Console.WriteLine("Menu ConsultasGeneros\n");
    Console.WriteLine("1) Lista Genero/Visor (nombre Plat)");
    Console.WriteLine("2) Agrupacion Genero/Visor");
    Console.WriteLine("3) Agrupacion Genero/Visor Ordenados");
    Console.WriteLine("4) Genero Maximo Numero Visores");
    Console.WriteLine("5) Todos Generos (Plataforma)");
    Console.WriteLine("6) Generos Plataforma (Visor)");
    Console.Write("Selecciona la opcion que desee: ");
    return Int32.Parse(Console.ReadLine());
}

static void PrimeraOpcionGeneros()
{
    string plataforma;
    ConsultasGeneros consulta = new ConsultasGeneros();
    IEnumerable<vmGeneroNombre> resultado;
    Console.Write("Nombre plataforma: ");
    plataforma = Console.ReadLine();
    resultado = consulta.ListaParGeneroVisorParaPlat(plataforma);
    ImprimirGeneroYVisor(resultado);
}

static void SegundaOpcionGeneros()
{
    ConsultasGeneros consulta = new ConsultasGeneros();
    IEnumerable<IGrouping<string, vmGeneroNombre>> resultado;
    resultado = consulta.AgrupacionVisoresGeneros();
    ImprimirGeneroYVisorGrouping(resultado);
}

static void TerceraOpcionGeneros()
{
    ConsultasGeneros consulta = new ConsultasGeneros();
    IEnumerable<vmGeneroNombre> resultado;
    resultado = consulta.AgrupacionVisoresGenerosOrdenados();
    ImprimirGeneroYVisor(resultado);
}

static void CuartaOpcionGeneros()
{
    ConsultasGeneros consulta = new ConsultasGeneros();
    IEnumerable<vmGeneroNombre> resultado;
    resultado = consulta.GeneroMaximoNumeroVisores();
    ImprimirGeneroYVisor(resultado);
}

static void QuintaOpcionGeneros()
{
    string plataforma;
    ConsultasGeneros consulta = new ConsultasGeneros();
    IEnumerable<vmGeneroNombre> resultado;
    Console.Write("Dime la plataforma: ");
    plataforma = Console.ReadLine();
    resultado = consulta.TodosGenerosPlat(plataforma);
    ImprimirGeneroYVisor(resultado);
}

static void SextaOpcionGeneros()
{
    string visor;
    ConsultasGeneros consulta = new ConsultasGeneros();
    IEnumerable<vmGeneroNombre> resultado;
    Console.Write("Dime el visor: ");
    visor = Console.ReadLine();
    resultado = consulta.GenerosPlataformaParaVisor(visor);
    ImprimirGeneroYPlataforma(resultado);
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
    Console.WriteLine("1) IP ha habido más visualizaciones y cuantas");
    Console.WriteLine("2) Lista de pares NombreVisor, suma de la duración de las visualizaciones");
    Console.WriteLine("3) Visores, suma total de duración de visualizaciones");
    Console.WriteLine("4) Visores cuya suma total de duración de visualizacion sea superior a la media");
    Console.WriteLine("5) Plataformas y su suma de tiempos de visualizacion de todos los visores ");
    Console.WriteLine("6) Plataformas y su suma de tiempos de visualizacion de todos los visores(ordenas de mayor a menor)");
    Console.Write("Selecciona la opcion que desee: ");
    return Int32.Parse(Console.ReadLine());
}

static void PrimeraOpcionAgrupaciones()
{
    string nombreGen;
    ConsultasAgrupaciones consulta = new ConsultasAgrupaciones();
    IEnumerable<vmNombreCantidad> resultado;
    Console.Write("Dime el genero: ");
    nombreGen = Console.ReadLine();
    resultado = consulta.IPconMasVisualizacionesSegunGenero(nombreGen);
    ImprimirGeneroYPlataformaAgrupaciones(resultado);
}

static void SegundaOpcionAgrupaciones()
{
    ConsultasAgrupaciones consulta = new ConsultasAgrupaciones();
    IEnumerable<vmNombreCantidad> resultado;
    resultado = consulta.VisorSumaDuracionVisualizaciones();
    ImprimirGeneroYPlataformaAgrupaciones(resultado);
}

static void TerceraOpcionAgrupaciones()
{
    ConsultasAgrupaciones consulta = new ConsultasAgrupaciones();
    IEnumerable<vmNombreCantidad> resultado;
    resultado = consulta.VisorSumaDuracionVisualizacionesNulos();
    ImprimirGeneroYPlataformaAgrupaciones(resultado);
}

static void CuartaOpcionAgrupaciones()
{
    ConsultasAgrupaciones consulta = new ConsultasAgrupaciones();
    IEnumerable<vmNombreCantidad> resultado;
    resultado = consulta.VisoresSumaDuracionMayorMedia();
    ImprimirGeneroYPlataformaAgrupaciones(resultado);
}

static void QuintaOpcionAgrupaciones()
{
    ConsultasAgrupaciones consulta = new ConsultasAgrupaciones();
    IEnumerable<vmNombreCantidad> resultado;
    resultado = consulta.PlataformasMasUsadas();
    ImprimirGeneroYPlataformaAgrupaciones(resultado);
}

static void SextaOpcionAgrupaciones()
{
    ConsultasAgrupaciones consulta = new ConsultasAgrupaciones();
    IEnumerable<vmNombreCantidad> resultado;
    resultado = consulta.PlataformasMasUsadasOrdenadas();
    ImprimirGeneroYPlataformaAgrupaciones(resultado);
}

static void ImprimirVisores(IEnumerable<vmNombre> result)
{
    Console.WriteLine();
    foreach (vmNombre x in result)
    {
        Console.WriteLine(x.Nombre); //Asi visualizamos la propiedad Nombre de x
    }
}

static void ImprimirGenero(IEnumerable<vmGeneroNombre> result)
{
    Console.WriteLine();
    foreach (vmGeneroNombre x in result)
    {
        Console.WriteLine(x.Genero); //Asi visualizamos la propiedad Genero de x
    }
}

static void ImprimirGeneroYVisor(IEnumerable<vmGeneroNombre> result)
{
    Console.WriteLine();
    foreach (vmGeneroNombre x in result)
    {
        Console.WriteLine(x.Genero + " " + x.Nombre); //Asi visualizamos las propiedades Genero y Nombre de x
    }
}

static void ImprimirGeneroYVisorGrouping(IEnumerable<IGrouping<string, vmGeneroNombre>> result)
{
    Console.WriteLine();
    foreach (IGrouping<string, vmGeneroNombre> x in result)
    {
        foreach (vmGeneroNombre entrada in x)
        {
            Console.WriteLine(entrada.Genero + " " + entrada.Nombre);
        }
    }
}

static void ImprimirGeneroYPlataforma(IEnumerable<vmGeneroNombre> result)
{
    Console.WriteLine();
    foreach (vmGeneroNombre x in result)
    {
        Console.WriteLine(x.Genero + " " + x.Nombre);
    }
}

static void ImprimirGeneroYPlataformaAgrupaciones(IEnumerable<vmNombreCantidad> result)
{
    Console.WriteLine();
    foreach (vmNombreCantidad cantidad in result)
    {
        Console.WriteLine(cantidad.Nombre + " " + cantidad.Cantidad);
    }
}