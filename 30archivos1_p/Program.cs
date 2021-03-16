using System;
using System.IO;
using static System.Console;
using static System.IO.Path;
using static System.IO.Directory;
using static System.Environment;

namespace _30archivos1_p
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Trabajando con archivos:");
            //SistemaArchivos();
            //UnidadesDisco();
            //Directorios();
            Archivos();
        }

        static void SistemaArchivos() {
            WriteLine("\nSistema de archivos:");
            WriteLine("{0,-33} {1}", "Separador de ruta :", PathSeparator);
            WriteLine("{0,-33} {1}", "Separador de directorios :", DirectorySeparatorChar);
            WriteLine("{0,-33} {1}", "Directorio actual:", GetCurrentDirectory());
            WriteLine("{0,-33} {1}", "Directorio del sistema ", SystemDirectory);
            WriteLine("{0,-33} {1}", "Directorio temporal ", GetTempPath());
            WriteLine("{0,-33} {1}", "Directorio del sistema ", GetFolderPath(SpecialFolder.System));
            WriteLine("{0,-33} {1}", "Directorio de datos de aplicación",GetFolderPath(SpecialFolder.ApplicationData));
            WriteLine("{0,-33} {1}", "Directorio Mis Documentos", GetFolderPath(SpecialFolder.MyDocuments));
            WriteLine("{0,-33} {1}", "Directorio Personal", GetFolderPath(SpecialFolder.Personal));
        }

        static void UnidadesDisco() {
            WriteLine("\n");
            WriteLine("{0,-30} | {1,-10} | {2,-7} | {3,18} | {4,18}","Nombre", "Tipo", "Formato", "Tamaño (Bytes)", "Espacio Libre");
            foreach(DriveInfo drive in DriveInfo.GetDrives()) {
                if (drive.IsReady) {
                    WriteLine("{0,-30} | {1,-10} | {2,-7} | {3,18:N0} | {4,18:N0}", 
                        drive.Name, drive.DriveType, drive.DriveFormat, drive.TotalSize, drive.AvailableFreeSpace);
                } else 
                    WriteLine("{0,-30} | {1,-10}", drive.Name, drive.DriveType);
            }
        }

        static void Directorios() {
            // define una ruta de directorio para una nueva carpeta, comenzado por la carpeta de usuario
            var nuevaCarpeta = Combine(GetFolderPath(SpecialFolder.Personal),"programas","codigofuente");

            WriteLine($"\nTrabajando con: {nuevaCarpeta}");
 
            // revisa si existe
            WriteLine($"El directorio ya existe? {Exists(nuevaCarpeta)}");
            
            // creando directorio
            WriteLine($"\nCreando el directorio ...");
            CreateDirectory(nuevaCarpeta); 
            Write("Confirma que el directorio existe, y luego presiona <Enter>");
            ReadLine();

            // borrando directorio
            WriteLine($"\nBorrando el directorio con todo su contenido recursivamente ...");
            Delete(nuevaCarpeta,recursive:true);
            WriteLine($"El directorio existe ? - {Exists(nuevaCarpeta)}");
        }

        static void Archivos() {
             var dir = Combine(GetFolderPath(SpecialFolder.Personal),"programas","archivos");
             string archTexto = Combine(dir,"notas.txt");
             string archRespaldo = Combine(dir,"notas.bak");

             if(!Exists(dir)) CreateDirectory(dir);

             // revisa si existe
             WriteLine($"Existe el archivo de Texto ? {File.Exists(archTexto)}");
             
             //crea un nuevo archivo de texto y escribe una linea en el
             StreamWriter txt = File.CreateText(archTexto);
             txt.WriteLine("Hola C#");
             txt.Close();
             WriteLine($"Existe el archivo de Texto ? {File.Exists(archTexto)}");

             // copia ela rchivo, y sobreescribe si esta ya existe
             File.Copy(sourceFileName:archTexto, destFileName:archRespaldo,  overwrite:true);
             WriteLine($"Existe el archivo de respaldo? {File.Exists(archRespaldo)}");
             WriteLine("Confirm que el archivo existe, y luego presiona <ENTER>:");
             ReadLine();

             // borra el archivo
            File.Delete(archTexto);
            WriteLine($"Existe el archivo de Texto ? {File.Exists(archTexto)}");

            // leer del archivo de respaldo
            WriteLine($"Leyebdo el contenido de {archRespaldo}");
            StreamReader res = File.OpenText(archRespaldo);
            WriteLine(res.ReadToEnd());
            res.Close();

            // manejando rutas
            WriteLine("\nManejo de rutas :");
            WriteLine($"Nombre del directorio : {GetDirectoryName(archTexto)}");
            WriteLine($"Nombre del archivo : {GetFileName(archTexto)}");
            WriteLine($"Nombre del archivo sin extensión: {GetFileNameWithoutExtension(archTexto)}");
            WriteLine($"Extensión del archivo : {GetExtension(archTexto)}");
            WriteLine($"Nombre de archivo aleatorio : {GetRandomFileName()}");
            WriteLine($"Nombre del archivo temporal : {GetTempFileName()}");

            // Informacion de archivos
            var info = new FileInfo(archRespaldo);
            WriteLine("\nInformación del archivo :");
            WriteLine($"{archRespaldo}");
            WriteLine($"Contiene {info.Length} bytes");
            WriteLine($"Ultima vez que se acceso : {info.LastAccessTime}");
            WriteLine($"Tiene el bit de solo lectura en : {info.IsReadOnly}");

        }

    }
}
