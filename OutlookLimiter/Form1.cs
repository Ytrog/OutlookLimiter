using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OutlookLimiter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Process _process;
        private const int _time = 1;
        private bool _shownWarning = false;

        private void btnStart_Click(object sender, EventArgs e)
        {
            _process = Process.Start("outlook.exe");
            btnStart.Enabled = false;
            StartTimer();
        }

        private void StartTimer()
        {
            
            pbCountdown.Maximum = _time*60;
            pbCountdown.Minimum = 0;
            pbCountdown.Step = timerTicker.Interval/1000;
            timerTicker.Start();

        }

        private void timerTicker_Tick(object sender, EventArgs e)
        {

            if (pbCountdown.Value < pbCountdown.Maximum)
            {
                pbCountdown.PerformStep();
                
                if (pbCountdown.Value >= (pbCountdown.Maximum - 60) && pbCountdown.Maximum > 60 && !_shownWarning)
                {
                    _shownWarning = true;
                    MessageBox.Show("time almost up");
                }
            }
            else
            {
                Stop();
            }
        }

        private void pbCountdown_MouseHover(object sender, EventArgs e)
        {
            ttProgress.Show(String.Format("{0}/{1}", pbCountdown.Value, pbCountdown.Maximum), pbCountdown);
        }        

        private void Stop()
        {
            _process.CloseMainWindow();
            btnStart.Enabled = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Stop();
        }
    }
}
