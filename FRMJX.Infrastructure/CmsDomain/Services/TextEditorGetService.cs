namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Responses;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Core.Infrastructure.Enums;
using FRMJX.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

internal class TextEditorGetService : ITextEditorGetService
{
	private readonly DatabaseContext databaseContext;
	private readonly ICustomFileGetService customFileGetService;

	public TextEditorGetService(DatabaseContext databaseContext, ICustomFileGetService customFileGetService)
	{
		this.databaseContext = databaseContext;
		this.customFileGetService = customFileGetService;
	}

	public async Task<ServiceResult<TextEditorGetResponseDto>> GetById(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<TextEditorGetResponseDto>();

		var textEditor = await databaseContext.TextEditors
			.Where(current => current.Id == id)
			.SingleOrDefaultAsync(cancellationToken);

		if (textEditor != null)
		{
			serviceResult.Result = new TextEditorGetResponseDto
			{
				Id = textEditor.Id,
				Ordering = textEditor.Ordering,
				IsActive = textEditor.IsActive,
				PageTitle = textEditor.PageTitle,
				HtmlDocument = textEditor.HtmlDocument,
			};
		}

		return serviceResult;
	}

	public async Task<ServiceResult<List<TextEditorGetResponseDto>>> GetByPageTitle(string pageTitle, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<TextEditorGetResponseDto>>();

		var textEditors = await databaseContext.TextEditors
			.Where(current => pageTitle == current.PageTitle)
			.OrderBy(current => current.Ordering)
			.ToListAsync(cancellationToken);

		serviceResult.Result = textEditors
			.Select(current => new TextEditorGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				PageTitle = current.PageTitle,
				HtmlDocument = current.HtmlDocument,
			})
			.ToList();

		return serviceResult;
	}

	public async Task<ServiceResult<List<TextEditorGetResponseDto>>> GetActives(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<TextEditorGetResponseDto>>();

		var textEditors = await databaseContext.TextEditors
			.Where(current => current.CultureLcid == cultureLcid)
			.Where(current => current.IsActive)
			.OrderBy(current => current.Ordering)
			.Skip(pageIndex * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);

		serviceResult.Result = textEditors
			.Select(current => new TextEditorGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				PageTitle = current.PageTitle,
				HtmlDocument = current.HtmlDocument,
			})
			.ToList();

		return serviceResult;
	}

	public async Task<ServiceResult<List<TextEditorGetResponseDto>>> GetAll(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<TextEditorGetResponseDto>>();

		var textEditors = await databaseContext.TextEditors
			.Where(current => current.CultureLcid == cultureLcid)
			.OrderBy(current => current.Ordering)
			.Skip(pageIndex * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);

		serviceResult.Result = textEditors
			.Select(current => new TextEditorGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				PageTitle = current.PageTitle,
				HtmlDocument = current.HtmlDocument,
			})
			.ToList();

		return serviceResult;
	}
}
