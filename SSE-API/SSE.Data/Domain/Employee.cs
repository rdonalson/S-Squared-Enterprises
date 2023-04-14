using System.Collections.Generic;

namespace SSE.Data.Domain
{
	public class Employee
	{
		public int Id { get; set; }
		public string Last { get; set; }
		public string First { get; set; }
		public int? ManagerId { get; set; }
		public int? PrincipalityId { get; set; }

		public ICollection<EmployeeRole> EmployeeRoles { get; set; }
		public Principality Principality { get; set; }

	}
}
