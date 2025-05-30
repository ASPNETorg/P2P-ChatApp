using ChatApp.Model;
using ChatApp.ViewModel.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ChatApp.ViewModel
{
    internal class SidebarRequestViewModel
    {
        private string ip;
        public string Ip
        {
            get { return ip; }
            set { ip = value; }
        }

        private string port;
        public string Port
        {
            get { return port; }
            set { port = value; }
        }

        private ICommand sendRequest = null;
        public ICommand SendRequest
        {
            get
            {
                if (sendRequest == null)
                {
                    sendRequest = new RequestCommand(this);
                    Ip = "";
                    Port = "";
                }
                return sendRequest;
            }
            set { sendRequest = value; }
        }

        public void SendNewRequest()
        {
            NetworkManager manager = NetworkManager.Instance;
            string addr = ip + ":" + port;
            if (manager.Host.Address == addr)
            {
                ConversationManager.Instance.SendNotification("You cannot connect to yourself!");
            } else if (manager.IsClientConnected(addr))
            {
                ConversationManager.Instance.SendNotification($"You are already connected to {addr}!");
                Ip = "";
                Port = "";
            }
            else
            {
                manager.Connect(Ip, Port);
            }
        }
    }
}
