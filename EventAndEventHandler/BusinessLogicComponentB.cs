using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAndEventHandler
{




    public class BusinessLogicComponentB
    {
        //Wir können von aussen Methoden an die jeweilige Delegates dranhängen -> event signalsiert das man von aussen zugreifen kann 
        public event EventHandler ProcessCompleted;
        public event EventHandler PercentValueChanged;
       

        public void StartProcess()
        {

            for (int i = 0; i < 100; i++)
            {
                OnPercentValueChanged(i);
            }

            //Ergebniss bzw Callback wird hier verwendet
            OnProcessCompleted();
        }

        protected virtual void OnProcessCompleted()
        {
            ProcessCompleted?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnPercentValueChanged(int i)
        {
            MyPercentEventArgs myPercentEventArgs = new ();
            myPercentEventArgs.PercentValue = i;

            PercentValueChanged?.Invoke(this, myPercentEventArgs);
        }

    }

    public class MyPercentEventArgs : EventArgs
    {
        public int PercentValue { get; set; }
    }
}
