using IllusionPlugin;
using System;
using System.IO;
using UnityEngine;

namespace TwitchIRCClient
{
    public class Plugin : IPlugin
    {
        public string Name => "TwitchIRCClient";
        public string Version => "v0.0.1";
        private string configPath = Path.Combine(Environment.CurrentDirectory, "TwitchClientConfig.json");
        public static TwitchClient twitchClient;
        public void OnApplicationStart()
        {
            Config config = Config.LoadConfig(configPath);
            twitchClient = new GameObject("TwitchClient").AddComponent<TwitchClient>();
            twitchClient.SetCredentials(config.oAuthToken, config.username, config.channelName);
            UnityEngine.Object.DontDestroyOnLoad(GameObject.Find("TwitchClient"));
        }

        public void OnApplicationQuit()
        {
        }

        public void OnLevelWasLoaded(int level)
        {

        }

        public void OnLevelWasInitialized(int level)
        {
        }

        public void OnUpdate()
        {
        }

        public void OnFixedUpdate()
        {
        }

        public static void Log(string message)
        {
            Console.WriteLine("[TwitchIRCClient] " + message);
        }
    }
}
