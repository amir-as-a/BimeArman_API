﻿namespace FRMJX.Core.CmsDomain.Dtos.Responses;

public class PdfGetResponseDto
{
	public int Id { get; set; }

	public string Title { get; set; }

	public string Description { get; set; }

	public int Ordering { get; set; }

	public bool IsActive { get; set; }

	public CustomFileGetResponseDto CustomFileGetResponseDto { get; set; }

	public CustomFileGetResponseDto ImageGetResponse { get; set; }
}
