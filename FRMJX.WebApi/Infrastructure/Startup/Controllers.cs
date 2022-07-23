namespace FRMJX.WebApi.Infrastructure.Startup;

using FluentValidation.AspNetCore;
using FRMJX.Infrastructure.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;

internal static class Controllers
{
	private static readonly string FRMJSAllowSpecificOrigins = "_FRMJSAllowSpecificOrigins";

	internal static void ConfigureControllersServices(this IServiceCollection services)
	{
		services.AddCors(options => options.AddPolicy(
			name: FRMJSAllowSpecificOrigins,
			builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

		services
			.AddControllers(configure => configure.ReturnHttpNotAcceptable = true)
			.AddJsonOptions(configure => configure.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()))
			.AddFluentValidation(configure => configure.RegisterValidatorsFromAssemblyContaining<CoreAssemblyAgent>(includeInternalTypes: true))
			.ConfigureApiBehaviorOptions(setupAction => setupAction.InvalidModelStateResponseFactory = context =>
			{
				// create a problem details object
				var problemDetailsFactory = context.HttpContext.RequestServices
					.GetRequiredService<ProblemDetailsFactory>();
				var problemDetails = problemDetailsFactory.CreateValidationProblemDetails(
						context.HttpContext,
						context.ModelState);

				// add additional info not added by default
				problemDetails.Detail = "See the errors field for details.";
				problemDetails.Instance = context.HttpContext.Request.Path;

				// find out which status code to use
				var actionExecutingContext = context as Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext;

				// if there are model state errors & all keys were correctly
				// found/parsed we're dealing with validation errors
				if (context.ModelState.ErrorCount > 0 &&
				actionExecutingContext?.ActionArguments.Count == context.ActionDescriptor.Parameters.Count)
				{
					problemDetails.Type = "https://tools.ietf.org/html/rfc4918#section-11.2";
					problemDetails.Status = StatusCodes.Status422UnprocessableEntity;
					problemDetails.Title = "One or more validation errors occurred.";

					return new UnprocessableEntityObjectResult(problemDetails)
					{
						ContentTypes = { "application/problem+json" },
					};
				}

				// if one of the keys wasn't correctly found / couldn't be parsed
				// we're dealing with null/unparsable input
				problemDetails.Status = StatusCodes.Status400BadRequest;
				problemDetails.Title = "One or more errors on input occurred.";
				return new BadRequestObjectResult(problemDetails)
				{
					ContentTypes = { "application/problem+json" },
				};
			});
	}

	internal static void UseControllers(this IApplicationBuilder app) =>
		app.UseCors(FRMJSAllowSpecificOrigins);
}
