using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Library72.Application.Common.Interfaces;
using Library72.Storage.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Library72.Application;

public static class ConfigureServices
{
	public static IServiceCollection AddInfrastrucutreServices(this IServiceCollection services)
	{
		services.AddScoped<IDbContext>(provider => provider.GetRequiredService<Test72Context>());

		return services;
	}
}