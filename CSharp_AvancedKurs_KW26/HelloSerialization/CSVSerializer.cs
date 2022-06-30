using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloSerialization.MyCSV
{
    public static class CSVSerializer
    {
        public static void Speichern( this Person p, string savePath )
        {
            File.WriteAllText(savePath, $"{p.Vornamen};{p.Nachnamen};{p.Kontostand}");
        }

        public static void Laden(this Person p, string loadPath)
        {
            string content = File.ReadAllText(loadPath);

            string[] csvPart = content.Split(';');

            p.Vornamen = csvPart[0];
            p.Nachnamen = csvPart[1];
            p.Kontostand = Convert.ToInt32(csvPart[2]);
            
        }
    }
}
