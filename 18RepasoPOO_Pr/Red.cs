using System;
using System.Collections.Generic;
 
public class Red
{

    public String Empresa  { get; set; }
    public String Propietario { get; set; }
    public String Domicilio  { get; set;}
    public List<Nodo> Nodos { get; set; }

    public Red(){Nodos=new List<Nodo>();}
    public Red(string empresa, string propietario, string domicilio) =>
        (Empresa, Propietario, Domicilio) = (empresa, propietario, domicilio);

    public int May() {
        int m=Nodos[0].Saltos;
        foreach(Nodo n in Nodos)
            if(n.Saltos>m)
                m=n.Saltos;
        return m;
    }

    public int Men() {
        int m=Nodos[0].Saltos;
        foreach(Nodo n in Nodos)
            if(n.Saltos<m)
                m=n.Saltos;
        return m;
    }

    public int TotVul() {
        int tot=0;
        foreach(Nodo n in Nodos) {
            tot+=n.Vulnerabilidades.Count;
        }
        return tot;
    }
    
     public override string ToString() =>
        String.Format($"Empresa: {Empresa}\nPropietario: {Propietario}\nDomicilio: {Domicilio}");
    
}
 