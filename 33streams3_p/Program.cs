using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace _33streams3_p
{
    [Serializable]
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
        static string ruta = Path.Combine(Environment.CurrentDirectory,"empleados.xml");

        static void Main(string[] args)
        {
            Console.WriteLine("Serializar y Deserializar en formato XML!");
            SerializarXml();
            DeserializarXml();
        }

        static void DeserializarXml() {
            Console.WriteLine("\nDeserializar datos de empleados en: {0}",ruta);
            FileStream fEmps = File.Open(ruta,FileMode.Open);
            XmlSerializer xmlEmp = new XmlSerializer(typeof(List<Empleado>));
            List<Empleado> empleados = (List<Empleado>)xmlEmp.Deserialize(fEmps);
            empleados.ForEach(e=>Console.WriteLine(e.ToString()));
        }

        static void  SerializarXml() {
            Console.WriteLine("\nSerializar datos en empleados en: {0}",ruta);
            List<Empleado> empleados = new List<Empleado>() {
                new Empleado {Id=1,Nombre="Juan Carlos",Salario=5300,Fecha=DateTime.Parse("1/1/2021")},
                new Empleado {Id=2,Nombre="Maria Lopez",Salario=2800,Fecha=DateTime.Parse("1/3/2021")},
                new Empleado {Id=3,Nombre="Gerado Jimez",Salario=1200,Fecha=DateTime.Parse("1/5/2021")},
            };
            empleados.ForEach(e=>Console.WriteLine(e.ToString()));
            FileStream fEmps = File.Open(ruta,FileMode.Create);
            XmlSerializer xmlEmp = new XmlSerializer(typeof(List<Empleado>));
            xmlEmp.Serialize(fEmps,empleados);
            fEmps.Close();
        }
    }
}
