using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace ChatApp.Model
{
    public sealed class NetworkManager
    {
        private static readonly Lazy<NetworkManager> _networkManager = new Lazy<NetworkManager>(() => new NetworkManager());

        private NotificationManager? notificationManager = null;
        public NotificationManager NotificationManager { get { return notificationManager; } set { notificationManager = value; } }

        private Dictionary<string, TcpClient> connections;
        private readonly object _lock = new();
        private Protocol protocol = new();
        private UserModel? host;
        private TcpListener? server = null;

        private CancellationTokenSource cts = new CancellationTokenSource();

        public event EventHandler listenerSuccessEvent;
        public event EventHandler listenerFailedEvent;

        private NetworkManager()
        {
            connections = new Dictionary<string, TcpClient>();
        }
        public static NetworkManager Instance
        {
            get
            {
                return _networkManager.Value;
            }
        }
        public UserModel Host { get { return host; } }
        private async Task ManageClientConnection(TcpClient client)
        {
            string clientAddress = client.Client.RemoteEndPoint.ToString();
            string clientName = "";
            string clientFName = "";
            string clientLName ="";
            bool exit = false;

            try
            {
                while (!exit)
                {
                    Byte[] bytes = new byte[4096];
                    string? data = null;
                    NetworkStream stream = client.GetStream();
                    DataModel message;

                    int i;
                    while ((i = await stream.ReadAsync(bytes, 0, bytes.Length)) != 0)
                        {

                        try
                        {
                            message = protocol.Decode(bytes);
                        } catch (JsonSerializationException) 
                        {
                            exit = true;
                            notificationManager.AddNotification($"❌ {clientAddress}: Unable to decode message from {clientName}. Closing connection.");
                            break;
                        } catch (ArgumentException)
                        {
                            exit = true;
                            notificationManager.AddNotification($"❌¨{clientAddress}: Message received with the wrong protocol version. Closing connection.");
                            break;
                        }

                        if (message is ConnectionRequestModel) 
                        {
                            ConversationManager.Instance.OnNewRequest(message.Sender);
                            connections[message.SenderAddr] = connections[clientAddress];
                            connections.Remove(clientAddress);
                            clientAddress = message.SenderAddr;
                            clientName = message.Sender.UserName;
                        } else if (message is AcceptRequestModel) 
                        {
                            clientName = message.Sender.UserName;
                            clientAddress = message.SenderAddr;
                            if (notificationManager != null)
                                notificationManager.AddNotification($"✔️ {clientAddress}: {clientName} has accepted your connection request! You can now chat.");
                            ConversationManager.Instance.InitializeConversation(message.Sender);
                        } else if (message is RefuseRequestModel)
                        {
                            clientAddress = message.SenderAddr;
                            if (notificationManager != null)
                                notificationManager.AddNotification($"❌ {clientAddress}: {message.Sender.UserName} has refused your connection request.");
                            exit = true;
                            break;
                            
                        } else if (message is CloseConnectionModel) 
                        {
                            clientAddress = message.SenderAddr;
                            if (notificationManager != null)
                                notificationManager.AddNotification($"❌ {clientAddress}: {message.Sender.UserName} has closed your chat.");
                            exit = true;
                            break;

                        }
                        else if (message is MessageModel)
                        {
                            ConversationManager.Instance.ReceiveMessage(message);
                        } else if (message is BuzzModel) 
                        {
                            ConversationManager.Instance.ReceiveBuzz(message);
                        }
                        bytes = new byte[4096];
                    }

                    if (exit)
                        break;
                }

            }
            catch (SocketException e)
            {
                if (notificationManager != null)
                {
                    notificationManager.AddNotification($"❗️ {clientAddress}: Something unexpected forced your connection to {clientName} to close.");
                }
            }
            catch (IOException e) 
            {
                if (notificationManager != null)
                {
                    notificationManager.AddNotification($"❗️ {clientAddress}: Failed to read message received from {clientName}. The connection will now close.");
                }
            }
            finally
            {
                client.Close();
                if (!exit && notificationManager != null)
                {
                    notificationManager.AddNotification($"❌ {clientAddress}: Your connection to {clientName} has been closed.");
                }
                lock (_lock)
                {
                    ConversationManager.Instance.CloseConversation(clientAddress);
                    connections.Remove(clientAddress);
                }

            }
        }
        public async Task Listen(UserModel user)
        {
            connections.Clear();
            host = user;
            TcpClient incomingClient;

            IPAddress localAddr = IPAddress.Parse(host.Ip);
            Int32 portInt = Convert.ToInt32(host.Port);

            try
            {
                server = new TcpListener(localAddr, portInt);
                server.Start();
            } catch (SocketException)
            {
                listenerFailedEvent?.Invoke(this, EventArgs.Empty);
                return;
            }
            while (!cts.Token.IsCancellationRequested)
            {
                if (server.Pending())
                {
                    incomingClient = await server.AcceptTcpClientAsync();

                    lock (_lock)
                    {
                        string clientAddress = incomingClient.Client.RemoteEndPoint.ToString();
                        connections[clientAddress] = incomingClient;
                    }

                    Task.Run(() => ManageClientConnection(incomingClient).ConfigureAwait(false));
                } else
                {
                    await Task.Delay(100);
                }
            }
        }
        public static bool IsPortOccupied(string port)
        {
            var activeConnections = IPGlobalProperties.GetIPGlobalProperties().GetActiveTcpListeners();
            
            foreach (var activeConnection in activeConnections)
            {
                if (activeConnection.Port == Convert.ToInt32(port))
                {
                    return true;
                }
            }
            return false;
        }
        public static string GetIpAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            string found_ip = null;

            try
            {
                foreach (var ip in host.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        found_ip = ip.ToString();
                        break;
                    }
                }
            }
            catch (SocketException e) 
            {
                found_ip = null;
            }

            return found_ip;
        }

        public async Task CloseServer()
        {
            var sendTasks = connections.Select(connection =>
                SendMessage(new CloseConnectionModel(host, connection.Key)));
            await Task.WhenAll(sendTasks);

            ConversationManager.Instance.OnExit();

            if (server != null)
            {
                cts.Cancel();
                server.Stop();
                server = null;
            }
        }
        public async Task Connect(string ip, string port)
        {
            string targetIp = ip + ":" + port;
            notificationManager.AddNotification($"❗ Sending connection request to {targetIp}...");
            Int32 portInt = Convert.ToInt32(port);
            TcpClient client = new TcpClient();

            try
            {
                IPAddress localAddr = IPAddress.Parse(ip);
                await client.ConnectAsync(ip, portInt);
            }
            catch (SocketException e)
            {
                notificationManager.AddNotification($"❌ No host appears to be listening at {targetIp}. No connection established.");
                return;
            }
            
            connections[targetIp] = client;
            await SendMessage(new ConnectionRequestModel(host, targetIp));
            _ = Task.Run(() => ManageClientConnection(client).ConfigureAwait(false));
        }
        public async Task SendMessage(DataModel dataModel)
        {
            NetworkStream stream = connections[dataModel.Receiver].GetStream();
            try
            {
                await stream.WriteAsync(protocol.Encode(dataModel));
            } catch (ArgumentOutOfRangeException) {
                if (notificationManager != null)
                {
                    notificationManager.AddNotification($"❌ Your message is too long, and has not been sent.");
                }
            } catch (Exception e) 
            {
                if (notificationManager != null)
                {
                    notificationManager.AddNotification($"❌ Failed to send message to {dataModel.Receiver}");
                }
            }
        }

        public void AcceptRequest(UserModel user)
        {
            AcceptRequestModel msg = new AcceptRequestModel(Host, user.Address);
            SendMessage(msg);
        }
        public void RefuseRequest(UserModel user)
        {
            RefuseRequestModel msg = new RefuseRequestModel(Host, user.Address);
            SendMessage(msg);

        }
        public bool IsClientConnected(string addr)
        {
            return connections.ContainsKey(addr);
        }
    }
}