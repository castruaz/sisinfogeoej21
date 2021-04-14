using System;
using  HtmlAgilityPack;
using System.Linq;
using static System.Console;


namespace _40webscraping1
{
    class Program
    {

        static void Main(string[] args)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load("https://www.uaz.edu.mx/");

            //Titulo(doc);
            //Textohtml(doc);
            //Comenentarios(doc);
            Ligas(doc);
            // Solo los comentarios
            //var nodos = ( doc.DocumentNode.SelectNodes("//a[@href]").Where(n=>n.Attributes["href"].Value.Contains("http")) ).ToList();
            //nodos.ForEach(r=>WriteLine(r.Attributes["href"].Value)); 
        }

        static void Ligas(HtmlDocument doc) {
            var ligas = ( doc.DocumentNode.SelectNodes("//a[@href]").Where(l=>l.Attributes["href"].Value.Contains("http"))).ToList();
             
            ligas.ForEach(x=>WriteLine(x.Attributes["href"].Value));
            
            WriteLine($"Total Ligas: {ligas.Count}");
        }


        static void Comenentarios(HtmlDocument doc) {
            var comentarios = doc.DocumentNode.SelectNodes("//comment()");
            if (comentarios is not null) {
                foreach(var c in comentarios) {
                    Console.WriteLine(c.InnerHtml);
                }
            }
        }

        static void Textohtml(HtmlDocument doc) {
            string html = doc.Text;
            WriteLine("Todo el Texto html> \n");
            WriteLine(html);
        }

        static void Titulo(HtmlDocument doc) {
            var titulo = doc.DocumentNode.SelectSingleNode("//title").InnerText;
            WriteLine(titulo);
        }



    }
}
  