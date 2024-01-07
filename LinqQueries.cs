using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CursoLinq
{
    internal class LinqQueries
    {
        // Colección privada de libros
        private List<Book> librosCollection = new List<Book>();

        // Constructor de la clase
        public LinqQueries()
        {
            // Lectura del archivo JSON de libros
            using (StreamReader reader = new StreamReader("books.json"))
            {
                string json = reader.ReadToEnd();
                // Deserialización del JSON a la colección de libros
                this.librosCollection = JsonSerializer.Deserialize<List<Book>>(json);
            }
        }

        // Método para obtener toda la colección de libros
        public IEnumerable<Book> TodaLaColeccion()
        {
            return librosCollection;
        }

        // Método para obtener los libros publicados después del año 2000
        public IEnumerable<Book> LibrosDespuesdel2000()
        {
            // Método de extensión
            //return librosCollection.Where(x => x.publishedDate.Year > 2000);

            // Expresión de consulta
            return from l in librosCollection where l.publishedDate.Year > 2000 select l;
        }

        // Método para obtener los libros con más de 250 páginas y que contienen "in Action" en el título
        public IEnumerable<Book> LibrosConMasde250PagConPalabrasInAction()
        {
            // Método de extensión
            //return librosCollection.Where(x => x.pageCount > 250 && x.title.Contains("in Action"));

            // Expresión de consulta
            return from l in librosCollection where l.pageCount > 250 && l.title.Contains("in Action") select l;
        }

        // Método para verificar si todos los libros tienen estado
        public bool TodosLosLibrosTienenStatus()
        {
            return librosCollection.All(x => x.status != string.Empty);
        }

        // Método para verificar si algún libro fue publicado en el año 2005
        public bool SiAlgunLibroFuePublicado2005()
        {
            return librosCollection.Any(x => x.publishedDate.Year == 2005);
        }

        // Método para obtener los libros de la categoría Python
        public IEnumerable<Book> LibrosPython()
        {
            return librosCollection.Where(x => x.categories.Contains("Python"));
        }

        // Método para obtener los libros de la categoría Java ordenados por nombre
        public IEnumerable<Book> LibrosJavaOrderByNombre()
        {
            return librosCollection.Where(x => x.categories.Contains("Java")).OrderBy(x => x.title);
        }

        // Método para obtener los libros con más de 450 páginas ordenados de mayor a menor
        public IEnumerable<Book> LibrosJavaOrderByPagDescMas450Pag()
        {
            return librosCollection.Where(x => x.pageCount > 450).OrderByDescending(x => x.pageCount);
        }

        // Método para obtener los primeros 3 libros más recientes de la categoría Java
        public IEnumerable<Book> Primeros3LibrosJAVAMasRecientes()
        {
            return librosCollection.Where(x => x.categories.Contains("Java")).OrderByDescending(x => x.publishedDate).Take(3);
        }

        // Método para obtener el tercer y cuarto libro con más de 400 páginas
        public IEnumerable<Book> TercerYCuartoLibrosConMasDe400Pag()
        {
            return librosCollection.Where(x => x.pageCount > 400).Skip(2).Take(2);
        }

        // Método para obtener los primeros tres libros de la colección
        public IEnumerable<Book> TresPrimeroLibrosDeLaCollecion()
        {
            return librosCollection.Take(3).Select(x => new Book() { title =  x.title, pageCount =  x.pageCount });
        }   

        // Método para obtener el número de libros con más de 200 páginas y menos de 500 páginas
        public int NumeroLibrosEntre200y500Pag()
        {
            return librosCollection.Count(x => x.pageCount >= 200 && x.pageCount <= 500);
        }

        // Método para obtener la fecha de publicación más antigua
        public DateTime FechaPublicacionMasAntigua()
        {
            return librosCollection.Min(x => x.publishedDate);
        }

        // Método para obtener el número de páginas del libro con más páginas
        public int NumeroPaginasLibroConMasPag()
        {
            return librosCollection.Max(x => x.pageCount);
        }

        // Método para obtener el libro con menor número de páginas
        public Book LibroConMenorCantidadPaginas()
        {
            return librosCollection.Where(x => x.pageCount > 0).MinBy(x => x.pageCount);
        }

        // Método para obtener el libro con la fecha de publicación más reciente
        public Book LibroConFechaPublicacionMasReciente()
        {
            return librosCollection.MaxBy(x => x.publishedDate);
        }

        // Método para obtener la suma de las páginas de los libros con más de 200 páginas y menos de 500 páginas
        public int SumaCantidadPaginasLibrosEntre0y500Pag()
        {
            return librosCollection.Where(x => x.pageCount >= 0 && x.pageCount <= 500).Sum(x => x.pageCount);
        }

        // Método para obtener los títulos de los libros publicados después del año 2015
        public string TitulosLibrosPublicadosDespues2015()
        {
            var libros = librosCollection.Where(x => x.publishedDate.Year > 2015).ToList();
            if (!libros.Any()) return string.Empty;

            return libros.Select(libro => libro.title).Aggregate((current, next) => current + " | " + next);
        }

        // Método para obtener el promedio de caracteres de los títulos de los libros
        public double PromedioCaracteresTitulosLibros()
        {
            return librosCollection.Average(x => x.title.Length);
        }

        // Método para obtener los libros publicados a partir del año 2000 agrupados por año
        public IEnumerable<IGrouping<int, Book>> LibrosPublicadosAPartir2000AgrupadosPorAnio()
        {
            return librosCollection.Where(x => x.publishedDate.Year >= 2000).GroupBy(x => x.publishedDate.Year);
        }

        // Método para obtener los libros por letra inicial.
        public ILookup<char, Book> LibrosPorLetraInicial()
        {
            return librosCollection.ToLookup(x => x.title[0], x => x);
        }

        // Método para obtener los libros con más de 500 páginas publicados después del año 2005
        public IEnumerable<Book> LibrosMas500PagPublicadosDespues2005()
        {
            var librosMas500Pag = librosCollection.Where(x => x.pageCount > 500);
            var librosPublicadosDespues2005 = librosCollection.Where(x => x.publishedDate.Year > 2005);

            return librosMas500Pag.Join(librosPublicadosDespues2005, libro => libro.title, libro => libro.title, (libro, libro1) => libro);
        }
    }
}
