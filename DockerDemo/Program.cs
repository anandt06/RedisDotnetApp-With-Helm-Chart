using NLog;
using NLog.Web;

namespace DockerDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {            
            try
            {
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
               
                throw ex;
            }
            finally
            {
                LogManager.Shutdown();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);

                })
                .UseNLog();
    }
}