namespace _16CuentaBancariav1
{
    public class CuentaDeCheques : CuentaBancaria
    {
        private double proteccionsobregiro;

        public CuentaDeCheques(double saldo, double proteccionsobregiro) 
            : base(saldo)
        {
            this.proteccionsobregiro=proteccionsobregiro;
        }

        public override bool Retira(double cant)
        {
             bool resultado=true;
             double proteccionrequerida=cant-saldo;
             if(proteccionsobregiro<proteccionrequerida) {
                 return false;
             } else  {
                 saldo=0.0;
                 proteccionsobregiro-=proteccionrequerida;
             }
            return resultado;
        }
    }
}