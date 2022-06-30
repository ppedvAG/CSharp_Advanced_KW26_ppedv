using System;
using System.Threading.Tasks;

namespace _004_Task_Mit_Parameter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Katze katze = new();

           
            //Task<Rückgabetype> 
            Task<string> task1 = new Task<string>(MachEtwas, katze);
            task1.Start();
            task1.Wait(); //Warten bis fertig
            Console.WriteLine(task1.Result);


            //Parameterübergabe via anonyme Methode
            Task<string> task2 = new Task<string>(() => MachEtwas(katze));
            task2.Start();//Warten bis fertig
            task2.Wait();
            Console.WriteLine(task2.Result);
            
            Task<string> task3 = Task.Factory.StartNew(MachEtwas, katze);
            task3.Wait();
            Console.WriteLine(task3.Result);


            //Task.Run kann nur via Anonyme 
            Task<string> task4 = Task.Run(()=>MachEtwas(katze));

        }

        private static string MachEtwas(object input)
        {
            if (input is Katze katze)
            {
                return katze.Name;
            }

            throw new ArgumentException();
        }
    }

    public class Katze
    {
        public string Name { get; set; } = "Maya";
    }
}
