namespace FRMJX.WebApi.Infrastructure.ApiSecurity.Attributes;

using FRMJX.Core.SecurityDomain.Enums;
using FRMJX.WebApi.Infrastructure.ApiSecurity.Enums;
using System;

internal class ApiSecurityAttribute : Attribute
{
	public ApiSecurityAttribute(AccessLevelEnum maximumAccessLevel, params SecurityClaimEnum[] requiredClaims)
	{
		MaximumAccessLevel = maximumAccessLevel;
		RequiredClaims = requiredClaims;
	}

	public ApiSecurityAttribute(params SecurityClaimEnum[] requiredClaims)
		: this(AccessLevelEnum.Personnel, requiredClaims)
	{
	}

	public AccessLevelEnum MaximumAccessLevel { get; }

	public SecurityClaimEnum[] RequiredClaims { get; }
}
