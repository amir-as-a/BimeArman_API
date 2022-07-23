namespace FRMJX.Infrastructure.CmsDomain.RequestValidators;

using FluentValidation;
using FRMJX.Core.CmsDomain.Dtos.Requests;

internal class VideoCreateAndUpdateRequestDtoValidator : AbstractValidator<VideoCreateAndUpdateRequestDto>
{
	public VideoCreateAndUpdateRequestDtoValidator()
	{
		RuleFor(entity => entity.Title)
			.NotNull();
	}
}
