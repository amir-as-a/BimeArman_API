namespace FRMJX.Core.SecurityDomain.Dtos.Responses;

using FRMJX.Core.Infrastructure.Framework.Dtos.Grid;
using System.Collections.Generic;

public class RoleGetWithPagingResponseDto : ISortable, ISearchable
{
	public long Id { get; set; }

	public string Name { get; set; }

	public string Description { get; set; }

	public List<string> GetSearchInformation() =>
		new()
		{
			nameof(Name),
			nameof(Description),
		};

	public List<(string Property, string Path)> GetSortInformation() =>
		new()
		{
			(nameof(Name), nameof(Name)),
			(nameof(Description), nameof(Description)),
		};
}
