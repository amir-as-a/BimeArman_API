namespace FRMJX.Infrastructure.WebServiceDomain.RequestValidators;

using FluentValidation;
using FRMJX.Core.WebServiceDomain.Dtos.Requests;

internal class JoinusRequestDtoValidator : AbstractValidator<JoinusRequestDto>
{
	public JoinusRequestDtoValidator()
	{
		RuleFor(entity => entity.FirstName)
			.NotNull();

		RuleFor(entity => entity.LastName)
			.NotNull();

		RuleFor(entity => entity.BirthDate)
			.NotNull();

		RuleFor(entity => entity.PhoneNumber)
			.NotNull();

		RuleFor(entity => entity.EmailAdsress)
			.NotNull();
	}
}
