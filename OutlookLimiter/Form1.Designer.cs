namespace OutlookLimiter
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnOverride = new System.Windows.Forms.Button();
            this.pbCountdown = new System.Windows.Forms.ProgressBar();
            this.timerTicker = new System.Windows.Forms.Timer(this.components);
            this.ttProgress = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(13, 13);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnOverride
            // 
            this.btnOverride.Location = new System.Drawing.Point(95, 13);
            this.btnOverride.Name = "btnOverride";
            this.btnOverride.Size = new System.Drawing.Size(75, 23);
            this.btnOverride.TabIndex = 1;
            this.btnOverride.Text = "Override";
            this.btnOverride.UseVisualStyleBackColor = true;
            // 
            // pbCountdown
            // 
            this.pbCountdown.Location = new System.Drawing.Point(13, 43);
            this.pbCountdown.Name = "pbCountdown";
            this.pbCountdown.Size = new System.Drawing.Size(256, 23);
            this.pbCountdown.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbCountdown.TabIndex = 2;
            this.pbCountdown.MouseHover += new System.EventHandler(this.pbCountdown_MouseHover);
            // 
            // timerTicker
            // 
            this.timerTicker.Interval = 1000;
            this.timerTicker.Tick += new System.EventHandler(this.timerTicker_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 90);
            this.Controls.Add(this.pbCountdown);
            this.Controls.Add(this.btnOverride);
            this.Controls.Add(this.btnStart);
            this.Name = "Form1";
            this.Text = "Outlook limiter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnOverride;
        private System.Windows.Forms.ProgressBar pbCountdown;
        private System.Windows.Forms.Timer timerTicker;
        private System.Windows.Forms.ToolTip ttProgress;
    }
}

