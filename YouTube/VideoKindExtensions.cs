namespace YouTube;

/// <summary>
/// <see cref="VideoKind"/> extensions.
/// </summary>
public static class VideoKindExtensions
{
    /// <summary>
    /// Get the Playlist ID prefix.
    /// </summary>
    /// <param name="videoKind">The <see cref="VideoKind"/>.</param>
    /// <returns>The Playlist ID prefix.</returns>
    /// <exception cref="ArgumentOutOfRangeException">An argument is outside the allowable range of values.</exception>
    public static string ToPlaylistIdPrefix(this VideoKind videoKind) => videoKind switch
    {
        // ReSharper disable StringLiteralTypo
        VideoKind.Videos => "UULF",
        VideoKind.Shorts => "UUSH",
        VideoKind.Streams => "UULV",
        _ => throw new ArgumentOutOfRangeException(nameof(videoKind), videoKind, null)
    };
}