namespace FRMJX.Infrastructure.CmsDomain.RequestValidators;

using FluentValidation;
using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Infrastructure.Infrastructure;

internal class BlogTypeCreateAndUpdateRequestDtoValidator : AbstractValidator<BlogTypeCreateAndUpdateRequestDto>
{
	public BlogTypeCreateAndUpdateRequestDtoValidator()
	{
		RuleFor(entity => entity.Name)
			.NotNull()
			.MaximumLength(ModelSettings.NameMaxLength);
	}
}
