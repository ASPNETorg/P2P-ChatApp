
namespace ChatApp.Model
{
    public class CloseConnectionModel : DataModel
    {
        public CloseConnectionModel(UserModel sender, string receiver) : base(sender, receiver) { }
    }
}