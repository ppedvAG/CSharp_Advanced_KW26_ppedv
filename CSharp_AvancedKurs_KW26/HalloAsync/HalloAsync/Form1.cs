using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HalloAsync
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                progressBar1.Value = i;
                Thread.Sleep(200);
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //hintergrund thread
            for (int i = 0; i < 100; i++)
            {
                //progressBar1.Value = i;
                backgroundWorker1.ReportProgress(i);
                Thread.Sleep(200);
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //GUI Thread
            MessageBox.Show("Backgroundworker hat fertig!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //GUI Thread
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //GUI Thread
            progressBar1.Value = e.ProgressPercentage;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Parallel.Invoke(Zähle, Zähle, Zähle, Zähle);
            //Parallel.For(0, 10000, i => Debug.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: {i}"));

        }

        private void Zähle()
        {
            for (int i = 0; i < 100; i++)
            {
                Debug.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: {i}");
            }
        }



        /// <summary>
        /// BEISPIEL: TASK GIBT INFORMATION AN GUI 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            //TPL !! Achtung Anonyme Methode
            Task first = Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    //progressBar1.Value = i;
                    progressBar1.Invoke((MethodInvoker)(() => progressBar1.Value = i));
                    Thread.Sleep(200);
                }
            });

            
            first.ContinueWith(sub => Counter());

        }


        private void Counter()
        {
            for (int i = 0; i < 100; i++)
            {
                //progressBar1.Value = i;
                progressBar1.Invoke((MethodInvoker)(() => progressBar1.Value = i));
                Thread.Sleep(200);
            }
        }

        private async Task Counter1()
        {
            for (int i = 0; i < 100; i++)
            {
                //progressBar1.Value = i;
                progressBar1.Value = i;
                await Task.Delay(100);
            }

            return;
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            
            //ASYNC / AWAIT Beispie
            for (int i = 0; i < 100; i++)
            {
                progressBar1.Value = i;
                await Task.Delay(100);
            }

            await Counter1();
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            button6.Enabled = false;
            //string conString = "Server=GibEsNicht;Database=AuchNichtDa;Trusted_Connection=true;Timeout=5";
            string conString = "Server=.;Database=NorthWind;Trusted_Connection=true;";
            try
            {
                using (var con = new SqlConnection(conString))
                {
                    progressBar1.Style = ProgressBarStyle.Marquee;
                    pictureBox1.Visible = true;
                    await con.OpenAsync();
                    using (var cmd = con.CreateCommand())
                    {
                        cmd.CommandText = "WAITFOR DELAY '00:00:10';SELECT * FROM Employees";
                        using (var reader = await cmd.ExecuteReaderAsync()) //befehl wird in DB ausgeführt
                        {
                            var namen = new List<string>();
                            while (await reader.ReadAsync()) //daten werden von DB geholt
                            {
                                namen.Add(reader.GetString(reader.GetOrdinal("FirstName")));
                            }
                            MessageBox.Show(string.Join(", ", namen));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler: {ex.Message}");
            }
            finally
            {
                progressBar1.Style = ProgressBarStyle.Continuous;
                pictureBox1.Visible = !true;
                button6.Enabled = !!!false;
            }
        }

        private void button5_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
