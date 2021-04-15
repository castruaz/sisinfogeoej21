using System;
using  HtmlAgilityPack;
using System.Linq;
using System.Text.RegularExpressions;
using static System.Console;


namespace _40webscraping1
{
    class Program
    {

        static void Main(string[] args)
        {
            Clear();
            if (args.Length < 2) {
                WriteLine("\nForma de uso: \n url [1 titulo, 2 html, 3 comentarios, 4 ligas, 5 correos]");
            } else {
                try {
                    HtmlWeb web = new HtmlWeb();
                    HtmlDocument doc = web.Load(args[0]);
                    switch(int.Parse(args[1])) {
                        case 1: Titulo(doc);break;
                        case 2: Textohtml(doc);break;
                        case 3: Comenentarios(doc);break;
                        case 4: Ligas(doc);break;
                        case 5: Correos(doc);break;
                        default: WriteLine("No elegiste que parsear");break;
                    }
                } catch (Exception e)
                {
                    WriteLine($"Error al acceder el Web: >> {e.Message} >>");
                }
            }
        }

        static void Correos(HtmlDocument doc) {
            var emails = doc.DocumentNode.SelectSingleNode("//body");
            string patron = @"([\w.]+)@([\w.]+)\.([a-z]+)";
            Match re = Regex.Match(emails.InnerHtml, patron);
            WriteLine("\nCorreos:\n");
            if (re.Success) {
                foreach(var c in re.Captures) {
                    WriteLine( c.ToString() );
                }
            }
            WriteLine($"\nTotal Correos: {re.Captures.Count}");
        }

        static void Ligas(HtmlDocument doc) {
            try {
                var ligas = ( doc.DocumentNode.SelectNodes("//a[@href]").Select(a=>a.Attributes["href"].Value).Where(b=>b.Contains("http"))).ToList();
                WriteLine("\nLigas:\n");
                if (ligas is not null ) ligas.ForEach(x=>WriteLine(x));
                WriteLine($"\nTotal Ligas: {ligas.Count}");
            } catch (System.ArgumentNullException ) {WriteLine("No tiene ligas");}
            
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
            if (titulo is not null) WriteLine(titulo);
        }
    }
}
  