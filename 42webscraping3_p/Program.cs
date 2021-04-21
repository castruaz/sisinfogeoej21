// https://stackoverflow.com/questions/18427257/htmlagilitypack-loading-multiple-pages
// https://www.nuget.org/packages/HtmlAgilityPack/ > dotnet add package HtmlAgilityPack --version 1.11.32
// https://www.nuget.org/packages/Newtonsoft.Json/ > dotnet add package Newtonsoft.Json --version 13.0.1

using System;
using HtmlAgilityPack;
using System.Collections.Generic;
using static System.Console;
using System.Linq;
using Newtonsoft.Json;
using System.IO;

namespace _42webscraping3_p
{
    class Pelicula {
        public int    Posicion {get; set;}
        public string Titulo {get; set;}
        public string Url {get; set;}
        public Single Rating {get; set;}
        public int    Liberacion {get; set;}
        public string Director {get; set;}
        public override string ToString() => $"Posición: {Posicion}\nTitulo: {Titulo}\nUrl: {Url}\nRating: {Rating}\n" + 
                                             $"Liberación: {Liberacion}\nDirector: {Director}\n" ;
    }

    class Program
    {
        static void Main(string[] args)
        {
            string baseUrl = @"https://www.imdb.com/";
            string iniUrl = @"https://www.imdb.com/chart/top/";
            List <Pelicula> dp = new List<Pelicula>();
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(iniUrl);

            var tp = doc.DocumentNode.SelectNodes("//div[@id='main']//table//tr");

            foreach(var l in tp) {     
                if ( l.ParentNode.Name != "thead") {
                    Pelicula p = new Pelicula();
                    p.Posicion = int.Parse( (l.SelectNodes(".//td[@class='posterColumn']//span[@name]").Select(a=>a.Attributes["data-value"].Value) ).First()); 
                    p.Titulo   = l.SelectSingleNode(".//td[@class='titleColumn']//a[@href]").InnerHtml;
                    p.Url      = baseUrl + l.SelectSingleNode(".//td[@class='posterColumn']//a[@href]").Attributes["href"].Value;
                    p.Rating   = Single.Parse(l.SelectSingleNode(".//td[@class='ratingColumn imdbRating']//strong").InnerHtml);
                    HtmlDocument sdoc = web.Load(p.Url);
                    p.Liberacion = int.Parse( sdoc.DocumentNode.SelectSingleNode("//h1//span//a").InnerText );
                    p.Director = sdoc.DocumentNode.SelectSingleNode("//div[@class='credit_summary_item']//a[@href]").InnerHtml;
                    dp.Add(p);
                    WriteLine(p.ToString());
                }
            }
            // Grabar los datos en formato Json
            string ruta = Path.Combine(Environment.CurrentDirectory,"peliculas");
            StreamWriter fs = File.CreateText(ruta+".json");
            JsonSerializer json = new JsonSerializer();
            json.Serialize(fs,dp);
            fs.Close();

            WriteLine(tp.Count);
       }
    }
}
