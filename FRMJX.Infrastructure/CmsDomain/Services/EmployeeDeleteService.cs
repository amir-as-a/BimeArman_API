namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class EmployeeDeleteService : IEmployeeDeleteService
{
	private readonly DatabaseContext databaseContext;

	public EmployeeDeleteService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Delete(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var employee = databaseContext.Employees
			.Where(current => current.Id == id)
			.SingleOrDefault();

		if (employee is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound);
			return serviceResult;
		}

		databaseContext.Remove(employee);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
