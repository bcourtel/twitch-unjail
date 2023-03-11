using System.Text.Json.Serialization;

namespace TwitchUnjail.Core.Models.HttpRequests
{
    public class VideoPlayer_VODSeekbarPreviewVideoRequest
    {
        [JsonPropertyName("operationName")]
        public string OperationName { get; set; }

        [JsonPropertyName("variables")]
        public VideoPlayer_VODSeekbarPreviewVideoVariables Variables { get; set; }

        [JsonPropertyName("extensions")]
        public Extensions Extensions { get; set; }

        public VideoPlayer_VODSeekbarPreviewVideoRequest(string videoId)
        {
            OperationName = "VideoPlayer_VODSeekbarPreviewVideo";
            Variables = new VideoPlayer_VODSeekbarPreviewVideoVariables(videoId);
            Extensions = new Extensions("07e99e4d56c5a7c67117a154777b0baf85a5ffefa393b213f4bc712ccaf85dd6");
        }
    }

    public class VideoPlayer_VODSeekbarPreviewVideoVariables
    {
        [JsonPropertyName("includePrivate")]
        public bool IncludePrivate { get; set; }

        [JsonPropertyName("videoID")]
        public string VideoId { get; set; }

        public VideoPlayer_VODSeekbarPreviewVideoVariables(string videoId)
        {
            IncludePrivate = false;
            VideoId = videoId;
        }
    }
}
