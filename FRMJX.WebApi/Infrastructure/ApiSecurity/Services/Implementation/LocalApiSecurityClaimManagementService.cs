namespace FRMJX.WebApi.Infrastructure.ApiSecurity.Services.Implementation;

using FRMJX.Core.Infrastructure;
using FRMJX.WebApi.Infrastructure.ApiSecurity;
using FRMJX.WebApi.Infrastructure.ApiSecurity.Enums;
using FRMJX.WebApi.Infrastructure.ApiSecurity.Services.Abstraction;
using System;
using System.Collections.Generic;

internal class LocalApiSecurityClaimManagementService : ILocalApiSecurityClaimManagementService
{
	private readonly object lockList = new();

	private IList<SecurityClaimObject> ClaimsList { get; set; }

	private IList<SecurityClaimEnum> SecurityClaims => (SecurityClaimEnum[])Enum.GetValues(typeof(SecurityClaimEnum));

	public ServiceResult<List<SecurityClaimDto>> GetSecurityClaims()
	{
		var serviceResult = new ServiceResult<List<SecurityClaimDto>>();
		if (ClaimsList is null)
		{
			lock (lockList)
			{
				if (ClaimsList is null)
				{
					var claims = new List<SecurityClaimObject>();

					foreach (var securityClaim in SecurityClaims)
					{
						claims.Add(new SecurityClaimObject(securityClaim));
					}

					ClaimsList = claims;
				}
			}
		}

		serviceResult.Result = ClaimsList
			.Select(current => new SecurityClaimDto
			{
				Value = current.Value,
				Dependencies = current.Dependencies?.Select(q => q.ToString()).ToList() ?? new(),
			})
			.ToList();

		return serviceResult;
	}
}
