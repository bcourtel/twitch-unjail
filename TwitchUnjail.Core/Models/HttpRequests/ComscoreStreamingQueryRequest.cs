using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TwitchUnjail.Core.Models.HttpRequests
{
    public class ComscoreStreamingQueryRequest
    {
        [JsonPropertyName("operationName")]
        public string OperationName { get; set; }

        [JsonPropertyName("variables")]
        public ComscoreStreamingQueryRequestVariables Variables { get; set; }

        [JsonPropertyName("extensions")]
        public Extensions Extensions { get; set; }

        public ComscoreStreamingQueryRequest(string vodId)
        {
            OperationName = "ComscoreStreamingQuery";
            Variables = new ComscoreStreamingQueryRequestVariables(vodId);
            Extensions = new Extensions("e1edae8122517d013405f237ffcc124515dc6ded82480a88daef69c83b53ac01");
        }
    }

    public class ComscoreStreamingQueryRequestVariables
    {
        [JsonPropertyName("channel")]
        public string Channel { get; set; }

        [JsonPropertyName("clipSlug")]
        public string ClipSlug { get; set; }

        [JsonPropertyName("isClip")]
        public bool IsClip { get; set; }

        [JsonPropertyName("isLive")]
        public bool IsLive { get; set; }

        [JsonPropertyName("isVodOrCollection")]
        public bool IsVodOrCollection { get; set; }

        [JsonPropertyName("vodID")]
        public string VodId { get; set; }

        public ComscoreStreamingQueryRequestVariables(string vodId)
        {
            Channel = "";
            ClipSlug = "";
            IsClip = false;
            IsLive = false;
            IsVodOrCollection = true;
            VodId = vodId;
        }
    }
}
