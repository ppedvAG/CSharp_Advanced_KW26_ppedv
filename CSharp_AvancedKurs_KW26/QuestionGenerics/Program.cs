// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

//Kombinai
MyGenericCombinationClass<AmphibischesVehicle> amphibischesVehicle = new MyGenericCombinationClass<AmphibischesVehicle>();  



public interface IFly
{
    void Fly();
}

public interface IDrive
{
    void Drive();
}

public interface ISwim
{
    void Swim();
}


public class Plain : IFly
{
    public void Fly()
    {
        throw new NotImplementedException();
    }
}

public class Ship : ISwim
{
    public void Swim()
    {
        throw new NotImplementedException();
    }
}


public class AmphibischesVehicle : ISwim, IDrive
{
    public void Drive()
    {
        
    }

    public void Swim()
    {
        
    }
}


public class MyGenericCombinationClass<T> where T : ISwim, IDrive
{

}