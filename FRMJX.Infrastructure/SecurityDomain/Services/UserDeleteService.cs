namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.Infrastructure;
using FRMJX.Core.SecurityDomain.Services;
using FRMJX.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class UsereDeleteService : IUserDeleteService
{
	private readonly DatabaseContext databaseContext;

	public UsereDeleteService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Delete(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var user = databaseContext.Users
			.Where(current => current.Id == id)
			.SingleOrDefault();

		if (user is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound);
			return serviceResult;
		}

		user.IsDeleted = true;

		databaseContext.Update(user);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
