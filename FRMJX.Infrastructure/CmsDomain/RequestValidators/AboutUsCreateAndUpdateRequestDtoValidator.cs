namespace FRMJX.Infrastructure.CmsDomain.RequestValidators;

using FluentValidation;
using FRMJX.Core.CmsDomain.Dtos.Requests;

internal class AboutUsCreateAndUpdateRequestDtoValidator : AbstractValidator<AboutUsCreateAndUpdateRequestDto>
{
	public AboutUsCreateAndUpdateRequestDtoValidator()
	{
		RuleFor(entity => entity.Title)
			.NotNull();
	}
}
