using System;
using HtmlAgilityPack;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using static System.Console;
using System.Net;

namespace _41webscraping2
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseUrl = args[0];
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(baseUrl);
            HashSet<Uri> lista = new HashSet<Uri>();
            string ruta = Path.Combine(Environment.CurrentDirectory, "imagenes");

            var nodos = doc.DocumentNode.SelectNodes("//img/@src").Select(v=>v.Attributes["src"].Value).Where(v=> v is not null);

            foreach(var n in nodos) {
                Uri uri = new Uri(n, UriKind.RelativeOrAbsolute);
                if( !uri.IsAbsoluteUri) uri = new Uri(new Uri(baseUrl),uri);
                lista.Add(uri);
            }

            if ( Directory.Exists(ruta) )
                Directory.Delete(ruta, true);
            Directory.CreateDirectory(ruta);

            WebClient wc = new WebClient();
            WriteLine("\nDescargado archivos ....\n");
            foreach(var uri in lista ) {
                string nomarch = Path.GetFileName(uri.LocalPath);
                string rutades = Path.Combine(ruta, nomarch);
                wc.DownloadFile(uri, rutades);
                WriteLine($"{uri.ToString()} - {rutades}");
            }
        }
    }
}
