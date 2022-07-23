namespace FRMJX.WebApi.Infrastructure.Middlewares.ExceptionHandling;

using System.Text.Json;

internal class ExceptionDetailsDto
{
	public int StatusCode { get; set; }

	public string Message { get; set; }

	public override string ToString() => JsonSerializer.Serialize(this);
}
