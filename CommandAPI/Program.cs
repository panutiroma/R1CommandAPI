using Azure.Identity;
using Microsoft.AspNetCore;

namespace CommandAPI;

public class Program
{
    public static void Main(string[] args)
    {
        CreateWebHostBuilder(args).Build().Run();
    }

    //public static IHostBuilder CreateWebHostBuilder(string[] args) => 
    //    Host.CreateDefaultBuilder(args)
    //        .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());

    public static IWebHostBuilder CreateWebHostBuilder(string[] args)
    {
        var builder = WebHost.CreateDefaultBuilder(args);

        var isDevelopment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == Environments.Development;
        Console.WriteLine(isDevelopment ? "Is Development" : "Is Production");

        builder.ConfigureAppConfiguration((hostingContext, config) =>
        {
            config.AddAzureAppConfiguration(options =>
            {
                var connectionString = Environment.GetEnvironmentVariable("COMMAND_APP_CONFIG");

                options.Connect(connectionString).UseFeatureFlags();
                options.ConfigureKeyVault(options =>
                {
                    options.SetCredential(new DefaultAzureCredential());
                });
            });

            //if (isDevelopment)
            //{
            //    // Prioritize Config Sources to use appsettings first for local development
            //    config.PrioritizeAppSettings();
            //}
        });

        return builder.UseStartup<Startup>();
    }
}