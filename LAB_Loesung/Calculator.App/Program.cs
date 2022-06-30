using System.Reflection;

//Ermitteln des Pfades der ausführbaren Datei
string executeFilePath = Assembly.GetExecutingAssembly().Location;

//Ermitteln des Programm Verzeichnis, indem sich Calculator.App.exe befindet.
string strWorkPath = Path.GetDirectoryName(executeFilePath);

//PlugIn-Verzeichnis
string pluginPath = Path.Combine(strWorkPath, "Plugins");
DirectoryInfo dirInfo = new DirectoryInfo(pluginPath);

if (!dirInfo.Exists)
    new ApplicationException("Plugin-Verzeichnis ist nicht vorhanden");

//Zugriff auf alle Dlls im Plugin-Verzeichnis
FileInfo[] plugIns = dirInfo.GetFiles("*.dll");


IList<ICalculatorPlugIn> plugins = new List<ICalculatorPlugIn>();

foreach (FileInfo currentFileInfo in plugIns)
{
    //Lade DLL 
    Assembly assembly = Assembly.LoadFrom(currentFileInfo.FullName);
    ICalculatorPlugIn pluginInterface = GetPluginInterface(assembly);
    plugins.Add(pluginInterface);
}

Console.WriteLine(plugins.Count +  " Plugins wurden geladen");
//Parameter für die Berechnung
double zahl1 = 32;
double zahl2 = 8;

//Gehe alle Verfügbaren PlugIns durch
foreach (ICalculatorPlugIn plugin in plugins)
{
    Console.WriteLine($"{zahl1} {plugin.OperatorDescription} {zahl2} = {plugin.Operation(zahl1, zahl2)}");
}

ICalculatorPlugIn GetPluginInterface(Assembly assembly)
{
    foreach (Type currentTyp in assembly.GetTypes())
    {
        if (currentTyp.GetInterfaces().Contains(typeof(ICalculatorPlugIn)))
        {
            ICalculatorPlugIn easyPlugIn = Activator.CreateInstance(currentTyp) as ICalculatorPlugIn;
            return easyPlugIn;
        }
    }
    
    string availableTypes = string.Join(",", assembly.GetTypes().Select(t => t.FullName));
    
    throw new ApplicationException(
                    $"Can't find any type which implements ICommand in {assembly} from {assembly.Location}.\n" +
                    $"Available types: {availableTypes}");

}