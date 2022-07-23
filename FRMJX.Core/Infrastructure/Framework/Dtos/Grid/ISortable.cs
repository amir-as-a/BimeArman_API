namespace FRMJX.Core.Infrastructure.Framework.Dtos.Grid;

using System.Collections.Generic;

public interface ISortable
{
	List<(string Property, string Path)> GetSortInformation();
}
