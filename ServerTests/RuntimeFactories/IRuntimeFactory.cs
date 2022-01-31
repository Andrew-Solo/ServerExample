using System;
using Server.Server;

namespace ServerTests.RuntimeFactories;

/// <summary>
/// Abstract factory for creating and handling related instances for testing
/// </summary>
public interface IRuntimeFactory : IAsyncDisposable
{
    /// <summary>
    /// Creates and build a server Runtime instance
    /// </summary>
    IRuntime CreateRuntime();
}
