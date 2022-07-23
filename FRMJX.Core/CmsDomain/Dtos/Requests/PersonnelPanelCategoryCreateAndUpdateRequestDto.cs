namespace FRMJX.Core.CmsDomain.Dtos.Requests;

public class PersonnelPanelCategoryCreateAndUpdateRequestDto
{
	public string Title { get; set; }

	public int Ordering { get; set; }

	public bool IsActive { get; set; }

	public int CultureLcid { get; set; }
}
