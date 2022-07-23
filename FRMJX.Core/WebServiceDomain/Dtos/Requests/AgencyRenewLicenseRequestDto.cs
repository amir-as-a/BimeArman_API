namespace FRMJX.Core.WebServiceDomain.Dtos.Requests;

public class AgencyRenewLicenseRequestDto
{
	public string FirstName { get; set; }

	public string LastName { get; set; }

	public string NationalCode { get; set; }

	public string AgentCode { get; set; }

	public string PhoneNumber { get; set; }

	public int BranchId { get; set; }

	public string Description { get; set; }

	public int PersonalPictureId { get; set; }

	public int ExpiredLicensePictureId { get; set; }

	public int EzharTaxPictureId { get; set; }

	public int EzharTaxPaymentPictureId { get; set; }

	public int TaxPictureId { get; set; }

	public int TaxPaymentPictureId { get; set; }

	public int RentPictureId { get; set; }
}
