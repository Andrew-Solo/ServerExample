using Server.Server;

var builder = IRuntime.CreateDefaultBuilder();
var runtime = builder.Build();

if (builder.IsBuiltSuccess)
{
    runtime.StartAsync();
}
