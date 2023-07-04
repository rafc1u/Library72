using System.Reflection;
using Library72.Application.Books.GetBooksList;
using Library72.Application.Books.GetBookWithInvertedTitle;
using Microsoft.Extensions.DependencyInjection;

namespace Library72.Application;

public static class ConfigureServices
{
	public static IServiceCollection AddApplicationServices(this IServiceCollection services)
	{
		services.AddMediatR(cfg =>
		{
			cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
		});

		services.AddSingleton<BookToGetBookWithInvertedTitleDtoMapping>();
		services.AddSingleton<BookTakenToBookSearchListDtoMapping>();

		return services;
	}
}