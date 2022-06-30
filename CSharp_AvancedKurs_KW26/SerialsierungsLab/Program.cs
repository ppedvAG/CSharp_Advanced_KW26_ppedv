using System;
using System.Collections.Generic;

namespace SerialsierungsLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<FormularCourse> courseListe = new List<FormularCourse>();

            courseListe.Add(new FormularCourse() { Id = 1, Name = "Avus", Baujahr = 1932, Length = 5.1, TopSpeed = 300, ZuschauscherAnzahl = 100_000 });
            courseListe.Add(new FormularCourse() { Id = 2, Name = "Solitude", Baujahr = 1922, Length = 15.1, TopSpeed = 350, ZuschauscherAnzahl = 200_000 });
            courseListe.Add(new FormularCourse() { Id = 3, Name = "Hockenheimring", Baujahr = 1933, Length = 6.1, TopSpeed = 320, ZuschauscherAnzahl = 300_000 });
            courseListe.Add(new FormularCourse() { Id = 4, Name = "Norisring", Baujahr = 1965, Length = 4.1, TopSpeed = 310, ZuschauscherAnzahl = 120_000 });
            courseListe.Add(new FormularCourse() { Id = 5, Name = "Odenwaldring", Baujahr = 1978, Length = 1.4, TopSpeed = 200, ZuschauscherAnzahl = 100_000 });
            courseListe.Add(new FormularCourse() { Id = 6, Name = "Zeltweg", Baujahr = 1950, Length = 4.3, TopSpeed = 280, ZuschauscherAnzahl = 140_000 });


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
}
