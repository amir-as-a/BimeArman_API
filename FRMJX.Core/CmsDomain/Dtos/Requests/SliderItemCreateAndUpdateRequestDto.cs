namespace FRMJX.Core.CmsDomain.Dtos.Requests;

public class SliderItemCreateAndUpdateRequestDto
{
	public string Title { get; set; }

	public string Description { get; set; }

	public int Ordering { get; set; }

	public bool? AboutUsSlider { get; set; }

	public bool IsActive { get; set; }

	public int CultureLcid { get; set; }

	public int CustomFileId { get; set; }
}
