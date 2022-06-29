using System;

namespace DelegateCallbackWithNet5
{
    public delegate void PercentDelegate(int percent);
    public delegate void FinishDelegate(string msg);
    internal class Program
    {
        static void Main(string[] args)
        {
            PercentDelegate percentDelegate = new PercentDelegate(PercentStatusCallback);
            FinishDelegate finishDelegate = new FinishDelegate(FinishCallback);

            Process(percentDelegate, finishDelegate);

            Console.ReadKey();
        }

        public static void PercentStatusCallback(int percent)
         => Console.WriteLine(percent);


        public static void FinishCallback(string msg)
            => Console.WriteLine(msg);

        public static void Process(PercentDelegate percentDelegate, FinishDelegate finishDelegate)
        {

            //Methode in der was passiert (Rechenprozess) 
            for (int i = 0; i < 100; i++)
            {
                //Möchte nach draußen erzählen, bei welcher Prozentanzahl ich stehe
                percentDelegate(i);
            }

            //Am Ende werde ich nach draußen erzählen, dass ich fertig bin 
            finishDelegate("Arbeit ist getan");
        }
    }


}
