public class TimeMiddleware
{
    readonly RequestDelegate next;
    public  TimeMiddleware(RequestDelegate netRequest)
    {
        next = netRequest;
    }
    public async Task Invoke(Microsoft.AspNetCore.Http.HttpContext context)
    {
        await next(context);
        if (context.Request.Query.Any(p => p.Key == "time"))
        {
            await context.Response.WriteAsync(DateTime.Now.ToShortDateString());
        }
    }
}
public static class TimeMiddlewareExtencion
{
    public static IApplicationBuilder UseTimeMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<TimeMiddleware>();
    }
}