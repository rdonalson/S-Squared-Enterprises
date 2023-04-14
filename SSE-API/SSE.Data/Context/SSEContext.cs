using Microsoft.EntityFrameworkCore;
using SSE.Data.Domain;

namespace SSE.Data.Context
{
	public class SSEContext : DbContext
	{
		public SSEContext(DbContextOptions<SSEContext> options)
			: base(options)
		{
		}

		public DbSet<Employee> Employees { get; set; }
		public DbSet<Role> Roles { get; set; }
		public DbSet<EmployeeRole> EmployeeRoles { get; set; }
		public DbSet<Principality> Principalities { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Employee>()
				.HasMany(e => e.EmployeeRoles)
				.WithOne(er => er.Employee)
				.HasForeignKey(er => er.EmployeeId);

			modelBuilder.Entity<Role>()
				.HasMany(r => r.EmployeeRoles)
				.WithOne(er => er.Role)
				.HasForeignKey(er => er.RoleId);

			modelBuilder.Entity<EmployeeRole>()
				.HasKey(er => er.Id);

			modelBuilder.Entity<Employee>()
				.HasOne(e => e.Principality)
				.WithMany(p => p.Employees)
				.HasForeignKey(e => e.PrincipalityId)
				.IsRequired(false);
		}
	}
}
