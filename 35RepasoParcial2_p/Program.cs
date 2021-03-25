﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
 

string ruta = Path.Combine(Environment.CurrentDirectory,"data");

Red mired=null;

Console.WriteLine("Sistemas de Seguridad SA de CV");
Inicializa(ref mired);
//Reporte(mired);
//RVulns(mired);
RNodos(mired);
//xmlSerializa(mired);
//jsonSerializa(mired);

void Inicializa(ref Red r) {

    // Creamos el objeto red y le asignamos valores
    r = new Red() {Empresa="Red Patito, S.A. de C.V",
                   Propietario="Mr Pato Macdonald",
                   Domicilio="Av. Princeton 123,Orlando Florida"};

    // Aregamos 4 nodos a la red, con sus valores respectivos
    r.Nodos.Add(new Nodo(){ Ip="192.168.0.10", Tipo="servidor",     Puertos=5,  Saltos=10, So="linux"});  
    r.Nodos.Add(new Nodo(){ Ip="192.168.0.12", Tipo="equipoactivo", Puertos=2,  Saltos=12, So="ios" });
    r.Nodos.Add(new Nodo(){ Ip="192.168.0.20", Tipo="computadora",  Puertos=8,  Saltos=5,  So="windows" }); 
    r.Nodos.Add(new Nodo(){ Ip="192.168.0.15", Tipo="servidor",     Puertos=10, Saltos=22, So="linux" });

    // Agregregar las vulnerablidades a cada nodo
    r.Nodos[0].Vulnerabilidades.Add(
        new Vulnerabilidad { Clave="CVE-2015-1635", Vendedor="microsoft", 
                             Descripcion="HTTP.sys permite a atacantes remotos ejecutar código arbitrario" , 
                             Tipo="remota", Fecha=DateTime.Parse("04/14/2015")
                            });
    r.Nodos[0].Vulnerabilidades.Add(
        new Vulnerabilidad { Clave="CVE-2017-0004", Vendedor="microsoft", 
                             Descripcion="El servicio LSASS permite causar una denegación de servicio" , 
                             Tipo="local", Fecha=DateTime.Parse("01/10/2011")
                            });

    r.Nodos[1].Vulnerabilidades.Add(
        new Vulnerabilidad { Clave="CVE-2017-3847", Vendedor="cisco", 
                             Descripcion="Cisco Firepower Management Center XSS" , 
                             Tipo="remota", Fecha=DateTime.Parse("02/21/2017")
                            });

    r.Nodos[2].Vulnerabilidades.Add(
        new Vulnerabilidad { Clave="CVE-2009-2504", Vendedor="microsoft", 
                             Descripcion="Múltiples desbordamientos de enteros en APIs Microsoft .NET 1.1" , 
                             Tipo="local", Fecha=DateTime.Parse("11/13/2009")
                            });

    r.Nodos[2].Vulnerabilidades.Add(
        new Vulnerabilidad { Clave="CVE-2016-7271", Vendedor="microsoft", 
                             Descripcion="Elevación de privilegios Kernel Segura en Windows 10 Gold" , 
                             Tipo="local", Fecha=DateTime.Parse("12/20/2016")
                            });

    r.Nodos[2].Vulnerabilidades.Add(
        new Vulnerabilidad { Clave="CVE-2017-2996", Vendedor="adobe", 
                             Descripcion="Adobe Flash Player 24.0.0.194 corrupción de memoria explotable" , 
                             Tipo="remota", Fecha=DateTime.Parse("2/15/2017")
                            });
}

void Reporte(Red r) {
    Console.WriteLine("Empresa de Seguridad en Redes SA De CV\n");
    Console.WriteLine(">> Datos generales de la red:\n");
    Console.WriteLine($"Empresa     = {r.Empresa}");
    Console.WriteLine($"Propietario = {r.Propietario}");
    Console.WriteLine($"Domicilio   = {r.Domicilio}");

    Console.WriteLine($"\nTotal nodos           :{r.Nodos.Count}");
    Console.WriteLine($"Total vulnerabilidades:{r.TotVuln()}");


    Console.WriteLine("\n>> Datos generales de los nodos:\n");
    r.Nodos.Sort();
    r.Nodos.ForEach(n=>Console.WriteLine(n.ToString()));
    Console.WriteLine($"\nMayor numero de saltos: {r.MaySal()}");
    Console.WriteLine($"Menor numero de saltos: {r.MenSal()}");

    Console.WriteLine("\n>> Vulnerabilidades por nodo:");
    
    foreach(Nodo n in r.Nodos) {
        Console.WriteLine($"\n> Ip:{n.Ip}, Tipo:{n.Tipo} ");
        Console.WriteLine($"\nVulnerabilidades: {n.Vulnerabilidades.Count}");
        n.Vulnerabilidades.Sort();
        n.Vulnerabilidades.ForEach(v=>Console.WriteLine(v.ToString("D1",CultureInfo.CurrentCulture)));
        }
}

void RVulns(Red r) {
    Console.WriteLine("Reporte de Vulnerabilidades por Tipo: Locales, Remotas: \n");
    var vl = (r.Nodos.SelectMany(n=>n.Vulnerabilidades).Where(v=>v.Tipo=="local")).ToList();
    var vr = (r.Nodos.SelectMany(n=>n.Vulnerabilidades).Where(v=>v.Tipo=="remota")).ToList();
    Console.WriteLine("\nLocales: {0}",vl.Count());
    vl.ForEach(v=>Console.WriteLine(v.ToString("D1",CultureInfo.CurrentCulture)));
    Console.WriteLine("\nRemotas: {0}",vr.Count());
    vr.ForEach(v=>Console.WriteLine(v.ToString("D2",CultureInfo.CurrentCulture)));
}

void RNodos(Red r) {
    Console.WriteLine("Reporte de Nodos \n");
    Console.WriteLine("\nNodos con SO Windows o Linux");
    var nwl = ( r.Nodos.Where(n=>n.So=="linux"||n.So=="windows") ).ToList();
    nwl.ForEach(n=>Console.WriteLine(n.ToString()));
    Console.WriteLine("\nNodos con menos de 15 saltos");
    var nsal = ( r.Nodos.Where(n=>n.Saltos<15) ).ToList();
    nsal.ForEach(n=>Console.WriteLine(n.ToString()));
}

void xmlSerializa(Red red) {
    Red nuevared=new Red();
    Utilerias.xmlGraba(ruta,red);
    Utilerias.xmlLeer(ruta,ref nuevared);
    Reporte(nuevared);
}

void jsonSerializa(Red red) {
    Red nuevared=new Red();
    Utilerias.jsonGraba(ruta,red);
    Utilerias.jsonLeer(ruta,ref nuevared);
    Reporte(nuevared);
}




// https://stackoverflow.com/questions/721395/linq-question-querying-nested-collections
  

