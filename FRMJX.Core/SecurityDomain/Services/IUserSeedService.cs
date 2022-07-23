namespace FRMJX.Core.SecurityDomain.Services
{
	using FRMJX.Core.Infrastructure;
	using System.Threading.Tasks;

	public interface IUserSeedService
	{
		Task<ServiceResult> Initialize();
	}
}
