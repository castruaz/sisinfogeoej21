using Microsoft.EntityFrameworkCore;
namespace _44webscraping5_p
{
    public class DataContext : DbContext
    {
        
        public DbSet<Categoria> Categorias {get; set;}
        public DbSet<Libro> Libros {get; set;}
        
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(@"Data Source=Libreria.db");
    }
}