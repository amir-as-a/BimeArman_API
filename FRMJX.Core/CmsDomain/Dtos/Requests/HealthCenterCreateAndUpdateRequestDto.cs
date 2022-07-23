namespace FRMJX.Core.CmsDomain.Dtos.Requests;

public class HealthCenterCreateAndUpdateRequestDto
{
	public string Center { get; set; }

	public string CenterName { get; set; }

	public string PhoneNumber { get; set; }

	public int CityId { get; set; }

	public string ExactAddress { get; set; }

	public int Ordering { get; set; }

	public bool IsActive { get; set; }

	public int CultureLcid { get; set; }
}
