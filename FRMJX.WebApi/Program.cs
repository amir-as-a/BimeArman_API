using FRMJX.Core.SecurityDomain.Models;
using FRMJX.Infrastructure;
using FRMJX.WebApi.Infrastructure.Helpers;
using FRMJX.WebApi.Infrastructure.Middlewares.ExceptionHandling;
using FRMJX.WebApi.Infrastructure.Services;
using FRMJX.WebApi.Infrastructure.Startup;
using FRMJX.WebApi.Infrastructure.Startup.ApiDocumentation;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.ConfigureHealthCheckServices();

builder.Services.ConfigureControllersServices();

builder.Services.ConfigureInfrastructureServices(builder.Configuration);

builder.Services.ConfigureSwaggerServices();

builder.Services.ConfigureHelperIoCServices(builder.Configuration);

builder.Services.ConfigureLocalServiceIoCServices();

builder.Services.ConfigureApiVersioningServices();

builder.Services.ConfigureXAuthenticationServices(builder.Configuration);

var app = builder.Build();

app.UseCors();

Configure(app);

void Configure(WebApplication app)
{
	var loggerFactory = app.Services.GetRequiredService<ILoggerFactory>();
	var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

	// Configure the HTTP request pipeline.
	if (app.Environment.IsDevelopment())
	{
		app.UseSwagger(apiVersionDescriptionProvider);
	}
	else
	{
		app.UseSwagger(apiVersionDescriptionProvider);
		using (var scope = app.Services.CreateScope())
		{
			var databaseContext = app.Services.GetRequiredService<DatabaseContext>();
			databaseContext.Database.Migrate();
		}
	}

	app.UseControllers();

	app.UseExceptionHandler(loggerFactory);

	app.UseHttpsRedirection();

	app.UseStaticFiles();

	app.UseAuthorization();

	app.UseRouting();

	app.UseXAuthentication();

	app.ConfigureHealthCheck();
}

app.Run();
