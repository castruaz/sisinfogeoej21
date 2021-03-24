using System;
using System.Collections.Generic;

public class Red {

    public Red(){ Nodos=new List<Nodo>();}

    public Red(string empresa, string propietario, string domicilio) =>
        (Empresa, Propietario, Domicilio) = (empresa, propietario, domicilio);

    public String Empresa {get; set;}
    public String Propietario {get; set;}
    public String Domicilio {get; set;}
    public List<Nodo> Nodos {get; set;}

    public int MaySal() {
        int m=Nodos[0].Saltos;
        foreach(Nodo n in Nodos)  
            if(n.Saltos>m)
                m=n.Saltos;
        return m;
    }
    public int MenSal() {
        int m=Nodos[0].Saltos;
        foreach(Nodo n in Nodos)  
            if(n.Saltos<m)
                m=n.Saltos;
        return m;
    }
    public int TotVuln() {
        int s=0;
        foreach(Nodo n in Nodos)
            s+=n.Vulnerabilidades.Count;
        return s;
    }
    
}