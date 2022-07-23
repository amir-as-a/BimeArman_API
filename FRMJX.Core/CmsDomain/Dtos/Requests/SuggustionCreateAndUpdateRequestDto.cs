namespace FRMJX.Core.CmsDomain.Dtos.Requests;

public class SuggustionCreateAndUpdateRequestDto
{
	public string FullName { get; set; }

	public string MobileNumber { get; set; }

	public string Text { get; set; }

	public int Ordering { get; set; }

	public bool IsActive { get; set; }

	public int CultureLcid { get; set; }

	public int CustomFileId { get; set; }
}
