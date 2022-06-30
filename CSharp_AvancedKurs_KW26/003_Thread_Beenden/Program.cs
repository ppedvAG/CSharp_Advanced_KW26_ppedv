using System;
using System.Threading;

namespace _003_Thread_Beenden
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread thread = new Thread(MachEtwas);
            thread.Start();
            
            //Wir warten im Hauptprogram 3 Sekunden
            Thread.Sleep(3000);


            //thread.Abort(); -> obsolete
            thread.Interrupt();

            Console.ReadLine();
        }


        private static void MachEtwas()
        {
            try
            {
                //10 Sekunden schlafen -> zzzzZZZzzzZZZzzzZ 
                for (int i = 0; i < 50; i++)
                {
                    Console.WriteLine("zzzZZZzzzzZZZZZzzzzZZ");

                    Thread.Sleep(200);
                }
            }
            catch (ThreadInterruptedException ex)
            {
                Console.WriteLine("Methode wurde von außen Interrrupt() beendet");
            }
        }
    }
}
