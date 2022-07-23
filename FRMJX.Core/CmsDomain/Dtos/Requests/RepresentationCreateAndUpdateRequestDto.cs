namespace FRMJX.Core.CmsDomain.Dtos.Requests;

public class RepresentationCreateAndUpdateRequestDto
{
	public string BranchName { get; set; }

	public string BranchManager { get; set; }

	public string PhoneNumber { get; set; }

	public string ExactAddress { get; set; }

	public string PostalCode { get; set; }

	public int Ordering { get; set; }

	public bool IsActive { get; set; }

	public int CultureLcid { get; set; }

	public int CityId { get; set; }

	public int StateId { get; set; }
}
