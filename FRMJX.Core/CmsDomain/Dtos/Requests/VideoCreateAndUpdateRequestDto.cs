namespace FRMJX.Core.CmsDomain.Dtos.Requests;

public class VideoCreateAndUpdateRequestDto
{
	public string Title { get; set; }

	public string Description { get; set; }

	public int Ordering { get; set; }

	public bool IsActive { get; set; }

	public int CultureLcid { get; set; }

	public int CustomFileId { get; set; }
}
