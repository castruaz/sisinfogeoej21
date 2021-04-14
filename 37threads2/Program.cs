using System;
using System.Threading;

namespace _37threads2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(args[0]);
            for(int i=1; i<=n; i++) {
                Thread t = new Thread(Imprime);
                t.Start(i);
            }
        }

        static void Imprime(Object o) {
            int s=0;
            for(int i=0; i<=5; i++) {
                Console.WriteLine($"Imprime en el thread {o} / {i}");
                s += i;
            }
            Console.WriteLine($"La suma del thread {o} = {s}");
        }
    }
}
