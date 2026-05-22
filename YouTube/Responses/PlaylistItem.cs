namespace YouTube.Responses;

/// <summary>
/// The playlist item.
/// </summary>
public sealed record PlaylistItem
{
    /// <summary>
    /// Get the basic details about the playlist item.
    /// </summary>
    /// <returns>The basic details about the playlist item.</returns>
    [System.Text.Json.Serialization.JsonPropertyNameAttribute("snippet")]
    public required Snippet Snippet { get; init; }
}