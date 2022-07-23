namespace FRMJX.Core.CmsDomain.Dtos.Requests;

public class RevelationCreateAndUpdateRequestDto
{
	public string Title { get; set; }

	public int CustomeFileId { get; set; }

	public int Ordering { get; set; }

	public bool IsActive { get; set; }

	public int CultureLcid { get; set; }
}
