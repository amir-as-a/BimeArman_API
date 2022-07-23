namespace FRMJX.WebApi.Infrastructure.Dtos;

/// <summary>
/// Token dto
/// </summary>
public class TokenDto
{
	/// <summary>
	/// Token
	/// </summary>
	public string Token { get; set; }

	/// <summary>
	/// Expires in seconds
	/// </summary>
	public long ExpiresInSeconds { get; set; }
}
