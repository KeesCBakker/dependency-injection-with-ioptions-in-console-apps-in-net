using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();

void Configure<TConfig>(string sectionName) where TConfig : class, new()
{
    builder.Services
        .AddSingleton(p => p.GetRequiredService<IOptions<TConfig>>().Value)
        .AddOptions<TConfig>()
        .Bind(builder.Configuration.GetSection(sectionName))
        .ValidateDataAnnotations()
        .ValidateOnStart();
}

Configure<JwtOptions>(JwtOptions.SectionName);

builder.Services.AddJwtAndAccessPolicies();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
