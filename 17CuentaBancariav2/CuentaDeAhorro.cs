

namespace _16CuentaBancariav1
{
    public class CuentaDeAhorro : CuentaBancaria // herencia
    {
        private double tasadeinteres;

        public CuentaDeAhorro(double saldo, double tasadeinteres) 
            : base(saldo) // llamada al constructor de la clase base
        {
            this.tasadeinteres=tasadeinteres;
        }
        public void CalcularIntereses() {
            saldo+= saldo*tasadeinteres;
        }
        
    }
}