using Arshia_Store.Application.Interfaces.Contexts;
using Arshia_Store.Common.UserRoles;
using Arshia_Store.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Arshai_Store.Presistence.Contexts
{
	public class StoreDbContext : DbContext, IStoreDbContext
	{
		public StoreDbContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<User> Users { get; set; }
		public DbSet<Role> Roles { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// making defualte roles
			modelBuilder.Entity<Role>().HasData(new Role { Id = (int)UserRoles.Admin, Name = UserRoles.Admin.ToString() });
			modelBuilder.Entity<Role>().HasData(new Role { Id = (int)UserRoles.Operator, Name = UserRoles.Operator.ToString() });
			modelBuilder.Entity<Role>().HasData(new Role { Id = (int)UserRoles.Costumer, Name = UserRoles.Costumer.ToString() });

			// make emails unique
			modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();

			// show only un-removed users
			modelBuilder.Entity<User>().HasQueryFilter(u => u.IsRemoved == false);
		}
	}
}
