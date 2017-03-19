using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Display_System.IO
{
    class ClientCommunication
    {
        public static void startNetServer()
        {
            if (Properties.Settings.Default.EnableClientConnections && Properties.Settings.Default.EnableNetworking)
            {
                Variables.clientConnServer = new NetworksApi.TCP.SERVER.Server(Properties.Settings.Default.ClientConnectionIP, Properties.Settings.Default.ClientConnectionPort);
                Variables.clientConnServer.OnClientConnected += ClientConnServer_OnClientConnected;
                Variables.clientConnServer.OnClientDisconnected += ClientConnServer_OnClientDisconnected;
                Variables.clientConnServer.OnDataReceived += ClientConnServer_OnDataReceived;
                Variables.clientConnServer.OnServerError += ClientConnServer_OnServerError;
                Variables.clientConnServer.Start();
            }
        }

        private static void ClientConnServer_OnServerError(object Sender, NetworksApi.TCP.SERVER.ErrorArguments R)
        {
            Variables.logger.LogLine(2, "TCP Server Error: " + R.ErrorMessage);
        }
        private static void sendMessage(string destination, string data)
        {
            Variables.clientConnServer.SendTo(destination, data);
        }
        private static void ClientConnServer_OnDataReceived(object Sender, NetworksApi.TCP.SERVER.ReceivedArguments R)
        {
            parseCommand(R.ReceivedData,R.Name);
        }

        private static void ClientConnServer_OnClientDisconnected(object Sender, NetworksApi.TCP.SERVER.DisconnectedArguments R)
        {
            Variables.logger.LogLine("TCP Client Disconnected: " + R.Name);
        }

        private static void ClientConnServer_OnClientConnected(object Sender, NetworksApi.TCP.SERVER.ConnectedArguments R)
        {
            Variables.logger.LogLine("TCP Client Connected: " + R.Name);
        }
        private static void parseCommand(string command,string sender)
        {
            string[] toParse = command.Split(':');
            if(toParse.Length > 0)
            {
                switch (toParse[0])
                {
                    case "PSK":
                        if(toParse.Length > 1)
                        {
                            if(toParse[1] == Properties.Settings.Default.PSK)
                            {
                                sendMessage(sender, "PSKRESPONSE:TRUE");
                            }
                            else
                            {
                                sendMessage(sender, "PSKRESPONSE:FALSE");
                            }
                        }
                        else
                        {
                            sendMessage(sender, "PSKRESPONSE:INVALID");
                        }
                        break;
                }
            }
        }
    }
}
