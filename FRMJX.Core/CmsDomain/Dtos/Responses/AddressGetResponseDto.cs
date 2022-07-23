namespace FRMJX.Core.CmsDomain.Dtos.Responses;

using FRMJX.Core.BaseDataDomain.Dtos.Responses;

public class AddressGetResponseDto
{
	public int Id { get; set; }

	public int StateId { get; set; }

	public int CityId { get; set; }

	public StateGetResponseDto StateInfo { get; set; }

	public CityGetResponseDto CityInfo { get; set; }

	public string ExactAddress { get; set; }

	public int Ordering { get; set; }

	public bool IsActive { get; set; }
}
