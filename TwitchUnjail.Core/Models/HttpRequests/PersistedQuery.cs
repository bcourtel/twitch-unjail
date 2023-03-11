using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TwitchUnjail.Core.Models.HttpRequests
{
    public class PersistedQuery
    {
        [JsonPropertyName("version")]
        public int Version { get; set; }

        [JsonPropertyName("sha256Hash")]
        public string Sha256Hash { get; set; }

        public PersistedQuery(string sha256Hash)
        {
            Version = 1;
            Sha256Hash = sha256Hash;
        }
    }
}
