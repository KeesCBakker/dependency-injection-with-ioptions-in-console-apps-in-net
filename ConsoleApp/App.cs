using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

public class App
{
    private readonly ILogger<App> _logger;
    private readonly AppSettings _appSettings;

    public App(IOptions<AppSettings> appSettings, ILogger<App> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _appSettings = appSettings?.Value ?? throw new ArgumentNullException(nameof(appSettings));
    }

    public async Task Run(string[] args)
    {
        _logger.LogInformation("Starting...");

        Console.WriteLine("Hello world!");
        Console.WriteLine(_appSettings.TempDirectory);

        _logger.LogInformation("Finished!");

        await Task.CompletedTask;
    }
}