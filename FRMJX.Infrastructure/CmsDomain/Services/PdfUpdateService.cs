namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class PdfUpdateService : IPdfUpdateService
{
	private readonly DatabaseContext databaseContext;

	public PdfUpdateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Update(
		int id,
		PdfCreateAndUpdateRequestDto pdfCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var pdf = await databaseContext.Pdfs
			.SingleOrDefaultAsync(current => current.Id == id);

		if (pdf is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound, "Pdf not found");
			return serviceResult;
		}

		pdf.Title = pdfCreateAndUpdateDto.Title;
		pdf.Description = pdfCreateAndUpdateDto.Description;
		pdf.CustomFileId = pdfCreateAndUpdateDto.CustomFileId;
		pdf.Ordering = pdfCreateAndUpdateDto.Ordering;
		pdf.IsActive = pdfCreateAndUpdateDto.IsActive;
		pdf.ImageId = pdfCreateAndUpdateDto.ImageId;
		pdf.UpdateDateTime = DateTime.Now;

		databaseContext.Update(pdf);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
