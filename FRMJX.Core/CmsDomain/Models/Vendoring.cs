﻿namespace FRMJX.Core.CmsDomain.Models;

using FRMJX.Core.BaseDataDomain.Models;
using FRMJX.Core.Infrastructure;

public class Vendoring : BaseLocalizedExtendedEntity
{
	public string FirstName { get; set; }

	public string LastName { get; set; }

	public string FatherName { get; set; }

	public string Gender { get; set; }

	public DateTime BirthDay { get; set; }

	public string NationalCode { get; set; }

	public string MobileNumber { get; set; }

	public string DegreeOfEducation { get; set; }

	public string FieldOfStudy { get; set; }

	public string MilitaryService { get; set; }

	public int StateId { get; set; }

	public int CityId { get; set; }

	public string Description { get; set; }

	public bool WorkExperience { get; set; }

	public State State { get; set; }

	public City City { get; set; }
}
