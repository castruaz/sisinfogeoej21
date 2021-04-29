using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using static System.Console;
using System.Linq;

namespace _44webscraping5_p
{
    class Program
    {
        static void Main(string[] args)
        { 
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--headless");
            IWebDriver driver = new ChromeDriver(options);
            driver.Url="http://books.toscrape.com";
            var db = new DataContext();
           

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

            List<Libro> libros = new List<Libro>();
            List<string> urls = new List<string>();
            for (int i = 1; i <=50; i++) urls.Add($@"http://books.toscrape.com/catalogue/page-{i}.html");
            //urls.ForEach(u=>WriteLine(u));
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
