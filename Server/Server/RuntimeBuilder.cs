namespace Server.Server;

public class RuntimeBuilder : IRuntimeBuilder
{
    public bool IsBuiltSuccess { get; private set; }
    
    public IRuntime Build()
    {
        return Build(new RuntimeOptions());
    }

    public IRuntime Build(RuntimeOptions options)
    {
        var serverRuntime = new Runtime(options);
        
        IsBuiltSuccess = true;
        
        return serverRuntime;
    }
}
