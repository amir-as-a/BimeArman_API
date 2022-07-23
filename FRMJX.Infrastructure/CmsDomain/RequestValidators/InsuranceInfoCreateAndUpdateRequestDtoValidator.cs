namespace FRMJX.Infrastructure.CmsDomain.RequestValidators;

using FluentValidation;
using FRMJX.Core.CmsDomain.Dtos.Requests;

internal class InsuranceInfoCreateAndUpdateRequestDtoValidator : AbstractValidator<InsuranceInfoCreateAndUpdateRequestDto>
{
	public InsuranceInfoCreateAndUpdateRequestDtoValidator()
	{
		RuleFor(entity => entity.Title)
			.NotNull();
	}
}
