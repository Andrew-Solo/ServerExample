using System;
using System.Threading.Tasks;
using Server.Server;
using ServerTests.RuntimeFactories;

namespace ServerTests.TestRunners;

/// <summary>
/// An interface for running tests with an IServerRuntime instance.
/// Useful for running the same test code on multiple runtime builds.
/// </summary>
public interface ITestRunner
{
    /// <summary>
    /// An instance of IRuntimeFactory, used in RunAsync and Run methods.
    /// </summary>
    IRuntimeFactory RuntimeFactory { get; }
    
    /// <summary>
    /// An integer type of test runner
    /// </summary>
    RunnerType RunnerType { get; }
        
    /// <summary>
    /// Runs a test method, passing in a RuntimeFactory-prepared instance of IServerRuntime into it.
    /// </summary>
    /// <param name="fTest">An async method to test that takes an IServerRuntime as an argument.</param>
    Task RunAsync(Func<IRuntime, Task> fTest);
        
    /// <summary>
    /// Runs a test method, passing in a RuntimeFactory-prepared instance of IServerRuntime into it.
    /// </summary>
    /// <param name="fTest">A method to test that takes an IServerRuntime as an argument.</param>
    void Run(Action<IRuntime> fTest);
    
    /// <summary>
    /// Runs a test method, passing in IRuntimeFactory into it, for multi-server testing.
    /// </summary>
    /// <param name="fTest">An async method to multi-server test that takes an IRuntimeFactory as an argument.</param>
    Task RunMultiserverAsync(Func<IRuntimeFactory, Task> fTest);
        
    /// <summary>
    /// Runs a test method, passing in IRuntimeFactory into it, for multi-server testing.
    /// </summary>
    /// <param name="fTest">A method to multi-server test that takes an IRuntimeFactory as an argument.</param>
    void RunMultiserver(Action<IRuntimeFactory> fTest);
}
