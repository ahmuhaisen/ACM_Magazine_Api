using Serilog;
using Magazine.Api;
using OpenTelemetry.Logs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Host.UseSerilog();

builder.Logging.AddOpenTelemetry(logging => logging.AddOtlpExporter());

builder.Services
    .AddPresentationServices()
    .AddApplicationServices(builder.Configuration)
    .AddInfrastructureServices(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AngularClient");

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseSerilogRequestLogging();

app.MapControllers();

app.UseResponseCaching();

app.UseAuthentication();

app.UseAuthorization();

app.Run();
