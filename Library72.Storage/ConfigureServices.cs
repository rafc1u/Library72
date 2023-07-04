using Library72.Application.Common.Interfaces;
using Library72.Storage;
using Microsoft.Extensions.DependencyInjection;

namespace Library72.Application;

public static class ConfigureServices
{
	public static IServiceCollection AddInfrastrucutreServices(this IServiceCollection services)
	{
		services.AddScoped<ILibrary72DbContext>(provider => provider.GetRequiredService<Library72DbContext>());

		return services;
	}
}