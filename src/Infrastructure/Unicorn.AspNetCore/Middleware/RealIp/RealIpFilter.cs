using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace Unicorn.AspNetCore.Middleware.RealIp
{
    public class RealIpFilter : IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return app => {
                app.UseMiddleware<RealIpMiddleware>();
                next(app);
            };
        }
    }

}