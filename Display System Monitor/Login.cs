using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetworksApi.TCP.CLIENT;

namespace Display_System_Monitor
{
    public partial class Login : Form
    {
        private Client netClient = new Client();
        public Login()
        {
            InitializeComponent();
            netClient.EncryptionEnabled = false;
            netClient.OnClientConnected += NetClient_OnClientConnected;
            netClient.OnClientConnecting += NetClient_OnClientConnecting;
            netClient.OnClientDisconnected += NetClient_OnClientDisconnected;
            netClient.OnClientError += NetClient_OnClientError;
            netClient.OnClientFileSending += NetClient_OnClientFileSending;
            netClient.OnDataReceived += NetClient_OnDataReceived;
        }

        private void NetClient_OnDataReceived(object Sender, ClientReceivedArguments R)
        {
            parseCommand(R.ReceivedData);
        }

        private void NetClient_OnClientFileSending(object Sender, ClientFileSendingArguments R)
        {
            //throw new NotImplementedException();
        }

        private void NetClient_OnClientError(object Sender, ClientErrorArguments R)
        {
            MessageBox.Show("Error: " + R.Exception);
        }

        private void NetClient_OnClientDisconnected(object Sender, ClientDisconnectedArguments R)
        {
            //throw new NotImplementedException();
        }

        private void NetClient_OnClientConnecting(object Sender, ClientConnectingArguments R)
        {
            //throw new NotImplementedException();
        }

        private void NetClient_OnClientConnected(object Sender, ClientConnectedArguments R)
        {
            //Properties.Settings.Default.CanConnect = true;
        }
        private void doExit()
        {
            netClient.Disconnect();
            Environment.Exit(0);
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            doExit();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!netClient.IsConnected)
                connectToServer();
            else
                netClient.Disconnect();
        }

        private void txtServerIp_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ServerIp = txtServerIp.Text;
        }

        private void txtServerPort_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ServerPort = txtServerPort.Text;
        }
        private void connectToServer()
        {
            netClient.ClientName = Properties.Settings.Default.ClientID;
            netClient.ServerIp = Properties.Settings.Default.ServerIp;
            netClient.ServerPort = Properties.Settings.Default.ServerPort;
            try
            {
                netClient.Connect();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to connect to server: " + ex.Message);
            }
            try
            {
                netClient.Send("PSK:" + Properties.Settings.Default.PSK);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Failed to connect to server: " + ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtServerIp.Text = Properties.Settings.Default.ServerIp;
            txtServerPort.Text = Properties.Settings.Default.ServerPort;
            txtClientID.Text = Properties.Settings.Default.ClientID;
            txtPSK.Text = Properties.Settings.Default.PSK;
        }

        private void txtClientID_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ClientID = txtClientID.Text;
        }

        private void txtPSK_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.PSK = txtPSK.Text;
        }
        private void parseCommand(string command)
        {
            string[] toParse = command.Split(':');
            if (toParse.Length > 0)
            {
                switch (toParse[0])
                {
                    case "PSKRESPONSE":
                        if (toParse.Length > 1)
                        {
                            if (toParse[1] == "FALSE")
                            {
                                netClient.Disconnect();
                                MessageBox.Show("PSK rejected by server.");
                            }
                            else if(toParse[1] == "TRUE")
                            {
                                Options opt = new Options();
                                opt.Show();
                                Hide();
                            }
                            else
                            {
                                MessageBox.Show("PSK ERROR");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Server Error");
                        }
                        break;
                }
            }
        }
    }
}
