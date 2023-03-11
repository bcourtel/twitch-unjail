using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.RegularExpressions;
using TwitchUnjail.Core.Models.HttpRequests;
using TwitchUnjail.Core.Models.HttpResponses;
using TwitchUnjail.Core.Utilities;

namespace TwitchUnjail.Core
{

    public static partial class Api
    {

        private const string ApiUrl = "https://api.twitch.tv";
        private const string TokenUrl = "https://gql.twitch.tv/gql";
        private const string TwitchClientId = "kimne78kx3ncx6brgo4mv6wki5h1ko";
        private static readonly Regex TwitchVodRegex = new("twitch\\.tv\\/videos\\/([0-9]+)", RegexOptions.IgnoreCase);

        public static async ValueTask<VideoInfoResponse> GetVideoInfo(string url)
        {
            var videoId = GetVideoIdForUrl(url).ToString();

            using var client = new HttpClient();
            client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/json");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Client-ID", TwitchClientId);

            using var firstRequest = new HttpRequestMessage(new HttpMethod("POST"), TokenUrl);
            var videoPlayer_VODSeekbarPreviewVideoRequest = new VideoPlayer_VODSeekbarPreviewVideoRequest(videoId);
            var firstParam = new List<VideoPlayer_VODSeekbarPreviewVideoRequest>();
            firstParam.Add(videoPlayer_VODSeekbarPreviewVideoRequest);
            firstRequest.Content = JsonContent.Create<List<VideoPlayer_VODSeekbarPreviewVideoRequest>>(firstParam, MediaTypeHeaderValue.Parse("application/json"));
            var firstResponse = await client.SendAsync(firstRequest);
            firstResponse.EnsureSuccessStatusCode();
            var firstResponseContent = await firstResponse.Content.ReadAsStringAsync();
            var firstContent = JsonSerializer.Deserialize<List<VideoPlayer_VODSeekbarPreviewVideoResponse>>(firstResponseContent);
            var videoPlayer_VODSeekbarPreviewVideoResponse = firstContent[0];

            using var secondRequest = new HttpRequestMessage(new HttpMethod("POST"), TokenUrl);
            var comscoreStreamingQueryRequest = new ComscoreStreamingQueryRequest(videoId);
            var secondParam = new List<ComscoreStreamingQueryRequest>();
            secondParam.Add(comscoreStreamingQueryRequest);
            secondRequest.Content = JsonContent.Create<List<ComscoreStreamingQueryRequest>>(secondParam, MediaTypeHeaderValue.Parse("application/json"));
            var secondResponse = await client.SendAsync(secondRequest);
            secondResponse.EnsureSuccessStatusCode();
            var secondResponseContent = await secondResponse.Content.ReadAsStringAsync();
            var secondContent = JsonSerializer.Deserialize<List<ComscoreStreamingQueryResponse>>(secondResponseContent);
            var comscoreStreamingQueryResponse = secondContent[0];
            var videoInfoResponseChannel = new VideoInfoResponseChannel();
            videoInfoResponseChannel.DisplayName = comscoreStreamingQueryResponse.Data.Video.Owner.DisplayName;
            videoInfoResponseChannel.Id = long.Parse(comscoreStreamingQueryResponse.Data.Video.Owner.Id);

            var videoInfoResponse = new VideoInfoResponse();
            videoInfoResponse.BroadcastId = long.Parse(videoPlayer_VODSeekbarPreviewVideoResponse.Data.Video.Id);
            videoInfoResponse.SeekPreviewsUrl = videoPlayer_VODSeekbarPreviewVideoResponse.Data.Video.SeekPreviewsUrl;
            videoInfoResponse.Channel = videoInfoResponseChannel;
            videoInfoResponse.Length = comscoreStreamingQueryResponse.Data.Video.LengthSeconds;
            videoInfoResponse.Title = comscoreStreamingQueryResponse.Data.Video.Title;
            videoInfoResponse.RecordDate = comscoreStreamingQueryResponse.Data.Video.CreatedAt;
            return videoInfoResponse;
        }

        public static async ValueTask<PlaybackAccessTokenResponse> GetPlaybackAccessToken(string id, bool isLive)
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", HttpHelper.UserAgent);
            client.DefaultRequestHeaders.Add("Client-ID", TwitchClientId);
            var response = await client.PostAsJsonAsync(TokenUrl, new PlaybackAccessTokenRequest(isLive, id));
            response.EnsureSuccessStatusCode();
            return JsonSerializer.Deserialize<PlaybackAccessTokenResponse>(await response.Content.ReadAsStringAsync());
        }

        public static long GetVideoIdForUrl(string url)
        {
            try
            {
                var matches = TwitchVodRegex.Match(url);
                if (matches.Success && matches.Groups.Count == 2)
                {
                    return long.Parse(matches.Groups[1].Value);
                }
            }
            catch { /* ignored */ }

            throw new Exception($"Unable to find vod-id in url: {url ?? "NULL"}");
        }
    }
}
