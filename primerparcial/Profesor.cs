using System;
using System.Collections.Generic;

public class Profesor
{
    public Profesor(){Alumnos=new List<Alumno>();}
    
    public Profesor(string nombre,DateTime fechaing,string grupo,string materia,double salario) =>
        (Nombre,FechaIng,Grupo,Materia,Salario)=(nombre,fechaing,grupo,materia,salario);

    public string Nombre {get;set;}
    public DateTime FechaIng {get;set;}
    public string Grupo {get;set;}
    public string Materia {get;set;}
    public double Salario {get;set;}
    public List<Alumno> Alumnos {get;set;}

    public string Antiguedad() => (DateTime.Now.Year - FechaIng.Year).ToString();

    public int MayP() {
        int m=Alumnos[0].Prom();
        foreach(Alumno a in Alumnos)
            if(a.Prom()>m) m=a.Prom();
        return m;
    }

    public int MenP() {
        int m=Alumnos[0].Prom();
        foreach(Alumno a in Alumnos)
            if(a.Prom()<m) m=a.Prom();
        return m;
    }

   public int TotBecaP() {
        int c=0;
        foreach(Alumno a in Alumnos)
            c+=(a.Becado?1:0);
        return c;
    }

    public override string ToString() =>
        String.Format($"Nombre: {Nombre,-12}, FechaIng: {FechaIng.ToString("dd-MM-yyyy")}, Grupo: {Grupo}, Materia: {Materia,-7}, ") +
        String.Format($"Salario: {Salario:C}, Alumnos: {Alumnos.Count}, Antiguedad: {Antiguedad()}");

    public string Resumen() => String.Format($"\nMayor Promedio: {MayP()}\nMenor Promedio: {MenP()}\nTotal becados:{TotBecaP()}");

}
 