namespace FRMJX.Infrastructure.CmsDomain.RequestValidators;

using FluentValidation;
using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Infrastructure.Infrastructure;

internal class BlogPostCreateAndUpdateRequestDtoValidator : AbstractValidator<BlogPostCreateAndUpdateRequestDto>
{
	public BlogPostCreateAndUpdateRequestDtoValidator()
	{
		RuleFor(entity => entity.Title)
			.NotNull();

		RuleFor(entity => entity.Body)
			.NotNull();
	}
}
