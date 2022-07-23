namespace FRMJX.Core.CmsDomain.Dtos.Requests;

public class ConditionMembershipCreateAndUpdateRequestDto
{
	public string Title { get; set; }

	public int Ordering { get; set; }

	public bool IsActive { get; set; }

	public int CultureLcid { get; set; }

	public int CustomFileId { get; set; }
}
