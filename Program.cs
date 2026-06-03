using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Load Ocelot configuration from ocelot.json
builder.Configuration.AddJsonFile(
    "ocelot.json",
    optional: false,
    reloadOnChange: true);


// Add CORS policy to allow requests from the Angular frontend
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy =>
        {
            policy
                .WithOrigins("http://localhost:4200")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});


// Add Ocelot services to the DI container
builder.Services.AddOcelot();

var app = builder.Build();

app.UseCors("AllowAngular");

await app.UseOcelot();

app.Run();