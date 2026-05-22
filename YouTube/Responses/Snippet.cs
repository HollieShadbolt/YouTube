using JsonPropertyNameAttribute = System.Text.Json.Serialization.JsonPropertyNameAttribute;

namespace YouTube.Responses;

/// <summary>
/// The basic details about a playlist item.
/// </summary>
public sealed record Snippet
{
    /// <summary>
    /// Get the date and time that the item was added to the playlist.
    /// </summary>
    /// <returns>The date and time that the item was added to the playlist.</returns>
    [JsonPropertyName("publishedAt")]
    public required DateTime PublishedAt { get; init; }

    /// <summary>
    /// Get the ID object contains information that can be used to uniquely identify the resource that is included in the playlist as the playlist item.
    /// </summary>
    /// <returns>The ID object contains information that can be used to uniquely identify the resource that is included in the playlist as the playlist item.</returns>
    [JsonPropertyName("resourceId")]
    public required ResourceId ResourceId { get; init; }
}