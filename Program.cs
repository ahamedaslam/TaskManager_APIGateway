using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

#region ================== Load Ocelot Config ==================

builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

#endregion

#region ================== Services ==================

builder.Services.AddOcelot();

#endregion

var app = builder.Build();

#region ================== Middleware ==================

await app.UseOcelot();

#endregion

app.Run();