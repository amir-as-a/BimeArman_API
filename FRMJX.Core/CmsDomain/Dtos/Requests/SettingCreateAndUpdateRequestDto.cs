namespace FRMJX.Core.CmsDomain.Dtos.Requests;
public class SettingCreateAndUpdateRequestDto
{
	public string Name { get; set; }

	public string Value { get; set; }

	public int CultureLcid { get; set; }
}
