using System;
using System.Collections.Generic;

Red mired=null;
Inicializa(ref mired);
Reporte(mired);

void Reporte(Red r) {
    Console.WriteLine("Empresa Seguridad en Redes SA de CV \n");
    Console.WriteLine("\nDatos Generales de la Red");
    Console.WriteLine(r.ToString());
    Console.WriteLine($"\nTotal nodos red       :{r.Nodos.Count}");
    Console.WriteLine($"Total vulnerabilidades:{r.TotVul()}");
    Console.WriteLine("\n>>Datos Generales de los nodos:\n");
    r.Nodos.ForEach(i => Console.WriteLine(i.ToString()));
    Console.WriteLine($"\nMayor numero de saltos {r.May()}");
    Console.WriteLine($"Menor numero de saltos {r.Men()}");
    Console.WriteLine("\n>>Vulnerabilidades por nodo:");
    foreach(Nodo n in r.Nodos) {
        Console.WriteLine($"\n>Ip: {n.Ip}, Tipo: {n.Tipo}\n");
        n.Vulnerabilidades.ForEach(v=>Console.WriteLine($"{v.ToString()}\n"));
    }
}


void Inicializa(ref Red r) {
    r = new Red() {Empresa="Red Patito, S.A. de C.V.", 
                   Propietario= "Mr Pato Macdonald",
                   Domicilio="Av. Princeton 123, Orlando Florida"}; 

      
    r.Nodos.Add(new Nodo {Ip="192.168.0.10", Tipo="servidor",     Puertos=5,  Saltos=10, So="linux"});
    r.Nodos.Add(new Nodo {Ip="192.168.0.12", Tipo="equipoactivo", Puertos=2,  Saltos=12, So="ios"});
    r.Nodos.Add(new Nodo {Ip="192.168.0.20", Tipo="computadora",  Puertos=8,  Saltos=5,  So="windows"}); 
    r.Nodos.Add(new Nodo {Ip="192.168.0.15", Tipo="servidor",     Puertos=10, Saltos=22, So="linux"});
      
    
    r.Nodos[0].Vulnerabilidades.Add( 
        new Vulnerabilidad() {  Clave="CVE-2015-1635", Vendedor="microsoft", 
                                Descripcion="HTTP.sys permite a atacantes remotos ejecutar código arbitrario" , 
                                Tipo="remota", Fecha=DateTime.Parse("04/14/2015")
                             });
    r.Nodos[0].Vulnerabilidades.Add(
        new Vulnerabilidad   {  Clave="CVE-2017-0004", Vendedor="microsoft", 
                                Descripcion="El servicio LSASS permite causar una denegación de servicio", 
                                Tipo="local",Fecha=DateTime.Parse("01/10/2011")
                             });
   
    r.Nodos[1].Vulnerabilidades.Add(
        new Vulnerabilidad() {
                                Clave="CVE-2017-3847", Vendedor="cisco", 
                                Descripcion="Cisco Firepower Management Center XSS" , 
                                Tipo="remota", Fecha=DateTime.Parse("02/21/2017")
                            });

    r.Nodos[2].Vulnerabilidades.Add(
        new Vulnerabilidad() {
                                Clave="CVE-2009-2504", Vendedor="microsoft", 
                                Descripcion="Múltiples desbordamientos de enteros en APIs Microsoft .NET 1.1" , 
                                Tipo="local", Fecha=DateTime.Parse("11/13/2009")
                            });

    r.Nodos[2].Vulnerabilidades.Add(
        new Vulnerabilidad() {
                                Clave="CVE-2016-7271", Vendedor="microsoft", 
                                Descripcion="Elevación de privilegios Kernel Segura en Windows 10 Gold", 
                                Tipo="local", Fecha=DateTime.Parse("12/20/2016")
                            });

    r.Nodos[2].Vulnerabilidades.Add(
        new Vulnerabilidad() {
                                Clave="CVE-2017-2996", Vendedor="adobe", 
                                Descripcion="Adobe Flash Player 24.0.0.194 corrupción de memoria explotable", 
                                Tipo="remota", Fecha=DateTime.Parse("2/15/2017")
                            });

}

