using Library72.Application.Books.GetBooksList;
using Library72.Application.Common.Interfaces;
using Library72.Storage.Entities;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;

namespace Library72.Extensions;

public static class ApiExtensions
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        services.AddTransient<HttpExceptionMiddleware>();

        return services;
    }
}
