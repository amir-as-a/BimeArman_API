namespace FRMJX.WebApi.Infrastructure.ApiSecurity.Attributes;

using FRMJX.WebApi.Infrastructure.ApiSecurity.ActionFilters;
using Microsoft.AspNetCore.Mvc;

internal class BaseApiSecurityAttribute : TypeFilterAttribute
{
	public BaseApiSecurityAttribute()
		: base(typeof(BaseApiSecurityActionFilter))
	{
	}
}
