namespace FRMJX.Infrastructure.WebServiceDomain.RequestValidators;

using FluentValidation;
using FRMJX.Core.WebServiceDomain.Dtos.Requests;

internal class AgencyRequestDtoValidator : AbstractValidator<AgencyRequestDto>
{
	public AgencyRequestDtoValidator()
	{
		RuleFor(entity => entity.FirstName)
			.NotNull();

		RuleFor(entity => entity.LastName)
			.NotNull();

		RuleFor(entity => entity.FatherName)
			.NotNull();

		RuleFor(entity => entity.NationalCode)
			.NotNull();

		RuleFor(entity => entity.PhoneNumber)
			.NotNull();

		RuleFor(entity => entity.EducationField)
			.NotNull();

		RuleFor(entity => entity.City)
			.NotNull();

		RuleFor(entity => entity.Description)
			.NotNull();
	}
}
