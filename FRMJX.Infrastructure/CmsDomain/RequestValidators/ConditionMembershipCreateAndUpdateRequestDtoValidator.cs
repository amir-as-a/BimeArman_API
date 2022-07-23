namespace FRMJX.Infrastructure.CmsDomain.RequestValidators;

using FluentValidation;
using FRMJX.Core.CmsDomain.Dtos.Requests;

internal class ConditionMembershipCreateAndUpdateRequestDtoValidator : AbstractValidator<ConditionMembershipCreateAndUpdateRequestDto>
{
	public ConditionMembershipCreateAndUpdateRequestDtoValidator()
	{
		RuleFor(entity => entity.Title)
			.NotNull();
	}
}
