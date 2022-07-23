namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class FaqUpdateService : IFaqUpdateService
{
	private readonly DatabaseContext databaseContext;

	public FaqUpdateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Update(
		int id,
		FaqCreateAndUpdateRequestDto faqCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var faq = await databaseContext.Faqs
			.SingleOrDefaultAsync(current => current.Id == id);

		if (faq is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound, "Faq not found");
			return serviceResult;
		}

		faq.Question = faqCreateAndUpdateDto.Question;
		faq.Answer = faqCreateAndUpdateDto.Answer;
		faq.Ordering = faqCreateAndUpdateDto.Ordering;
		faq.IsActive = faqCreateAndUpdateDto.IsActive;
		faq.UpdateDateTime = DateTime.Now;

		databaseContext.Update(faq);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
