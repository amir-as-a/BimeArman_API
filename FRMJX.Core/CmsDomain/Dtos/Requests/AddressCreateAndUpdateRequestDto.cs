namespace FRMJX.Core.CmsDomain.Dtos.Requests;

public class AddressCreateAndUpdateRequestDto
{
	public string ExactAddress { get; set; }

	public int Ordering { get; set; }

	public bool IsActive { get; set; }

	public int CultureLcid { get; set; }

	public int CityId { get; set; }

	public int StateId { get; set; }
}
