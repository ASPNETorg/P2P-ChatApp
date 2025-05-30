

namespace ChatApp.Model
{
    public class MessageModel : DataModel
    {
        public MessageModel(UserModel sender, string receiver, string message) : base(sender, receiver)
        {
            Message = message;
        }
    }
}
