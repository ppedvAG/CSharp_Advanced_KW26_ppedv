

Console.Write("Bitte geben Sie eine Zahl ein: ");
string input = Console.ReadLine();
int zahl;
//Convert.ToInt32
//int.Parse()

int testNumber = 5;

PseudoOffset(testNumber); //Der Inhalt 5 wird weitergereicht, nicht die Speicheradresse 
Console.WriteLine(testNumber);

PseudoOffsettWithOut(out testNumber);
Console.WriteLine(testNumber);


//out -> wird bei Wertetypen verwenden, die nicht den Inhalt, sondern die Speicheradresse übergeben 
if (int.TryParse(input, out zahl))
{
    Console.WriteLine(zahl.ToString());
}


int eineMillionen = 1_000_000;

decimal geldbeträge = 1999m;

int[] zahlen = { 11, 22, 33, 44, 55, 66, 10, 20 };


//Ich bekomme von der zahlen->Index 4 die Speicheradresse und den Inhalt
ref int position = ref Zahlensuche(55, zahlen);

Console.WriteLine(position); // Ausgaber 55: 
//manip
position = 100_000_000;


foreach (int currentZahl in zahlen)
{
    Console.WriteLine(zahlen.ToString());
}

ref int Zahlensuche(int gesuchteZahl, int[] zahlen)
{
    for (int i = 0; i < zahlen.Length; i++)
    {
        if (gesuchteZahl == zahlen[i])
            return ref zahlen[i];
    }

    throw new IndexOutOfRangeException();
}

#region Referenztypen
/*  Wertetypen:
 *  bool, byte, short, float, decimal, double, int, uint, decimal, long .....
 *  struct, 
 * 
 *  Was passiert bei einem Wertetyp bei einer Zuweisung?
 * 
 *  Was passiert bei einem Wertetyp bei einem Variablenvergleich?
 * 
 */


int a = 5;
int b = 0;

b = a; // Inhalt der Variable wird zugewiesen;

if (a == b)
    Console.WriteLine("gleich");
else
    Console.WriteLine( "ungleich");


// Referenztypen 
// string, class (ArrayList, Listen, weitere Klassenimplementierung), interface, records,

/*
 *   Was passiert bei einem Referenztyp bei einer Zuweisung?
 * 
 *   Was passiert bei einem Referenztyp bei einem Variablenvergleich?
 */


Person p1 = new Person() { Id = 1, Name = "MaxMoritz" };

Person p2 = new Person() { Id = 1, Name = "MaxMoritz" };

//Zuweisung 
Person p3 = p1;

//Vergleich -> Ist es die selbe Speicheradresse

if (p1 == p2)
    Console.WriteLine("Gleich");
else
    Console.WriteLine("Ungleich");



void SwitchStatement(int number)
{
    switch(number)
    {
        case > 20:
            Console.WriteLine("größer als 10");
            break;
        case > 10:
            break;
        default:
            Console.WriteLine("");
            break;
    }
}
void PseudoOffset(int number)
{
    number++;
}


void PseudoOffsettWithOut(out int number)
{
    number = 10; 
}
public class Person
{
    public string Name { get; set; }
    public int Id { get; set; }
}

#endregion
