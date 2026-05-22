namespace YouTube.Interfaces;

/// <summary>
/// A <see cref="YouTube"/> config.
/// </summary>
public interface IConfig
{
    /// <summary>
    /// Get the API key.
    /// </summary>
    /// <returns>The API key.</returns>
    string Key { get; }

    /// <summary>
    /// Get the ID of the channel.
    /// </summary>
    /// <returns>The ID of the channel.</returns>
    string ChannelId { get; }
}