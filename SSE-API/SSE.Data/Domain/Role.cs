using System.Collections.Generic;

namespace SSE.Data.Domain
{
	public class Role
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public ICollection<EmployeeRole> EmployeeRoles { get; set; }
	}
}
