using System;

namespace _6pizza
{
    class Program
    {
        static int Main(string[] args)
        {
            char tam, cub, don;
            string[] ings;

            string tamaño="", ingredientes="", cubierta, donde;

            if(args.Length==0) {
                Menu();
                return 1;

            }
            // Elegir tamaño
            tam=char.Parse(args[0].ToUpper());
            if(tam=='P') tamaño="Pequeña";
            else if(tam=='M') tamaño="Mediana";
            else tamaño="Grande";

            // Elegir ingredientes
            ings=args[1].Split("+");
            foreach(string i in ings) {
                switch(char.Parse(i.ToUpper())) {
                    case 'E' : ingredientes+="Extraqueso ";break;
                    case 'C' : ingredientes+="Champiñones ";break;
                    case 'P' : ingredientes+="Piña ";break;
                }
            }
            // Tipo de Cubierta
            cub=char.Parse(args[2].ToUpper());
            cubierta= (cub=='D' ? "Delgada": "Gruesa");
            // Donde la consume
            don=char.Parse(args[3].ToUpper());
            donde= (don=='A' ? "Aqui": "Llevar");
            // Resultado del pedido
            Console.WriteLine("Tu pizza queda asi\n");
            Console.WriteLine("Tamaño      : {0} ",tamaño);
            Console.WriteLine("Ingredientes: {0} ",ingredientes);
            Console.WriteLine("Cubierta    : {0} ",cubierta);
            Console.WriteLine("Consumes    : {0} ",donde);
            
            return 0;
        }

        static void Menu() {
            Console.Clear();
            Console.WriteLine("\nElije como deseas armar tu pedido de pizza \n");
            Console.WriteLine("Tamaño: [P]equeña   [M]ediana   [G]rande");
            Console.WriteLine("Ingredientes: [E]xtra queso, [C]hampiñoness, [P]iña , unidos por un +");
            Console.WriteLine("Cubierta: [D]elgada  [G]ruesa");
            Console.WriteLine("Donde la consumes: [A]qui   [L]levar");
        }
    }
}
