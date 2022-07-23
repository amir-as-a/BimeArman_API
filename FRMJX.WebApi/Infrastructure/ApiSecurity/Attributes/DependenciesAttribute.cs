namespace FRMJX.WebApi.Infrastructure.ApiSecurity.Attributes;

using FRMJX.WebApi.Infrastructure.ApiSecurity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

[AttributeUsage(AttributeTargets.All)]
internal class DependenciesAttribute : Attribute
{
	internal DependenciesAttribute(params SecurityClaimEnum[] claims)
	{
		Claims = claims.ToList();
	}

	public List<SecurityClaimEnum> Claims { get; set; }
}
