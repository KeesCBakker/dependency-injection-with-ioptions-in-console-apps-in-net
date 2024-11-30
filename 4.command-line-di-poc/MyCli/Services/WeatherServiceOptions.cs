namespace MyCli.Services;

class WeatherServiceOptions
{
    public const string SectionName = "Weather";

    public string DefaultCity { get; set; } = "Amsterdam, NLD";

    public int DefaultForecastDays { get; set; } = 5;
}
