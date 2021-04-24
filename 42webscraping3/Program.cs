
// https://www.imdb.com/
// https://www.imdb.com/chart/top/
// dotnet add package HtmlAgilityPack --version 1.11.32
// dotnet add package Newtonsoft.Json --version 13.0.1
using System;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Newtonsoft.Json;
using static System.Console;

namespace _42webscraping3
{
    class Pelicula {
        public int    Posicion {get; set;}
        public string Titulo {get; set;}
        public string Url {get; set;}
        public float  Rating {get; set;}
        public int    Liberacion {get; set;}
        public string Director {get; set;}
        public override string ToString() => $"Posicion: {Posicion}\nTitulo: {Titulo}\nUrl: {Url}" +
                                             $"Rating: {Rating}\nLiberacion: {Liberacion}\nDirector: {Director}\n";
    }

    class Program
    {
        static void Main(string[] args)
        {
             string baseUrl="https://www.imdb.com/";
             string iniUtil="https://www.imdb.com/chart/top/";
             List<Pelicula> dp = new List<Pelicula>();
             HtmlWeb web = new HtmlWeb();
             HtmlDocument doc = web.Load(iniUtil);

             var tp = doc.DocumentNode.SelectNodes("//div[@id='main']//table//tr");

             foreach(var l in tp) {
                 if(l.ParentNode.Name!="thead") {
                    Pelicula p = new Pelicula();
                    p.Posicion = int.Parse( l.SelectNodes(".//td[@class='posterColumn']//span[@name='rk']").Select(a=>a.Attributes["data-value"].Value).First() );
                    p.Titulo   = l.SelectSingleNode(".//td[@class='titleColumn']//a[@href]").InnerHtml;
                    p.Rating   = float.Parse( l.SelectSingleNode(".//td[@class='ratingColumn imdbRating']//strong").InnerHtml );
                    p.Url      = baseUrl + l.SelectSingleNode(".//td[@class='titleColumn']//a[@href]").Attributes["href"].Value;
                    HtmlDocument doc2 = web.Load(p.Url);
                    p.Liberacion = int.Parse(doc2.DocumentNode.SelectSingleNode("//h1//span//a").InnerText);
                    p.Director   = doc2.DocumentNode.SelectSingleNode("//div[@class='credit_summary_item']//a[@href]").InnerHtml;
                    //WriteLine(p.ToString());
                    dp.Add(p);
                 }
                 //WriteLine(l.InnerHtml);
                 //WriteLine("\n");
             }
            // Grabar datos en formato Json
            string ruta = Path.Combine(Environment.CurrentDirectory,"peliculas");
            StreamWriter fs = File.CreateText(ruta+".json");
            JsonSerializer json = new JsonSerializer();
            json.Serialize(fs,dp);
            fs.Close();
            

        }
    }
}
