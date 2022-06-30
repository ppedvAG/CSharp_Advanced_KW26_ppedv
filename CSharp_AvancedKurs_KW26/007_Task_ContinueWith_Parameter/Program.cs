using System;
using System.Threading.Tasks;

namespace _007_Task_ContinueWith_Parameter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Sample1 
            //task erwartet -> evening/afternoon oder morgning
            Task<string> task = Task.Run(DayTime); 
            task.ContinueWith(secondTask => ShowDayTime(task.Result)); //Wir verketten Methode DayTime mit ShowDateTime
            #endregion


            #region Sample2
            Task<string> ersterTask = Task.Run(DayTime);

            Task<string> zweiterTask = ersterTask.ContinueWith(mytask => StringToUpper(ersterTask.Result));

            Task dritterTask = zweiterTask.ContinueWith(myTask => ShowDayTime(zweiterTask.Result));

            dritterTask.Wait(); //Warten bis das Ergebnis ausgegeben wurde

            #endregion

            Console.ReadLine();
        }

        public static string DayTime()
        {
            DateTime dateTime = DateTime.Now; //Aktuelle Uhrzeit ermitteln wird

            return dateTime.Hour > 17 ? "evening" : dateTime.Hour > 12 ? "afternoon" : "morning";
        }

        public static string StringToUpper(string dayTime)
            => dayTime.ToUpper();

        public static void ShowDayTime(string result)
           => Console.WriteLine(result + " liebe Teilnehmer");
    }
}
