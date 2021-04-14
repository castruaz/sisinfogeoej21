using System;
using System.Threading;

namespace _39threads4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando Thread Principal ...");

            Thread t1 = new Thread(Metodo1) {Name = "Thread A"};
            Thread t2 = new Thread(Metodo2) {Name = "Thread B"};
            Thread t3 = new Thread(Metodo3) {Name = "Thread C"};
            t1.Start();
            t2.Start();
            t3.Start();

            Console.WriteLine("Terminando Thread Principal ...");
        }
        static void Metodo1() {
            Console.WriteLine($"Metodo 1 iniciado usando {Thread.CurrentThread.Name}");
            for(int i=1; i<=5; i++) {
                Console.WriteLine($"Metodo 1: {i}");
            }
            Console.WriteLine($"Metodo 1 terminado usando {Thread.CurrentThread.Name}");
        }
        static void Metodo2() {
            Console.WriteLine($"Metodo 2 iniciado usando {Thread.CurrentThread.Name}");
            for(int i=1; i<=5; i++) {
                Console.WriteLine($"Metodo 2: {i}");
                if( i== 3) {
                    Console.WriteLine("Iniciando operación sobre la base de datos en Metodo 2..");
                    Thread.Sleep(10000);
                    Console.WriteLine("Operación sobre la base de datos terminada en Metodo 2.");
                }
            }
            Console.WriteLine($"Metodo 2 terminado usando {Thread.CurrentThread.Name}");
        }
        static void Metodo3() {
            Console.WriteLine($"Metodo 3 iniciado usando {Thread.CurrentThread.Name}");
            for(int i=1; i<=5; i++) {
                Console.WriteLine($"Metodo 3: {i}");
            }
            Console.WriteLine($"Metodo 3 terminado usando {Thread.CurrentThread.Name}");
        }
    }
}
