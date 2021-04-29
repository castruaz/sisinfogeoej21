﻿
// https://aspnetcoremaster.com/web/scraping/c%23/advientocsharp/dotnet/selenium/2018/12/24/web-scraping-con-csharp.html
// - https://www.talkingdotnet.com/create-sqlite-db-entity-framework-core-code-first/
// - https://docs.microsoft.com/es-es/ef/core/get-started/overview/first-app?tabs=netcore-cli
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Linq;
using static System.Console;

namespace _44ef_p
{
    class Program
    {
        static void Main(string[] args)
        {
            var driver = GetDriver();
            driver.Manage().Window.Maximize();
            GuardarCategorias(driver);
            ExtraerLibros(driver);
            ReadLine();
        }

        private static void ExtraerLibros(IWebDriver driver)
        {
            foreach (var url in GetCatalogoUrls().Skip(1))
            {
                driver.Navigate().GoToUrl(url);
                Catalogo catalogo = new Catalogo(driver);
                var links = catalogo.ObtenerUrlLibros();
                foreach (var link in links)
                {
                    driver.Navigate().GoToUrl(link);
                    DetalleLibro detalleLibro = new DetalleLibro(driver);
                    using (var db = new LibreriaContext())
                    {
                        db.Libros.Add(detalleLibro.GetDetallesLibro());
                        db.SaveChanges();
                    }
                }
            }
        }

        public static List<string> GetCatalogoUrls()
        {
            List<string> urls = new List<string>();
            for (int i = 1; i <= 3; i++)
            {
                    urls.Add($@"http://books.toscrape.com/catalogue/page-{i}.html");
            }
            return urls;
        }

        private static IWebDriver GetDriver()
        {
            var user_agent = "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/60.0.3112.50 Safari/537.36";
            ChromeOptions options = new ChromeOptions();
            //Descomenta ela siguiente linea para usar el mode headless de Chrome
            options.AddArgument("--headless"); 
            options.AddArgument("--disable-gpu");
            options.AddArgument($"user_agent={user_agent}");
            options.AddArgument("--ignore-certificate-errors");
            IWebDriver driver = new ChromeDriver(options);
            return driver;
        }
        public static void NavegarPorElCatalogo(IWebDriver driver)
        {
            foreach (var url in GetCatalogoUrls())
            {
            driver.Navigate().GoToUrl(url);
            }
        }
        public static void GuardarCategorias(IWebDriver driver)
        {
            foreach (var url in GetCatalogoUrls().Take(1))
            {
                driver.Navigate().GoToUrl(url);
                Catalogo catalogo = new Catalogo(driver);
                var cate = catalogo.ObtenerCategorias();
                using (var db = new LibreriaContext())
                {
                    foreach (var cat in cate)
                    {
                        db.Categorias.Add(cat);
                        db.SaveChanges();
                    }
                }
            }
        }

    }
}