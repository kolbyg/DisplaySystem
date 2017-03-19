using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using System.Text.RegularExpressions;

namespace Display_System
{
    public partial class Display : Form
    {
        bool alert = false;
        public Display()
        {
            InitializeComponent();
            Variables.logger = new IO.Logger(Variables.logVerbosity, Variables.logPath);
            Variables.logger.LogLine("Starting Initialization");
            IO.Init.runInit();
            controlTimers(true);
            refreshAll();
        }
        private void refreshAll()
        {
            IO.Init.runInit();
            BackColor = Properties.Settings.Default.BackColor;
            ForeColor = Properties.Settings.Default.ForeColor;
            lblPanel.BackColor = Properties.Settings.Default.BackColor;
            lblDateTime.BackColor = Properties.Settings.Default.BackColor;
            lblRotator.BackColor = Properties.Settings.Default.BackColor;
            lblPanel.ForeColor = Properties.Settings.Default.ForeColor;
            lblDateTime.ForeColor = Properties.Settings.Default.ForeColor;
            lblRotator.ForeColor = Properties.Settings.Default.ForeColor;
            picDisplay.BackColor = Properties.Settings.Default.BackColor;
            mainTick.Interval = Properties.Settings.Default.TickDelay;
            picTick.Interval = Properties.Settings.Default.PictureRotatorDelay;
            msgTick.Interval = Properties.Settings.Default.MessageRotatorDelay;
            longTick.Interval = Properties.Settings.Default.LongTickDelay;
            if(Properties.Settings.Default.StretchImage)
            {
                picDisplay.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                picDisplay.SizeMode = PictureBoxSizeMode.Zoom;
            }
            if (Properties.Settings.Default.MessageRotatorLargeText)
            {
                lblRotator.Font = new Font(FontFamily.GenericSansSerif, 36);
            }
            else
            {
                lblRotator.Font = new Font(FontFamily.GenericSansSerif, 24);
            }
            if (Properties.Settings.Default.PanelFormat == "text")
            {
                lblPanel.Text = Rotators.PanelRotator.DisplayText();
                lblPanel.Visible = true;
                picPanel.Visible = false;
            }
            else if (Properties.Settings.Default.PanelFormat == "image")
            {
                picPanel.Image = Rotators.PanelRotator.DisplayImage();
                lblPanel.Visible = false;
                picPanel.Visible = true;
            }
        }
        private void controlTimers(bool value)
        {
            mainTick.Enabled = value;
            picTick.Enabled = value;
            msgTick.Enabled = value;
            longTick.Enabled = value;
        }
        private void Display_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F6)
            {
                controlTimers(false);
                using (Options options = new Options())
                {
                    options.ShowDialog();
                }
                IO.Init.genPanelTextFile();
                refreshAll();
                controlTimers(true);
                //MessageBox.Show("Config functions are disabled in this version, please edit the file \"Display System.exe.config\" in the program directory");
            }
            else if (e.KeyCode == Keys.F7)
            {
                //DialogResult result = MessageBox.Show("Send the log file to the developer?", "Error Reporting", MessageBoxButtons.YesNo);
                //if (result == System.Windows.Forms.DialogResult.Yes)
                //IO.Email.EmailLog();
            }
            else if (e.KeyCode == Keys.F8)
            {
                using (About about = new About())
                {
                    about.ShowDialog();
                }
            }
            else if (e.KeyCode == Keys.F2)
            {
               DialogResult result = MessageBox.Show("Exit Now?","Exit",MessageBoxButtons.YesNo);
               if (result == System.Windows.Forms.DialogResult.Yes)
                   Environment.Exit(0);
            }
            else if (e.KeyCode == Keys.F4)
            {
                refreshAll();
            }
        }

        private void mainTick_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString(Properties.Settings.Default.DateTimeFormat);
            if (File.Exists(Properties.Settings.Default.Path + "\\alert"))
            {
                if (!alert)
                {
                    Variables.logger.LogLine("Alert file present, and alert will be triggered.");
                    string[] alertinfo = File.ReadAllLines(Properties.Settings.Default.Path + "\\alert");
                    if (alertinfo != null)
                    {
                        if (alertinfo.Length == 4)
                        {
                            lblAlert.Visible = true;
                            lblAlert.BringToFront();
                            lblAlert.BackColor = Color.FromName(alertinfo[0].Replace(" ", ""));
                            lblAlert.ForeColor = Color.FromName(alertinfo[1].Replace(" ", ""));
                            lblAlert.Text = Regex.Unescape(alertinfo[2]);
                            lblAlert.Left = 0;
                            lblAlert.Top = 0;
                            lblAlert.Height = 768;
                            lblAlert.Width = 1024;
                            if (Convert.ToBoolean(alertinfo[3].Replace(" ", "")))
                                lblAlert.TextAlign = ContentAlignment.TopCenter;
                            else
                                lblAlert.TextAlign = ContentAlignment.TopLeft;
                            Variables.logger.LogLine("Alert triggered. The content of the alert is: " + alertinfo[2]);
                            alert = true;
                        }
                        else
                        {
                            Variables.logger.LogLine(2, "Alert file was formatted incorrectly, loading aborted.");
                        }
                    }
                }
            }
            else
            {
                lblAlert.Visible = false;
                if (alert)
                    alert = false;
            }
        }

        private void picTick_Tick(object sender, EventArgs e)
        {
            if (Variables.runVideo)
            {
                MediaPlayer.Visible = true;
                picDisplay.Visible = false;
                if (MediaPlayer.playState == WMPLib.WMPPlayState.wmppsStopped || MediaPlayer.playState == WMPLib.WMPPlayState.wmppsUndefined || MediaPlayer.playState == WMPLib.WMPPlayState.wmppsReady)
                {
                    string path = Rotators.VideoRotator.GetNextVideo();
                    MediaPlayer.uiMode = "none";
                    MediaPlayer.URL = path;
                    MediaPlayer.settings.mute = true;
                    MediaPlayer.settings.setMode("loop", false);
                }
            }
            else
            {
                picDisplay.Visible = true;
                MediaPlayer.Visible = false;
                picDisplay.Image = Rotators.PictureRotator.GetNextImage();
            }
            GC.Collect();
        }

        private void msgTick_Tick(object sender, EventArgs e)
        {
            string toDisplay = Rotators.MessageRotator.GetNextMessage();
            if (toDisplay != null)
            {
                lblRotator.Text = toDisplay;
            }
        }

        private void longTick_Tick(object sender, EventArgs e)
        {
            refreshAll();
        }

        private void MediaPlayer_PositionChange(object sender, AxWMPLib._WMPOCXEvents_PositionChangeEvent e)
        {

        }

        private void MediaPlayer_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (MediaPlayer.playState == WMPLib.WMPPlayState.wmppsStopped || MediaPlayer.playState == WMPLib.WMPPlayState.wmppsUndefined || MediaPlayer.playState == WMPLib.WMPPlayState.wmppsReady)
            {
                picTick.Enabled = true;
            }
            else if(MediaPlayer.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                picTick.Enabled = false;
            }
        }

        private void lblRotator_Click(object sender, EventArgs e)
        {

        }

        private void Display_Load(object sender, EventArgs e)
        {
        }
    }
}
