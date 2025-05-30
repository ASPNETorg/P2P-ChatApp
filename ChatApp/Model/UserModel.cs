
namespace ChatApp.Model
{
    public class UserModel
    {
        private string ip {  get; }
        private string port { get; }
        private string address { get; }
        private string fname { get; }
        private string lname { get; }
        private string username { get; }

        public UserModel(string ip, string port, string username/*, string fname, string lname*/) { 
            this.ip = ip;
            this.port = port;
            this.address = ip + ":" + port;
            this.username = username;
            //this.fname = fname;
            //this.lname = lname;
        }

        public string Ip { get { return ip; } }
        public string Port { get { return port; } }
        public string Address { get { return address; } }
        public string UserName { get { return username; } }
        public string FName { get { return fname; } }
        public string LName { get { return lname; } }
    }
}
