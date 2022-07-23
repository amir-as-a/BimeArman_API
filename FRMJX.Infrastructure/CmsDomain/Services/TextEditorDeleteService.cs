namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class TextEditorDeleteService : ITextEditorDeleteService
{
	private readonly DatabaseContext databaseContext;

	public TextEditorDeleteService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Delete(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var textEditor = databaseContext.TextEditors
			.Where(current => current.Id == id)
			.SingleOrDefault();

		if (textEditor is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound);
			return serviceResult;
		}

		databaseContext.Remove(textEditor);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
