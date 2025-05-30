using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace ChatApp.Model
{
    public class ConversationSerializer
    {
        private string? hostEndpoint = null;
        private string? hostName = null;

        private readonly object _lock = new object();

        private string baseDirectory =>
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "SavedChats");

        public ConversationSerializer() { }
        public void Save(ConversationModel conversationModel)
        {
            InitializeHost();
            string directoryPath = Path.Combine(baseDirectory, $"{hostName}_{hostEndpoint}");
            Directory.CreateDirectory(directoryPath);

            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };

            string filePath = Path.Combine(directoryPath, $"{conversationModel.User.FName}-{conversationModel.User.LName}-{conversationModel.User.UserName}_{conversationModel.User.Ip}-{conversationModel.User.Port}.json");

            string json = JsonConvert.SerializeObject(conversationModel, settings);

            File.WriteAllText(filePath, json);
        }
        public ConversationModel Load(string filePath)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            };

            string json = File.ReadAllText(filePath);

            ConversationModel conversation = JsonConvert.DeserializeObject<ConversationModel>(json, settings);

            return conversation;
        }

        public List<ConversationModel> LoadAll() 
        {
            try
            {
                InitializeHost();
                List<ConversationModel> conversationModels = new List<ConversationModel>();

                string directoryPath = Path.Combine(baseDirectory, $"{hostName}_{hostEndpoint}");

                if (Directory.Exists(directoryPath))
                {
                    string[] files = Directory.GetFiles(directoryPath);

                    try
                    {
                        foreach (string file in files)
                        {
                            ConversationModel conversation = Load(file);
                            conversationModels.Add(conversation);
                        }
                    } catch (Exception ex) { 
                        System.Diagnostics.Debug.WriteLine(ex.Message);
                    }
                }

                return conversationModels;

            } catch (Exception ex)
            {
                return new List<ConversationModel>();
            }
        }

        private void InitializeHost()
        {
            if (hostEndpoint == null || hostName == null)
            {
                hostEndpoint = NetworkManager.Instance.Host.Ip + "-" + NetworkManager.Instance.Host.Port;
                hostName = NetworkManager.Instance.Host.UserName;
            }
        }
    }
}
