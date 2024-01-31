using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Serilog;
using Serilog.Events;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
public class LogActionAttribute : ActionFilterAttribute
{
    private readonly ILogger<LogActionAttribute> _logger;
    private readonly LogProvider _logProvider;

    public LogActionAttribute(LogProvider logProvider = LogProvider.Console)
    {
        _logProvider = logProvider;
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var methodName = context.ActionDescriptor.DisplayName;

        var parameters = context.ActionArguments.Select(arg =>
            new
            {
                Name = arg.Key,
                Value = JsonConvert.SerializeObject(arg.Value)
            });

        LogInformation($"Entering {methodName}. Parameters: {string.Join(", ", parameters)}");
    }

    public override void OnActionExecuted(ActionExecutedContext context)
    {
        var methodName = context.ActionDescriptor.DisplayName;

        if (context.Exception != null)
        {
            LogError($"Error in {methodName}. Line: {context.Exception.StackTrace.Split(':')[1]} - {context.Exception.Message}");
        }
        else
        {
            LogInformation($"Exiting {methodName}");
        }
    }

    private void LogInformation(string message)
    {
        switch (_logProvider)
        {
            case LogProvider.Console:
                Console.WriteLine(message);
                break;
            case LogProvider.File:
                Log.Logger.Information(message);
                break;
            case LogProvider.MSSqlServer:
                Log.Logger = new LoggerConfiguration()
        .WriteTo.MSSqlServer(
      connectionString: "Data Source=RAMAZANKUCUKKOC;Initial Catalog=ETradeApp;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False",
      tableName: "Logs",
      restrictedToMinimumLevel: LogEventLevel.Debug, // Debug seviyesi için
      autoCreateSqlTable: true)
     .CreateLogger(); break;
            default:
                _logger.LogInformation(message);
                break;
        }
    }
    private void LogError(string message)
    {
        switch (_logProvider)
        {
            case LogProvider.Console:
                Console.WriteLine($"ERROR: {message}");
                break;
            case LogProvider.File:
                Log.Logger.Error(message);
                break;
            case LogProvider.MSSqlServer:
                Log.Logger = new LoggerConfiguration()
        .WriteTo.MSSqlServer(
      connectionString: "Data Source=RAMAZANKUCUKKOC;Initial Catalog=ETradeApp;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False",
      tableName: "Logs",
      restrictedToMinimumLevel: LogEventLevel.Debug, // Debug seviyesi için
      autoCreateSqlTable: true)
     .CreateLogger();
                break;
            default:
                _logger.LogError(message);
                break;
        }
    }
}

public enum LogProvider
{
    Console,
    File,
    MSSqlServer,
    // Diğer loglama sağlayıcılarını ekleyebilirsiniz.
}
