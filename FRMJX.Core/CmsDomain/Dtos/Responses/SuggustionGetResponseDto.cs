namespace FRMJX.Core.CmsDomain.Dtos.Responses;

public class SuggustionGetResponseDto
{
	public int Id { get; set; }

	public string FullName { get; set; }

	public string MobileNumber { get; set; }

	public string Text { get; set; }

	public string Author { get; set; }

	public int Ordering { get; set; }

	public bool IsActive { get; set; }
}
