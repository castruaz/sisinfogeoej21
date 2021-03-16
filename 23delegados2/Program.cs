using System;

// Ejemplo de delegado multicast

namespace _23delegados2
{

    public delegate void Midelegado(string msj);

    class Program
    {
        static void Main(string[] args)
        {
            Midelegado d1, d2, d3, d;

            d1 = Mensaje.Mensaje1;
            d2 = Mensaje.Mensaje2;
            d3 = (string msj) => Console.WriteLine($"{msj} - paga todo que no pare la fiesta");
            d = d1 + d2 ;
            d("El peje");
            d += d3;
            d("El borolas");
            d -= d2;
            d("Peña");
            d -= d1;
            d("Tello");
        }
    }

     public class Mensaje {
        public static void Mensaje1(string msj) => Console.WriteLine($"{msj} - lleva el pastel");
        public static void Mensaje2(string msj) => Console.WriteLine($"{msj} - fue el culpable se cancela la fiesta");
    }

}
