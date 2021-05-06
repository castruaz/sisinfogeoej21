using Microsoft.EntityFrameworkCore;

namespace _44webscraping5
{
    public class DataContext : DbContext {

        public DbSet<Categoria> Categorias {get; set;}
        public DbSet<Libro> Libros {get; set;}
         
        protected override void OnConfiguring(DbContextOptionsBuilder opciones) =>
            opciones.UseSqlite(@"Data Source=Catalogo.db");
    }

}