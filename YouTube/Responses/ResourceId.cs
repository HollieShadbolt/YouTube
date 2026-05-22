namespace YouTube.Responses;

/// <summary>
/// The ID object contains information that can be used to uniquely identify the resource that is included in the playlist as the playlist item.
/// </summary>
public sealed record ResourceId
{
    /// <summary>
    /// Get the ID that YouTube uses to uniquely identify the video in the playlist.
    /// </summary>
    /// <returns>The ID that YouTube uses to uniquely identify the video in the playlist.</returns>
    [System.Text.Json.Serialization.JsonPropertyNameAttribute("videoId")]
    public required string VideoId { get; init; }
}