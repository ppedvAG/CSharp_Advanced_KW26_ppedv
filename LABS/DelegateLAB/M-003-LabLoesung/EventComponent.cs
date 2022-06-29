public class PrimeComponent
{
	public event Action<int, int> NotPrime;
	public event Action<int> Prime;
	public event Action<int> Prime100;
	
	public void StartProcess()
	{
		Prime(2);
		for (int i = 3, counter = 0; ; i += 2)
		{
			if (CheckPrime(i))
			{
				Prime(i);
				counter++;
				if (counter % 100 == 0)
					Prime100(i);
			}
			Thread.Sleep(500);
		}
	}
	
	public bool CheckPrime(int num)
	{
		for (int i = num - 1; i >= 2; i--)
		{
			if (num % i == 0)
			{
				NotPrime(num, i);
				return false;
			}
		}
		return true;
	}
}