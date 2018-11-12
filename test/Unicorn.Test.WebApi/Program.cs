using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Unicorn.AspNetCore.Middleware.RealIp;

namespace Unicorn.Test.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseRealIp("X-Forwarded-For")
                .UseStartup<Startup>();
    }
}
