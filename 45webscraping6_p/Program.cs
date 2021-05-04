using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using static System.Console;
using System.Linq;
using System.IO;

namespace _44webscraping5_p
{
    class Program
    {
        static DataContext db = new DataContext();
        static string ruta = Path.Combine(Environment.CurrentDirectory,"Libreria.db");

        static void Main(string[] args) {
            if(!db.Categorias.Any()) Scraping();
            Consultas();
        }

        static void Consultas() {
            
            if(File.Exists(ruta)) {
                
                // Consulta 1 - Todas las categorias
                WriteLine("\n\nTodas las Categorias ");
                foreach(var c in db.Categorias) {
                    WriteLine(c.ToString());
                }
                WriteLine($"\n>> Total: {db.Categorias.Count()}");

                // Consulta 2 - Categorias cuyo nombre inicia con la Letra E
                WriteLine("\n\nCategorias cuyo nombre inicia con la letra determinada");
                string letra = "A";
                var catsE = db.Categorias.Where(c=>c.Nombre.StartsWith(letra)).ToList();
                catsE.ForEach(c=>WriteLine(c.ToString())); 
                WriteLine($"\n>> Total: {catsE.Count()}");

                // Consulta 3 - Todos los libros
                  WriteLine("\n\nTodas los Libros ");
                foreach(var l in db.Libros) {
                    WriteLine(l.ToString());
                }
                WriteLine($"\n>> Total: {db.Libros.Count()}");

                // Consulta 4 - Categorias cuyo nombre inicia con la Letra E
                WriteLine("\n\nLibros de una categoria determinada");
                int id = 2;
                var libcat = db.Categorias.SelectMany(c=>c.Libros).Where(l=>l.CategoriaId==id).ToList();
                libcat.ForEach(l=>WriteLine(l.ToString())); 
                WriteLine($"\n>> Total: {libcat.Count()}");

                // Consulta 5 - Todos los libros agrupados por categoria 
                WriteLine("\n\n>> Todos los libros agrupados por categoria");
                var librosxcategoria = db.Libros.OrderBy(l=>l.CategoriaId).ToLookup(c=> new {c.CategoriaId, c.Categoria.Nombre,c.Categoria.Url});
                foreach (var c in librosxcategoria)
                {
                    WriteLine($"\n {c.Key} \n");
                    
                    
                    
                    foreach(var l in c ) {
                        WriteLine(l.ToString());
                    }

                    WriteLine($"\n>> Total: {c.Count()}");
                }
                
                





                
            } else 
                WriteLine("La base de datos aun no existe");

        }



        static void Scraping()
        { 
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--headless");
            IWebDriver driver = new ChromeDriver(options);
            driver.Url="http://books.toscrape.com";
            
           

             // Hacer scrapping de los datos en las estructuras temporales en memoria categorias,libros

            // Scraping de categorias
            var ligascat =  driver.FindElements(By.XPath("/html/body/div/div/div/aside/div[2]/ul/li/ul/li/a"));
            List<Categoria> categorias = new List<Categoria>();
            foreach(var l in ligascat) {
                Categoria cat = new Categoria();
                var url = l.GetAttribute("href");
                var i = url.LastIndexOf('_') + 1;
                var f = url.LastIndexOf('/') - i;
                cat.CategoriaId = int.Parse(url.Substring(i, f));
                cat.Nombre = l.Text;
                cat.Url = url;
                categorias.Add(cat);
            }

            // Scraping de libros
            List<Libro> libros = new List<Libro>();
            List<string> urls = new List<string>();
            for (int i = 1; i <=50; i++) urls.Add($@"http://books.toscrape.com/catalogue/page-{i}.html");
             foreach(var url in urls) {
                driver.Navigate().GoToUrl(url);
                List<string> urlslibros = new List<string>();
                var ligaslibros = driver.FindElements(By.XPath("html/body/div/div/div/div/section/div[2]/ol/li/article/h3/a"));
                foreach(var l in ligaslibros) urlslibros.Add(l.GetAttribute("href"));
                foreach(var u in urlslibros) {
                    driver.Navigate().GoToUrl(u);
                    Libro libro = new Libro();
                    libro.Url = u;
                    var catl = driver.FindElement(By.XPath("/html/body/div/div/ul/li[3]/a")).GetAttribute("href");
                    var i = catl.LastIndexOf('_') + 1;
                    var f = catl.LastIndexOf('/') - i;
                    libro.CategoriaId=Convert.ToInt32(catl.Substring(i, f));
                    libro.UrlImage = driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[2]/article/div[1]/div[1]/div/div/div/div/img")).GetAttribute("src");
                    libro.Titulo = driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[2]/article/div[1]/div[2]/h1")).Text;
                    libro.Precio = decimal.Parse(driver.FindElement(By.XPath("/html/body/div/div/div[2]/div[2]/article/div[1]/div[2]/p[1]")).Text.Replace('£',' '));
                    libros.Add(libro);
                }

            }

            // Grabar los datos en la base de datos
            
            db.Database.EnsureCreated();

            
                foreach(var c in categorias) {
                    db.Categorias.Add(c);
                }
                foreach(var l in libros) {
                    db.Libros.Add(l);
                }
                db.SaveChanges();
            
        }
 
    }
}
