using System;

public class Vulnerabilidad: IFormattable {

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
        $"Clave: {Clave,-12} Vendedor: {Vendedor,-10} Descripcion: {Descripcion,-63} Tipo: {Tipo,-8}" +
        $"Fecha: {Fecha.ToString("dd/mm/yy"),-8} Antiguedad: {Antiguedad().ToString()}";
    
    public string ToString(string formato, IFormatProvider proveedor) {
        switch(formato) {
            case "D1" : return  $"Clave: {Clave,-12} Vendedor: {Vendedor,-10} Tipo: {Tipo,-8}";
            case "D2" : return  $"Clave: {Clave,-12} Vendedor: {Vendedor,-10} Tipo: {Tipo,-8} Fecha: {Fecha.ToString("dd/mm/yy"),-8}";
            default: return "";                  
        }
    }
     
}