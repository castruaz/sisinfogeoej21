using System;
using System.Threading;

namespace _38threads3
{
    class Impresora {
        public void Imprime(object o) {
            lock(this) {
                for(int i=1; i<=10; i++) {
                    Thread.Sleep(100);
                    Console.WriteLine($"{o} - {i}");
                }
            }
            Console.WriteLine("......");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Impresora i = new Impresora();
            Thread t1 = new Thread(i.Imprime);
            Thread t2 = new Thread(i.Imprime);
            t1.Start(t1.ManagedThreadId);
            t2.Start(t2.ManagedThreadId);

            i.Imprime(Thread.CurrentThread.ManagedThreadId);
        }
    }
}
