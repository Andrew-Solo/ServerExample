namespace Server.Server;

public class RuntimeOptions
{
    public RuntimeOptions()
    {
        WebApplicationOptions = Setup.DefaultWebApplicationOptions;
        FSetupBuildList = Setup.DefaultBuild;
        FSetupApplicationList = Setup.DefaultPipeline;
    }

    public WebApplicationOptions WebApplicationOptions { get; set; }
    public List<Action<WebApplicationBuilder>> FSetupBuildList { get; set; }
    public List<Action<WebApplication>> FSetupApplicationList { get; set; }
}
