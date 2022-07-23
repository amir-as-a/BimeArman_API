namespace FRMJX.Core.CmsDomain.Dtos.Requests;

public class HealthCenterPdfCreateAndUpdateRequestDto
{
	public string Title { get; set; }

	public int CustomFileId { get; set; }

	public int StateId { get; set; }

	public int Ordering { get; set; }

	public bool IsActive { get; set; }

	public int CultureLcid { get; set; }
}
