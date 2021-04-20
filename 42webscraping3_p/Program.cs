// https://stackoverflow.com/questions/18427257/htmlagilitypack-loading-multiple-pages

using System;
using HtmlAgilityPack;
using System.Collections.Generic;

namespace _42webscraping3_p
{
    class Pelicula {
        string Titulo {get; set;}
    }


    class Program
    {
        static void Main(string[] args)
        {
            string baseUrl = @"https://www.imdb.com/chart/top/";
             List <Pelicula> datosPelicula = new List<Pelicula>();

            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = new HtmlDocument();
            


            Console.WriteLine("Lista de peliculas en el tpo de www.imbd.com");



        }
    }
}
