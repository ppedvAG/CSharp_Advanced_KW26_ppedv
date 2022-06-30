using System;
using System.Threading.Tasks;

namespace _006_ContinueWith
{
    internal class Program
    {
        private static int[] Lottozahlen = new int[7];
        static void Main(string[] args)
        {
            Task t1 = new Task(() =>
            {
                //anonyme Methode
                Console.WriteLine("Task 1 arbeitet");
                Lottozahlen[0] = 2;
                Lottozahlen[1] = 12;
                Lottozahlen[2] = 22;
                Lottozahlen[3] = 32;
                Lottozahlen[4] = 42;
                Lottozahlen[5] = 52;
                Lottozahlen[6] = 62;

                throw new Exception();
            });
            t1.Start();

            t1.ContinueWith(task => AllgemeinerFolgetask()); //Wird immer ausgeführt 
            t1.ContinueWith(task => FolgetaskBeiFehler(), TaskContinuationOptions.OnlyOnFaulted); //Bei Fehler wird ausgeführt
            t1.ContinueWith(task => FolgetaskBeiErfolg(), TaskContinuationOptions.OnlyOnRanToCompletion); //Bei Erfolg wird ausgeführt

            Console.ReadLine();
        }

        private static void AllgemeinerFolgetask()
        {
            Console.WriteLine("Ich muss immer augerufen werden ");
        }

        private static void FolgetaskBeiErfolg()
        {
            //Workflow? Transaction->Comit 
            Console.WriteLine("Ich werde aufgerufen, wenn der vorige Task ohne Fehler durchgelaufen ist");
        }

        private static void FolgetaskBeiFehler()
        {
            //Aufräumarbeiten
            //Workflow? Transaction->Rollback 
            Console.WriteLine("Ich werde aufgerufen, wenn der vorige Task einen Fehler verursacht hat");
        }
    }
}
