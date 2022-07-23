namespace FRMJX.Infrastructure.CmsDomain.RequestValidators;

using FluentValidation;
using FRMJX.Core.CmsDomain.Dtos.Requests;

internal class InsuranceCreateAndUpdateRequestDtoValidator : AbstractValidator<InsuranceCreateAndUpdateRequestDto>
{
	public InsuranceCreateAndUpdateRequestDtoValidator()
	{
		RuleFor(entity => entity.Title)
			.NotNull();
	}
}
