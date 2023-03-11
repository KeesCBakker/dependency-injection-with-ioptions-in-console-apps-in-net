using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.CommandLine;

public class App: RootCommand
{
    private readonly ILogger<App> _logger;
    private readonly AppSettings _appSettings;

    public App(IOptions<AppSettings> appSettings, ILogger<App> logger):
        base("Sends a nice greeting to the user.")
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _appSettings = appSettings?.Value ?? throw new ArgumentNullException(nameof(appSettings));

        var nameArgument = new Argument<string>("name", "The name of the person to greet.");
        AddArgument(nameArgument);

        this.SetHandler(Execute, nameArgument);
    }

    private async Task Execute(string name)
    {
        _logger.LogInformation("Starting...");
        var greeting = String.Format(_appSettings.Greeting, name);
        _logger.LogDebug($"Greeting: {greeting}");

        Console.WriteLine(greeting);

        _logger.LogInformation("Finished!");

        await Task.CompletedTask;
    }
}