namespace FRMJX.Infrastructure.BasicDataDomain;

using FRMJX.Infrastructure.BasicDataDomain.Services;
using FRMJX.Core.BaseDataDomain.Services;
using Microsoft.Extensions.DependencyInjection;

public static class ServiceConfiguration
{
	public static void ConfigureBasicDataDomainServices(this IServiceCollection services)
	{
		services.AddScoped<IStateCreateService, StateCreateService>();
		services.AddScoped<IStateDeleteService, StateDeleteService>();
		services.AddScoped<IStateGetService, StateGetService>();
		services.AddScoped<IStateUpdateService, StateUpdateService>();

		services.AddScoped<ICityCreateService, CityCreateService>();
		services.AddScoped<ICityDeleteService, CityDeleteService>();
		services.AddScoped<ICityGetService, CityGetService>();
		services.AddScoped<ICityUpdateService, CityUpdateService>();
	}
}
