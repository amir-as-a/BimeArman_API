namespace FRMJX.Core.Infrastructure.Framework.Dtos.Grid;

using System.Collections.Generic;

public class GridResultDto<T>
{
	public int TotalCount { get; set; }

	public List<T> Records { get; set; }
}
