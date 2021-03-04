using System;
using System.Collections.Generic;



List<Empleado> emps= new List<Empleado> {
    new Empleado(){Paterno="Castañeda", Materno="Ramírez",Nombre="Carlos", Salario=1005.25},
    new Empleado(){Paterno="Diaz", Materno="Perez",Nombre="Juan", Salario=110.24},
    new Empleado(){Paterno="Torres",Materno="Orozco",Nombre="Pedro", Salario=5110.12},
    new Empleado(){Paterno="Arias",Materno="Rivas",Nombre="Luis", Salario=1000.292},
    new Empleado(){Paterno="Carrillo",Materno="Correa",Nombre="MAria", Salario=2110.25}
    };



Console.WriteLine("Ejemplo de Interfaz para oredenar");

Console.WriteLine("\nLista de empleados ordenada por salario ascendente");
emps.Sort();
emps.ForEach(e=>Console.WriteLine(e.ToString()));

Console.WriteLine("\nLista de empleados ordenada por salario descendente");
emps.Reverse();
emps.ForEach(e=>Console.WriteLine(e.ToString()));

Console.WriteLine("\nLista de emplados (Paterno, Materno, Nombre) salario ascendente");
emps.Sort();
emps.ForEach(e=>Console.WriteLine(e.ToString("PMN",System.Globalization.CultureInfo.CurrentCulture)));

Console.WriteLine("\nLista de emplados (Nombre, Paterno, Materno,) salario descendente");
emps.Reverse();
emps.ForEach(e=>Console.WriteLine(e.ToString("NPM",System.Globalization.CultureInfo.CurrentCulture)));
