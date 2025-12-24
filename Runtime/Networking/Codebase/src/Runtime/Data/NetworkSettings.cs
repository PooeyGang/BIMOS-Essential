using Newtonsoft.Json;
using System;
using System.IO;
using UnityEngine;

namespace KadenZombie8.BIMOS.Networking
{
    [JsonObject]
    public class NetworkSettings
    {
        public PlayerMetadata LocalMetadata = PlayerMetadata.GenerateRandom();

        public static string NetworkSettingsPath = Path.Combine(Application.persistentDataPath, "NetworkSettings.json");

        public NetworkSettings Save() {
            Debug.Log("Saving NetworkSettings");
            var json = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(NetworkSettingsPath, json);
            Debug.Log("Saved NetworkSettings");
            return this;
        }
        public static NetworkSettings Load() {
            try {
                Debug.Log("Loading NetworkSettings");
                var json = File.ReadAllText(NetworkSettingsPath);
                Debug.Log("Loaded NetworkSettings");
                return JsonConvert.DeserializeObject<NetworkSettings>(json);
            } catch (Exception e) {
                Debug.LogException(e);
                return new NetworkSettings().Save();
            }
        }
    }
}
