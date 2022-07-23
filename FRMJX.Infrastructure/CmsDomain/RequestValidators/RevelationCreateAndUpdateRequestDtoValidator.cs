namespace FRMJX.Infrastructure.CmsDomain.RequestValidators;

using FluentValidation;
using FRMJX.Core.CmsDomain.Dtos.Requests;

internal class RevelationCreateAndUpdateRequestDtoValidator : AbstractValidator<RevelationCreateAndUpdateRequestDto>
{
	public RevelationCreateAndUpdateRequestDtoValidator()
	{
		RuleFor(entity => entity.Title)
			.NotNull();

		RuleFor(x => x.CustomeFileId)
			.NotNull();
	}
}
