namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Models;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

internal class FaqCreateService : IFaqCreateService
{
	private readonly DatabaseContext databaseContext;

	public FaqCreateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult<int>> Create(
		FaqCreateAndUpdateRequestDto faqCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<int>();

		var faq = new Faq
		{
			CultureLcid = faqCreateAndUpdateDto.CultureLcid,
			IsActive = faqCreateAndUpdateDto.IsActive,
			Ordering = faqCreateAndUpdateDto.Ordering,
			Question = faqCreateAndUpdateDto.Question,
			Answer = faqCreateAndUpdateDto.Answer,
			InsertDateTime = DateTime.Now,
		};

		databaseContext.Faqs.Add(faq);
		await databaseContext.SaveChangesAsync(cancellationToken);

		serviceResult.SetStatusCode(HttpStatusCode.Created);
		serviceResult.Result = faq.Id;

		return serviceResult;
	}
}
