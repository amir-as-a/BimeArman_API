namespace FRMJX.WebApi.Infrastructure.Attributes.ResponseHandling;

using FRMJX.Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

internal class XApiResponseAttribute : ActionFilterAttribute
{
	public override void OnResultExecuting(ResultExecutingContext context)
	{
		if (context.Result is ServiceResult serviceResult)
		{
			context.Result = new JsonResult(serviceResult) { StatusCode = (int)serviceResult.GetStatusCode() };
		}
	}
}
