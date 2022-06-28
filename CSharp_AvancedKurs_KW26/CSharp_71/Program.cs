

int number = 0; //default 

int? nullableNumber = null; //beIm auslesen auf nullableNumber.Value gehen 

if (nullableNumber == null)
{

}

if (nullableNumber is null)
{

}

if (nullableNumber.HasValue)
{
    Console.WriteLine(nullableNumber.Value);
}


decimal? nullableDecimal = null;

bool? nullableBooleanValue = null;

Person p = null;

if (p == null)
    p = new Person();

if (p != null)
{

}



void MyLogic(int? a, bool? kaffeHeuteGetrunken)
{
    //Erwarten, dass alle Variablen einen Wert haben -> Defensives Programmieren 
    if (!a.HasValue || !kaffeHeuteGetrunken.HasValue)
        throw new ArgumentException();


}

class Person
{
    string Name { get; set; }
}



