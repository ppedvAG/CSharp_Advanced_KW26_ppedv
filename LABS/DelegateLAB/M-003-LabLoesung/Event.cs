public class Program
{
	static void Main(string[] args)
	{
		PrimeComponent pc = new PrimeComponent();
		pc.NotPrime += (i, div) => Console.WriteLine($"Keine Primzahl: {i}, teilbar durch {div}");
		pc.Prime += (i) => Console.WriteLine($"Primzahl: {i}");
		pc.Prime100 += (i) => Console.WriteLine($"Hundertste Primzahl: {i}");
		pc.StartProcess();
	}
}