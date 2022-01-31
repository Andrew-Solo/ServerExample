using ServerTests.RuntimeFactories;

namespace ServerTests.TestRunners;

public class TestRunner : BaseTestRunner
{
    public TestRunner() : base(new RuntimeFactory(), RunnerType.Default) {}
}
