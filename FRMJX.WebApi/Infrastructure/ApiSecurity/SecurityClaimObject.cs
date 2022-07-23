namespace FRMJX.WebApi.Infrastructure.ApiSecurity;

using FRMJX.Core.Infrastructure.Framework.Extentions;
using FRMJX.WebApi.Infrastructure.ApiSecurity.Attributes;
using FRMJX.WebApi.Infrastructure.ApiSecurity.Enums;
using System.Collections.Generic;

internal class SecurityClaimObject
{
	public SecurityClaimObject(SecurityClaimEnum securityClaim)
	{
		SecurityClaim = securityClaim;
	}

	public SecurityClaimEnum SecurityClaim { get; set; }

	public string Value => SecurityClaim.ToString();

	public string Type => SecurityClaim.GetAttributeFromEnumType<TypeAttribute>().Type.ToString();

	public List<SecurityClaimEnum> Dependencies => SecurityClaim.GetAttribute<DependenciesAttribute>()?.Claims;
}
