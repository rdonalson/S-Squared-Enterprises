using System.Collections.Generic;

namespace SSE.Data.Domain
{
	public class Principality
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public ICollection<Employee> Employees { get; set; }
	}
}
