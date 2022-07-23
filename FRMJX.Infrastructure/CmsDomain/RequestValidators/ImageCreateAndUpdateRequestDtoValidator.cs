namespace FRMJX.Infrastructure.CmsDomain.RequestValidators;

using FluentValidation;
using FRMJX.Core.CmsDomain.Dtos.Requests;

internal class ImageCreateAndUpdateRequestDtoValidator : AbstractValidator<ImageCreateAndUpdateRequestDto>
{
	public ImageCreateAndUpdateRequestDtoValidator()
	{
		RuleFor(entity => entity.Title)
			.NotNull();
	}
}
