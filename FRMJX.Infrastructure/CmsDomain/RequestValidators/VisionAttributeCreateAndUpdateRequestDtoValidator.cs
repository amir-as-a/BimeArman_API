namespace FRMJX.Infrastructure.CmsDomain.RequestValidators;

using FluentValidation;
using FRMJX.Core.CmsDomain.Dtos.Requests;

internal class VisionAttributeCreateAndUpdateRequestDtoValidator : AbstractValidator<VisionAttributeCreateAndUpdateRequestDto>
{
	public VisionAttributeCreateAndUpdateRequestDtoValidator()
	{
		RuleFor(entity => entity.Title)
			.NotNull();
	}
}
