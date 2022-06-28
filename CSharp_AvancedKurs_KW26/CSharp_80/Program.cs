
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


string str = "Datum von heute ist: " + DateTime.Now.ToString();
string str1 = $"Datum von heute ist: {DateTime.Now.ToString()}";

string path = "Personal";
string path2 = @"C:\Windows\Temp"; //Achtung Escape Zeichen werden deaktiviert. -> \n für New Line oder \t für Tabluar
string path3 = $@"C:\Windows\{path}";





