using ChatApp.Model;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using ChatApp.ViewModel.Command;
using System.Windows;

namespace ChatApp.ViewModel
{
    internal class ChatClientWindowViewModel : INotifyPropertyChanged {

        private string windowTitle = "";
        public string WindowTitle
        {
            get
            {
                return windowTitle;
            }
            set
            {
                windowTitle = value;
                OnPropertyChanged("WindowTitle");
            }
        }

        private bool shouldShake;
        public bool ShouldShake
        {
            get { return shouldShake; }
            set
            {
                if (shouldShake != value)
                {
                    shouldShake = value;
                    OnPropertyChanged(nameof(ShouldShake));

                    Task.Delay(500).ContinueWith(t => ShouldShake = false);
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand onClose { get; private set; }
        public ICommand OnClose
        {
            get
            {
                if (onClose == null)
                {
                    onClose = new CloseWindowCommand(param => OnWindowClose(), null);
                }
                return onClose;
            }
            set { onClose = value; }
        }

        public ChatClientWindowViewModel()
        {
            ConversationManager.Instance.buzzEvent += ActivateBuzz;
            UserModel host = NetworkManager.Instance.Host;
            WindowTitle = $"{host.UserName} - {host.Address}";
        }

        private void ActivateBuzz(object sender, EventArgs e)
        {
            ShouldShake = true;
        }
        public static void OnWindowClose()
        {
            NetworkManager.Instance.CloseServer();
            Application.Current.Dispatcher.Invoke(() => Application.Current.Shutdown());
        }
    }
}
