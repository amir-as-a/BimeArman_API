namespace FRMJX.Core.BaseDataDomain.Dtos.Responses;

using FRMJX.Core.BaseDataDomain.Models;

public class CityGetResponseDto
{
	public int Id { get; set; }

	public string Name { get; set; }

	public string Description { get; set; }

	public StateGetResponseDto StateInfo { get; set; }
}
