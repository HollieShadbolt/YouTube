using Moq;
using YouTube;

namespace YouTubeTests;

public class Tests
{
    [Test]
    public async Task GetPlaylistItemsAsync_TestAsync([Values] VideoKind videoKind)
    {
        // Arrange
        var mockHttpRequestMessageFactoryHandler =
            new Mock<HttpRequestMessageHandler.Interfaces.IHttpRequestMessageFactoryHandler>();

        var cancellationTokenSource = new CancellationTokenSource();

        var videoId = Guid.NewGuid().ToString();

        var resourceId = new YouTube.Responses.ResourceId
        {
            VideoId = videoId
        };

        var snippet = new YouTube.Responses.Snippet
        {
            ResourceId = resourceId
        };

        YouTube.Responses.PlaylistItem[] items =
        [
            new()
            {
                Snippet = snippet
            }
        ];

        var playlistItems = new YouTube.Responses.PlaylistItems
        {
            Items = items
        };

        mockHttpRequestMessageFactoryHandler
            .Setup(httpRequestMessageFactoryHandler =>
                httpRequestMessageFactoryHandler.SendAsync<YouTube.Responses.PlaylistItems>(
                    It.IsAny<Func<HttpRequestMessage>>(),
                    cancellationTokenSource.Token))
            .ReturnsAsync(playlistItems);

        var mockConfig = new Mock<YouTube.Interfaces.IConfig>();

        var key = Guid.NewGuid().ToString();

        mockConfig.SetupGet(config => config.Key).Returns(key);

        var channelId = Guid.NewGuid().ToString();

        mockConfig.SetupGet(config => config.ChannelId).Returns(channelId);

        var youTube = new YouTube.YouTube(mockHttpRequestMessageFactoryHandler.Object, mockConfig.Object);

        // Act
        var actualResourceIds = await youTube.GetPlaylistItemsAsync(videoKind, cancellationTokenSource.Token);

        // Assert
        var expectedResourceIds = playlistItems.Items.Select(playlistItem => playlistItem.Snippet.ResourceId);

        Assert.That(actualResourceIds, Is.EqualTo(expectedResourceIds));

        mockHttpRequestMessageFactoryHandler
            .Verify(
                httpRequestMessageFactoryHandler =>
                    httpRequestMessageFactoryHandler.SendAsync<YouTube.Responses.PlaylistItems>(
                        It.Is<Func<HttpRequestMessage>>(httpRequestMessageFactory =>
                            VerifyGetPlaylistItemsAsyncHttpRequestMessageFactory(httpRequestMessageFactory, key,
                                videoKind, channelId)),
                        cancellationTokenSource.Token),
                Times.Exactly(1));

        mockHttpRequestMessageFactoryHandler.VerifyNoOtherCalls();
    }

    private static bool VerifyGetPlaylistItemsAsyncHttpRequestMessageFactory(
        Func<HttpRequestMessage> httpRequestMessageFactory,
        string key,
        VideoKind videoKind,
        string channelId)
    {
        var httpRequestMessage = httpRequestMessageFactory();

        return httpRequestMessage.Method == HttpMethod.Get &&
               httpRequestMessage.RequestUri?.ToString() ==
               $"https://www.googleapis.com/youtube/v3/playlistItems?key=" +
               $"{key}&part=snippet&playlistId={videoKind.ToPlaylistIdPrefix()}{channelId}&maxResults=50";
    }
}