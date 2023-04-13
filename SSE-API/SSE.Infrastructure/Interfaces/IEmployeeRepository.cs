using SSE.Data.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SSE.Infrastructure.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetEmployees();
    }
}