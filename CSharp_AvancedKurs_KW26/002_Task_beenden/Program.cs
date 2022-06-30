using System;
using System.Threading;
using System.Threading.Tasks;

namespace _002_Task_beenden
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CancellationTokenSource cts = new CancellationTokenSource(); //Sender

            //Empfänger
            CancellationToken token = cts.Token; //Referenz wird überen 

            try
            {
                Task task = new Task(MeineMethodeMitabbrechen, token); //token wird als Parameter in die MeineMethodeMitAbbrechen übergeben 
                task.Start();

                Task.Delay(3000).Wait();


                cts.Cancel();
            }
            finally
            {

            }
            Console.ReadLine();
        }

        private static void MeineMethodeMitabbrechen(object param)
        {

            CancellationToken cancellationToken = (CancellationToken)param;
            try
            {
                while(true)
                {
                    Console.WriteLine("zzzZZZzzzZZZZzz");
                    Task.Delay(50).Wait(); //50 Milisekunden wartet er

                    if (cancellationToken.IsCancellationRequested)
                        cancellationToken.ThrowIfCancellationRequested(); //Kontrollierte Exception wird geschmissen 
                }
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
