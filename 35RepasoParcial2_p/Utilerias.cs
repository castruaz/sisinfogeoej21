using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;

public static class Utilerias {

    public static void xmlGraba(string ruta, Red red) {
        FileStream fs = File.Open(ruta+".xml",FileMode.Create);
        XmlSerializer xml = new XmlSerializer(typeof(Red));
        xml.Serialize(fs,red);
        fs.Close();
    }
    public static void xmlLeer(string ruta, ref Red red) {
        FileStream fs = File.Open(ruta+".xml",FileMode.Open);
        XmlSerializer xmlEmp = new XmlSerializer(typeof(Red));
        red = (Red)xmlEmp.Deserialize(fs);
         
    }

    public static void jsonGraba(string ruta, Red red) {
        StreamWriter fs = File.CreateText(ruta+".json");
        JsonSerializer json = new JsonSerializer();
        json.Serialize(fs,red);
        fs.Close();
    }

    public static void jsonLeer(string ruta, ref Red red) {
        StreamReader fs = File.OpenText(ruta+".json");
        string strData = fs.ReadToEnd();            
        red = JsonConvert.DeserializeObject<Red>(strData);
    }
    
}