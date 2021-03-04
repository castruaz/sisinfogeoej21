using System;
using System.Collections.Generic;

public class Escuela {

    public Escuela(){Profesores=new List<Profesor>();}

    public Escuela(string nombre,string encargado,string domicilio) =>
        (Nombre,Encargado,Domicilio)=(nombre,encargado,domicilio);

    public string Nombre {get; set;}
    public string Encargado {get; set;}
    public string Domicilio {get; set;}
    public List<Profesor> Profesores {get; set;}

    public int TotAlum() {
        int c=0;
        foreach(Profesor p in Profesores) 
            c+=p.Alumnos.Count;  
        return c;
    }

    public int TotBeca() {
        int c=0;
        foreach(Profesor p in Profesores) 
            c+=p.TotBecaP();
        return c;
    }

    public double TotSal() {
        double t=0;
        foreach(Profesor p in Profesores)
            t+=p.Salario;
        return t;
    }

    public override string ToString() =>
        string.Format($"Nombre   : {Nombre}\nEncargado: {Encargado}\nDomicilio: {Domicilio}\n\n") +
        String.Format($"Total profesores: {Profesores.Count}\nTotal alumnos : {TotAlum().ToString()}\n") +
        String.Format($"Total alumnos becados: {TotBeca().ToString()}\nTotal salario profesores: {TotSal().ToString()}" );

}