using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;


namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Process notepad = new Process();
            notepad.StartInfo.FileName = "notepad.exe";
            notepad.StartInfo.Arguments = "test.txt";
            notepad.Start();

            do {

                notepad.Refresh();
                Thread.Sleep(5000);
                System.Console.WriteLine($"Mémoire consommée : {notepad.WorkingSet64}");

            } while (!notepad.HasExited);

            Process[] All = Process.GetProcesses();
            foreach (Process proc in All)
            {
                System.Console.WriteLine(proc);
            }

            System.Console.WriteLine($"Pic maximum : {notepad.PeakWorkingSet64}");
            System.Console.WriteLine("closed");

            /*
            Process nav = new Process ();
            nav.StartInfo.FileName = "Chrome.exe";
            nav.StartInfo.Arguments = "www.google.fr";
            nav.StartInfo.UseShellExecute = true;
            nav.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            nav.Start();
            */

        }

    }
}
