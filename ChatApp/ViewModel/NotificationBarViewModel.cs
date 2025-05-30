using ChatApp.Model;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace ChatApp.ViewModel
{
    class NotificationBarViewModel : INotifyPropertyChanged
    {
        private string notification = "";
        public string Notification { get { return notification; } set { notification = value; OnPropertyChanged("Notification"); } }

        private NotificationManager notificationManager;
        public NotificationManager NotificationManager { get { return notificationManager; } set { notificationManager = value; } }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public NotificationBarViewModel(NotificationManager manager) 
        {
            notificationManager = manager;
            NetworkManager.Instance.NotificationManager = notificationManager;
            ConversationManager.Instance.NotificationManager = notificationManager;

            notificationManager.newNotification += DisplayNotification;
        }

        private async Task SendNotification()
        {
            while (notificationManager.HasMoreNotifications())
            {
                Notification = notificationManager.GetLatestNotification();
                await Task.Delay(3000);
                notificationManager.DequeueNotification();
            }
            Notification = "";
        }
        public void DisplayNotification(object sender, EventArgs e)
        {
            Task.Run(() => SendNotification().ConfigureAwait(false));
        }
    }
}
