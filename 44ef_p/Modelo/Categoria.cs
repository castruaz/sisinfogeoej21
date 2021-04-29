using System.Collections.Generic;
namespace _44ef_p
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public string Nombre { get; set; }
        public string Url { get; set; }
        public List<Libro> Libros { get; set; }
    }
}