namespace FRMJX.Core.CmsDomain.Dtos.Responses;

public class FaqGetResponseDto
{
	public int Id { get; set; }

	public string Question { get; set; }

	public string Answer { get; set; }

	public int Ordering { get; set; }

	public bool IsActive { get; set; }
}
