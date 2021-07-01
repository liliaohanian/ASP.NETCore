using Microsoft.AspNetCore.Http;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NETCore.Infrastructure
{
    public class ResponseEditingMiddleware
    {
        private RequestDelegate nextDelegate;
        public ResponseEditingMiddleware(RequestDelegate next)
        {
            nextDelegate = next;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            await nextDelegate.Invoke(httpContext);
            if (httpContext.Response.StatusCode == 403)
            {
                await httpContext.Response
                    .WriteAsync("Chrome not supported", Encoding.UTF8);
            }
            else if (httpContext.Response.StatusCode == 404)
            {
                await httpContext.Response
                    .WriteAsync("No content middleware response", Encoding.UTF8);
            }
        }
    }
}
