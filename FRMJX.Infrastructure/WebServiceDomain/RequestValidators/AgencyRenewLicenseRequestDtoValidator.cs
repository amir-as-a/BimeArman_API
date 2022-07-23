namespace FRMJX.Infrastructure.WebServiceDomain.RequestValidators;

using FluentValidation;
using FRMJX.Core.WebServiceDomain.Dtos.Requests;

internal class AgencyRenewLicenseRequestDtoValidator : AbstractValidator<AgencyRenewLicenseRequestDto>
{
	public AgencyRenewLicenseRequestDtoValidator()
	{
		RuleFor(entity => entity.FirstName)
			.NotNull();

		RuleFor(entity => entity.LastName)
			.NotNull();

		RuleFor(entity => entity.AgentCode)
			.NotNull();

		RuleFor(entity => entity.NationalCode)
			.NotNull();

		RuleFor(entity => entity.PhoneNumber)
			.NotNull();

		RuleFor(entity => entity.Description)
			.NotNull();
	}
}
