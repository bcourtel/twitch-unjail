using System.Text.Json;
using System.Text.Json.Serialization;

namespace TwitchUnjail.Core.Models.HttpResponses
{
    public class VideoPlayer_VODSeekbarPreviewVideoResponse
    {
        [JsonPropertyName("data")]
        public VideoPlayer_VODSeekbarPreviewVideoResponseData Data { get; set; }
    }

    public class VideoPlayer_VODSeekbarPreviewVideoResponseData
    {
        [JsonPropertyName("video")]
        public VideoPlayer_VODSeekbarPreviewVideoResponseVideo Video { get; set; }
    }

    public class VideoPlayer_VODSeekbarPreviewVideoResponseVideo
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("seekPreviewsURL")]
        public string SeekPreviewsUrl { get; set; }
    }
}
