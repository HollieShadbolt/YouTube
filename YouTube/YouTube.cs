using YouTube.Interfaces;
using YouTube.Responses;
using PlaylistItems = YouTube.Responses.PlaylistItems;

namespace YouTube;

public sealed class YouTube(
    HttpRequestMessageHandler.Interfaces.IHttpRequestMessageFactoryHandler httpRequestMessageFactoryHandler,
    IConfig config) : IYouTube
{
    private const string Uri = "https://www.googleapis.com/youtube/v3/playlistItems";

    /// <inheritdoc/>
    /// <exception cref="TaskCanceledException">The cancellation token was cancelled.</exception>
    public async Task<IEnumerable<Snippet>> GetPlaylistItemsAsync(VideoKind videoKind, CancellationToken cancellationToken)
    {
        var httpRequestMessageFactory = GetHttpRequestMessageFactory(videoKind);

        var playlistItems = await httpRequestMessageFactoryHandler.SendAsync<PlaylistItems>(
            httpRequestMessageFactory,
            cancellationToken);

        return playlistItems.Items.Select(playlistItem => playlistItem.Snippet);
    }

    private Func<HttpRequestMessage> GetHttpRequestMessageFactory(VideoKind videoKind) => () =>
    {
        var uriBuilder = new UriBuilder(Uri);

        var query = System.Web.HttpUtility.ParseQueryString(uriBuilder.Query);

        query["key"] = config.Key;
        query["part"] = "snippet";
        query["playlistId"] = videoKind.ToPlaylistIdPrefix() + config.ChannelId;
        query["maxResults"] = 50.ToString();

        uriBuilder.Query = query.ToString();

        return new HttpRequestMessage(HttpMethod.Get, uriBuilder.Uri);
    };
}