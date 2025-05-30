using ChatApp.Model;
using ChatApp.ViewModel.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ChatApp.ViewModel
{
    public class PendingRequestBarViewModel : INotifyPropertyChanged
    {
        private string requestMessage = "";
        public string RequestMessage { get { return requestMessage; } set { requestMessage = $"{value} sent a chat request!"; OnPropertyChanged("RequestMessage"); } }

        private ICommand acceptRequestCommand = null;
        public ICommand AcceptRequestCommand
        {
            get
            {
                if (acceptRequestCommand == null)
                {
                    acceptRequestCommand = new AcceptRequestCommand(this);
                }
                return acceptRequestCommand;
            }
            set { acceptRequestCommand = value; }
        }

        private ICommand declineRequestCommand = null;
        public ICommand DeclineRequestCommand
        {
            get
            {
                if (declineRequestCommand == null)
                {
                    declineRequestCommand = new DeclineRequestCommand(this);
                }
                return declineRequestCommand;
            }
            set { declineRequestCommand = value; }
        }

        private bool hasNewRequest = false;
        public bool HasNewRequest { get { return hasNewRequest; } set { hasNewRequest = value; OnPropertyChanged("HasNewRequest"); } }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private void OnNewRequest(object sender, EventArgs e)
        {
            UserModel user = ConversationManager.Instance.GetPendingRequest();
            RequestMessage = user.Address + ": " + user.UserName;
            HasNewRequest = true;
        }
        public PendingRequestBarViewModel()
        {
            ConversationManager.Instance.newRequestEvent += OnNewRequest;
        }
        public void AcceptRequest()
        {
            HasNewRequest = false;
            ConversationManager.Instance.AcceptRequest();
        }
        public void DeclineRequest()
        {
            HasNewRequest = false;
            ConversationManager.Instance.DeclineRequest();
        }
    }
}
