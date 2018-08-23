using System.IO;
using UnityEngine;

namespace TwitchIRCClient
{
    public class Config
    {
        public string username = "username here";
        public string oAuthToken = "OAuth password here";
        public string channelName = "channel to connect to";
        public static Config LoadConfig(string configPath)
        {
            if(!File.Exists(configPath))
            {
                File.Create(configPath).Dispose();
                Config config = new Config();
                config.SaveConfig(configPath);
            }
            return JsonUtility.FromJson<Config>(File.ReadAllText(configPath));
        }
        public void SaveConfig(string configPath)
        {
            File.WriteAllText(configPath, JsonUtility.ToJson(this, true));
        }
    }
}
