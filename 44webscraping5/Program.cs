using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace _44webscraping5
{
    class Program
    {
        static void Main(string[] args)
        {
             ChromeOptions opciones = new ChromeOptions();
             opciones.AddArgument("--headless");
             IWebDriver driver = new ChromeDriver(opciones);
             driver.Url = "http://books.toscrape.com/";
             DataContext db = new DataContext();

            // Hago scraping de las categorias y obtengo los datos CategoriaID, Nombre, Url
             var ligascat = driver.FindElements(By.XPath("/html/body/div/div/div/aside/div[2]/ul/li/ul/li/a"));
             List<Categoria> categorias = new List<Categoria>();
             foreach(var l in ligascat) {
                 Categoria categoria = new Categoria();
                 var url = l.GetAttribute("href");
                 var i = url.LastIndexOf("_")+1;
                 var f = url.LastIndexOf("/")-i;
                categoria.CategoriaID = int.Parse(url.Substring(i,f));  
                categoria.Nombre = l.Text;
                categoria.Url = url;
                categorias.Add(categoria);
             }
            // Vacia las categorias obtenidas al objeto que represnta la tabla de BD
            foreach(var c in categorias){
                db.Categorias.Add(c);
            }
            db.SaveChanges();

        }
    }
}
