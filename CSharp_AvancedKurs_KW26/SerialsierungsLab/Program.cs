using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace SerialsierungsLab
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            List<FormularCourse> courseListe = new List<FormularCourse>();

            courseListe.Add(new FormularCourse() { Id = 1, Name = "Avus", Baujahr = 1932, Length = 5.1, TopSpeed = 300, ZuschauscherAnzahl = 100_000 });
            courseListe.Add(new FormularCourse() { Id = 2, Name = "Solitude", Baujahr = 1922, Length = 15.1, TopSpeed = 350, ZuschauscherAnzahl = 200_000 });
            courseListe.Add(new FormularCourse() { Id = 3, Name = "Hockenheimring", Baujahr = 1933, Length = 6.1, TopSpeed = 320, ZuschauscherAnzahl = 300_000 });
            courseListe.Add(new FormularCourse() { Id = 4, Name = "Norisring", Baujahr = 1965, Length = 4.1, TopSpeed = 310, ZuschauscherAnzahl = 120_000 });
            courseListe.Add(new FormularCourse() { Id = 5, Name = "Odenwaldring", Baujahr = 1978, Length = 1.4, TopSpeed = 200, ZuschauscherAnzahl = 100_000 });
            courseListe.Add(new FormularCourse() { Id = 6, Name = "Zeltweg", Baujahr = 1950, Length = 4.3, TopSpeed = 280, ZuschauscherAnzahl = 140_000 });





            //JSON -> List rausschreiben und einlesen jeweils mit Newtonsoft Json und System.Text.Json 
            string jsonString = JsonConvert.SerializeObject(courseListe);
            await File.WriteAllTextAsync("Courses1.json", jsonString);

            jsonString = await File.ReadAllTextAsync("Courses1.json");
            List<FormularCourse> courses = JsonConvert.DeserializeObject<List<FormularCourse>>(jsonString);


            //

            System.Text.Json.JsonSerializerOptions options = new() { WriteIndented = true, };
            jsonString = System.Text.Json.JsonSerializer.Serialize(courseListe, options);
            File.WriteAllText("Courses2.json", jsonString);

            jsonString = File.ReadAllText("Courses2.json");
            List<FormularCourse> courses1 = System.Text.Json.JsonSerializer.Deserialize<List<FormularCourse>>(jsonString);

        }
    }


    public class FormularCourse
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public double Length { get; set; }

        public int TopSpeed { get; set; }

        public int Baujahr { get; set; }

        public int ZuschauscherAnzahl { get; set; }

    }



    public class Rootobject
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string Rated { get; set; }
        public string Released { get; set; }
        public string Runtime { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Writer { get; set; }
        public string Actors { get; set; }
        public string Plot { get; set; }
        public string Language { get; set; }
        public string Country { get; set; }
        public string Awards { get; set; }
        public string Poster { get; set; }
        public Rating[] Ratings { get; set; }
        public string Metascore { get; set; }
        public string imdbRating { get; set; }
        public string imdbVotes { get; set; }
        public string imdbID { get; set; }
        public string Type { get; set; }
        public string DVD { get; set; }
        public string BoxOffice { get; set; }
        public string Production { get; set; }
        public string Website { get; set; }
        public string Response { get; set; }
    }

    public class Rating
    {
        public string Source { get; set; }
        public string Value { get; set; }
    }


   

}
