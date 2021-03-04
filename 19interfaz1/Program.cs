using System;

namespace _19interfaz1
{
    class Program
    {
        public interface IAnimal {
            string Nombre {get; set;}
            void Llorar();
        }

        class Perro : IAnimal {
            public Perro(string nombre) => Nombre = nombre;
            public string Nombre {get; set;}
            public void Llorar() => Console.WriteLine("Woff Woff");
        }

        class Gato : IAnimal {
            public Gato(string nombre, string raza) => (Nombre,Raza) = (nombre, raza);
            public string Nombre {get; set;}
            public string Raza {get; set;}
            public void Llorar() => Console.WriteLine("Miau Miau");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Primer ejemplo de uso de interfaces");

            Perro miperro = new Perro("El capitan");
            Console.WriteLine($"El perro {miperro.Nombre}, llora asi :");
            miperro.Llorar();

            Gato migato = new Gato("Misifus","Angora");
            Console.WriteLine($"El gato {migato.Nombre} de raza {migato.Raza} lloara asi:" );
            migato.Llorar();

        }
    }
}
