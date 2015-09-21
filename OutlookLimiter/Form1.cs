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
            var defaultTitle = this.Text;
            if (defaultTitle != null) _defaultTitle = defaultTitle;
        }

        private Process _process;
        private int _time = 5;
        private bool _shownWarning = false;
        private readonly string _defaultTitle;
#if BOX
        private Form _messageForm;
#endif


        private void btnStart_Click(object sender, EventArgs e)
        {
            _time = Convert.ToInt32(cmbTime.SelectedItem);
            _process = GetProcess();
            Text = _defaultTitle + " - " + _process.Id;
            btnStart.Enabled = false;
            cmbTime.Enabled = false;
            StartTimer();
        }

        private static Process GetProcess()
        {
            Process[] processes = Process.GetProcessesByName("outlook");

            return processes.FirstOrDefault() ?? Process.Start("outlook.exe");
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

            if (pbCountdown.Value < pbCountdown.Maximum && _process.Running())
            {
                pbCountdown.PerformStep();
                
                if (pbCountdown.Value >= (pbCountdown.Maximum - 60) && pbCountdown.Maximum > 60 && !_shownWarning)
                {
                    _shownWarning = true;

#if BOX
                    _messageForm = CreateBlankForm();
                    _messageForm.Show(this);
                    MessageBox.Show(_messageForm,"time almost up");
#else
                    MessageBox.Show("time almost up");
#endif

                    
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
            _process.Stop();
            btnStart.Enabled = true;
            pbCountdown.Value = 0;
            timerTicker.Stop();
            Text = _defaultTitle;
#if BOX
            if (_messageForm != null)
            {
                _messageForm.Close();
            }
#endif

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _process.Stop();
        }

        private void btnOverride_Click(object sender, EventArgs e)
        {
            if (timerTicker.Enabled)
            {
                timerTicker.Enabled = false;
                btnOverride.FlatStyle = FlatStyle.Flat;
            }
            else
            {
                timerTicker.Enabled = true;
                btnOverride.FlatStyle = FlatStyle.Standard;
            }
        }

#if BOX
        private Form CreateBlankForm()
        {
            return new Form() { Size = new Size(0, 0) };
        }
#endif


        
    }
}
