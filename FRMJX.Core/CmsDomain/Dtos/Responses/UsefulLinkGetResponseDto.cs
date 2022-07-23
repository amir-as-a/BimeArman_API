namespace FRMJX.Core.CmsDomain.Dtos.Responses;

using FRMJX.Core.BaseDataDomain.Dtos.Responses;

public class UsefulLinkGetResponseDto
{
	public int Id { get; set; }

	public int IconId { get; set; }

	public int? FileId { get; set; }

	public string Url { get; set; }

	public CustomFileGetResponseDto IconInfo { get; set; }

	public string Title { get; set; }

	public bool IsPersonnel { get; set; }

	public bool IsRepresention { get; set; }

	public int Ordering { get; set; }

	public bool IsActive { get; set; }
}
