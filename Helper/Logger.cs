using Microsoft.Extensions.Configuration;
using Serilog;
using System.IO;

namespace UiHelper.Logging
{
    public class Logger
    {
        private static Serilog.Core.Logger logger;


        public static Serilog.Core.Logger Instance
        {
            get
            {
                if (logger == null)
                {
                    try
                    {
                        var configuration = new ConfigurationBuilder()
                                               .AddJsonFile("serilogsettings.json")
                                               .Build();

                        logger = new LoggerConfiguration()
                            .ReadFrom.Configuration(configuration)
                            .CreateLogger();
                    }
                    catch (FileNotFoundException)
                    {
                        logger = new LoggerConfiguration()
                                    .WriteTo.Console()
                                    .WriteTo.File(@"C:\Logs\TA\TA_default.log")
                                    .MinimumLevel.Debug()
                                    .CreateLogger();
                    }
                }
                return logger;
            }
        }
    }
}
