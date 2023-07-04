namespace Library72.Extensions;

public static class ApiExtensions
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        services.AddTransient<HttpExceptionMiddleware>();

        return services;
    }
}
