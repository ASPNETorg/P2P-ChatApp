using Newtonsoft.Json;
using System;
using System.Text;

namespace ChatApp.Model
{
    internal class ProtocolWrapper
    {
        public DataModel dataModel { get; set; }
        public string protocol { get; private set; } = "P2P_TDDD49";
        public string version { get; private set; } = "1.0";

        public ProtocolWrapper(DataModel dataModel) 
        { 
            this.dataModel = dataModel;
        }

        public DataModel DataModel { get { return dataModel; } }
    }

    public class Protocol
    {
        private string protocol = "P2P_TDDD49";
        private string version = "1.0";

        public Protocol() { }
        public byte[] Encode<T>(T dataModel) where T : DataModel
        {
            ProtocolWrapper wrapper = new ProtocolWrapper(dataModel);

            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };

            string json = JsonConvert.SerializeObject(wrapper, settings);
            byte[] byteArray = Encoding.UTF8.GetBytes(json);

            if (byteArray.Length > 4096)
            {
                throw new ArgumentOutOfRangeException();
            }
            return byteArray;
        }
        public DataModel Decode(byte[] byteArray)
        {
            ProtocolWrapper? wrapper = null;

            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            };

            string json = Encoding.UTF8.GetString(byteArray);

            wrapper = JsonConvert.DeserializeObject<ProtocolWrapper>(json, settings);

            if (wrapper.protocol != protocol || wrapper.version != version)
            {
                throw new ArgumentException();
            }

            DataModel dataModel = wrapper.DataModel;

            return dataModel;
        }
    }
}
