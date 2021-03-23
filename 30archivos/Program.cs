using System;
using static System.Console;
using System.IO;
using static System.IO.Path;
using static System.IO.Directory;
using static System.Environment;


namespace _30archivos
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Trabajando con Información del Sistema, Archivos y Rutas");
            //SistemaArchivos();
            //UnidadesDisco();
            //Directorios();
            Archivos();
        }

        static void Archivos() {
            WriteLine("\nTrabajando con Archivos:");
            var dir = Combine(GetCurrentDirectory(),"datos","archivo");
            string archTexto = Combine(dir,"notas.txt");
            string archRespaldo = Combine(dir,"notas.bak");

            // revisar si existe la ruta donde estarn los archivos
            if(!Exists(dir))
                CreateDirectory(dir);
            // revisar si existe el archivo de texto
            WriteLine($"Existe el archivo de texto ? {File.Exists(archTexto)}");
            // crear un archivo de texto nuevo y escribir una linea en el
            WriteLine("Creando archivo de texto ...");
            StreamWriter txt = File.CreateText(archTexto);
            txt.WriteLine("Saludos desde un archivo de texto creado en C#");
            txt.Close();
            WriteLine($"Existe el archivo de texto ? {File.Exists(archTexto)}");
            // crear una copia del archivo original
            WriteLine("Creando una copia del archivo de texto");
            File.Copy(sourceFileName:archTexto,destFileName:archRespaldo,overwrite:true);
            WriteLine($"Existe el archivo de respaldo? {File.Exists(archRespaldo)}");
            WriteLine("Confirma que el archivo existe, luego presiona <Enter>");
            ReadLine();
            // borrar archivo de respaldo
            File.Delete(archRespaldo);
            WriteLine($"Existe el archivo de respaldo? {File.Exists(archRespaldo)}");
            // leer archivo de texto
            WriteLine($"Leyendo contenido del archivo de texto: {GetFileName(archTexto)}");
            StreamReader res = File.OpenText(archTexto);
            WriteLine(res.ReadToEnd());
            res.Close();
            // informacion del aarchivo 
            var info = new FileInfo(archTexto);
            WriteLine("\nInformacion sobre un archivo existente");
            WriteLine($"El archivo {archTexto}");
            WriteLine($"Nombre del archvo: {GetFileName(archTexto)},  Extension:{GetExtension(archTexto)}");
            WriteLine($"Contiene {info.Length} bytes");
            WriteLine($"Ultima vez que se acceso: {info.LastAccessTime}");
            WriteLine($"Es de solo lectura ? {info.IsReadOnly}"); 
            WriteLine($"Fecha de creación: {info.CreationTime}");
            // cambiar nombre al rachivo
            WriteLine("Cambiando el nombre al archivo");
            string nvoNombre = Combine(dir,"apuntes.doc");
            File.Move(sourceFileName:archTexto,nvoNombre,overwrite:true);
            WriteLine($"Existe el archivo renombrado? {File.Exists(nvoNombre)}");
        }

        static void Directorios() {
            WriteLine("\nTrabajando con Directorios:");
            var nvaCarpeta = Combine(GetCurrentDirectory(),"datos","codigofuete");
            WriteLine($"Trabajando con: {nvaCarpeta}");
            // revisar si existe
            WriteLine($"El directorio ya existe ? {Exists(nvaCarpeta)}");
            // Creando directorio
            WriteLine("Creando directorio ...");
            CreateDirectory(nvaCarpeta);
            WriteLine($"El directorio ya existe ? {Exists(nvaCarpeta)}");
            WriteLine("Confirma que el directorio existe, luego presiona <Enter>");
            ReadLine();
            // borrar directorio
            WriteLine("Borrando el directorio y su contentenidos ...");
            Delete(nvaCarpeta,recursive:true);
            WriteLine($"El directorio ya existe ? {Exists(nvaCarpeta)}");
        }


        static void UnidadesDisco() {
            WriteLine("\nTrabajando con Unidades de disco Lógicas:");
            WriteLine("|{0,-30}|{1,-10}|{2,-7}|{3,18}|{4,18}", "Nombre", "Tipo","Formato","Tamaño","Espacio Libre");
            foreach(DriveInfo drive in DriveInfo.GetDrives()) {
                if(drive.IsReady) {
                    WriteLine("{0,-30} {1,-10} {2,-7} {3,18:N0} {4,18:N0}",drive.Name,drive.DriveType,drive.DriveFormat,drive.TotalSize,drive.AvailableFreeSpace);
                } else {
                    WriteLine("{0,-30} {1,-10}",drive.Name,drive.DriveType);
                }
            }
        }

        static void SistemaArchivos() {
            WriteLine("\nInformación del Sistema de Archivos");
            WriteLine("{0,-33} {1}","Seperado de ruta :", PathSeparator);
            WriteLine("{0,-33} {1}","Seperado de directorios:", DirectorySeparatorChar);
            WriteLine("{0,-33} {1}","Directorio actual:", GetCurrentDirectory());
            WriteLine("{0,-33} {1}","Directorio del sistem:", SystemDirectory);
            WriteLine("{0,-33} {1}","Directorio temporal:", GetTempPath());
            WriteLine("{0,-33} {1}","Directorio del Sistema:", GetFolderPath(SpecialFolder.System));
            WriteLine("{0,-33} {1}","Directorio de Mis Documents", GetFolderPath(SpecialFolder.MyDocuments));
            WriteLine("{0,-33} {1}","Directorio de datos de aplicacion", GetFolderPath(SpecialFolder.ApplicationData));
            WriteLine("{0,-33} {1}","Directorio personal", GetFolderPath(SpecialFolder.Personal));
        }
    }
}
