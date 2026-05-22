namespace YouTube.Responses;

/// <summary>
/// A <see cref="Interfaces.IYouTube.GetPlaylistItemsAsync"/> response.
/// </summary>
public sealed record PlaylistItems
{
    /// <summary>
    /// Get the <see cref="PlaylistItem"/> collection.
    /// </summary>
    /// <returns>The <see cref="PlaylistItem"/> collection.</returns>
    [System.Text.Json.Serialization.JsonPropertyNameAttribute("items")]
    public required IEnumerable<PlaylistItem> Items { get; init; }
}