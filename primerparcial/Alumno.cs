using System;
using System.Collections.Generic;

public class Alumno
{
    public Alumno(){}

    public Alumno(string nombre,int edad,DateTime fechaing,bool becado, int[] califs) =>
        (Nombre,Edad,FechaIng,Becado,Califs)=(nombre,edad,fechaing,becado,califs);

    public string Nombre {get;set;}
    public int Edad {get;set;}
    public DateTime FechaIng {get;set;}
    public bool Becado {get;set;}
    public int[] Califs {get;set;}

    public int Antiguedad()=>DateTime.Now.Year-FechaIng.Year;

    public int Prom() {
        int s=0;
        foreach(int c in Califs) s+=c;
        return s/3;
    }

    public string msj() => (Prom()>=7?"Aprobado":"Reporbado");

    public override string ToString() =>
        String.Format($"Nombre: {Nombre}, Edad: {Edad}, FechaIng: {FechaIng.ToString("dd/MM/yyyy")}, Becado: {(Becado?"Si":"No")}, ") +
        String.Format($"Califs: {string.Join(",",Califs)}, Antiguedad: {Antiguedad()}, Prom: {Prom()}, Mensaje: {msj()}");
   
}
