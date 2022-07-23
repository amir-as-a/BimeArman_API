namespace FRMJX.WebApi.Infrastructure.Dtos;

/// <summary>
/// Refresh token dto
/// </summary>
public class RefreshTokenDto
{
	/// <summary>
	/// Access Token
	/// </summary>
	public string AccessToken { get; set; }

	/// <summary>
	/// Refresh Token
	/// </summary>
	public string RefreshToken { get; set; }
}
