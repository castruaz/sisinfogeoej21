using System;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Linq;
using static System.Console;

public static class Utilerias {

    public static void xmlGrabar(string ruta, Red red) {
        FileStream fs = File.Open(ruta+".xml",FileMode.Create);
        XmlSerializer xml = new XmlSerializer(typeof(Red));
        xml.Serialize(fs,red);
        fs.Close();
    }

    public static void xmlLeer(string ruta, ref Red red) {
        FileStream fs = File.Open(ruta+".xml",FileMode.Open);
        XmlSerializer xml = new XmlSerializer(typeof(Red));
        red = (Red)xml.Deserialize(fs);
        fs.Close();
    }

    public static void jsonGrabar(string ruta, Red red) {
        StreamWriter fs = File.CreateText(ruta+".json");
        JsonSerializer json = new JsonSerializer();
        json.Serialize(fs,red);
        fs.Close();
    }

    public static void jsonLeer(string ruta, ref Red red) {
        StreamReader fs = File.OpenText(ruta+".json");
        string strData = fs.ReadToEnd();
        red = JsonConvert.DeserializeObject<Red>(strData);
        fs.Close();
    }

    public static void repVulnerabilidades(Red red) {
        WriteLine("Reporte de Vulnerabilidades \n");
        WriteLine("\nVulnerabilidades por tipo: local");
        var vl = ( red.Nodos.SelectMany(n=>n.Vulnerabilidades).Where(v=>v.Tipo=="local") ).ToList();
        vl.ForEach(v=>WriteLine(v.ToString("D1",System.Globalization.CultureInfo.CurrentCulture)));
        WriteLine("\nVulnerabilidades por vendedor: Microsoft");
        var vv = ( red.Nodos.SelectMany(n=>n.Vulnerabilidades).Where(v=>v.Vendedor=="microsoft") ).ToList();
        vv.ForEach(v=>WriteLine(v.ToString("D2",System.Globalization.CultureInfo.CurrentCulture)));
    }

    public static void repNodos(Red red) {
        WriteLine("Reporte de nodos \n");
        WriteLine("Nodos SO Windos o Linux\n");
        var nwl = ( red.Nodos.Where(n=>n.So=="linux"||n.So=="windows") ).ToList();
        nwl.ForEach(n=>WriteLine(n.ToString()));
        WriteLine("\nNodos con mas de 15 saltos\n");
        var nsal = ( red.Nodos.Where(n=>n.Saltos>15) ).ToList();
        nsal.ForEach(n=>WriteLine(n.ToString()));
    }

}