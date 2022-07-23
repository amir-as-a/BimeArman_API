namespace FRMJX.Infrastructure.SecurityDomain.Services;

using FRMJX.Core.Infrastructure;
using FRMJX.Core.Infrastructure.Framework.Dtos.Grid;
using FRMJX.Core.SecurityDomain.Dtos.Responses;
using FRMJX.Core.SecurityDomain.Enums;
using FRMJX.Core.SecurityDomain.Models;
using FRMJX.Core.SecurityDomain.Services;
using FRMJX.Infrastructure.Infrastructure.SharedServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

internal class RoleGetService : IRoleGetService
{
	private readonly RoleManager<Role> roleManager;
	private readonly UserManager<User> userManager;
	private readonly IGridService<Role, RoleGetWithPagingResponseDto> gridService;

	public RoleGetService(RoleManager<Role> roleManager, UserManager<User> userManager, IGridService<Role, RoleGetWithPagingResponseDto> gridService)
	{
		this.roleManager = roleManager;
		this.userManager = userManager;
		this.gridService = gridService;
	}

	public async Task<ServiceResult<GridResultDto<RoleGetWithPagingResponseDto>>> Get(int applicantUserId, GridFilterDto gridFilterDto, CancellationToken cancellationToken)
	{
		var validRoleIds = await GetValidRoles(applicantUserId, cancellationToken);

		var query = roleManager.Roles
			.Where(current => validRoleIds.Result.Contains(current.Id));

		var result = await gridService.ApplyGridFilterAsync(query, gridFilterDto, cancellationToken);

		var gridResult = new GridResultDto<RoleGetWithPagingResponseDto>
		{
			TotalCount = result.TotalCount,
			Records = result.Records.Select(current => new RoleGetWithPagingResponseDto()
			{
				Id = current.Id,
				Name = current.Name,
				Description = current.Description,
			})
			.ToList(),
		};

		var serviceResult = new ServiceResult<GridResultDto<RoleGetWithPagingResponseDto>>
		{
			Result = gridResult,
		};

		return serviceResult;
	}

	public async Task<ServiceResult<List<RoleGetResponseDto>>> GetAll(int applicantUserId, CancellationToken cancellationToken)
	{
		var validRoleIds = await GetValidRoles(applicantUserId, cancellationToken);

		var roles = await roleManager.Roles
			.Where(current => validRoleIds.Result.Contains(current.Id))
			.ToListAsync(cancellationToken);

		var serviceResult = new ServiceResult<List<RoleGetResponseDto>>
		{
			Result = roles
				.Select(current => new RoleGetResponseDto
				{
					Id = current.Id,
					Name = current.Name,
					Description = current.Description,
				})
				.ToList(),
		};

		return serviceResult;
	}

	public async Task<ServiceResult<RoleGetDetailResponseDto>> GetById(int applicantUserId, int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<RoleGetDetailResponseDto>();

		var role = await roleManager.FindByIdAsync(id.ToString());
		if (role is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound);

			return serviceResult;
		}

		var validRoles = await GetValidRoles(applicantUserId, cancellationToken);
		if (validRoles.Result.Contains(id) is false)
		{
			serviceResult.SetStatusCode(HttpStatusCode.BadRequest, "You do not have access this to this role");

			return serviceResult;
		}

		var roleClaims = await roleManager.GetClaimsAsync(role);

		serviceResult.Result = new RoleGetDetailResponseDto
		{
			Id = role.Id,
			Name = role.Name,
			Description = role.Description,
			SecurityClaims = roleClaims
				.Where(current => current.Type == nameof(ClaimTypeEnum.Security))
				.Select(current => current.Value)
				.ToList(),
		};

		return serviceResult;
	}

	public async Task<ServiceResult<List<int>>> GetValidRoles(int applicantUserId, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<int>>();
		var applicantUser = await userManager.FindByIdAsync(applicantUserId.ToString());

		var roles = roleManager.Roles
			.Include(current => current.UserRoles)
			.AsQueryable();

		if (applicantUser.IsAppResponsible is false)
		{
			roles = roles
				.Where(current => current.UserRoles.Any(current => current.UserId == applicantUserId));
		}

		serviceResult.Result = await roles
			.Select(current => current.Id)
			.ToListAsync(cancellationToken);

		return serviceResult;
	}
}
