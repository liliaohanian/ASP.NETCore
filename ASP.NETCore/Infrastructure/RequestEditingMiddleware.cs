using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NETCore.Infrastructure
{
    public class RequestEditingMiddleware
    {
        private RequestDelegate nextDelegate;
        public RequestEditingMiddleware(RequestDelegate next)
        {
            nextDelegate = next;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            httpContext.Items["ChromeBrowser"]
                = httpContext.Request.Headers["User-Agent"]
                .Any(v => v.ToLower().Contains("chrome"));
            await nextDelegate.Invoke(httpContext);
        }
    }
}
