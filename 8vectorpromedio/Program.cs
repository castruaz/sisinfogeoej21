
// 8 Programa que calcula el promedio de un vector de 50 valores constantes

using System;

namespace _8vectorpromedio
{
    class Program
    {
        static void Main(string[] args)
        {
            // Definimos un arreglo con 50 valores constantes
            int[] vector = {10,15,20,25,30,35,40,45,50,55, 
                            10,15,20,25,30,35,40,45,50,55,
                            10,15,20,25,30,35,40,45,50,55,
                            10,15,20,25,30,35,40,45,50,55,
                            10,15,20,25,30,35,40,45,50,55};

            int suma=0, nmp=0;
            float promedio=0;

            Console.WriteLine("Programa que calcula el promedio de un vector de 50 valores constantes");
            // Calcular suma de los elmentos del arreglo
            for(int i=0; i<vector.Length; i++) {
                Console.Write("{0} ",vector[i]);
                suma+=vector[i];
            }
            // Calcular promedio
            promedio= suma / vector.Length;
            // Contar cuantos elementos del arreglo son mayors al promedio
            Console.WriteLine("\n\n");
            Console.WriteLine("\nLa suma de los numeros del vector es     : {0}", suma);
            Console.WriteLine("\nEl promedio de los numeros del vector es : {0}\n\n", promedio);
            for(int i=0; i<vector.Length; i++) {
                 if(vector[i]>promedio) {
                     Console.Write("{0} ",vector[i]);
                     nmp++;
                 }
            }
            Console.WriteLine("\nLos numeros mayores al promedio son {0}",nmp);
        }
    }
}
