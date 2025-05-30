
namespace ChatApp.Model
{
    public class ConnectionRequestModel : DataModel
    {
        public ConnectionRequestModel(UserModel sender, string receiver) : base(sender, receiver) { }
    }
}
