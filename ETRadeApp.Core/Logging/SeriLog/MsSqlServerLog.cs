using Serilog.Events;
using Serilog;

namespace ETRadeApp.Core.Logging.SeriLog
{
    public class MsSqlServerLog
    {
        public MsSqlServerLog()
        {
            Log.Logger = new LoggerConfiguration()
          .WriteTo.MSSqlServer(
        connectionString: "Data Source=RAMAZANKUCUKKOC;Initial Catalog=ETradeApp;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False",
        tableName: "Logs",
        restrictedToMinimumLevel: LogEventLevel.Debug, // Debug seviyesi için
        autoCreateSqlTable: true)
       .CreateLogger();

        }
    }
}
