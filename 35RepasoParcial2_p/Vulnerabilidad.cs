using System;

public class Vulnerabilidad {

    public Vulnerabilidad() {}

    public Vulnerabilidad(string clave,string vendedor,string descripcion,string tipo,DateTime fecha) =>
    (Clave,Vendedor,Descripcion,Tipo,Fecha) = (clave,vendedor,descripcion,tipo,fecha);

    public string Clave {get; set;}
    public string Vendedor {get; set;}
    public string Descripcion {get; set;}
    public string Tipo {get; set;}
    public DateTime Fecha {get; set;}

    public int Antiguedad() => DateTime.Now.Year - Fecha.Year;

    public override string ToString() =>
        String.Format($"Clave:{Clave},Vendedor:{Vendedor},Descripcion:{Descripcion},Tipo:{Tipo},Fecha:{Fecha.ToString("dd/mm/yy")},Antiguedad:{Antiguedad().ToString()}");
     
}