namespace Display_System
{
    partial class Display
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Display));
            this.picDisplay = new System.Windows.Forms.PictureBox();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.lblPanel = new System.Windows.Forms.Label();
            this.lblRotator = new System.Windows.Forms.Label();
            this.mainTick = new System.Windows.Forms.Timer(this.components);
            this.picTick = new System.Windows.Forms.Timer(this.components);
            this.msgTick = new System.Windows.Forms.Timer(this.components);
            this.longTick = new System.Windows.Forms.Timer(this.components);
            this.lblAlert = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.MediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.picPanel = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MediaPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // picDisplay
            // 
            this.picDisplay.BackColor = System.Drawing.Color.DimGray;
            this.picDisplay.Location = new System.Drawing.Point(257, 5);
            this.picDisplay.Name = "picDisplay";
            this.picDisplay.Size = new System.Drawing.Size(760, 540);
            this.picDisplay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picDisplay.TabIndex = 0;
            this.picDisplay.TabStop = false;
            // 
            // lblDateTime
            // 
            this.lblDateTime.BackColor = System.Drawing.Color.Gray;
            this.lblDateTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateTime.Location = new System.Drawing.Point(257, 548);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(760, 47);
            this.lblDateTime.TabIndex = 1;
            this.lblDateTime.Text = "DOTWXXXXX MMXXXXXXX  HH:MM:SS";
            // 
            // lblPanel
            // 
            this.lblPanel.BackColor = System.Drawing.Color.Gray;
            this.lblPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPanel.Location = new System.Drawing.Point(10, 5);
            this.lblPanel.Name = "lblPanel";
            this.lblPanel.Size = new System.Drawing.Size(240, 590);
            this.lblPanel.TabIndex = 2;
            this.lblPanel.Text = "TOP\r\nA\r\nA\r\nA\r\nA\r\nA\r\nA\r\nA";
            this.lblPanel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblRotator
            // 
            this.lblRotator.BackColor = System.Drawing.Color.Gray;
            this.lblRotator.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRotator.Location = new System.Drawing.Point(12, 595);
            this.lblRotator.Name = "lblRotator";
            this.lblRotator.Size = new System.Drawing.Size(1005, 173);
            this.lblRotator.TabIndex = 3;
            this.lblRotator.Text = "The messages file is currently empty.";
            this.lblRotator.Click += new System.EventHandler(this.lblRotator_Click);
            // 
            // mainTick
            // 
            this.mainTick.Tick += new System.EventHandler(this.mainTick_Tick);
            // 
            // picTick
            // 
            this.picTick.Tick += new System.EventHandler(this.picTick_Tick);
            // 
            // msgTick
            // 
            this.msgTick.Tick += new System.EventHandler(this.msgTick_Tick);
            // 
            // longTick
            // 
            this.longTick.Tick += new System.EventHandler(this.longTick_Tick);
            // 
            // lblAlert
            // 
            this.lblAlert.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlert.Location = new System.Drawing.Point(261, 9);
            this.lblAlert.Name = "lblAlert";
            this.lblAlert.Size = new System.Drawing.Size(100, 23);
            this.lblAlert.TabIndex = 4;
            this.lblAlert.Text = "label1";
            this.lblAlert.Visible = false;
            // 
            // MediaPlayer
            // 
            this.MediaPlayer.Enabled = true;
            this.MediaPlayer.Location = new System.Drawing.Point(257, 5);
            this.MediaPlayer.Name = "MediaPlayer";
            this.MediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("MediaPlayer.OcxState")));
            this.MediaPlayer.Size = new System.Drawing.Size(760, 540);
            this.MediaPlayer.TabIndex = 5;
            this.MediaPlayer.Visible = false;
            this.MediaPlayer.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(this.MediaPlayer_PlayStateChange);
            this.MediaPlayer.PositionChange += new AxWMPLib._WMPOCXEvents_PositionChangeEventHandler(this.MediaPlayer_PositionChange);
            // 
            // picPanel
            // 
            this.picPanel.Location = new System.Drawing.Point(10, 5);
            this.picPanel.Name = "picPanel";
            this.picPanel.Size = new System.Drawing.Size(240, 590);
            this.picPanel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPanel.TabIndex = 6;
            this.picPanel.TabStop = false;
            // 
            // Display
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.picPanel);
            this.Controls.Add(this.MediaPlayer);
            this.Controls.Add(this.lblAlert);
            this.Controls.Add(this.lblRotator);
            this.Controls.Add(this.lblPanel);
            this.Controls.Add(this.lblDateTime);
            this.Controls.Add(this.picDisplay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Display";
            this.Text = "Display";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Display_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MediaPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPanel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picDisplay;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.Label lblPanel;
        private System.Windows.Forms.Label lblRotator;
        private System.Windows.Forms.Timer mainTick;
        private System.Windows.Forms.Timer picTick;
        private System.Windows.Forms.Timer msgTick;
        private System.Windows.Forms.Timer longTick;
        private System.Windows.Forms.Label lblAlert;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private AxWMPLib.AxWindowsMediaPlayer MediaPlayer;
        private System.Windows.Forms.PictureBox picPanel;
    }
}

