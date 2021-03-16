using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace _28linq2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] frutas = new string[] 
            {"pera","melon","sandia","durazno","manzana","platano","kiwi","naranja","jicama","piña"};

            WriteLine("\n\nFrutas que inician con la letra m");
            var mfrutas = from f in frutas where f.StartsWith('m') select f;
            foreach(string f in mfrutas) Write($"{f} ");
  
            var anfrutas = from f in frutas where f.Contains("an") select f;
            WriteLine("\n\nFrutas que contienen las letras: an {0}", anfrutas.Count());
            foreach(string f in anfrutas) Write($"{f} ");

            var frutasa = (from f in frutas where f.EndsWith('a') select f).ToList();
            WriteLine("\n\nFrutas que terminan con la letra m: {0}", frutasa.Count());
            frutasa.ForEach(f=>Write($"{f} "));



        }
    }
}
