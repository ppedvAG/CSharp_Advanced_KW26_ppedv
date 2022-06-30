using System;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HalloAsync
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartOhneThread(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                pb1.Value = i;
                Thread.Sleep(300);
            }
        }

        private void StartTask(object sender, RoutedEventArgs e)
        {
            ((Button)sender).IsEnabled = false;

            Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    pb1.Dispatcher.Invoke(() => pb1.Value = i);
                    Thread.Sleep(30);
                }
                this.Dispatcher.Invoke(() => ((Button)sender).IsEnabled = true);
            });
        }

        CancellationTokenSource cts = null;

        private void StartTaskMitTS(object sender, RoutedEventArgs e)
        {
            ((Button)sender).IsEnabled = false;
            var ts = TaskScheduler.FromCurrentSynchronizationContext();
            cts = new CancellationTokenSource();

            Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Task.Factory.StartNew(() => pb1.Value = i, CancellationToken.None, TaskCreationOptions.None, ts);
                    Thread.Sleep(30);
                    if (cts.IsCancellationRequested)
                        break; //cleanup
                }
                //Task.Factory.StartNew(() => ((Button)sender).IsEnabled = true, CancellationToken.None, TaskCreationOptions.None, ts);
            }).ContinueWith(t => ((Button)sender).IsEnabled = true, CancellationToken.None, TaskContinuationOptions.None, ts);
        }

        private void Abort(object sender, RoutedEventArgs e)
        {
            cts?.Cancel();
        }

        private async void StartAA(object sender, RoutedEventArgs e)
        {
            cts = new CancellationTokenSource();

            for (int i = 0; i < 100; i++)
            {
                pb1.Value = i;
                try
                {
                    await Task.Delay(300, cts.Token);
                }
                catch (TaskCanceledException) { }
            }
        }

        private async void CountEmps(object sender, RoutedEventArgs e)
        {
            ((Button)sender).IsEnabled = false;
            pb1.IsIndeterminate = true;
            cts = new CancellationTokenSource();

            try
            {
                var conString = "Server=(localdb)\\mssqllocaldb;Database=NORTHWND;Trusted_Connection=true";

                using (var con = new SqlConnection(conString))
                {
                    await con.OpenAsync(cts.Token);

                    using (var cmd = con.CreateCommand())
                    {
                        cmd.CommandText = "WAITFOR DELAY '0:0:10';SELECT count(*) FROM Employees";
                        var count = await cmd.ExecuteScalarAsync(cts.Token);

                        con.Close();

                        MessageBox.Show($"{count} Employees found");
                    }
                }
            }
            catch (TaskCanceledException)
            {
                MessageBox.Show("Abgebrochen");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler: {ex.Message}");
            }

            ((Button)sender).IsEnabled = !false;
            pb1.IsIndeterminate = !true;

        }

        private async void AlteMethode(object sender, RoutedEventArgs e)
        {
            MessageBox.Show((await AlteFunktionAsync("Hallo")).ToString());
        }

        public Task<long> AlteFunktionAsync(string text)
        {
            return Task.Run<long>(() => AlteFunktion(text));
        }

        public long AlteFunktion(string text)
        {
            Thread.Sleep(5000);
            return text.Length * 67834;
        }
    }
}
