namespace Server.Server;

/// <summary>
/// Server runtime interface for managing server processes
/// </summary>
public interface IRuntime : IAsyncDisposable
{
    /// <summary>
    /// Creates the default server runtime builder
    /// </summary>
    /// <returns>Default server runtime builder</returns>
    static IRuntimeBuilder CreateDefaultBuilder()
    {
        return new RuntimeBuilder();
    }
    
    /// <summary>
    /// Is server runtime stopped
    /// </summary>
    public bool IsStopped { get; }
    
    /// <summary>
    /// Starts the server runtime
    /// </summary>
    Task StartAsync();
    
    /// <summary>
    /// Stops the server runtime
    /// </summary>
    Task StopAsync();
}

