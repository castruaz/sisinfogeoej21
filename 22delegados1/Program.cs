using System;

// Delegado Simple
namespace _22delegados1 {

    public delegate void MiDelegado(string msj); // Creacion del delegado

    class program {
        public static void Main() { 
            MiDelegado d; // Creo una instancia del delegado
            d = Mensaje.Mensaje1; // Apunto el delegado a un metodo o funcion que coincide con la firma del delegado
            d("Juan"); // Invocando al delegado

            d = Mensaje.Mensaje2;
            d("Jose");

            d =  (string msj) => Console.WriteLine($"{msj} - paga todo que no pare la fiesta");
            d("Carlos");

            d
        }
    }

    public class Mensaje {
        public static void Mensaje1(string msj) => Console.WriteLine($"{msj} - lleva el pastel");
        public static void Mensaje2(string msj) => Console.WriteLine($"{msj} - fue el culpable se cancela la fiesta");

    }


}




