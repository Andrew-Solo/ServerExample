using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Server.Server;

namespace ServerTests.RuntimeFactories;

public class RuntimeFactory : IRuntimeFactory
{
    public RuntimeFactory()
    {
        _disposed = false;
        _serverRuntimes = new List<IRuntime>();
    }

    /// <summary>
    /// Creates an instance using default configuration
    /// </summary>
    /// <exception cref="Exception">Throws an exception if ServerRuntime build fails</exception>
    public IRuntime CreateRuntime()
    {
        var builder = IRuntime.CreateDefaultBuilder();
        var runtime = builder.Build();

        if (!builder.IsBuiltSuccess)
        {
            throw new Exception("Server build filed");
        }
            
        _serverRuntimes.Add(runtime);

        return runtime;
    }

    public async ValueTask DisposeAsync()
    {
        if (_disposed)
        {
            return;
        }

        foreach (var runtime in _serverRuntimes)
        {
            await runtime.DisposeAsync();
        }

        _disposed = true;
    }

    //Disposing
    private readonly List<IRuntime> _serverRuntimes;
    private bool _disposed;
}
