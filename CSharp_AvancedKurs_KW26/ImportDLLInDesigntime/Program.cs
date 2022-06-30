using System;
using Taschenrechner;

namespace ImportDLLInDesigntime
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyCalc myCalc = new MyCalc();
            Console.WriteLine(myCalc.Add(5,6)); //Ausgabe 11: 
            Console.ReadKey();
        }
    }
}
