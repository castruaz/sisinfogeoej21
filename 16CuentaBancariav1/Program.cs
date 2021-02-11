using System;

namespace _16CuentaBancariav1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool retiro;
            Banco mibanco = new Banco("La mina", "Carlos Castaneda");
            CuentaBancaria micuenta1 = new CuentaBancaria(100);
            CuentaBancaria micuenta2 = new CuentaBancaria(300);
            Cliente micliente1 = new Cliente("Juan Perez");
            Cliente micliente2 = new Cliente("Maria Ruiz");
            Cliente micliente3 = new Cliente();
            micliente3.Nombre="Miguel Mendoza";
            micliente1.Cuenta = micuenta1;
            micliente2.Cuenta = micuenta2;
            micliente3.Cuenta = new CuentaBancaria(10000);
            micuenta1.Deposita(300);
            retiro = micuenta2.Retira(500);
            if(retiro) Console.WriteLine("Retiro exitoso");
            else Console.WriteLine("No se puede retirar la cantidad solicitada");
            micliente3.Cuenta.Deposita(10000);
            micliente2.Cuenta.Retira(100);
            // Agregar clientes existentes al banco
            mibanco.AgregarCliente(micliente1);
            mibanco.AgregarCliente(micliente2);
            mibanco.AgregarCliente(micliente3);
            mibanco.AgregarCliente(new Cliente("Ruben Ibarra")); // crear y agregar un nuevo cliente
            mibanco.Clientes[3].Cuenta = new CuentaBancaria(50000); // crear y agregar una cuenta al nuevo cliente
            // Salida       
            Console.WriteLine("Control Bancario");
            Console.WriteLine("Saldo cuenta 1 : {0}", micuenta1.Saldo);
            Console.WriteLine("Saldo cuenta 1 : {0}", micuenta2.Saldo);
            Console.WriteLine("Cliente 1: Nombre: {0}, Saldo: {1}", micliente1.Nombre, micliente1.Cuenta.Saldo);
            Console.WriteLine("Cliente 2: Nombre: {0}, Saldo: {1}", micliente2.Nombre, micliente2.Cuenta.Saldo);
            Console.WriteLine("Cliente 3: Nombre: {0}, Saldo: {1}", micliente3.Nombre, micliente3.Cuenta.Saldo);
            // Imprimir reporte bancario
            Console.WriteLine("\nReporte Bancario ");
            Console.WriteLine($"Banco {mibanco.Nombre}, Propietario {mibanco.Propietario}");
            foreach(Cliente cte in mibanco.Clientes) {
                Console.WriteLine($"Nombre: {cte.Nombre}, Saldo:{cte.Cuenta.Saldo}");
            }
            Console.WriteLine("\nTotal de Clientes {0}", mibanco.Clientes.Count);
        }
    }
}
