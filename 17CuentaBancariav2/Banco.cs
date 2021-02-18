using System.Collections.Generic;

namespace _16CuentaBancariav1
{
    public class Banco
    {
        private string nombre;
        private string propietario;
        private List<Cliente> clientes; // definir una lista del tipo Cliente

        public Banco(string nombre, string propietario) {
            this.nombre=nombre;
            this.propietario=propietario;
            clientes=new List<Cliente>(); //crea espacio en memoria para la lista
        }

        public string Nombre
        {
            get { return nombre; }
        }
        
        public string Propietario
        {
            get { return propietario; }
        }

        public List<Cliente> Clientes { // Regresa la lista de clientes
            get {return clientes;}
        }

        public void AgregarCliente(Cliente cliente) { // Agrega un cliente a la lista
            clientes.Add(cliente);
        }

            
    }
}