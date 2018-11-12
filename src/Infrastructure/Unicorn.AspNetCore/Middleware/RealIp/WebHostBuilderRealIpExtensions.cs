using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Unicorn.AspNetCore.Middleware.RealIp
{
    /// <summary>
    /// Processing client real IP address Middleware
    /// </summary>
    public static class WebHostBuilderRealIpExtensions
    {
        /// <summary>
        /// Enable RealIp Middleware
        /// </summary>
        /// <param name="hostBuilder"></param>
        /// <param name="headerKey">The request header key is used to get IP from the request header.</param>
        /// <returns></returns>
        public static IWebHostBuilder UseRealIp(this IWebHostBuilder hostBuilder,string headerKey)
        {
            if (hostBuilder == null)
            {
                throw new ArgumentNullException(nameof(hostBuilder));
            }

            // check loaded
            if (hostBuilder.GetSetting(nameof(UseRealIp)) != null)
            {
                return hostBuilder;
            }

            hostBuilder.UseSetting(nameof(UseRealIp), true.ToString());

            hostBuilder.ConfigureServices(services => {
                
                services.AddSingleton<IStartupFilter>(new RealIpFilter());
                services.Configure<RealIpOptions>(options =>options.HeaderKey=headerKey );
            });

            return hostBuilder;
        }

    }
}
