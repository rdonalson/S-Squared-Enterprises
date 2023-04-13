using Microsoft.EntityFrameworkCore;
using SSE.Data.Context;
using SSE.Data.Domain;
using SSE.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SSE.Infrastructure.Repositories
{
	public class EmployeeRepository : IEmployeeRepository
	{
		private readonly SSEContext _context;

		public EmployeeRepository(SSEContext context)
		{
			_context = context;
		}

		public async Task<List<Employee>> GetEmployees()
		{
			try
			{
				return await _context.Employees.ToListAsync();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return null;
			}
		}
	}
}
