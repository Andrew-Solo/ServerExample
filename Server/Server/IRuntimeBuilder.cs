namespace Server.Server;

/// <summary>
/// Server runtime builder interface to build a prepared server runtime instance
/// </summary>
public interface IRuntimeBuilder
{
    /// <summary>
    /// Is server runtime built successfully
    /// </summary>
    public bool IsBuiltSuccess { get; }
    
    /// <summary>
    /// Build an instance of server runtime
    /// </summary>
    IRuntime Build();
}
