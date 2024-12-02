using Microsoft.Extensions.Logging;
using System.CommandLine;

public class App: RootCommand
{
    private readonly ILogger<App> _logger;
    private readonly AppOptions _options;

    public App(AppOptions options, ILogger<App> logger):
        base("Sends a nice greeting to the user.")
    {
        _logger = logger;
        _options = options;

        var nameArgument = new Argument<string>("name", "The name of the person to greet.");
        AddArgument(nameArgument);

        this.SetHandler(Execute, nameArgument);
    }

    private async Task Execute(string name)
    {
        _logger.LogInformation("Starting...");
        var greeting = string.Format(_options.Greeting, name);
        _logger.LogDebug($"Greeting: {greeting}");

        Console.WriteLine(greeting);

        _logger.LogInformation("Finished!");

        await Task.CompletedTask;
    }
}