//Main Method
LogDelegate logDelegate = new LogDelegate(LogToDb); //<- Die Speicheradresse von der Methode LogToDb (Funktionszeiger) 
logDelegate += LogToEvetLog;

logDelegate("Delegates sind cool"); //Weil sich das Delegate die Methode LogToDb gemerkt hat, kann er diese aufrufen.
ClassMitLogMethoden classMitLogMethoden = new ClassMitLogMethoden();

LogDelegate logDelegate1 = new LogDelegate(classMitLogMethoden.WriteToLogFile); //Methode aus einer Klasse wird gemerkt 
logDelegate1("Kommen wir in WriteToLogFile?");

OffsetDelegate offsetDelegate = new OffsetDelegate(OffSet5);

int ret = offsetDelegate(12);
Console.WriteLine(ret); // 17


//void IrgendwasMit(string Parameter) 
Action<string> myLogActionDelegate = new Action<string>(LogToDb);

myLogActionDelegate += LogToEvetLog;

myLogActionDelegate("Hi from ActionDelegate");



Func<int, int> offsetFunc = new Func<int, int>(OffSet5);

int ret1 = offsetFunc(13);
Console.WriteLine(ret1);



void LogToDb(string nachricht)
{
    Console.WriteLine($"Logge nach DB: {nachricht}"); 
}

void LogToEvetLog(string nachricht)
{
    Console.WriteLine($"Logge nach EventListener: {nachricht}");
}



int OffSet5(int zahl)
{
    return zahl + 5;
}

//Wir definieren ein Delegate, dass nur Methoden 
delegate void LogDelegate(string msg);

delegate int OffsetDelegate(int zahl);

public class ClassMitLogMethoden
{
    public void WriteToLogFile(string msg)
    {
        Console.WriteLine(msg);
    }
}

