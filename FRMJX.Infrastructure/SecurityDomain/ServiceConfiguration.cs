namespace FRMJX.Infrastructure.SecurityDomain;

using FRMJX.Infrastructure.SecurityDomain.Services;
using FRMJX.Core.SecurityDomain.Services;
using Microsoft.Extensions.DependencyInjection;
using FRMJX.Infrastructure.CmsDomain.Services;

public static class ServiceConfiguration
{
	public static void ConfigureSecurityDomainServices(this IServiceCollection services)
	{
		// User
		services.AddScoped<IUserInformationService, UserInformationService>();
		services.AddScoped<IUserDeleteService, UsereDeleteService>();
		services.AddScoped<IUserGetService, UserGetService>();
		services.AddScoped<IUserUpdateService, UserUpdateService>();
		services.AddScoped<IUserSeedService, UserSeedService>();

		// Role
		services.AddScoped<IRoleGetService, RoleGetService>();
		services.AddScoped<IRoleCreateService, RoleCreateService>();
		services.AddScoped<IRoleUpdateService, RoleUpdateService>();
		services.AddScoped<IRoleDeleteService, RoleDeleteService>();

		services.AddScoped<IMailService, MailService>();
	}
}
