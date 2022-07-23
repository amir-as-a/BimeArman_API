namespace FRMJX.Infrastructure.CmsDomain.RequestValidators;

using FluentValidation;
using FRMJX.Core.CmsDomain.Dtos.Requests;

internal class GeneralConditionCreateAndUpdateRequestDtoValidator : AbstractValidator<GeneralConditionCreateAndUpdateRequestDto>
{
	public GeneralConditionCreateAndUpdateRequestDtoValidator()
	{
		RuleFor(entity => entity.Title)
			.NotNull();
	}
}
