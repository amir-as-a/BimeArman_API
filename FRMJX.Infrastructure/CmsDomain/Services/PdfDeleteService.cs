namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class PdfDeleteService : IPdfDeleteService
{
	private readonly DatabaseContext databaseContext;

	public PdfDeleteService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Delete(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var pdf = databaseContext.Pdfs
			.Where(current => current.Id == id)
			.SingleOrDefault();

		if (pdf is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound);
			return serviceResult;
		}

		databaseContext.Remove(pdf);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
