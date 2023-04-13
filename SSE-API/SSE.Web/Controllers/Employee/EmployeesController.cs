using Microsoft.AspNetCore.Mvc;
using SSE.Data.Context;
using SSE.Infrastructure.Interfaces;
using SSE.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SSE.Web.Controllers.Employee
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmployeesController : ControllerBase
	{
		private readonly IEmployeeRepository _employeeRepository;

		public EmployeesController(SSEContext context)
		{
			_employeeRepository = new EmployeeRepository(context);
		}

		public async Task<ActionResult<List<Data.Domain.Employee>>> GetEmployees()
		{
			return await _employeeRepository.GetEmployees();
		}
	}
}
