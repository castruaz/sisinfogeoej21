// https://www.nuget.org/packages/Newtonsoft.Json/
// dotnet add package Newtonsoft.Json --version 12.0.3

using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using static System.Console;

namespace _34streams4_p
{
    public class Empleado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Salario {get; set;}
        public DateTime Fecha {get; set;}
        public override string ToString() => $"{Id} {Nombre,-12} {Salario,10:N0} {Fecha.ToString("dd/mmmm/yy")}";
    }

    class Program
    {
        static string ruta = Path.Combine(Environment.CurrentDirectory,"empleados.json");

        static void Main(string[] args)
        {
            Console.WriteLine("Serializar y Deserializar en formato json!");
            //SerializarJson();
            DeserializarJson();
        }

        static void DeserializarJson() {
            Console.WriteLine("\nDeserializar datos de empleados en: {0}",ruta);
            StreamReader femps = File.OpenText(ruta);
            string strEmpleados =  femps.ReadToEnd();

            List<Empleado> empleados = JsonConvert.DeserializeObject<List<Empleado>>(strEmpleados);
            
            empleados.ForEach(e=>Console.WriteLine(e.ToString()));
        }

        static void SerializarJson() {
            Console.WriteLine("\nSerializar datos en empleados en: {0}",ruta);
            List<Empleado> empleados = new List<Empleado>() {
                new Empleado {Id=1,Nombre="Juan Carlos",Salario=5300,Fecha=DateTime.Parse("1/1/2021")},
                new Empleado {Id=2,Nombre="Maria Lopez",Salario=2800,Fecha=DateTime.Parse("1/3/2021")},
                new Empleado {Id=3,Nombre="Gerado Jimez",Salario=1200,Fecha=DateTime.Parse("1/5/2021")},
            };
            StreamWriter fEmps = File.CreateText(ruta);
            JsonSerializer jsonEmp = new JsonSerializer();
            jsonEmp.Serialize(fEmps,empleados);
            fEmps.Close();
            empleados.ForEach(e=>Console.WriteLine(e.ToString()));
        }

    }
}
