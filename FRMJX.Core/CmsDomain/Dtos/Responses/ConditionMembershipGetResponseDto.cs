namespace FRMJX.Core.CmsDomain.Dtos.Responses;

public class ConditionMembershipGetResponseDto
{
	public int Id { get; set; }

	public string Title { get; set; }

	public int Ordering { get; set; }

	public bool IsActive { get; set; }

	public CustomFileGetResponseDto CustomFileGetResponseDto { get; set; }
}
