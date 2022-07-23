namespace FRMJX.Core.CmsDomain.Dtos.Responses;

public class InsuranceGetResponseDto
{
	public int Id { get; set; }

	public string Title { get; set; }

	public string Description { get; set; }

	public int Ordering { get; set; }

	public bool IsActive { get; set; }

	public CustomFileGetResponseDto ImageInfo { get; set; }

	public CustomFileGetResponseDto IconInfo { get; set; }
}
