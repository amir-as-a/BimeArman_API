namespace FRMJX.Infrastructure.CmsDomain.RequestValidators;

using FluentValidation;
using FRMJX.Core.CmsDomain.Dtos.Requests;

internal class UsefulLinkCreateAndUpdateRequestDtoValidator : AbstractValidator<UsefulLinkCreateAndUpdateRequestDto>
{
	public UsefulLinkCreateAndUpdateRequestDtoValidator()
	{
		RuleFor(entity => entity.Title)
			.NotNull();
	}
}
