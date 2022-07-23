namespace FRMJX.WebApi.Infrastructure.Dtos;

/// <summary>
/// Token Dto
/// </summary>
public class TokensDto
{
	/// <summary>
	/// Access token
	/// </summary>
	public TokenDto AccessToken { get; set; }

	/// <summary>
	/// Refresh token
	/// </summary>
	public TokenDto RefreshToken { get; set; }
}
