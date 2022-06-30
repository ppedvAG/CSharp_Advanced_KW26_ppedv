using System;
using System.Threading.Tasks;

namespace AwaitAsyncSample2
{
    internal class Program
    {
        static async void Main(string[] args)
        {
            #region Sample 1: kürzeste Schreibweise mit Async / Await -> Ohne der Möglichkeit von z.b Continue With oder zu erfahren, was mit dem Task passiert ist 

            //task erwartet -> evening/afternoon oder morgning
            string str = await Task.Run(DayTime);
            await Task.Run(()=>ShowDayTime(str));
            #endregion

            #region Sample 2: async await mit Task
            Task<string> dayTimeTask = Task.Run(DayTime);
            //Wir warten bis Task fertig ist -> dayTimeTask.Wait
            await dayTimeTask.ContinueWith(myTask => ShowDayTime(dayTimeTask.Result));
            #endregion



            Console.ReadLine();
        }

        public static string DayTime()
        {
            DateTime dateTime = DateTime.Now; //Aktuelle Uhrzeit ermitteln wird

            return dateTime.Hour > 17 ? "evening" : dateTime.Hour > 12 ? "afternoon" : "morning";
        }

        public static void ShowDayTime(string result)
           => Console.WriteLine(result + " liebe Teilnehmer");
    }
}
}
