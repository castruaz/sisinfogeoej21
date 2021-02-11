// Codigo client

using System;

namespace _15Objetos
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instanciar la clase y crear espacio en memoria para el objeto en la misma linea
            Empleado empleado1 = new Empleado();
            // Instanciar la clase, y luego en otra linea, crear el espacio para el objeto
            Empleado empleado2;
            empleado2 = new Empleado();

            Empleado empleado3 = new Empleado("Maria", 45);

            empleado1.Nombre="Juan";
            empleado1.Edad=25;
            empleado2.Nombre="Pedro";
            empleado2.Edad=30;

            Console.WriteLine("Empleado 1: {0} , {1}", empleado1.Nombre, empleado1.Edad);
            Console.WriteLine("Empleado 2: {0} , {1}", empleado2.Nombre, empleado2.Edad);
            Console.WriteLine("Empleado 3: {0} , {1}", empleado3.Nombre, empleado3.Edad);

            empleado1.CalcularVacaciones(DateTime.Parse("02/13/2021"),70);

        }
    }
}
