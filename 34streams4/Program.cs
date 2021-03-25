using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using static System.Console;

namespace _34streams4
{
    public class Empleado {
        public int Id { get; set;}
        public string Nombre {get; set;}
        public double Salario {get; set;}
        public override string ToString() => $"Id:{Id,-3}, Nombre:{Nombre,-12}, Salario: {Salario,10:N0}";
    }

    class Program
    {
        static string ruta = Path.Combine(Environment.CurrentDirectory,"datos.json");

        static void Main(string[] args)
        {
            Console.WriteLine("Escribir y Leer datos en formato Json");
            List<Empleado> emps = new List<Empleado>() {
                new Empleado {Id=1, Nombre="Juan Perez",Salario=5300},
                new Empleado {Id=2, Nombre="Maria Lopez",Salario=6500},
                new Empleado {Id=3, Nombre="Gerardo Jimenez",Salario=15300},
                new Empleado {Id=4, Nombre="Claudia Reyes",Salario=30000}
            };
            WriteLine("\nSerializando datos  ...");
            emps.ForEach(e=>WriteLine(e.ToString()));
            StreamWriter fEmps = File.CreateText(ruta);
            JsonSerializer jsonEmp = new JsonSerializer();
            jsonEmp.Serialize(fEmps,emps);
            fEmps.Close();

            WriteLine("\nDeserializando datos en el archivo: {0} ", ruta);
            StreamReader fEmps2 = File.OpenText(ruta);
            string txtemps2 = fEmps2.ReadToEnd();
            List<Empleado> emps2 = JsonConvert.DeserializeObject<List<Empleado>>(txtemps2);
            emps2.ForEach(e=>WriteLine(e.ToString()));

        }
    }
}
