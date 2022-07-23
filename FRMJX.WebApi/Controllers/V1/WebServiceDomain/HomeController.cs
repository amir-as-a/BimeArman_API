namespace FRMJX.WebApi.Controllers.V1.WebServiceDomain;

using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure.Enums;
using FRMJX.Core.SecurityDomain.Models;
using FRMJX.Core.SecurityDomain.Services;
using FRMJX.Core.WebServiceDomain.Dtos.Requests;
using FRMJX.WebApi.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

/// <summary>
/// Hhome controller
/// </summary>
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/webservice/home")]
[ApiExplorerSettings(GroupName = "WebService - Home")]
public class HomeController : BaseController
{
	/*public static YourClass LoadFromXMLString(string xmlText)
	{
		using (var stringReader = new System.IO.StringReader(xmlText))
		{
			var serializer = new XmlSerializer(typeof(YourClass));
			return serializer.Deserialize(stringReader) as YourClass;
		}
	}*/

	/// <summary>
	/// Agency post
	/// </summary>
	/// <param name="mailService">mail Service</param>
	/// <param name="settingGetService">setting get Service</param>
	/// <param name="cultureLcid">cultureLcid</param>
	/// <param name="agencyRequestDto">agency request dto</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>mail agency request</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpPost("agency")]
	[AllowAnonymous]
	public async Task<IActionResult> Agency(
		[FromServices] IMailService mailService,
		[FromServices] ISettingGetService settingGetService,
		[FromHeader] int cultureLcid,
		AgencyRequestDto agencyRequestDto,
		CancellationToken cancellationToken)
	{
		string emailReciever = "FaramoujDevTeam@gmail.com";
		var emailRecieverSetting = await settingGetService.GetByName(cultureLcid, "webservice.emailreciever", cancellationToken);
		if (emailRecieverSetting.Result != null)
		{
			emailReciever = emailRecieverSetting.Result.Value;
		}

		var mailRequest = new MailRequest
		{
			Subject = "Agency Request",
			ToEmail = emailReciever,
			Body = $"name: {agencyRequestDto.FirstName}<br/>" +
					$"family: {agencyRequestDto.LastName}<br/>" +
					$"father Name: {agencyRequestDto.FatherName}<br/>" +
					$"gender: {agencyRequestDto.Gender}<br/>" +
					$"birth date: {agencyRequestDto.BirthDate.ToString("yyyy/MM/dd")}<br/>" +
					$"national code: {agencyRequestDto.NationalCode}<br/>" +
					$"phone number: {agencyRequestDto.PhoneNumber}<br/>" +
					$"education level: {agencyRequestDto.EducationLevel}<br/>" +
					$"education field: {agencyRequestDto.EducationField}<br/>" +
					$"nezam vazife status: {agencyRequestDto.NezamVazifeStatus}<br/>" +
					$"province: {agencyRequestDto.Province}<br/>" +
					$"city: {agencyRequestDto.City}<br/>" +
					$"has work history on insurance companies: {agencyRequestDto.HasWorkHistoryOnInsuranceCompanies}<br/>" +
					$"description: {agencyRequestDto.Description}<br/>",
		};
		await mailService.SendEmailAsync(mailRequest);
		return Ok();
	}

