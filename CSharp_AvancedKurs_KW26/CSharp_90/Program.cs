

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


MyClass class1 = new MyClass();
MyClass class2 = new();

MyClass class3 = new MyClass() { MyGetSetProperty = 12, MySetSetProperty2 = 24 };
//class3.MySetSetProperty2 = 36; // das geht nur mit Set -> ist readonly 




#region Record Vs Class

PersonRecord personRecord1 = new PersonRecord(1, "Mario Bart");
PersonRecord personRecord2 = new PersonRecord(1, "Mario Bart");

PersonClass myPerson1Class = new PersonClass(1, "Helge Schneider");
PersonClass myPerson2Class = new PersonClass(1, "Helge Schneider");



if (myPerson1Class == myPerson2Class)
{
    Console.WriteLine("myPerson1Class == myPerson2Class -> gleich");
}
else
{
    Console.WriteLine("myPerson1Class == myPerson2Class -> ungleich");
}


if (personRecord1 == personRecord2)
{
    Console.WriteLine("personRecord1 == personRecord2 -> gleich");
}
else
{
    Console.WriteLine("personRecord1 == personRecord2 -> ungleich");
}



if (myPerson1Class.Equals(myPerson2Class))
{
    Console.WriteLine("myPerson1Class.Equals(myPerson2Class) -> gleich");
}
else
{
    Console.WriteLine("myPerson1Class.Equals(myPerson2Class) -> ungleich");
}

if (personRecord1.Equals(personRecord2))
{
    Console.WriteLine("personRecord1.Equals(personRecord2) -> gleich");
}
else
{
    Console.WriteLine("personRecord1.Equals(personRecord2) -> ungleich");
}


Console.WriteLine(myPerson1Class.ToString());

Console.WriteLine(personRecord1.ToString());
#endregion


#region Deconstruct in einem record

(int id, string name) = personRecord1; //Deconstruct - Methode
#endregion

#region Default Record hat nur get und init Properties
//personRecord1.Name = "Harry"; //Bringt Fehler  -> Name ist init; 
#endregion

//Methoden, Klassen und Typen immer unterhalb der Top - Level Statement
public class MyClass
{
    public int MyGetSetProperty { get; set; }
    public int MySetSetProperty2 { get; init; } // Kann nur beim initialisieren des Objektes verwendes werden 
}

public record Person (int Id, string FirstName, string SecondName); //Kleinste Schreibweise eines Records

public class PersonClass
{
    public PersonClass(int Id, string Name)
    {
        this.Id = Id;
        this.Name = Name;
    }

    public int Id { get; set; }
    public string Name { get; set; }
}

public record PersonRecord(int Id, string Name);



public record Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; }

    public Employee(int Id, string FirstName)
    {
        this.Id = Id;
        this.FirstName = FirstName;
    }
}

public record Animal(int Id, string Name, DateTime Birthday);

public record Dog : Animal
{

    protected Dog(string color, string height, Animal original) : base(original)
    {
    }

    public string Color { get; set; }
    public string Height { get; set; }

}