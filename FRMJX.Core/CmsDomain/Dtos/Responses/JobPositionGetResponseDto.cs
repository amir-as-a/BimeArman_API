namespace FRMJX.Core.CmsDomain.Dtos.Responses;

public class JobPositionGetResponseDto
{
	public int Id { get; set; }

	public string Category { get; set; }

	public string Title { get; set; }

	public int Ordering { get; set; }

	public bool IsActive { get; set; }
}
