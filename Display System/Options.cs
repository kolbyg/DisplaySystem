using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

namespace Display_System
{
    public partial class Options : Form
    {
        public Options()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = Properties.Settings.Default.BackColor;
            colorDialog1.ShowDialog();
            Properties.Settings.Default.BackColor = colorDialog1.Color;
            Properties.Settings.Default.Save();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = Properties.Settings.Default.ForeColor;
            colorDialog1.ShowDialog();
            Properties.Settings.Default.ForeColor = colorDialog1.Color;
            Properties.Settings.Default.Save();
        }

        private void Options_Load(object sender, EventArgs e)
        {
            doLoad();
        }
        private void doLoad()
        {
            txtPath.Text = Properties.Settings.Default.Path;
            txtSunday.Text = Regex.Escape(Properties.Settings.Default.PanelSundayText);
            txtMonday.Text = Regex.Escape(Properties.Settings.Default.PanelMondayText);
            txtTuesday.Text = Regex.Escape(Properties.Settings.Default.PanelTuesdayText);
            txtWednesday.Text = Regex.Escape(Properties.Settings.Default.PanelWednesdayText);
            txtThursday.Text = Regex.Escape(Properties.Settings.Default.PanelThursdayText);
            txtFriday.Text = Regex.Escape(Properties.Settings.Default.PanelFridayText);
            txtSaturday.Text = Regex.Escape(Properties.Settings.Default.PanelSaturdayText);
            txtTickDelay.Text = Properties.Settings.Default.TickDelay.ToString();
            txtRefreshDelay.Text = Properties.Settings.Default.LongTickDelay.ToString();
            txtPicDelay.Text = Properties.Settings.Default.PictureRotatorDelay.ToString();
            txtMessageDelay.Text = Properties.Settings.Default.MessageRotatorDelay.ToString();
            cmbPanelFormat.SelectedItem = Properties.Settings.Default.PanelFormat;
            txtDateTime.Text = Properties.Settings.Default.DateTimeFormat;
            txtPanelOverride.Text = Regex.Escape(Properties.Settings.Default.ManualPanelOverride);
            txtPanelImagePath.Text = Properties.Settings.Default.PanelImagePath;
            checkBox1.Checked = Properties.Settings.Default.MessageRotatorLargeText;
            enableNet.Checked = Properties.Settings.Default.EnableNetworking;
            chkClientConn.Checked = Properties.Settings.Default.EnableClientConnections;
            chkStretchImage.Checked = Properties.Settings.Default.StretchImage;
            txtClientPSK.Text = Properties.Settings.Default.PSK;
            if (Properties.Settings.Default.PanelFormat == "image")
            {
                sunEdit.Enabled = false;
                monEdit.Enabled = false;
                tuesEdit.Enabled = false;
                wedsEdit.Enabled = false;
                thursEdit.Enabled = false;
                friEdit.Enabled = false;
                satEdit.Enabled = false;
                ovrEdit.Enabled = false;
                txtSunday.Enabled = false;
                txtMonday.Enabled = false;
                txtTuesday.Enabled = false;
                txtWednesday.Enabled = false;
                txtThursday.Enabled = false;
                txtFriday.Enabled = false;
                txtSaturday.Enabled = false;
                txtPanelOverride.Enabled = false;
                txtPanelImagePath.Enabled = true;
                selectOvrImage.Enabled = true;
            }
            else
            {
                sunEdit.Enabled = true;
                monEdit.Enabled = true;
                tuesEdit.Enabled = true;
                wedsEdit.Enabled = true;
                thursEdit.Enabled = true;
                friEdit.Enabled = true;
                satEdit.Enabled = true;
                ovrEdit.Enabled = true;
                txtSunday.Enabled = true;
                txtMonday.Enabled = true;
                txtTuesday.Enabled = true;
                txtWednesday.Enabled = true;
                txtThursday.Enabled = true;
                txtFriday.Enabled = true;
                txtSaturday.Enabled = true;
                txtPanelOverride.Enabled = true;
                txtPanelImagePath.Enabled = false;
                selectOvrImage.Enabled = false;
            }
            if (Properties.Settings.Default.EnableNetworking)
            {
                txtServerIP.Enabled = true;
                txtServerPort.Enabled = true;
                btnTestSrvConn.Enabled = true;
                btnConnServer.Enabled = true;
                chkClientConn.Enabled = true;
                txtClientPSK.Enabled = true;
            }
            else
            {
                txtServerIP.Enabled = false;
                txtServerPort.Enabled = false;
                btnTestSrvConn.Enabled = false;
                btnConnServer.Enabled = false;
                chkClientConn.Enabled = false;
                txtClientPSK.Enabled = false;
            }
        }
        private void tabPage4_Click(object sender, EventArgs e)
        {

        }
        private void txtSunday_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.PanelSundayText = Regex.Unescape(txtSunday.Text);
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                Variables.logger.LogLine(ex.Message);
            }
        }

        private void txtMonday_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.PanelMondayText = Regex.Unescape(txtMonday.Text);
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                Variables.logger.LogLine(ex.Message);
            }
        }

        private void txtTuesday_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.PanelTuesdayText = Regex.Unescape(txtTuesday.Text);
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                Variables.logger.LogLine(ex.Message);
            }
        }

        private void txtWednesday_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.PanelWednesdayText = Regex.Unescape(txtWednesday.Text);
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                Variables.logger.LogLine(ex.Message);
            }
        }

        private void txtThursday_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.PanelThursdayText = Regex.Unescape(txtThursday.Text);
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                Variables.logger.LogLine(ex.Message);
            }
        }

        private void txtFriday_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.PanelFridayText = Regex.Unescape(txtFriday.Text);
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                Variables.logger.LogLine(ex.Message);
            }
        }

        private void txtSaturday_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.PanelSaturdayText = Regex.Unescape(txtSaturday.Text);
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                Variables.logger.LogLine(ex.Message);
            }
        }

        private void txtPath_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Path = txtPath.Text;
            Properties.Settings.Default.Save();
        }

        private void txtDateTime_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.DateTimeFormat = txtDateTime.Text;
            Properties.Settings.Default.Save();
        }

        private void cmbPanelFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.PanelFormat = cmbPanelFormat.SelectedItem.ToString();
            Properties.Settings.Default.Save();
            doLoad();
        }

        private void txtPanelOverride_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.ManualPanelOverride = Regex.Unescape(txtPanelOverride.Text);
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                Variables.logger.LogLine(ex.Message);
            }
        }

        private void txtPanelImagePath_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.PanelImagePath = txtPanelImagePath.Text;
            Properties.Settings.Default.Save();
        }

        private void txtTickDelay_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.TickDelay = Convert.ToInt32(txtTickDelay.Text);
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid Format, Numbers only please. " + ex.Message);
            }
        }

        private void txtRefreshDelay_TextChanged(object sender, EventArgs e)
        {

            try
            {
                Properties.Settings.Default.LongTickDelay = Convert.ToInt32(txtRefreshDelay.Text);
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid Format, Numbers only please. " + ex.Message);
            }
        }

        private void txtPicDelay_TextChanged(object sender, EventArgs e)
        {

            try
            {
                Properties.Settings.Default.PictureRotatorDelay = Convert.ToInt32(txtPicDelay.Text);
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid Format, Numbers only please. " + ex.Message);
            }
        }

        private void txtMessageDelay_TextChanged(object sender, EventArgs e)
        {

            try
            {
                Properties.Settings.Default.MessageRotatorDelay = Convert.ToInt32(txtMessageDelay.Text);
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid Format, Numbers only please. " + ex.Message);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked != Properties.Settings.Default.MessageRotatorLargeText)
            {
                DialogResult result = MessageBox.Show("This will recreate your current messages file. Please be sure you have backups of your messages.\n\nDo you want to continue?", "Continue?", MessageBoxButtons.YesNo);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    if (File.Exists(Properties.Settings.Default.Path + "\\messages.txt"))
                        File.Delete(Properties.Settings.Default.Path + "\\messages.txt");
                    Properties.Settings.Default.MessageRotatorLargeText = checkBox1.Checked;
                    Properties.Settings.Default.Save();
                }
            }
            doLoad();
        }

        private void sunEdit_Click(object sender, EventArgs e)
        {
            using (TextEditor editor = new TextEditor())
            {
                editor.InitialText = Properties.Settings.Default.PanelSundayText;
                editor.Caption = "Edit Sunday Text";
                DialogResult result = editor.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                    Properties.Settings.Default.PanelSundayText = editor.FinalText;
            }
            doLoad();
        }

        private void monEdit_Click(object sender, EventArgs e)
        {
            using (TextEditor editor = new TextEditor())
            {
                editor.InitialText = Properties.Settings.Default.PanelMondayText;
                editor.Caption = "Edit Monday Text";
                DialogResult result = editor.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                    Properties.Settings.Default.PanelMondayText = editor.FinalText;
            }
            doLoad();
        }

        private void tuesEdit_Click(object sender, EventArgs e)
        {
            using (TextEditor editor = new TextEditor())
            {
                editor.InitialText = Properties.Settings.Default.PanelTuesdayText;
                editor.Caption = "Edit Tuesday Text";
                DialogResult result = editor.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                    Properties.Settings.Default.PanelTuesdayText = editor.FinalText;
            }
            doLoad();
        }

        private void wedsEdit_Click(object sender, EventArgs e)
        {
            using (TextEditor editor = new TextEditor())
            {
                editor.InitialText = Properties.Settings.Default.PanelWednesdayText;
                editor.Caption = "Edit Wednesday Text";
                DialogResult result = editor.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                    Properties.Settings.Default.PanelWednesdayText = editor.FinalText;
            }
            doLoad();
        }

        private void thursEdit_Click(object sender, EventArgs e)
        {
            using (TextEditor editor = new TextEditor())
            {
                editor.InitialText = Properties.Settings.Default.PanelThursdayText;
                editor.Caption = "Edit Thursday Text";
                DialogResult result = editor.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                    Properties.Settings.Default.PanelThursdayText = editor.FinalText;
            }
            doLoad();
        }

        private void friEdit_Click(object sender, EventArgs e)
        {
            using (TextEditor editor = new TextEditor())
            {
                editor.InitialText = Properties.Settings.Default.PanelFridayText;
                editor.Caption = "Edit Friday Text";
                DialogResult result = editor.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                    Properties.Settings.Default.PanelFridayText = editor.FinalText;
            }
            doLoad();
        }

        private void satEdit_Click(object sender, EventArgs e)
        {
            using (TextEditor editor = new TextEditor())
            {
                editor.InitialText = Properties.Settings.Default.PanelSaturdayText;
                editor.Caption = "Edit Saturday Text";
                DialogResult result = editor.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                    Properties.Settings.Default.PanelSaturdayText = editor.FinalText;
            }
            doLoad();
        }

        private void ovrEdit_Click(object sender, EventArgs e)
        {
            using (TextEditor editor = new TextEditor())
            {
                editor.InitialText = Properties.Settings.Default.ManualPanelOverride;
                editor.Caption = "Edit Override Text";
                DialogResult result = editor.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                    Properties.Settings.Default.ManualPanelOverride = editor.FinalText;
            }
            doLoad();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            Properties.Settings.Default.PanelImagePath = openFileDialog1.FileName;
            doLoad();
        }

        private void selectOvrImage_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            doLoad();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            Properties.Settings.Default.Path = folderBrowserDialog1.SelectedPath;
            Properties.Settings.Default.Save();
            doLoad();
        }

        private void enableNet_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.EnableNetworking = enableNet.Checked;
            Properties.Settings.Default.Save();
            doLoad();
        }

        private void chkClientConn_CheckedChanged(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.EnableClientConnections != chkClientConn.Checked)
            {
                if (chkClientConn.Checked)
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to enable client connections?\n\nThis will allow anyone running the tray app to control this diplay system.", "Networking", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        Properties.Settings.Default.EnableClientConnections = chkClientConn.Checked;
                        Properties.Settings.Default.Save();
                    }
                }
                else
                {
                    Properties.Settings.Default.EnableClientConnections = chkClientConn.Checked;
                    Properties.Settings.Default.Save();
                }
            }
        }

        private void btnTestSrvConn_Click(object sender, EventArgs e)
        {

        }

        private void chkStretchImage_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.StretchImage = chkStretchImage.Checked;
            Properties.Settings.Default.Save();
            doLoad();
        }

        private void txtClientPSK_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.PSK = txtClientPSK.Text;
            Properties.Settings.Default.Save();
            doLoad();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Environment.CurrentDirectory);
        }
    }
}
