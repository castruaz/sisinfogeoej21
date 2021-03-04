using System;
using System.Collections.Generic;
 
Escuela miescuela=null;
Inicializa(ref miescuela);
Reporte(miescuela);


void Reporte(Escuela esc) {
    Console.WriteLine("\n>>> Datos Generales de la Escuela:\n");
    Console.WriteLine($"{esc.ToString()}");
    Console.WriteLine("\n>>> Datos Generales de los profesores:\n");
    esc.Profesores.ForEach(p=>Console.WriteLine(p.ToString()));
    Console.WriteLine("\n>>> Alumnos por profesor:");
    foreach(Profesor p in esc.Profesores) {
        Console.WriteLine($"\n> Nombre: {p.Nombre}, Grupo: {p.Grupo}\n");
        if(p.Alumnos.Count!=0) {
            p.Alumnos.ForEach(a=>Console.WriteLine(a.ToString()));
            Console.WriteLine(p.Resumen());
        } else Console.WriteLine("No tiene alumnos aún");
    }

}
 
void Inicializa(ref Escuela esc) {
    esc = new Escuela() { Nombre="Universidad Patito SA de CV", Encargado="Ing. Juan Perez", Domicilio="Av. de la Juventud 348"};
    esc.Profesores.Add(new Profesor() {Nombre="Jose Diaz",    FechaIng=DateTime.Parse("1/1/2018"),  Grupo="1A", Materia="Fisica", Salario=1200});
    esc.Profesores.Add(new Profesor() {Nombre="Maria Perez",  FechaIng=DateTime.Parse("10/2/2016"), Grupo="2A", Materia="Algebra", Salario=3400});
    esc.Profesores.Add(new Profesor() {Nombre="Claudia Sid",  FechaIng=DateTime.Parse("1/4/2019"),  Grupo="4B", Materia="Calculo", Salario=3800});
    esc.Profesores.Add(new Profesor() {Nombre="Carlos Lopez", FechaIng=DateTime.Parse("10/3/2016"), Grupo="8A", Materia="Química", Salario=1000});
    esc.Profesores[0].Alumnos.Add( new Alumno() { Nombre="Fatima Soto", Edad=23, FechaIng=DateTime.Parse("1/1/2019"), Becado=true,  Califs=new int[] {7,7,7}});
    esc.Profesores[0].Alumnos.Add( new Alumno() { Nombre="Damian Diaz", Edad=25, FechaIng=DateTime.Parse("1/1/2016"), Becado=false, Califs=new int[] {8,8,8}});
    esc.Profesores[0].Alumnos.Add( new Alumno() { Nombre="Alicia Soto", Edad=23, FechaIng=DateTime.Parse("1/1/2018"), Becado=true,  Califs=new int[] {6,6,6}});  
    esc.Profesores[1].Alumnos.Add( new Alumno() { Nombre="Maria Ochoa", Edad=20, FechaIng=DateTime.Parse("1/10/2018"), Becado=true,  Califs=new int[] {9,9,9}});
    esc.Profesores[1].Alumnos.Add( new Alumno() { Nombre="Carlos Diaz", Edad=23, FechaIng=DateTime.Parse("1/10/2018"), Becado=false, Califs=new int[] {8,8,8}});
    esc.Profesores[2].Alumnos.Add( new Alumno() { Nombre="Jose Ochoa",  Edad=19, FechaIng=DateTime.Parse("1/10/2016"), Becado=false, Califs=new int[] {6,6,6}});
}