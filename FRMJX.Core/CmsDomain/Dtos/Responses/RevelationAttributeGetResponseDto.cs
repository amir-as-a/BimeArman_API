namespace FRMJX.Core.CmsDomain.Dtos.Responses;

public class RevelationAttributeGetResponseDto
{
	public int Id { get; set; }

	public string Title { get; set; }

	public int CustomFileId { get; set; }

	public int Ordering { get; set; }

	public bool IsActive { get; set; }

	public RevelationGetResponseDto RevelationGetResponseDto { get; set; }

	public CustomFileGetResponseDto CustomFileGetResponse { get; set; }
}
