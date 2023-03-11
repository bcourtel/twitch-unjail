using System.Text.Json;
using System.Text.Json.Serialization;

namespace TwitchUnjail.Core.Models.HttpResponses
{
    public class ComscoreStreamingQueryResponse
    {
        [JsonPropertyName("data")]
        public ComscoreStreamingQueryResponseData Data { get; set; }
    }

    public class ComscoreStreamingQueryResponseData
    {
        [JsonPropertyName("video")]
        public ComscoreStreamingQueryResponseVideo Video { get; set; }
    }

    public class ComscoreStreamingQueryResponseVideo
    {
        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("lengthSeconds")]
        public int LengthSeconds { get; set; }

        [JsonPropertyName("owner")]
        public ComscoreStreamingQueryResponseOwner Owner { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }
    }

    public class ComscoreStreamingQueryResponseOwner
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("displayName")]
        public string DisplayName { get; set; }
    }
}
