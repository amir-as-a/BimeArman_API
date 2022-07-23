namespace FRMJX.Core.CmsDomain.Dtos.Responses;

using FRMJX.Core.Infrastructure;

public class SearchResponseDto
{
	public List<InsuranceGetResponseDto> Insurances { get; set; }

	public List<BlogPostGetResponseDto> BlogPosts { get; set; }
}
