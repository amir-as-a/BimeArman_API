namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class TextEditorUpdateService : ITextEditorUpdateService
{
	private readonly DatabaseContext databaseContext;

	public TextEditorUpdateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Update(
		int id,
		TextEditorCreateAndUpdateRequestDto textEditorCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var textEditor = await databaseContext.TextEditors
			.SingleOrDefaultAsync(current => current.Id == id);

		if (textEditor is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound, "TextEditor not found");
			return serviceResult;
		}

		textEditor.PageTitle = textEditorCreateAndUpdateDto.PageTitle;
		textEditor.HtmlDocument = textEditorCreateAndUpdateDto.HtmlDocument;
		textEditor.Ordering = textEditorCreateAndUpdateDto.Ordering;
		textEditor.IsActive = textEditorCreateAndUpdateDto.IsActive;
		textEditor.UpdateDateTime = DateTime.Now;

		databaseContext.Update(textEditor);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
