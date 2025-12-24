using Newtonsoft.Json;
using System;
using Random = UnityEngine.Random;

namespace KadenZombie8.BIMOS.Networking
{
    [JsonObject]
    public struct PlayerMetadata
    {
        public string Username;
        public string PlatformId;
        public string Nickname;
        public string Description;

        public PlayerMetadata(string username, string id, string nickname, string description) {
            Username = username;
            PlatformId = id;
            Nickname = nickname;
            Description = description;
        }

        public static PlayerMetadata GenerateRandom() {
            var username = $"Player_{Random.Range(1111, 999999)}";
            return new(username, Guid.NewGuid().ToString(), username.Replace("_", " "), "Lorem Ispum");
        }
    }
}
