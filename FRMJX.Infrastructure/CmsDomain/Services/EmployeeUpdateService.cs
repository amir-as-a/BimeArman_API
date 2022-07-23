namespace FRMJX.Infrastructure.CmsDomain.Services;

using FRMJX.Core.CmsDomain.Dtos.Requests;
using FRMJX.Core.CmsDomain.Services;
using FRMJX.Core.Infrastructure;
using FRMJX.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class EmployeeUpdateService : IEmployeeUpdateService
{
	private readonly DatabaseContext databaseContext;

	public EmployeeUpdateService(DatabaseContext databaseContext)
	{
		this.databaseContext = databaseContext;
	}

	public async Task<ServiceResult> Update(
		int id,
		EmployeeCreateAndUpdateRequestDto employeeCreateAndUpdateDto,
		CancellationToken cancellationToken)
	{
		var serviceResult = new ServiceResult();

		var employee = await databaseContext.Employees
			.SingleOrDefaultAsync(current => current.Id == id);

		if (employee is null)
		{
			serviceResult.SetStatusCode(HttpStatusCode.NotFound, "Employee not found");
			return serviceResult;
		}

		employee.FirstName = employeeCreateAndUpdateDto.FirstName;
		employee.LastName = employeeCreateAndUpdateDto.LastName;
		employee.UserName = employeeCreateAndUpdateDto.UserName;
		employee.Password = employeeCreateAndUpdateDto.Password;
		employee.Email = employeeCreateAndUpdateDto.Email;
		employee.Position = employeeCreateAndUpdateDto.Position;
		employee.MobileNumber = employeeCreateAndUpdateDto.MobileNumber;
		employee.Age = employeeCreateAndUpdateDto.Age;
		employee.Gender = employeeCreateAndUpdateDto.Gender;
		employee.NationalCode = employeeCreateAndUpdateDto.NationalCode;
		employee.JobPositionId = employeeCreateAndUpdateDto.JobPositionId;
		employee.CustomFileId = employeeCreateAndUpdateDto.CustomFileId;
		employee.Ordering = employeeCreateAndUpdateDto.Ordering;
		employee.IsActive = employeeCreateAndUpdateDto.IsActive;
		employee.UpdateDateTime = DateTime.Now;

		databaseContext.Update(employee);
		await databaseContext.SaveChangesAsync(cancellationToken);

		return serviceResult;
	}
}
