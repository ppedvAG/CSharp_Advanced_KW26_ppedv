using Microsoft.Data.SqlClient;
using System;
using System.Threading.Tasks;

namespace AwaitAsyncSample
{
    internal class Program
    {
        static async void Main(string[] args)
        {
            //Synchrone CallServer-Methode
            CallSqlServer();

            Task task = CallSqlServerAsync();
            task.Wait();


            await CallSqlServerAsync();
            //

            await Task.Run(() =>
            {
                Task.Delay(10000).Wait();
                Console.WriteLine("Task hat 10 Sekunden geartet");
            });



        }

        static async void CallSqlServer()
        {

            #region Wie wir es von der TPL kennen
            SqlConnection conn = new SqlConnection("einConnectionString");
            Task sqlOpenConnectionTask = conn.OpenAsync();
            sqlOpenConnectionTask.Wait();



            Task<bool> task = IchBinEineAssynchroneMethodeAsync();
            task.Wait();

            if (task.Result)
                Console.WriteLine("IchBinEineAssynchroneMethodeAsync geklappt");
            else
                Console.WriteLine("IchBinEineAssynchroneMethodeAsync nicht geklappt");
            #endregion

            #region async/await Pattern


            await conn.OpenAsync();

            bool boolReturnValue = await IchBinEineAssynchroneMethodeAsync();

            #endregion


        }


        static async Task CallSqlServerAsync()
        {

            #region Wie wir es von der TPL kennen
            SqlConnection conn = new SqlConnection("einConnectionString");
            Task sqlOpenConnectionTask = conn.OpenAsync();
            sqlOpenConnectionTask.Wait();



            Task<bool> task = IchBinEineAssynchroneMethodeAsync();
            task.Wait();

            if (task.Result)
                Console.WriteLine("IchBinEineAssynchroneMethodeAsync geklappt");
            else
                Console.WriteLine("IchBinEineAssynchroneMethodeAsync nicht geklappt");
            #endregion

            #region async/await Pattern


            await conn.OpenAsync();

            bool boolReturnValue = await IchBinEineAssynchroneMethodeAsync();

            #endregion


        }

        static Task<bool> IchBinEineAssynchroneMethodeAsync()
        {
            //Wir machen etwas in einer Asynchronen Methode

            return Task.FromResult(true); //Wir geben true als Return-Value zurüclk 
        }
    }
}
