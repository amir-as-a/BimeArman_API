namespace FRMJX.Core.CmsDomain.Dtos.Requests;

public class SettingFileCreateAndUpdateRequestDto
{
	public string Name { get; set; }

	public int CultureLcid { get; set; }

	public int CustomFileId { get; set; }
}
