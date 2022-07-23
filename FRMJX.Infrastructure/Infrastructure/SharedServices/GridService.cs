namespace FRMJX.Infrastructure.Infrastructure.SharedServices;

using FRMJX.Core.Infrastructure.Framework.Dtos.Grid;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;

public class GridService<TModel, TDto> : IGridService<TModel, TDto>
	where TDto : ISortable, ISearchable, new()
{
	public async Task<(List<TModel> Records, int TotalCount)> ApplyGridFilterAsync(IQueryable<TModel> query, GridFilterDto gridFilterDto, CancellationToken cancellationToken)
	{
		query = ApplySearchTerm(query, gridFilterDto);

		var totalCount = await query.CountAsync(cancellationToken);

		query = MakeOrdering(query, gridFilterDto);
		query = MakePaging(query, gridFilterDto);

		var records = await query.ToListAsync(cancellationToken);

		return (records, totalCount);
	}

	public (List<TModel> Records, int TotalCount) ApplyGridFilter(IQueryable<TModel> query, GridFilterDto gridFilterDto)
	{
		query = ApplySearchTerm(query, gridFilterDto);

		var totalCount = query.Count();

		query = MakeOrdering(query, gridFilterDto);
		query = MakePaging(query, gridFilterDto);

		var records = query.ToList();

		return (records, totalCount);
	}

	private IQueryable<TModel> MakePaging(IQueryable<TModel> query, GridFilterDto gridFilterDto)
	{
		query = query
			.Skip((gridFilterDto.PageNumber - 1) * gridFilterDto.PageSize)
			.Take(gridFilterDto.PageSize);

		return query;
	}

	private IQueryable<TModel> MakeOrdering(IQueryable<TModel> query, GridFilterDto gridFilterDto)
	{
		var sortInformation = new TDto().GetSortInformation();

		if (gridFilterDto.SortBy.Any())
		{
			var dynamicSortResult = string.Empty;

			foreach (var sortBy in gridFilterDto.SortBy)
			{
				var actualColumnName = sortInformation.SingleOrDefault(current => current.Property.Equals(sortBy.Column, StringComparison.InvariantCultureIgnoreCase));

				dynamicSortResult = $"{dynamicSortResult}, {actualColumnName.Path} {(sortBy.Direction == SortDirectionEnum.Desc ? "desc" : string.Empty)}";
			}

			query = query.OrderBy(dynamicSortResult.Trim().TrimStart(',').TrimEnd(',').Trim());
		}

		return query;
	}

	private IQueryable<TModel> ApplySearchTerm(IQueryable<TModel> query, GridFilterDto gridFilterDto)
	{
		if (string.IsNullOrEmpty(gridFilterDto.SearchTerm) == false)
		{
			var searchInformation = new TDto().GetSearchInformation();
			if (searchInformation.Any())
			{
				var where = string.Empty;

				foreach (var item in searchInformation)
				{
					where = $"{where} || {item}.ToUpper().Contains(\"{gridFilterDto.SearchTerm}\".ToUpper())";
				}

				query = query.Where(where.Trim().TrimStart('|').Trim());
			}
		}

		return query;
	}
}
