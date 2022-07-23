namespace FRMJX.Infrastructure.CmsDomain.RequestValidators;

using FluentValidation;
using FRMJX.Core.CmsDomain.Dtos.Requests;

internal class SuggustionCreateAndUpdateRequestDtoValidator : AbstractValidator<SuggustionCreateAndUpdateRequestDto>
{
	public SuggustionCreateAndUpdateRequestDtoValidator()
	{
		RuleFor(entity => entity.FullName)
			.NotNull();

		RuleFor(entity => entity.MobileNumber)
			.NotNull();

		RuleFor(entity => entity.Text)
			.NotNull();
	}
}
