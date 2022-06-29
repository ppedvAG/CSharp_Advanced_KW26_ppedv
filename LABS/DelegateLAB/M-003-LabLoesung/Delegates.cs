public class Program
{
	public delegate void Berechnungen(double z1, double z2);
	
	public static void Main(string[] args)
	{
		Berechnungen b = new Berechnungen(Addition);
		b += Subtraktion;
		b += Multiplikation;
		b += DivisionsCalculator.Division;
		
		Action a = Addition;
		a += Subtraktion;
		a += Multiplikation;
		a += DivisionsCalculator.Division;
	}

	public void Addition (double zahl1, double zahl2)
	{
		Console.WriteLine($"{zahl1} + {zahl2} = {zahl1 + zahl2}");
	}

	public void Subtraktion(double zahl1, double zahl2)
	{
		Console.WriteLine($"{zahl1} - {zahl2} = {zahl1 - zahl2}");
	}

	public void Multiplikation(double zahl1, double zahl2)
	{
		Console.WriteLine($"{zahl1} * {zahl2} = {zahl1 * zahl2}");
	}

}

public class DivisionsCalculator
{
	public void Division(double zahl1, double zahl2)
	{
		Console.WriteLine($"{zahl1} : {zahl2} = {zahl1 /  zahl2}");
	}
}