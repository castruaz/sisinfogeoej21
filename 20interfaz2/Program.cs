using System;

namespace _20interfaz2
{
    public class Organismo {
        public Organismo(string nombre)=>Nombre=nombre;
        public string Nombre {get; set;}
        public void Respiracion() => Console.WriteLine("Respirando..");
        public void Movimiento() => Console.WriteLine("Moviendose..");
        public void Crecimiento() => Console.WriteLine("Creciendo..");
    }

    public interface IAnimales {
        void MultiCelular();
        void SangreCaliente();
    }

    public interface ICanino : IAnimales {
        void Correr();
        void CuatroPatas();
    }

    public interface IAve : IAnimales, I {
        void Volar();
        void DosPatas();
    }

    public class Perro : Organismo, ICanino  {
        public Perro(string nombre): base(nombre) {}
        public void MultiCelular()=>Console.WriteLine("Multicelilar perro");
        public void SangreCaliente()=>Console.WriteLine("Sangrecaliente perro");
        public void Correr()=>Console.WriteLine("Corre perro");
        public void CuatroPatas()=>Console.WriteLine("Cuatropatas perro");
    }

    public class Perico : Organismo, IAve {
        public Perico(string nombre): base(nombre) {}
        public void MultiCelular()=>Console.WriteLine("Multicelilar perico");
        public void SangreCaliente()=>Console.WriteLine("Sangrecaliente perico");
        public void Volar()=>Console.WriteLine("Volar perico");
        public void DosPatas()=>Console.WriteLine("Dospatas perico");
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Segundo ejemplo de Intrfaces");
            Perro miperro = new Perro("Lassie");
            Console.WriteLine($"Mi perro llamado {miperro.Nombre} esta haciendo lo siguiente");
            miperro.Respiracion();
            miperro.Movimiento();
            miperro.Crecimiento();
            miperro.MultiCelular();
            miperro.SangreCaliente();
            miperro.Correr();
            miperro.CuatroPatas();

            Perico miperico = new Perico("Sparrow");
            Console.WriteLine($"Mi perico llamado {miperico.Nombre} esta haciendo lo siguiente");
            miperico.Respiracion();
            miperico.Movimiento();
            miperico.Crecimiento();
            miperico.MultiCelular();
            miperico.SangreCaliente();
            miperico.Volar();
            miperico.DosPatas();
        
        }
    }
}
