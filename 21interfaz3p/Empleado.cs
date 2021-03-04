using System;


public class Empleado : IComparable<Empleado>, IFormattable
{
    public string Paterno {get;set;}
    public string Materno {get; set;}
    public string Nombre {get; set;}
    public double Salario {get;set;}

    public int CompareTo(Empleado otro) {
        if(this.Salario<otro.Salario) return 1;
        else if(this.Salario>otro.Salario) return -1;
        else return 0;
    }

    public override string ToString() =>  $"{this.Nombre} -> {this.Salario}";
    
    public string ToString(string formato, IFormatProvider provedorformato) {
        switch(formato) {
            case "PMN" : return $"{Paterno,-10} {Materno,-10} {Nombre,-10} - {Salario,10:#,###.00}";
            case "NPM" : return $"{Nombre,-10} {Paterno,-10} {Materno,-10} - {Salario,10:#,###.00}" ;
            default: throw new FormatException("Formato Desconocido para empleado");
        }
    }
}