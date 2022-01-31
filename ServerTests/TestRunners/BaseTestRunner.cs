using System;
using System.Threading.Tasks;
using Server.Server;
using ServerTests.RuntimeFactories;

namespace ServerTests.TestRunners;

/// <summary>
/// Basic test runner, which can run tests using the RuntimeFactory object passed to it in constructor
/// </summary>
public class BaseTestRunner : ITestRunner
{
    public BaseTestRunner(IRuntimeFactory runtimeFactory, RunnerType runnerType)
    {
        RuntimeFactory = runtimeFactory;
        RunnerType = runnerType;
    }

    ~BaseTestRunner()
    {
        RuntimeFactory.DisposeAsync();
    }

    public IRuntimeFactory RuntimeFactory { get; }
    public RunnerType RunnerType { get; }

    public async Task RunAsync(Func<IRuntime, Task> fTest)
    {
        await fTest(RuntimeFactory.CreateRuntime()).ConfigureAwait(false);
    }

    public void Run(Action<IRuntime> fTest)
    {
        fTest(RuntimeFactory.CreateRuntime());
    }

    public async Task RunMultiserverAsync(Func<IRuntimeFactory, Task> fTest)
    {
        await fTest(RuntimeFactory);
    }

    public void RunMultiserver(Action<IRuntimeFactory> fTest)
    {
        fTest(RuntimeFactory);
    }
}
