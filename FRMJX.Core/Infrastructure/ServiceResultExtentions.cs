namespace FRMJX.Core.Infrastructure;

using System.Net;

public static class ServiceResultExtentions
{
	public static void SetStatusCode(this ServiceResult serviceResult, HttpStatusCode statusCode, string message = "")
	{
		serviceResult.HttpStatusCode = statusCode;
		serviceResult.Message = message;
	}

	public static HttpStatusCode GetStatusCode(this ServiceResult serviceResult) =>
		serviceResult.HttpStatusCode;
}
