namespace FRMJX.Core.Infrastructure.Framework.Dtos.Grid;

using System;
using System.Collections.Generic;
using System.Linq;

public class GridFilterDto
{
	public int PageSize { get; set; }

	public int PageNumber { get; set; }

	public string? SearchTerm { get; set; }

	public string? SortlColumns { get; set; }

	public string? SortDirections { get; set; }

	public List<GridSortDto> SortBy
	{
		get
		{
			var result = new List<GridSortDto>();

			var columns = SortlColumns?.Split(",") ?? Array.Empty<string>();
			var directions = SortDirections?.Split(",") ?? Array.Empty<string>();

			foreach (var column in columns.Select((value, index) => new { index, value }))
			{
				_ = Enum.TryParse(directions[column.index], out SortDirectionEnum directionEnum);

				result.Add(new GridSortDto { Column = column.value, Direction = directionEnum });
			}

			return result;
		}
	}
}
