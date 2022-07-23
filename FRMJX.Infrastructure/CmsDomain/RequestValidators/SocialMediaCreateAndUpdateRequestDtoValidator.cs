namespace FRMJX.Infrastructure.CmsDomain.RequestValidators;

using FluentValidation;
using FRMJX.Core.CmsDomain.Dtos.Requests;

internal class SocialMediaCreateAndUpdateRequestDtoValidator : AbstractValidator<SocialMediaCreateAndUpdateRequestDto>
{
	public SocialMediaCreateAndUpdateRequestDtoValidator()
	{
		RuleFor(entity => entity.Title)
			.NotNull();

		RuleFor(entity => entity.Url)
			.NotNull();
	}
}
