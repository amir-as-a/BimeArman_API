namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Models;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

internal class EmployeeCreateService : IEmployeeCreateService
{
	private readonly DatabaseContext databaseContext;

	public EmployeeCreateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult<int>> Create(
		EmployeeCreateAndUpdateRequestDto employeeCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult<int>();

		var employee = new Employee
		{
			CultureLcid = employeeCreateAndUpdateDto.CultureLcid,
			IsActive = employeeCreateAndUpdateDto.IsActive,
			Ordering = employeeCreateAndUpdateDto.Ordering,
			FirstName = employeeCreateAndUpdateDto.FirstName,
			LastName = employeeCreateAndUpdateDto.LastName,
			Gender = employeeCreateAndUpdateDto.Gender,
			Email = employeeCreateAndUpdateDto.Email,
			Position = employeeCreateAndUpdateDto.Position,
			MobileNumber = employeeCreateAndUpdateDto.MobileNumber,
			Age = employeeCreateAndUpdateDto.Age,
			NationalCode = employeeCreateAndUpdateDto.NationalCode,
			UserName = employeeCreateAndUpdateDto.UserName,
			Password = employeeCreateAndUpdateDto.Password,
			CustomFileId = employeeCreateAndUpdateDto.CustomFileId,
			JobPositionId = employeeCreateAndUpdateDto.JobPositionId,
			InsertDateTime = DateTime.Now,
		};

		databaseContext.Employees.Add(employee);
		await databaseContext.SaveChangesAsync(cancellationToken);

		serviceResult.SetStatusCode(HttpStatusCode.Created);
		serviceResult.Result = employee.Id;

		return serviceResult;
	}
}
