using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
internal class Program
{
    private static void Main(string[] args)
    {
        var host = new HostBuilder()
          .ConfigureHostConfiguration(configHost =>
          {
          })
          .ConfigureServices((hostContext, services) =>
          {
              services.AddHostedService<Relay>();
              services.AddDbContext<AppDbContext>();
              services.AddScoped<AppDbContext>();
              services.AddScoped<Publisher>();
          })
         .UseConsoleLifetime()
         .Build();

        //run the host
        host.Run();
    }
}