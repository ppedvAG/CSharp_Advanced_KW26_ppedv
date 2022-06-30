


using System;
using System.IO;

namespace Serialialisierung_ExtentionMethods.ABC
{
    public static class CSVSerializer
    {
        /// <summary>
        /// Erweiterung Methode für das Objekt Person
        /// </summary>
        /// <param name="p"></param>
        /// <param name="path"></param>
        public static void Serialize(this Person p, string path)
        {
            File.WriteAllText(path, $"{p.Vorname};{p.Nachname};{p.Alter};{p.Kontostand};{p.KreditLimit}");
        }

        public static void Deserialize(this Person p, string path)
        {
            string content = File.ReadAllText(path);
            string[] csvParts = content.Split(';');

            p.Vorname = csvParts[0];
            p.Nachname = csvParts[1];
            p.Alter = Convert.ToInt32(csvParts[2]);
            p.Kontostand = Convert.ToInt32(csvParts[3]);
            p.KreditLimit = Convert.ToInt32(csvParts[4]);

        }
    }
}
