using System;
using System.Threading;

namespace _002_Thread_mit_Parameter_starten
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ParameterizedThreadStart parameterizedThreadStart = new ParameterizedThreadStart(MachEtwasInEinemThread);
            Thread thread = new Thread(parameterizedThreadStart);

            thread.Start(600);

            for (int i = 0; i <= 100; i++)
                Console.WriteLine("*");


            Console.ReadLine();

        }


        private static void MachEtwasInEinemThread(object obj)
        {
            for (int i = 0; i < (int)obj; i++)
            {
                Console.WriteLine("#");
            }
        }
    }
}
