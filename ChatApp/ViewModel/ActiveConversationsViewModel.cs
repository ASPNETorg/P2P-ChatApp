using ChatApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Data;
using Newtonsoft.Json.Linq;

namespace ChatApp.ViewModel
{
    internal class ActiveConversationsViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<ConversationModel> conversations = new ObservableCollection<ConversationModel>(ConversationManager.Instance.GetActiveConversations());
        public ObservableCollection<ConversationModel> Conversations { get { return conversations; } }

        private ConversationModel selectedConversation;
        public ConversationModel SelectedConversation
        {
            get { return selectedConversation; }
            set
            {
                selectedConversation = value;
                if (value != null)
                {
                    ConversationManager.Instance.AssignCurrentConversation(value.User.Address);
                }
                OnPropertyChanged(nameof(SelectedConversation));
            }
        }

        
        public ActiveConversationsViewModel() {
            ConversationManager.Instance.conversationsUpdatedEvent  += ReloadConversations;
            ConversationManager.Instance.inactiveConversationSetEvent += InactiveConversationSet;
            ConversationManager.Instance.activeConversationSetEvent += ActiveConversationSet;
        }

        private void InactiveConversationSet(object sender, EventArgs e)
        {
            SelectedConversation = null;
        }

        public void ActiveConversationSet(object sender, EventArgs e)
        {
            if (SelectedConversation != ConversationManager.Instance.GetConversation())
                SelectedConversation = ConversationManager.Instance.GetConversation();
        }

        private void ReloadConversations(object sender, EventArgs e)
        {
            conversations = new ObservableCollection<ConversationModel>(ConversationManager.Instance.GetActiveConversations());
            OnPropertyChanged("Conversations");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
