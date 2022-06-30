using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace BenchmarkTestParallelForVsFor
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] durchgänge = { 1_000, 10_000, 50_000, 100_000, 250_000, 500_000, 1_000_000, 5_000_000, 10_000_000, 100_000_000 };

            Stopwatch watch = new Stopwatch();

            for (int i = 0; i < durchgänge.Length; i++)
            {
                Console.WriteLine($"Schleifenanzahl - Test:  {durchgänge[i]}");

                watch.Restart();
                ForSchleife(durchgänge[i]);
                watch.Stop();

                Console.WriteLine($"For: {watch.ElapsedMilliseconds}ms");


                watch.Restart();
                ParallelFor(durchgänge[i]);
                watch.Stop();

                Console.WriteLine($"Parallel.For: {watch.ElapsedMilliseconds}ms");
                Console.WriteLine("---------------------------------------------------");
            }

            Console.ReadLine();
        }

        private static void ForSchleife(int durchgänge)
        {
            double[] erg = new double[durchgänge];

            for (int i = 0; i < durchgänge; i++)
            {
                erg[i] = ((Math.Pow(i, 0.33333333333333333333333333333333333333333333) * Math.Sin(i + 2)) / Math.Exp(i) + Math.Log(i + 1)) * Math.Sqrt(i + 100);
            }
        }

        private static void ParallelFor(int durchgänge)
        {
            double[] erg = new double[durchgänge];

            Parallel.For(0, durchgänge, i =>
            {
                erg[i] = ((Math.Pow(i, 0.33333333333333333333333333333333333333333333) * Math.Sin(i + 2)) / Math.Exp(i) + Math.Log(i + 1)) * Math.Sqrt(i + 100);
            });
        }
    }
}
