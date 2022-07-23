namespace FRMJX.WebApi.Infrastructure.Startup;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.DependencyInjection;

internal static class ApiVersioning
{
	internal static void ConfigureApiVersioningServices(this IServiceCollection services)
	{
		services.AddApiVersioning(config =>
		{
			config.DefaultApiVersion = new ApiVersion(1, 0);
			config.ApiVersionSelector = new CurrentImplementationApiVersionSelector(config);
			config.AssumeDefaultVersionWhenUnspecified = true;
			config.ReportApiVersions = true;
		});

		services.AddVersionedApiExplorer(options =>
			// add the versioned api explorer, which also adds IApiVersionDescriptionProvider service
			// note: the specified format code will format the version as "'v'major[.minor][-status]"
			options.GroupNameFormat = "'v'VVV");
	}
}
