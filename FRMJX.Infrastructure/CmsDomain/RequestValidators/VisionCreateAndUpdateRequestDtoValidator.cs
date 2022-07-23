namespace FRMJX.Infrastructure.CmsDomain.RequestValidators;

using FluentValidation;
using FRMJX.Core.CmsDomain.Dtos.Requests;

internal class VisionCreateAndUpdateRequestDtoValidator : AbstractValidator<VisionCreateAndUpdateRequestDto>
{
	public VisionCreateAndUpdateRequestDtoValidator()
	{
		RuleFor(entity => entity.Title)
			.NotNull();
	}
}
