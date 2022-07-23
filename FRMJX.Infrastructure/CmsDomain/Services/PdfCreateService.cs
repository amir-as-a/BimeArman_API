namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Models;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

internal class PdfCreateService : IPdfCreateService
{
	private readonly DatabaseContext databaseContext;

	public PdfCreateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult<int>> Create(
		PdfCreateAndUpdateRequestDto pdfCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<int>();

		var pdf = new Pdf
		{
			CultureLcid = pdfCreateAndUpdateDto.CultureLcid,
			IsActive = pdfCreateAndUpdateDto.IsActive,
			Ordering = pdfCreateAndUpdateDto.Ordering,
			Title = pdfCreateAndUpdateDto.Title,
			Description = pdfCreateAndUpdateDto.Description,
			CustomFileId = pdfCreateAndUpdateDto.CustomFileId,
			ImageId = pdfCreateAndUpdateDto.ImageId,
			InsertDateTime = DateTime.Now,
		};

		databaseContext.Pdfs.Add(pdf);
		await databaseContext.SaveChangesAsync(cancellationToken);

		serviceResult.SetStatusCode(HttpStatusCode.Created);
		serviceResult.Result = pdf.Id;

		return serviceResult;
	}
}
