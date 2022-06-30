using Newtonsoft.Json;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Serialialisierung_ExtentionMethods.ABC;

namespace Serialialisierung_ExtentionMethods
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Person person = new Person()
            {
                Vorname = "Max",
                Nachname = "Muster",
                Alter = 45,
                Kontostand = 1_000_000,
                KreditLimit = 5_000_000
            };

            Person person2 = new Person()
            {
                Vorname = "Maria",
                Nachname = "Muster",
                Alter = 33,
                Kontostand = 10_000_000,
                KreditLimit = 50_000_000
            };

            Stream stream;
            #region Binär

            //Schreiben
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            stream = File.OpenWrite("Person.bin");
            binaryFormatter.Serialize(stream, person);
            stream.Close();

            //Lesen
            stream = File.OpenRead("Person.bin");
            Person geladenePerson = (Person)binaryFormatter.Deserialize(stream);
            stream.Close();
            #endregion

            #region XML

            // Schreiben
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));
            stream = File.OpenWrite("Person.xml");
            xmlSerializer.Serialize(stream, person2);
            stream.Flush();

            stream.Close();

            // Lesen
            stream = File.OpenRead("Person.xml");
            Person geladenePerson2 = (Person)xmlSerializer.Deserialize(stream);
            stream.Close();
            #endregion

            #region Json
            string jsonString = JsonConvert.SerializeObject(person2);
            await File.WriteAllTextAsync("Person.json", jsonString);


            jsonString = string.Empty;
            jsonString = await File.ReadAllTextAsync("Person.json");

            Person geladenePerson3 = JsonConvert.DeserializeObject<Person>(jsonString);

            #endregion

            #region Custom CSV-Serializer
            person2.Serialize("Person.CSV");

            Person loadedPerson = new Person();
            loadedPerson.Deserialize("Person.CSV");

            #endregion
        }
    }

    [Serializable]
    public class Person //: IAnyJSONInterface 
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public int Alter { get; set; }

        //[field: NonSerialized]
        [XmlIgnore]
        [JsonIgnore]
        public decimal Kontostand { get; set; }

        //[NonSerialized] //Nur bei Binär, JSON -> Variablen bekommen NonSerialized Attribute, wenn diese nicht serialisierbar sein sollen
        [XmlIgnore]
        [JsonIgnore]
        public decimal KreditLimit;
    }







    //public class Rootobject
    //{
    //    public string Vorname { get; set; }
    //    public string Nachname { get; set; }
    //    public int Alter { get; set; }
    //}

}
