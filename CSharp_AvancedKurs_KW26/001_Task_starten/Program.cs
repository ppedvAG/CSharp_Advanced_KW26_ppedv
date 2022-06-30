using System;
using System.Threading.Tasks;

namespace _001_Task_starten
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task task = new Task(MacheEtwasInEinemTask);
            task.Start();

            for (int i = 0; i < 1000; i++)
                Console.WriteLine("*");

            Console.ReadLine(); 
        }
        private static void MacheEtwasInEinemTask()
        {
            for (int i = 0; i < 1000; i++)
                Console.WriteLine("#");
        }
    }
}
