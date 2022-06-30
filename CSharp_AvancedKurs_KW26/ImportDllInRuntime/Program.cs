using System;
using System.Collections.Generic;
using System.Reflection;

namespace ImportDllInRuntime
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Assembly repäsentiert eine Dll/Exe im geladenen Zustand (Arbeitsspeicher) 
            Assembly geladeneDll = Assembly.LoadFrom("Taschenrechner.dll");

            //Kleiner Rundumblock über Assembly
            //Alle Definierten Typen in dieser Dll
            //IEnumerable<TypeInfo> allType = geladeneDll.DefinedTypes;

            Type taschenrechnerClassAsType = geladeneDll.GetType("Taschenrechner.MyCalc");

            //Rundumblick über Type
            //bool isClass = taschenrechnerClassAsType.IsClass;
            //bool isAbstract = taschenrechnerClassAsType.IsAbstract;
            //Type basisType = taschenrechnerClassAsType.BaseType;


            //Merke mir den Einstiegspunkt der Instance MyCalc
            object objAddress = Activator.CreateInstance(taschenrechnerClassAsType);

            MethodInfo methodeInfo = taschenrechnerClassAsType.GetMethod("Add", new Type[] { typeof(Int32), typeof(Int32) });

            object result = methodeInfo.Invoke(objAddress, new object[] { 11, 33 });
            Console.WriteLine(result); //44


            Console.ReadLine();
        }
    }
}