	/// <summary>
	/// Agency renew license post
	/// </summary>
	/// <param name="customFileGetService">custom File Get Service</param>
	/// <param name="agencyRenewLicenseRequest">agency renew license request dto</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded homes</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpPost("agencyRenewLicense")]
	[AllowAnonymous]
	public async Task<IActionResult> AgencyRenewLicense(
		[FromServices] ICustomFileGetService customFileGetService,
		AgencyRenewLicenseRequestDto agencyRenewLicenseRequest,
		CancellationToken cancellationToken)
	{
		var personalPicture = customFileGetService.GetModelById(agencyRenewLicenseRequest.PersonalPictureId, CustomFileType.Image, cancellationToken);
		var expiredLicensePicture = customFileGetService.GetModelById(agencyRenewLicenseRequest.ExpiredLicensePictureId, CustomFileType.Image, cancellationToken);
		var ezharTaxPicture = customFileGetService.GetModelById(agencyRenewLicenseRequest.EzharTaxPictureId, CustomFileType.Image, cancellationToken);
		var ezharTaxPaymentPicture = customFileGetService.GetModelById(agencyRenewLicenseRequest.EzharTaxPaymentPictureId, CustomFileType.Image, cancellationToken);
		var taxPicture = customFileGetService.GetModelById(agencyRenewLicenseRequest.TaxPictureId, CustomFileType.Image, cancellationToken);
		var taxPaymentPicture = customFileGetService.GetModelById(agencyRenewLicenseRequest.TaxPaymentPictureId, CustomFileType.Image, cancellationToken);
		var rentPicture = customFileGetService.GetModelById(agencyRenewLicenseRequest.RentPictureId, CustomFileType.Image, cancellationToken);

		var bizAgiWSParam = new Core.WebServiceDomain.Models.Agency.BizAgiWSParam
		{
			domain = "Armanins.local",
			userName = "b_bizagi",
		};
		bizAgiWSParam.Cases = new Core.WebServiceDomain.Models.Agency.BizAgiWSParamCases
		{
			Case = new Core.WebServiceDomain.Models.Agency.BizAgiWSParamCasesCase
			{
				Process = "RenewalOfAgencyLic",
			},
		};
		bizAgiWSParam.Cases.Case.Entities = new Core.WebServiceDomain.Models.Agency.BizAgiWSParamCasesCaseEntities
		{
			AP_RenewalOfAgencyLicens = new Core.WebServiceDomain.Models.Agency.BizAgiWSParamCasesCaseEntitiesAP_RenewalOfAgencyLicens
			{
				agentCode = agencyRenewLicenseRequest.AgentCode,
				BranchName = agencyRenewLicenseRequest.BranchId,
				cellPhone = agencyRenewLicenseRequest.PhoneNumber,
				Description = agencyRenewLicenseRequest.Description,
				Name = agencyRenewLicenseRequest.FirstName,
				Family = agencyRenewLicenseRequest.LastName,
				nationalCode = agencyRenewLicenseRequest.NationalCode,
			},
		};

		bizAgiWSParam.Cases.Case.Entities.AP_RenewalOfAgencyLicens.ap_checklist = new Core.WebServiceDomain.Models.Agency.BizAgiWSParamCasesCaseEntitiesAP_RenewalOfAgencyLicensAP_CheckList[7];
		bizAgiWSParam.Cases.Case.Entities.AP_RenewalOfAgencyLicens.ap_checklist[0] = new Core.WebServiceDomain.Models.Agency.BizAgiWSParamCasesCaseEntitiesAP_RenewalOfAgencyLicensAP_CheckList
		{
			DocType = 102571,
			AttachFile = new Core.WebServiceDomain.Models.Agency.BizAgiWSParamCasesCaseEntitiesAP_RenewalOfAgencyLicensAP_CheckListAttachFile
			{
				File = new Core.WebServiceDomain.Models.Agency.BizAgiWSParamCasesCaseEntitiesAP_RenewalOfAgencyLicensAP_CheckListAttachFileFile
				{
					fileName = personalPicture.Name,
					Value = Convert.ToBase64String(personalPicture.Content),
				},
			},
		};
		bizAgiWSParam.Cases.Case.Entities.AP_RenewalOfAgencyLicens.ap_checklist[1] = new Core.WebServiceDomain.Models.Agency.BizAgiWSParamCasesCaseEntitiesAP_RenewalOfAgencyLicensAP_CheckList
		{
			DocType = 102573,
			AttachFile = new Core.WebServiceDomain.Models.Agency.BizAgiWSParamCasesCaseEntitiesAP_RenewalOfAgencyLicensAP_CheckListAttachFile
			{
				File = new Core.WebServiceDomain.Models.Agency.BizAgiWSParamCasesCaseEntitiesAP_RenewalOfAgencyLicensAP_CheckListAttachFileFile
				{
					fileName = expiredLicensePicture.Name,
					Value = Convert.ToBase64String(expiredLicensePicture.Content),
				},
			},
		};
		bizAgiWSParam.Cases.Case.Entities.AP_RenewalOfAgencyLicens.ap_checklist[2] = new Core.WebServiceDomain.Models.Agency.BizAgiWSParamCasesCaseEntitiesAP_RenewalOfAgencyLicensAP_CheckList
		{
			DocType = 102574,
			AttachFile = new Core.WebServiceDomain.Models.Agency.BizAgiWSParamCasesCaseEntitiesAP_RenewalOfAgencyLicensAP_CheckListAttachFile
			{
				File = new Core.WebServiceDomain.Models.Agency.BizAgiWSParamCasesCaseEntitiesAP_RenewalOfAgencyLicensAP_CheckListAttachFileFile
				{
					fileName = ezharTaxPicture.Name,
					Value = Convert.ToBase64String(ezharTaxPicture.Content),
				},
			},
		};
		bizAgiWSParam.Cases.Case.Entities.AP_RenewalOfAgencyLicens.ap_checklist[3] = new Core.WebServiceDomain.Models.Agency.BizAgiWSParamCasesCaseEntitiesAP_RenewalOfAgencyLicensAP_CheckList
		{
			DocType = 102575,
			AttachFile = new Core.WebServiceDomain.Models.Agency.BizAgiWSParamCasesCaseEntitiesAP_RenewalOfAgencyLicensAP_CheckListAttachFile
			{
				File = new Core.WebServiceDomain.Models.Agency.BizAgiWSParamCasesCaseEntitiesAP_RenewalOfAgencyLicensAP_CheckListAttachFileFile
				{
					fileName = ezharTaxPaymentPicture.Name,
					Value = Convert.ToBase64String(ezharTaxPaymentPicture.Content),
				},
			},
		};
		bizAgiWSParam.Cases.Case.Entities.AP_RenewalOfAgencyLicens.ap_checklist[4] = new Core.WebServiceDomain.Models.Agency.BizAgiWSParamCasesCaseEntitiesAP_RenewalOfAgencyLicensAP_CheckList
		{
			DocType = 102578,
			AttachFile = new Core.WebServiceDomain.Models.Agency.BizAgiWSParamCasesCaseEntitiesAP_RenewalOfAgencyLicensAP_CheckListAttachFile
			{
				File = new Core.WebServiceDomain.Models.Agency.BizAgiWSParamCasesCaseEntitiesAP_RenewalOfAgencyLicensAP_CheckListAttachFileFile
				{
					fileName = taxPicture.Name,
					Value = Convert.ToBase64String(taxPicture.Content),
				},
			},
		};
		bizAgiWSParam.Cases.Case.Entities.AP_RenewalOfAgencyLicens.ap_checklist[5] = new Core.WebServiceDomain.Models.Agency.BizAgiWSParamCasesCaseEntitiesAP_RenewalOfAgencyLicensAP_CheckList
		{
			DocType = 102579,
			AttachFile = new Core.WebServiceDomain.Models.Agency.BizAgiWSParamCasesCaseEntitiesAP_RenewalOfAgencyLicensAP_CheckListAttachFile
			{
				File = new Core.WebServiceDomain.Models.Agency.BizAgiWSParamCasesCaseEntitiesAP_RenewalOfAgencyLicensAP_CheckListAttachFileFile
				{
					fileName = taxPaymentPicture.Name,
					Value = Convert.ToBase64String(taxPaymentPicture.Content),
				},
			},
		};
		bizAgiWSParam.Cases.Case.Entities.AP_RenewalOfAgencyLicens.ap_checklist[6] = new Core.WebServiceDomain.Models.Agency.BizAgiWSParamCasesCaseEntitiesAP_RenewalOfAgencyLicensAP_CheckList
		{
			DocType = 102583,
			AttachFile = new Core.WebServiceDomain.Models.Agency.BizAgiWSParamCasesCaseEntitiesAP_RenewalOfAgencyLicensAP_CheckListAttachFile
			{
				File = new Core.WebServiceDomain.Models.Agency.BizAgiWSParamCasesCaseEntitiesAP_RenewalOfAgencyLicensAP_CheckListAttachFileFile
				{
					fileName = rentPicture.Name,
					Value = Convert.ToBase64String(rentPicture.Content),
				},
			},
		};

		var s = bizAgiWSParam.ToXML();
		return Ok();
	}

