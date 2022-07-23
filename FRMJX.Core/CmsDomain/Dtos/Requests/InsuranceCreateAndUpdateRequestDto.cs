namespace FRMJX.Core.CmsDomain.Dtos.Requests;

public class InsuranceCreateAndUpdateRequestDto
{
	public string Title { get; set; }

	public string Description { get; set; }

	public int Ordering { get; set; }

	public bool IsActive { get; set; }

	public int CultureLcid { get; set; }

	public int? ImageId { get; set; }

	public int IconId { get; set; }
}
