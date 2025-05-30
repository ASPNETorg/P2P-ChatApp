using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace ChatApp.Model
{
    public class ConversationModel
    {
        private string endpoint;
        public string Endpoint { get { return endpoint; } set { endpoint = value; } }

        private string username;
        public string UserName { get; set; }

        private DateTime lastActivity;
        public DateTime LastActivity { get => lastActivity; set { lastActivity = value; } }
        public string LastActivityToString { get { return DateToString(lastActivity); } }

        private bool unreadMessages = false;
        public bool UnreadMessages { get { return unreadMessages; } set { unreadMessages = value; } }

        private bool unreadBuzz = false;
        public bool UnreadBuzz { get { return unreadBuzz; } set { unreadBuzz = value; } }

        public string Username { get { return user.UserName; } }

        private UserModel user;
        public UserModel User { get { return user; } set { user = value; } }  

        private ObservableCollection<DataModel> messages = new ObservableCollection<DataModel>();
        public ObservableCollection<DataModel> Messages { get { return messages; } }
        public ConversationModel() { }

        public ConversationModel(string endpoint)
        {
            this.endpoint = endpoint;
        }     
        public ConversationModel(UserModel user)
        {
            this.user = user;
        }

        public void ReceiveMessage(DataModel message)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                lastActivity = message.Date;
                messages.Add(message);
                if (!(ConversationManager.Instance.CurrentConversation == User.Address))
                {
                    unreadMessages = true;
                    UnreadBuzz = false;
                } else
                {
                    unreadMessages = false;
                }
            });
           
        }
        private static string DateToString(DateTime dateTime)
        {
            int seconds = (int)(DateTime.Now - dateTime).TotalSeconds;

            if (seconds < 30)
            {
                return "Just now";
            }
            else if (seconds < 60)
            {
                return $"{seconds} sec ago";
            }
            else if (seconds < 60 * 60)
            {
                int minutes = seconds / 60;
                return $"{minutes} min ago";
            }
            else if (seconds < (60 * 60 * 24))
            {
                int hours = seconds / 60 / 60;
                string tmp = hours == 1 ? "hour" : "hours";
                return $"{hours} {tmp} ago";
            }
            else if (seconds < (60 * 60 * 24 * 30))
            { 
                int days = seconds / 60 / 60 / 24;
                string tmp = days == 1 ? "day" : "days";
                return $"{days} {tmp} ago";
            } else
            {
                return "Long ago";
            }
        }
    }
}
