var builder = WebApplication.CreateBuilder(args);

// Environment variables override appsettings
builder.Configuration.AddEnvironmentVariables();

var app = builder.Build();

app.MapGet("/", () =>
{
    var appName = app.Configuration["App:Name"];
    var env = app.Configuration["App:Environment"];
    var featureX = app.Configuration["App:FeatureXEnabled"];
    var secret = app.Configuration["MY_SECRET"] ?? "Not Set";

    return new
    {
        App = appName,
        Environment = env,
        FeatureXEnabled = featureX,
        SecretLength = secret.Length
    };
});

app.MapGet("/health", () => "Healthy");

app.Run();
