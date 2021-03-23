using System;
using System.IO;

namespace _32streams2_p
{
    class Program
    {
        static string ruta = Path.Combine(Environment.CurrentDirectory,"opciones.bin");

        static void Main(string[] args)
        {
            Console.WriteLine("Streams de datos binarios");
            EscribirDatos();
            LeerDatos();            
        }

        static void EscribirDatos() {
            Console.WriteLine("\nEscribiendo Datos en un archivo en formato binario ...");
            BinaryWriter fOpciones = new BinaryWriter(File.Open(ruta,FileMode.Create));
            fOpciones.Write(1.250F);
            fOpciones.Write(@"c:\Temp");
            fOpciones.Write(10);
            fOpciones.Write(true);
            fOpciones.Close();
        }

        static void LeerDatos() {
            float radio;
            string dirTemporal;
            int tiempoGuardadoAutomatico;
            bool mostrarBarraEstado;
            Console.WriteLine("\nLeyendo datos de un archivo binario");
            using(BinaryReader fOps = new BinaryReader(File.Open(ruta,FileMode.Open))) {
                radio = fOps.ReadSingle();
                dirTemporal = fOps.ReadString();
                tiempoGuardadoAutomatico = fOps.ReadInt32();
                mostrarBarraEstado = fOps.ReadBoolean();
            }
            Console.WriteLine("Radio: {0}", radio);
            Console.WriteLine("Directorio temporal: {0}", dirTemporal);
            Console.WriteLine("Tiempo de autoguardado: {0}", tiempoGuardadoAutomatico);
            Console.WriteLine("Mostrar barra de estado: {0}", mostrarBarraEstado);
        }
}
}
