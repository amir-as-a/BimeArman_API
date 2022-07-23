namespace FRMJX.Core.CmsDomain.Dtos.Responses;

using FRMJX.Core.BaseDataDomain.Dtos.Responses;

public class HealthCenterGetResponseDto
{
	public int Id { get; set; }

	public string Center { get; set; }

	public string CenterName { get; set; }

	public string PhoneNumber { get; set; }

	public string ExactAddress { get; set; }

	public int CityId { get; set; }

	public int Ordering { get; set; }

	public bool IsActive { get; set; }

	public CityGetResponseDto CityGetResponseDto { get; set; }
}
