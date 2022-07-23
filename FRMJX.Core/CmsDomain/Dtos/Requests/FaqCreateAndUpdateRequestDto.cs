namespace FRMJX.Core.CmsDomain.Dtos.Requests;

public class FaqCreateAndUpdateRequestDto
{
	public string Question { get; set; }

	public string Answer { get; set; }

	public int Ordering { get; set; }

	public bool IsActive { get; set; }

	public int CultureLcid { get; set; }
}
