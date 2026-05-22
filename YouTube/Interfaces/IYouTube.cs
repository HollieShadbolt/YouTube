namespace YouTube.Interfaces;

/// <summary>
/// A YouTube caller instance.
/// </summary>
public interface IYouTube
{
    /// <summary>
    /// Returns a collection of playlist items that match the API request parameters.
    /// </summary>
    /// <param name="videoKind">The kind, or type, of the referred resource.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    Task<IEnumerable<Responses.Snippet>> GetPlaylistItemsAsync(VideoKind videoKind, CancellationToken cancellationToken);
}