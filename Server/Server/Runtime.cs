namespace Server.Server;

public class Runtime : IRuntime
{
    public Runtime(RuntimeOptions options)
    {
        //Initializing properties
        IsStopped = true;
        _disposed = false;
        
        //Building
        var builder = WebApplication.CreateBuilder(options.WebApplicationOptions);
        options.FSetupBuildList.ForEach(func => func(builder));
        
        //Create an instance of app
        WebApplication = builder.Build();
        options.FSetupApplicationList.ForEach(func => func(WebApplication));
    }

    public bool IsStopped { get; private set; }

    public async Task StartAsync()
    {
        IsStopped = false;
        await WebApplication.StartAsync();
    }

    public async Task StopAsync()
    {
        IsStopped = true;
        await WebApplication.StopAsync();
    }
    
    public async ValueTask DisposeAsync()
    {
        if (_disposed)
        {
            return;
        }

        if (!IsStopped)
        {
            await StopAsync();
        }

        await WebApplication.DisposeAsync();

        _disposed = true;
    }

    private bool _disposed;
    
    private WebApplication WebApplication { get; }
}
