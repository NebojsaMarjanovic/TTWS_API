namespace TTWS_Api_DotNet6_Final.Middleware
{
    public class TestMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await next.Invoke(context);
        }
    }
}
