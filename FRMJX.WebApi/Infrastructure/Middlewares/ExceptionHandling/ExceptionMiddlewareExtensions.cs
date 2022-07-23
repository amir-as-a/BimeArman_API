namespace FRMJX.WebApi.Infrastructure.Middlewares.ExceptionHandling;

using FRMJX.Infrastructure.Infrastructure.Logging.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;

internal static class ExceptionMiddlewareExtensions
{
	public static void UseExceptionHandler(this IApplicationBuilder app, ILoggerFactory loggerFactory)
	{
		var logger = loggerFactory.CreateLogger("ExceptionMiddleware");

		app.UseExceptionHandler(config => config.Run(async context =>
		{
			context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
			context.Response.ContentType = "application/json";

			var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

			if (contextFeature is not null)
			{
				logger.LogError(LogEvent.ExceptionMiddlewareEvent, contextFeature.Error, $"Internal Server Error");

				var result = JsonSerializer.Serialize(new ExceptionDetailsDto()
				{
					StatusCode = context.Response.StatusCode,
					Message = "An unhandled exception occurred (internal server error). please contact the administrator.",
				},
				new JsonSerializerOptions()
				{
					PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
				});

				await context.Response.WriteAsync(result);
			}
		}));
	}
}
