using System;
using System.Threading;

namespace _005_ThreadMitParamsAndReturnValues
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string eingabeString = "hallo liebe teilnehmer";
            string retString;


            //Anonymen Methode -> können wir Methoden normal aufrufen
            Thread thread = new Thread(() =>
            {
                retString = StringToUpper(eingabeString);

                Console.WriteLine(retString);
            });

            thread.Start();


            Thread thread1 = new Thread(Startmethode);
            thread1.Start();

            Console.ReadLine();
        }


        private static string StringToUpper(string param)
        {
            return param.ToUpper();
        }


        public static void Startmethode()
        {
            string retString = StringToUpper("testme");
            Console.WriteLine(retString);
        }
    }
}
