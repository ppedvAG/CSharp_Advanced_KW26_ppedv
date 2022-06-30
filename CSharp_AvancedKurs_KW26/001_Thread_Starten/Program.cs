using System;
using System.Threading;

namespace _001_Thread_Starten
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread thread = new Thread(MachEtwasInEinemThread);
            thread.Start(); 

            
            //thread.Join(); //Warten bis Thread 1 fertig ist

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("*");
            }

            Console.ReadLine();
        }


        private static void MachEtwasInEinemThread()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("#");
            }
        }
    }
}
