namespace FRMJX.Infrastructure.CmsDomain.RequestValidators;

using FluentValidation;
using FRMJX.Core.CmsDomain.Dtos.Requests;

internal class SliderItemCreateAndUpdateRequestDtoValidator : AbstractValidator<SliderItemCreateAndUpdateRequestDto>
{
	public SliderItemCreateAndUpdateRequestDtoValidator()
	{
		RuleFor(entity => entity.Title)
			.NotNull();
	}
}
