namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class SliderItemUpdateService : ISliderItemUpdateService
{
	private readonly DatabaseContext databaseContext;

	public SliderItemUpdateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Update(
		int id,
		SliderItemCreateAndUpdateRequestDto sliderItemCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var sliderItem = await databaseContext.SliderItems
			.SingleOrDefaultAsync(current => current.Id == id);

		if (sliderItem is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound, "SliderItem not found");
			return serviceResult;
		}

		sliderItem.Title = sliderItemCreateAndUpdateDto.Title;
		sliderItem.Description = sliderItemCreateAndUpdateDto.Description;
		sliderItem.CustomFileId = sliderItemCreateAndUpdateDto.CustomFileId;
		sliderItem.Ordering = sliderItemCreateAndUpdateDto.Ordering;
		sliderItem.IsActive = sliderItemCreateAndUpdateDto.IsActive;
		sliderItem.UpdateDateTime = DateTime.Now;

		databaseContext.Update(sliderItem);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
