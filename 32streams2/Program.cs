using System;
using System.IO;
using static System.Console;

namespace _32streams2
{
    class Program
    {
        static string ruta = Path.Combine(Environment.CurrentDirectory,"opciones.bin");

        static void Main(string[] args)
        {
            Console.WriteLine("\nLectura y Escritura de datos en un archivo binario");
            Escribir();
            Leer();
        }

        static void Escribir() {
            WriteLine("\nEscribiendo datos en un archivo en fomato binario");
            BinaryWriter fOps = new BinaryWriter( File.Open(ruta,FileMode.Create) );
            fOps.Write(1.25f);
            fOps.Write(@"c:\Temp");
            fOps.Write(10);
            fOps.Write(true);
            fOps.Close();
        }

        static void Leer() {
            float radio;
            string folder;
            int periodo;
            bool estado;
            WriteLine("Leyendo datos del archivo binario {0}", ruta);
            BinaryReader fOps = new BinaryReader( File.Open(ruta,FileMode.Open) );
            radio   = fOps.ReadSingle();
            folder  = fOps.ReadString();
            periodo = fOps.ReadInt32();
            estado  = fOps.ReadBoolean();
            WriteLine("\nRadio    = {0}", radio);
            WriteLine("\nRuta     = {0}", folder);
            WriteLine("\nPeriodo  = {0}", periodo);
            WriteLine("\nEstado   = {0}", estado);
            fOps.Close();
        }
    }
}
