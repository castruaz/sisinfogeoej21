namespace _16CuentaBancariav1
{
    public class CuentaBancaria
    {
        private double saldo;

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

        public bool Retira(double cant) {
            if(saldo>=cant) {
                saldo-=cant;
                return true;
            } else
                return false;
        }
        
    }
}