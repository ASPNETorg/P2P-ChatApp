using ChatApp.Model;
using ChatApp.View;
using ChatApp.ViewModel.Command;
using System;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ChatApp.ViewModel
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        private string errorMessage = "";
        public string ErrorMessage { get { return errorMessage; } set { errorMessage = value; OnPropertyChanged("ErrorMessage"); } }

        private ObservableCollection<string> ipAddresses = new ObservableCollection<string>();
        public ObservableCollection<string> IpAddresses { get { return ipAddresses; } }

        private string selectedIp = "127.0.0.1";
        public string SelectedIp { get { return selectedIp; } set { selectedIp = value;  } }

        private string username;
        public string UserName { 
            get { return username; } 
            set { username = value; }
        }
        private string port;
        public string Port
        {
            get { return port; }
            set { port = value; }
        }

        private ICommand startClient;
        public ICommand StartClient { 
            get {
                if (startClient == null)
                {
                    startClient = new LoginCommand(this);
                }
                return startClient; 
            } 
            set { startClient = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public MainWindowViewModel() {
            NetworkManager.Instance.listenerFailedEvent += OnError;
            NetworkManager.Instance.listenerSuccessEvent += OnSuccess;
            ipAddresses.Add("127.0.0.1");

            string localIp = NetworkManager.GetIpAddress();

            if (localIp != null)
            {
                ipAddresses.Add(localIp);
            }

            OnPropertyChanged("IpAddresses");
        }
        public void StartChatClient()
        {
            if (username.Length < 2)
            {
                ErrorMessage = "Name must be at least two characters long.";
            }
            else if (!IsValidPort())
            {
                ErrorMessage = "Please choose a port between 10 000 and 64 0000.";
            }
            else if (NetworkManager.IsPortOccupied(port))
            {
                ErrorMessage = "The port " + port + " is currently occupied.";
            }
            else
            {
                ErrorMessage = "";
                NetworkManager.Instance.Listen(new UserModel("127.0.0.1", port, username));
                ChatClientWindow chatClientWindow = new ChatClientWindow();
                chatClientWindow.ShowDialog();
            }
        }
        public void OnError(object sender, EventArgs e)
        {
            ErrorMessage = $"Failed to start listening on port {port}";
        }
        public void OnSuccess(object sender, EventArgs e)
        {
            ErrorMessage = "";
            NetworkManager.Instance.Listen(new UserModel(selectedIp, port, username));
            ChatClientWindow chatClientWindow = new ChatClientWindow();
            chatClientWindow.ShowDialog();                
        }
        private bool IsValidPort()
        {
            Int32 portInt = 0;

            try
            {
                portInt = Convert.ToInt32(port);
            } catch (FormatException)
            {
                return false;
            }

            if (portInt < 9999 || portInt > 64001)
            {
                return false;
            }

            return true;
        }
    }
}
