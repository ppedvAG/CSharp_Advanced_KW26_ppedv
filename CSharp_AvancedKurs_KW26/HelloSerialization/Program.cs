// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using HelloSerialization.MyCSV;



Console.WriteLine("Hello, World!");


Stream stream = null;


Person person = new Person()
{
    Vornamen = "Max",
    Nachnamen = "Moritz",
    Kontostand = 10_000m
};

#region BinaryFormatter
BinaryFormatter binary = new BinaryFormatter();

//Schreiben
//FileStream wird zurückgegeben 
stream = File.OpenWrite("Person.bin");
//obeselete -> wird aber trotzdem noch verwendet
binary.Serialize(stream, person);
stream.Close();

//Lesen
//geladene Person 
stream = File.OpenRead("Person.bin");
Person geladenePerson = (Person)binary.Deserialize(stream);
stream.Close();
#endregion

#region XML-Serializer
XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));


//Schreiben
stream = File.OpenWrite("Person.xml");
xmlSerializer.Serialize(stream, person);
stream.Close();

//Lesen
stream = File.OpenRead("Person.xml");
Person xmlPerson = (Person)xmlSerializer.Deserialize(stream);
stream.Close();
#endregion


#region JSON Newtonsoft

string jsonString = JsonConvert.SerializeObject(person);
File.WriteAllText("Person.json", jsonString);


string readedJSONString = File.ReadAllText("Person.json");
Person readJsonPerson = JsonConvert.DeserializeObject<Person>(readedJSONString);

#endregion


#region JSON System.Text.Json
System.Text.Json.JsonSerializerOptions options = new() 
{ WriteIndented = true,};


jsonString = System.Text.Json.JsonSerializer.Serialize(person, options);
File.WriteAllText("Person2.json", jsonString);

readedJSONString = File.ReadAllText("Person2.json");
Person readJsonPerson1 = System.Text.Json.JsonSerializer.Deserialize<Person>(readedJSONString);
#endregion


#region CSV-Serilizer mit Erweiterungsmethoden

person.Speichern("Person.csv");

Person person1 = new Person();
person1.Laden("Person.csv");
#endregion

Console.ReadLine();






[Serializable]
public class Person
{
    public string Vornamen { get; set; }
    public string Nachnamen { get; set; }

    [field: NonSerialized]
    [XmlIgnore]
    public decimal Kontostand { get; set; } 
}