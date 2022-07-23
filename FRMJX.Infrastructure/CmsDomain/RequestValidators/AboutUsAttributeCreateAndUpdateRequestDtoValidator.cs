namespace FRMJX.Infrastructure.CmsDomain.RequestValidators;

using FluentValidation;
using FRMJX.Core.CmsDomain.Dtos.Requests;

internal class AboutUsAttributeCreateAndUpdateRequestDtoValidator : AbstractValidator<AboutUsAttributeCreateAndUpdateRequestDto>
{
	public AboutUsAttributeCreateAndUpdateRequestDtoValidator()
	{
		RuleFor(entity => entity.Title)
			.NotNull();
	}
}
