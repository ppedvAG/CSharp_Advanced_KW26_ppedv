using System;
using PluginBase;

namespace PPEDVPlugIn
{
    public class PPEDVCommand : ICommand //Ist ICommand implementiert, wenn ja, dann ist das Plugin kompatibel zu meiner App
    {
        public string Name => "PPEDV Super - Plugin";

        public string Description => "Mit einem Befehl alle Powershell Probleme lösen";

        public int Execute()
        {
            Console.WriteLine("schon fertig :-) ");

            return 0;
        }
    }

    //public class App
    //{
    //    public void Test()
    //    {
    //        ICommand command = new PPEDVCommand();
    //        command.
    //    }
    //}
}
