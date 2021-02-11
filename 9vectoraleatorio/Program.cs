// Programa que genera 2 vectores de 15 numeros aleatorios y los suma en un tercer vector

using System;

namespace _9vectoraleatorio
{
    class Program
    {
        static void Main(string[] args)
        {
            const int TAM=15;
            int[] A = new int[TAM];
            int[] B = new int[TAM];
            int[] C = new int[TAM];
            Random rnd = new Random();

            Console.WriteLine("Programa que genera 2 vectores de 15 numeros aleatorios y los suma en un tercer vector\n");

            for(int i=0; i<TAM; i++) {
                A[i]=rnd.Next(1,100);
                B[i]=rnd.Next(1,100);
                C[i]=A[i]+B[i];
            }
            Console.WriteLine("\nElementos en el vector A: "); imprime(A);
            Console.WriteLine("\nElementos en el vector B: "); imprime(B);
            Console.WriteLine("\nElementos en el vector C: "); imprime(C);
        }

        static void imprime(int[] v) {
            for(int i=0; i<v.Length; i++) 
                Console.Write("{0} ",v[i]);
        }
    }
}
