using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Unicorn.AspNetCore.Middleware.RealIp
{
    public class RealIpMiddleware
    {
        readonly RequestDelegate _next;
        private readonly ILogger<RealIpMiddleware> _logger;
        private readonly RealIpOptions _options;

        public RealIpMiddleware(RequestDelegate next,IOptions<RealIpOptions> options,ILogger<RealIpMiddleware> logger)
        {
            _next = next;
            _logger = logger;
            _options = options.Value;
        }

        public async Task Invoke(HttpContext context)
        {
            var headers = context.Request.Headers;

            try
            {
                if (headers.ContainsKey(_options.HeaderKey))
                {
                    if (_options.HeaderKey.ToLower() == "x-forwarded-for")
                    {
                        context.Connection.RemoteIpAddress = IPAddress.Parse(headers["X-Forwarded-For"].ToString().Split(',')[0]);
                    }
                    else
                    {
                        context.Connection.RemoteIpAddress = IPAddress.Parse(headers[_options.HeaderKey].ToString());
                    }

                    _logger.LogDebug($"Resolve real ip success: {context.Connection.RemoteIpAddress}");
                }
            }
            finally
            {
                await _next(context);
            }
        }
    }
}