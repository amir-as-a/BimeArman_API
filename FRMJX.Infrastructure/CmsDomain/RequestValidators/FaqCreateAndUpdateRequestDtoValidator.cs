namespace FRMJX.Infrastructure.CmsDomain.RequestValidators;

using FluentValidation;
using FRMJX.Core.CmsDomain.Dtos.Requests;

internal class FaqCreateAndUpdateRequestDtoValidator : AbstractValidator<FaqCreateAndUpdateRequestDto>
{
	public FaqCreateAndUpdateRequestDtoValidator()
	{
		RuleFor(entity => entity.Question)
			.NotNull();

		RuleFor(entity => entity.Answer)
			.NotNull();
	}
}
