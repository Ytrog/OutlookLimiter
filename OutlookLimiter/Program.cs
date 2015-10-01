using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OutlookLimiter
{
    static class Program
    {

        private static readonly Mutex _mutex = new Mutex(true, "{7A9F883F-BDF6-430E-9C97-69F0C50BE5AA}");

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {


            if (!_mutex.WaitOne(TimeSpan.Zero, true)) return;

            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            finally
            {
                _mutex.ReleaseMutex();
            }
        }
    }
}
