using ChatApp.Model;
using ChatApp.ViewModel.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ChatApp.ViewModel
{
    internal class ConversationViewModel : INotifyPropertyChanged
    {
        private ConversationModel conversation = null;

        private ObservableCollection<DataModel> messages = new ObservableCollection<DataModel>();
        public ObservableCollection<DataModel> Messages { get { return messages; } }

        public bool CanSendMessage { get { return conversation != null && ConversationManager.Instance.CurrentConversationIsActive; } }
        public bool CanReconnect { get { return conversation != null && !ConversationManager.Instance.CurrentConversationIsActive; } }

        private bool shouldScrollToEnd;
        public bool ShouldScrollToEnd
        {
            get { return shouldScrollToEnd; }
            set
            {
                shouldScrollToEnd = value;
                OnPropertyChanged(nameof(ShouldScrollToEnd));
            }
        }

        private string message;
        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged("Message"); }
        }

        private ICommand sendMessageCommand = null;
        public ICommand SendMessageCommand
        {
            get
            {
                if (sendMessageCommand == null)
                {
                    sendMessageCommand = new SendMessageCommand(this);
                }
                return sendMessageCommand;
            }
            set { sendMessageCommand = value; }
        }

        private ICommand sendBuzzCommand = null;
        public ICommand SendBuzzCommand
        {
            get
            {
                if (sendBuzzCommand == null)
                {
                    sendBuzzCommand = new SendBuzzCommand(this);
                }
                return sendBuzzCommand;
            }
            set { sendBuzzCommand = value; }
        }

        private ICommand reconnectCommand = null;
        public ICommand ReconnectCommand
        {
            get
            {
                if (reconnectCommand == null)
                {
                    reconnectCommand = new ReconnectCommand(this);
                }
                return reconnectCommand;
            }
            set { reconnectCommand = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void ConversationPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            this.UpdateConversation();
        }

        private void ConversationPropertyChanged(object sender, EventArgs e)
        {
            this.UpdateConversation();

        }

        public ConversationViewModel()
        {
            ConversationManager.Instance.PropertyChanged += ConversationPropertyChanged;
            ConversationManager.Instance.conversationsUpdatedEvent += ConversationPropertyChanged;
        }

        public void SendMessage()
        {
            UpdateConversation();
            if (this.conversation != null) {
                MessageModel msg = new MessageModel(NetworkManager.Instance.Host, ConversationManager.Instance.CurrentConversation, message);
                ConversationManager.Instance.SendMessage(msg);
            }

            Message = "";
        }

        public void SendBuzz()
        {
            if (this.conversation != null)
            {
                BuzzModel msg = new BuzzModel(NetworkManager.Instance.Host, ConversationManager.Instance.CurrentConversation);
                ConversationManager.Instance.SendBuzz(msg);
            }
        }

        private void UpdateConversation()
        {
            conversation = ConversationManager.Instance.GetConversation();
            if (conversation != null)
            {
                messages = conversation.Messages;
                ShouldScrollToEnd = true;
            } else
            {
                messages = new ObservableCollection<DataModel>();
            }
            OnPropertyChanged("Messages");
            OnPropertyChanged("CanSendMessage");
            OnPropertyChanged("CanReconnect");
        }

        public void AttemptReconnection()
        {
            try
            {
                string ip = conversation.User.Ip;
                string port = conversation.User.Port;
                NetworkManager.Instance.Connect(ip, port);
            } catch (KeyNotFoundException e)
            {
                ConversationManager.Instance.SendNotification($"❌ Error: Cannot reconnect to {conversation.User.Ip}:{conversation.User.Port}.");
            }

        }

    }
}