using PluginBase;
using System;

namespace CSharpAdvancedPlugin
{
    public class CSharpAdvancedPluginClass : ICommand
    {
        public string Name => "Kurs Plugin";

        public string Description => "Der Kurs ist sehr gut gelaufen";

        public int Execute()
        {
            Console.WriteLine("Das Plugin wird ausgeführt ...... ;-) ");

            return 0;
        }
    }
}
