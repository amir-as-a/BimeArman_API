namespace FRMJX.Core.CmsDomain.Dtos.Responses;

public class RevelationGetResponseDto
{
	public int Id { get; set; }

	public string Title { get; set; }

	public int CustomeFileId { get; set; }

	public CustomFileGetResponseDto CustomFileGetResponseDto { get; set; }

	public int Ordering { get; set; }

	public bool IsActive { get; set; }
}
