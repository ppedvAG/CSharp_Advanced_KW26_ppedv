using System;

namespace EventAndEventHandler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BusinessLogicComponentA businessLogicComponentA = new BusinessLogicComponentA();
            businessLogicComponentA.ChengecPercentValue += BusinessLogicComponentA_ChengecPercentValue;
            businessLogicComponentA.ResultCompletedDelegate += BusinessLogicComponentA_ResultCompletedDelegate;

            businessLogicComponentA.StartProcess();

            Console.Clear();

            BusinessLogicComponentB businessLogicComponentB = new BusinessLogicComponentB();
            businessLogicComponentB.ProcessCompleted += BusinessLogicComponentB_ProcessCompleted;
            businessLogicComponentB.PercentValueChanged += BusinessLogicComponentB_PercentValueChanged;
            businessLogicComponentB.StartProcess();
        }

        private static void BusinessLogicComponentB_PercentValueChanged(object sender, EventArgs e)
        {
            MyPercentEventArgs myPercentArgs = (MyPercentEventArgs)e;



            Console.WriteLine("Sender" + sender.ToString() + "\t Percent: " + myPercentArgs.PercentValue) ;
        }

        private static void BusinessLogicComponentB_ProcessCompleted(object sender, EventArgs e)
        {
            //sender -> EventAndEventHandler.BusinessLogicComponentB
            Console.WriteLine(sender.ToString() + "ist mit Berrechnung fertig");
        }

        //Wird aus der BusinessLogicComponentA heraus aufgerufen (Als Finish-Message)
        private static void BusinessLogicComponentA_ResultCompletedDelegate(string msg)
        {
            Console.WriteLine(msg);
        }


        //Wird aus der BusinessLogicComponentA heraus aufgerufen (pro Percent)
        private static void BusinessLogicComponentA_ChengecPercentValue(int percentValue)
        {
            Console.WriteLine(percentValue);
        }
    }
}
