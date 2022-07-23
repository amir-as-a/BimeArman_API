namespace FRMJX.Core.CmsDomain.Dtos.Requests;

public class UsefulLinkCreateAndUpdateRequestDto
{
	public string Title { get; set; }

	public string Url { get; set; }

	public bool IsPersonnel { get; set; }

	public bool IsRepresention { get; set; }

	public int Ordering { get; set; }

	public bool IsActive { get; set; }

	public int CultureLcid { get; set; }

	public int IconId { get; set; }

	public int? FileId { get; set; }
}
