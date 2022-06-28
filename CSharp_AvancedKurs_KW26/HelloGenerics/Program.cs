#nullable disable

#region Sample1
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


//string ersetzt hier den Platzhalter T 
DataStore<string> dataStore = new DataStore<string>();

dataStore.AddTryUpdate(0, "Hallo");


MyDictionary<int, string> myDictionary = new MyDictionary<int, string>();
myDictionary.Add(1, "Hallo");


myDictionary.DeplatzierteGenerischeMethode<DateTime>(DateTime.Now);
#endregion








#region Sample 1 -> Was sind generische Klassen/Methoden


//T -> Platzhalter für einen Datentypen
public class DataStore<T>
{
    private T[] _data = new T[10];

    public T[] Data
    {
        get => _data;
        set => _data = value;
    }

    public void AddTryUpdate(int index, T item)
    {
        if (index >= 0 && index < 10)
            _data[index] = item;
    }


    public void DeplatzierteGenerischeMethode<T2>(T2 parameter)
    {
        //T gilt hier nur Methodenweit
        Console.WriteLine(parameter.ToString());
    }

}

public class MyDictionary <TKey, TValue>
{
    List<KeyValuePair<TKey, TValue>> dictionaryListe;

    public MyDictionary()
    {
        dictionaryListe = new List<KeyValuePair<TKey, TValue>>();
    }

    public void Add(TKey key, TValue value)
    {
        dictionaryListe.Add(new KeyValuePair<TKey, TValue>(key, value));
    }

    public void DeplatzierteGenerischeMethode<H>(H parameter)
    {
        //T gilt hier nur Methodenweit
        Console.WriteLine(parameter.ToString());
    }
}

#endregion

//DataStore3a<Animal> animalStore = new DataStore3a<Animal>();
//DataStore3a<Human> animalStore1 = new DataStore3a<Human>();



//In T dürfen nur Referenztypen (Klasse, Interfaces, string, record , List<T>, Animal/Dog -> weil es eine Klasse ist
public class DataStore1<T> where T : class 
{
}

//In T dürfen nur Wertettypen (Structs, int, float, bool, double, chars .... ) 
public class DataStore2<T> where T : struct
{

}
// In T dürfen nur Animal oder abgeleitete Klasse von Animal (Vererbungsbaum) 
public class DataStore3<T> where T : Animal
{

}

public class DataStore3a<T> where T : IAnimal, IAlienAnimal
{

}

//Hier dürfen nur Objekte, die einen Default-Konstruktor beinhalten
public class DataStore4<T> where T : new()
{

}


public interface IAnimal
{
    DateTime Birthday { get; set; }
}


public class Animal
{
    public Animal() //<- Default-Konstruktor
    {
        //hier darf stehen 
    }
    public string Name { get; set; } = "R2D2";
    public DateTime Birthday { get; set; }
    public bool WithHair { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}

public class Dog : Animal
{
    public string Hunderasse { get; set; } = "ein wau wau";
}

