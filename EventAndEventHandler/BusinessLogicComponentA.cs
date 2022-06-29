using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAndEventHandler
{

    public delegate void ChengecPercentValueDelegate(int percentValue);
    public delegate void ResultDelegate(string msg);


    public class BusinessLogicComponentA
    {
        //Wir können von aussen Methoden an die jeweilige Delegates dranhängen -> event signalsiert das man von aussen zugreifen kann 

        public event ChengecPercentValueDelegate ChengecPercentValue; 
        public event ResultDelegate ResultCompletedDelegate;

        public void StartProcess()
        {

            for (int i = 0; i < 100; i++)
            {
                //-> Code
                //if (ChengecPercentValue != null)
                //    ChengecPercentValue.Invoke(i); //Invoke bedeutet, rufe die Speicheradresse auf, die du gerade speicherst -> BusinessLogicComponentA_ChengecPercentValue

                OnProcessPercentStatus(i);
            }

            //Ergebniss bzw Callback wird hier verwendet
            OnResult("Bin fertig");
        }

        protected virtual void OnProcessPercentStatus(int percent)
            => ChengecPercentValue?.Invoke(percent);


        protected virtual void OnResult (string msg)
        {
            ResultCompletedDelegate?.Invoke(msg);
        }



    }
}
