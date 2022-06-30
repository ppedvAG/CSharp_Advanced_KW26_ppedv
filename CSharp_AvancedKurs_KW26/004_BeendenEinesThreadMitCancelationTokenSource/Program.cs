using System;
using System.Threading;

namespace _004_BeendenEinesThreadMitCancelationTokenSource
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Sender
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            //Empfänger 
            CancellationToken cancellationToken = cancellationTokenSource.Token;


            ParameterizedThreadStart parameterizedThreadStart = new ParameterizedThreadStart(MachEtwas);
            Thread thread = new Thread(parameterizedThreadStart);
            thread.Start(cancellationToken); //MachEtwas wird gestartet

            Thread.Sleep(3000);

            //Nach 3 Sek brechen wir ab
            cancellationTokenSource.Cancel();


            Console.ReadLine();
            
            
        }


        private static void MachEtwas(object param) //Übergabe des CancellationToken Objekts
        {
            try
            {
                //10 Sekunden mit Ausgabe 'zzZZZZzzzZZZ'
                if (param is CancellationToken cancellationToken)
                {

                    ParameterizedThreadStart parameterizedThreadStart = new ParameterizedThreadStart(MachEtwasInEinemThread);
                    
                    
                    Thread innerThread = new Thread(parameterizedThreadStart);
                    innerThread.Start(cancellationToken);

                    for (int i = 0; i < 50; i++)
                    {

                        Console.WriteLine("zzzzzZZZZZzzzzzZZZZZ");
                        Thread.Sleep(200);

                        if (cancellationToken.IsCancellationRequested)
                            cancellationToken.ThrowIfCancellationRequested();
                    }
                }
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine("Erster Thread wird beendet: " + ex.Message);
            }
        }

        private static void MachEtwasInEinemThread(object param)
        {
            try
            {
                CancellationToken cancellationToken = (CancellationToken)param;

                for (int i = 0; i < 5000; i++)
                {
                    if (cancellationToken.IsCancellationRequested)
                    {
                        cancellationToken.ThrowIfCancellationRequested(); //kalkulierte Exception
                    }
                    Thread.Sleep(200);
                    Console.WriteLine("#");
                }
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine("Zweiter Thread wird beendet: " + ex.Message);
            } 
        }
    }
}
