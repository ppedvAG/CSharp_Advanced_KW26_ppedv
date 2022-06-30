using System;
using System.Threading.Tasks;

namespace TaskFactorySample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Variante1: 
            Task task = new Task(MacheEtwasInEinemTask); /*Funktionszeiger*/
            task.Start(); //explizites Starten
            //task.Wait();

            //Variante 2
            Task task1 = Task.Factory.StartNew(MacheEtwasInEinemTask); //Zuweisung der Methode + Starten des Task

            // Variante 3 -> Task.Factory.StartNew
            //Task.Run ist eine verkürzte Schreibweise
            Task task2 = Task.Run(MacheEtwasInEinemTask); //Hier ist auch ein Factory-Pattern


            //Warten bis der erste fertig ist 
            Task.WaitAny(task, task1, task2);

            //Wir warten bis alle Task fertig
            Task.WaitAll(task, task1, task2);

            Console.WriteLine("Bin fertig");
            Console.ReadLine();
        }



        private static void MacheEtwasInEinemTask()
        {
            for (int i = 0; i < 100; i++)
                Console.WriteLine("*");
        }
    }
}
