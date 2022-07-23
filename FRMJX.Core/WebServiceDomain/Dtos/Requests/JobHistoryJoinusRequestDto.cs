namespace FRMJX.Core.WebServiceDomain.Dtos.Requests;

public class JobHistoryJoinusRequestDto
{
	public string LastWorkPlace { get; set; }

	public string ActivityType { get; set; }

	public string TelephonsCompany { get; set; }

	public DateTime StartDateOfJob { get; set; }

	public DateTime EndDateOfJob { get; set; }
}
