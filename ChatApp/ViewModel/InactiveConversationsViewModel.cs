using ChatApp.Model;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ChatApp.ViewModel
{
    internal class InactiveConversationsViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<ConversationModel> conversations;
        public ObservableCollection<ConversationModel> Conversations { get { return conversations; } }

        private ObservableCollection<ConversationModel> filteredConversations = new ObservableCollection<ConversationModel>();
        public ObservableCollection<ConversationModel> FilteredConversations { get { return filteredConversations; } set { filteredConversations = value; OnPropertyChanged("FilteredConversations"); } }

        private string searchQuery = "";
        public string SearchQuery { 
            get { return searchQuery; } 
            set { 
                searchQuery = value; 
                OnPropertyChanged("SearchQuery");
                UpdateSearch();
            } 
        }

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

        private async Task Refresh()
        {
            while (true)
            {
                UpdateSearch();
                await Task.Delay(60000);
            }
        }

        public InactiveConversationsViewModel()
        {
            ConversationManager.Instance.conversationsUpdatedEvent += ReloadInactiveConversations;
            ConversationManager.Instance.inactiveConversationSetEvent += InactiveConversationSet;
            ConversationManager.Instance.activeConversationSetEvent += ActiveConversationSet;
            conversations = new ObservableCollection<ConversationModel>(ConversationManager.Instance.GetInactiveConversations());
            FilteredConversations = conversations;
            Task.Run(() => { Refresh(); }).ConfigureAwait(false);
        }

        private void InactiveConversationSet(object sender, EventArgs e)
        {
            if (SelectedConversation != ConversationManager.Instance.GetConversation())
                SelectedConversation = ConversationManager.Instance.GetConversation();
        }

        public void ActiveConversationSet(object sender, EventArgs e)
        {
            SelectedConversation = null;
        }

        private void ReloadInactiveConversations(object sender, EventArgs e)
        {
            conversations = new ObservableCollection<ConversationModel>(ConversationManager.Instance.GetInactiveConversations());
            UpdateSearch();
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

        private void UpdateSearch()
        {
            if (searchQuery.Length > 0)
            {
                FilteredConversations = new ObservableCollection<ConversationModel>(conversations.Where(item => item.User.UserName.ToUpper().Contains(searchQuery.ToUpper())).ToList());
            }
            else
            {
                FilteredConversations = new ObservableCollection<ConversationModel>(conversations);
            }
        }
    }
}