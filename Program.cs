namespace CursoLinq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LinqQueries queries = new LinqQueries();

            //Toda la Colección
            //ImprimirValores(queries.TodaLaColeccion());

            //Libros después del 2000
            //ImprimirValores(queries.LibrosDespuesdel2000());

            //Libros Con Mas de 250 Pag Con Palabras In Action
            //ImprimirValores(queries.LibrosConMasde250PagConPalabrasInAction());

            //Todos los libros tienen status
            //Console.WriteLine("Todos los libros tienen status? " + queries.TodosLosLibrosTienenStatus());

            //Si algún libro fue publicado en el año 2005
            //Console.WriteLine("Algún libro fue publicado en 2005? " + queries.SiAlgunLibroFuePublicado2005());

            //Libros en la categoría de Python
            //ImprimirValores(queries.LibrosPython());

            //Libros de JAVA Ordendos por Nombre
            //ImprimirValores(queries.LibrosJavaOrderByNombre());

            //Libros de con más de 450 páginas ordenados descendente por número de página.
            //ImprimirValores(queries.LibrosJavaOrderByPagDescMas450Pag());

            //3 Primeros libros de la categoría JAVA con la fecha más reciente.
            //ImprimirValores(queries.Primeros3LibrosJAVAMasRecientes());

            //Tercer y cuarto libro con más de 400 páginas
            //ImprimirValores(queries.TercerYCuartoLibrosConMasDe400Pag());

            //Tres Primeros Libros Filtrados con Select
            //ImprimirValores(queries.TresPrimeroLibrosDeLaCollecion());

            // Cantidad de libros que tienen entre 200 y 500 páginas.
            //Console.WriteLine("Cantidad de libros que tienen entre 200 y 500 páginas: " + queries.NumeroLibrosEntre200y500Pag());

            // Fecha de publicación más antigua.
            //Console.WriteLine("Fecha de publicación más antigua: " + queries.FechaPublicacionMasAntigua());

            // Número de páginas del libro con mayor número de páginas.
            //Console.WriteLine("Número de páginas del libro con mayor número de páginas: " + queries.NumeroPaginasLibroConMasPag());

            // Libro con menor número de páginas.
            //var libro = queries.LibroConMenorCantidadPaginas();
            //Console.WriteLine(libro.title + " - " + libro.pageCount);

            // Libro con la fecha de publicación más reciente.
            //var libro = queries.LibroConFechaPublicacionMasReciente();
            //Console.WriteLine(libro.title + " - " + libro.publishedDate.ToShortDateString());

            // Suma de páginas de libros entre 0 y 500
            //Console.WriteLine("Suma total de páginas es: " + String.Format("{0:n0}", queries.SumaCantidadPaginasLibrosEntre0y500Pag()));

            // Libros publicados después del 2015
            //Console.WriteLine(queries.TitulosLibrosPublicadosDespues2015());

            // Promedio de caracteres de los títulos de los libros
            //Console.WriteLine("Promedio de caracteres de los títulos de los libros: " + queries.PromedioCaracteresTitulosLibros().ToString("F2"));

            // Libros publicados después a partir del 2000 agrupados por año.
            //ImprimirGrupo(queries.LibrosPublicadosAPartir2000AgrupadosPorAnio());

            // Diccionario de libros agrupados por primera letra del titulo.
            //ImprimirDiccionario(queries.LibrosPorLetraInicial(), 'P');

            // Libros con más de 500 páginas publicados después del 2005.
            ImprimirValores(queries.LibrosMas500PagPublicadosDespues2005());
        }


        // Método estático para imprimir los valores de una lista de libros
        static void ImprimirValores(IEnumerable<Book> listadelibros)
        {
            Console.WriteLine("{0, -60} {1, 15} {2, 15}", "Titulo", "N. Paginas", "Fecha Publicación");
            Console.WriteLine("");
            foreach (var book in listadelibros)
            {
                Console.WriteLine("{0, -60} {1, 15} {2, 15}", book.title, book.pageCount, book.publishedDate.ToShortDateString());
            }
        }

        static void ImprimirGrupo(IEnumerable<IGrouping<int, Book>> ListadeLibros)
        {
            foreach (var grupo in ListadeLibros)
            {
                Console.WriteLine("");
                Console.WriteLine("Grupo: " + grupo.Key);
                Console.WriteLine("{0, -60} {1, 15} {2, 15}\n", "Titulo", "N. Páginas", "Fecha Publicación");
                foreach (var libro in grupo)
                {
                    Console.WriteLine("{0, -60} {1, 15} {2, 15}", libro.title, libro.pageCount, libro.publishedDate.ToShortDateString());
                }
            }
        }

        static void ImprimirDiccionario(ILookup<char, Book> ListadeLibros, char letra)
        {
            Console.WriteLine("{0, -60} {1, 15} {2, 15}\n", "Titulo", "N. Páginas", "Fecha Publicación");
            foreach (var grupo in ListadeLibros[letra])
            {
                Console.WriteLine("{0, -60} {1, 15} {2, 15}", grupo.title, grupo.pageCount, grupo.publishedDate.ToShortDateString());
            }
        }
    }
}
