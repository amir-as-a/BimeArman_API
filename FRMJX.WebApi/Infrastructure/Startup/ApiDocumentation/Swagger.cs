namespace FRMJX.WebApi.Infrastructure.Startup.ApiDocumentation;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Linq;

internal static class Swagger
{
	internal static void ConfigureSwaggerServices(this IServiceCollection services)
	{
		services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
		services.AddSwaggerGen(setupAction =>
			{
				setupAction.OperationFilter<SwaggerDefaultValues>();

				setupAction.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
				{
					In = ParameterLocation.Header,
					Description = "Please insert JWT with Bearer into field",
					Name = "Authorization",
					Type = SecuritySchemeType.ApiKey,
				});

				setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
					{
						{
							new OpenApiSecurityScheme
							{
								Reference = new OpenApiReference
								{
									Type = ReferenceType.SecurityScheme,
									Id = "Bearer",
								},
							},
							Array.Empty<string>()
						},
					});

				setupAction.TagActionsBy(api =>
				{
					if (api.GroupName is not null)
					{
						return new[] { api.GroupName };
					}
					else if (api.ActionDescriptor is ControllerActionDescriptor controllerActionDescriptor)
					{
						return new[] { controllerActionDescriptor.ControllerName };
					}

					throw new InvalidOperationException("Unable to determine tag for endpoint.");
				});

				setupAction.DocInclusionPredicate((name, api) => api.GetApiVersion().ToString("'v'VVV") == name);

				setupAction.OrderActionsBy(sortKeySelector => $"{sortKeySelector.RelativePath}_{sortKeySelector.HttpMethod}");
			});
	}

	internal static void UseSwagger(this IApplicationBuilder app, IApiVersionDescriptionProvider apiVersionDescriptionProvider)
	{
		app.UseSwagger();
		app.UseSwaggerUI(setupAction =>
		{
			// build a swagger endpoint for each discovered API version
			foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions.OrderByDescending(current => current.GroupName))
			{
				setupAction.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
			}

			setupAction.DefaultModelsExpandDepth(-1);
		});
	}
}
