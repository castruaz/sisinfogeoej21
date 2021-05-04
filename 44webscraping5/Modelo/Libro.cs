namespace _44webscraping5
{
    public class Libro {
        public int ID {get; set;}
        public string Url {get; set;}
        public string UrlImagen {get; set;}
        public string Titulo {get; set;}
        public decimal Precio {get; set;}
        public int CategoriaID {get; set;}
        public override string ToString() => 
            $"ID: {ID}\nUrl: {Url}\nUrl Imagen: {UrlImagen}\nTitulo: {Titulo}" +
            $"Precio: {Precio}\nCategoria ID: {CategoriaID}";
    }
}