	/// <summary>
	/// join us
	/// </summary>
	/// <param name="customFileGetService">custom File Get Service</param>
	/// <param name="joinusRequestDto">join us request dto</param>
	/// <param name="cancellationToken">Cancellation token</param>
	/// <returns>Founded homes</returns>
	[ProducesResponseType((int)HttpStatusCode.OK)]
	[HttpPost("joinus")]
	[AllowAnonymous]
	public async Task<IActionResult> Joinus(
		[FromServices] ICustomFileGetService customFileGetService,
		JoinusRequestDto joinusRequestDto,
		CancellationToken cancellationToken)
	{
		var resumeFile = customFileGetService.GetModelById(joinusRequestDto.OfficialResume.FileId, CustomFileType.File, cancellationToken);

		var bizAgiWSParam = new Core.WebServiceDomain.Models.Joinus.BizAgiWSParam
		{
			domain = "Armanins.local",
			userName = "b_bizagi",
		};
		bizAgiWSParam.Cases = new Core.WebServiceDomain.Models.Joinus.BizAgiWSParamCases
		{
			Case = new Core.WebServiceDomain.Models.Joinus.BizAgiWSParamCasesCase
			{
				Process = "HR_JobRequest",
				Entities = new Core.WebServiceDomain.Models.Joinus.BizAgiWSParamCasesCaseEntities(),
			},
		};
		bizAgiWSParam.Cases.Case.Entities.HR_JobRequest = new Core.WebServiceDomain.Models.Joinus.BizAgiWSParamCasesCaseEntitiesHR_JobRequest
		{
			Name = joinusRequestDto.FirstName,
			Family = joinusRequestDto.LastName,
			Gender = joinusRequestDto.GenderId,
			Fathersname = joinusRequestDto.FatherName,
			NationaID = joinusRequestDto.NationalCode,
			Identificationcardnumber = joinusRequestDto.IdentificationCardNumber,
			Provinceofbirth = joinusRequestDto.BirthProvinceId,
			Placeofbirth = joinusRequestDto.BirthCityId,
			Provinceofresidence = joinusRequestDto.ResidenceProvinceId,
			Cityofresidence = joinusRequestDto.ResidenceCityId,
			Birthday = joinusRequestDto.BirthDate,
			MarriageStatus = joinusRequestDto.MarriageStatusId,
			eMail = joinusRequestDto.EmailAdsress,
			Telephone = joinusRequestDto.HomeNumber,
			Address = joinusRequestDto.Address,
			CellphoneNumber = joinusRequestDto.PhoneNumber,
			Edu = new Core.WebServiceDomain.Models.Joinus.BizAgiWSParamCasesCaseEntitiesHR_JobRequestEdu[joinusRequestDto.Educations.Count],
			Skills = new Core.WebServiceDomain.Models.Joinus.BizAgiWSParamCasesCaseEntitiesHR_JobRequestSkills[joinusRequestDto.Skills.Count],
			Jobshistory = new Core.WebServiceDomain.Models.Joinus.BizAgiWSParamCasesCaseEntitiesHR_JobRequestJobshistory[joinusRequestDto.JobsHistory.Count],
			JobList = new Core.WebServiceDomain.Models.Joinus.BizAgiWSParamCasesCaseEntitiesHR_JobRequestJobList[joinusRequestDto.JobList.Count],
			Officialresume = new Core.WebServiceDomain.Models.Joinus.BizAgiWSParamCasesCaseEntitiesHR_JobRequestOfficialresume
			{
				File = new Core.WebServiceDomain.Models.Joinus.BizAgiWSParamCasesCaseEntitiesHR_JobRequestOfficialresumeFile
				{
					fileName = resumeFile.Name,
					Value = Convert.ToBase64String(resumeFile.Content),
				},
			},
		};

		for (var i = 0; i < joinusRequestDto.Educations.Count; i++)
		{
			bizAgiWSParam.Cases.Case.Entities.HR_JobRequest.Edu[i] = new Core.WebServiceDomain.Models.Joinus.BizAgiWSParamCasesCaseEntitiesHR_JobRequestEdu
			{
				Thelasteducationalcerti = joinusRequestDto.Educations.ElementAt(i).TheLastEducationalCerti,
				Nameofplaceofstudy = joinusRequestDto.Educations.ElementAt(i).NameOfPlaceOfStudy,
				Fieldofstudy = joinusRequestDto.Educations.ElementAt(i).FieldOfStudy,
				Rateofgrade = joinusRequestDto.Educations.ElementAt(i).RateOfGrade,
				Provinceofstudy = joinusRequestDto.Educations.ElementAt(i).ProvinceOfStudy,
				Cityofstudy = joinusRequestDto.Educations.ElementAt(i).CityOfStudy,
			};
		}

		for (var i = 0; i < joinusRequestDto.Skills.Count; i++)
		{
			bizAgiWSParam.Cases.Case.Entities.HR_JobRequest.Skills[i] = new Core.WebServiceDomain.Models.Joinus.BizAgiWSParamCasesCaseEntitiesHR_JobRequestSkills
			{
				SkillsName = joinusRequestDto.Skills.ElementAt(i).SkillsName,
				Skilllevel = joinusRequestDto.Skills.ElementAt(i).SkillLevel,
			};
		}

		for (var i = 0; i < joinusRequestDto.JobsHistory.Count; i++)
		{
			bizAgiWSParam.Cases.Case.Entities.HR_JobRequest.Jobshistory[i] = new Core.WebServiceDomain.Models.Joinus.BizAgiWSParamCasesCaseEntitiesHR_JobRequestJobshistory
			{
				Activitytype = joinusRequestDto.JobsHistory.ElementAt(i).ActivityType,
				Enddateofjob = joinusRequestDto.JobsHistory.ElementAt(i).EndDateOfJob,
				Startdateofjob = joinusRequestDto.JobsHistory.ElementAt(i).StartDateOfJob,
				Lastworkplace = joinusRequestDto.JobsHistory.ElementAt(i).LastWorkPlace,
				Telephonscompany = joinusRequestDto.JobsHistory.ElementAt(i).TelephonsCompany,
			};
		}

		for (var i = 0; i < joinusRequestDto.JobList.Count; i++)
		{
			bizAgiWSParam.Cases.Case.Entities.HR_JobRequest.JobList[i] = new Core.WebServiceDomain.Models.Joinus.BizAgiWSParamCasesCaseEntitiesHR_JobRequestJobList
			{
				JBCAT_Level1 = joinusRequestDto.JobList.ElementAt(i).JBCAT_Level1,
				JBCAT_Level2 = joinusRequestDto.JobList.ElementAt(i).JBCAT_Level2,
			};
		}

		var s = bizAgiWSParam.ToXML();
		return Ok();
	}
}
