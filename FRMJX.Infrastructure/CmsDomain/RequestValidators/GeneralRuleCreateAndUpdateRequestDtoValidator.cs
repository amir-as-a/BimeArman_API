namespace FRMJX.Infrastructure.CmsDomain.RequestValidators;

using FluentValidation;
using FRMJX.Core.CmsDomain.Dtos.Requests;

internal class GeneralRuleCreateAndUpdateRequestDtoValidator : AbstractValidator<GeneralRuleCreateAndUpdateRequestDto>
{
	public GeneralRuleCreateAndUpdateRequestDtoValidator()
	{
		RuleFor(entity => entity.Title)
			.NotNull();
	}
}
