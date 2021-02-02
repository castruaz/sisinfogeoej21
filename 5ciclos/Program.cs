using System;

namespace _5ciclos
{
    class Program
    {
        static int Main(string[] args)
        {
            int op, c,suma;
            if(args.Length==0) {
                Menu();
                return 1;
            }
            op=int.Parse(args[0]);
            switch(op) {
                case 1: { // numeros del 1 al 100 con while
                    c=1;suma=0;
                    while(c<=100) {
                        Console.Write("{0} ",c);
                        suma+=c;
                        c++;
                    }
                    Console.WriteLine("\nLa suma es {0}",suma);
                    } break;
                case 2: { // numeros del 100 al 1 con do .. while
                    c=100;suma=0;
                    do {
                        Console.Write("{0} ",c);
                        suma+=c;
                        c--;
                    } while(c>=1);
                    Console.WriteLine("\nLa suma es {0}",suma);
                    } break;
                case 3 : {  // numeros del 50 al 200 con for
                    suma=0;
                    for(c=50; c<=200; c++) {
                        Console.Write("{0} ",c);
                    }
                    Console.WriteLine("\nLa suma es {0}",suma);
                } break;
                case 4 : { // numeros del 2 al 100 los pares con for
                    suma=0;
                    for(c=2; c<=100; c+=2) {
                        Console.Write("{0} ",c);
                    }
                    Console.WriteLine("\nLa suma es {0}",suma);
                } break;
                case 5 : { // numeros del 99 al 1 impares con for
                    suma=0;
                    for(c=99; c>=1; c-=2) {
                        Console.Write("{0} ",c);
                    }
                    Console.WriteLine("\nLa suma es {0}",suma);
                } break;
                case 6: { // numeros 272 al 40 decrementos de 4 con do .. while
                    c=272;suma=0;
                    do {
                        Console.Write("{0} ",c);
                        suma+=c;
                        c-=4;
                    } while(c>=4);
                    Console.WriteLine("\nLa suma es {0}",suma);
                    } break;
                default: 
                    Console.WriteLine("Opcion no implementada");
                    break;
            }
            return 0;
        }

        static void Menu() {
            Console.Clear();
            Console.WriteLine("[ 1 ] Numeros del 1 al 100 usando un ciclo while");
            Console.WriteLine("[ 2 ] Números del 100 al 1 con ciclo do .. while");
            Console.WriteLine("[ 3 ] Números del 50 al 200 con ciclo for");
            Console.WriteLine("[ 4 ] Números del 2 al 100 solo los pares con ciclo for");
            Console.WriteLine("[ 5 ] Números del 99 al 1 solo los impares con ciclo for");
            Console.WriteLine("[ 6 ] Números del 272 al 40 en decrementos de 4 con ciclo while");
        }
    }
}
