namespace FRMJX.Core.CmsDomain.Dtos.Responses;

using FRMJX.Core.BaseDataDomain.Dtos.Responses;

public class InsuranceInfoGetResponseDto
{
	public int Id { get; set; }

	public string Title { get; set; }

	public string Description { get; set; }

	public int InsuranceId { get; set; }

	public InsuranceGetResponseDto InsuranceDetail { get; set; }

	public int Ordering { get; set; }

	public bool IsActive { get; set; }
}
