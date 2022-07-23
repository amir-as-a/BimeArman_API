namespace FRMJX.Infrastructure.CmsDomain.RequestValidators;

using FluentValidation;
using FRMJX.Core.CmsDomain.Dtos.Requests;

internal class BlogCommentCreateAndUpdateRequestDtoValidator : AbstractValidator<BlogCommentCreateAndUpdateRequestDto>
{
	public BlogCommentCreateAndUpdateRequestDtoValidator()
	{
		RuleFor(entity => entity.FirstName)
			.NotNull();

		RuleFor(entity => entity.LastName)
			.NotNull();

		RuleFor(entity => entity.Comment)
		.NotNull();
	}
}
