using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Tranning_pro.Meddilware
{
    public class HeaderCheckMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly HederChickSettings _heder;

        public HeaderCheckMiddleware(RequestDelegate next, IOptions<HederChickSettings> options)
        {
            _next = next;
            _heder=options.Value;  
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var heddername = _heder.RequiredHeaderName;
            // Example: Require a specific header
            if (!context.Request.Headers.TryGetValue(heddername, out var headerValue) || string.IsNullOrWhiteSpace(headerValue) || (!string.IsNullOrEmpty(_heder.ExpectedValue) && headerValue != _heder.ExpectedValue))
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync("Missing or invalid X-Custom-Header.");
                return;
            }

            // You can log or use the header value here as needed

            await _next(context); // Continue to the next middleware
        }
    }
    public class HederChickSettings 
    {
        public string RequiredHeaderName { get; set; }
        public string ExpectedValue { get; set;}
    }

}
