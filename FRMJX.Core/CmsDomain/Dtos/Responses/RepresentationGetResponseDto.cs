namespace FRMJX.Core.CmsDomain.Dtos.Responses;

using FRMJX.Core.BaseDataDomain.Dtos.Responses;

public class RepresentationGetResponseDto
{
	public int Id { get; set; }

	public string BranchName { get; set; }

	public string BranchManager { get; set; }

	public string PhoneNumber { get; set; }

	public string PostalCode { get; set; }

	public string ExactAddress { get; set; }

	public int StateId { get; set; }

	public int CityId { get; set; }

	public int Ordering { get; set; }

	public bool IsActive { get; set; }

	public StateGetResponseDto StateInfo { get; set; }

	public CityGetResponseDto CityInfo { get; set; }
}
