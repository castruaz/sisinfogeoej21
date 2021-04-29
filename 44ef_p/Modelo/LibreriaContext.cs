using Microsoft.EntityFrameworkCore;
namespace _44ef_p {
    public class LibreriaContext : DbContext
    {
        public LibreriaContext() {
            if(!_created) {
                _created = true;
                Database.EnsureDeleted();
                Database.EnsureCreated();
            }
        }
        private static bool _created = false;
        public DbSet<Categoria> Categorias {get; set;}
        public DbSet<Libro> Libros {get; set;}
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(@"Data Source=Libreria.db");
    }

}