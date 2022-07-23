namespace FRMJX.Core.CmsDomain.Dtos.Requests;

using Microsoft.AspNetCore.Http;

public class CustomFileCreateAndUpdateRequestDto
{
	public IFormFile FormFile { get; set; }
}
