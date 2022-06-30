using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountSimulatorLAB_Solution
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            List<Task> tasks = new List<Task>();
            
            for (int i = 0; i < 500; i++) //Hier 50 Tasks erzeugen die alle jeweils 500 Transaktionen machen
                tasks.Add(Task.Run(() => KontoUpdates()));

            Task.WaitAll(tasks.ToArray());

            Console.ReadLine();
        }


        //static void KontoUpdate() //Random Einzahlungen und Auszahlungen ausführen
        //{
        //    Random random = new Random();
        //    for (int i = 0; i < 10000; i++)
        //    {
        //        Task.Run(() =>
        //        {
        //            int betrag = random.Next(0, 1000);
        //            bool einzahlen = random.Next() % 2 == 0;
        //            Account.TransactionCount++;
        //            if (einzahlen)
        //                Account.Einzahlen(betrag);
        //            else
        //            {
        //                Account.Auszahlen(betrag);
        //                betrag *= -1;
        //            }

        //            return betrag;

        //        }).ContinueWith(task => Ausgabe(task.Result));
        //    }
        //}


        static void KontoUpdates()
        {

            for (int i = 0; i < 10000; i++)
            {
                //Task<int> eineTransactionTask = new Task<int>(EinzahlenOderAuszahlen);
                //eineTransactionTask.Start();

                //eineTransactionTask.ContinueWith(myTask => Ausgabe(eineTransactionTask.Result));

                Ausgabe(EinzahlenOderAuszahlen());
            }
        }

        static int EinzahlenOderAuszahlen()
        {
            Random random = new Random();

            int betrag = random.Next(1, 1000);

            //gerade zahl oder ungerade zahl
            bool einzahlen = random.Next() % 2 == 0;
            Account.TransactionCount++;
            if (einzahlen)
                Account.Einzahlen(betrag);
            else
            {
                Account.Auszahlen(betrag);
                betrag *= -1;
            }

            return betrag;
        }





        static void Ausgabe(int betrag)
        {
            Console.WriteLine($"TransactionNr: {Account.TransactionCount} \t Kontostand: {Account.Kontostand} - Veränderung des Kontostandes: {betrag}");
        }

    }


    


    public static class Account
    {
        public static int Kontostand { get; set; } = 0;

        public static int TransactionCount { get;set; } = 0;

        public static void Einzahlen(int betrag) => Kontostand += betrag;

        public static void Auszahlen(int betrag) => Kontostand -= betrag;
    }
}
