// Paga del trabajdor

using System;

namespace _4pagatrabajador
{
    class Program
    {
        static void Main(string[] args)
        {
            string nombre;
            int horas;
            float paga, tasa=0.10F;

            float impuesto, pagabruta, paganeta;

            Console.WriteLine("Calculo de la paga de un trabajador \n");

            Console.Write("Nombre del trabajador: "); nombre = Console.ReadLine();
            Console.Write("Horas trabajadas     : "); horas = int.Parse(Console.ReadLine());
            Console.Write("Paga por hora        : "); paga = float.Parse(Console.ReadLine());

            pagabruta = horas * paga;
            impuesto = pagabruta * tasa;
            paganeta = pagabruta - impuesto;

            Console.WriteLine("\n\n");
            Console.WriteLine("Estimado " + nombre);
            Console.WriteLine($"Trabajaste {horas} horas, con una paga por hora de {paga} \n");
            Console.WriteLine("Paga Bruta   : {0}", pagabruta);
            Console.WriteLine("Impuesto     : {0}", impuesto);
            Console.WriteLine("Paga Neta    : {0}", paganeta);
            Console.WriteLine("Trabajaste {0} horas, con una paga por hora de {1} \n",horas,paga);


            
        }
    }
}
