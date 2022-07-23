namespace FRMJX.Core.Infrastructure;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

public class ServiceResult : IActionResult
{
	public ServiceResult()
	{
		HttpStatusCode = HttpStatusCode.OK;
		Message = string.Empty;
	}

	public ServiceResultStatusEnum Status => (int)HttpStatusCode switch
	{
		>= 100 and < 200 => ServiceResultStatusEnum.Information,
		>= 200 and < 299 => ServiceResultStatusEnum.Success,
		>= 300 and < 399 => ServiceResultStatusEnum.Redirection,
		>= 400 and < 499 => ServiceResultStatusEnum.ClientError,
		>= 500 and < 599 => ServiceResultStatusEnum.ServerError,
		_ => ServiceResultStatusEnum.Unofficial,
	};

	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
	public string Message { get; set; }

	internal HttpStatusCode HttpStatusCode { get; set; }

	public async Task ExecuteResultAsync(ActionContext context)
	{
		var objectResult = new ObjectResult(context)
		{
			StatusCode = StatusCodes.Status200OK,
		};

		await objectResult.ExecuteResultAsync(context);
	}
}
