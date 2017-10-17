using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Easynvest.SimulatorCalc.Api
{
    public class Program
    {
        const string APP_URL = "http://0.0.0.0:5000";

        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseUrls(APP_URL)
                .Build();
    }
}
