using Newtonsoft.Json;
using PluginBase;
using System;
using System.Reflection;

namespace JsonPlugin
{
    public class JsonPlugin : ICommand
    {
        public string Name => "json";

        public string Description => "Outputs JSON value.";

        private struct Info
        {
            public string JsonVersion;
            public string JsonLocation;
            public string Machine;
            public string User;
            public DateTime Date;
        }

        public int Execute()
        {
            Info info = new Info();
            info.JsonLocation = "abc";
            info.Machine = "def";
            info.Date = DateTime.Now;

            Console.WriteLine(JsonConvert.SerializeObject(info, Formatting.Indented));

            return 0;
        }
    }
}
