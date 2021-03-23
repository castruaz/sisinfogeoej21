using System;
using System.IO;
using static System.Console;

namespace _31streams1_p
{
    class Program
    {
        static void Main(string[] args)
        {
            ArchivoTexto();
           
        }

        public static void ArchivoTexto() {
            string[] materias = new string[] {"Matemáticas","Física","Química","Programación","Estadística","Seguridad"};
            string txtMaterias = Path.Combine(Environment.CurrentDirectory,"materias.txt");
            
            StreamWriter fMaterias = File.CreateText(txtMaterias);

            // Escribir líneas de texto
            WriteLine("Escribiendo la lista de materias en el archivo: {0}\n",txtMaterias);
            foreach(string m in materias) {
                WriteLine("{0}",m);
                fMaterias.WriteLine(m);
            }
            fMaterias.Close();

            FileInfo fInfo = new FileInfo(txtMaterias);
            string contenido = File.ReadAllText(txtMaterias);

            WriteLine("\nLeyendo del archivo {0}",txtMaterias);
            WriteLine("\nEl tamaño del archvivo es {0} bytes", fInfo.Length);
            WriteLine("\nEl archivo tiene el siguiente contenido: \n{0} ", contenido);
        }
    }
}
