namespace CommandAPI;

public class Program
{
    public static void Main(string[] args)
    {
        //var builder = WebApplication.CreateBuilder(args);
        //var app = builder.Build();
        //app.MapGet("/", () => "Hello World!");
        //app.Run();

        CreateWebHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateWebHostBuilder(string[] args) => 
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());
}