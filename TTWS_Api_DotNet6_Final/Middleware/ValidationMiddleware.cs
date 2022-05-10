using System.Text.RegularExpressions;

namespace TTWS_Api_DotNet6_Final.Middleware
{
    public class ValidationMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {

            var isin = context.Request.RouteValues["isin"]?.ToString();
            var regex = "([A-Z]{2})([A-Z0-9]{9})([A-Z0-9]{1})";
            Match? match = Regex.Match(isin, regex, RegexOptions.IgnoreCase);

            if (!match.Success)
                context.Response.StatusCode = 404;
            else
                await next.Invoke(context);
        }
    }
}
