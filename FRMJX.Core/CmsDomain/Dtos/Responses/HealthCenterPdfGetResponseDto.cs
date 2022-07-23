namespace FRMJX.Core.CmsDomain.Dtos.Responses;

using FRMJX.Core.BaseDataDomain.Dtos.Responses;

public class HealthCenterPdfGetResponseDto
{
	public int Id { get; set; }

	public string Title { get; set; }

	public int CustomFileId { get; set; }

	public int StateId { get; set; }

	public int Ordering { get; set; }

	public bool IsActive { get; set; }

	public StateGetResponseDto StateGetResponseDto { get; set; }

	public CustomFileGetResponseDto CustomFileGetResponseDto { get; set; }
}
