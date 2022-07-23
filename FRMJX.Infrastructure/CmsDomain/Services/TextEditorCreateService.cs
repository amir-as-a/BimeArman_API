namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Models;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

internal class TextEditorCreateService : ITextEditorCreateService
{
	private readonly DatabaseContext databaseContext;

	public TextEditorCreateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult<int>> Create(
		TextEditorCreateAndUpdateRequestDto textEditorCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<int>();

		var textEditor = new TextEditor
		{
			CultureLcid = textEditorCreateAndUpdateDto.CultureLcid,
			IsActive = textEditorCreateAndUpdateDto.IsActive,
			Ordering = textEditorCreateAndUpdateDto.Ordering,
			PageTitle = textEditorCreateAndUpdateDto.PageTitle,
			HtmlDocument = textEditorCreateAndUpdateDto.HtmlDocument,
			InsertDateTime = DateTime.Now,
		};

		databaseContext.TextEditors.Add(textEditor);
		await databaseContext.SaveChangesAsync(cancellationToken);

		serviceResult.SetStatusCode(HttpStatusCode.Created);
		serviceResult.Result = textEditor.Id;

		return serviceResult;
	}
}
