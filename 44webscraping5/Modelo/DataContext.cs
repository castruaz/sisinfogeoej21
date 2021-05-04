using Microsoft.EntityFrameworkCore;

namespace _44webscraping5
{
    public class DataContext : DbContext {

        private static bool _creada = false;
        public DbSet<Categoria> Categorias {get; set;}
        public DbSet<Libro> Libros {get; set;}
        public DataContext() {
            if(!_creada) {
                _creada = true;
                Database.EnsureDeleted();
                Database.EnsureCreated();
            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder opciones) =>
            opciones.UseSqlite(@"Data Source=Catalogo.db");
    }

}