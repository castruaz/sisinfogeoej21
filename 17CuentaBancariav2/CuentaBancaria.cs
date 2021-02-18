namespace _16CuentaBancariav1
{
    public class CuentaBancaria
    {
        protected double saldo; // permite que las clases que herdan puedan acceder a esta variable

        public CuentaBancaria(double saldo) {
            this.saldo=saldo;
        }
        // Propiedad de solo lectura
        public double Saldo {
            get {return saldo;}
        }

        public void Deposita(double cant) {
            saldo+=cant;
        }

        public virtual bool Retira(double cant) { // este metodo pueda ser sobrecargado en la clases que lo heredan
            if(saldo>=cant) {
                saldo-=cant;
                return true;
            } else
                return false;
        }
        
    }
}