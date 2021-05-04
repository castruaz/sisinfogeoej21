using System.Collections.Generic;

namespace _44webscraping5_p
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public string Nombre { get; set; }
        public string Url { get; set; }
        public List<Libro> Libros { get; set; }
        public override string ToString()
            => $"Id: {CategoriaId}\nNombre: {Nombre}\nUrl: {Url}";
       
    }
}