namespace FRMJX.WebApi.Infrastructure.Helpers;

/// <summary>
/// Jason web token (JWT) settings
/// </summary>
public class JwtSettings
{
	/// <summary>
	/// Issuer url
	/// </summary>
	public string Issuer { get; set; }

	/// <summary>
	/// Audience url
	/// </summary>
	public string Audience { get; set; }

	/// <summary>
	/// Secret key
	/// </summary>
	public string SecretKey { get; set; }

	/// <summary>
	/// Secret
	/// </summary>
	public string EncryptionKey { get; set; }

	/// <summary>
	/// Auth provider
	/// </summary>
	public string LoginProvider { get; set; }

	/// <summary>
	/// Access token expiration in seconds
	/// </summary>
	public long AccessTokenExpirationInSeconds { get; set; }

	/// <summary>
	/// Refresh token expiration in seconds
	/// </summary>
	public long RefreshTokenExpirationInSeconds { get; set; }

	/// <summary>
	/// Refresh token title
	/// </summary>
	public string RefreshTokenTitle { get; set; }
}
