using MyProject.Data;
using MyProject.Manager;
using MyProject.Common.MiddleWares;
using MyProject.Configuration;
using Serilog;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Microsoft.AspNet.Identity;

IConfiguration configuration = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json")
                            .Build();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((hostingContext, loggerConfiguration) =>
{
    loggerConfiguration
        .MinimumLevel.Information()
        .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
        .MinimumLevel.Override("System", LogEventLevel.Warning)
        .WriteTo.Console();

    // Local File Sink
    loggerConfiguration.WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day);

    // Azure Blob Storage Sink => on production
    var azureBlobStorageConnectionString = "your_azure_blob_storage_connection_string";
    var azureBlobStorageContainerName = "your_container_name";
    loggerConfiguration.WriteTo.AzureBlobStorage(azureBlobStorageConnectionString,
        LogEventLevel.Warning,
        azureBlobStorageContainerName,
        outputTemplate: "[{Timestamp:HH:mm:ss} {Level}]" +
                        " {SourceContext}{NewLine}{Message:lj}{NewLine}" +
                        "{Exception}{NewLine}");
});

// Add services to the container.
builder.Services.ConfigureDataModule(configuration);

builder.Services.AddLogging(loggingBuilder =>
{
    loggingBuilder.AddSerilog();
});

builder.Services.ConfigureManagerModule(configuration);

builder.Services.ConfigureApiControllers(configuration, "CorsPolicy");

builder.Services.ConfigureApiIdentity(configuration);

builder.Services.AddHealthChecks();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

Log.Information("Starting application");

var app = builder.Build();

var scope = app.Services.CreateAsyncScope();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging(o =>
{
    o.EnrichDiagnosticContext = (diagnosticContext, httpContext) =>
    {
        //diagnosticContext.Set("TenantId", httpContext.User?.Identity..GetTenantId());
        diagnosticContext.Set("UserId", httpContext.User?.Identity.GetUserId());
    };
});

app.UseSwaggerDocumentation(configuration);

app.UseCustomExceptionHandler();

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseStaticFiles();

app.UseRequestLocalization();

await app.MigrateAndSeedDatabaseAsync();

app.UseResultWrapper();

app.UseRouting();

app.UseAuthentication();
app.UseRolePermissions();
app.UseAuthorization();

app.UseUnitOfWork();

app.UseEndpoints(endpoints =>
{
    endpoints.MapHealthChecks("/health");
    endpoints.MapDefaultControllerRoute();
});

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
