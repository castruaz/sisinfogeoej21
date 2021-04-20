using System;
using HtmlAgilityPack;
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
                WriteLine("URL [1 html, 2 Titulo]");
            } else {
                try {
                    HtmlWeb web = new HtmlWeb();
                    HtmlDocument doc = web.Load(args[0]);
                    switch(int.Parse(args[1])) {
                        case 1: WriteLine("\nTodo el codigo de la pagina: \n");
                                WriteLine(doc.Text);
                                break;
                        case 2: WriteLine("\nTitulo de la pagina:\n");
                                var titulo = doc.DocumentNode.SelectSingleNode("//title").InnerText;
                                if (titulo is not null) WriteLine(titulo);
                                break;
                        case 3: WriteLine("\nComentarios:\n");
                                var comentarios = doc.DocumentNode.SelectNodes("//comment()");
                                if (comentarios is not null ) {
                                    foreach(var c in comentarios) {
                                        WriteLine(c.InnerHtml);
                                    }
                                }
                                WriteLine($"Total comentarios: {comentarios.Count}\n");
                                break;
                        case 4: WriteLine("\nLigas :\n");
                                //var ligas = doc.DocumentNode.SelectNodes("//a[@href]");
                                var ligas = ( doc.DocumentNode.SelectNodes("//a[@href]").Select(a=>a.Attributes["href"].Value).Where(v=>v.Contains("http")) ).ToList();
                                //if (ligas is not null) {
                                    // foreach(var l in ligas) {
                                    //     if ( l.Attributes["href"].Value != null ) {
                                    //         WriteLine(l.Attributes["href"].Value);
                                    //     }
                                    // }
                                //} 
                                ligas.ForEach(l=>WriteLine(l));
                                WriteLine($"\nTotal Ligas: {ligas.Count}\n");
                                break;
                        case 5: WriteLine("\nCorreos:\n");
                                string patron = @"([\w.]+)@([\w.]+)\.([a-z]+)";
                                var emails = doc.DocumentNode.SelectSingleNode("//body");
                                Match re = Regex.Match(emails.InnerHtml, patron);
                                WriteLine("\nCorreos:\n");
                                if (re.Success) {
                                    foreach(var c in re.Captures) {
                                        WriteLine( c.ToString() );
                                    }
                                }
                                WriteLine($"\nTotal Correos: {re.Captures.Count} \n");
                                break;


                    }
                } catch(Exception e) {
                    WriteLine($"Error de acceso: >> {e.Message} >> ");
                }
            }
        }
    }
}
