namespace FRMJX.Infrastructure.CmsDomain.RequestValidators;

using FluentValidation;
using FRMJX.Core.CmsDomain.Dtos.Requests;

internal class SaleRuleCreateAndUpdateRequestDtoValidator : AbstractValidator<SaleRuleCreateAndUpdateRequestDto>
{
	public SaleRuleCreateAndUpdateRequestDtoValidator()
	{
		RuleFor(entity => entity.Title)
			.NotNull();
	}
}
