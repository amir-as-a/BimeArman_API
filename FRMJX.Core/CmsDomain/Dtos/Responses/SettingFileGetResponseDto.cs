namespace FRMJX.Core.CmsDomain.Dtos.Responses;

public class SettingFileGetResponseDto
{
	public int Id { get; set; }

	public string Name { get; set; }

	public int Ordering { get; set; }

	public bool IsActive { get; set; }

	public CustomFileGetResponseDto CustomFileGetResponseDto { get; set; }
}
