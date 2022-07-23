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

internal class PdfGetService : IPdfGetService
{
	private readonly DatabaseContext databaseContext;
	private readonly ICustomFileGetService customFileGetService;

	public PdfGetService(DatabaseContext databaseContext, ICustomFileGetService customFileGetService)
	{
		this.databaseContext = databaseContext;
		this.customFileGetService = customFileGetService;
	}

	public async Task<ServiceResult<PdfGetResponseDto>> GetById(int id, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<PdfGetResponseDto>();

		var pdf = await databaseContext.Pdfs
			.Where(current => current.Id == id)
			.SingleOrDefaultAsync(cancellationToken);

		if (pdf != null)
		{
			serviceResult.Result = new PdfGetResponseDto
			{
				Id = pdf.Id,
				Ordering = pdf.Ordering,
				IsActive = pdf.IsActive,
				Title = pdf.Title,
				Description = pdf.Description,
				CustomFileGetResponseDto = customFileGetService.GetById(pdf.CustomFileId, CustomFileType.File, cancellationToken).Result.Result,
				ImageGetResponse = customFileGetService.GetById(pdf.ImageId, CustomFileType.Image, cancellationToken).Result.Result,
			};
		}

		return serviceResult;
	}

	public async Task<ServiceResult<List<PdfGetResponseDto>>> GetActives(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<PdfGetResponseDto>>();

		var pdfs = await databaseContext.Pdfs
			.Where(current => current.CultureLcid == cultureLcid)
			.Where(current => current.IsActive)
			.OrderBy(current => current.Ordering)
			.Skip(pageIndex * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);

		serviceResult.Result = pdfs
			.Select(current => new PdfGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				Title = current.Title,
				Description = current.Description,
				CustomFileGetResponseDto = customFileGetService.GetById(current.CustomFileId, CustomFileType.File, cancellationToken).Result.Result,
				ImageGetResponse = customFileGetService.GetById(current.ImageId, CustomFileType.Image, cancellationToken).Result.Result,
			})
			.ToList();

		return serviceResult;
	}

	public async Task<ServiceResult<List<PdfGetResponseDto>>> GetAll(int cultureLcid, int pageIndex, int pageSize, CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<List<PdfGetResponseDto>>();

		var pdfs = await databaseContext.Pdfs
			.Where(current => current.CultureLcid == cultureLcid)
			.OrderBy(current => current.Ordering)
			.Skip(pageIndex * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);

		serviceResult.Result = pdfs
			.Select(current => new PdfGetResponseDto
			{
				Id = current.Id,
				Ordering = current.Ordering,
				IsActive = current.IsActive,
				Title = current.Title,
				Description = current.Description,
				CustomFileGetResponseDto = customFileGetService.GetById(current.CustomFileId, CustomFileType.File, cancellationToken).Result.Result,
				ImageGetResponse = customFileGetService.GetById(current.ImageId, CustomFileType.Image, cancellationToken).Result.Result,
			})
			.ToList();

		return serviceResult;
	}
}
