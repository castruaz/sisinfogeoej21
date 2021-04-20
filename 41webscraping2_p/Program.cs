using System;
using HtmlAgilityPack;
using System.IO;
using System.Linq;
using System.Net;
using System.Collections.Generic;
using static System.Console;


namespace _41webscraping2_p
{
    class Program
    {
        static void Main(string[] args)
        {
            string ruta = Path.Combine(System.Environment.CurrentDirectory, "imagenes");
            HashSet<Uri> lista = new HashSet<Uri>();

            Directory.CreateDirectory(ruta);
            
            string baseUrl = args[0];
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(baseUrl);
            Ligas(doc);

            // var nodos = doc.DocumentNode.SelectNodes("//img/@src").Select(v=>v.Attributes["src"].Value).Where(v=>v is not null);

            // foreach(var n in nodos) {
            //     Uri uri = new Uri(n, UriKind.RelativeOrAbsolute);
            //     if ( !uri.IsAbsoluteUri) uri = new Uri(new Uri(baseUrl),uri);
            //     lista.Add(uri);
            // }

            // WebClient wc = new WebClient();

            // WriteLine("\nDescargando ..\n");
            // foreach(var uri in lista) {
            //     string nomarch = Path.GetFileName(uri.LocalPath);
            //     string rutades  = Path.Combine(ruta,nomarch);
            //    WriteLine($"{uri.ToString()} - {rutades}");
            //     wc.DownloadFile(uri,rutades);
            //}
        }

        static void Ligas(HtmlDocument doc) {
             var ligas = ( doc.DocumentNode.SelectNodes("//a[@href]").Select(a=>a.Attributes["href"].Value)).ToHashSet();
             
                WriteLine("\nLigas:\n");
                if (ligas is not null ) 
                    foreach(var l in ligas) {
                        WriteLine(l);
                    }
        }

    }
}
