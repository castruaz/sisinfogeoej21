using System;

namespace _16CuentaBancariav1
{
    class Program
    {

        static void Main(string[] args) {
            
            Banco mibanco = new Banco("Patito SA de CV","Mac Pato");

            mibanco.AgregarCliente(new Cliente("Amalia Garcia")); // 0
            mibanco.AgregarCliente(new Cliente("Miguel Alonso")); // 1
            mibanco.AgregarCliente(new Cliente("Alejandro Tello")); // 2
            mibanco.AgregarCliente(new Cliente("Ricardo Moreal")); // 3

            mibanco.Clientes[0].AgregarCuenta(new CuentaDeAhorro(5000,.10));
            mibanco.Clientes[0].AgregarCuenta(new CuentaDeCheques(10000,400));
            mibanco.Clientes[1].AgregarCuenta(new CuentaDeAhorro(6000,.05));
            mibanco.Clientes[1].AgregarCuenta(new CuentaDeCheques(8000,300));
            mibanco.Clientes[2].AgregarCuenta(new CuentaDeAhorro(118000,400));
            mibanco.Clientes[3].AgregarCuenta(new CuentaDeAhorro(150000,0.4));
            mibanco.Clientes[3].AgregarCuenta(new CuentaDeAhorro(30000,0.3));


            Console.WriteLine("\nReporte Bancario");
            Console.WriteLine("Banco: {0} Propietario: {1}", mibanco.Nombre, mibanco.Propietario);
            foreach(Cliente cte in mibanco.Clientes) {
                Console.WriteLine($"Nombre: {cte.Nombre}, Tiene: {cte.Cuentas.Count} cuentas");
                foreach(CuentaBancaria cta in cte.Cuentas) {
                    Console.Write( (cta is CuentaDeCheques)  ? " Cuenta de Cheques:" : "Cuenta de Ahorro:" );
                    Console.WriteLine($"{cta.Saldo}");
                }
            }
        }

        static void PruebaCuentas()
        {
            CuentaDeAhorro  miahorro1 = new CuentaDeAhorro(5500,0.1);
            CuentaDeCheques micheque1 = new CuentaDeCheques(900,500);
            
            // miahorro
            miahorro1.Deposita(1500);
            miahorro1.Retira(100);
            Console.WriteLine("Mi ahorro 1 {0}",miahorro1.Saldo);
            miahorro1.CalcularIntereses();
            Console.WriteLine("Mi ahorro 1 {0}",miahorro1.Saldo);

            // micheque
            micheque1.Deposita(100);
            Console.WriteLine("Mi cheque 1 saldo: {0}", micheque1.Saldo);
            micheque1.Retira(1400);
            Console.WriteLine("Mi cheque 1 saldo: {0}", micheque1.Saldo);
            if(micheque1.Retira(150))
                Console.WriteLine("Retiro Exitoso");
            else
                Console.WriteLine("Te pasaste ....");
        }
    }
}
