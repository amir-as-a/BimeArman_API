namespace FRMJX.Core.CmsDomain.Dtos.Requests;

public class RevelationAttributeCreateAndUpdateRequestDto
{
	public string Title { get; set; }

	public int RevelationId { get; set; }

	public int CustomFileId { get; set; }

	public int Ordering { get; set; }

	public bool IsActive { get; set; }

	public int CultureLcid { get; set; }
}
