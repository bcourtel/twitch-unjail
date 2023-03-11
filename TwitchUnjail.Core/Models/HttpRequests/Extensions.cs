using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TwitchUnjail.Core.Models.HttpRequests
{
    public class Extensions
    {
        [JsonPropertyName("persistedQuery")]
        public PersistedQuery PersistedQuery { get; set; }

        public Extensions(string sha256Hash)
        {
            PersistedQuery = new PersistedQuery(sha256Hash);
        }
    }
}
