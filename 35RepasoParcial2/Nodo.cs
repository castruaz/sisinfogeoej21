using System;
using System.Collections.Generic;

public class Nodo {

    public Nodo() {Vulnerabilidades=new List<Vulnerabilidad>();}

    public Nodo(string ip,string tipo,int puertos,int saltos,string so) =>
    (Ip,Tipo,Puertos,Saltos,So) = (ip,tipo,puertos,saltos,so);

    public String Ip {get; set;}
    public String Tipo {get; set;}
    public int Puertos {get; set;}
    public int Saltos {get; set;}
    public String So {get; set;}
    public List<Vulnerabilidad> Vulnerabilidades {get; set;}

    public override string ToString() =>
         $"Ip: {Ip,-10} Tipo: {Tipo,-12} Puertos: {Puertos.ToString(),-3} " +
         $"Saltos: {Saltos.ToString(),-3} So: {So,-8} Totvul: {Vulnerabilidades.Count.ToString()}";
}