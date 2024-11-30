using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MyCli.Commands;
using MyCli.Services;
using System.CommandLine;

static void ConfigureServices(IServiceCollection services)
{
    // build config
    var configuration = new ConfigurationBuilder()
        .AddEnvironmentVariables()
        .Build();

    void Configure<TConfig>(string sectionName) where TConfig : class
    {
        services
            .AddSingleton(p => p.GetRequiredService<IOptions<TConfig>>().Value)
            .AddOptions<TConfig>()
            .Bind(configuration.GetSection(sectionName));
    }

    // options
    Configure<WeatherServiceOptions>(WeatherServiceOptions.SectionName);

    // add commands:
    services.AddTransient<Command, CurrentCommand>();
    services.AddTransient<Command, ForecastCommand>();
    services.AddTransient<WeatherService>();
}

// create service collection
var services = new ServiceCollection();
ConfigureServices(services);

// create service provider
using var serviceProvider = services.BuildServiceProvider();

// entry to run app
var commands = serviceProvider.GetServices<Command>();
var rootCommand = new RootCommand("Weather information using a very unreliable weather service.");
commands.ToList().ForEach(command => rootCommand.AddCommand(command));

await rootCommand.InvokeAsync(args);

