using System;
using static System.Console;
using System.Linq;
using System.Collections.Generic;

namespace _27linq1
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. fuente datos
            int[] numeros = new int[] {10,25,-1,10,0,20,22,65,800,-4,20,20,1000,2000,-233};

            // imprimir numeros pares
            WriteLine("Listado de numeros pares de manera convencional");
            for(int i=0; i<numeros.Length; i++) {
                if((numeros[i]%2)==0)
                    Write($"{numeros[i]} ");
            }

            // 2. Crear consulta Linq para obtener numeros pares
            IEnumerable<int> qrypares = from num in numeros where (num%2)==0 select num;

            // 3. Ejecutar consulta Linq
            WriteLine("\nListado de numeros pares usando consulta Linq");
            foreach(int n in qrypares) 
                Write($"{n} ");

            WriteLine("\nListado de numeros impares usando consulta Linq y el resultado en formato de arreglo");
            var qryimpares = (from num in numeros where (num%2)!=0 select num).ToArray();
            foreach(int n in qryimpares) 
                Write($"{n} ");

            WriteLine("\nListado de numeros mayors a 20 y 1000 usando Linq y el resultado en formato de lista");
            var mayores = (from num in numeros where (num>=20 && num<=1000) && num%2==0  select num).ToList();
            mayores.ForEach(n=>Write($"{n} "));
            


        }
    }
}
